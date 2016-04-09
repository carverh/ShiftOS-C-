using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using NetSockets;

namespace ShiftOS
{
    [Serializable]
    public class ObjectModel
    {
        public string SysId { get; set; }
        public string Command { get; set; }
        public object OptionalObject { get; set; }
    }

    [Serializable]
    public class ChatUser
    {
        public string Name { get; set; }
        public event EventHandler OnJoin;
        public event EventHandler OnLeave;
    }

    [Serializable]
    public class ChatMessage
    {
        public string Text { get; set; }
        public ChatUser User { get; set; }
    }

    class Package_Grabber
    {


        public static Dictionary<string, NetObjectClient> clients = null;

        /// <summary>
        /// Connect to a ShiftOS server
        /// </summary>
        /// <param name="address">IP address</param>
        /// <param name="port">Port (typically this is 4433.)</param>
        public static void ConnectToServer(string address, int port)
        {
            if(clients == null)
            {
                clients = new Dictionary<string, NetObjectClient>();
            }
            var client = new NetObjectClient();
            client.OnReceived += (object s, NetReceivedEventArgs<NetObject> a) => {
                try {
                    var obj = (ObjectModel)a.Data.Object;
                    if (obj.Command == "set_ident")
                    {
                        this_id = obj.SysId;
                    }
                }
                catch
                {

                }
            };

            try
            {
                client.Connect(address, port);
                clients.Add(client.RemoteHost, client);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private static string this_id = "";

        /// <summary>
        /// Send a message to a server.
        /// </summary>
        /// <param name="host">Server hostname/IP</param>
        /// <param name="text">Messge contents.</param>
        public static void SendMessage(string host, string text)
        {
            var obj = new ObjectModel();
            obj.SysId = this_id;
            obj.Command = text;
            try {
                clients[host].Send(new NetObject("test", obj));
            }
            catch
            {

            }
        }

        /// <summary>
        /// Send a message to a server containing a .NET object.
        /// </summary>
        /// <param name="host">Server hostname/IP</param>
        /// <param name="text">Message text.</param>
        /// <param name="optional">The object to go with it.</param>
        public static void SendMessage(string host, string text, object optional)
        {
            var obj = new ObjectModel();
            obj.SysId = this_id;
            obj.Command = text;
            obj.OptionalObject = optional;
            try {
                clients[host].Send(obj.SysId, obj);
            }
            catch
            {

            }
        }



        /// <summary>
        /// Disconnect from a server.
        /// </summary>
        /// <param name="host">Server host.</param>
        public static void Disconnect(string host)
        {
            if(clients.ContainsKey(host))
            {
                if(clients[host].IsConnected == true)
                {
                    clients[host].Disconnect();
                }
            }
        }


        /// <summary>
        /// Download a package through spkg.
        /// </summary>
        /// <param name="pkgname">Package name</param>
        /// <returns>Could it download?</returns>
        public static bool GetPackage(string pkgname)
        {
            bool result = true;
            try
            {
                string downloadpath = Paths.Mod_Temp;
                if (!Directory.Exists(downloadpath))
                {
                    Directory.CreateDirectory(downloadpath);
                } else
                {
                    Directory.Delete(downloadpath, true);
                    Directory.CreateDirectory(downloadpath);
                }
                WebClient wc = new WebClient();
                wc.DownloadFile("http://playshiftos.ml/shiftnet/packages/" + pkgname + ".pkg", downloadpath + pkgname + ".pkg");
                LastPackage_DownloadPath = downloadpath + pkgname + ".pkg";
            }
            catch (WebException wex)
            {
                result = false;
            }
            return result;
        }

        public static string LastPackage_DownloadPath = null;

        /// <summary>
        /// Extracts the last downloaded package.
        /// </summary>
        /// <returns>The temp path</returns>
        public static string ExtractPackage()
        {
            if (LastPackage_DownloadPath != null)
            {
                string packagedir = null;
                if (LastPackage_DownloadPath.EndsWith(".pkg"))
                {
                    packagedir = LastPackage_DownloadPath.Replace(".pkg", "");
                }
                else
                {
                    packagedir = LastPackage_DownloadPath.Replace(".stp", "");
                }
                if (Directory.Exists(packagedir))
                {
                    Directory.Delete(packagedir, true);
                }
                ZipFile.ExtractToDirectory(LastPackage_DownloadPath, packagedir);
                return packagedir;
            }
            else
            {
                return "fail";
            }
        }

        /// <summary>
        /// Extract a specified .stp or .pkg file.
        /// </summary>
        /// <param name="localpath">File to extract</param>
        /// <returns>The new temp path</returns>
        public static string ExtractPackage(string localpath)
        {
            try {

                string packagedir = Paths.Mod_Temp + "pkg";
                if (Directory.Exists(packagedir))
                {
                    Directory.Delete(packagedir, true);
                }
                Directory.CreateDirectory(packagedir);
                ZipFile.ExtractToDirectory(localpath, packagedir);
                return packagedir;
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        /// <summary>
        /// Install a package from a directory
        /// </summary>
        /// <param name="dir">The package directory</param>
        /// <returns>Could it install?</returns>
        public static string InstallPackage(string dir)
        {
            try
            {
                string dirsepchar = "\\";
                switch (OSInfo.GetPlatformID())
                {
                    case "microsoft":
                        dirsepchar = "\\";
                        break;
                    default:
                        dirsepchar = "/";
                        break;
                }
                string alfile = null;
                foreach (string file in Directory.GetFiles(dir))
                {
                    if (file.Contains("applauncher"))
                    {
                        alfile = file;
                    }
                }
                string json = File.ReadAllText(alfile);
                if (!Directory.Exists(Paths.Mod_AppLauncherEntries))
                {
                    Directory.CreateDirectory(Paths.Mod_AppLauncherEntries);
                }
                ModApplauncherItem itm = JsonConvert.DeserializeObject<ModApplauncherItem>(json);
                File.WriteAllText(Paths.Mod_AppLauncherEntries + itm.Name, json);
                //Applauncher Entry installed!
                if (!Directory.Exists(Paths.Applications + itm.AppDirectory))
                {
                    Directory.CreateDirectory(Paths.Applications + itm.AppDirectory);
                }

                Thread.Sleep(200);
                if (!File.Exists(Paths.Applications + itm.AppDirectory + dirsepchar + "Icon.bmp"))
                {
                    File.Copy(dir + "Icon.bmp", Paths.Applications + itm.AppDirectory + dirsepchar + "Icon.bmp");
                }
                if (File.Exists(Paths.Applications + itm.AppDirectory + dirsepchar + "app.saa"))
                {
                    File.Delete(Paths.Applications + itm.AppDirectory + dirsepchar + "app.saa");
                }
                File.Move(dir + "app.saa", Paths.Applications + itm.AppDirectory + dirsepchar + "app.saa");
                //App installed.
                foreach (string file in Directory.GetFiles(dir))
                {
                    if (file.EndsWith(".dll"))
                    {
                        if (!File.Exists(Paths.Applications + itm.AppDirectory + dirsepchar + new FileInfo(file).Name))
                        {
                            //Dependencies are fucking bitches.
                            File.Copy(file, Paths.Applications + itm.AppDirectory + dirsepchar + new FileInfo(file).Name);
                        }
                    }
                }
                //Dependencies installed.
                API.CurrentSession.SetupAppLauncher();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    class FTP_API
    {
        /// <summary>
        /// Gets a package image from the ShiftOS website
        /// </summary>
        /// <param name="ftpFilePath">Image path relative to the packages directory</param>
        /// <returns>The image</returns>
        [Obsolete]
        public static Image GetImage(string ftpFilePath)
        {
            var request = WebRequest.Create("http://playshiftos.ml/appscape/packages/" + ftpFilePath);

            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                    return Image.FromStream(str);
                }
            }
        }

        [Obsolete]
        public static Image GetSkinImage(string ftpFilePath)
        {
            var request = WebRequest.Create("http://playshiftos.ml/appscape/skins/" + ftpFilePath);

            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                    return Image.FromStream(str);
                }
            }
        }
    }


    [Serializable]
    public class AppscapeModder
    {
        public string DevKey { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string BitnoteAddress { get; set; }
    }

    [Serializable]
    public class AppscapePackage
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string DevKey { get; set; }
        public string Description { get; set; }
        public string SetupFile { get; set; }
        public string PkgIconPath { get; set; }
        public string ScreenshotPath { get; set; }
        public decimal Cost { get; set; }
        public string Server { get; set; }
    }

    [Serializable]
    public class SkinData
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Download { get; set; }
        public string Icon { get; set; }
        public string Screenshot { get; set; }
        public decimal Cost { get; set; }
        public string Server { get; set; }
    }
}
