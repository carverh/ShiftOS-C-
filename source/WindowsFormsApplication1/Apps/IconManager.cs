using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class IconManager : Form
    {
        public IconManager()
        {
            InitializeComponent();
        }

        private void IconManager_Load(object sender, EventArgs e)
        {
            GetAllIcons();
        }

        public void GetAllIcons()
        {
            pnlicons.Widgets.Clear();
            pnlicons.Margin = new Padding(0);
            foreach(var kv in API.IconRegistry)
            {
                var ctrl = new IconWidget();
                ctrl.Margin = new Padding(0);
                ctrl.IconName = kv.Key;
                ctrl.LargeImage = kv.Value;
                pnlicons.Widgets.Add(ctrl);
                ctrl.Show();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            foreach (Widget ctrl in pnlicons.Widgets)
            {
                try
                {
                    IconWidget ic = (IconWidget)ctrl;
                    Skinning.Utilities.IconRegistry[ic.IconName] = ic.LargeImage;
                }
                catch
                {
                    IconWidget ic = (IconWidget)ctrl;
                    Skinning.Utilities.IconRegistry.Add(ic.IconName, ic.LargeImage);
                }
            }

            var rnd = new Random();
            int cp = rnd.Next(0, 10);
            Skinning.Utilities.saveimages();
            API.AddCodepoints(cp);
            if(API.CurrentSession != null)
            {
                API.CurrentSession.SetupAppLauncher();
                API.CurrentSession.SetupDesktopIcons();
            }
            GetAllIcons();
            API.CreateInfoboxSession("Icon pack set.", $"Your icon pack has been set successfully. You have earned {cp} Codepoints.", infobox.InfoboxMode.Info);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".icn", File_Skimmer.FileSkimmerMode.Save);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    ZipFile.CreateFromDirectory(Paths.Icons, res);
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".icn", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    if(Directory.Exists(Paths.Mod_Temp + "icn"))
                    {
                        Directory.Delete(Paths.Mod_Temp + "icn", true);
                    }
                    ZipFile.ExtractToDirectory(res, Paths.Mod_Temp + "icn");
                    foreach (var f in Directory.GetFiles(Paths.Mod_Temp + "icn"))
                    {
                        var finf = new FileInfo(f);
                        try
                        {
                            var bytes = File.ReadAllBytes(finf.FullName);
                            using (var stream = new MemoryStream(bytes))
                            {
                                API.IconRegistry[finf.Name] = Image.FromStream(stream);
                            }
                        }
                        catch 
                        {
                            API.IconRegistry.Add(finf.Name, Image.FromFile(finf.FullName));
                        }
                        finf = null;
                    }
                    if (API.CurrentSession != null)
                    {
                        API.CurrentSession.SetupAppLauncher();
                        API.CurrentSession.SetupDesktopIcons();
                    }
                    GetAllIcons();
                    Directory.Delete(Paths.Mod_Temp + "icn", true);
                }
            };
        }
    }
}
