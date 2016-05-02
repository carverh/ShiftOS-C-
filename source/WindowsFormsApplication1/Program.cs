using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;
using System.Threading;

namespace ShiftOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Extract all dependencies before starting the engine.
            ExtractDependencies();
            var poolThread = new Thread(new ThreadStart(new Action(() => {
                //Download ShiftOS server startup-pool
                string pool = new WebClient().DownloadString("http://playshiftos.ml/server/startup_pool");
                string[] splitter = pool.Split(';');
                foreach(string address in splitter)
                {
                    try
                    {
                        string[] addSplitter = address.Split(':');
                        string host = addSplitter[0];
                        int port = Convert.ToInt32(addSplitter[1]);
                        Package_Grabber.ConnectToServer(host, port);
                    }
                    catch
                    {

                    }
                }
            })));
            poolThread.Start();
            //Start the Windows Forms backend
            Paths.RegisterPaths(); //Sets ShiftOS path variables based on the current OS.
            SaveSystem.Utilities.CheckForOlderSaves(); //Backs up C:\ShiftOS on Windows systems if it exists and doesn't contain a _engineInfo.txt file telling ShiftOS what engine created it.
            //If there isn't a save folder at the directory specified by ShiftOS.Paths.SaveRoot, create a new save.
            //If not, load that save.
            if (Directory.Exists(Paths.SaveRoot))
            {
                API.Log("Loading ShiftOS save...");
                SaveSystem.Utilities.loadGame();
            } else
            {
                SaveSystem.Utilities.NewGame();
            }
            //Load ShiftOS skin
            Skinning.Utilities.loadskin();
            SaveSystem.ShiftoriumRegistry.UpdateShiftorium();
            //Start recieving calls from the Modding API...
            Application.Run(new ShiftOSDesktop());
            //By now, the API receiver has been loaded,
            //and the desktop is shown. So, let's check
            //for auto-start mods.
            if(Directory.Exists(Paths.AutoStart))
            {
                foreach(string file in Directory.GetFiles(Paths.AutoStart))
                {
                    var inf = new FileInfo(file);
                    switch(inf.Extension)
                    {
                        case ".saa":
                            if (API.Upgrades["shiftnet"] == true)
                            {
                                API.Log("Starting start-up mod \"" + inf.FullName + "\"...");
                                API.LaunchMod(inf.FullName);
                            }
                            break;
                        case ".trm":
                            var t = new Terminal();
                            t.runterminalfile(inf.FullName);
                            API.Log("Started terminal file \"" + inf.FullName + "\"...");
                            break;
                    }                }
            }
            //Now, for some ShiftOS launcher integration.
            try
            {
                if(args[0] != null)
                {
                    if(args[0] != "")
                    {
                        API.CurrentSave.username = args[0];
                        //Username set.
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
        static void ExtractDependencies()
        {
            //Wow. This'll make it easy for people...
            string path = Directory.GetParent(Application.ExecutablePath).FullName;
            string temppath = path + OSInfo.DirectorySeparator + "temp";
            string zippath = path + OSInfo.DirectorySeparator + "depend.zip";
            var wc = new WebClient();
            //Newtonsoft.Json is REQUIRED for the ShiftOS engine to start.
            if(!File.Exists(path + OSInfo.DirectorySeparator + "Svg.dll"))
            {
                wc.DownloadFile("http://playshiftos.ml/shiftos/dependencies/Svg.dll", path + OSInfo.DirectorySeparator + "Svg.dll");
            }
            if (!File.Exists(path + OSInfo.DirectorySeparator + "Newtonsoft.Json.dll"))
            {
                wc.DownloadFile("http://playshiftos.ml/shiftos/dependencies/Newtonsoft.Json.dll", path + OSInfo.DirectorySeparator + "Newtonsoft.Json.dll");
            }
            //Download optional dependencies.
            wc.DownloadFileCompleted += (object s, AsyncCompletedEventArgs e) =>
            {
                if(Directory.Exists(temppath))
                {
                    Directory.Delete(temppath, true);
                }
                bool firstfile = false;
                ZipFile.ExtractToDirectory(zippath, temppath);
                foreach (string f in Directory.GetFiles(temppath))
                {
                    var finf = new FileInfo(f);
                    if (!File.Exists(path + OSInfo.DirectorySeparator + finf.Name))
                    {
                        File.Copy(finf.FullName, path + OSInfo.DirectorySeparator + finf.Name);
                    }
                }
                //Delete that damn temp folder and zip file.
                File.Delete(zippath);
                Directory.Delete(temppath, true);
            };
            //Because these files aren't needed for ShiftOS to function fundamentally, they're downloaded asynchronously in the background.
            try
            {
                //Create a new Lua API object, and a new Gecko web renderer. If the job fails, then redownload requisite libraries after notifying the user.
                var l = new LuaInterpreter();
                var w = new Gecko.GeckoWebBrowser();
                l = null;
                w.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry to break the immersion, but we're currently downloading ShiftOS dependencies that'll make the game run MUCH better, such as the Lua engine and Gecko web renderer. Give us a moment. ShiftOS will continue to run while this happens but some things won't work right until we're finished.");
                wc.DownloadFileAsync(new Uri("http://playshiftos.ml/shiftos/dependencies/ShiftOS_Dependencies.zip"), zippath);
            }
            
        }
    }
}
