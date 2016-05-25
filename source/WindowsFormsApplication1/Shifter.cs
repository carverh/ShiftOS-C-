using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Shifter : Form
    {
        public Shifter()
        {
            InitializeComponent();
        }

        public Skinning.Skin CustomizingSkin = null;
        public Skinning.Images CustomizingImages = null;
        private bool EarnCP = false;

        public void AddCP(int amount)
        {
            if (EarnCP == true)
            {
                codepointstogive += amount;
            }
        }

        private void btndesktop_Click(object sender, EventArgs e)
        {
            HideAll();
            pnldesktopoptions.Show();
            pnldesktopoptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void SetPreviewSkin(bool updateValues)
        {
            EarnCP = false;
            predesktopappmenu.Renderer = new Skinning.MyToolStripRenderer(new AppLauncherColorTable());
            //fix apply button
            btnapply.BackColor = Color.White;
            btnapply.ForeColor = Color.Black;
            btnapply.Text = "Apply Changes";

            //Set Available Title Buttons
            combobuttonoption.Items.Clear();
            if(API.Upgrades["closebutton"])
            {
                combobuttonoption.Items.Add("Close");
            }
            if (API.Upgrades["rollupbutton"])
            {
                combobuttonoption.Items.Add("Roll Up");
            }
            if (API.Upgrades["minimizebutton"])
            {
                combobuttonoption.Items.Add("Minimize");
            }
            //set available options
            SetAvailableOptions();

            //windows
            setuptitlebar();
            setskin();

            //desktop
            SetupDesktop();

            //Setting Values
            if (updateValues == true)
            {
                EarnCP = false;
                SetupDesktopPanelValues();
                SetupAppLauncherValues();
                SetupPanelButtonValues();
                SetClockValues();
                SetupTitleTextValues();
                SetupBorderValues();
                SetupTitleBarValues();
                SetupButtonValues();
                SetupBasicMenuValues();
                SetupDropdownValues();
                SetupAdvancedMenuValues();
                SetupAnimationStyleValues();
            }
            EarnCP = true;
        }

        #region Preview Skinning

        public void SetupDesktop()
        {

            if (API.Upgrades["desktoppanel"] == true)
            {
                if (CustomizingImages.desktoppanel == null)
                {
                    predesktoppanel.BackColor = CustomizingSkin.desktoppanelcolour;
                    predesktoppanel.BackgroundImage = null;
                }
                else {
                    predesktoppanel.BackgroundImage = CustomizingImages.desktoppanel;
                    predesktoppanel.BackgroundImageLayout = (ImageLayout)CustomizingSkin.desktoppanellayout;
                    predesktoppanel.BackColor = Color.Transparent;
                }

                predesktoppanel.Size = new Size(predesktoppanel.Size.Width, CustomizingSkin.desktoppanelheight);
                switch (CustomizingSkin.desktoppanelposition)
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
                ApplicationsToolStripMenuItem.Font = new Font(CustomizingSkin.applicationbuttontextfont, CustomizingSkin.applicationbuttontextsize, CustomizingSkin.applicationbuttontextstyle);
                ApplicationsToolStripMenuItem.Text = CustomizingSkin.applicationlaunchername;



                ApplicationsToolStripMenuItem.Height = CustomizingSkin.applicationbuttonheight;
                if (CustomizingImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.Text = "";
                    ApplicationsToolStripMenuItem.BackColor = Color.Transparent;
                }
                else {
                    ApplicationsToolStripMenuItem.Text = CustomizingSkin.applicationlaunchername;
                    ApplicationsToolStripMenuItem.BackColor = CustomizingSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImage = null;
                }

                preapplaunchermenuholder.Width = CustomizingSkin.applaunchermenuholderwidth;
                predesktopappmenu.Width = CustomizingSkin.applaunchermenuholderwidth;
                ApplicationsToolStripMenuItem.Width = CustomizingSkin.applaunchermenuholderwidth;
                preapplaunchermenuholder.Height = CustomizingSkin.applicationbuttonheight;
                predesktopappmenu.Height = CustomizingSkin.applicationbuttonheight;
                ApplicationsToolStripMenuItem.Height = CustomizingSkin.applicationbuttonheight;

                if (CustomizingImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.BackgroundImage = CustomizingImages.applauncher;
                }
                else {
                    ApplicationsToolStripMenuItem.BackColor = CustomizingSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImageLayout = (ImageLayout)CustomizingSkin.applauncherlayout;
                }
            }
            else {
                ApplicationsToolStripMenuItem.Visible = false;
            }

            if (API.Upgrades["desktoppanelclock"] == true)
            {

                prepaneltimetext.ForeColor = CustomizingSkin.clocktextcolour;

                if (CustomizingImages.panelclock == null)
                {
                    pretimepanel.BackColor = CustomizingSkin.clockbackgroundcolor;
                    pretimepanel.BackgroundImage = null;
                }
                else {
                    pretimepanel.BackColor = Color.Transparent;
                    pretimepanel.BackgroundImage = CustomizingImages.panelclock;
                    pretimepanel.BackgroundImageLayout = (ImageLayout)CustomizingSkin.panelclocklayout;
                }
                prepaneltimetext.Font = new Font(CustomizingSkin.panelclocktextfont, CustomizingSkin.panelclocktextsize, CustomizingSkin.panelclocktextstyle);
                pretimepanel.Size = new Size(prepaneltimetext.Width + 3, pretimepanel.Height);
                prepaneltimetext.Location = new Point(0, CustomizingSkin.panelclocktexttop);
                pretimepanel.Show();
            }
            else {
                pretimepanel.Hide();
            }


            ApplicationsToolStripMenuItem.BackColor = CustomizingSkin.applauncherbuttoncolour;

            pnldesktoppreview.BackColor = CustomizingSkin.desktopbackgroundcolour;
            pnldesktoppreview.BackgroundImage = CustomizingImages.desktopbackground;
            pnldesktoppreview.BackgroundImageLayout = (ImageLayout)CustomizingSkin.desktopbackgroundlayout;

            if (API.Upgrades["panelbuttons"] == true)
            {
                prepnlpanelbutton.Visible = API.Upgrades["panelbuttons"];

                pretbicon.Image = Properties.Resources.iconTerminal;
                pretbctext.Text = "Terminal";

                prepnlpanelbutton.Margin = new Padding(0, CustomizingSkin.panelbuttonfromtop, CustomizingSkin.panelbuttongap, 0);

                if (API.Upgrades["appicons"] == true)
                {
                    pretbicon.Show();
                }
                else
                {
                    pretbicon.Hide();
                }
                pretbicon.Location = new Point(CustomizingSkin.panelbuttoniconside, CustomizingSkin.panelbuttonicontop);
                pretbicon.Size = new Size(CustomizingSkin.panelbuttoniconsize, CustomizingSkin.panelbuttoniconsize);
                prepnlpanelbutton.Size = new Size(CustomizingSkin.panelbuttonwidth, CustomizingSkin.panelbuttonheight);
                prepnlpanelbutton.BackColor = CustomizingSkin.panelbuttoncolour;
                prepnlpanelbutton.BackgroundImage = CustomizingImages.panelbutton;
                prepnlpanelbutton.BackgroundImageLayout = (ImageLayout)CustomizingSkin.panelbuttonlayout;
                pretbctext.ForeColor = CustomizingSkin.panelbuttontextcolour;
                pretbctext.Font = new Font(CustomizingSkin.panelbuttontextfont, CustomizingSkin.panelbuttontextsize, CustomizingSkin.panelbuttontextstyle);
                pretbctext.Location = new Point(CustomizingSkin.panelbuttontextside, CustomizingSkin.panelbuttontexttop);


                pretbicon.Size = new Size(CustomizingSkin.panelbuttoniconsize, CustomizingSkin.panelbuttoniconsize);

            }
            prepnlpanelbuttonholder.Padding = new Padding(CustomizingSkin.panelbuttoninitialgap, 0, 0, 0);


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
            if (CustomizingImages.closebtn == null)
                preclosebutton.BackColor = CustomizingSkin.closebtncolour;
            else
                preclosebutton.BackgroundImage = CustomizingImages.closebtn;
                preclosebutton.BackgroundImageLayout = (ImageLayout)CustomizingSkin.closebtnlayout;
            if (CustomizingImages.titlebar == null)
                pretitlebar.BackColor = CustomizingSkin.titlebarcolour;
            else
                pretitlebar.BackgroundImage = CustomizingImages.titlebar;
            pretitlebar.BackgroundImageLayout = (ImageLayout)CustomizingSkin.titlebarlayout;
            if (CustomizingImages.rollbtn == null)
                prerollupbutton.BackColor = CustomizingSkin.rollbtncolour;
            else
                prerollupbutton.BackgroundImage = CustomizingImages.rollbtn;
            prerollupbutton.BackgroundImageLayout = (ImageLayout)CustomizingSkin.rollbtnlayout;
            if (CustomizingImages.leftcorner == null)
                prepgtoplcorner.BackColor = CustomizingSkin.leftcornercolour;
            else
                prepgtoplcorner.BackgroundImage = CustomizingImages.leftcorner;
            prepgtoplcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.leftcornerlayout;
            if (CustomizingImages.rightcorner == null)
                prepgtoprcorner.BackColor = CustomizingSkin.rightcornercolour;
            else
                prepgtoprcorner.BackgroundImage = CustomizingImages.rightcorner;
            prepgtoprcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.rightcornerlayout;
            if (CustomizingImages.minbtn == null)
                preminimizebutton.BackColor = CustomizingSkin.minbtncolour;
            else
                preminimizebutton.BackgroundImage = CustomizingImages.minbtn;
            preminimizebutton.BackgroundImageLayout = (ImageLayout)CustomizingSkin.minbtnlayout;
            if (CustomizingImages.borderleft == null)
                prepgleft.BackColor = CustomizingSkin.borderleftcolour;
            else
                prepgleft.BackgroundImage = CustomizingImages.borderleft;
            prepgleft.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderleftlayout;
            if (CustomizingImages.borderright == null)
                prepgright.BackColor = CustomizingSkin.borderrightcolour;
            else
                prepgright.BackgroundImage = CustomizingImages.borderright;
            prepgleft.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderrightlayout;
            if (CustomizingImages.borderbottom == null)
                prepgbottom.BackColor = CustomizingSkin.borderbottomcolour;
            else
                prepgbottom.BackgroundImage = CustomizingImages.borderbottom;
            prepgbottom.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderbottomlayout;
            if (CustomizingSkin.enablebordercorners == true)
            {
                if (CustomizingImages.bottomleftcorner == null)
                    prepgbottomlcorner.BackColor = CustomizingSkin.bottomleftcornercolour;
                else
                    prepgbottomlcorner.BackgroundImage = CustomizingImages.bottomleftcorner;
                prepgbottomlcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomleftcornerlayout;
                if (CustomizingImages.bottomrightcorner == null)
                    prepgbottomrcorner.BackColor = CustomizingSkin.bottomrightcornercolour;
                else
                    prepgbottomrcorner.BackgroundImage = CustomizingImages.bottomrightcorner;
                prepgbottomrcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomrightcornerlayout;
            }
            else {
                prepgbottomlcorner.BackColor = CustomizingSkin.borderrightcolour;
                prepgbottomrcorner.BackColor = CustomizingSkin.borderrightcolour;
                prepgbottomlcorner.BackgroundImage = null;
                prepgbottomrcorner.BackgroundImage = null;
            }

            //set bottom border corner size
            prepgbottomlcorner.Size = new Size(CustomizingSkin.borderwidth, CustomizingSkin.borderwidth);
            prepgbottomrcorner.Size = new Size(CustomizingSkin.borderwidth, CustomizingSkin.borderwidth);
            prepgbottomlcorner.Location = new Point(0, pnlwindowpreview.Height - CustomizingSkin.borderwidth);
            prepgbottomrcorner.Location = new Point(pnlwindowpreview.Width, pnlwindowpreview.Height - CustomizingSkin.borderwidth);

            prepgright.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderrightlayout;
            prepgbottomrcorner.BackgroundImage = CustomizingImages.bottomrightcorner;
            prepgbottomlcorner.BackgroundImage = CustomizingImages.bottomleftcorner;
            prepgbottomrcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomrightcornerlayout;
            prepgbottomlcorner.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomleftcornerlayout;

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

            prepgleft.Width = CustomizingSkin.borderwidth;
            prepgright.Width = CustomizingSkin.borderwidth;
            prepgbottom.Height = CustomizingSkin.borderwidth;
            pretitlebar.Height = CustomizingSkin.titlebarheight;
            
            if (CustomizingSkin.enablecorners == true)
            {
                prepgtoplcorner.Show();
                prepgtoprcorner.Show();
                prepgtoprcorner.Width = CustomizingSkin.titlebarcornerwidth;
                prepgtoplcorner.Width = CustomizingSkin.titlebarcornerwidth;
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
                pretitletext.Font = new Font(CustomizingSkin.titletextfontfamily, CustomizingSkin.titletextfontsize, CustomizingSkin.titletextfontstyle, GraphicsUnit.Point);
                pretitletext.Text = "Preview";
                pretitletext.Show();
            }

            if (API.Upgrades["closebutton"] == false)
            {
                preclosebutton.Hide();
            }
            else {
                preclosebutton.BackColor = CustomizingSkin.closebtncolour;
                preclosebutton.Size = CustomizingSkin.closebtnsize;
                preclosebutton.Show();
            }

            if (API.Upgrades["rollupbutton"] == false)
            {
                prerollupbutton.Hide();
            }
            else {
                prerollupbutton.BackColor = CustomizingSkin.rollbtncolour;
                prerollupbutton.Size = CustomizingSkin.rollbtnsize;
                prerollupbutton.Show();
            }

            if (API.Upgrades["minimizebutton"] == false)
            {
                preminimizebutton.Hide();
            }
            else {
                preminimizebutton.BackColor = CustomizingSkin.minbtncolour;
                preminimizebutton.Size = CustomizingSkin.minbtnsize;
                preminimizebutton.Show();
            }

            if (API.Upgrades["windowborders"] == true)
            {
                preclosebutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.closebtnfromside - preclosebutton.Size.Width, CustomizingSkin.closebtnfromtop);
                prerollupbutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.rollbtnfromside - prerollupbutton.Size.Width, CustomizingSkin.rollbtnfromtop);
                preminimizebutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.minbtnfromside - preminimizebutton.Size.Width, CustomizingSkin.minbtnfromtop);
                switch (CustomizingSkin.titletextpos)
                {
                    case "Left":
                        pretitletext.Location = new Point(CustomizingSkin.titletextfromside, CustomizingSkin.titletextfromtop);
                        break;
                    case "Centre":
                        pretitletext.Location = new Point((pretitlebar.Width / 2) - pretitletext.Width / 2, CustomizingSkin.titletextfromtop);
                        break;
                }
                pretitletext.ForeColor = CustomizingSkin.titletextcolour;
            }
            else {
                preclosebutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.closebtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - preclosebutton.Size.Width, CustomizingSkin.closebtnfromtop);
                prerollupbutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.rollbtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - prerollupbutton.Size.Width, CustomizingSkin.rollbtnfromtop);
                preminimizebutton.Location = new Point(pretitlebar.Size.Width - CustomizingSkin.minbtnfromside - prepgtoplcorner.Width - prepgtoprcorner.Width - preminimizebutton.Size.Width, CustomizingSkin.minbtnfromtop);
                switch (CustomizingSkin.titletextpos)
                {
                    case "Left":
                        pretitletext.Location = new Point(CustomizingSkin.titletextfromside + prepgtoplcorner.Width, CustomizingSkin.titletextfromtop);
                        break;
                    case "Centre":
                        pretitletext.Location = new Point((pretitlebar.Width / 2) - pretitletext.Width / 2, CustomizingSkin.titletextfromtop);
                        break;
                }
                pretitletext.ForeColor = CustomizingSkin.titletextcolour;
            }

            //Change when Icon skinning complete
            // Change to program's icon
            if (API.Upgrades["appicons"] == true)
            {
                prepnlicon.Visible = true;
                prepnlicon.Location = new Point(CustomizingSkin.titleiconfromside, CustomizingSkin.titleiconfromtop);
                prepnlicon.Size = new Size(CustomizingSkin.titlebariconsize, CustomizingSkin.titlebariconsize);
                prepnlicon.Image = Properties.Resources.iconShifter;
                
            }

        }

        #endregion

        #region Other things...

        private void HideAll()
        {
            pnlshifterintro.Hide();
            pnldesktopoptions.Hide();
            pnlwindowsoptions.Hide();
            pnlreset.Hide();
            //pnlmenuoptions.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlreset.Show();
            pnlreset.BringToFront();
            SetPreviewSkin(true);
        }

        private void btnwindows_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlwindowsoptions.Show();
            pnlwindowsoptions.BringToFront();
            SetPreviewSkin(true);
            pnlwindowpreview.Show();
            pnlwindowpreview.BringToFront();
            pnlwindowsintro.Show();
            pnlwindowsintro.BringToFront();
        }

        public void GrabSkinData()
        {
            string json = JsonConvert.SerializeObject(API.CurrentSkin);
            CustomizingSkin = JsonConvert.DeserializeObject<Skinning.Skin>(json);
            GetAllImages();
        }

        public void GetAllImages()
        {
                CustomizingImages = new Skinning.Images();
                CustomizingImages.applauncherclick = Skinning.Utilities.GetImage(CustomizingSkin.applauncherclickpath);
                CustomizingImages.panelbutton = Skinning.Utilities.GetImage(CustomizingSkin.panelbuttonpath);
                CustomizingImages.applaunchermouseover = Skinning.Utilities.GetImage(CustomizingSkin.applaunchermouseoverpath);
                CustomizingImages.applauncher = Skinning.Utilities.GetImage(CustomizingSkin.applauncherpath);
                CustomizingImages.panelclock = Skinning.Utilities.GetImage(CustomizingSkin.panelclockpath);
                CustomizingImages.desktopbackground = Skinning.Utilities.GetImage(CustomizingSkin.desktopbackgroundpath);
                CustomizingImages.desktoppanel = Skinning.Utilities.GetImage(CustomizingSkin.desktoppanelpath);
                CustomizingImages.minbtnhover = Skinning.Utilities.GetImage(CustomizingSkin.minbtnhoverpath);
                CustomizingImages.minbtnclick = Skinning.Utilities.GetImage(CustomizingSkin.minbtnclickpath);
                CustomizingImages.rightcorner = Skinning.Utilities.GetImage(CustomizingSkin.rightcornerpath);
                CustomizingImages.titlebar = Skinning.Utilities.GetImage(CustomizingSkin.titlebarpath);
                CustomizingImages.borderright = Skinning.Utilities.GetImage(CustomizingSkin.borderrightpath);
                CustomizingImages.borderleft = Skinning.Utilities.GetImage(CustomizingSkin.borderleftpath);
                CustomizingImages.borderbottom = Skinning.Utilities.GetImage(CustomizingSkin.borderbottompath);
                CustomizingImages.closebtn = Skinning.Utilities.GetImage(CustomizingSkin.closebtnpath);
                CustomizingImages.closebtnhover = Skinning.Utilities.GetImage(CustomizingSkin.closebtnhoverpath);
                CustomizingImages.closebtnclick = Skinning.Utilities.GetImage(CustomizingSkin.closebtnclickpath);
                CustomizingImages.rollbtn = Skinning.Utilities.GetImage(CustomizingSkin.rollbtnpath);
                CustomizingImages.rollbtnhover = Skinning.Utilities.GetImage(CustomizingSkin.rollbtnhoverpath);
                CustomizingImages.rollbtnclick = Skinning.Utilities.GetImage(CustomizingSkin.rollbtnclickpath);
                CustomizingImages.minbtn = Skinning.Utilities.GetImage(CustomizingSkin.minbtnpath);
                CustomizingImages.leftcorner = Skinning.Utilities.GetImage(CustomizingSkin.leftcornerpath);
                CustomizingImages.bottomleftcorner = Skinning.Utilities.GetImage(CustomizingSkin.bottomleftcornerpath);
                CustomizingImages.bottomrightcorner = Skinning.Utilities.GetImage(CustomizingSkin.bottomrightcornerpath);
            
        }

        private void Shifter_Load(object sender, EventArgs e)
        {
            GrabSkinData();
            HideAll();
            pnlshifterintro.Show();
            pnlshifterintro.BringToFront();
            SetPreviewSkin(true);
            codepointstogive = 0;
        }

        #endregion


        private void SetAvailableOptions ()
        {
            btntitlebar.Visible = API.Upgrades["shifttitlebar"];
            btntitletext.Visible = API.Upgrades["shifttitletext"];
            btnbuttons.Visible = API.Upgrades["shifttitlebuttons"];
            btnpanelbuttons.Visible = API.Upgrades["shiftpanelbuttons"];
            btnpanelclock.Visible = API.Upgrades["shiftpanelclock"];
            btndesktoppanel.Visible = API.Upgrades["shiftdesktoppanel"];
            btnapplauncher.Visible = API.Upgrades["shiftapplauncher"];
            btndesktopitself.Visible = API.Upgrades["shiftdesktop"];
            btnmenus.Visible = API.Upgrades["shiftsystemmenus"];
            btndesktopicons.Visible = API.Upgrades["shiftdesktopicons"];
            btnwindowcomposition.Visible = API.Upgrades["shiftfancyeffects"];
        }
        #region Desktop, Reset, Intro, Apply
        private Random rand = new Random();

        private int codepointstogive = 0;

        private void btnresetallsettings_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Reset all settings - Are you SURE?", "Are you absolutely sure you want to reset your ShiftOS to the default settings? You will lose the currently loaded settings and the action is NOT reversable.", infobox.InfoboxMode.YesNo);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string result = API.GetInfoboxResult();
                if(result == "Yes")
                {
                    Skinning.Utilities.loadedSkin = new Skinning.Skin();
                    Skinning.Utilities.loadedskin_images = new Skinning.Images();
                    Skinning.Utilities.saveskin();
                    Skinning.Utilities.GenDefaultIconPack();
                    API.UpdateWindows();
                    API.CurrentSession.SetupDesktop();
                    API.CreateInfoboxSession("Settings reset.", "ShiftOS has tried to reset all settings and as far is it's aware, it succeeded. You may have to re-open some apps before the reset takes effect on them", infobox.InfoboxMode.Info);
                    codepointstogive = 0;
                }
            };
        }

      

        private void txtdesktoppanelheight_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.desktoppanelheight = Convert.ToInt16(txtdesktoppanelheight.Text);
                SetPreviewSkin(false);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtdesktoppanelheight.Text = CustomizingSkin.desktoppanelheight.ToString();
            }
        }

        private void SetupDesktopPanelValues()
        {
            txtdesktoppanelheight.Text = CustomizingSkin.desktoppanelheight.ToString();
            combodesktoppanelposition.Items.Clear();
            combodesktoppanelposition.Items.Add("Top");
            combodesktoppanelposition.Items.Add("Bottom");
            combodesktoppanelposition.Text = CustomizingSkin.desktoppanelposition;
            pnldesktoppanelcolour.BackColor = CustomizingSkin.desktoppanelcolour;
            pnldesktoppanelcolour.BackgroundImage = CustomizingImages.desktoppanel;
            pnldesktoppanelcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.desktoppanellayout;
            pnldesktopcolour.BackColor = CustomizingSkin.desktopbackgroundcolour;
            pnldesktopcolour.BackgroundImage = CustomizingImages.desktopbackground;
            pnldesktopcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.desktopbackgroundlayout;
        }

        private void btndesktoppanel_Click(object sender, EventArgs e)
        {
            pnldesktoppaneloptions.Show();
            pnldesktoppaneloptions.BringToFront();
            SetupDesktopPanelValues();
            if(API.Upgrades["advanceddesktop"])
            {
                lbpanelcolor.Hide();
                pnldesktoppanelcolour.Hide();
                lbheight.Hide();
                txtdesktoppanelheight.Hide();
                lbposition.Hide();
                combodesktoppanelposition.Hide();
                lbwarning.Text = "Desktop Panel customization has been moved from the Shifter! You can right-click panels to change their settings and add/remove widgets.";
            }
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            btnapply.BackColor = Color.Black;
            btnapply.ForeColor = Color.White;
            btnapply.Text = "Codepoints: " + codepointstogive.ToString();

            Skinning.Utilities.loadedSkin = CustomizingSkin;
            Skinning.Utilities.loadedskin_images = CustomizingImages;
            Skinning.Utilities.saveimages();
            Skinning.Utilities.saveskin();
            API.AddCodepoints(codepointstogive);
            API.UpdateWindows();
            API.CurrentSession.SetupDesktop();
            codepointstogive = 0;
        }

        private void combodesktoppanelposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.desktoppanelposition = combodesktoppanelposition.Text;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private Color ColorToChange
        {
            get
            {
                return ctc;
            }
        }

        private Color ctc = Color.Black;

        private void ChangeDesktopPanelColor(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Desktop Panel Color", CustomizingSkin.desktoppanelcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.desktoppanelcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if(API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Desktop Panel", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if(result == "OK")
                        {
                            CustomizingImages.desktoppanel = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.desktoppanellayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetupAppLauncherValues()
        {
            txtappbuttonlabel.Text = CustomizingSkin.applicationlaunchername;
            txtappbuttontextsize.Text = CustomizingSkin.applicationbuttontextsize.ToString();
            AddFonts(ref comboappbuttontextfont);
            comboappbuttontextfont.Text = CustomizingSkin.applicationbuttontextfont;
            ListFontStyles(ref comboappbuttontextstyle, CustomizingSkin.applicationbuttontextstyle);
            txtapplauncherwidth.Text = CustomizingSkin.applaunchermenuholderwidth.ToString();
            txtapplicationsbuttonheight.Text = CustomizingSkin.applicationbuttonheight.ToString();
            pnlmaintextcolour.BackColor = CustomizingSkin.applicationsbuttontextcolour;
            pnlmainbuttoncolour.BackColor = CustomizingSkin.applauncherbuttoncolour;
            pnlmainbuttoncolour.BackgroundImage = CustomizingImages.applauncher;
            pnlmainbuttoncolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.applauncherlayout;
            pnlmainbuttonactivated.BackColor = CustomizingSkin.Menu_MenuItemPressedGradientBegin;
            pnlalhover.BackColor = CustomizingSkin.applaunchermouseovercolour;
        }

        private void SetAppLauncherTextColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("App Launcher Button Text Color", CustomizingSkin.applicationsbuttontextcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.applicationsbuttontextcolour = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetFontStyle(string newStyle, ref FontStyle oldStyle)
        {
            switch (newStyle)
            {
                case "Regular":
                    oldStyle = FontStyle.Regular;
                    break;
                case "Bold":
                    oldStyle = FontStyle.Bold;
                    break;
                case "Italic":
                    oldStyle = FontStyle.Italic;
                    break;
                case "Underline":
                    oldStyle = FontStyle.Underline;
                    break;
            }
        }

        private void ListFontStyles(ref ComboBox list, FontStyle currentFontStyle)
        {
            list.Items.Clear();
            list.Items.Add("Regular");
            list.Items.Add("Bold");
            list.Items.Add("Italic");
            list.Items.Add("Underline");
            switch(currentFontStyle)
            {
                case FontStyle.Regular:
                    list.Text = "Regular";
                    break;
                case FontStyle.Bold:
                    list.Text = "Bold";
                    break;
                case FontStyle.Italic:
                    list.Text = "Italic";
                    break;
                case FontStyle.Underline:
                    list.Text = "Underline";
                    break;

            }
        }


        private void txtappbuttonlabel_KeyDown(object sender, EventArgs e)
        {
            CustomizingSkin.applicationlaunchername = txtappbuttonlabel.Text;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void AddFonts(ref ComboBox fontList)
        {
            // Get the installed fonts collection.
            System.Drawing.Text.InstalledFontCollection allFonts = new System.Drawing.Text.InstalledFontCollection();

            // Get an array of the system's font families.
            FontFamily[] fontFamilies = allFonts.Families;

            // Display the font families.
            foreach (FontFamily myFont in fontFamilies)
            {
                fontList.Items.Add(myFont.Name);
            }
            //font_family
        }

        private void btnapplauncher_Click(object sender, EventArgs e)
        {
            pnlapplauncheroptions.Show();
            pnlapplauncheroptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void txtappbuttontextsize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.applicationbuttontextsize = Convert.ToInt16(txtappbuttontextsize.Text);
                SetPreviewSkin(false);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtappbuttontextsize.Text = CustomizingSkin.applicationbuttontextsize.ToString();
            }
        }

        private void comboappbuttontextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.applicationbuttontextfont = comboappbuttontextfont.Text;
            SetPreviewSkin(false);
            AddCP(1);
        }

        private void comboappbuttontextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontStyle(comboappbuttontextstyle.Text, ref CustomizingSkin.applicationbuttontextstyle);
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void txtapplicationsbuttonheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.applicationbuttonheight = Convert.ToInt16(txtapplicationsbuttonheight.Text);
                SetPreviewSkin(false);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtapplicationsbuttonheight.Text = CustomizingSkin.applicationbuttonheight.ToString();
            }
        }

        private void txtapplauncherwidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.applaunchermenuholderwidth = Convert.ToInt16(txtapplauncherwidth.Text);
                SetPreviewSkin(false);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtapplauncherwidth.Text = CustomizingSkin.applaunchermenuholderwidth.ToString();
            }
        }

        private void ChangeMenuItemColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Item Color", CustomizingSkin.Menu_ToolStripDropDownBackground);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ToolStripDropDownBackground = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void ChangeMenuHighlight(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Item Mouse Over Color", CustomizingSkin.Menu_MenuItemSelected);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemSelected = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetALButtonColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Desktop Panel Color", CustomizingSkin.applauncherbuttoncolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.applauncherbuttoncolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("App Launcher Button", true);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.applauncher = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.applauncherlayout = (int)API.GraphicPickerSession.ImageLayout;
                            CustomizingImages.applauncherclick = API.GraphicPickerSession.MouseDownImage;
                            CustomizingImages.applaunchermouseover = API.GraphicPickerSession.MouseOverImage;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetALButtonClickedColor(object sender, MouseEventArgs e)
        {
            if(CustomizingImages.applauncherclick != null)
            {
                API.CreateInfoboxSession("Shifter - Error", "It appears you've set an image as the 'Activated' property of the App Launcher button, thus this setting is overidden by it. Please un-set the image to change this setting.", infobox.InfoboxMode.Info);

            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    API.CreateColorPickerSession("Menu Button Activated", CustomizingSkin.Menu_MenuItemPressedGradientBegin);
                    API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        CustomizingSkin.Menu_MenuItemPressedGradientBegin = API.GetLastColorFromSession();
                        CustomizingSkin.Menu_MenuItemPressedGradientMiddle = CustomizingSkin.Menu_MenuItemPressedGradientBegin;
                        CustomizingSkin.Menu_MenuItemPressedGradientEnd = CustomizingSkin.Menu_MenuItemPressedGradientBegin;
                        SetPreviewSkin(true);
                        AddCP(rand.Next(0, 5));
                    };
                }
            }
        }

        private void ChangeDesktopBackground(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Desktop Background", CustomizingSkin.desktopbackgroundcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.desktopbackgroundcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Desktop Background", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.desktopbackground = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.desktopbackgroundlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void btndesktopitself_Click(object sender, EventArgs e)
        {
            pnldesktopbackgroundoptions.Show();
            pnldesktopbackgroundoptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void btnpanelbuttons_Click(object sender, EventArgs e)
        {
            pnlpanelbuttonsoptions.Show();
            pnlpanelbuttonsoptions.BringToFront();
        }

        public void SetupPanelButtonValues()
        {
            txtpanelbuttonwidth.Text = CustomizingSkin.panelbuttonwidth.ToString();
            pnlpanelbuttoncolour.BackColor = CustomizingSkin.panelbuttoncolour;
            pnlpanelbuttoncolour.BackgroundImage = CustomizingImages.panelbutton;
            pnlpanelbuttoncolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.panelbuttonlayout;
            txtpanelbuttoninitalgap.Text = CustomizingSkin.panelbuttoninitialgap.ToString();
            txtpanelbuttonheight.Text = CustomizingSkin.panelbuttonheight.ToString();
            txtpanelbuttongap.Text = CustomizingSkin.panelbuttongap.ToString();
            AddFonts(ref cbpanelbuttonfont);
            cbpanelbuttonfont.Text = CustomizingSkin.panelbuttontextfont;
            ListFontStyles(ref cbpanelbuttontextstyle, CustomizingSkin.panelbuttontextstyle);
            pnlpanelbuttontextcolour.BackColor = CustomizingSkin.panelbuttontextcolour;
            txtpanelbuttoniconsize.Text = CustomizingSkin.panelbuttoniconsize.ToString();
            txtpanelbuttoniconside.Text = CustomizingSkin.panelbuttoniconside.ToString();
            txtpanelbuttonicontop.Text = CustomizingSkin.panelbuttonicontop.ToString();
            txtpaneltextbuttonsize.Text = CustomizingSkin.panelbuttontextsize.ToString();
            txtpanelbuttontextside.Text = CustomizingSkin.panelbuttontextside.ToString();
            txtpanelbuttontexttop.Text = CustomizingSkin.panelbuttontexttop.ToString();
            txtpanelbuttontop.Text = CustomizingSkin.panelbuttonfromtop.ToString();
        }

        private void txtpanelbuttonwidth_TextChanged(object sender, EventArgs e)
        {
            try {
                CustomizingSkin.panelbuttonwidth = Convert.ToInt16(txtpanelbuttonwidth.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtpanelbuttonwidth.Text = CustomizingSkin.panelbuttonwidth.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttoninitalgap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttoninitialgap = Convert.ToInt16(txtpanelbuttoninitalgap.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttoninitalgap.Text = CustomizingSkin.panelbuttoninitialgap.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttonheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttonheight = Convert.ToInt16(txtpanelbuttonheight.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttonheight.Text = CustomizingSkin.panelbuttonheight.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttongap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttongap = Convert.ToInt16(txtpanelbuttongap.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttongap.Text = CustomizingSkin.panelbuttongap.ToString();
            }
            SetPreviewSkin(false);
        }

        private void cbpanelbuttonfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.panelbuttontextfont = (string)cbpanelbuttonfont.SelectedItem;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void cbpanelbuttontextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontStyle(cbpanelbuttontextstyle.SelectedItem.ToString(), ref CustomizingSkin.panelbuttontextstyle);
            SetPreviewSkin(false);

        }

        private void SetPanelButtonTextColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Panel Button Text", CustomizingSkin.panelbuttontextcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.panelbuttontextcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            
        }

        private void SetPanelButtonColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Panel Button", CustomizingSkin.panelbuttoncolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.panelbuttoncolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Panel Button", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.panelbutton = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.panelbuttonlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txtpanelbuttoniconsize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttoniconsize = Convert.ToInt16(txtpanelbuttoniconsize.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttoniconsize.Text = CustomizingSkin.panelbuttoniconsize.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttoniconside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttoniconside = Convert.ToInt16(txtpanelbuttoniconside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttoniconside.Text = CustomizingSkin.panelbuttoniconside.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttonicontop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttonicontop = Convert.ToInt16(txtpanelbuttonicontop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttonicontop.Text = CustomizingSkin.panelbuttonicontop.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttontextside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttontextside = Convert.ToInt16(txtpanelbuttontextside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttontextside.Text = CustomizingSkin.panelbuttontextside.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttontexttop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttontexttop = Convert.ToInt16(txtpanelbuttontexttop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttontexttop.Text = CustomizingSkin.panelbuttontexttop.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpaneltextbuttonsize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttontextsize = Convert.ToInt16(txtpaneltextbuttonsize.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpaneltextbuttonsize.Text = CustomizingSkin.panelbuttontextsize.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtpanelbuttontop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelbuttonfromtop = Convert.ToInt16(txtpanelbuttontop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtpanelbuttontop.Text = CustomizingSkin.panelbuttonfromtop.ToString();
            }
            SetPreviewSkin(false);
        }

        public void SetClockValues()
        {
            pnlpanelclocktextcolour.BackColor = CustomizingSkin.clocktextcolour;
            pnlclockbackgroundcolour.BackColor = CustomizingSkin.clockbackgroundcolor;
            pnlclockbackgroundcolour.BackgroundImage = CustomizingImages.panelclock;
            pnlclockbackgroundcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.panelclocklayout;
            AddFonts(ref comboclocktextfont);
            comboclocktextfont.Text = CustomizingSkin.panelclocktextfont;
            ListFontStyles(ref comboclocktextstyle, CustomizingSkin.panelclocktextstyle);
            txtclocktextfromtop.Text = CustomizingSkin.panelclocktexttop.ToString();
            txtclocktextsize.Text = CustomizingSkin.panelclocktextsize.ToString();
        }

        private void SetClockTextColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Panel Clock Text", CustomizingSkin.clocktextcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.clocktextcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetClockBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Panel Clock", CustomizingSkin.clockbackgroundcolor);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.clockbackgroundcolor = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Panel Clock", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.panelclock = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.panelclocklayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void btnpanelclock_Click(object sender, EventArgs e)
        {
            pnlpanelclockoptions.Show();
            pnlpanelclockoptions.BringToFront();
        }

        private void comboclocktextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.panelclocktextfont = comboclocktextfont.Text;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void comboclocktextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontStyle(comboclocktextstyle.Text, ref CustomizingSkin.panelclocktextstyle);
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void txtclocktextsize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelclocktextsize = Convert.ToInt16(txtclocktextsize.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclocktextsize.Text = CustomizingSkin.panelclocktextsize.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txtclocktextfromtop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.panelclocktexttop = Convert.ToInt16(txtclocktextfromtop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclocktextfromtop.Text = CustomizingSkin.panelclocktexttop.ToString(); //Funny story: I accidentally assigned 'panelcocktexttop' to that property. xD - Michael VanOverbeek
            }
            SetPreviewSkin(false);
        }

        private void SetALHoverColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("App Launcher Mouse Over", CustomizingSkin.applaunchermouseovercolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.applaunchermouseovercolour = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        #endregion

        #region Title Text
        public void SetupTitleTextValues()
        {
            txttitletexttop.Text = CustomizingSkin.titletextfromtop.ToString();
            txttitletextside.Text = CustomizingSkin.titletextfromside.ToString();
            combotitletextposition.Items.Clear();
            combotitletextposition.Items.Add("Left");
            combotitletextposition.Items.Add("Centre");
            combotitletextposition.Text = CustomizingSkin.titletextpos;
            AddFonts(ref combotitletextfont);
            combotitletextfont.Text = CustomizingSkin.titletextfontfamily;
            ListFontStyles(ref combotitletextstyle, CustomizingSkin.titletextfontstyle);
            pnltitletextcolour.BackColor = CustomizingSkin.titletextcolour;
            txttitletextsize.Text = CustomizingSkin.titletextfontsize.ToString();
        }

        private void txttitletexttop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titletextfromtop = Convert.ToInt16(txttitletexttop.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txttitletexttop.Text = CustomizingSkin.titletextfromtop.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txttitletextside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titletextfromside = Convert.ToInt16(txttitletextside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txttitletextside.Text = CustomizingSkin.titletextfromside.ToString();
            }
            SetPreviewSkin(false);
        }

        private void combotitletextposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.titletextpos = combotitletextposition.Text;
            CustomizingSkin.titletextposition = combotitletextposition.Text;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void combotitletextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomizingSkin.titletextfontfamily = combotitletextfont.Text;
            AddCP(1);
            SetPreviewSkin(false);
        }

        private void combotitletextstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontStyle(combotitletextstyle.Text, ref CustomizingSkin.titletextfontstyle);
            SetPreviewSkin(false);
        }

        private void txttitletextsize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titletextfontsize = Convert.ToInt16(txttitletextsize.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txttitletextsize.Text = CustomizingSkin.titletextfontsize.ToString();
            }
            SetPreviewSkin(false);
        }

        private void SetTitleTextColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Title Text", CustomizingSkin.titletextcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.titletextcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void btntitletext_Click(object sender, EventArgs e)
        {
            pnltitletextoptions.Show();
            pnltitletextoptions.BringToFront();
        }
        #endregion

        #region Main Buttons

        private void btnmenus_Click(object sender, EventArgs e)
        {
            /*API.CreateInfoboxSession("Test", "Test", infobox.InfoboxMode.Info);
            HideAll();
            pnlmenuoptions.Show();
            pnlmenuoptions.BringToFront();
            SetPreviewSkin(true);*/
        }

        private void Button2_Click(object sender, EventArgs e)
        {
                    }

        private void Label68_Click(object sender, EventArgs e)
        {

        }

        private void btntitlebar_Click(object sender, EventArgs e)
        {
            pnltitlebaroptions.Show();
            pnltitlebaroptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void btntitletext_Click_1(object sender, EventArgs e)
        {
            pnltitletextoptions.Show();
            pnltitletextoptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void btnbuttons_Click(object sender, EventArgs e)
        {
            pnlbuttonoptions.Show();
            pnlbuttonoptions.BringToFront();
            SetPreviewSkin(true);
        }

        private void btnborders_Click(object sender, EventArgs e)
        {
            pnlborderoptions.Show();
            pnlborderoptions.BringToFront();
            SetPreviewSkin(true);
        }

        #endregion

        #region Window Borders

        public void SetupBorderValues()
        {
            cbindividualbordercolours.Checked = IndividualBorders;
            //hide/show labels
            lbleft.Visible = IndividualBorders;
            lbright.Visible = IndividualBorders;
            lbbottom.Visible = IndividualBorders;
            lbbright.Visible = IndividualBorders;
            lbbleft.Visible = IndividualBorders;
            //hide/show individual colors
            pnlborderleftcolour.Visible = IndividualBorders;
            pnlborderrightcolour.Visible = IndividualBorders;
            pnlborderbottomcolour.Visible = IndividualBorders;
            pnlborderbottomleftcolour.Visible = IndividualBorders;
            pnlborderbottomrightcolour.Visible = IndividualBorders;
            //main color
            pnlbordercolour.BackColor = CustomizingSkin.borderleftcolour;
            pnlbordercolour.BackgroundImage = CustomizingImages.borderleft;
            pnlbordercolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderleftlayout;
            //individual color
            //left
            pnlborderleftcolour.BackColor = CustomizingSkin.borderleftcolour;
            pnlborderleftcolour.BackgroundImage = CustomizingImages.borderleft;
            pnlborderleftcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderleftlayout;
            //right
            pnlborderrightcolour.BackColor = CustomizingSkin.borderrightcolour;
            pnlborderrightcolour.BackgroundImage = CustomizingImages.borderright;
            pnlborderrightcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderrightlayout;
            //bottom
            pnlborderbottomcolour.BackColor = CustomizingSkin.borderbottomcolour;
            pnlborderbottomcolour.BackgroundImage = CustomizingImages.borderbottom;
            pnlborderbottomcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.borderbottomlayout;
            //bottom corners
            pnlborderbottomleftcolour.BackColor = CustomizingSkin.bottomleftcornercolour;
            pnlborderbottomleftcolour.BackgroundImage = CustomizingImages.bottomleftcorner;
            pnlborderbottomleftcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomleftcornerlayout;

            pnlborderbottomrightcolour.BackColor = CustomizingSkin.bottomrightcornercolour;
            pnlborderbottomrightcolour.BackgroundImage = CustomizingImages.bottomrightcorner;
            pnlborderbottomrightcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.bottomrightcornerlayout;


            //border width
            txtbordersize.Text = CustomizingSkin.borderwidth.ToString();
        }

        private bool IndividualBorders = false;

        private void cbindividualbordercolours_CheckedChanged(object sender, EventArgs e)
        {
            IndividualBorders = cbindividualbordercolours.Checked;
            SetPreviewSkin(true);
        }

        private void SetMainBorderColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.borderleftcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.borderleftcolour = API.GetLastColorFromSession();
                    CustomizingSkin.borderrightcolour = API.GetLastColorFromSession();
                    CustomizingSkin.borderbottomcolour = API.GetLastColorFromSession();
                    CustomizingSkin.bottomleftcornercolour = API.GetLastColorFromSession();
                    CustomizingSkin.bottomrightcornercolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.borderleft = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderleftlayout = (int)API.GraphicPickerSession.ImageLayout;
                            CustomizingImages.borderright = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderrightlayout = (int)API.GraphicPickerSession.ImageLayout;
                            CustomizingImages.borderbottom = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderbottomlayout = (int)API.GraphicPickerSession.ImageLayout;
                            CustomizingImages.bottomleftcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.bottomleftcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            CustomizingImages.bottomrightcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.bottomrightcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetLeftBorderColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.borderleftcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.borderleftcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.borderleft = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderleftlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetBottomBorderColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.borderbottomcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.borderbottomcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.borderbottom = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderbottomlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetRightBorderColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.borderrightcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.borderrightcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.borderright = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.borderrightlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetBottomLColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.bottomleftcornercolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.bottomleftcornercolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.bottomleftcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.bottomleftcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetBottomRBorderColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Border Color", CustomizingSkin.bottomrightcornercolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.bottomrightcornercolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Window Borders", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.bottomrightcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.bottomrightcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txtbordersize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.borderwidth = Convert.ToInt16(txtbordersize.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtbordersize.Text = CustomizingSkin.borderwidth.ToString();
            }
            SetPreviewSkin(false);
        }
        #endregion

        #region Title Bar

        public void SetupTitleBarValues()
        {
            //Main color
            pnltitlebarcolour.BackColor = CustomizingSkin.titlebarcolour;
            pnltitlebarcolour.BackgroundImage = CustomizingImages.titlebar;
            pnltitlebarcolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.titlebarlayout;
            //Corners
            cboxtitlebarcorners.Checked = CustomizingSkin.enablecorners;
            //Hide some options if corners are disabled.
            lbcornerwidth.Visible = CustomizingSkin.enablecorners;
            lbcornerwidthpx.Visible = CustomizingSkin.enablecorners;
            lbleftcornercolor.Visible = CustomizingSkin.enablecorners;
            lbrightcornercolor.Visible = CustomizingSkin.enablecorners;
            pnltitlebarleftcornercolour.Visible = CustomizingSkin.enablecorners;
            pnltitlebarrightcornercolour.Visible = CustomizingSkin.enablecorners;
            txttitlebarcornerwidth.Visible = CustomizingSkin.enablecorners;
            //Corner Width
            txttitlebarcornerwidth.Text = CustomizingSkin.titlebarcornerwidth.ToString();
            //Left/Right colors
            pnltitlebarleftcornercolour.BackColor = CustomizingSkin.leftcornercolour;
            pnltitlebarleftcornercolour.BackgroundImage = CustomizingImages.leftcorner;
            pnltitlebarleftcornercolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.leftcornerlayout;

            pnltitlebarrightcornercolour.BackColor = CustomizingSkin.rightcornercolour;
            pnltitlebarrightcornercolour.BackgroundImage = CustomizingImages.rightcorner;
            pnltitlebarrightcornercolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.rightcornerlayout;
            
            //Height
            txttitlebarheight.Text = CustomizingSkin.titlebarheight.ToString();

            //Icon
            txticonfromside.Text = CustomizingSkin.titleiconfromside.ToString();
            txticonfromtop.Text = CustomizingSkin.titleiconfromtop.ToString();

        }

        private void SetTitlebarColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Titlebar Color", CustomizingSkin.titlebarcolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.titlebarcolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Titlebar", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.titlebar = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.titlebarlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void cboxtitlebarcorners_CheckedChanged(object sender, EventArgs e)
        {
            CustomizingSkin.enablecorners = cboxtitlebarcorners.Checked;
            SetPreviewSkin(true);
        }

        private void txttitlebarheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titlebarheight = Convert.ToInt16(txttitlebarheight.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txttitlebarheight.Text = CustomizingSkin.titlebarheight.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txttitlebarcornerwidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titlebarcornerwidth = Convert.ToInt16(txttitlebarcornerwidth.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txttitlebarcornerwidth.Text = CustomizingSkin.titlebarcornerwidth.ToString();
            }
            SetPreviewSkin(false);
        }

        private void SetLeftCornerColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Left Corner", CustomizingSkin.leftcornercolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.leftcornercolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Left Corner", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.leftcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.leftcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void SetRightCornerColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Right Corner", CustomizingSkin.rightcornercolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.rightcornercolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Right Corner", false);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.rightcorner = API.GraphicPickerSession.IdleImage;
                            CustomizingSkin.rightcornerlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txticonfromside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titleiconfromside = Convert.ToInt16(txticonfromside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txticonfromside.Text = CustomizingSkin.titleiconfromside.ToString();
            }
            SetPreviewSkin(false);
        }

        private void txticonfromtop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.titleiconfromtop = Convert.ToInt16(txticonfromtop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txticonfromtop.Text = CustomizingSkin.titleiconfromtop.ToString();
            }
            SetPreviewSkin(false);
        }

        #endregion

        #region Title Button Prep
        private void combobuttonoption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupButtonUI(combobuttonoption.Text);
        }

        public void SetupButtonUI(string button)
        {
            pnlminimizebuttonoptions.Hide();
            pnlclosebuttonoptions.Hide();
            pnlrollupbuttonoptions.Hide();
            switch(button)
            {
                case "Close":
                    pnlclosebuttonoptions.Show();
                    pnlclosebuttonoptions.BringToFront();
                    break;
                case "Roll Up":
                    pnlrollupbuttonoptions.Show();
                    pnlrollupbuttonoptions.BringToFront();
                    break;
                case "Minimize":
                    pnlminimizebuttonoptions.Show();
                    pnlminimizebuttonoptions.BringToFront();
                    break;
            }
            SetPreviewSkin(true);
        }

        public void SetupButtonValues()
        {
            ///Minimize
            //Color
            pnlminimizebuttoncolour.BackColor = CustomizingSkin.minbtncolour;
            pnlminimizebuttoncolour.BackgroundImage = CustomizingImages.minbtn;
            pnlminimizebuttoncolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.minbtnlayout;
            //Width, Height
            txtminimizebuttonheight.Text = CustomizingSkin.minbtnsize.Height.ToString();
            txtminimizebuttonwidth.Text = CustomizingSkin.minbtnsize.Width.ToString();
            //Side, Top
            txtminimizebuttonside.Text = CustomizingSkin.minbtnfromside.ToString();
            txtminimizebuttontop.Text = CustomizingSkin.minbtnfromtop.ToString();

            ///Rollup
            //Color
            pnlrollupbuttoncolour.BackColor = CustomizingSkin.rollbtncolour;
            pnlrollupbuttoncolour.BackgroundImage = CustomizingImages.rollbtn;
            pnlrollupbuttoncolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.rollbtnlayout;
            //Width, Height
            txtrollupbuttonheight.Text = CustomizingSkin.rollbtnsize.Height.ToString();
            txtrollupbuttonwidth.Text = CustomizingSkin.rollbtnsize.Width.ToString();
            //Side, Top
            txtrollupbuttonside.Text = CustomizingSkin.rollbtnfromside.ToString();
            txtrollupbuttontop.Text = CustomizingSkin.rollbtnfromtop.ToString();


            ///Close
            //Color
            pnlclosebuttoncolour.BackColor = CustomizingSkin.closebtncolour;
            pnlclosebuttoncolour.BackgroundImage = CustomizingImages.closebtn;
            pnlclosebuttoncolour.BackgroundImageLayout = (ImageLayout)CustomizingSkin.closebtnlayout;
            //Width, Height
            txtclosebuttonheight.Text = CustomizingSkin.closebtnsize.Height.ToString();
            txtclosebuttonwidth.Text = CustomizingSkin.closebtnsize.Width.ToString();
            //Side, Top
            txtclosebuttonfromside.Text = CustomizingSkin.closebtnfromside.ToString();
            txtclosebuttonfromtop.Text = CustomizingSkin.closebtnfromtop.ToString();

        }


        #endregion


        #region Minimize
        private void SetMinimizeColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Minimize Color", CustomizingSkin.minbtncolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.minbtncolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("Minimize Button", true);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.minbtn = API.GraphicPickerSession.IdleImage;
                            CustomizingImages.minbtnclick = API.GraphicPickerSession.MouseDownImage;
                            CustomizingImages.minbtnhover = API.GraphicPickerSession.MouseOverImage;
                            CustomizingSkin.minbtnlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txtminimizebuttonheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.minbtnsize.Height = Convert.ToInt16(txtminimizebuttonheight.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtminimizebuttonheight.Text = CustomizingSkin.minbtnsize.Height.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtminimizebuttonwidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.minbtnsize.Width = Convert.ToInt16(txtminimizebuttonwidth.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtminimizebuttonwidth.Text = CustomizingSkin.minbtnsize.Width.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtminimizebuttontop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.minbtnfromtop = Convert.ToInt16(txtminimizebuttontop.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtminimizebuttontop.Text = CustomizingSkin.minbtnfromtop.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtminimizebuttonside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.minbtnfromside = Convert.ToInt16(txtminimizebuttonside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtminimizebuttonside.Text = CustomizingSkin.minbtnfromside.ToString();
            }
            SetPreviewSkin(true);
        }
        #endregion

        #region Rollup
        private void SetrollupColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("rollup Color", CustomizingSkin.rollbtncolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.rollbtncolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("rollup Button", true);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.rollbtn = API.GraphicPickerSession.IdleImage;
                            CustomizingImages.rollbtnclick = API.GraphicPickerSession.MouseDownImage;
                            CustomizingImages.rollbtnhover = API.GraphicPickerSession.MouseOverImage;
                            CustomizingSkin.rollbtnlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txtrollupbuttonheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.rollbtnsize.Height = Convert.ToInt16(txtrollupbuttonheight.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtrollupbuttonheight.Text = CustomizingSkin.rollbtnsize.Height.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtrollupbuttonwidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.rollbtnsize.Width = Convert.ToInt16(txtrollupbuttonwidth.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtrollupbuttonwidth.Text = CustomizingSkin.rollbtnsize.Width.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtrollupbuttontop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.rollbtnfromtop = Convert.ToInt16(txtrollupbuttontop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtrollupbuttontop.Text = CustomizingSkin.rollbtnfromtop.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtrollupbuttonside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.rollbtnfromside = Convert.ToInt16(txtrollupbuttonside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtrollupbuttonside.Text = CustomizingSkin.rollbtnfromside.ToString();
            }
            SetPreviewSkin(true);
        }
        #endregion

        #region Close
        private void SetcloseColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("close Color", CustomizingSkin.closebtncolour);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.closebtncolour = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
            else
            {
                if (API.Upgrades["skinning"] == true)
                {
                    API.CreateGraphicPickerSession("close Button", true);
                    API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        string result = API.GetGraphicPickerResult();
                        if (result == "OK")
                        {
                            CustomizingImages.closebtn = API.GraphicPickerSession.IdleImage;
                            CustomizingImages.closebtnclick = API.GraphicPickerSession.MouseDownImage;
                            CustomizingImages.closebtnhover = API.GraphicPickerSession.MouseOverImage;
                            CustomizingSkin.closebtnlayout = (int)API.GraphicPickerSession.ImageLayout;
                            SetPreviewSkin(true);
                        }
                    };
                }
            }
        }

        private void txtclosebuttonheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.closebtnsize.Height = Convert.ToInt16(txtclosebuttonheight.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclosebuttonheight.Text = CustomizingSkin.closebtnsize.Height.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtclosebuttonwidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.closebtnsize.Width = Convert.ToInt16(txtclosebuttonwidth.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclosebuttonwidth.Text = CustomizingSkin.closebtnsize.Width.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtclosebuttonfromtop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.closebtnfromtop = Convert.ToInt16(txtclosebuttonfromtop.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclosebuttonfromtop.Text = CustomizingSkin.closebtnfromtop.ToString();
            }
            SetPreviewSkin(true);
        }

        private void txtclosebuttonfromside_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.closebtnfromside = Convert.ToInt16(txtclosebuttonfromside.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtclosebuttonfromside.Text = CustomizingSkin.closebtnfromside.ToString();
            }
            SetPreviewSkin(true);
        }
        #endregion

        #region Menus - Basic Tier
        private void btnmenus_Click_1(object sender, EventArgs e)
        {
            HideAll();
            pnlmenus.Show();
            pnlmenus.BringToFront();
            SetPreviewSkin(true);
            pnlmenusintro.BringToFront();
        }

        public void SetupBasicMenuValues()
        {
            //Menu strip
            pnlmenubarbegin.BackColor = CustomizingSkin.Menu_MenuStripGradientBegin;
            pnlmenubarend.BackColor = CustomizingSkin.Menu_MenuStripGradientEnd;

            //Toolstrip
            pnltoolbarbegin.BackColor = CustomizingSkin.Menu_ToolStripGradientBegin;
            pnltoolbarmiddle.BackColor = CustomizingSkin.Menu_ToolStripGradientMiddle;
            pnltoolbarend.BackColor = CustomizingSkin.Menu_ToolStripGradientEnd;

            //Status
            pnlstatusbegin.BackColor = CustomizingSkin.Menu_StatusStripGradientBegin;
            pnlstatusend.BackColor = CustomizingSkin.Menu_StatusStripGradientEnd;

            //Dropdown BG
            pnldropdownbg.BackColor = CustomizingSkin.Menu_ToolStripDropDownBackground;

            //Text Color
            pnlmenutextcolor.BackColor = CustomizingSkin.Menu_TextColor;
        }

        private void MenuBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Bar Begin", CustomizingSkin.Menu_MenuStripGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuStripGradientBegin = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void MenuEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Bar End", CustomizingSkin.Menu_MenuStripGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuStripGradientEnd = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void ToolBarBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Tool Bar Begin", CustomizingSkin.Menu_ToolStripGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ToolStripGradientBegin = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void ToolBarEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Tool Bar End", CustomizingSkin.Menu_ToolStripGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ToolStripGradientEnd = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void ToolBarMiddle(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Tool Bar Middle", CustomizingSkin.Menu_ToolStripGradientMiddle);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ToolStripGradientMiddle = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void StatusBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Status Bar Begin", CustomizingSkin.Menu_StatusStripGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_StatusStripGradientBegin = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void StatusEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Status Bar End", CustomizingSkin.Menu_StatusStripGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_StatusStripGradientEnd = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void DropDownBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Dropdown BG", CustomizingSkin.Menu_ToolStripDropDownBackground);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ToolStripDropDownBackground = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void btnbasic_Click(object sender, EventArgs e)
        {
            pnlbasic.Show();
            pnlbasic.BringToFront();
        }

        private void SetMenuTextColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Text Color", CustomizingSkin.Menu_TextColor);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_TextColor = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        #endregion

        #region Menus - Dropdowns
        private void btndropdown_Click(object sender, EventArgs e)
        {
            pnldropdown.Show();
            pnldropdown.BringToFront();
            SetPreviewSkin(true);
        }

        public void SetupDropdownValues()
        {
            //Highlight Color - Basic
            pnlhborder.BackColor = CustomizingSkin.Menu_MenuItemBorder;
            pnlhcolor.BackColor = CustomizingSkin.Menu_MenuItemSelected;

            //Image Margin
            pnlmarginbegin.BackColor = CustomizingSkin.Menu_ImageMarginGradientBegin;
            pnlmarginmiddle.BackColor = CustomizingSkin.Menu_ImageMarginGradientMiddle;
            pnlmarginend.BackColor = CustomizingSkin.Menu_ImageMarginGradientEnd;

            //Drop-Down Border
            pnlddborder.BackColor = CustomizingSkin.Menu_MenuBorder;
        }

        private void HighlightBorder(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Highlight Border", CustomizingSkin.Menu_MenuItemBorder);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemBorder = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void HighlightColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Highlight Color", CustomizingSkin.Menu_MenuItemSelected);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemSelected = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void MarginBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Margin Begin", CustomizingSkin.Menu_ImageMarginGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ImageMarginGradientBegin = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void MarginEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Margin End", CustomizingSkin.Menu_ImageMarginGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ImageMarginGradientEnd = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void MarginMiddle(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Margin Middle", CustomizingSkin.Menu_ImageMarginGradientMiddle);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ImageMarginGradientMiddle = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void MenuBorder(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Border", CustomizingSkin.Menu_MenuBorder);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuBorder = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }
        #endregion

        public void SetupAdvancedMenuValues()
        {
            //Checkboxes
            pnlcheckbg.BackColor = CustomizingSkin.Menu_CheckBackground;

            //Buttons - Highlight
            pnlbuttonselected.BackColor = CustomizingSkin.Menu_ButtonSelectedHighlight;
            pnlbuttonpressed.BackColor = CustomizingSkin.Menu_ButtonPressedHighlight;
            pnlbuttonchecked.BackColor = CustomizingSkin.Menu_ButtonCheckedHighlight;

            //Advanced Buttons
            pnlselectedbegin.BackColor = CustomizingSkin.Menu_ButtonSelectedGradientBegin;
            pnlselectedmiddle.BackColor = CustomizingSkin.Menu_ButtonSelectedGradientMiddle;
            pnlselectedend.BackColor = CustomizingSkin.Menu_ButtonSelectedGradientEnd;

            pnlpressedbegin.BackColor = CustomizingSkin.Menu_ButtonPressedGradientBegin;
            pnlpressedmiddle.BackColor = CustomizingSkin.Menu_ButtonPressedGradientMiddle;
            pnlpressedend.BackColor = CustomizingSkin.Menu_ButtonPressedGradientEnd;

            //Menu Items
            pnlitemselected.BackColor = CustomizingSkin.Menu_MenuItemSelected;
            pnlitemselectedbegin.BackColor = CustomizingSkin.Menu_MenuItemSelectedGradientBegin;
            pnlitemselectedend.BackColor = CustomizingSkin.Menu_MenuItemSelectedGradientEnd;

        }

        private void btnadvanced_Click(object sender, EventArgs e)
        {
            pnladvanced.Show();
            pnladvanced.BringToFront();
            SetPreviewSkin(true);
        }

        private void SetSelectedBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Selected Begin", CustomizingSkin.Menu_ButtonSelectedGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonSelectedGradientBegin = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetSelectedMiddle(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Selected Middle", CustomizingSkin.Menu_ButtonSelectedGradientMiddle);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonSelectedGradientMiddle = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetSelectedEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Selected End", CustomizingSkin.Menu_ButtonSelectedGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonSelectedGradientEnd = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetPressedBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Pressed Begin", CustomizingSkin.Menu_ButtonPressedGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonPressedGradientBegin = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonCheckedGradientBegin = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetPressedMiddle(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Pressed Middle", CustomizingSkin.Menu_ButtonPressedGradientMiddle);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonPressedGradientMiddle = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonCheckedGradientMiddle = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetPressedEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Pressed End", CustomizingSkin.Menu_ButtonPressedGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonPressedGradientEnd = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonCheckedGradientEnd = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void btnmorebuttons_Click(object sender, EventArgs e)
        {
            pnlmore.Show();
            pnlmore.BringToFront();
            SetPreviewSkin(true);
        }

        private void SetCheckBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Checkbox Background", CustomizingSkin.Menu_CheckBackground);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_CheckBackground = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_CheckPressedBackground = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_CheckSelectedBackground = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetButtonCheckBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Checked Background", CustomizingSkin.Menu_ButtonCheckedHighlight);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonCheckedHighlight = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonCheckedHighlightBorder = API.GetLastColorFromSession();
            
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetButtonSelectedBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Selected Background", CustomizingSkin.Menu_ButtonSelectedHighlight);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonSelectedHighlight = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonSelectedHighlightBorder = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonSelectedBorder = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetButtonPressedBG(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Button Pressed Background", CustomizingSkin.Menu_ButtonPressedHighlight);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_ButtonPressedHighlight = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonPressedHighlightBorder = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_ButtonPressedBorder = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetItemSelected(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Item Selected", CustomizingSkin.Menu_MenuItemSelected);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemSelected = API.GetLastColorFromSession();
                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetItemSelectedBegin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Item Selected Begin", CustomizingSkin.Menu_MenuItemSelectedGradientBegin);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemSelectedGradientBegin = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_MenuItemPressedGradientMiddle = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_MenuItemPressedGradientBegin = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void SetItemSelectedEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Menu Item Selected End", CustomizingSkin.Menu_MenuItemSelectedGradientEnd);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    CustomizingSkin.Menu_MenuItemSelectedGradientEnd = API.GetLastColorFromSession();
                    CustomizingSkin.Menu_MenuItemPressedGradientEnd = API.GetLastColorFromSession();

                    SetPreviewSkin(true);
                    AddCP(rand.Next(0, 5));
                };
            }
        }

        private void btnwindowcomposition_Click(object sender, EventArgs e)
        {
            HideAll();
            pnldesktopcomposition.Show();
            pnldesktopcomposition.BringToFront();
            pnlfancyintro.BringToFront();
            SetPreviewSkin(true);
        }

        public void SetupWindowEffect<T>(ComboBox cb, T style)
        {
            cb.Items.Clear();
            var vals = Enum.GetValues(typeof(T)).Cast<T>();
            foreach(var item in vals)
            {
                cb.Items.Add(item.ToString());
            }
            cb.SelectedItem = style.ToString();
        }

        public void SetAnimation<T>(ComboBox cb, ref T objToSet)
        {
            string text = cb.SelectedItem.ToString();
            var vals = Enum.GetValues(typeof(T)).Cast<T>();
            foreach (var item in vals)
            {
                if(item.ToString() == text)
                {
                    objToSet = item;
                    codepointstogive += 1;
                }
            }
            
        }

        public void SetupAnimationStyleValues()
        {
            SetupWindowEffect<WindowAnimationStyle>(cbopenanim, CustomizingSkin.WindowOpenAnimation);
            SetupWindowEffect<WindowAnimationStyle>(cbcloseanim, CustomizingSkin.WindowCloseAnimation);
            SetupWindowEffect<WindowDragEffect>(cbdrageffect, CustomizingSkin.DragAnimation);

            //Drag fade.
            txtfadespeed.Text = CustomizingSkin.DragFadeInterval.ToString();
            txtdragfadedec.Text = ((decimal)CustomizingSkin.DragFadeSpeed).ToString();
            txtdragopacitydec.Text = ((decimal)CustomizingSkin.DragFadeLevel).ToString();

            //Drag Shake
            txtshakeminoffset.Text = CustomizingSkin.ShakeMinOffset.ToString();
            txtshakemax.Text = CustomizingSkin.ShakeMaxOffset.ToString();

            //Window Fade
            txtwinfadespeed.Text = CustomizingSkin.WindowFadeTime.ToString();
            txtwinfadedec.Text = CustomizingSkin.WindowFadeSpeed.ToString();

        }


        private void btnfancywindows_Click(object sender, EventArgs e)
        {
            pnlfancywindows.BringToFront();
            SetPreviewSkin(true);
        }

        private void cbopenanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAnimation<WindowAnimationStyle>(cbopenanim, ref CustomizingSkin.WindowOpenAnimation);
        }

        private void cbcloseanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAnimation<WindowAnimationStyle>(cbcloseanim, ref CustomizingSkin.WindowCloseAnimation);
        }

        private void cbdrageffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAnimation<WindowDragEffect>(cbdrageffect, ref CustomizingSkin.DragAnimation);
        }

        private void txtfadespeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.DragFadeInterval = Convert.ToInt32(txtfadespeed.Text);
                AddCP(1);
            }
            catch(Exception ex)
            {
                txtfadespeed.Text = CustomizingSkin.DragFadeInterval.ToString();
            }
        }

        private void txtdragfadedec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.DragFadeSpeed = Convert.ToDouble(txtdragfadedec.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtdragfadedec.Text = CustomizingSkin.DragFadeSpeed.ToString();
            }
        }

        private void btnfancydragging_Click(object sender, EventArgs e)
        {
            pnlfancydragging.Show();
            pnlfancydragging.BringToFront();
            SetPreviewSkin(true);
        }

        private void txtdragopacitydec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.DragFadeLevel = Convert.ToDouble(txtdragopacitydec.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtdragopacitydec.Text = CustomizingSkin.DragFadeLevel.ToString();
            }
        }

        private void txtshakemax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.ShakeMaxOffset = Convert.ToInt32(txtshakemax.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtshakemax.Text = CustomizingSkin.ShakeMaxOffset.ToString();
            }
        }

        private void txtshakeminoffset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.ShakeMinOffset = Convert.ToInt32(txtshakeminoffset.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtshakeminoffset.Text = CustomizingSkin.ShakeMinOffset.ToString();
            }
        }

        private void txtwinfadespeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.WindowFadeTime = Convert.ToInt32(txtwinfadespeed.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtwinfadespeed.Text = CustomizingSkin.WindowFadeTime.ToString();
            }
        }

        private void txtwinfadedec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CustomizingSkin.WindowFadeSpeed = Convert.ToDecimal(txtwinfadedec.Text);
                AddCP(1);
            }
            catch (Exception ex)
            {
                txtwinfadedec.Text = CustomizingSkin.WindowFadeSpeed.ToString();
            }
        }
    }
}
