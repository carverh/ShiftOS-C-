using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class AppscapeUploader : Form
    {
        /// <summary>
        /// Front-end to handle uploading of an Appscape package.
        /// </summary>
        /// <param name="modder">The developer of the new package.</param>
        /// <param name="repo">The client representing the repository to upload to.</param>
        public AppscapeUploader(AppscapeModder modder, AppscapeClient repo)
        {
            InitializeComponent();
            MyProfile = modder;
            Repo = repo;
        }

        private AppscapeModder MyProfile = null;
        private AppscapeClient Repo = null;

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndone_Click(object sender, EventArgs e)
        {
            bool ContinueUpload = true;
            //Create new package and assign values
            var pkg = new AppscapePackage();
            pkg.Name = txtpackagename.Text;
            pkg.DevKey = MyProfile.DevKey;
            pkg.Description = txtpackagedescription.Text;
            if (cbsell.Checked == true)
            {
                try
                {
                    pkg.Cost = Convert.ToDecimal(Convert.ToDecimal(txtprice.Text).ToString("#.#####"));
                }
                catch
                {
                    ContinueUpload = false;
                    API.CreateInfoboxSession("Error", "You have entered an incorrect price value.", infobox.InfoboxMode.Info);
                }
            }
            else {
                pkg.Cost = 0;
            }
            pkg.SetupFile = pkg.Name.Replace(" ", "_");
            pkg.PkgIconPath = "";
            if(AppScreenshot != null)
            {
                pkg.ScreenshotPath = new FileInfo(AppScreenshot).Name.Replace(" ", "_");
            }
            else
            {
                pkg.ScreenshotPath = "none.jpg";
            }
            if (ContinueUpload == true) {
                //Upload the package meta file
                
                if (!Directory.Exists(Paths.Mod_Temp + "newapm")) {
                    Directory.CreateDirectory(Paths.Mod_Temp + "newapm");
                }
                else
                {
                    Directory.Delete(Paths.Mod_Temp + "newapm", true);
                    Directory.CreateDirectory(Paths.Mod_Temp + "newapm");
                }

                //Copy app SAA and icon to package folder
                File.Copy(SAAFile, Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "app.saa");
                if (AppIcon != null)
                {
                    File.Copy(AppIcon, Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "Icon.bmp");
                }
                else
                {
                    Properties.Resources.iconShiftnet.Save(Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "Icon.bmp");
                }

                //Create AL meta file for package (so it will display in the app launcher)
                var al = new ModApplauncherItem();
                al.Display = true;
                al.Icon = "Icon.bmp";
                al.Name = pkg.Name;
                al.ShiftCode = "runSAA:app.saa";
                al.AppDirectory = al.Name;

                //Serialize AL meta file and copy to package
                var json = JsonConvert.SerializeObject(al);
                File.WriteAllText(Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "applauncher", json);

                //Package file to .stp and upload to Appscape
                ZipFile.CreateFromDirectory(Paths.Mod_Temp + "newapm", Paths.Mod_Temp + pkg.Name.Replace(" ", "_") + ".stp");
                Repo.UploadPackage(pkg, File.ReadAllBytes(Paths.Mod_Temp + pkg.Name.Replace(" ", "_") + ".stp"));



                this.Close();
            }
        }

        
        int page = 0;

        /// <summary>
        /// Makes the specified control and ALL of it's children, grand children, great grand children, and so on, appear "dark".
        /// </summary>
        /// <param name="ctrl">The top of the hierarchy; the start of it all.</param>
        private void RecursiveWidgetSetup(Widget ctrl)
        {
            ctrl.BackColor = API.CurrentSkin.titlebarcolour;
            ctrl.ForeColor = API.CurrentSkin.titletextcolour;
            try
            {
                var pnl = (Panel)ctrl;
                foreach(Widget c in pnl.Widgets)
                {
                    RecursiveWidgetSetup(c);
                }
            }
            catch {

            }
        }

        /// <summary>
        /// Sets up the user interface.
        /// </summary>
        private void SetupUI()
        {
            RecursiveWidgetSetup(pnlmain);
            switch (page)
            {
                case 0:
                    lbtitle.Text = "Welcome!";
                    lbldescription.Text = "This wizard will guide you through the creation of an Appscape Package which will be uploaded to Appscape for all to see. First, let's start with some basics.";
                    Page0.BringToFront();
                    btndone.Hide();
                    btnback.Hide();
                    break;
                case 1:
                    lbtitle.Text = "Packaged Files";
                    lbldescription.Text = "Now that we have a name and description, it's time to get some files into your package. Namely, an icon and the app itself.";
                    btnback.Show();
                    Page1.BringToFront();
                    break;
                case 2:
                    lbtitle.Text = "Ready!";
                    lbldescription.Text = "That's all we need from you. Assuming everything is correct, as soon as you click 'Done!', the package will be generated and uploaded to Appscape quicker than you can say \"Appscape Package Manager is so freakin' awesome.\".";
                    btnnext.Hide();
                    btndone.Show();
                    Page2.BringToFront();
                    txtconfirm.Font = new Font(OSInfo.GetMonospaceFont(), 9);
                    ConfirmPKG();
                    break;
            }
        }

        /// <summary>
        /// Makes sure the package is ready for upload.
        /// </summary>
        private void ConfirmPKG()
        {
            txtconfirm.Text = "";
            WriteLine(" == Basics == ");
            WriteLine($"Name: {txtpackagename.Text}");
            WriteLine($"Description: {txtpackagedescription.Text}");
            WriteLine("");
            WriteLine(" == Files == ");
            if(SAAFile != null)
            {
                WriteLine(SAAFile);
            }
            else
            {
                WriteLine("no saa file");
            }
            WriteLine(AppIcon);
            WriteLine(AppScreenshot);
            WriteLine("");
            WriteLine(" == Package Check == ");
            CheckForErrors();
            foreach(string err in Errors)
            {
                WriteLine(" - " + err);
                btndone.Hide();
            }
            if(Errors.Count > 0)
            {
                WriteLine("Please go back and correct these errors.");
            }
        }

        private List<string> Errors = null;

        /// <summary>
        /// Checks for package errors.
        /// </summary>
        private void CheckForErrors()
        {
            Errors = new List<string>();
            if(txtpackagename.Text.Length < 1)
            {
                Errors.Add("Your package doesn't have a name.");
            }
            if(SAAFile == null)
            {
                Errors.Add("Your package won't contain a .saa file, therefore it won't be installed by ShiftOS!");
            }
        }

        /// <summary>
        /// Writes a line to the summary box.
        /// </summary>
        /// <param name="text">Text to write.</param>
        private void WriteLine(string text)
        {
            if(txtconfirm.Text == "")
            {
                txtconfirm.Text = text;
            }
            else
            {
                txtconfirm.Text += Environment.NewLine + text;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            page += 1;
            SetupUI();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            page -= 1;
            SetupUI();
        }

        private void AppscapeUploader_Load(object sender, EventArgs e)
        {
            SetupUI();
        }

        private string SAAFile = null;
        private string AppIcon = null;
        private string AppScreenshot = null;

        private void btnsaa_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".saa", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    SAAFile = res;
                    btnsaa.Text = new FileInfo(SAAFile).Name;
                }
            };
        }

        private void btnicon_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".bmp;.png;.jpg;.pic", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    AppIcon = res;
                    btnicon.Text = new FileInfo(res).Name;
                }
            };
        }

        private void btnscreenshot_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".bmp;.png;.jpg;.pic", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    AppScreenshot = res;
                    btnscreenshot.Text = new FileInfo(res).Name;
                }
            };
        }

        private void btncompilesaa_Click(object sender, EventArgs e)
        {
            //Source code folder finder
            API.CreateFileSkimmerSession("dir", File_Skimmer.FileSkimmerMode.OpenFolder);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    if(File.Exists(res + OSInfo.DirectorySeparator + "main.lua")) {
                        string dir = res;
                        API.CreateFileSkimmerSession(".saa", File_Skimmer.FileSkimmerMode.Open);
                        API.FileSkimmerSession.FormClosing += (object s2, FormClosingEventArgs a2) =>
                        {
                            try
                            {
                                ZipFile.CreateFromDirectory(dir, API.GetFSResult());
                                API.CreateInfoboxSession("Success", "The SAA file has been created successfully.", infobox.InfoboxMode.Info);
                            }
                            catch
                            {
                                API.CreateInfoboxSession("Error", "Could not create the SAA file.", infobox.InfoboxMode.Info);
                            }
                        };
                    }
                    else {
                        API.CreateInfoboxSession("Invalid source", "Your source directory doesn't contain a main script (main.lua) file.", infobox.InfoboxMode.Info);
                    }
                }
            };
        }

        private void cbsell_CheckedChanged(object sender, EventArgs e)
        {
            lbprice.Visible = cbsell.Checked;
            lbaddress.Visible = cbsell.Checked;
            txtprice.Visible = cbsell.Checked;
        }

        private void lbprice_Click(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbaddress_Click(object sender, EventArgs e)
        {

        }

        private void txtpackagedescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpackagename_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
