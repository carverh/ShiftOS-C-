using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class SkinLoader : Form
    {
        public SkinLoader()
        {
            InitializeComponent();
        }

        public Skinning.Skin PreviewSkin = null;
        public Skinning.Images PreviewImages = null;

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string LoadedSkinFile = "fail";

        public void LoadSkin(string res)
        {
            LoadedSkinFile = res;
            ExtractSkin(res);
            SetupDesktop();
            setupborders();
            setuptitlebar();
            setskin();
        }

        private void ExtractSkin(string file)
        {
            if(Directory.Exists(Paths.ToBeLoaded))
            {
                Directory.Delete(Paths.ToBeLoaded, true);
            }
            API.ExtractFile(file, Paths.ToBeLoaded, false);
            PreviewSkin = JsonConvert.DeserializeObject<Skinning.Skin>(File.ReadAllText(Paths.ToBeLoaded + "data.json"));
            LoadImages();
        }

        private void LoadImages()
        {
            PreviewImages = new Skinning.Images();
            PreviewImages.applauncherclick = GetImage(PreviewSkin.applauncherclickpath);
            PreviewImages.panelbutton = GetImage(PreviewSkin.panelbuttonpath);
            PreviewImages.applaunchermouseover = GetImage(PreviewSkin.applaunchermouseoverpath);
            PreviewImages.applauncher = GetImage(PreviewSkin.applauncherpath);
            PreviewImages.panelclock = GetImage(PreviewSkin.panelclockpath);
            PreviewImages.desktopbackground = GetImage(PreviewSkin.desktopbackgroundpath);
            PreviewImages.desktoppanel = GetImage(PreviewSkin.desktoppanelpath);
            PreviewImages.minbtnhover = GetImage(PreviewSkin.minbtnhoverpath);
            PreviewImages.minbtnclick = GetImage(PreviewSkin.minbtnclickpath);
            PreviewImages.rightcorner = GetImage(PreviewSkin.rightcornerpath);
            PreviewImages.titlebar = GetImage(PreviewSkin.titlebarpath);
            PreviewImages.borderright = GetImage(PreviewSkin.borderrightpath);
            PreviewImages.borderleft = GetImage(PreviewSkin.borderleftpath);
            PreviewImages.borderbottom = GetImage(PreviewSkin.borderbottompath);
            PreviewImages.closebtn = GetImage(PreviewSkin.closebtnpath);
            PreviewImages.closebtnhover = GetImage(PreviewSkin.closebtnhoverpath);
            PreviewImages.closebtnclick = GetImage(PreviewSkin.closebtnclickpath);
            PreviewImages.rollbtn = GetImage(PreviewSkin.rollbtnpath);
            PreviewImages.rollbtnhover = GetImage(PreviewSkin.rollbtnhoverpath);
            PreviewImages.rollbtnclick = GetImage(PreviewSkin.rollbtnclickpath);
            PreviewImages.minbtn = GetImage(PreviewSkin.minbtnpath);
            PreviewImages.leftcorner = GetImage(PreviewSkin.leftcornerpath);
            PreviewImages.bottomleftcorner = GetImage(PreviewSkin.bottomleftcornerpath);
            PreviewImages.bottomrightcorner = GetImage(PreviewSkin.bottomrightcornerpath);
        }

        private Bitmap GetImage(string fileName)
        {
            Bitmap ret;
            if (File.Exists(Paths.ToBeLoaded + fileName))
            {
                using (Image img = Image.FromFile(Paths.ToBeLoaded + fileName))
                {
                    ret = new Bitmap(img);
                }
            }
            else
            {
                ret = null;
            }
            return ret;
        }

        private void btnloadskin_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".skn;.spk", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string res = API.GetFSResult();
                if(res != "fail")
                {
                    if(res.EndsWith(".skn"))
                    {
                        LoadedSkinFile = res;
                        ExtractSkin(res);
                        SetupDesktop();
                        setupborders();
                        setuptitlebar();
                        setskin();
                    }
                    else if(res.EndsWith(".spk"))
                    {
                        LoadedPack = res;
                        SetupPackUI();
                    }
                }
            };
        }

        public string LoadedPack = "";

        public void SetupPackUI()
        {
            pgcontents.Hide();
            pnlskinpacks.Show();

            txtpackpath.Text = LoadedPack;

            if(Directory.Exists(Paths.SkinDir + "_packdata"))
            {
                Directory.Delete(Paths.SkinDir + "_packdata", true);
            }
            API.ExtractFile(LoadedPack, Paths.SkinDir + "_packdata", false);
            cbpackfiles.Items.Clear();
            foreach (string file in Directory.GetFiles(Paths.SkinDir + "_packdata"))
            {
                var finf = new FileInfo(file);
                cbpackfiles.Items.Add(finf.Name);

            }
        }

        private void ScanForSkinFiles(string dir, ref List<string> files)
        {
            foreach(string file in Directory.GetFiles(dir))
            {
                var finf = new FileInfo(file);
                if(finf.Extension == ".skn")
                {
                    files.Add(finf.FullName);
                }
            }
            foreach(string dirname in Directory.GetDirectories(dir))
            {
                ScanForSkinFiles(dirname, ref files);
            }
        }

        private void btnapplyskin_Click(object sender, EventArgs e)
        {
            if(LoadedSkinFile != "fail")
            {
                try
                {
                    if (Viruses.InfectedWith("skininceptor"))
                    {
                        var rnd = new Random();
                        switch(rnd.Next(0, 10))
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 9:
                                //Load another random skin.
                                List<string> skinfiles = new List<string>();
                                ScanForSkinFiles(Paths.SaveRoot, ref skinfiles);
                                string fname = skinfiles[rnd.Next(0, skinfiles.Count - 1)];
                                Skinning.Utilities.loadsknfile(fname);
                                Skinning.Utilities.loadskin();
                                API.CurrentSession.SetupDesktop();
                                API.UpdateWindows();
                                break;
                            default:
                                File.Delete(LoadedSkinFile);
                                //Corrupting binary is fun.
                                API.CreateInfoboxSession("Skin Loader - Error", "It appears that the provided skin file is either corrupted or not supported by this version of ShiftOS.", infobox.InfoboxMode.Info);
                                Skinning.Utilities.loadedSkin = new Skinning.Skin();
                                Skinning.Utilities.loadedskin_images = new Skinning.Images();
                                API.UpdateWindows();
                                break;
                        }
                    }
                    else {
                        Skinning.Utilities.loadsknfile(LoadedSkinFile);
                        Skinning.Utilities.loadskin();
                        API.CurrentSession.SetupDesktop();
                        API.UpdateWindows();
                        PreviewSkin = API.CurrentSkin;
                        PreviewImages = API.CurrentSkinImages;
                        SetupDesktop();
                        setupborders();
                        setuptitlebar();
                        setskin();
                    }
                }
                catch (Exception ex)
                {
                    if (API.DeveloperMode == false)
                    {
                        API.CreateInfoboxSession("Skin Loader - Error", "It appears that the provided skin file is either corrupted or not supported by this version of ShiftOS.", infobox.InfoboxMode.Info);
                    }
                    else
                    {
                        API.CreateInfoboxSession("Skin Loader - Error", ex.Message, infobox.InfoboxMode.Info);
                    }
                }
            }
            else
            {
                API.CreateInfoboxSession("Skin Loader - Error", "You have not selected a skin file to load! Try pressing \"Load Skin\" and selecting a .skn file.", infobox.InfoboxMode.Info);
            }
        }

        private void SkinLoader_Load(object sender, EventArgs e)
        {

            PreviewSkin = API.CurrentSkin;
            PreviewImages = API.CurrentSkinImages;
            LoadPreview();
            pnlskinpacks.Hide();
            pgcontents.Show();
        }

        private void LoadPreview()
        {
            SetupDesktop();
            setupborders();
            setuptitlebar();
            setskin();

        }

        #region Preview Skinning

        public void SetupDesktop()
        {

            if (API.Upgrades["desktoppanel"] == true)
            {
                if (PreviewImages.desktoppanel == null)
                {
                    predesktoppanel.BackColor = PreviewSkin.desktoppanelcolour;
                    predesktoppanel.BackgroundImage = null;
                }
                else {
                    predesktoppanel.BackgroundImage = PreviewImages.desktoppanel;
                    predesktoppanel.BackgroundImageLayout = (ImageLayout)PreviewSkin.desktoppanellayout;
                    predesktoppanel.BackColor = Color.Transparent;
                }

                predesktoppanel.Size = new Size(predesktoppanel.Size.Width, PreviewSkin.desktoppanelheight);
                switch (PreviewSkin.desktoppanelposition)
                {
                    case "Top":
                        predesktoppanel.Dock = DockStyle.Top;
                        predesktopappmenu.Dock = DockStyle.Top;
                        break;
                    case "Bottom":
                        predesktoppanel.Dock = DockStyle.Bottom;
                        predesktopappmenu.Dock = DockStyle.Bottom;
                        break;
                }
                predesktoppanel.Show();
            }
            else {
                predesktoppanel.Hide();
            }


            if (API.Upgrades["applaunchermenu"] == true)
            {
                ApplicationsToolStripMenuItem.Font = new Font(PreviewSkin.applicationbuttontextfont, PreviewSkin.applicationbuttontextsize, PreviewSkin.applicationbuttontextstyle);
                ApplicationsToolStripMenuItem.Text = PreviewSkin.applicationlaunchername;



                ApplicationsToolStripMenuItem.Height = PreviewSkin.applicationbuttonheight;
                if (PreviewImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.Text = "";
                    ApplicationsToolStripMenuItem.BackColor = Color.Transparent;
                }
                else {
                    ApplicationsToolStripMenuItem.Text = PreviewSkin.applicationlaunchername;
                    ApplicationsToolStripMenuItem.BackColor = PreviewSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImage = null;
                }

                preapplaunchermenuholder.Width = PreviewSkin.applaunchermenuholderwidth;
                predesktopappmenu.Width = PreviewSkin.applaunchermenuholderwidth;
                ApplicationsToolStripMenuItem.Width = PreviewSkin.applaunchermenuholderwidth;
                preapplaunchermenuholder.Height = PreviewSkin.applicationbuttonheight;
                predesktopappmenu.Height = PreviewSkin.applicationbuttonheight;
                ApplicationsToolStripMenuItem.Height = PreviewSkin.applicationbuttonheight;

                if (PreviewImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.BackgroundImage = PreviewImages.applauncher;
                }
                else {
                    ApplicationsToolStripMenuItem.BackColor = PreviewSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImageLayout = (ImageLayout)PreviewSkin.applauncherlayout;
                }
            }
            else {
                ApplicationsToolStripMenuItem.Visible = false;
            }

            if (API.Upgrades["desktoppanelclock"] == true)
            {

                prepaneltimetext.ForeColor = PreviewSkin.clocktextcolour;

                if (PreviewImages.panelclock == null)
                {
                    pretimepanel.BackColor = PreviewSkin.clockbackgroundcolor;
                    pretimepanel.BackgroundImage = null;
                }
                else {
                    pretimepanel.BackColor = Color.Transparent;
                    pretimepanel.BackgroundImage = PreviewImages.panelclock;
                    pretimepanel.BackgroundImageLayout = (ImageLayout)PreviewSkin.panelclocklayout;
                }
                prepaneltimetext.Font = new Font(PreviewSkin.panelclocktextfont, PreviewSkin.panelclocktextsize, PreviewSkin.panelclocktextstyle);
                pretimepanel.Size = new Size(prepaneltimetext.Width + 3, pretimepanel.Height);
                prepaneltimetext.Location = new Point(0, PreviewSkin.panelclocktexttop);
                pretimepanel.Show();
            }
            else {
                pretimepanel.Hide();
            }


            ApplicationsToolStripMenuItem.BackColor = PreviewSkin.applauncherbuttoncolour;

            pnldesktoppreview.BackColor = PreviewSkin.desktopbackgroundcolour;
            pnldesktoppreview.BackgroundImage = PreviewImages.desktopbackground;
            pnldesktoppreview.BackgroundImageLayout = (ImageLayout)PreviewSkin.desktopbackgroundlayout;

            if (API.Upgrades["panelbuttons"] == true)
            {
                prepnlpanelbutton.Visible = API.Upgrades["panelbuttons"];

                pretbicon.Image = Properties.Resources.iconTerminal;
                pretbctext.Text = "Terminal";

                prepnlpanelbutton.Margin = new Padding(0, PreviewSkin.panelbuttonfromtop, PreviewSkin.panelbuttongap, 0);

                if (API.Upgrades["appicons"] == true)
                {
                    pretbicon.Show();
                }
                else
                {
                    pretbicon.Hide();
                }
                pretbicon.Location = new Point(PreviewSkin.panelbuttoniconside, PreviewSkin.panelbuttonicontop);
                pretbicon.Size = new Size(PreviewSkin.panelbuttoniconsize, PreviewSkin.panelbuttoniconsize);
                prepnlpanelbutton.Size = new Size(PreviewSkin.panelbuttonwidth, PreviewSkin.panelbuttonheight);
                prepnlpanelbutton.BackColor = PreviewSkin.panelbuttoncolour;
                prepnlpanelbutton.BackgroundImage = PreviewImages.panelbutton;
                prepnlpanelbutton.BackgroundImageLayout = (ImageLayout)PreviewSkin.panelbuttonlayout;
                pretbctext.ForeColor = PreviewSkin.panelbuttontextcolour;
                pretbctext.Font = new Font(PreviewSkin.panelbuttontextfont, PreviewSkin.panelbuttontextsize, PreviewSkin.panelbuttontextstyle);
                pretbctext.Location = new Point(PreviewSkin.panelbuttontextside, PreviewSkin.panelbuttontexttop);


                pretbicon.Size = new Size(PreviewSkin.panelbuttoniconsize, PreviewSkin.panelbuttoniconsize);

            }
            prepnlpanelbuttonholder.Padding = new Padding(PreviewSkin.panelbuttoninitialgap, 0, 0, 0);


        }



        public void setskin()
        {

            //disposals
            preclosebutton.BackgroundImage = null;
            pretitlebar.BackgroundImage = null;
            prerollupbutton.BackgroundImage = null;
            prepgtoplcorner.BackgroundImage = null;
            prepgtoprcorner.BackgroundImage = null;
            preminimizebutton.BackgroundImage = null;
            //apply new skin
            if (PreviewImages.closebtn == null)
                preclosebutton.BackColor = PreviewSkin.closebtncolour;
            else
                preclosebutton.BackgroundImage = PreviewImages.closebtn;
            preclosebutton.BackgroundImageLayout = (ImageLayout)PreviewSkin.closebtnlayout;
            if (PreviewImages.titlebar == null)
                pretitlebar.BackColor = PreviewSkin.titlebarcolour;
            else
                pretitlebar.BackgroundImage = PreviewImages.titlebar;
            pretitlebar.BackgroundImageLayout = (ImageLayout)PreviewSkin.titlebarlayout;
            if (PreviewImages.rollbtn == null)
                prerollupbutton.BackColor = PreviewSkin.rollbtncolour;
            else
                prerollupbutton.BackgroundImage = PreviewImages.rollbtn;
            prerollupbutton.BackgroundImageLayout = (ImageLayout)PreviewSkin.rollbtnlayout;
            if (PreviewImages.leftcorner == null)
                prepgtoplcorner.BackColor = PreviewSkin.leftcornercolour;
            else
                prepgtoplcorner.BackgroundImage = PreviewImages.leftcorner;
            prepgtoplcorner.BackgroundImageLayout = (ImageLayout)PreviewSkin.leftcornerlayout;
            if (PreviewImages.rightcorner == null)
                prepgtoprcorner.BackColor = PreviewSkin.rightcornercolour;
            else
                prepgtoprcorner.BackgroundImage = PreviewImages.rightcorner;
            prepgtoprcorner.BackgroundImageLayout = (ImageLayout)PreviewSkin.rightcornerlayout;
            if (PreviewImages.minbtn == null)
                preminimizebutton.BackColor = PreviewSkin.minbtncolour;
            else
                preminimizebutton.BackgroundImage = PreviewImages.minbtn;
            preminimizebutton.BackgroundImageLayout = (ImageLayout)PreviewSkin.minbtnlayout;
            if (PreviewImages.borderleft == null)
                prepgleft.BackColor = PreviewSkin.borderleftcolour;
            else
                prepgleft.BackgroundImage = PreviewImages.borderleft;
            prepgleft.BackgroundImageLayout = (ImageLayout)PreviewSkin.borderleftlayout;
            if (PreviewImages.borderright == null)
                prepgright.BackColor = PreviewSkin.borderrightcolour;
            else
                prepgright.BackgroundImage = PreviewImages.borderright;
            prepgleft.BackgroundImageLayout = (ImageLayout)PreviewSkin.borderrightlayout;
            if (PreviewImages.borderbottom == null)
                prepgbottom.BackColor = PreviewSkin.borderbottomcolour;
            else
                prepgbottom.BackgroundImage = PreviewImages.borderbottom;
            prepgbottom.BackgroundImageLayout = (ImageLayout)PreviewSkin.borderbottomlayout;
            if (PreviewSkin.enablebordercorners == true)
            {
                if (PreviewImages.bottomleftcorner == null)
                    prepgbottomlcorner.BackColor = PreviewSkin.bottomleftcornercolour;
                else
                    prepgbottomlcorner.BackgroundImage = PreviewImages.bottomleftcorner;
                prepgbottomlcorner.BackgroundImageLayout = (ImageLayout)PreviewSkin.bottomleftcornerlayout;
                if (PreviewImages.bottomrightcorner == null)
                    prepgbottomrcorner.BackColor = PreviewSkin.bottomrightcornercolour;
                else
                    prepgbottomrcorner.BackgroundImage = PreviewImages.bottomrightcorner;
                prepgbottomrcorner.BackgroundImageLayout = (ImageLayout)PreviewSkin.bottomrightcornerlayout;
            }
            else {
                prepgbottomlcorner.BackColor = PreviewSkin.borderrightcolour;
                prepgbottomrcorner.BackColor = PreviewSkin.borderrightcolour;
                prepgbottomlcorner.BackgroundImage = null;
                prepgbottomrcorner.BackgroundImage = null;
            }

            //set bottom border corner size
            prepgbottomlcorner.Size = new Size(PreviewSkin.borderwidth, PreviewSkin.borderwidth);
            prepgbottomrcorner.Size = new Size(PreviewSkin.borderwidth, PreviewSkin.borderwidth);
            prepgbottomlcorner.Location = new Point(0, pnlwindowpreview.Height - PreviewSkin.borderwidth);
            prepgbottomrcorner.Location = new Point(pnlwindowpreview.Width, pnlwindowpreview.Height - PreviewSkin.borderwidth);
        }

        private void setupborders()
        {
            if (API.Upgrades["windowborders"] == false)
            {
                prepgleft.Hide();
                prepgbottom.Hide();
                prepgright.Hide();
            }
        }

        private void setuptitlebar()
        {
            setupborders();

            prepgleft.Width = PreviewSkin.borderwidth;
            prepgright.Width = PreviewSkin.borderwidth;
            prepgbottom.Height = PreviewSkin.borderwidth;
            pretitlebar.Height = PreviewSkin.titlebarheight;

            if (PreviewSkin.enablecorners == true)
            {
                prepgtoplcorner.Show();
                prepgtoprcorner.Show();
                prepgtoprcorner.Width = PreviewSkin.titlebarcornerwidth;
                prepgtoplcorner.Width = PreviewSkin.titlebarcornerwidth;
            }
            else {
                prepgtoplcorner.Hide();
                prepgtoprcorner.Hide();
            }

            if (API.Upgrades["titlebar"] == false)
            {
                pretitlebar.Hide();
            }

            if (API.Upgrades["titletext"] == false)
            {
                pretitletext.Hide();
            }
            else {
                pretitletext.Font = new Font(PreviewSkin.titletextfontfamily, PreviewSkin.titletextfontsize, PreviewSkin.titletextfontstyle, GraphicsUnit.Point);
                pretitletext.Text = "Your app name here";
                pretitletext.Show();
            }

            if (API.Upgrades["closebutton"] == false)
            {
                preclosebutton.Hide();
            }
            else {
                preclosebutton.BackColor = PreviewSkin.closebtncolour;
                preclosebutton.Size = PreviewSkin.closebtnsize;
                preclosebutton.Show();
            }

            if (API.Upgrades["rollupbutton"] == false)
            {
                prerollupbutton.Hide();
            }
            else {
                prerollupbutton.BackColor = PreviewSkin.rollbtncolour;
                prerollupbutton.Size = PreviewSkin.rollbtnsize;
                prerollupbutton.Show();
            }

            if (API.Upgrades["minimizebutton"] == false)
            {
                preminimizebutton.Hide();
            }
            else {
                preminimizebutton.BackColor = PreviewSkin.minbtncolour;
                preminimizebutton.Size = PreviewSkin.minbtnsize;
                preminimizebutton.Show();
            }

            if (API.Upgrades["windowborders"] == true)
            {
                preclosebutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.closebtnfromside - preclosebutton.Size.Width, PreviewSkin.closebtnfromtop);
                prerollupbutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.rollbtnfromside - prerollupbutton.Size.Width, PreviewSkin.rollbtnfromtop);
                preminimizebutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.minbtnfromside - preminimizebutton.Size.Width, PreviewSkin.minbtnfromtop);
                switch (PreviewSkin.titletextpos)
                {
                    case "Left":
                        pretitletext.Location = new Point(PreviewSkin.titletextfromside, PreviewSkin.titletextfromtop);
                        break;
                    case "Centre":
                        pretitletext.Location = new Point((pretitlebar.Width / 2) - pretitletext.Width / 2, PreviewSkin.titletextfromtop);
                        break;
                }
                pretitletext.ForeColor = PreviewSkin.titletextcolour;
            }
            else {
                preclosebutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.closebtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - preclosebutton.Size.Width, PreviewSkin.closebtnfromtop);
                prerollupbutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.rollbtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - prerollupbutton.Size.Width, PreviewSkin.rollbtnfromtop);
                preminimizebutton.Location = new Point(pretitlebar.Size.Width - PreviewSkin.minbtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - preminimizebutton.Size.Width, PreviewSkin.minbtnfromtop);
                switch (PreviewSkin.titletextpos)
                {
                    case "Left":
                        pretitletext.Location = new Point(PreviewSkin.titletextfromside + prepgtoplcorner.Width, PreviewSkin.titletextfromtop);
                        break;
                    case "Centre":
                        pretitletext.Location = new Point((pretitlebar.Width / 2) - pretitletext.Width / 2, PreviewSkin.titletextfromtop);
                        break;
                }
                pretitletext.ForeColor = PreviewSkin.titletextcolour;
            }

            //Change when Icon skinning complete
            // Change to program's icon
            if (API.Upgrades["appicons"] == true)
            {
                prepnlicon.Visible = true;
                prepnlicon.Location = new Point(PreviewSkin.titleiconfromside, PreviewSkin.titleiconfromtop);
                prepnlicon.Size = new Size(PreviewSkin.titlebariconsize, PreviewSkin.titlebariconsize);
                prepnlicon.Image = Properties.Resources.iconShifter;

            }

        }

        #endregion

        private void btnsaveskin_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".skn", File_Skimmer.FileSkimmerMode.Save);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string res = API.GetFSResult();
                if (res != "fail")
                {
                    Skinning.Utilities.saveskintofile(res);
                    API.CreateInfoboxSession("Skin Loader", "The skin has been saved successfully.", infobox.InfoboxMode.Info);
                }
            };
        }

        private void btnbacktoskinloader_Click(object sender, EventArgs e)
        {
            pnlskinpacks.Hide();
            pgcontents.Show();
        }

        private void cbpackfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbpackfiles.Text.EndsWith(".skn"))
            {
                string dirsepchar = "\\";
                switch(OSInfo.GetPlatformID())
                {
                    case "microsoft":
                        dirsepchar = "\\";
                        break;
                    default:
                        dirsepchar = "/";
                        break;
                }
                LoadedSkinFile = Paths.SkinDir + "_packdata" + dirsepchar + cbpackfiles.Text;
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".spk", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string res = API.GetFSResult();
                if(res != "fail")
                {
                    LoadedPack = res;
                    SetupPackUI();
                }
            };
        }
    }
}
