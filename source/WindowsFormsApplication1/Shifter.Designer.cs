using System;
using System.Windows.Forms;

namespace ShiftOS
{
    partial class Shifter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shifter));
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.clocktick = new System.Windows.Forms.Timer(this.components);
            this.customizationtime = new System.Windows.Forms.Timer(this.components);
            this.timerearned = new System.Windows.Forms.Timer(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.btnapply = new System.Windows.Forms.Button();
            this.catholder = new System.Windows.Forms.Panel();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnwindowcomposition = new System.Windows.Forms.Button();
            this.btndesktopicons = new System.Windows.Forms.Button();
            this.btnmenus = new System.Windows.Forms.Button();
            this.btnwindows = new System.Windows.Forms.Button();
            this.btndesktop = new System.Windows.Forms.Button();
            this.pnlshifterintro = new System.Windows.Forms.Panel();
            this.Label66 = new System.Windows.Forms.Label();
            this.Label65 = new System.Windows.Forms.Label();
            this.Label64 = new System.Windows.Forms.Label();
            this.Label63 = new System.Windows.Forms.Label();
            this.pnldesktopoptions = new System.Windows.Forms.Panel();
            this.pnlapplauncheroptions = new System.Windows.Forms.Panel();
            this.pnlalhover = new System.Windows.Forms.Panel();
            this.label119 = new System.Windows.Forms.Label();
            this.Label71 = new System.Windows.Forms.Label();
            this.txtapplauncherwidth = new System.Windows.Forms.TextBox();
            this.Label72 = new System.Windows.Forms.Label();
            this.txtappbuttonlabel = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.Label50 = new System.Windows.Forms.Label();
            this.pnlmaintextcolour = new System.Windows.Forms.Panel();
            this.comboappbuttontextstyle = new System.Windows.Forms.ComboBox();
            this.comboappbuttontextfont = new System.Windows.Forms.ComboBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.txtappbuttontextsize = new System.Windows.Forms.TextBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.pnlmainbuttonactivated = new System.Windows.Forms.Panel();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.txtapplicationsbuttonheight = new System.Windows.Forms.TextBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.pnlmainbuttoncolour = new System.Windows.Forms.Panel();
            this.Label43 = new System.Windows.Forms.Label();
            this.pnldesktopintro = new System.Windows.Forms.Panel();
            this.Label69 = new System.Windows.Forms.Label();
            this.Label70 = new System.Windows.Forms.Label();
            this.pnlpanelbuttonsoptions = new System.Windows.Forms.Panel();
            this.pnlpanelbuttontextcolour = new System.Windows.Forms.Panel();
            this.Label101 = new System.Windows.Forms.Label();
            this.txtpanelbuttontexttop = new System.Windows.Forms.TextBox();
            this.Label104 = new System.Windows.Forms.Label();
            this.txtpanelbuttontextside = new System.Windows.Forms.TextBox();
            this.Label106 = new System.Windows.Forms.Label();
            this.Label93 = new System.Windows.Forms.Label();
            this.txtpanelbuttontop = new System.Windows.Forms.TextBox();
            this.Label94 = new System.Windows.Forms.Label();
            this.txtpanelbuttoninitalgap = new System.Windows.Forms.TextBox();
            this.Label108 = new System.Windows.Forms.Label();
            this.txtpanelbuttonicontop = new System.Windows.Forms.TextBox();
            this.Label110 = new System.Windows.Forms.Label();
            this.txtpanelbuttoniconside = new System.Windows.Forms.TextBox();
            this.Label112 = new System.Windows.Forms.Label();
            this.txtpanelbuttoniconsize = new System.Windows.Forms.TextBox();
            this.Label105 = new System.Windows.Forms.Label();
            this.cbpanelbuttontextstyle = new System.Windows.Forms.ComboBox();
            this.cbpanelbuttonfont = new System.Windows.Forms.ComboBox();
            this.Label100 = new System.Windows.Forms.Label();
            this.txtpaneltextbuttonsize = new System.Windows.Forms.TextBox();
            this.Label102 = new System.Windows.Forms.Label();
            this.Label103 = new System.Windows.Forms.Label();
            this.Label98 = new System.Windows.Forms.Label();
            this.txtpanelbuttongap = new System.Windows.Forms.TextBox();
            this.Label99 = new System.Windows.Forms.Label();
            this.Label96 = new System.Windows.Forms.Label();
            this.txtpanelbuttonheight = new System.Windows.Forms.TextBox();
            this.Label97 = new System.Windows.Forms.Label();
            this.Label92 = new System.Windows.Forms.Label();
            this.txtpanelbuttonwidth = new System.Windows.Forms.TextBox();
            this.Label91 = new System.Windows.Forms.Label();
            this.pnlpanelbuttoncolour = new System.Windows.Forms.Panel();
            this.Label95 = new System.Windows.Forms.Label();
            this.pnldesktoppaneloptions = new System.Windows.Forms.Panel();
            this.btnpanelbuttons = new System.Windows.Forms.Button();
            this.Label27 = new System.Windows.Forms.Label();
            this.combodesktoppanelposition = new System.Windows.Forms.ComboBox();
            this.Label46 = new System.Windows.Forms.Label();
            this.Label47 = new System.Windows.Forms.Label();
            this.txtdesktoppanelheight = new System.Windows.Forms.NumericUpDown();
            this.Label48 = new System.Windows.Forms.Label();
            this.pnldesktoppanelcolour = new System.Windows.Forms.Panel();
            this.Label49 = new System.Windows.Forms.Label();
            this.pnldesktopbackgroundoptions = new System.Windows.Forms.Panel();
            this.pnldesktopcolour = new System.Windows.Forms.Panel();
            this.Label45 = new System.Windows.Forms.Label();
            this.pnlpanelclockoptions = new System.Windows.Forms.Panel();
            this.pnlclockbackgroundcolour = new System.Windows.Forms.Panel();
            this.Label44 = new System.Windows.Forms.Label();
            this.comboclocktextstyle = new System.Windows.Forms.ComboBox();
            this.comboclocktextfont = new System.Windows.Forms.ComboBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.txtclocktextfromtop = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.txtclocktextsize = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.pnlpanelclocktextcolour = new System.Windows.Forms.Panel();
            this.Label34 = new System.Windows.Forms.Label();
            this.pnldesktoppreview = new System.Windows.Forms.Panel();
            this.predesktoppanel = new System.Windows.Forms.Panel();
            this.prepnlpanelbuttonholder = new System.Windows.Forms.FlowLayoutPanel();
            this.prepnlpanelbutton = new System.Windows.Forms.Panel();
            this.pretbicon = new System.Windows.Forms.PictureBox();
            this.pretbctext = new System.Windows.Forms.Label();
            this.pretimepanel = new System.Windows.Forms.Panel();
            this.prepaneltimetext = new System.Windows.Forms.Label();
            this.preapplaunchermenuholder = new System.Windows.Forms.Panel();
            this.predesktopappmenu = new System.Windows.Forms.MenuStrip();
            this.ApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KnowledgeInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShiftoriumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShifterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.btndesktopitself = new System.Windows.Forms.Button();
            this.btnpanelclock = new System.Windows.Forms.Button();
            this.btnapplauncher = new System.Windows.Forms.Button();
            this.btndesktoppanel = new System.Windows.Forms.Button();
            this.txtpanelbuttoniconheight = new System.Windows.Forms.TextBox();
            this.pnlwindowsoptions = new System.Windows.Forms.Panel();
            this.pnlwindowsintro = new System.Windows.Forms.Panel();
            this.Label68 = new System.Windows.Forms.Label();
            this.Label67 = new System.Windows.Forms.Label();
            this.pnlbuttonoptions = new System.Windows.Forms.Panel();
            this.pnlclosebuttonoptions = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.pnlclosebuttoncolour = new System.Windows.Forms.Panel();
            this.txtclosebuttonfromside = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtclosebuttonheight = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtclosebuttonfromtop = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtclosebuttonwidth = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.pnlrollupbuttonoptions = new System.Windows.Forms.Panel();
            this.Label54 = new System.Windows.Forms.Label();
            this.Label55 = new System.Windows.Forms.Label();
            this.pnlrollupbuttoncolour = new System.Windows.Forms.Panel();
            this.txtrollupbuttonside = new System.Windows.Forms.TextBox();
            this.Label56 = new System.Windows.Forms.Label();
            this.Label57 = new System.Windows.Forms.Label();
            this.txtrollupbuttonheight = new System.Windows.Forms.TextBox();
            this.Label58 = new System.Windows.Forms.Label();
            this.Label59 = new System.Windows.Forms.Label();
            this.txtrollupbuttontop = new System.Windows.Forms.TextBox();
            this.Label60 = new System.Windows.Forms.Label();
            this.Label61 = new System.Windows.Forms.Label();
            this.txtrollupbuttonwidth = new System.Windows.Forms.TextBox();
            this.Label62 = new System.Windows.Forms.Label();
            this.pnlminimizebuttonoptions = new System.Windows.Forms.Panel();
            this.Label82 = new System.Windows.Forms.Label();
            this.Label83 = new System.Windows.Forms.Label();
            this.pnlminimizebuttoncolour = new System.Windows.Forms.Panel();
            this.txtminimizebuttonside = new System.Windows.Forms.TextBox();
            this.Label84 = new System.Windows.Forms.Label();
            this.Label85 = new System.Windows.Forms.Label();
            this.txtminimizebuttonheight = new System.Windows.Forms.TextBox();
            this.Label86 = new System.Windows.Forms.Label();
            this.Label87 = new System.Windows.Forms.Label();
            this.txtminimizebuttontop = new System.Windows.Forms.TextBox();
            this.Label88 = new System.Windows.Forms.Label();
            this.Label89 = new System.Windows.Forms.Label();
            this.txtminimizebuttonwidth = new System.Windows.Forms.TextBox();
            this.Label90 = new System.Windows.Forms.Label();
            this.combobuttonoption = new System.Windows.Forms.ComboBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.pnltitlebaroptions = new System.Windows.Forms.Panel();
            this.Label80 = new System.Windows.Forms.Label();
            this.txticonfromtop = new System.Windows.Forms.TextBox();
            this.Label81 = new System.Windows.Forms.Label();
            this.Label78 = new System.Windows.Forms.Label();
            this.txticonfromside = new System.Windows.Forms.TextBox();
            this.Label79 = new System.Windows.Forms.Label();
            this.lbcornerwidthpx = new System.Windows.Forms.Label();
            this.txttitlebarcornerwidth = new System.Windows.Forms.TextBox();
            this.lbcornerwidth = new System.Windows.Forms.Label();
            this.pnltitlebarrightcornercolour = new System.Windows.Forms.Panel();
            this.pnltitlebarleftcornercolour = new System.Windows.Forms.Panel();
            this.lbrightcornercolor = new System.Windows.Forms.Label();
            this.lbleftcornercolor = new System.Windows.Forms.Label();
            this.cboxtitlebarcorners = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txttitlebarheight = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.pnltitlebarcolour = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlborderoptions = new System.Windows.Forms.Panel();
            this.cbindividualbordercolours = new System.Windows.Forms.CheckBox();
            this.pnlborderbottomrightcolour = new System.Windows.Forms.Panel();
            this.lbbright = new System.Windows.Forms.Label();
            this.pnlborderbottomcolour = new System.Windows.Forms.Panel();
            this.lbbottom = new System.Windows.Forms.Label();
            this.pnlborderbottomleftcolour = new System.Windows.Forms.Panel();
            this.lbbleft = new System.Windows.Forms.Label();
            this.pnlborderrightcolour = new System.Windows.Forms.Panel();
            this.lbright = new System.Windows.Forms.Label();
            this.pnlborderleftcolour = new System.Windows.Forms.Panel();
            this.lbleft = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.pnlbordercolour = new System.Windows.Forms.Panel();
            this.txtbordersize = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.pnltitletextoptions = new System.Windows.Forms.Panel();
            this.combotitletextposition = new System.Windows.Forms.ComboBox();
            this.Label53 = new System.Windows.Forms.Label();
            this.combotitletextstyle = new System.Windows.Forms.ComboBox();
            this.combotitletextfont = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.txttitletextside = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.txttitletexttop = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.txttitletextsize = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.pnltitletextcolour = new System.Windows.Forms.Panel();
            this.Label25 = new System.Windows.Forms.Label();
            this.pnlwindowsobjects = new System.Windows.Forms.Panel();
            this.btnborders = new System.Windows.Forms.Button();
            this.btnbuttons = new System.Windows.Forms.Button();
            this.btntitletext = new System.Windows.Forms.Button();
            this.btntitlebar = new System.Windows.Forms.Button();
            this.pnlwindowpreview = new System.Windows.Forms.Panel();
            this.prepgcontent = new System.Windows.Forms.Panel();
            this.prepgbottom = new System.Windows.Forms.Panel();
            this.prepgleft = new System.Windows.Forms.Panel();
            this.prepgbottomlcorner = new System.Windows.Forms.Panel();
            this.prepgright = new System.Windows.Forms.Panel();
            this.prepgbottomrcorner = new System.Windows.Forms.Panel();
            this.pretitlebar = new System.Windows.Forms.Panel();
            this.preminimizebutton = new System.Windows.Forms.Panel();
            this.prepnlicon = new System.Windows.Forms.PictureBox();
            this.prerollupbutton = new System.Windows.Forms.Panel();
            this.preclosebutton = new System.Windows.Forms.Panel();
            this.pretitletext = new System.Windows.Forms.Label();
            this.prepgtoplcorner = new System.Windows.Forms.Panel();
            this.prepgtoprcorner = new System.Windows.Forms.Panel();
            this.pnlreset = new System.Windows.Forms.Panel();
            this.Label113 = new System.Windows.Forms.Label();
            this.btnresetallsettings = new System.Windows.Forms.Button();
            this.Label109 = new System.Windows.Forms.Label();
            this.Label111 = new System.Windows.Forms.Label();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.pnldesktopcomposition = new System.Windows.Forms.Panel();
            this.pnlfancywindows = new System.Windows.Forms.Panel();
            this.txtwinfadedec = new System.Windows.Forms.TextBox();
            this.label150 = new System.Windows.Forms.Label();
            this.txtwinfadespeed = new System.Windows.Forms.TextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.cbdrageffect = new System.Windows.Forms.ComboBox();
            this.label141 = new System.Windows.Forms.Label();
            this.cbcloseanim = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.cbopenanim = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.pnlfancydragging = new System.Windows.Forms.Panel();
            this.txtshakeminoffset = new System.Windows.Forms.TextBox();
            this.label148 = new System.Windows.Forms.Label();
            this.txtshakemax = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.txtdragopacitydec = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.txtdragfadedec = new System.Windows.Forms.TextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.txtfadespeed = new System.Windows.Forms.TextBox();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.pnlfancyintro = new System.Windows.Forms.Panel();
            this.label174 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label157 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label158 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label159 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label160 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label161 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label164 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.label165 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.label166 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.label167 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.label168 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label169 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label170 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.label171 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.btnfancydragging = new System.Windows.Forms.Button();
            this.btnfancywindows = new System.Windows.Forms.Button();
            this.label176 = new System.Windows.Forms.Label();
            this.pnlmenus = new System.Windows.Forms.Panel();
            this.pnladvanced = new System.Windows.Forms.Panel();
            this.btnmorebuttons = new System.Windows.Forms.Button();
            this.pnlbuttonchecked = new System.Windows.Forms.Panel();
            this.label136 = new System.Windows.Forms.Label();
            this.pnlitemselectedend = new System.Windows.Forms.Panel();
            this.label129 = new System.Windows.Forms.Label();
            this.pnlbuttonpressed = new System.Windows.Forms.Panel();
            this.label130 = new System.Windows.Forms.Label();
            this.pnlitemselectedbegin = new System.Windows.Forms.Panel();
            this.label131 = new System.Windows.Forms.Label();
            this.pnlitemselected = new System.Windows.Forms.Panel();
            this.label132 = new System.Windows.Forms.Label();
            this.pnlbuttonselected = new System.Windows.Forms.Panel();
            this.label133 = new System.Windows.Forms.Label();
            this.pnlcheckbg = new System.Windows.Forms.Panel();
            this.label134 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.pnlmore = new System.Windows.Forms.Panel();
            this.pnlpressedbegin = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label138 = new System.Windows.Forms.Label();
            this.pnlselectedbegin = new System.Windows.Forms.Panel();
            this.pnlpressedend = new System.Windows.Forms.Panel();
            this.label137 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.pnlselectedend = new System.Windows.Forms.Panel();
            this.pnlpressedmiddle = new System.Windows.Forms.Panel();
            this.label140 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.pnlselectedmiddle = new System.Windows.Forms.Panel();
            this.label145 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.pnldropdown = new System.Windows.Forms.Panel();
            this.pnlddborder = new System.Windows.Forms.Panel();
            this.label117 = new System.Windows.Forms.Label();
            this.pnlmarginend = new System.Windows.Forms.Panel();
            this.label120 = new System.Windows.Forms.Label();
            this.pnlmarginmiddle = new System.Windows.Forms.Panel();
            this.label121 = new System.Windows.Forms.Label();
            this.pnlmarginbegin = new System.Windows.Forms.Panel();
            this.label122 = new System.Windows.Forms.Label();
            this.pnlhcolor = new System.Windows.Forms.Panel();
            this.label123 = new System.Windows.Forms.Label();
            this.pnlhborder = new System.Windows.Forms.Panel();
            this.label125 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.pnlbasic = new System.Windows.Forms.Panel();
            this.pnlmenutextcolor = new System.Windows.Forms.Panel();
            this.label118 = new System.Windows.Forms.Label();
            this.pnldropdownbg = new System.Windows.Forms.Panel();
            this.label115 = new System.Windows.Forms.Label();
            this.pnlstatusend = new System.Windows.Forms.Panel();
            this.label114 = new System.Windows.Forms.Label();
            this.pnlstatusbegin = new System.Windows.Forms.Panel();
            this.label107 = new System.Windows.Forms.Label();
            this.pnltoolbarend = new System.Windows.Forms.Panel();
            this.label77 = new System.Windows.Forms.Label();
            this.pnltoolbarmiddle = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.pnltoolbarbegin = new System.Windows.Forms.Panel();
            this.label75 = new System.Windows.Forms.Label();
            this.pnlmenubarend = new System.Windows.Forms.Panel();
            this.label73 = new System.Windows.Forms.Label();
            this.pnlmenubarbegin = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.pnlmenusintro = new System.Windows.Forms.Panel();
            this.label116 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.pnlmenucategories = new System.Windows.Forms.Panel();
            this.btnmisc = new System.Windows.Forms.Button();
            this.btnadvanced = new System.Windows.Forms.Button();
            this.btndropdown = new System.Windows.Forms.Button();
            this.btnbasic = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.tmrfix = new System.Windows.Forms.Timer(this.components);
            this.tmrdelay = new System.Windows.Forms.Timer(this.components);
            this.catholder.SuspendLayout();
            this.pnlshifterintro.SuspendLayout();
            this.pnldesktopoptions.SuspendLayout();
            this.pnlapplauncheroptions.SuspendLayout();
            this.pnldesktopintro.SuspendLayout();
            this.pnlpanelbuttonsoptions.SuspendLayout();
            this.pnldesktoppaneloptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesktoppanelheight)).BeginInit();
            this.pnldesktopbackgroundoptions.SuspendLayout();
            this.pnlpanelclockoptions.SuspendLayout();
            this.pnldesktoppreview.SuspendLayout();
            this.predesktoppanel.SuspendLayout();
            this.prepnlpanelbuttonholder.SuspendLayout();
            this.prepnlpanelbutton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pretbicon)).BeginInit();
            this.pretimepanel.SuspendLayout();
            this.preapplaunchermenuholder.SuspendLayout();
            this.predesktopappmenu.SuspendLayout();
            this.Panel10.SuspendLayout();
            this.pnlwindowsoptions.SuspendLayout();
            this.pnlwindowsintro.SuspendLayout();
            this.pnlbuttonoptions.SuspendLayout();
            this.pnlclosebuttonoptions.SuspendLayout();
            this.pnlrollupbuttonoptions.SuspendLayout();
            this.pnlminimizebuttonoptions.SuspendLayout();
            this.pnltitlebaroptions.SuspendLayout();
            this.pnlborderoptions.SuspendLayout();
            this.pnltitletextoptions.SuspendLayout();
            this.pnlwindowsobjects.SuspendLayout();
            this.pnlwindowpreview.SuspendLayout();
            this.prepgleft.SuspendLayout();
            this.prepgright.SuspendLayout();
            this.pretitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prepnlicon)).BeginInit();
            this.pnlreset.SuspendLayout();
            this.pgcontents.SuspendLayout();
            this.pnldesktopcomposition.SuspendLayout();
            this.pnlfancywindows.SuspendLayout();
            this.pnlfancydragging.SuspendLayout();
            this.pnlfancyintro.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel36.SuspendLayout();
            this.pnlmenus.SuspendLayout();
            this.pnladvanced.SuspendLayout();
            this.pnlmore.SuspendLayout();
            this.pnldropdown.SuspendLayout();
            this.pnlbasic.SuspendLayout();
            this.pnlmenusintro.SuspendLayout();
            this.pnlmenucategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // clocktick
            // 
            this.clocktick.Enabled = true;
            this.clocktick.Interval = 1000;
            // 
            // customizationtime
            // 
            this.customizationtime.Enabled = true;
            this.customizationtime.Interval = 10000;
            // 
            // timerearned
            // 
            this.timerearned.Interval = 3000;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(597, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Label1";
            // 
            // btnapply
            // 
            this.btnapply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnapply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnapply.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapply.Location = new System.Drawing.Point(7, 286);
            this.btnapply.Name = "btnapply";
            this.btnapply.Size = new System.Drawing.Size(119, 29);
            this.btnapply.TabIndex = 3;
            this.btnapply.TabStop = false;
            this.btnapply.Text = "Apply Changes";
            this.btnapply.UseVisualStyleBackColor = true;
            this.btnapply.Click += new System.EventHandler(this.btnapply_Click);
            // 
            // catholder
            // 
            this.catholder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.catholder.BackColor = System.Drawing.Color.White;
            this.catholder.Controls.Add(this.btnreset);
            this.catholder.Controls.Add(this.btnwindowcomposition);
            this.catholder.Controls.Add(this.btndesktopicons);
            this.catholder.Controls.Add(this.btnmenus);
            this.catholder.Controls.Add(this.btnwindows);
            this.catholder.Controls.Add(this.btndesktop);
            this.catholder.Location = new System.Drawing.Point(7, 9);
            this.catholder.Name = "catholder";
            this.catholder.Size = new System.Drawing.Size(119, 271);
            this.catholder.TabIndex = 5;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.White;
            this.btnreset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.Location = new System.Drawing.Point(0, 145);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(119, 29);
            this.btnreset.TabIndex = 8;
            this.btnreset.TabStop = false;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnwindowcomposition
            // 
            this.btnwindowcomposition.BackColor = System.Drawing.Color.White;
            this.btnwindowcomposition.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnwindowcomposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnwindowcomposition.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnwindowcomposition.Location = new System.Drawing.Point(0, 116);
            this.btnwindowcomposition.Name = "btnwindowcomposition";
            this.btnwindowcomposition.Size = new System.Drawing.Size(119, 29);
            this.btnwindowcomposition.TabIndex = 10;
            this.btnwindowcomposition.TabStop = false;
            this.btnwindowcomposition.Text = "Fancy Effects";
            this.btnwindowcomposition.UseVisualStyleBackColor = false;
            this.btnwindowcomposition.Visible = false;
            this.btnwindowcomposition.Click += new System.EventHandler(this.btnwindowcomposition_Click);
            // 
            // btndesktopicons
            // 
            this.btndesktopicons.BackColor = System.Drawing.Color.White;
            this.btndesktopicons.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndesktopicons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesktopicons.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndesktopicons.Location = new System.Drawing.Point(0, 87);
            this.btndesktopicons.Name = "btndesktopicons";
            this.btndesktopicons.Size = new System.Drawing.Size(119, 29);
            this.btndesktopicons.TabIndex = 9;
            this.btndesktopicons.TabStop = false;
            this.btndesktopicons.Text = "Desktop Icons";
            this.btndesktopicons.UseVisualStyleBackColor = false;
            this.btndesktopicons.Visible = false;
            // 
            // btnmenus
            // 
            this.btnmenus.BackColor = System.Drawing.Color.White;
            this.btnmenus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnmenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmenus.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmenus.Location = new System.Drawing.Point(0, 58);
            this.btnmenus.Name = "btnmenus";
            this.btnmenus.Size = new System.Drawing.Size(119, 29);
            this.btnmenus.TabIndex = 6;
            this.btnmenus.TabStop = false;
            this.btnmenus.Text = "Menus";
            this.btnmenus.UseVisualStyleBackColor = false;
            this.btnmenus.Visible = false;
            this.btnmenus.Click += new System.EventHandler(this.btnmenus_Click_1);
            // 
            // btnwindows
            // 
            this.btnwindows.BackColor = System.Drawing.Color.White;
            this.btnwindows.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnwindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnwindows.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnwindows.Location = new System.Drawing.Point(0, 29);
            this.btnwindows.Name = "btnwindows";
            this.btnwindows.Size = new System.Drawing.Size(119, 29);
            this.btnwindows.TabIndex = 5;
            this.btnwindows.TabStop = false;
            this.btnwindows.Text = "Windows";
            this.btnwindows.UseVisualStyleBackColor = false;
            this.btnwindows.Click += new System.EventHandler(this.btnwindows_Click);
            // 
            // btndesktop
            // 
            this.btndesktop.BackColor = System.Drawing.Color.White;
            this.btndesktop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesktop.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndesktop.Location = new System.Drawing.Point(0, 0);
            this.btndesktop.Name = "btndesktop";
            this.btndesktop.Size = new System.Drawing.Size(119, 29);
            this.btndesktop.TabIndex = 4;
            this.btndesktop.TabStop = false;
            this.btndesktop.Text = "Desktop";
            this.btndesktop.UseVisualStyleBackColor = false;
            this.btndesktop.Click += new System.EventHandler(this.btndesktop_Click);
            // 
            // pnlshifterintro
            // 
            this.pnlshifterintro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlshifterintro.BackColor = System.Drawing.Color.White;
            this.pnlshifterintro.Controls.Add(this.Label66);
            this.pnlshifterintro.Controls.Add(this.Label65);
            this.pnlshifterintro.Controls.Add(this.Label64);
            this.pnlshifterintro.Controls.Add(this.Label63);
            this.pnlshifterintro.Location = new System.Drawing.Point(134, 9);
            this.pnlshifterintro.Name = "pnlshifterintro";
            this.pnlshifterintro.Size = new System.Drawing.Size(457, 306);
            this.pnlshifterintro.TabIndex = 17;
            // 
            // Label66
            // 
            this.Label66.BackColor = System.Drawing.Color.Transparent;
            this.Label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label66.Location = new System.Drawing.Point(3, 227);
            this.Label66.Name = "Label66";
            this.Label66.Size = new System.Drawing.Size(451, 65);
            this.Label66.TabIndex = 3;
            this.Label66.Text = "That\'s right! As you make customizations to ShiftOS, you can earn Codepoints. The" +
    " more you shift it, the more CP you earn. Just hit the \'Apply Changes\' button, a" +
    "nd you\'ll recieve your codepoints.";
            this.Label66.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label65
            // 
            this.Label65.AutoSize = true;
            this.Label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label65.Location = new System.Drawing.Point(53, 204);
            this.Label65.Name = "Label65";
            this.Label65.Size = new System.Drawing.Size(352, 20);
            this.Label65.TabIndex = 2;
            this.Label65.Text = "You can earn codepoints using the Shifter!";
            // 
            // Label64
            // 
            this.Label64.BackColor = System.Drawing.Color.Transparent;
            this.Label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label64.Location = new System.Drawing.Point(4, 32);
            this.Label64.Name = "Label64";
            this.Label64.Size = new System.Drawing.Size(451, 167);
            this.Label64.TabIndex = 1;
            this.Label64.Text = resources.GetString("Label64.Text");
            this.Label64.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label63
            // 
            this.Label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label63.Location = new System.Drawing.Point(72, 0);
            this.Label63.Name = "Label63";
            this.Label63.Size = new System.Drawing.Size(332, 29);
            this.Label63.TabIndex = 0;
            this.Label63.Text = "Welcome to the Shifter!";
            // 
            // pnldesktopoptions
            // 
            this.pnldesktopoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktopoptions.BackColor = System.Drawing.Color.White;
            this.pnldesktopoptions.Controls.Add(this.pnlapplauncheroptions);
            this.pnldesktopoptions.Controls.Add(this.pnldesktopintro);
            this.pnldesktopoptions.Controls.Add(this.pnlpanelbuttonsoptions);
            this.pnldesktopoptions.Controls.Add(this.pnldesktoppaneloptions);
            this.pnldesktopoptions.Controls.Add(this.pnldesktopbackgroundoptions);
            this.pnldesktopoptions.Controls.Add(this.pnlpanelclockoptions);
            this.pnldesktopoptions.Controls.Add(this.pnldesktoppreview);
            this.pnldesktopoptions.Controls.Add(this.Panel10);
            this.pnldesktopoptions.Location = new System.Drawing.Point(134, 9);
            this.pnldesktopoptions.Name = "pnldesktopoptions";
            this.pnldesktopoptions.Size = new System.Drawing.Size(457, 306);
            this.pnldesktopoptions.TabIndex = 16;
            this.pnldesktopoptions.Visible = false;
            // 
            // pnlapplauncheroptions
            // 
            this.pnlapplauncheroptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlapplauncheroptions.Controls.Add(this.pnlalhover);
            this.pnlapplauncheroptions.Controls.Add(this.label119);
            this.pnlapplauncheroptions.Controls.Add(this.Label71);
            this.pnlapplauncheroptions.Controls.Add(this.txtapplauncherwidth);
            this.pnlapplauncheroptions.Controls.Add(this.Label72);
            this.pnlapplauncheroptions.Controls.Add(this.txtappbuttonlabel);
            this.pnlapplauncheroptions.Controls.Add(this.Label51);
            this.pnlapplauncheroptions.Controls.Add(this.Label50);
            this.pnlapplauncheroptions.Controls.Add(this.pnlmaintextcolour);
            this.pnlapplauncheroptions.Controls.Add(this.comboappbuttontextstyle);
            this.pnlapplauncheroptions.Controls.Add(this.comboappbuttontextfont);
            this.pnlapplauncheroptions.Controls.Add(this.Label37);
            this.pnlapplauncheroptions.Controls.Add(this.Label38);
            this.pnlapplauncheroptions.Controls.Add(this.txtappbuttontextsize);
            this.pnlapplauncheroptions.Controls.Add(this.Label39);
            this.pnlapplauncheroptions.Controls.Add(this.Label40);
            this.pnlapplauncheroptions.Controls.Add(this.pnlmainbuttonactivated);
            this.pnlapplauncheroptions.Controls.Add(this.Label28);
            this.pnlapplauncheroptions.Controls.Add(this.Label35);
            this.pnlapplauncheroptions.Controls.Add(this.txtapplicationsbuttonheight);
            this.pnlapplauncheroptions.Controls.Add(this.Label36);
            this.pnlapplauncheroptions.Controls.Add(this.pnlmainbuttoncolour);
            this.pnlapplauncheroptions.Controls.Add(this.Label43);
            this.pnlapplauncheroptions.Location = new System.Drawing.Point(135, 159);
            this.pnlapplauncheroptions.Name = "pnlapplauncheroptions";
            this.pnlapplauncheroptions.Size = new System.Drawing.Size(317, 140);
            this.pnlapplauncheroptions.TabIndex = 10;
            this.pnlapplauncheroptions.Visible = false;
            // 
            // pnlalhover
            // 
            this.pnlalhover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlalhover.Location = new System.Drawing.Point(90, 29);
            this.pnlalhover.Name = "pnlalhover";
            this.pnlalhover.Size = new System.Drawing.Size(41, 20);
            this.pnlalhover.TabIndex = 3;
            this.pnlalhover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetALHoverColor);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(3, 31);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(84, 16);
            this.label119.TabIndex = 2;
            this.label119.Text = "Mouse Over:";
            // 
            // Label71
            // 
            this.Label71.AutoSize = true;
            this.Label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label71.Location = new System.Drawing.Point(203, 103);
            this.Label71.Name = "Label71";
            this.Label71.Size = new System.Drawing.Size(22, 16);
            this.Label71.TabIndex = 33;
            this.Label71.Text = "px";
            // 
            // txtapplauncherwidth
            // 
            this.txtapplauncherwidth.BackColor = System.Drawing.Color.White;
            this.txtapplauncherwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtapplauncherwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapplauncherwidth.ForeColor = System.Drawing.Color.Black;
            this.txtapplauncherwidth.Location = new System.Drawing.Point(148, 101);
            this.txtapplauncherwidth.Name = "txtapplauncherwidth";
            this.txtapplauncherwidth.Size = new System.Drawing.Size(54, 22);
            this.txtapplauncherwidth.TabIndex = 32;
            this.txtapplauncherwidth.TextChanged += new System.EventHandler(this.txtapplauncherwidth_TextChanged);
            // 
            // Label72
            // 
            this.Label72.AutoSize = true;
            this.Label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label72.Location = new System.Drawing.Point(103, 103);
            this.Label72.Name = "Label72";
            this.Label72.Size = new System.Drawing.Size(45, 16);
            this.Label72.TabIndex = 31;
            this.Label72.Text = "Width:";
            // 
            // txtappbuttonlabel
            // 
            this.txtappbuttonlabel.BackColor = System.Drawing.Color.White;
            this.txtappbuttonlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtappbuttonlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtappbuttonlabel.ForeColor = System.Drawing.Color.Black;
            this.txtappbuttonlabel.Location = new System.Drawing.Point(53, 76);
            this.txtappbuttonlabel.Name = "txtappbuttonlabel";
            this.txtappbuttonlabel.Size = new System.Drawing.Size(81, 22);
            this.txtappbuttonlabel.TabIndex = 30;
            this.txtappbuttonlabel.TextChanged += new System.EventHandler(this.txtappbuttonlabel_KeyDown);
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label51.Location = new System.Drawing.Point(2, 79);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(45, 16);
            this.Label51.TabIndex = 29;
            this.Label51.Text = "Label:";
            // 
            // Label50
            // 
            this.Label50.AutoSize = true;
            this.Label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label50.Location = new System.Drawing.Point(140, 79);
            this.Label50.Name = "Label50";
            this.Label50.Size = new System.Drawing.Size(37, 16);
            this.Label50.TabIndex = 28;
            this.Label50.Text = "Font:";
            // 
            // pnlmaintextcolour
            // 
            this.pnlmaintextcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmaintextcolour.Location = new System.Drawing.Point(155, 51);
            this.pnlmaintextcolour.Name = "pnlmaintextcolour";
            this.pnlmaintextcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlmaintextcolour.TabIndex = 19;
            this.pnlmaintextcolour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetAppLauncherTextColor);
            // 
            // comboappbuttontextstyle
            // 
            this.comboappbuttontextstyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboappbuttontextstyle.FormattingEnabled = true;
            this.comboappbuttontextstyle.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Strikeout",
            "Underline"});
            this.comboappbuttontextstyle.Location = new System.Drawing.Point(243, 49);
            this.comboappbuttontextstyle.Name = "comboappbuttontextstyle";
            this.comboappbuttontextstyle.Size = new System.Drawing.Size(64, 24);
            this.comboappbuttontextstyle.TabIndex = 27;
            this.comboappbuttontextstyle.SelectedIndexChanged += new System.EventHandler(this.comboappbuttontextstyle_SelectedIndexChanged);
            // 
            // comboappbuttontextfont
            // 
            this.comboappbuttontextfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboappbuttontextfont.FormattingEnabled = true;
            this.comboappbuttontextfont.Location = new System.Drawing.Point(181, 75);
            this.comboappbuttontextfont.Name = "comboappbuttontextfont";
            this.comboappbuttontextfont.Size = new System.Drawing.Size(125, 24);
            this.comboappbuttontextfont.TabIndex = 26;
            this.comboappbuttontextfont.SelectedIndexChanged += new System.EventHandler(this.comboappbuttontextfont_SelectedIndexChanged);
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.Location = new System.Drawing.Point(200, 52);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(41, 16);
            this.Label37.TabIndex = 25;
            this.Label37.Text = "Style:";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label38.Location = new System.Drawing.Point(75, 52);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(22, 16);
            this.Label38.TabIndex = 24;
            this.Label38.Text = "px";
            // 
            // txtappbuttontextsize
            // 
            this.txtappbuttontextsize.BackColor = System.Drawing.Color.White;
            this.txtappbuttontextsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtappbuttontextsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtappbuttontextsize.ForeColor = System.Drawing.Color.Black;
            this.txtappbuttontextsize.Location = new System.Drawing.Point(51, 50);
            this.txtappbuttontextsize.Name = "txtappbuttontextsize";
            this.txtappbuttontextsize.Size = new System.Drawing.Size(23, 22);
            this.txtappbuttontextsize.TabIndex = 23;
            this.txtappbuttontextsize.TextChanged += new System.EventHandler(this.txtappbuttontextsize_TextChanged);
            // 
            // Label39
            // 
            this.Label39.AutoSize = true;
            this.Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label39.Location = new System.Drawing.Point(1, 52);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(49, 16);
            this.Label39.TabIndex = 22;
            this.Label39.Text = "T Size:";
            // 
            // Label40
            // 
            this.Label40.AutoSize = true;
            this.Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label40.Location = new System.Drawing.Point(101, 53);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(50, 16);
            this.Label40.TabIndex = 21;
            this.Label40.Text = "Colour:";
            // 
            // pnlmainbuttonactivated
            // 
            this.pnlmainbuttonactivated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmainbuttonactivated.Location = new System.Drawing.Point(267, 6);
            this.pnlmainbuttonactivated.Name = "pnlmainbuttonactivated";
            this.pnlmainbuttonactivated.Size = new System.Drawing.Size(41, 20);
            this.pnlmainbuttonactivated.TabIndex = 16;
            this.pnlmainbuttonactivated.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetALButtonClickedColor);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label28.Location = new System.Drawing.Point(177, 7);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(67, 16);
            this.Label28.TabIndex = 15;
            this.Label28.Text = "Activated:";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(77, 103);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(22, 16);
            this.Label35.TabIndex = 14;
            this.Label35.Text = "px";
            // 
            // txtapplicationsbuttonheight
            // 
            this.txtapplicationsbuttonheight.BackColor = System.Drawing.Color.White;
            this.txtapplicationsbuttonheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtapplicationsbuttonheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapplicationsbuttonheight.ForeColor = System.Drawing.Color.Black;
            this.txtapplicationsbuttonheight.Location = new System.Drawing.Point(53, 101);
            this.txtapplicationsbuttonheight.Name = "txtapplicationsbuttonheight";
            this.txtapplicationsbuttonheight.Size = new System.Drawing.Size(23, 22);
            this.txtapplicationsbuttonheight.TabIndex = 13;
            this.txtapplicationsbuttonheight.TextChanged += new System.EventHandler(this.txtapplicationsbuttonheight_TextChanged);
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.Location = new System.Drawing.Point(2, 103);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(50, 16);
            this.Label36.TabIndex = 12;
            this.Label36.Text = "Height:";
            // 
            // pnlmainbuttoncolour
            // 
            this.pnlmainbuttoncolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmainbuttoncolour.Location = new System.Drawing.Point(128, 4);
            this.pnlmainbuttoncolour.Name = "pnlmainbuttoncolour";
            this.pnlmainbuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlmainbuttoncolour.TabIndex = 1;
            this.pnlmainbuttoncolour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetALButtonColor);
            // 
            // Label43
            // 
            this.Label43.AutoSize = true;
            this.Label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label43.Location = new System.Drawing.Point(3, 7);
            this.Label43.Name = "Label43";
            this.Label43.Size = new System.Drawing.Size(122, 16);
            this.Label43.TabIndex = 0;
            this.Label43.Text = "Main Button Colour:";
            // 
            // pnldesktopintro
            // 
            this.pnldesktopintro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktopintro.Controls.Add(this.Label69);
            this.pnldesktopintro.Controls.Add(this.Label70);
            this.pnldesktopintro.Location = new System.Drawing.Point(135, 159);
            this.pnldesktopintro.Name = "pnldesktopintro";
            this.pnldesktopintro.Size = new System.Drawing.Size(317, 140);
            this.pnldesktopintro.TabIndex = 17;
            // 
            // Label69
            // 
            this.Label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label69.Location = new System.Drawing.Point(3, 20);
            this.Label69.Name = "Label69";
            this.Label69.Size = new System.Drawing.Size(312, 113);
            this.Label69.TabIndex = 1;
            this.Label69.Text = "The Desktop Settings allow you to customize various desktop-related settings such" +
    " as the desktop background. Go ahead and explore!";
            this.Label69.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label70
            // 
            this.Label70.AutoSize = true;
            this.Label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label70.Location = new System.Drawing.Point(86, -2);
            this.Label70.Name = "Label70";
            this.Label70.Size = new System.Drawing.Size(148, 20);
            this.Label70.TabIndex = 0;
            this.Label70.Text = "Desktop Settings";
            // 
            // pnlpanelbuttonsoptions
            // 
            this.pnlpanelbuttonsoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlpanelbuttonsoptions.Controls.Add(this.pnlpanelbuttontextcolour);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label101);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttontexttop);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label104);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttontextside);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label106);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label93);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttontop);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label94);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttoninitalgap);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label108);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttonicontop);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label110);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttoniconside);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label112);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttoniconsize);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label105);
            this.pnlpanelbuttonsoptions.Controls.Add(this.cbpanelbuttontextstyle);
            this.pnlpanelbuttonsoptions.Controls.Add(this.cbpanelbuttonfont);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label100);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpaneltextbuttonsize);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label102);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label103);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label98);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttongap);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label99);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label96);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttonheight);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label97);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label92);
            this.pnlpanelbuttonsoptions.Controls.Add(this.txtpanelbuttonwidth);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label91);
            this.pnlpanelbuttonsoptions.Controls.Add(this.pnlpanelbuttoncolour);
            this.pnlpanelbuttonsoptions.Controls.Add(this.Label95);
            this.pnlpanelbuttonsoptions.Location = new System.Drawing.Point(135, 159);
            this.pnlpanelbuttonsoptions.Name = "pnlpanelbuttonsoptions";
            this.pnlpanelbuttonsoptions.Size = new System.Drawing.Size(317, 140);
            this.pnlpanelbuttonsoptions.TabIndex = 10;
            this.pnlpanelbuttonsoptions.Visible = false;
            // 
            // pnlpanelbuttontextcolour
            // 
            this.pnlpanelbuttontextcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpanelbuttontextcolour.Location = new System.Drawing.Point(270, 57);
            this.pnlpanelbuttontextcolour.Name = "pnlpanelbuttontextcolour";
            this.pnlpanelbuttontextcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlpanelbuttontextcolour.TabIndex = 50;
            this.pnlpanelbuttontextcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetPanelButtonTextColor);
            // 
            // Label101
            // 
            this.Label101.AutoSize = true;
            this.Label101.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label101.Location = new System.Drawing.Point(219, 59);
            this.Label101.Name = "Label101";
            this.Label101.Size = new System.Drawing.Size(50, 16);
            this.Label101.TabIndex = 49;
            this.Label101.Text = "Colour:";
            // 
            // txtpanelbuttontexttop
            // 
            this.txtpanelbuttontexttop.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttontexttop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttontexttop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttontexttop.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttontexttop.Location = new System.Drawing.Point(225, 82);
            this.txtpanelbuttontexttop.Name = "txtpanelbuttontexttop";
            this.txtpanelbuttontexttop.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttontexttop.TabIndex = 48;
            this.txtpanelbuttontexttop.TextChanged += new System.EventHandler(this.txtpanelbuttontexttop_TextChanged);
            // 
            // Label104
            // 
            this.Label104.AutoSize = true;
            this.Label104.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label104.Location = new System.Drawing.Point(191, 84);
            this.Label104.Name = "Label104";
            this.Label104.Size = new System.Drawing.Size(36, 16);
            this.Label104.TabIndex = 47;
            this.Label104.Text = "Top:";
            // 
            // txtpanelbuttontextside
            // 
            this.txtpanelbuttontextside.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttontextside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttontextside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttontextside.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttontextside.Location = new System.Drawing.Point(165, 82);
            this.txtpanelbuttontextside.Name = "txtpanelbuttontextside";
            this.txtpanelbuttontextside.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttontextside.TabIndex = 46;
            this.txtpanelbuttontextside.TextChanged += new System.EventHandler(this.txtpanelbuttontextside_TextChanged);
            // 
            // Label106
            // 
            this.Label106.AutoSize = true;
            this.Label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label106.Location = new System.Drawing.Point(128, 84);
            this.Label106.Name = "Label106";
            this.Label106.Size = new System.Drawing.Size(39, 16);
            this.Label106.TabIndex = 45;
            this.Label106.Text = "Side:";
            // 
            // Label93
            // 
            this.Label93.AutoSize = true;
            this.Label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label93.Location = new System.Drawing.Point(292, 7);
            this.Label93.Name = "Label93";
            this.Label93.Size = new System.Drawing.Size(22, 16);
            this.Label93.TabIndex = 43;
            this.Label93.Text = "px";
            // 
            // txtpanelbuttontop
            // 
            this.txtpanelbuttontop.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttontop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttontop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttontop.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttontop.Location = new System.Drawing.Point(268, 5);
            this.txtpanelbuttontop.Name = "txtpanelbuttontop";
            this.txtpanelbuttontop.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttontop.TabIndex = 42;
            this.txtpanelbuttontop.TextChanged += new System.EventHandler(this.txtpanelbuttontop_TextChanged);
            // 
            // Label94
            // 
            this.Label94.AutoSize = true;
            this.Label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label94.Location = new System.Drawing.Point(233, 7);
            this.Label94.Name = "Label94";
            this.Label94.Size = new System.Drawing.Size(36, 16);
            this.Label94.TabIndex = 41;
            this.Label94.Text = "Top:";
            // 
            // txtpanelbuttoninitalgap
            // 
            this.txtpanelbuttoninitalgap.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttoninitalgap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttoninitalgap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttoninitalgap.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttoninitalgap.Location = new System.Drawing.Point(207, 5);
            this.txtpanelbuttoninitalgap.Name = "txtpanelbuttoninitalgap";
            this.txtpanelbuttoninitalgap.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttoninitalgap.TabIndex = 40;
            this.txtpanelbuttoninitalgap.TextChanged += new System.EventHandler(this.txtpanelbuttoninitalgap_TextChanged);
            // 
            // Label108
            // 
            this.Label108.AutoSize = true;
            this.Label108.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label108.Location = new System.Drawing.Point(137, 7);
            this.Label108.Name = "Label108";
            this.Label108.Size = new System.Drawing.Size(70, 16);
            this.Label108.TabIndex = 39;
            this.Label108.Text = "Initial Gap:";
            // 
            // txtpanelbuttonicontop
            // 
            this.txtpanelbuttonicontop.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttonicontop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttonicontop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttonicontop.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttonicontop.Location = new System.Drawing.Point(287, 108);
            this.txtpanelbuttonicontop.Name = "txtpanelbuttonicontop";
            this.txtpanelbuttonicontop.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttonicontop.TabIndex = 37;
            this.txtpanelbuttonicontop.TextChanged += new System.EventHandler(this.txtpanelbuttonicontop_TextChanged);
            // 
            // Label110
            // 
            this.Label110.AutoSize = true;
            this.Label110.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label110.Location = new System.Drawing.Point(221, 110);
            this.Label110.Name = "Label110";
            this.Label110.Size = new System.Drawing.Size(64, 16);
            this.Label110.TabIndex = 36;
            this.Label110.Text = "Icon Top:";
            // 
            // txtpanelbuttoniconside
            // 
            this.txtpanelbuttoniconside.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttoniconside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttoniconside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttoniconside.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttoniconside.Location = new System.Drawing.Point(180, 108);
            this.txtpanelbuttoniconside.Name = "txtpanelbuttoniconside";
            this.txtpanelbuttoniconside.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttoniconside.TabIndex = 34;
            this.txtpanelbuttoniconside.TextChanged += new System.EventHandler(this.txtpanelbuttoniconside_TextChanged);
            // 
            // Label112
            // 
            this.Label112.AutoSize = true;
            this.Label112.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label112.Location = new System.Drawing.Point(113, 110);
            this.Label112.Name = "Label112";
            this.Label112.Size = new System.Drawing.Size(67, 16);
            this.Label112.TabIndex = 33;
            this.Label112.Text = "Icon Side:";
            // 
            // txtpanelbuttoniconsize
            // 
            this.txtpanelbuttoniconsize.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttoniconsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttoniconsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttoniconsize.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttoniconsize.Location = new System.Drawing.Point(70, 108);
            this.txtpanelbuttoniconsize.Name = "txtpanelbuttoniconsize";
            this.txtpanelbuttoniconsize.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttoniconsize.TabIndex = 27;
            this.txtpanelbuttoniconsize.TextChanged += new System.EventHandler(this.txtpanelbuttoniconsize_TextChanged);
            // 
            // Label105
            // 
            this.Label105.AutoSize = true;
            this.Label105.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label105.Location = new System.Drawing.Point(3, 110);
            this.Label105.Name = "Label105";
            this.Label105.Size = new System.Drawing.Size(65, 16);
            this.Label105.TabIndex = 26;
            this.Label105.Text = "Icon Size:";
            // 
            // cbpanelbuttontextstyle
            // 
            this.cbpanelbuttontextstyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbpanelbuttontextstyle.FormattingEnabled = true;
            this.cbpanelbuttontextstyle.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Strikeout",
            "Underline"});
            this.cbpanelbuttontextstyle.Location = new System.Drawing.Point(46, 83);
            this.cbpanelbuttontextstyle.Name = "cbpanelbuttontextstyle";
            this.cbpanelbuttontextstyle.Size = new System.Drawing.Size(80, 24);
            this.cbpanelbuttontextstyle.TabIndex = 25;
            this.cbpanelbuttontextstyle.SelectedIndexChanged += new System.EventHandler(this.cbpanelbuttontextstyle_SelectedIndexChanged);
            // 
            // cbpanelbuttonfont
            // 
            this.cbpanelbuttonfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbpanelbuttonfont.FormattingEnabled = true;
            this.cbpanelbuttonfont.Location = new System.Drawing.Point(70, 56);
            this.cbpanelbuttonfont.Name = "cbpanelbuttonfont";
            this.cbpanelbuttonfont.Size = new System.Drawing.Size(147, 24);
            this.cbpanelbuttonfont.TabIndex = 24;
            this.cbpanelbuttonfont.SelectedIndexChanged += new System.EventHandler(this.cbpanelbuttonfont_SelectedIndexChanged);
            // 
            // Label100
            // 
            this.Label100.AutoSize = true;
            this.Label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label100.Location = new System.Drawing.Point(3, 86);
            this.Label100.Name = "Label100";
            this.Label100.Size = new System.Drawing.Size(41, 16);
            this.Label100.TabIndex = 23;
            this.Label100.Text = "Style:";
            // 
            // txtpaneltextbuttonsize
            // 
            this.txtpaneltextbuttonsize.BackColor = System.Drawing.Color.White;
            this.txtpaneltextbuttonsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpaneltextbuttonsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpaneltextbuttonsize.ForeColor = System.Drawing.Color.Black;
            this.txtpaneltextbuttonsize.Location = new System.Drawing.Point(287, 82);
            this.txtpaneltextbuttonsize.Name = "txtpaneltextbuttonsize";
            this.txtpaneltextbuttonsize.Size = new System.Drawing.Size(23, 22);
            this.txtpaneltextbuttonsize.TabIndex = 21;
            this.txtpaneltextbuttonsize.TextChanged += new System.EventHandler(this.txtpaneltextbuttonsize_TextChanged);
            // 
            // Label102
            // 
            this.Label102.AutoSize = true;
            this.Label102.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label102.Location = new System.Drawing.Point(252, 84);
            this.Label102.Name = "Label102";
            this.Label102.Size = new System.Drawing.Size(37, 16);
            this.Label102.TabIndex = 20;
            this.Label102.Text = "Size:";
            // 
            // Label103
            // 
            this.Label103.AutoSize = true;
            this.Label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label103.Location = new System.Drawing.Point(3, 60);
            this.Label103.Name = "Label103";
            this.Label103.Size = new System.Drawing.Size(66, 16);
            this.Label103.TabIndex = 19;
            this.Label103.Text = "Text Font:";
            // 
            // Label98
            // 
            this.Label98.AutoSize = true;
            this.Label98.BackColor = System.Drawing.Color.Transparent;
            this.Label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label98.Location = new System.Drawing.Point(292, 33);
            this.Label98.Name = "Label98";
            this.Label98.Size = new System.Drawing.Size(22, 16);
            this.Label98.TabIndex = 14;
            this.Label98.Text = "px";
            // 
            // txtpanelbuttongap
            // 
            this.txtpanelbuttongap.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttongap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttongap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttongap.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttongap.Location = new System.Drawing.Point(268, 31);
            this.txtpanelbuttongap.Name = "txtpanelbuttongap";
            this.txtpanelbuttongap.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttongap.TabIndex = 13;
            this.txtpanelbuttongap.TextChanged += new System.EventHandler(this.txtpanelbuttongap_TextChanged);
            // 
            // Label99
            // 
            this.Label99.AutoSize = true;
            this.Label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label99.Location = new System.Drawing.Point(232, 33);
            this.Label99.Name = "Label99";
            this.Label99.Size = new System.Drawing.Size(37, 16);
            this.Label99.TabIndex = 12;
            this.Label99.Text = "Gap:";
            // 
            // Label96
            // 
            this.Label96.AutoSize = true;
            this.Label96.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label96.Location = new System.Drawing.Point(209, 34);
            this.Label96.Name = "Label96";
            this.Label96.Size = new System.Drawing.Size(22, 16);
            this.Label96.TabIndex = 11;
            this.Label96.Text = "px";
            // 
            // txtpanelbuttonheight
            // 
            this.txtpanelbuttonheight.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttonheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttonheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttonheight.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttonheight.Location = new System.Drawing.Point(185, 32);
            this.txtpanelbuttonheight.Name = "txtpanelbuttonheight";
            this.txtpanelbuttonheight.Size = new System.Drawing.Size(23, 22);
            this.txtpanelbuttonheight.TabIndex = 10;
            this.txtpanelbuttonheight.TextChanged += new System.EventHandler(this.txtpanelbuttonheight_TextChanged);
            // 
            // Label97
            // 
            this.Label97.AutoSize = true;
            this.Label97.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label97.Location = new System.Drawing.Point(135, 34);
            this.Label97.Name = "Label97";
            this.Label97.Size = new System.Drawing.Size(50, 16);
            this.Label97.TabIndex = 9;
            this.Label97.Text = "Height:";
            // 
            // Label92
            // 
            this.Label92.AutoSize = true;
            this.Label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label92.Location = new System.Drawing.Point(114, 33);
            this.Label92.Name = "Label92";
            this.Label92.Size = new System.Drawing.Size(22, 16);
            this.Label92.TabIndex = 8;
            this.Label92.Text = "px";
            // 
            // txtpanelbuttonwidth
            // 
            this.txtpanelbuttonwidth.BackColor = System.Drawing.Color.White;
            this.txtpanelbuttonwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelbuttonwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelbuttonwidth.ForeColor = System.Drawing.Color.Black;
            this.txtpanelbuttonwidth.Location = new System.Drawing.Point(88, 31);
            this.txtpanelbuttonwidth.Name = "txtpanelbuttonwidth";
            this.txtpanelbuttonwidth.Size = new System.Drawing.Size(26, 22);
            this.txtpanelbuttonwidth.TabIndex = 7;
            this.txtpanelbuttonwidth.TextChanged += new System.EventHandler(this.txtpanelbuttonwidth_TextChanged);
            // 
            // Label91
            // 
            this.Label91.AutoSize = true;
            this.Label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label91.Location = new System.Drawing.Point(3, 33);
            this.Label91.Name = "Label91";
            this.Label91.Size = new System.Drawing.Size(85, 16);
            this.Label91.TabIndex = 6;
            this.Label91.Text = "Button Width:";
            // 
            // pnlpanelbuttoncolour
            // 
            this.pnlpanelbuttoncolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpanelbuttoncolour.Location = new System.Drawing.Point(94, 5);
            this.pnlpanelbuttoncolour.Name = "pnlpanelbuttoncolour";
            this.pnlpanelbuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlpanelbuttoncolour.TabIndex = 1;
            this.pnlpanelbuttoncolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetPanelButtonColor);
            // 
            // Label95
            // 
            this.Label95.AutoSize = true;
            this.Label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label95.Location = new System.Drawing.Point(3, 7);
            this.Label95.Name = "Label95";
            this.Label95.Size = new System.Drawing.Size(90, 16);
            this.Label95.TabIndex = 0;
            this.Label95.Text = "Button Colour:";
            // 
            // pnldesktoppaneloptions
            // 
            this.pnldesktoppaneloptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktoppaneloptions.Controls.Add(this.btnpanelbuttons);
            this.pnldesktoppaneloptions.Controls.Add(this.Label27);
            this.pnldesktoppaneloptions.Controls.Add(this.combodesktoppanelposition);
            this.pnldesktoppaneloptions.Controls.Add(this.Label46);
            this.pnldesktoppaneloptions.Controls.Add(this.Label47);
            this.pnldesktoppaneloptions.Controls.Add(this.txtdesktoppanelheight);
            this.pnldesktoppaneloptions.Controls.Add(this.Label48);
            this.pnldesktoppaneloptions.Controls.Add(this.pnldesktoppanelcolour);
            this.pnldesktoppaneloptions.Controls.Add(this.Label49);
            this.pnldesktoppaneloptions.Location = new System.Drawing.Point(135, 159);
            this.pnldesktoppaneloptions.Name = "pnldesktoppaneloptions";
            this.pnldesktoppaneloptions.Size = new System.Drawing.Size(317, 140);
            this.pnldesktoppaneloptions.TabIndex = 9;
            this.pnldesktoppaneloptions.Visible = false;
            // 
            // btnpanelbuttons
            // 
            this.btnpanelbuttons.BackColor = System.Drawing.Color.White;
            this.btnpanelbuttons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpanelbuttons.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpanelbuttons.Location = new System.Drawing.Point(193, 101);
            this.btnpanelbuttons.Name = "btnpanelbuttons";
            this.btnpanelbuttons.Size = new System.Drawing.Size(119, 29);
            this.btnpanelbuttons.TabIndex = 8;
            this.btnpanelbuttons.Text = "Panel Buttons >";
            this.btnpanelbuttons.UseVisualStyleBackColor = false;
            this.btnpanelbuttons.Click += new System.EventHandler(this.btnpanelbuttons_Click);
            // 
            // Label27
            // 
            this.Label27.Location = new System.Drawing.Point(3, 52);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(290, 42);
            this.Label27.TabIndex = 8;
            this.Label27.Text = "Warning: If you set the panel position to the bottom you must hide your windows t" +
    "askbar and restart ShiftOS on your host operating system to prevent a visual bug" +
    ".";
            // 
            // combodesktoppanelposition
            // 
            this.combodesktoppanelposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combodesktoppanelposition.FormattingEnabled = true;
            this.combodesktoppanelposition.Items.AddRange(new object[] {
            "Top",
            "Bottom"});
            this.combodesktoppanelposition.Location = new System.Drawing.Point(103, 28);
            this.combodesktoppanelposition.Name = "combodesktoppanelposition";
            this.combodesktoppanelposition.Size = new System.Drawing.Size(59, 24);
            this.combodesktoppanelposition.TabIndex = 7;
            this.combodesktoppanelposition.SelectedIndexChanged += new System.EventHandler(this.combodesktoppanelposition_SelectedIndexChanged);
            // 
            // Label46
            // 
            this.Label46.AutoSize = true;
            this.Label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label46.Location = new System.Drawing.Point(3, 31);
            this.Label46.Name = "Label46";
            this.Label46.Size = new System.Drawing.Size(97, 16);
            this.Label46.TabIndex = 6;
            this.Label46.Text = "Panel Position:";
            // 
            // Label47
            // 
            this.Label47.AutoSize = true;
            this.Label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label47.Location = new System.Drawing.Point(226, 8);
            this.Label47.Name = "Label47";
            this.Label47.Size = new System.Drawing.Size(22, 16);
            this.Label47.TabIndex = 5;
            this.Label47.Text = "px";
            // 
            // txtdesktoppanelheight
            // 
            this.txtdesktoppanelheight.BackColor = System.Drawing.Color.White;
            this.txtdesktoppanelheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdesktoppanelheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesktoppanelheight.ForeColor = System.Drawing.Color.Black;
            this.txtdesktoppanelheight.Location = new System.Drawing.Point(189, 5);
            this.txtdesktoppanelheight.Name = "txtdesktoppanelheight";
            this.txtdesktoppanelheight.Size = new System.Drawing.Size(37, 22);
            this.txtdesktoppanelheight.TabIndex = 4;
            this.txtdesktoppanelheight.ValueChanged += new System.EventHandler(this.txtdesktoppanelheight_ValueChanged);
            // 
            // Label48
            // 
            this.Label48.AutoSize = true;
            this.Label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label48.Location = new System.Drawing.Point(138, 7);
            this.Label48.Name = "Label48";
            this.Label48.Size = new System.Drawing.Size(50, 16);
            this.Label48.TabIndex = 2;
            this.Label48.Text = "Height:";
            // 
            // pnldesktoppanelcolour
            // 
            this.pnldesktoppanelcolour.Location = new System.Drawing.Point(92, 5);
            this.pnldesktoppanelcolour.Name = "pnldesktoppanelcolour";
            this.pnldesktoppanelcolour.Size = new System.Drawing.Size(41, 20);
            this.pnldesktoppanelcolour.TabIndex = 1;
            this.pnldesktoppanelcolour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeDesktopPanelColor);
            // 
            // Label49
            // 
            this.Label49.AutoSize = true;
            this.Label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label49.Location = new System.Drawing.Point(3, 7);
            this.Label49.Name = "Label49";
            this.Label49.Size = new System.Drawing.Size(88, 16);
            this.Label49.TabIndex = 0;
            this.Label49.Text = "Panel Colour:";
            // 
            // pnldesktopbackgroundoptions
            // 
            this.pnldesktopbackgroundoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktopbackgroundoptions.Controls.Add(this.pnldesktopcolour);
            this.pnldesktopbackgroundoptions.Controls.Add(this.Label45);
            this.pnldesktopbackgroundoptions.Location = new System.Drawing.Point(135, 159);
            this.pnldesktopbackgroundoptions.Name = "pnldesktopbackgroundoptions";
            this.pnldesktopbackgroundoptions.Size = new System.Drawing.Size(317, 140);
            this.pnldesktopbackgroundoptions.TabIndex = 10;
            this.pnldesktopbackgroundoptions.Visible = false;
            // 
            // pnldesktopcolour
            // 
            this.pnldesktopcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnldesktopcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnldesktopcolour.Location = new System.Drawing.Point(112, 5);
            this.pnldesktopcolour.Name = "pnldesktopcolour";
            this.pnldesktopcolour.Size = new System.Drawing.Size(41, 20);
            this.pnldesktopcolour.TabIndex = 3;
            this.pnldesktopcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChangeDesktopBackground);
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label45.Location = new System.Drawing.Point(3, 7);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(104, 16);
            this.Label45.TabIndex = 2;
            this.Label45.Text = "Desktop Colour:";
            // 
            // pnlpanelclockoptions
            // 
            this.pnlpanelclockoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlpanelclockoptions.Controls.Add(this.pnlclockbackgroundcolour);
            this.pnlpanelclockoptions.Controls.Add(this.Label44);
            this.pnlpanelclockoptions.Controls.Add(this.comboclocktextstyle);
            this.pnlpanelclockoptions.Controls.Add(this.comboclocktextfont);
            this.pnlpanelclockoptions.Controls.Add(this.Label26);
            this.pnlpanelclockoptions.Controls.Add(this.Label29);
            this.pnlpanelclockoptions.Controls.Add(this.txtclocktextfromtop);
            this.pnlpanelclockoptions.Controls.Add(this.Label30);
            this.pnlpanelclockoptions.Controls.Add(this.Label31);
            this.pnlpanelclockoptions.Controls.Add(this.txtclocktextsize);
            this.pnlpanelclockoptions.Controls.Add(this.Label32);
            this.pnlpanelclockoptions.Controls.Add(this.Label33);
            this.pnlpanelclockoptions.Controls.Add(this.pnlpanelclocktextcolour);
            this.pnlpanelclockoptions.Controls.Add(this.Label34);
            this.pnlpanelclockoptions.Location = new System.Drawing.Point(135, 159);
            this.pnlpanelclockoptions.Name = "pnlpanelclockoptions";
            this.pnlpanelclockoptions.Size = new System.Drawing.Size(317, 140);
            this.pnlpanelclockoptions.TabIndex = 15;
            this.pnlpanelclockoptions.Visible = false;
            // 
            // pnlclockbackgroundcolour
            // 
            this.pnlclockbackgroundcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlclockbackgroundcolour.Location = new System.Drawing.Point(261, 5);
            this.pnlclockbackgroundcolour.Name = "pnlclockbackgroundcolour";
            this.pnlclockbackgroundcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlclockbackgroundcolour.TabIndex = 20;
            this.pnlclockbackgroundcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetClockBG);
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label44.Location = new System.Drawing.Point(173, 7);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(84, 16);
            this.Label44.TabIndex = 19;
            this.Label44.Text = "Background:";
            // 
            // comboclocktextstyle
            // 
            this.comboclocktextstyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboclocktextstyle.FormattingEnabled = true;
            this.comboclocktextstyle.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Strikeout",
            "Underline"});
            this.comboclocktextstyle.Location = new System.Drawing.Point(209, 54);
            this.comboclocktextstyle.Name = "comboclocktextstyle";
            this.comboclocktextstyle.Size = new System.Drawing.Size(99, 24);
            this.comboclocktextstyle.TabIndex = 18;
            this.comboclocktextstyle.SelectedIndexChanged += new System.EventHandler(this.comboclocktextstyle_SelectedIndexChanged);
            // 
            // comboclocktextfont
            // 
            this.comboclocktextfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboclocktextfont.FormattingEnabled = true;
            this.comboclocktextfont.Location = new System.Drawing.Point(114, 28);
            this.comboclocktextfont.Name = "comboclocktextfont";
            this.comboclocktextfont.Size = new System.Drawing.Size(192, 24);
            this.comboclocktextfont.TabIndex = 17;
            this.comboclocktextfont.SelectedIndexChanged += new System.EventHandler(this.comboclocktextfont_SelectedIndexChanged);
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label26.Location = new System.Drawing.Point(166, 57);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(41, 16);
            this.Label26.TabIndex = 15;
            this.Label26.Text = "Style:";
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label29.Location = new System.Drawing.Point(163, 82);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(22, 16);
            this.Label29.TabIndex = 11;
            this.Label29.Text = "px";
            // 
            // txtclocktextfromtop
            // 
            this.txtclocktextfromtop.BackColor = System.Drawing.Color.White;
            this.txtclocktextfromtop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclocktextfromtop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclocktextfromtop.ForeColor = System.Drawing.Color.Black;
            this.txtclocktextfromtop.Location = new System.Drawing.Point(139, 80);
            this.txtclocktextfromtop.Name = "txtclocktextfromtop";
            this.txtclocktextfromtop.Size = new System.Drawing.Size(23, 22);
            this.txtclocktextfromtop.TabIndex = 10;
            this.txtclocktextfromtop.TextChanged += new System.EventHandler(this.txtclocktextfromtop_TextChanged);
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label30.Location = new System.Drawing.Point(3, 82);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(136, 16);
            this.Label30.TabIndex = 9;
            this.Label30.Text = "Clock Text From Top:";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(138, 57);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(22, 16);
            this.Label31.TabIndex = 8;
            this.Label31.Text = "px";
            // 
            // txtclocktextsize
            // 
            this.txtclocktextsize.BackColor = System.Drawing.Color.White;
            this.txtclocktextsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclocktextsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclocktextsize.ForeColor = System.Drawing.Color.Black;
            this.txtclocktextsize.Location = new System.Drawing.Point(114, 55);
            this.txtclocktextsize.Name = "txtclocktextsize";
            this.txtclocktextsize.Size = new System.Drawing.Size(23, 22);
            this.txtclocktextsize.TabIndex = 7;
            this.txtclocktextsize.Validated += new System.EventHandler(this.txtclocktextsize_TextChanged);
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(3, 57);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(103, 16);
            this.Label32.TabIndex = 6;
            this.Label32.Text = "Clock Text Size:";
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label33.Location = new System.Drawing.Point(3, 32);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(103, 16);
            this.Label33.TabIndex = 2;
            this.Label33.Text = "Clock Text Font:";
            // 
            // pnlpanelclocktextcolour
            // 
            this.pnlpanelclocktextcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpanelclocktextcolour.Location = new System.Drawing.Point(121, 5);
            this.pnlpanelclocktextcolour.Name = "pnlpanelclocktextcolour";
            this.pnlpanelclocktextcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlpanelclocktextcolour.TabIndex = 1;
            this.pnlpanelclocktextcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetClockTextColor);
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label34.Location = new System.Drawing.Point(3, 7);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(116, 16);
            this.Label34.TabIndex = 0;
            this.Label34.Text = "Clock Text Colour:";
            // 
            // pnldesktoppreview
            // 
            this.pnldesktoppreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktoppreview.Controls.Add(this.predesktoppanel);
            this.pnldesktoppreview.Location = new System.Drawing.Point(5, 3);
            this.pnldesktoppreview.Name = "pnldesktoppreview";
            this.pnldesktoppreview.Size = new System.Drawing.Size(448, 148);
            this.pnldesktoppreview.TabIndex = 0;
            // 
            // predesktoppanel
            // 
            this.predesktoppanel.BackColor = System.Drawing.Color.Gray;
            this.predesktoppanel.Controls.Add(this.prepnlpanelbuttonholder);
            this.predesktoppanel.Controls.Add(this.pretimepanel);
            this.predesktoppanel.Controls.Add(this.preapplaunchermenuholder);
            this.predesktoppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.predesktoppanel.Location = new System.Drawing.Point(0, 0);
            this.predesktoppanel.Name = "predesktoppanel";
            this.predesktoppanel.Size = new System.Drawing.Size(448, 25);
            this.predesktoppanel.TabIndex = 1;
            // 
            // prepnlpanelbuttonholder
            // 
            this.prepnlpanelbuttonholder.BackColor = System.Drawing.Color.Transparent;
            this.prepnlpanelbuttonholder.Controls.Add(this.prepnlpanelbutton);
            this.prepnlpanelbuttonholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prepnlpanelbuttonholder.Location = new System.Drawing.Point(116, 0);
            this.prepnlpanelbuttonholder.Name = "prepnlpanelbuttonholder";
            this.prepnlpanelbuttonholder.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.prepnlpanelbuttonholder.Size = new System.Drawing.Size(235, 25);
            this.prepnlpanelbuttonholder.TabIndex = 6;
            // 
            // prepnlpanelbutton
            // 
            this.prepnlpanelbutton.BackColor = System.Drawing.Color.Black;
            this.prepnlpanelbutton.Controls.Add(this.pretbicon);
            this.prepnlpanelbutton.Controls.Add(this.pretbctext);
            this.prepnlpanelbutton.Location = new System.Drawing.Point(5, 3);
            this.prepnlpanelbutton.Name = "prepnlpanelbutton";
            this.prepnlpanelbutton.Size = new System.Drawing.Size(126, 20);
            this.prepnlpanelbutton.TabIndex = 18;
            this.prepnlpanelbutton.Visible = false;
            // 
            // pretbicon
            // 
            this.pretbicon.BackColor = System.Drawing.Color.Transparent;
            this.pretbicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pretbicon.Location = new System.Drawing.Point(4, 2);
            this.pretbicon.Name = "pretbicon";
            this.pretbicon.Size = new System.Drawing.Size(16, 16);
            this.pretbicon.TabIndex = 1;
            this.pretbicon.TabStop = false;
            // 
            // pretbctext
            // 
            this.pretbctext.AutoSize = true;
            this.pretbctext.BackColor = System.Drawing.Color.Transparent;
            this.pretbctext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretbctext.ForeColor = System.Drawing.Color.White;
            this.pretbctext.Location = new System.Drawing.Point(24, 2);
            this.pretbctext.Name = "pretbctext";
            this.pretbctext.Size = new System.Drawing.Size(45, 16);
            this.pretbctext.TabIndex = 0;
            this.pretbctext.Text = "Shifter";
            // 
            // pretimepanel
            // 
            this.pretimepanel.Controls.Add(this.prepaneltimetext);
            this.pretimepanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pretimepanel.Location = new System.Drawing.Point(351, 0);
            this.pretimepanel.Name = "pretimepanel";
            this.pretimepanel.Size = new System.Drawing.Size(97, 25);
            this.pretimepanel.TabIndex = 5;
            // 
            // prepaneltimetext
            // 
            this.prepaneltimetext.AutoSize = true;
            this.prepaneltimetext.BackColor = System.Drawing.Color.Transparent;
            this.prepaneltimetext.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepaneltimetext.Location = new System.Drawing.Point(5, 0);
            this.prepaneltimetext.Name = "prepaneltimetext";
            this.prepaneltimetext.Size = new System.Drawing.Size(80, 24);
            this.prepaneltimetext.TabIndex = 1;
            this.prepaneltimetext.Text = "5000023";
            this.prepaneltimetext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preapplaunchermenuholder
            // 
            this.preapplaunchermenuholder.Controls.Add(this.predesktopappmenu);
            this.preapplaunchermenuholder.Dock = System.Windows.Forms.DockStyle.Left;
            this.preapplaunchermenuholder.Location = new System.Drawing.Point(0, 0);
            this.preapplaunchermenuholder.Name = "preapplaunchermenuholder";
            this.preapplaunchermenuholder.Size = new System.Drawing.Size(116, 25);
            this.preapplaunchermenuholder.TabIndex = 4;
            // 
            // predesktopappmenu
            // 
            this.predesktopappmenu.AutoSize = false;
            this.predesktopappmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplicationsToolStripMenuItem});
            this.predesktopappmenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.predesktopappmenu.Location = new System.Drawing.Point(0, 0);
            this.predesktopappmenu.Name = "predesktopappmenu";
            this.predesktopappmenu.Padding = new System.Windows.Forms.Padding(0);
            this.predesktopappmenu.Size = new System.Drawing.Size(116, 24);
            this.predesktopappmenu.TabIndex = 0;
            this.predesktopappmenu.Text = "MenuStrip1";
            // 
            // ApplicationsToolStripMenuItem
            // 
            this.ApplicationsToolStripMenuItem.AutoSize = false;
            this.ApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KnowledgeInputToolStripMenuItem,
            this.ShiftoriumToolStripMenuItem,
            this.ClockToolStripMenuItem,
            this.TerminalToolStripMenuItem,
            this.ShifterToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ShutdownToolStripMenuItem});
            this.ApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationsToolStripMenuItem.Name = "ApplicationsToolStripMenuItem";
            this.ApplicationsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ApplicationsToolStripMenuItem.ShowShortcutKeys = false;
            this.ApplicationsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.ApplicationsToolStripMenuItem.Text = "Applications";
            this.ApplicationsToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.ApplicationsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // KnowledgeInputToolStripMenuItem
            // 
            this.KnowledgeInputToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.KnowledgeInputToolStripMenuItem.Name = "KnowledgeInputToolStripMenuItem";
            this.KnowledgeInputToolStripMenuItem.ShowShortcutKeys = false;
            this.KnowledgeInputToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.KnowledgeInputToolStripMenuItem.Text = "Knowledge Input";
            // 
            // ShiftoriumToolStripMenuItem
            // 
            this.ShiftoriumToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShiftoriumToolStripMenuItem.Name = "ShiftoriumToolStripMenuItem";
            this.ShiftoriumToolStripMenuItem.ShowShortcutKeys = false;
            this.ShiftoriumToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShiftoriumToolStripMenuItem.Text = "Shiftorium";
            // 
            // ClockToolStripMenuItem
            // 
            this.ClockToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ClockToolStripMenuItem.Name = "ClockToolStripMenuItem";
            this.ClockToolStripMenuItem.ShowShortcutKeys = false;
            this.ClockToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ClockToolStripMenuItem.Text = "Clock";
            // 
            // TerminalToolStripMenuItem
            // 
            this.TerminalToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.TerminalToolStripMenuItem.Name = "TerminalToolStripMenuItem";
            this.TerminalToolStripMenuItem.ShowShortcutKeys = false;
            this.TerminalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.TerminalToolStripMenuItem.Text = "Terminal";
            // 
            // ShifterToolStripMenuItem
            // 
            this.ShifterToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShifterToolStripMenuItem.Name = "ShifterToolStripMenuItem";
            this.ShifterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShifterToolStripMenuItem.Text = "Shifter";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // ShutdownToolStripMenuItem
            // 
            this.ShutdownToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem";
            this.ShutdownToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShutdownToolStripMenuItem.Text = "Shut Down";
            // 
            // Panel10
            // 
            this.Panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel10.Controls.Add(this.btndesktopitself);
            this.Panel10.Controls.Add(this.btnpanelclock);
            this.Panel10.Controls.Add(this.btnapplauncher);
            this.Panel10.Controls.Add(this.btndesktoppanel);
            this.Panel10.Location = new System.Drawing.Point(1, 168);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(128, 135);
            this.Panel10.TabIndex = 8;
            // 
            // btndesktopitself
            // 
            this.btndesktopitself.BackColor = System.Drawing.Color.White;
            this.btndesktopitself.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesktopitself.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndesktopitself.Location = new System.Drawing.Point(4, 105);
            this.btndesktopitself.Name = "btndesktopitself";
            this.btndesktopitself.Size = new System.Drawing.Size(119, 29);
            this.btndesktopitself.TabIndex = 7;
            this.btndesktopitself.Text = "Desktop";
            this.btndesktopitself.UseVisualStyleBackColor = false;
            this.btndesktopitself.Click += new System.EventHandler(this.btndesktopitself_Click);
            // 
            // btnpanelclock
            // 
            this.btnpanelclock.BackColor = System.Drawing.Color.White;
            this.btnpanelclock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpanelclock.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpanelclock.Location = new System.Drawing.Point(4, 70);
            this.btnpanelclock.Name = "btnpanelclock";
            this.btnpanelclock.Size = new System.Drawing.Size(119, 29);
            this.btnpanelclock.TabIndex = 6;
            this.btnpanelclock.Text = "Panel Clock";
            this.btnpanelclock.UseVisualStyleBackColor = false;
            this.btnpanelclock.Click += new System.EventHandler(this.btnpanelclock_Click);
            // 
            // btnapplauncher
            // 
            this.btnapplauncher.BackColor = System.Drawing.Color.White;
            this.btnapplauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnapplauncher.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapplauncher.Location = new System.Drawing.Point(4, 35);
            this.btnapplauncher.Name = "btnapplauncher";
            this.btnapplauncher.Size = new System.Drawing.Size(119, 29);
            this.btnapplauncher.TabIndex = 5;
            this.btnapplauncher.Text = "App Launcher";
            this.btnapplauncher.UseVisualStyleBackColor = false;
            this.btnapplauncher.Click += new System.EventHandler(this.btnapplauncher_Click);
            // 
            // btndesktoppanel
            // 
            this.btndesktoppanel.BackColor = System.Drawing.Color.White;
            this.btndesktoppanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesktoppanel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndesktoppanel.Location = new System.Drawing.Point(4, 0);
            this.btndesktoppanel.Name = "btndesktoppanel";
            this.btndesktoppanel.Size = new System.Drawing.Size(119, 29);
            this.btndesktoppanel.TabIndex = 4;
            this.btndesktoppanel.Text = "Desktop Panel";
            this.btndesktoppanel.UseVisualStyleBackColor = false;
            this.btndesktoppanel.Click += new System.EventHandler(this.btndesktoppanel_Click);
            // 
            // txtpanelbuttoniconheight
            // 
            this.txtpanelbuttoniconheight.Location = new System.Drawing.Point(0, 0);
            this.txtpanelbuttoniconheight.Name = "txtpanelbuttoniconheight";
            this.txtpanelbuttoniconheight.Size = new System.Drawing.Size(100, 20);
            this.txtpanelbuttoniconheight.TabIndex = 0;
            // 
            // pnlwindowsoptions
            // 
            this.pnlwindowsoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlwindowsoptions.BackColor = System.Drawing.Color.White;
            this.pnlwindowsoptions.Controls.Add(this.pnlwindowsintro);
            this.pnlwindowsoptions.Controls.Add(this.pnlbuttonoptions);
            this.pnlwindowsoptions.Controls.Add(this.pnltitlebaroptions);
            this.pnlwindowsoptions.Controls.Add(this.pnlborderoptions);
            this.pnlwindowsoptions.Controls.Add(this.pnltitletextoptions);
            this.pnlwindowsoptions.Controls.Add(this.pnlwindowsobjects);
            this.pnlwindowsoptions.Controls.Add(this.pnlwindowpreview);
            this.pnlwindowsoptions.Location = new System.Drawing.Point(134, 9);
            this.pnlwindowsoptions.Name = "pnlwindowsoptions";
            this.pnlwindowsoptions.Size = new System.Drawing.Size(457, 306);
            this.pnlwindowsoptions.TabIndex = 4;
            // 
            // pnlwindowsintro
            // 
            this.pnlwindowsintro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlwindowsintro.Controls.Add(this.Label68);
            this.pnlwindowsintro.Controls.Add(this.Label67);
            this.pnlwindowsintro.Location = new System.Drawing.Point(135, 159);
            this.pnlwindowsintro.Name = "pnlwindowsintro";
            this.pnlwindowsintro.Size = new System.Drawing.Size(325, 139);
            this.pnlwindowsintro.TabIndex = 16;
            // 
            // Label68
            // 
            this.Label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label68.Location = new System.Drawing.Point(3, 20);
            this.Label68.Name = "Label68";
            this.Label68.Size = new System.Drawing.Size(312, 113);
            this.Label68.TabIndex = 1;
            this.Label68.Text = "Welcome to the Windows category. Here, you may skin various aspects of windows in" +
    " ShiftOS.";
            this.Label68.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label68.Click += new System.EventHandler(this.Label68_Click);
            // 
            // Label67
            // 
            this.Label67.AutoSize = true;
            this.Label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label67.Location = new System.Drawing.Point(89, -2);
            this.Label67.Name = "Label67";
            this.Label67.Size = new System.Drawing.Size(143, 20);
            this.Label67.TabIndex = 0;
            this.Label67.Text = "Window Settings";
            // 
            // pnlbuttonoptions
            // 
            this.pnlbuttonoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlbuttonoptions.Controls.Add(this.pnlclosebuttonoptions);
            this.pnlbuttonoptions.Controls.Add(this.pnlrollupbuttonoptions);
            this.pnlbuttonoptions.Controls.Add(this.pnlminimizebuttonoptions);
            this.pnlbuttonoptions.Controls.Add(this.combobuttonoption);
            this.pnlbuttonoptions.Controls.Add(this.Label52);
            this.pnlbuttonoptions.Location = new System.Drawing.Point(135, 159);
            this.pnlbuttonoptions.Name = "pnlbuttonoptions";
            this.pnlbuttonoptions.Size = new System.Drawing.Size(325, 139);
            this.pnlbuttonoptions.TabIndex = 10;
            this.pnlbuttonoptions.Visible = false;
            // 
            // pnlclosebuttonoptions
            // 
            this.pnlclosebuttonoptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlclosebuttonoptions.Controls.Add(this.Label8);
            this.pnlclosebuttonoptions.Controls.Add(this.Label11);
            this.pnlclosebuttonoptions.Controls.Add(this.pnlclosebuttoncolour);
            this.pnlclosebuttonoptions.Controls.Add(this.txtclosebuttonfromside);
            this.pnlclosebuttonoptions.Controls.Add(this.Label7);
            this.pnlclosebuttonoptions.Controls.Add(this.Label12);
            this.pnlclosebuttonoptions.Controls.Add(this.txtclosebuttonheight);
            this.pnlclosebuttonoptions.Controls.Add(this.Label13);
            this.pnlclosebuttonoptions.Controls.Add(this.Label6);
            this.pnlclosebuttonoptions.Controls.Add(this.txtclosebuttonfromtop);
            this.pnlclosebuttonoptions.Controls.Add(this.Label10);
            this.pnlclosebuttonoptions.Controls.Add(this.Label14);
            this.pnlclosebuttonoptions.Controls.Add(this.txtclosebuttonwidth);
            this.pnlclosebuttonoptions.Controls.Add(this.Label9);
            this.pnlclosebuttonoptions.Location = new System.Drawing.Point(4, 29);
            this.pnlclosebuttonoptions.Name = "pnlclosebuttonoptions";
            this.pnlclosebuttonoptions.Size = new System.Drawing.Size(311, 105);
            this.pnlclosebuttonoptions.TabIndex = 15;
            this.pnlclosebuttonoptions.Visible = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(3, 6);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(128, 16);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Close Button Colour:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(177, 82);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(22, 16);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "px";
            // 
            // pnlclosebuttoncolour
            // 
            this.pnlclosebuttoncolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlclosebuttoncolour.Location = new System.Drawing.Point(132, 4);
            this.pnlclosebuttoncolour.Name = "pnlclosebuttoncolour";
            this.pnlclosebuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlclosebuttoncolour.TabIndex = 1;
            this.pnlclosebuttoncolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetcloseColor);
            // 
            // txtclosebuttonfromside
            // 
            this.txtclosebuttonfromside.BackColor = System.Drawing.Color.White;
            this.txtclosebuttonfromside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclosebuttonfromside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclosebuttonfromside.ForeColor = System.Drawing.Color.Black;
            this.txtclosebuttonfromside.Location = new System.Drawing.Point(153, 80);
            this.txtclosebuttonfromside.Name = "txtclosebuttonfromside";
            this.txtclosebuttonfromside.Size = new System.Drawing.Size(23, 22);
            this.txtclosebuttonfromside.TabIndex = 13;
            this.txtclosebuttonfromside.TextChanged += new System.EventHandler(this.txtclosebuttonfromside_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(3, 32);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(128, 16);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Close Button Height:";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(3, 82);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(151, 16);
            this.Label12.TabIndex = 12;
            this.Label12.Text = "Close Button From Side:";
            // 
            // txtclosebuttonheight
            // 
            this.txtclosebuttonheight.BackColor = System.Drawing.Color.White;
            this.txtclosebuttonheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclosebuttonheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclosebuttonheight.ForeColor = System.Drawing.Color.Black;
            this.txtclosebuttonheight.Location = new System.Drawing.Point(132, 30);
            this.txtclosebuttonheight.Name = "txtclosebuttonheight";
            this.txtclosebuttonheight.Size = new System.Drawing.Size(23, 22);
            this.txtclosebuttonheight.TabIndex = 4;
            this.txtclosebuttonheight.TextChanged += new System.EventHandler(this.txtclosebuttonheight_TextChanged);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(177, 57);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(22, 16);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "px";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(156, 32);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(22, 16);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "px";
            // 
            // txtclosebuttonfromtop
            // 
            this.txtclosebuttonfromtop.BackColor = System.Drawing.Color.White;
            this.txtclosebuttonfromtop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclosebuttonfromtop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclosebuttonfromtop.ForeColor = System.Drawing.Color.Black;
            this.txtclosebuttonfromtop.Location = new System.Drawing.Point(153, 55);
            this.txtclosebuttonfromtop.Name = "txtclosebuttonfromtop";
            this.txtclosebuttonfromtop.Size = new System.Drawing.Size(23, 22);
            this.txtclosebuttonfromtop.TabIndex = 10;
            this.txtclosebuttonfromtop.TextChanged += new System.EventHandler(this.txtclosebuttonfromtop_TextChanged);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(184, 32);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(45, 16);
            this.Label10.TabIndex = 6;
            this.Label10.Text = "Width:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(3, 57);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(148, 16);
            this.Label14.TabIndex = 9;
            this.Label14.Text = "Close Button From Top:";
            // 
            // txtclosebuttonwidth
            // 
            this.txtclosebuttonwidth.BackColor = System.Drawing.Color.White;
            this.txtclosebuttonwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtclosebuttonwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclosebuttonwidth.ForeColor = System.Drawing.Color.Black;
            this.txtclosebuttonwidth.Location = new System.Drawing.Point(234, 30);
            this.txtclosebuttonwidth.Name = "txtclosebuttonwidth";
            this.txtclosebuttonwidth.Size = new System.Drawing.Size(23, 22);
            this.txtclosebuttonwidth.TabIndex = 7;
            this.txtclosebuttonwidth.TextChanged += new System.EventHandler(this.txtclosebuttonwidth_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(258, 32);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(22, 16);
            this.Label9.TabIndex = 8;
            this.Label9.Text = "px";
            // 
            // pnlrollupbuttonoptions
            // 
            this.pnlrollupbuttonoptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlrollupbuttonoptions.Controls.Add(this.Label54);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label55);
            this.pnlrollupbuttonoptions.Controls.Add(this.pnlrollupbuttoncolour);
            this.pnlrollupbuttonoptions.Controls.Add(this.txtrollupbuttonside);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label56);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label57);
            this.pnlrollupbuttonoptions.Controls.Add(this.txtrollupbuttonheight);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label58);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label59);
            this.pnlrollupbuttonoptions.Controls.Add(this.txtrollupbuttontop);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label60);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label61);
            this.pnlrollupbuttonoptions.Controls.Add(this.txtrollupbuttonwidth);
            this.pnlrollupbuttonoptions.Controls.Add(this.Label62);
            this.pnlrollupbuttonoptions.Location = new System.Drawing.Point(4, 29);
            this.pnlrollupbuttonoptions.Name = "pnlrollupbuttonoptions";
            this.pnlrollupbuttonoptions.Size = new System.Drawing.Size(311, 105);
            this.pnlrollupbuttonoptions.TabIndex = 16;
            this.pnlrollupbuttonoptions.Visible = false;
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label54.Location = new System.Drawing.Point(3, 6);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(138, 16);
            this.Label54.TabIndex = 0;
            this.Label54.Text = "Roll Up Button Colour:";
            // 
            // Label55
            // 
            this.Label55.AutoSize = true;
            this.Label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label55.Location = new System.Drawing.Point(188, 82);
            this.Label55.Name = "Label55";
            this.Label55.Size = new System.Drawing.Size(22, 16);
            this.Label55.TabIndex = 14;
            this.Label55.Text = "px";
            // 
            // pnlrollupbuttoncolour
            // 
            this.pnlrollupbuttoncolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlrollupbuttoncolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlrollupbuttoncolour.Location = new System.Drawing.Point(143, 4);
            this.pnlrollupbuttoncolour.Name = "pnlrollupbuttoncolour";
            this.pnlrollupbuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlrollupbuttoncolour.TabIndex = 1;
            this.pnlrollupbuttoncolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetrollupColor);
            // 
            // txtrollupbuttonside
            // 
            this.txtrollupbuttonside.BackColor = System.Drawing.Color.White;
            this.txtrollupbuttonside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrollupbuttonside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrollupbuttonside.ForeColor = System.Drawing.Color.Black;
            this.txtrollupbuttonside.Location = new System.Drawing.Point(164, 80);
            this.txtrollupbuttonside.Name = "txtrollupbuttonside";
            this.txtrollupbuttonside.Size = new System.Drawing.Size(23, 22);
            this.txtrollupbuttonside.TabIndex = 13;
            this.txtrollupbuttonside.TextChanged += new System.EventHandler(this.txtrollupbuttonside_TextChanged);
            // 
            // Label56
            // 
            this.Label56.AutoSize = true;
            this.Label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label56.Location = new System.Drawing.Point(3, 32);
            this.Label56.Name = "Label56";
            this.Label56.Size = new System.Drawing.Size(138, 16);
            this.Label56.TabIndex = 2;
            this.Label56.Text = "Roll Up Button Height:";
            // 
            // Label57
            // 
            this.Label57.AutoSize = true;
            this.Label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label57.Location = new System.Drawing.Point(3, 82);
            this.Label57.Name = "Label57";
            this.Label57.Size = new System.Drawing.Size(161, 16);
            this.Label57.TabIndex = 12;
            this.Label57.Text = "Roll Up Button From Side:";
            // 
            // txtrollupbuttonheight
            // 
            this.txtrollupbuttonheight.BackColor = System.Drawing.Color.White;
            this.txtrollupbuttonheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrollupbuttonheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrollupbuttonheight.ForeColor = System.Drawing.Color.Black;
            this.txtrollupbuttonheight.Location = new System.Drawing.Point(143, 30);
            this.txtrollupbuttonheight.Name = "txtrollupbuttonheight";
            this.txtrollupbuttonheight.Size = new System.Drawing.Size(23, 22);
            this.txtrollupbuttonheight.TabIndex = 4;
            this.txtrollupbuttonheight.TextChanged += new System.EventHandler(this.txtrollupbuttonheight_TextChanged);
            // 
            // Label58
            // 
            this.Label58.AutoSize = true;
            this.Label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label58.Location = new System.Drawing.Point(188, 57);
            this.Label58.Name = "Label58";
            this.Label58.Size = new System.Drawing.Size(22, 16);
            this.Label58.TabIndex = 11;
            this.Label58.Text = "px";
            // 
            // Label59
            // 
            this.Label59.AutoSize = true;
            this.Label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label59.Location = new System.Drawing.Point(167, 32);
            this.Label59.Name = "Label59";
            this.Label59.Size = new System.Drawing.Size(22, 16);
            this.Label59.TabIndex = 5;
            this.Label59.Text = "px";
            // 
            // txtrollupbuttontop
            // 
            this.txtrollupbuttontop.BackColor = System.Drawing.Color.White;
            this.txtrollupbuttontop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrollupbuttontop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrollupbuttontop.ForeColor = System.Drawing.Color.Black;
            this.txtrollupbuttontop.Location = new System.Drawing.Point(164, 55);
            this.txtrollupbuttontop.Name = "txtrollupbuttontop";
            this.txtrollupbuttontop.Size = new System.Drawing.Size(23, 22);
            this.txtrollupbuttontop.TabIndex = 10;
            this.txtrollupbuttontop.TextChanged += new System.EventHandler(this.txtrollupbuttontop_TextChanged);
            // 
            // Label60
            // 
            this.Label60.AutoSize = true;
            this.Label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label60.Location = new System.Drawing.Point(195, 32);
            this.Label60.Name = "Label60";
            this.Label60.Size = new System.Drawing.Size(45, 16);
            this.Label60.TabIndex = 6;
            this.Label60.Text = "Width:";
            // 
            // Label61
            // 
            this.Label61.AutoSize = true;
            this.Label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label61.Location = new System.Drawing.Point(3, 57);
            this.Label61.Name = "Label61";
            this.Label61.Size = new System.Drawing.Size(158, 16);
            this.Label61.TabIndex = 9;
            this.Label61.Text = "Roll Up Button From Top:";
            // 
            // txtrollupbuttonwidth
            // 
            this.txtrollupbuttonwidth.BackColor = System.Drawing.Color.White;
            this.txtrollupbuttonwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrollupbuttonwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrollupbuttonwidth.ForeColor = System.Drawing.Color.Black;
            this.txtrollupbuttonwidth.Location = new System.Drawing.Point(245, 30);
            this.txtrollupbuttonwidth.Name = "txtrollupbuttonwidth";
            this.txtrollupbuttonwidth.Size = new System.Drawing.Size(23, 22);
            this.txtrollupbuttonwidth.TabIndex = 7;
            this.txtrollupbuttonwidth.TextChanged += new System.EventHandler(this.txtrollupbuttonwidth_TextChanged);
            // 
            // Label62
            // 
            this.Label62.AutoSize = true;
            this.Label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label62.Location = new System.Drawing.Point(269, 32);
            this.Label62.Name = "Label62";
            this.Label62.Size = new System.Drawing.Size(22, 16);
            this.Label62.TabIndex = 8;
            this.Label62.Text = "px";
            // 
            // pnlminimizebuttonoptions
            // 
            this.pnlminimizebuttonoptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlminimizebuttonoptions.Controls.Add(this.Label82);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label83);
            this.pnlminimizebuttonoptions.Controls.Add(this.pnlminimizebuttoncolour);
            this.pnlminimizebuttonoptions.Controls.Add(this.txtminimizebuttonside);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label84);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label85);
            this.pnlminimizebuttonoptions.Controls.Add(this.txtminimizebuttonheight);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label86);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label87);
            this.pnlminimizebuttonoptions.Controls.Add(this.txtminimizebuttontop);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label88);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label89);
            this.pnlminimizebuttonoptions.Controls.Add(this.txtminimizebuttonwidth);
            this.pnlminimizebuttonoptions.Controls.Add(this.Label90);
            this.pnlminimizebuttonoptions.Location = new System.Drawing.Point(4, 29);
            this.pnlminimizebuttonoptions.Name = "pnlminimizebuttonoptions";
            this.pnlminimizebuttonoptions.Size = new System.Drawing.Size(311, 105);
            this.pnlminimizebuttonoptions.TabIndex = 18;
            this.pnlminimizebuttonoptions.Visible = false;
            // 
            // Label82
            // 
            this.Label82.AutoSize = true;
            this.Label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label82.Location = new System.Drawing.Point(3, 6);
            this.Label82.Name = "Label82";
            this.Label82.Size = new System.Drawing.Size(145, 16);
            this.Label82.TabIndex = 0;
            this.Label82.Text = "Minimize Button Colour:";
            // 
            // Label83
            // 
            this.Label83.AutoSize = true;
            this.Label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label83.Location = new System.Drawing.Point(196, 82);
            this.Label83.Name = "Label83";
            this.Label83.Size = new System.Drawing.Size(22, 16);
            this.Label83.TabIndex = 14;
            this.Label83.Text = "px";
            // 
            // pnlminimizebuttoncolour
            // 
            this.pnlminimizebuttoncolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlminimizebuttoncolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlminimizebuttoncolour.Location = new System.Drawing.Point(149, 4);
            this.pnlminimizebuttoncolour.Name = "pnlminimizebuttoncolour";
            this.pnlminimizebuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlminimizebuttoncolour.TabIndex = 1;
            this.pnlminimizebuttoncolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetMinimizeColor);
            // 
            // txtminimizebuttonside
            // 
            this.txtminimizebuttonside.BackColor = System.Drawing.Color.White;
            this.txtminimizebuttonside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminimizebuttonside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminimizebuttonside.ForeColor = System.Drawing.Color.Black;
            this.txtminimizebuttonside.Location = new System.Drawing.Point(172, 80);
            this.txtminimizebuttonside.Name = "txtminimizebuttonside";
            this.txtminimizebuttonside.Size = new System.Drawing.Size(23, 22);
            this.txtminimizebuttonside.TabIndex = 13;
            this.txtminimizebuttonside.TextChanged += new System.EventHandler(this.txtminimizebuttonside_TextChanged);
            // 
            // Label84
            // 
            this.Label84.AutoSize = true;
            this.Label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label84.Location = new System.Drawing.Point(3, 32);
            this.Label84.Name = "Label84";
            this.Label84.Size = new System.Drawing.Size(145, 16);
            this.Label84.TabIndex = 2;
            this.Label84.Text = "Minimize Button Height:";
            // 
            // Label85
            // 
            this.Label85.AutoSize = true;
            this.Label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label85.Location = new System.Drawing.Point(3, 82);
            this.Label85.Name = "Label85";
            this.Label85.Size = new System.Drawing.Size(168, 16);
            this.Label85.TabIndex = 12;
            this.Label85.Text = "Minimize Button From Side:";
            // 
            // txtminimizebuttonheight
            // 
            this.txtminimizebuttonheight.BackColor = System.Drawing.Color.White;
            this.txtminimizebuttonheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminimizebuttonheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminimizebuttonheight.ForeColor = System.Drawing.Color.Black;
            this.txtminimizebuttonheight.Location = new System.Drawing.Point(150, 30);
            this.txtminimizebuttonheight.Name = "txtminimizebuttonheight";
            this.txtminimizebuttonheight.Size = new System.Drawing.Size(23, 22);
            this.txtminimizebuttonheight.TabIndex = 4;
            this.txtminimizebuttonheight.TextChanged += new System.EventHandler(this.txtminimizebuttonheight_TextChanged);
            // 
            // Label86
            // 
            this.Label86.AutoSize = true;
            this.Label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label86.Location = new System.Drawing.Point(196, 57);
            this.Label86.Name = "Label86";
            this.Label86.Size = new System.Drawing.Size(22, 16);
            this.Label86.TabIndex = 11;
            this.Label86.Text = "px";
            // 
            // Label87
            // 
            this.Label87.AutoSize = true;
            this.Label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label87.Location = new System.Drawing.Point(174, 32);
            this.Label87.Name = "Label87";
            this.Label87.Size = new System.Drawing.Size(22, 16);
            this.Label87.TabIndex = 5;
            this.Label87.Text = "px";
            // 
            // txtminimizebuttontop
            // 
            this.txtminimizebuttontop.BackColor = System.Drawing.Color.White;
            this.txtminimizebuttontop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminimizebuttontop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminimizebuttontop.ForeColor = System.Drawing.Color.Black;
            this.txtminimizebuttontop.Location = new System.Drawing.Point(172, 55);
            this.txtminimizebuttontop.Name = "txtminimizebuttontop";
            this.txtminimizebuttontop.Size = new System.Drawing.Size(23, 22);
            this.txtminimizebuttontop.TabIndex = 10;
            this.txtminimizebuttontop.TextChanged += new System.EventHandler(this.txtminimizebuttontop_TextChanged);
            // 
            // Label88
            // 
            this.Label88.AutoSize = true;
            this.Label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label88.Location = new System.Drawing.Point(198, 32);
            this.Label88.Name = "Label88";
            this.Label88.Size = new System.Drawing.Size(45, 16);
            this.Label88.TabIndex = 6;
            this.Label88.Text = "Width:";
            // 
            // Label89
            // 
            this.Label89.AutoSize = true;
            this.Label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label89.Location = new System.Drawing.Point(3, 57);
            this.Label89.Name = "Label89";
            this.Label89.Size = new System.Drawing.Size(165, 16);
            this.Label89.TabIndex = 9;
            this.Label89.Text = "Minimize Button From Top:";
            // 
            // txtminimizebuttonwidth
            // 
            this.txtminimizebuttonwidth.BackColor = System.Drawing.Color.White;
            this.txtminimizebuttonwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminimizebuttonwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminimizebuttonwidth.ForeColor = System.Drawing.Color.Black;
            this.txtminimizebuttonwidth.Location = new System.Drawing.Point(247, 30);
            this.txtminimizebuttonwidth.Name = "txtminimizebuttonwidth";
            this.txtminimizebuttonwidth.Size = new System.Drawing.Size(23, 22);
            this.txtminimizebuttonwidth.TabIndex = 7;
            this.txtminimizebuttonwidth.TextChanged += new System.EventHandler(this.txtminimizebuttonwidth_TextChanged);
            // 
            // Label90
            // 
            this.Label90.AutoSize = true;
            this.Label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label90.Location = new System.Drawing.Point(269, 32);
            this.Label90.Name = "Label90";
            this.Label90.Size = new System.Drawing.Size(22, 16);
            this.Label90.TabIndex = 8;
            this.Label90.Text = "px";
            // 
            // combobuttonoption
            // 
            this.combobuttonoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobuttonoption.FormattingEnabled = true;
            this.combobuttonoption.Items.AddRange(new object[] {
            "Close Button",
            "Roll Up Button"});
            this.combobuttonoption.Location = new System.Drawing.Point(157, 4);
            this.combobuttonoption.Name = "combobuttonoption";
            this.combobuttonoption.Size = new System.Drawing.Size(121, 24);
            this.combobuttonoption.TabIndex = 17;
            this.combobuttonoption.SelectedIndexChanged += new System.EventHandler(this.combobuttonoption_SelectedIndexChanged);
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label52.Location = new System.Drawing.Point(40, 6);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(111, 16);
            this.Label52.TabIndex = 15;
            this.Label52.Text = "Button To Modify:";
            // 
            // pnltitlebaroptions
            // 
            this.pnltitlebaroptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnltitlebaroptions.Controls.Add(this.Label80);
            this.pnltitlebaroptions.Controls.Add(this.txticonfromtop);
            this.pnltitlebaroptions.Controls.Add(this.Label81);
            this.pnltitlebaroptions.Controls.Add(this.Label78);
            this.pnltitlebaroptions.Controls.Add(this.txticonfromside);
            this.pnltitlebaroptions.Controls.Add(this.Label79);
            this.pnltitlebaroptions.Controls.Add(this.lbcornerwidthpx);
            this.pnltitlebaroptions.Controls.Add(this.txttitlebarcornerwidth);
            this.pnltitlebaroptions.Controls.Add(this.lbcornerwidth);
            this.pnltitlebaroptions.Controls.Add(this.pnltitlebarrightcornercolour);
            this.pnltitlebaroptions.Controls.Add(this.pnltitlebarleftcornercolour);
            this.pnltitlebaroptions.Controls.Add(this.lbrightcornercolor);
            this.pnltitlebaroptions.Controls.Add(this.lbleftcornercolor);
            this.pnltitlebaroptions.Controls.Add(this.cboxtitlebarcorners);
            this.pnltitlebaroptions.Controls.Add(this.Label5);
            this.pnltitlebaroptions.Controls.Add(this.txttitlebarheight);
            this.pnltitlebaroptions.Controls.Add(this.Label4);
            this.pnltitlebaroptions.Controls.Add(this.pnltitlebarcolour);
            this.pnltitlebaroptions.Controls.Add(this.Label2);
            this.pnltitlebaroptions.Location = new System.Drawing.Point(135, 159);
            this.pnltitlebaroptions.Name = "pnltitlebaroptions";
            this.pnltitlebaroptions.Size = new System.Drawing.Size(325, 139);
            this.pnltitlebaroptions.TabIndex = 9;
            this.pnltitlebaroptions.Visible = false;
            // 
            // Label80
            // 
            this.Label80.AutoSize = true;
            this.Label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label80.Location = new System.Drawing.Point(277, 105);
            this.Label80.Name = "Label80";
            this.Label80.Size = new System.Drawing.Size(22, 16);
            this.Label80.TabIndex = 19;
            this.Label80.Text = "px";
            // 
            // txticonfromtop
            // 
            this.txticonfromtop.BackColor = System.Drawing.Color.White;
            this.txticonfromtop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txticonfromtop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txticonfromtop.ForeColor = System.Drawing.Color.Black;
            this.txticonfromtop.Location = new System.Drawing.Point(253, 103);
            this.txticonfromtop.Name = "txticonfromtop";
            this.txticonfromtop.Size = new System.Drawing.Size(23, 22);
            this.txticonfromtop.TabIndex = 18;
            this.txticonfromtop.TextChanged += new System.EventHandler(this.txticonfromtop_TextChanged);
            // 
            // Label81
            // 
            this.Label81.AutoSize = true;
            this.Label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label81.Location = new System.Drawing.Point(157, 105);
            this.Label81.Name = "Label81";
            this.Label81.Size = new System.Drawing.Size(98, 16);
            this.Label81.TabIndex = 17;
            this.Label81.Text = "Icon From Top:";
            // 
            // Label78
            // 
            this.Label78.AutoSize = true;
            this.Label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label78.Location = new System.Drawing.Point(128, 105);
            this.Label78.Name = "Label78";
            this.Label78.Size = new System.Drawing.Size(22, 16);
            this.Label78.TabIndex = 16;
            this.Label78.Text = "px";
            // 
            // txticonfromside
            // 
            this.txticonfromside.BackColor = System.Drawing.Color.White;
            this.txticonfromside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txticonfromside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txticonfromside.ForeColor = System.Drawing.Color.Black;
            this.txticonfromside.Location = new System.Drawing.Point(104, 103);
            this.txticonfromside.Name = "txticonfromside";
            this.txticonfromside.Size = new System.Drawing.Size(23, 22);
            this.txticonfromside.TabIndex = 15;
            this.txticonfromside.TextChanged += new System.EventHandler(this.txticonfromside_TextChanged);
            // 
            // Label79
            // 
            this.Label79.AutoSize = true;
            this.Label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label79.Location = new System.Drawing.Point(3, 105);
            this.Label79.Name = "Label79";
            this.Label79.Size = new System.Drawing.Size(101, 16);
            this.Label79.TabIndex = 14;
            this.Label79.Text = "Icon From Side:";
            // 
            // lbcornerwidthpx
            // 
            this.lbcornerwidthpx.AutoSize = true;
            this.lbcornerwidthpx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcornerwidthpx.Location = new System.Drawing.Point(277, 32);
            this.lbcornerwidthpx.Name = "lbcornerwidthpx";
            this.lbcornerwidthpx.Size = new System.Drawing.Size(22, 16);
            this.lbcornerwidthpx.TabIndex = 13;
            this.lbcornerwidthpx.Text = "px";
            // 
            // txttitlebarcornerwidth
            // 
            this.txttitlebarcornerwidth.BackColor = System.Drawing.Color.White;
            this.txttitlebarcornerwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitlebarcornerwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitlebarcornerwidth.ForeColor = System.Drawing.Color.Black;
            this.txttitlebarcornerwidth.Location = new System.Drawing.Point(253, 30);
            this.txttitlebarcornerwidth.Name = "txttitlebarcornerwidth";
            this.txttitlebarcornerwidth.Size = new System.Drawing.Size(23, 22);
            this.txttitlebarcornerwidth.TabIndex = 12;
            this.txttitlebarcornerwidth.TextChanged += new System.EventHandler(this.txttitlebarcornerwidth_TextChanged);
            // 
            // lbcornerwidth
            // 
            this.lbcornerwidth.AutoSize = true;
            this.lbcornerwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcornerwidth.Location = new System.Drawing.Point(163, 32);
            this.lbcornerwidth.Name = "lbcornerwidth";
            this.lbcornerwidth.Size = new System.Drawing.Size(88, 16);
            this.lbcornerwidth.TabIndex = 11;
            this.lbcornerwidth.Text = "Corner Width:";
            // 
            // pnltitlebarrightcornercolour
            // 
            this.pnltitlebarrightcornercolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnltitlebarrightcornercolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltitlebarrightcornercolour.Location = new System.Drawing.Point(136, 80);
            this.pnltitlebarrightcornercolour.Name = "pnltitlebarrightcornercolour";
            this.pnltitlebarrightcornercolour.Size = new System.Drawing.Size(41, 20);
            this.pnltitlebarrightcornercolour.TabIndex = 10;
            this.pnltitlebarrightcornercolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetRightCornerColor);
            // 
            // pnltitlebarleftcornercolour
            // 
            this.pnltitlebarleftcornercolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnltitlebarleftcornercolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltitlebarleftcornercolour.Location = new System.Drawing.Point(126, 56);
            this.pnltitlebarleftcornercolour.Name = "pnltitlebarleftcornercolour";
            this.pnltitlebarleftcornercolour.Size = new System.Drawing.Size(41, 20);
            this.pnltitlebarleftcornercolour.TabIndex = 8;
            this.pnltitlebarleftcornercolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetLeftCornerColor);
            // 
            // lbrightcornercolor
            // 
            this.lbrightcornercolor.AutoSize = true;
            this.lbrightcornercolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrightcornercolor.Location = new System.Drawing.Point(3, 81);
            this.lbrightcornercolor.Name = "lbrightcornercolor";
            this.lbrightcornercolor.Size = new System.Drawing.Size(127, 16);
            this.lbrightcornercolor.TabIndex = 9;
            this.lbrightcornercolor.Text = "Right Corner Colour:";
            // 
            // lbleftcornercolor
            // 
            this.lbleftcornercolor.AutoSize = true;
            this.lbleftcornercolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleftcornercolor.Location = new System.Drawing.Point(3, 57);
            this.lbleftcornercolor.Name = "lbleftcornercolor";
            this.lbleftcornercolor.Size = new System.Drawing.Size(117, 16);
            this.lbleftcornercolor.TabIndex = 7;
            this.lbleftcornercolor.Text = "Left Corner Colour:";
            // 
            // cboxtitlebarcorners
            // 
            this.cboxtitlebarcorners.AutoSize = true;
            this.cboxtitlebarcorners.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxtitlebarcorners.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.cboxtitlebarcorners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxtitlebarcorners.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cboxtitlebarcorners.Location = new System.Drawing.Point(166, 4);
            this.cboxtitlebarcorners.Name = "cboxtitlebarcorners";
            this.cboxtitlebarcorners.Size = new System.Drawing.Size(131, 21);
            this.cboxtitlebarcorners.TabIndex = 6;
            this.cboxtitlebarcorners.Text = "Title Bar Corners";
            this.cboxtitlebarcorners.UseVisualStyleBackColor = true;
            this.cboxtitlebarcorners.CheckedChanged += new System.EventHandler(this.cboxtitlebarcorners_CheckedChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(136, 32);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(22, 16);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "px";
            // 
            // txttitlebarheight
            // 
            this.txttitlebarheight.BackColor = System.Drawing.Color.White;
            this.txttitlebarheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitlebarheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitlebarheight.ForeColor = System.Drawing.Color.Black;
            this.txttitlebarheight.Location = new System.Drawing.Point(112, 30);
            this.txttitlebarheight.Name = "txttitlebarheight";
            this.txttitlebarheight.Size = new System.Drawing.Size(23, 22);
            this.txttitlebarheight.TabIndex = 4;
            this.txttitlebarheight.TextChanged += new System.EventHandler(this.txttitlebarheight_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(3, 32);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(103, 16);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Title Bar Height:";
            // 
            // pnltitlebarcolour
            // 
            this.pnltitlebarcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnltitlebarcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltitlebarcolour.Location = new System.Drawing.Point(112, 5);
            this.pnltitlebarcolour.Name = "pnltitlebarcolour";
            this.pnltitlebarcolour.Size = new System.Drawing.Size(41, 20);
            this.pnltitlebarcolour.TabIndex = 1;
            this.pnltitlebarcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetTitlebarColor);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 7);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Title Bar Colour:";
            // 
            // pnlborderoptions
            // 
            this.pnlborderoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlborderoptions.Controls.Add(this.cbindividualbordercolours);
            this.pnlborderoptions.Controls.Add(this.pnlborderbottomrightcolour);
            this.pnlborderoptions.Controls.Add(this.lbbright);
            this.pnlborderoptions.Controls.Add(this.pnlborderbottomcolour);
            this.pnlborderoptions.Controls.Add(this.lbbottom);
            this.pnlborderoptions.Controls.Add(this.pnlborderbottomleftcolour);
            this.pnlborderoptions.Controls.Add(this.lbbleft);
            this.pnlborderoptions.Controls.Add(this.pnlborderrightcolour);
            this.pnlborderoptions.Controls.Add(this.lbright);
            this.pnlborderoptions.Controls.Add(this.pnlborderleftcolour);
            this.pnlborderoptions.Controls.Add(this.lbleft);
            this.pnlborderoptions.Controls.Add(this.Label15);
            this.pnlborderoptions.Controls.Add(this.pnlbordercolour);
            this.pnlborderoptions.Controls.Add(this.txtbordersize);
            this.pnlborderoptions.Controls.Add(this.Label3);
            this.pnlborderoptions.Controls.Add(this.Label16);
            this.pnlborderoptions.Location = new System.Drawing.Point(135, 159);
            this.pnlborderoptions.Name = "pnlborderoptions";
            this.pnlborderoptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlborderoptions.Size = new System.Drawing.Size(325, 139);
            this.pnlborderoptions.TabIndex = 10;
            this.pnlborderoptions.Visible = false;
            // 
            // cbindividualbordercolours
            // 
            this.cbindividualbordercolours.AutoSize = true;
            this.cbindividualbordercolours.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cbindividualbordercolours.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.cbindividualbordercolours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbindividualbordercolours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cbindividualbordercolours.Location = new System.Drawing.Point(161, 4);
            this.cbindividualbordercolours.Name = "cbindividualbordercolours";
            this.cbindividualbordercolours.Size = new System.Drawing.Size(135, 21);
            this.cbindividualbordercolours.TabIndex = 28;
            this.cbindividualbordercolours.Text = "Individual Colours";
            this.cbindividualbordercolours.UseVisualStyleBackColor = true;
            this.cbindividualbordercolours.CheckedChanged += new System.EventHandler(this.cbindividualbordercolours_CheckedChanged);
            // 
            // pnlborderbottomrightcolour
            // 
            this.pnlborderbottomrightcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlborderbottomrightcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborderbottomrightcolour.Location = new System.Drawing.Point(132, 101);
            this.pnlborderbottomrightcolour.Name = "pnlborderbottomrightcolour";
            this.pnlborderbottomrightcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlborderbottomrightcolour.TabIndex = 27;
            this.pnlborderbottomrightcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetBottomRBorderColor);
            // 
            // lbbright
            // 
            this.lbbright.AutoSize = true;
            this.lbbright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbright.Location = new System.Drawing.Point(3, 103);
            this.lbbright.Name = "lbbright";
            this.lbbright.Size = new System.Drawing.Size(129, 16);
            this.lbbright.TabIndex = 26;
            this.lbbright.Text = "Bottom Right Colour:";
            // 
            // pnlborderbottomcolour
            // 
            this.pnlborderbottomcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlborderbottomcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborderbottomcolour.Location = new System.Drawing.Point(263, 31);
            this.pnlborderbottomcolour.Name = "pnlborderbottomcolour";
            this.pnlborderbottomcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlborderbottomcolour.TabIndex = 25;
            this.pnlborderbottomcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetBottomBorderColor);
            // 
            // lbbottom
            // 
            this.lbbottom.AutoSize = true;
            this.lbbottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbottom.Location = new System.Drawing.Point(158, 32);
            this.lbbottom.Name = "lbbottom";
            this.lbbottom.Size = new System.Drawing.Size(95, 16);
            this.lbbottom.TabIndex = 24;
            this.lbbottom.Text = "Bottom Colour:";
            // 
            // pnlborderbottomleftcolour
            // 
            this.pnlborderbottomleftcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlborderbottomleftcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborderbottomleftcolour.Location = new System.Drawing.Point(124, 78);
            this.pnlborderbottomleftcolour.Name = "pnlborderbottomleftcolour";
            this.pnlborderbottomleftcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlborderbottomleftcolour.TabIndex = 23;
            this.pnlborderbottomleftcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetBottomLColor);
            // 
            // lbbleft
            // 
            this.lbbleft.AutoSize = true;
            this.lbbleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbleft.Location = new System.Drawing.Point(3, 80);
            this.lbbleft.Name = "lbbleft";
            this.lbbleft.Size = new System.Drawing.Size(119, 16);
            this.lbbleft.TabIndex = 22;
            this.lbbleft.Text = "Bottom Left Colour:";
            // 
            // pnlborderrightcolour
            // 
            this.pnlborderrightcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlborderrightcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborderrightcolour.Location = new System.Drawing.Point(263, 54);
            this.pnlborderrightcolour.Name = "pnlborderrightcolour";
            this.pnlborderrightcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlborderrightcolour.TabIndex = 21;
            this.pnlborderrightcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetRightBorderColor);
            // 
            // lbright
            // 
            this.lbright.AutoSize = true;
            this.lbright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbright.Location = new System.Drawing.Point(157, 56);
            this.lbright.Name = "lbright";
            this.lbright.Size = new System.Drawing.Size(84, 16);
            this.lbright.TabIndex = 20;
            this.lbright.Text = "Right Colour:";
            // 
            // pnlborderleftcolour
            // 
            this.pnlborderleftcolour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlborderleftcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborderleftcolour.Location = new System.Drawing.Point(102, 54);
            this.pnlborderleftcolour.Name = "pnlborderleftcolour";
            this.pnlborderleftcolour.Size = new System.Drawing.Size(41, 20);
            this.pnlborderleftcolour.TabIndex = 19;
            this.pnlborderleftcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetLeftBorderColor);
            // 
            // lbleft
            // 
            this.lbleft.AutoSize = true;
            this.lbleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleft.Location = new System.Drawing.Point(3, 56);
            this.lbleft.Name = "lbleft";
            this.lbleft.Size = new System.Drawing.Size(74, 16);
            this.lbleft.TabIndex = 18;
            this.lbleft.Text = "Left Colour:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(126, 31);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(22, 16);
            this.Label15.TabIndex = 17;
            this.Label15.Text = "px";
            // 
            // pnlbordercolour
            // 
            this.pnlbordercolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbordercolour.Location = new System.Drawing.Point(102, 5);
            this.pnlbordercolour.Name = "pnlbordercolour";
            this.pnlbordercolour.Size = new System.Drawing.Size(41, 20);
            this.pnlbordercolour.TabIndex = 3;
            this.pnlbordercolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetMainBorderColor);
            // 
            // txtbordersize
            // 
            this.txtbordersize.BackColor = System.Drawing.Color.White;
            this.txtbordersize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbordersize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbordersize.ForeColor = System.Drawing.Color.Black;
            this.txtbordersize.Location = new System.Drawing.Point(102, 29);
            this.txtbordersize.Name = "txtbordersize";
            this.txtbordersize.Size = new System.Drawing.Size(23, 22);
            this.txtbordersize.TabIndex = 16;
            this.txtbordersize.TextChanged += new System.EventHandler(this.txtbordersize_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(3, 7);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(94, 16);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Border Colour:";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(3, 31);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(81, 16);
            this.Label16.TabIndex = 15;
            this.Label16.Text = "Border Size:";
            // 
            // pnltitletextoptions
            // 
            this.pnltitletextoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnltitletextoptions.Controls.Add(this.combotitletextposition);
            this.pnltitletextoptions.Controls.Add(this.Label53);
            this.pnltitletextoptions.Controls.Add(this.combotitletextstyle);
            this.pnltitletextoptions.Controls.Add(this.combotitletextfont);
            this.pnltitletextoptions.Controls.Add(this.Label23);
            this.pnltitletextoptions.Controls.Add(this.Label17);
            this.pnltitletextoptions.Controls.Add(this.txttitletextside);
            this.pnltitletextoptions.Controls.Add(this.Label18);
            this.pnltitletextoptions.Controls.Add(this.Label19);
            this.pnltitletextoptions.Controls.Add(this.txttitletexttop);
            this.pnltitletextoptions.Controls.Add(this.Label20);
            this.pnltitletextoptions.Controls.Add(this.Label21);
            this.pnltitletextoptions.Controls.Add(this.txttitletextsize);
            this.pnltitletextoptions.Controls.Add(this.Label22);
            this.pnltitletextoptions.Controls.Add(this.Label24);
            this.pnltitletextoptions.Controls.Add(this.pnltitletextcolour);
            this.pnltitletextoptions.Controls.Add(this.Label25);
            this.pnltitletextoptions.Location = new System.Drawing.Point(135, 159);
            this.pnltitletextoptions.Name = "pnltitletextoptions";
            this.pnltitletextoptions.Size = new System.Drawing.Size(325, 139);
            this.pnltitletextoptions.TabIndex = 15;
            this.pnltitletextoptions.Visible = false;
            // 
            // combotitletextposition
            // 
            this.combotitletextposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotitletextposition.FormattingEnabled = true;
            this.combotitletextposition.Items.AddRange(new object[] {
            "Left",
            "Centre"});
            this.combotitletextposition.Location = new System.Drawing.Point(211, 54);
            this.combotitletextposition.Name = "combotitletextposition";
            this.combotitletextposition.Size = new System.Drawing.Size(95, 24);
            this.combotitletextposition.TabIndex = 21;
            this.combotitletextposition.SelectedIndexChanged += new System.EventHandler(this.combotitletextposition_SelectedIndexChanged);
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label53.Location = new System.Drawing.Point(149, 57);
            this.Label53.Name = "Label53";
            this.Label53.Size = new System.Drawing.Size(59, 16);
            this.Label53.TabIndex = 20;
            this.Label53.Text = "Position:";
            // 
            // combotitletextstyle
            // 
            this.combotitletextstyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotitletextstyle.FormattingEnabled = true;
            this.combotitletextstyle.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Strikeout",
            "Underline"});
            this.combotitletextstyle.Location = new System.Drawing.Point(207, 3);
            this.combotitletextstyle.Name = "combotitletextstyle";
            this.combotitletextstyle.Size = new System.Drawing.Size(99, 24);
            this.combotitletextstyle.TabIndex = 18;
            this.combotitletextstyle.SelectedIndexChanged += new System.EventHandler(this.combotitletextstyle_SelectedIndexChanged);
            // 
            // combotitletextfont
            // 
            this.combotitletextfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotitletextfont.FormattingEnabled = true;
            this.combotitletextfont.Location = new System.Drawing.Point(100, 30);
            this.combotitletextfont.Name = "combotitletextfont";
            this.combotitletextfont.Size = new System.Drawing.Size(202, 24);
            this.combotitletextfont.TabIndex = 17;
            this.combotitletextfont.SelectedIndexChanged += new System.EventHandler(this.combotitletextfont_SelectedIndexChanged);
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.Location = new System.Drawing.Point(164, 7);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(41, 16);
            this.Label23.TabIndex = 15;
            this.Label23.Text = "Style:";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(159, 107);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(22, 16);
            this.Label17.TabIndex = 14;
            this.Label17.Text = "px";
            // 
            // txttitletextside
            // 
            this.txttitletextside.BackColor = System.Drawing.Color.White;
            this.txttitletextside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitletextside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitletextside.ForeColor = System.Drawing.Color.Black;
            this.txttitletextside.Location = new System.Drawing.Point(135, 105);
            this.txttitletextside.Name = "txttitletextside";
            this.txttitletextside.Size = new System.Drawing.Size(23, 22);
            this.txttitletextside.TabIndex = 13;
            this.txttitletextside.TextChanged += new System.EventHandler(this.txttitletextside_TextChanged);
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(3, 107);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(131, 16);
            this.Label18.TabIndex = 12;
            this.Label18.Text = "Title Text From Side:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(159, 82);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(22, 16);
            this.Label19.TabIndex = 11;
            this.Label19.Text = "px";
            // 
            // txttitletexttop
            // 
            this.txttitletexttop.BackColor = System.Drawing.Color.White;
            this.txttitletexttop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitletexttop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitletexttop.ForeColor = System.Drawing.Color.Black;
            this.txttitletexttop.Location = new System.Drawing.Point(135, 80);
            this.txttitletexttop.Name = "txttitletexttop";
            this.txttitletexttop.Size = new System.Drawing.Size(23, 22);
            this.txttitletexttop.TabIndex = 10;
            this.txttitletexttop.TextChanged += new System.EventHandler(this.txttitletexttop_TextChanged);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(3, 82);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(128, 16);
            this.Label20.TabIndex = 9;
            this.Label20.Text = "Title Text From Top:";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.Location = new System.Drawing.Point(124, 57);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(22, 16);
            this.Label21.TabIndex = 8;
            this.Label21.Text = "px";
            // 
            // txttitletextsize
            // 
            this.txttitletextsize.BackColor = System.Drawing.Color.White;
            this.txttitletextsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitletextsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitletextsize.ForeColor = System.Drawing.Color.Black;
            this.txttitletextsize.Location = new System.Drawing.Point(100, 55);
            this.txttitletextsize.Name = "txttitletextsize";
            this.txttitletextsize.Size = new System.Drawing.Size(23, 22);
            this.txttitletextsize.TabIndex = 7;
            this.txttitletextsize.TextChanged += new System.EventHandler(this.txttitletextsize_TextChanged);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.Location = new System.Drawing.Point(3, 57);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(95, 16);
            this.Label22.TabIndex = 6;
            this.Label22.Text = "Title Text Size:";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.Location = new System.Drawing.Point(3, 33);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(95, 16);
            this.Label24.TabIndex = 2;
            this.Label24.Text = "Title Text Font:";
            // 
            // pnltitletextcolour
            // 
            this.pnltitletextcolour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltitletextcolour.Location = new System.Drawing.Point(114, 5);
            this.pnltitletextcolour.Name = "pnltitletextcolour";
            this.pnltitletextcolour.Size = new System.Drawing.Size(41, 20);
            this.pnltitletextcolour.TabIndex = 1;
            this.pnltitletextcolour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetTitleTextColor);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label25.Location = new System.Drawing.Point(3, 7);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(108, 16);
            this.Label25.TabIndex = 0;
            this.Label25.Text = "Title Text Colour:";
            // 
            // pnlwindowsobjects
            // 
            this.pnlwindowsobjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlwindowsobjects.Controls.Add(this.btnborders);
            this.pnlwindowsobjects.Controls.Add(this.btnbuttons);
            this.pnlwindowsobjects.Controls.Add(this.btntitletext);
            this.pnlwindowsobjects.Controls.Add(this.btntitlebar);
            this.pnlwindowsobjects.Location = new System.Drawing.Point(1, 159);
            this.pnlwindowsobjects.Name = "pnlwindowsobjects";
            this.pnlwindowsobjects.Size = new System.Drawing.Size(128, 135);
            this.pnlwindowsobjects.TabIndex = 8;
            // 
            // btnborders
            // 
            this.btnborders.BackColor = System.Drawing.Color.White;
            this.btnborders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnborders.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnborders.Location = new System.Drawing.Point(4, 105);
            this.btnborders.Name = "btnborders";
            this.btnborders.Size = new System.Drawing.Size(119, 29);
            this.btnborders.TabIndex = 7;
            this.btnborders.TabStop = false;
            this.btnborders.Text = "Borders";
            this.btnborders.UseVisualStyleBackColor = false;
            this.btnborders.Click += new System.EventHandler(this.btnborders_Click);
            // 
            // btnbuttons
            // 
            this.btnbuttons.BackColor = System.Drawing.Color.White;
            this.btnbuttons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuttons.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuttons.Location = new System.Drawing.Point(4, 70);
            this.btnbuttons.Name = "btnbuttons";
            this.btnbuttons.Size = new System.Drawing.Size(119, 29);
            this.btnbuttons.TabIndex = 6;
            this.btnbuttons.TabStop = false;
            this.btnbuttons.Text = "Buttons";
            this.btnbuttons.UseVisualStyleBackColor = false;
            this.btnbuttons.Click += new System.EventHandler(this.btnbuttons_Click);
            // 
            // btntitletext
            // 
            this.btntitletext.BackColor = System.Drawing.Color.White;
            this.btntitletext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntitletext.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntitletext.Location = new System.Drawing.Point(4, 35);
            this.btntitletext.Name = "btntitletext";
            this.btntitletext.Size = new System.Drawing.Size(119, 29);
            this.btntitletext.TabIndex = 5;
            this.btntitletext.TabStop = false;
            this.btntitletext.Text = "Title Text";
            this.btntitletext.UseVisualStyleBackColor = false;
            this.btntitletext.Click += new System.EventHandler(this.btntitletext_Click_1);
            // 
            // btntitlebar
            // 
            this.btntitlebar.BackColor = System.Drawing.Color.White;
            this.btntitlebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntitlebar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntitlebar.Location = new System.Drawing.Point(4, 0);
            this.btntitlebar.Name = "btntitlebar";
            this.btntitlebar.Size = new System.Drawing.Size(119, 29);
            this.btntitlebar.TabIndex = 4;
            this.btntitlebar.TabStop = false;
            this.btntitlebar.Text = "Title Bar";
            this.btntitlebar.UseVisualStyleBackColor = false;
            this.btntitlebar.Click += new System.EventHandler(this.btntitlebar_Click);
            // 
            // pnlwindowpreview
            // 
            this.pnlwindowpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlwindowpreview.Controls.Add(this.prepgcontent);
            this.pnlwindowpreview.Controls.Add(this.prepgbottom);
            this.pnlwindowpreview.Controls.Add(this.prepgleft);
            this.pnlwindowpreview.Controls.Add(this.prepgright);
            this.pnlwindowpreview.Controls.Add(this.pretitlebar);
            this.pnlwindowpreview.Location = new System.Drawing.Point(5, 3);
            this.pnlwindowpreview.Name = "pnlwindowpreview";
            this.pnlwindowpreview.Size = new System.Drawing.Size(448, 148);
            this.pnlwindowpreview.TabIndex = 0;
            // 
            // prepgcontent
            // 
            this.prepgcontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prepgcontent.Location = new System.Drawing.Point(2, 30);
            this.prepgcontent.Name = "prepgcontent";
            this.prepgcontent.Size = new System.Drawing.Size(444, 116);
            this.prepgcontent.TabIndex = 20;
            // 
            // prepgbottom
            // 
            this.prepgbottom.BackColor = System.Drawing.Color.Gray;
            this.prepgbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prepgbottom.Location = new System.Drawing.Point(2, 146);
            this.prepgbottom.Name = "prepgbottom";
            this.prepgbottom.Size = new System.Drawing.Size(444, 2);
            this.prepgbottom.TabIndex = 23;
            // 
            // prepgleft
            // 
            this.prepgleft.BackColor = System.Drawing.Color.Gray;
            this.prepgleft.Controls.Add(this.prepgbottomlcorner);
            this.prepgleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.prepgleft.Location = new System.Drawing.Point(0, 30);
            this.prepgleft.Name = "prepgleft";
            this.prepgleft.Size = new System.Drawing.Size(2, 118);
            this.prepgleft.TabIndex = 21;
            // 
            // prepgbottomlcorner
            // 
            this.prepgbottomlcorner.BackColor = System.Drawing.Color.Red;
            this.prepgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prepgbottomlcorner.Location = new System.Drawing.Point(0, 116);
            this.prepgbottomlcorner.Name = "prepgbottomlcorner";
            this.prepgbottomlcorner.Size = new System.Drawing.Size(2, 2);
            this.prepgbottomlcorner.TabIndex = 14;
            // 
            // prepgright
            // 
            this.prepgright.BackColor = System.Drawing.Color.Gray;
            this.prepgright.Controls.Add(this.prepgbottomrcorner);
            this.prepgright.Dock = System.Windows.Forms.DockStyle.Right;
            this.prepgright.Location = new System.Drawing.Point(446, 30);
            this.prepgright.Name = "prepgright";
            this.prepgright.Size = new System.Drawing.Size(2, 118);
            this.prepgright.TabIndex = 22;
            // 
            // prepgbottomrcorner
            // 
            this.prepgbottomrcorner.BackColor = System.Drawing.Color.Red;
            this.prepgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prepgbottomrcorner.Location = new System.Drawing.Point(0, 116);
            this.prepgbottomrcorner.Name = "prepgbottomrcorner";
            this.prepgbottomrcorner.Size = new System.Drawing.Size(2, 2);
            this.prepgbottomrcorner.TabIndex = 15;
            // 
            // pretitlebar
            // 
            this.pretitlebar.BackColor = System.Drawing.Color.Gray;
            this.pretitlebar.Controls.Add(this.preminimizebutton);
            this.pretitlebar.Controls.Add(this.prepnlicon);
            this.pretitlebar.Controls.Add(this.prerollupbutton);
            this.pretitlebar.Controls.Add(this.preclosebutton);
            this.pretitlebar.Controls.Add(this.pretitletext);
            this.pretitlebar.Controls.Add(this.prepgtoplcorner);
            this.pretitlebar.Controls.Add(this.prepgtoprcorner);
            this.pretitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pretitlebar.ForeColor = System.Drawing.Color.White;
            this.pretitlebar.Location = new System.Drawing.Point(0, 0);
            this.pretitlebar.Name = "pretitlebar";
            this.pretitlebar.Size = new System.Drawing.Size(448, 30);
            this.pretitlebar.TabIndex = 19;
            // 
            // preminimizebutton
            // 
            this.preminimizebutton.BackColor = System.Drawing.Color.Black;
            this.preminimizebutton.Location = new System.Drawing.Point(185, 5);
            this.preminimizebutton.Name = "preminimizebutton";
            this.preminimizebutton.Size = new System.Drawing.Size(22, 22);
            this.preminimizebutton.TabIndex = 31;
            // 
            // prepnlicon
            // 
            this.prepnlicon.BackColor = System.Drawing.Color.Transparent;
            this.prepnlicon.Location = new System.Drawing.Point(8, 8);
            this.prepnlicon.Name = "prepnlicon";
            this.prepnlicon.Size = new System.Drawing.Size(16, 16);
            this.prepnlicon.TabIndex = 32;
            this.prepnlicon.TabStop = false;
            this.prepnlicon.Visible = false;
            // 
            // prerollupbutton
            // 
            this.prerollupbutton.BackColor = System.Drawing.Color.Black;
            this.prerollupbutton.Location = new System.Drawing.Point(213, 5);
            this.prerollupbutton.Name = "prerollupbutton";
            this.prerollupbutton.Size = new System.Drawing.Size(22, 22);
            this.prerollupbutton.TabIndex = 31;
            // 
            // preclosebutton
            // 
            this.preclosebutton.BackColor = System.Drawing.Color.Black;
            this.preclosebutton.Location = new System.Drawing.Point(251, 5);
            this.preclosebutton.Name = "preclosebutton";
            this.preclosebutton.Size = new System.Drawing.Size(22, 22);
            this.preclosebutton.TabIndex = 20;
            // 
            // pretitletext
            // 
            this.pretitletext.AutoSize = true;
            this.pretitletext.BackColor = System.Drawing.Color.Transparent;
            this.pretitletext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretitletext.Location = new System.Drawing.Point(29, 7);
            this.pretitletext.Name = "pretitletext";
            this.pretitletext.Size = new System.Drawing.Size(77, 18);
            this.pretitletext.TabIndex = 19;
            this.pretitletext.Text = "Template";
            // 
            // prepgtoplcorner
            // 
            this.prepgtoplcorner.BackColor = System.Drawing.Color.Red;
            this.prepgtoplcorner.Dock = System.Windows.Forms.DockStyle.Left;
            this.prepgtoplcorner.Location = new System.Drawing.Point(0, 0);
            this.prepgtoplcorner.Name = "prepgtoplcorner";
            this.prepgtoplcorner.Size = new System.Drawing.Size(2, 30);
            this.prepgtoplcorner.TabIndex = 17;
            // 
            // prepgtoprcorner
            // 
            this.prepgtoprcorner.BackColor = System.Drawing.Color.Red;
            this.prepgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right;
            this.prepgtoprcorner.Location = new System.Drawing.Point(446, 0);
            this.prepgtoprcorner.Name = "prepgtoprcorner";
            this.prepgtoprcorner.Size = new System.Drawing.Size(2, 30);
            this.prepgtoprcorner.TabIndex = 16;
            // 
            // pnlreset
            // 
            this.pnlreset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlreset.Controls.Add(this.Label113);
            this.pnlreset.Controls.Add(this.btnresetallsettings);
            this.pnlreset.Controls.Add(this.Label109);
            this.pnlreset.Controls.Add(this.Label111);
            this.pnlreset.Location = new System.Drawing.Point(134, 9);
            this.pnlreset.Name = "pnlreset";
            this.pnlreset.Size = new System.Drawing.Size(457, 306);
            this.pnlreset.TabIndex = 18;
            // 
            // Label113
            // 
            this.Label113.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label113.Location = new System.Drawing.Point(57, 231);
            this.Label113.Name = "Label113";
            this.Label113.Size = new System.Drawing.Size(332, 33);
            this.Label113.TabIndex = 5;
            this.Label113.Text = "Warning! A Global Reset Is Irreversible!";
            this.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnresetallsettings
            // 
            this.btnresetallsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnresetallsettings.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnresetallsettings.Location = new System.Drawing.Point(101, 145);
            this.btnresetallsettings.Name = "btnresetallsettings";
            this.btnresetallsettings.Size = new System.Drawing.Size(255, 83);
            this.btnresetallsettings.TabIndex = 4;
            this.btnresetallsettings.TabStop = false;
            this.btnresetallsettings.Text = "Reset All Settings";
            this.btnresetallsettings.UseVisualStyleBackColor = true;
            this.btnresetallsettings.Click += new System.EventHandler(this.btnresetallsettings_Click);
            // 
            // Label109
            // 
            this.Label109.BackColor = System.Drawing.Color.Transparent;
            this.Label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label109.Location = new System.Drawing.Point(4, 40);
            this.Label109.Name = "Label109";
            this.Label109.Size = new System.Drawing.Size(451, 66);
            this.Label109.TabIndex = 3;
            this.Label109.Text = resources.GetString("Label109.Text");
            this.Label109.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label111
            // 
            this.Label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label111.Location = new System.Drawing.Point(68, 4);
            this.Label111.Name = "Label111";
            this.Label111.Size = new System.Drawing.Size(332, 33);
            this.Label111.TabIndex = 2;
            this.Label111.Text = "Global Settings Reset!";
            this.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.pnldesktopcomposition);
            this.pgcontents.Controls.Add(this.pnldesktopoptions);
            this.pgcontents.Controls.Add(this.pnlreset);
            this.pgcontents.Controls.Add(this.pnlwindowsoptions);
            this.pgcontents.Controls.Add(this.pnlmenus);
            this.pgcontents.Controls.Add(this.pnlshifterintro);
            this.pgcontents.Controls.Add(this.catholder);
            this.pgcontents.Controls.Add(this.btnapply);
            this.pgcontents.Controls.Add(this.Label1);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(600, 323);
            this.pgcontents.TabIndex = 0;
            // 
            // pnldesktopcomposition
            // 
            this.pnldesktopcomposition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldesktopcomposition.BackColor = System.Drawing.Color.White;
            this.pnldesktopcomposition.Controls.Add(this.pnlfancywindows);
            this.pnldesktopcomposition.Controls.Add(this.pnlfancydragging);
            this.pnldesktopcomposition.Controls.Add(this.pnlfancyintro);
            this.pnldesktopcomposition.Controls.Add(this.panel18);
            this.pnldesktopcomposition.Controls.Add(this.panel25);
            this.pnldesktopcomposition.Controls.Add(this.panel36);
            this.pnldesktopcomposition.Controls.Add(this.label176);
            this.pnldesktopcomposition.Location = new System.Drawing.Point(134, 9);
            this.pnldesktopcomposition.Name = "pnldesktopcomposition";
            this.pnldesktopcomposition.Size = new System.Drawing.Size(457, 306);
            this.pnldesktopcomposition.TabIndex = 20;
            // 
            // pnlfancywindows
            // 
            this.pnlfancywindows.Controls.Add(this.txtwinfadedec);
            this.pnlfancywindows.Controls.Add(this.label150);
            this.pnlfancywindows.Controls.Add(this.txtwinfadespeed);
            this.pnlfancywindows.Controls.Add(this.label151);
            this.pnlfancywindows.Controls.Add(this.cbdrageffect);
            this.pnlfancywindows.Controls.Add(this.label141);
            this.pnlfancywindows.Controls.Add(this.cbcloseanim);
            this.pnlfancywindows.Controls.Add(this.label128);
            this.pnlfancywindows.Controls.Add(this.cbopenanim);
            this.pnlfancywindows.Controls.Add(this.label127);
            this.pnlfancywindows.Controls.Add(this.label149);
            this.pnlfancywindows.Location = new System.Drawing.Point(139, 43);
            this.pnlfancywindows.Name = "pnlfancywindows";
            this.pnlfancywindows.Size = new System.Drawing.Size(311, 256);
            this.pnlfancywindows.TabIndex = 13;
            // 
            // txtwinfadedec
            // 
            this.txtwinfadedec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtwinfadedec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtwinfadedec.Location = new System.Drawing.Point(225, 189);
            this.txtwinfadedec.Name = "txtwinfadedec";
            this.txtwinfadedec.Size = new System.Drawing.Size(35, 23);
            this.txtwinfadedec.TabIndex = 26;
            this.txtwinfadedec.TextChanged += new System.EventHandler(this.txtwinfadedec_TextChanged);
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.Location = new System.Drawing.Point(153, 191);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(71, 16);
            this.label150.TabIndex = 25;
            this.label150.Text = "Fade Dec.";
            // 
            // txtwinfadespeed
            // 
            this.txtwinfadespeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtwinfadespeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtwinfadespeed.Location = new System.Drawing.Point(109, 185);
            this.txtwinfadespeed.Name = "txtwinfadespeed";
            this.txtwinfadespeed.Size = new System.Drawing.Size(35, 23);
            this.txtwinfadespeed.TabIndex = 24;
            this.txtwinfadespeed.TextChanged += new System.EventHandler(this.txtwinfadespeed_TextChanged);
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(13, 189);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(84, 16);
            this.label151.TabIndex = 23;
            this.label151.Text = "Fade Speed";
            // 
            // cbdrageffect
            // 
            this.cbdrageffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbdrageffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdrageffect.FormattingEnabled = true;
            this.cbdrageffect.Location = new System.Drawing.Point(6, 153);
            this.cbdrageffect.Name = "cbdrageffect";
            this.cbdrageffect.Size = new System.Drawing.Size(294, 21);
            this.cbdrageffect.TabIndex = 22;
            this.cbdrageffect.SelectedIndexChanged += new System.EventHandler(this.cbdrageffect_SelectedIndexChanged);
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(7, 132);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(125, 16);
            this.label141.TabIndex = 21;
            this.label141.Text = "Window Drag Effect";
            // 
            // cbcloseanim
            // 
            this.cbcloseanim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbcloseanim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcloseanim.FormattingEnabled = true;
            this.cbcloseanim.Location = new System.Drawing.Point(8, 102);
            this.cbcloseanim.Name = "cbcloseanim";
            this.cbcloseanim.Size = new System.Drawing.Size(294, 21);
            this.cbcloseanim.TabIndex = 20;
            this.cbcloseanim.SelectedIndexChanged += new System.EventHandler(this.cbcloseanim_SelectedIndexChanged);
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(9, 81);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(156, 16);
            this.label128.TabIndex = 19;
            this.label128.Text = "Window Close Animation";
            // 
            // cbopenanim
            // 
            this.cbopenanim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbopenanim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopenanim.FormattingEnabled = true;
            this.cbopenanim.Location = new System.Drawing.Point(9, 50);
            this.cbopenanim.Name = "cbopenanim";
            this.cbopenanim.Size = new System.Drawing.Size(294, 21);
            this.cbopenanim.TabIndex = 18;
            this.cbopenanim.SelectedIndexChanged += new System.EventHandler(this.cbopenanim_SelectedIndexChanged);
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(10, 29);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(154, 16);
            this.label127.TabIndex = 17;
            this.label127.Text = "Window Open Animation";
            // 
            // label149
            // 
            this.label149.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label149.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label149.Location = new System.Drawing.Point(6, 0);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(301, 29);
            this.label149.TabIndex = 1;
            this.label149.Text = "Animations";
            this.label149.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlfancydragging
            // 
            this.pnlfancydragging.Controls.Add(this.txtshakeminoffset);
            this.pnlfancydragging.Controls.Add(this.label148);
            this.pnlfancydragging.Controls.Add(this.txtshakemax);
            this.pnlfancydragging.Controls.Add(this.label146);
            this.pnlfancydragging.Controls.Add(this.txtdragopacitydec);
            this.pnlfancydragging.Controls.Add(this.label144);
            this.pnlfancydragging.Controls.Add(this.txtdragfadedec);
            this.pnlfancydragging.Controls.Add(this.label143);
            this.pnlfancydragging.Controls.Add(this.txtfadespeed);
            this.pnlfancydragging.Controls.Add(this.label155);
            this.pnlfancydragging.Controls.Add(this.label156);
            this.pnlfancydragging.Location = new System.Drawing.Point(139, 43);
            this.pnlfancydragging.Name = "pnlfancydragging";
            this.pnlfancydragging.Size = new System.Drawing.Size(311, 256);
            this.pnlfancydragging.TabIndex = 14;
            // 
            // txtshakeminoffset
            // 
            this.txtshakeminoffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtshakeminoffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtshakeminoffset.Location = new System.Drawing.Point(167, 189);
            this.txtshakeminoffset.Name = "txtshakeminoffset";
            this.txtshakeminoffset.Size = new System.Drawing.Size(35, 23);
            this.txtshakeminoffset.TabIndex = 13;
            this.txtshakeminoffset.TextChanged += new System.EventHandler(this.txtshakeminoffset_TextChanged);
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(17, 192);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(140, 16);
            this.label148.TabIndex = 12;
            this.label148.Text = "Shake Minimum Offset";
            // 
            // txtshakemax
            // 
            this.txtshakemax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtshakemax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtshakemax.Location = new System.Drawing.Point(167, 159);
            this.txtshakemax.Name = "txtshakemax";
            this.txtshakemax.Size = new System.Drawing.Size(35, 23);
            this.txtshakemax.TabIndex = 11;
            this.txtshakemax.TextChanged += new System.EventHandler(this.txtshakemax_TextChanged);
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.Location = new System.Drawing.Point(17, 162);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(144, 16);
            this.label146.TabIndex = 10;
            this.label146.Text = "Shake Maximum Offset";
            // 
            // txtdragopacitydec
            // 
            this.txtdragopacitydec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdragopacitydec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtdragopacitydec.Location = new System.Drawing.Point(104, 116);
            this.txtdragopacitydec.Name = "txtdragopacitydec";
            this.txtdragopacitydec.Size = new System.Drawing.Size(35, 23);
            this.txtdragopacitydec.TabIndex = 9;
            this.txtdragopacitydec.TextChanged += new System.EventHandler(this.txtdragopacitydec_TextChanged);
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.Location = new System.Drawing.Point(18, 119);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(85, 16);
            this.label144.TabIndex = 8;
            this.label144.Text = "Opacity Dec.";
            // 
            // txtdragfadedec
            // 
            this.txtdragfadedec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdragfadedec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtdragfadedec.Location = new System.Drawing.Point(89, 88);
            this.txtdragfadedec.Name = "txtdragfadedec";
            this.txtdragfadedec.Size = new System.Drawing.Size(35, 23);
            this.txtdragfadedec.TabIndex = 7;
            this.txtdragfadedec.TextChanged += new System.EventHandler(this.txtdragfadedec_TextChanged);
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.Location = new System.Drawing.Point(17, 90);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(71, 16);
            this.label143.TabIndex = 6;
            this.label143.Text = "Fade Dec.";
            // 
            // txtfadespeed
            // 
            this.txtfadespeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfadespeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtfadespeed.Location = new System.Drawing.Point(114, 54);
            this.txtfadespeed.Name = "txtfadespeed";
            this.txtfadespeed.Size = new System.Drawing.Size(35, 23);
            this.txtfadespeed.TabIndex = 5;
            this.txtfadespeed.TextChanged += new System.EventHandler(this.txtfadespeed_TextChanged);
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(18, 58);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(84, 16);
            this.label155.TabIndex = 4;
            this.label155.Text = "Fade Speed";
            // 
            // label156
            // 
            this.label156.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label156.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label156.Location = new System.Drawing.Point(6, 0);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(301, 29);
            this.label156.TabIndex = 1;
            this.label156.Text = "Fancy Dragging";
            this.label156.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlfancyintro
            // 
            this.pnlfancyintro.Controls.Add(this.label174);
            this.pnlfancyintro.Controls.Add(this.label175);
            this.pnlfancyintro.Location = new System.Drawing.Point(139, 43);
            this.pnlfancyintro.Name = "pnlfancyintro";
            this.pnlfancyintro.Size = new System.Drawing.Size(311, 256);
            this.pnlfancyintro.TabIndex = 11;
            // 
            // label174
            // 
            this.label174.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label174.BackColor = System.Drawing.Color.Transparent;
            this.label174.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label174.Location = new System.Drawing.Point(6, 29);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(300, 221);
            this.label174.TabIndex = 4;
            this.label174.Text = "This section allows you to customize various Fancy Effects throughout ShiftOS suc" +
    "h as animations, speeds, etc.\r\n\r\nGo ahead and explore!";
            this.label174.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label175
            // 
            this.label175.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label175.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label175.Location = new System.Drawing.Point(6, 0);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(301, 29);
            this.label175.TabIndex = 1;
            this.label175.Text = "Fancy Effects - Intro";
            this.label175.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.panel19);
            this.panel18.Controls.Add(this.label157);
            this.panel18.Controls.Add(this.panel20);
            this.panel18.Controls.Add(this.label158);
            this.panel18.Controls.Add(this.panel21);
            this.panel18.Controls.Add(this.label159);
            this.panel18.Controls.Add(this.panel22);
            this.panel18.Controls.Add(this.label160);
            this.panel18.Controls.Add(this.panel23);
            this.panel18.Controls.Add(this.label161);
            this.panel18.Controls.Add(this.panel24);
            this.panel18.Controls.Add(this.label162);
            this.panel18.Controls.Add(this.label163);
            this.panel18.Location = new System.Drawing.Point(139, 43);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(311, 256);
            this.panel18.TabIndex = 12;
            // 
            // panel19
            // 
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Location = new System.Drawing.Point(216, 80);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(41, 20);
            this.panel19.TabIndex = 11;
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(167, 81);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(49, 16);
            this.label157.TabIndex = 10;
            this.label157.Text = "Border";
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Location = new System.Drawing.Point(224, 55);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(41, 20);
            this.panel20.TabIndex = 9;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(148, 56);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(76, 16);
            this.label158.TabIndex = 8;
            this.label158.Text = "Margin End";
            // 
            // panel21
            // 
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Location = new System.Drawing.Point(117, 80);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(41, 20);
            this.panel21.TabIndex = 7;
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label159.Location = new System.Drawing.Point(12, 80);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(93, 16);
            this.label159.TabIndex = 6;
            this.label159.Text = "Margin Middle";
            // 
            // panel22
            // 
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Location = new System.Drawing.Point(101, 55);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(41, 20);
            this.panel22.TabIndex = 5;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.Location = new System.Drawing.Point(12, 55);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(87, 16);
            this.label160.TabIndex = 4;
            this.label160.Text = "Margin Begin";
            // 
            // panel23
            // 
            this.panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel23.Location = new System.Drawing.Point(249, 29);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(41, 20);
            this.panel23.TabIndex = 5;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.Location = new System.Drawing.Point(156, 29);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(95, 16);
            this.label161.TabIndex = 4;
            this.label161.Text = "Highlight Color";
            // 
            // panel24
            // 
            this.panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel24.Location = new System.Drawing.Point(115, 29);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(41, 20);
            this.panel24.TabIndex = 3;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label162.Location = new System.Drawing.Point(10, 29);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(104, 16);
            this.label162.TabIndex = 2;
            this.label162.Text = "Highlight Border";
            // 
            // label163
            // 
            this.label163.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label163.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label163.Location = new System.Drawing.Point(6, 0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(301, 29);
            this.label163.TabIndex = 1;
            this.label163.Text = "Drop-Down Menus";
            this.label163.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.panel26);
            this.panel25.Controls.Add(this.label164);
            this.panel25.Controls.Add(this.panel27);
            this.panel25.Controls.Add(this.label165);
            this.panel25.Controls.Add(this.panel28);
            this.panel25.Controls.Add(this.label166);
            this.panel25.Controls.Add(this.panel29);
            this.panel25.Controls.Add(this.label167);
            this.panel25.Controls.Add(this.panel30);
            this.panel25.Controls.Add(this.label168);
            this.panel25.Controls.Add(this.panel31);
            this.panel25.Controls.Add(this.label169);
            this.panel25.Controls.Add(this.panel32);
            this.panel25.Controls.Add(this.label170);
            this.panel25.Controls.Add(this.panel33);
            this.panel25.Controls.Add(this.label171);
            this.panel25.Controls.Add(this.panel34);
            this.panel25.Controls.Add(this.label172);
            this.panel25.Controls.Add(this.label173);
            this.panel25.Location = new System.Drawing.Point(139, 43);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(311, 256);
            this.panel25.TabIndex = 10;
            // 
            // panel26
            // 
            this.panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel26.Location = new System.Drawing.Point(85, 129);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(41, 20);
            this.panel26.TabIndex = 17;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label164.Location = new System.Drawing.Point(11, 131);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(69, 16);
            this.label164.TabIndex = 16;
            this.label164.Text = "Text Color";
            // 
            // panel27
            // 
            this.panel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel27.Location = new System.Drawing.Point(228, 104);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(41, 20);
            this.panel27.TabIndex = 15;
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label165.Location = new System.Drawing.Point(132, 106);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(92, 16);
            this.label165.TabIndex = 14;
            this.label165.Text = "Dropdown BG";
            // 
            // panel28
            // 
            this.panel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel28.Location = new System.Drawing.Point(84, 104);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(41, 20);
            this.panel28.TabIndex = 13;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.Location = new System.Drawing.Point(10, 106);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(72, 16);
            this.label166.TabIndex = 12;
            this.label166.Text = "Status End";
            // 
            // panel29
            // 
            this.panel29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel29.Location = new System.Drawing.Point(254, 81);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(41, 20);
            this.panel29.TabIndex = 11;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.Location = new System.Drawing.Point(169, 81);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(83, 16);
            this.label167.TabIndex = 10;
            this.label167.Text = "Status Begin";
            // 
            // panel30
            // 
            this.panel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel30.Location = new System.Drawing.Point(254, 55);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(41, 20);
            this.panel30.TabIndex = 9;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.Location = new System.Drawing.Point(161, 55);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(87, 16);
            this.label168.TabIndex = 8;
            this.label168.Text = "Tool Bar End";
            // 
            // panel31
            // 
            this.panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel31.Location = new System.Drawing.Point(117, 80);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(41, 20);
            this.panel31.TabIndex = 7;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.Location = new System.Drawing.Point(12, 80);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(104, 16);
            this.label169.TabIndex = 6;
            this.label169.Text = "Tool Bar Middle";
            // 
            // panel32
            // 
            this.panel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel32.Location = new System.Drawing.Point(117, 55);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(41, 20);
            this.panel32.TabIndex = 5;
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.Location = new System.Drawing.Point(12, 55);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(98, 16);
            this.label170.TabIndex = 4;
            this.label170.Text = "Tool Bar Begin";
            // 
            // panel33
            // 
            this.panel33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel33.Location = new System.Drawing.Point(249, 29);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(41, 20);
            this.panel33.TabIndex = 5;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label171.Location = new System.Drawing.Point(156, 29);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(92, 16);
            this.label171.TabIndex = 4;
            this.label171.Text = "Menu Bar End";
            // 
            // panel34
            // 
            this.panel34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel34.Location = new System.Drawing.Point(115, 29);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(41, 20);
            this.panel34.TabIndex = 3;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label172.Location = new System.Drawing.Point(10, 29);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(103, 16);
            this.label172.TabIndex = 2;
            this.label172.Text = "Menu Bar Begin";
            // 
            // label173
            // 
            this.label173.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label173.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label173.Location = new System.Drawing.Point(6, 0);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(301, 29);
            this.label173.TabIndex = 1;
            this.label173.Text = "The Basics";
            this.label173.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel36
            // 
            this.panel36.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel36.Controls.Add(this.btnfancydragging);
            this.panel36.Controls.Add(this.btnfancywindows);
            this.panel36.Location = new System.Drawing.Point(6, 42);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(128, 257);
            this.panel36.TabIndex = 9;
            // 
            // btnfancydragging
            // 
            this.btnfancydragging.BackColor = System.Drawing.Color.White;
            this.btnfancydragging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfancydragging.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfancydragging.Location = new System.Drawing.Point(4, 35);
            this.btnfancydragging.Name = "btnfancydragging";
            this.btnfancydragging.Size = new System.Drawing.Size(119, 29);
            this.btnfancydragging.TabIndex = 5;
            this.btnfancydragging.Text = "Fancy Dragging";
            this.btnfancydragging.UseVisualStyleBackColor = false;
            this.btnfancydragging.Click += new System.EventHandler(this.btnfancydragging_Click);
            // 
            // btnfancywindows
            // 
            this.btnfancywindows.BackColor = System.Drawing.Color.White;
            this.btnfancywindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfancywindows.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfancywindows.Location = new System.Drawing.Point(4, 0);
            this.btnfancywindows.Name = "btnfancywindows";
            this.btnfancywindows.Size = new System.Drawing.Size(119, 29);
            this.btnfancywindows.TabIndex = 4;
            this.btnfancywindows.Text = "Animations";
            this.btnfancywindows.UseVisualStyleBackColor = false;
            this.btnfancywindows.Click += new System.EventHandler(this.btnfancywindows_Click);
            // 
            // label176
            // 
            this.label176.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label176.Location = new System.Drawing.Point(72, 0);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(332, 29);
            this.label176.TabIndex = 0;
            this.label176.Text = "Fancy Effects";
            // 
            // pnlmenus
            // 
            this.pnlmenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlmenus.BackColor = System.Drawing.Color.White;
            this.pnlmenus.Controls.Add(this.pnladvanced);
            this.pnlmenus.Controls.Add(this.pnlmore);
            this.pnlmenus.Controls.Add(this.pnldropdown);
            this.pnlmenus.Controls.Add(this.pnlbasic);
            this.pnlmenus.Controls.Add(this.pnlmenusintro);
            this.pnlmenus.Controls.Add(this.pnlmenucategories);
            this.pnlmenus.Controls.Add(this.label74);
            this.pnlmenus.Location = new System.Drawing.Point(134, 9);
            this.pnlmenus.Name = "pnlmenus";
            this.pnlmenus.Size = new System.Drawing.Size(457, 306);
            this.pnlmenus.TabIndex = 19;
            // 
            // pnladvanced
            // 
            this.pnladvanced.Controls.Add(this.btnmorebuttons);
            this.pnladvanced.Controls.Add(this.pnlbuttonchecked);
            this.pnladvanced.Controls.Add(this.label136);
            this.pnladvanced.Controls.Add(this.pnlitemselectedend);
            this.pnladvanced.Controls.Add(this.label129);
            this.pnladvanced.Controls.Add(this.pnlbuttonpressed);
            this.pnladvanced.Controls.Add(this.label130);
            this.pnladvanced.Controls.Add(this.pnlitemselectedbegin);
            this.pnladvanced.Controls.Add(this.label131);
            this.pnladvanced.Controls.Add(this.pnlitemselected);
            this.pnladvanced.Controls.Add(this.label132);
            this.pnladvanced.Controls.Add(this.pnlbuttonselected);
            this.pnladvanced.Controls.Add(this.label133);
            this.pnladvanced.Controls.Add(this.pnlcheckbg);
            this.pnladvanced.Controls.Add(this.label134);
            this.pnladvanced.Controls.Add(this.label135);
            this.pnladvanced.Location = new System.Drawing.Point(139, 43);
            this.pnladvanced.Name = "pnladvanced";
            this.pnladvanced.Size = new System.Drawing.Size(311, 256);
            this.pnladvanced.TabIndex = 13;
            // 
            // btnmorebuttons
            // 
            this.btnmorebuttons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmorebuttons.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.btnmorebuttons.Location = new System.Drawing.Point(216, 195);
            this.btnmorebuttons.Name = "btnmorebuttons";
            this.btnmorebuttons.Size = new System.Drawing.Size(90, 32);
            this.btnmorebuttons.TabIndex = 18;
            this.btnmorebuttons.Text = "More >>";
            this.btnmorebuttons.UseVisualStyleBackColor = true;
            this.btnmorebuttons.Click += new System.EventHandler(this.btnmorebuttons_Click);
            // 
            // pnlbuttonchecked
            // 
            this.pnlbuttonchecked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbuttonchecked.Location = new System.Drawing.Point(115, 153);
            this.pnlbuttonchecked.Name = "pnlbuttonchecked";
            this.pnlbuttonchecked.Size = new System.Drawing.Size(41, 20);
            this.pnlbuttonchecked.TabIndex = 11;
            this.pnlbuttonchecked.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetButtonCheckBG);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.Location = new System.Drawing.Point(10, 153);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(102, 16);
            this.label136.TabIndex = 10;
            this.label136.Text = "Button Checked";
            // 
            // pnlitemselectedend
            // 
            this.pnlitemselectedend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlitemselectedend.Location = new System.Drawing.Point(134, 83);
            this.pnlitemselectedend.Name = "pnlitemselectedend";
            this.pnlitemselectedend.Size = new System.Drawing.Size(41, 20);
            this.pnlitemselectedend.TabIndex = 11;
            this.pnlitemselectedend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetItemSelectedEnd);
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(12, 85);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(117, 16);
            this.label129.TabIndex = 10;
            this.label129.Text = "Item Selected End";
            // 
            // pnlbuttonpressed
            // 
            this.pnlbuttonpressed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbuttonpressed.Location = new System.Drawing.Point(117, 207);
            this.pnlbuttonpressed.Name = "pnlbuttonpressed";
            this.pnlbuttonpressed.Size = new System.Drawing.Size(41, 20);
            this.pnlbuttonpressed.TabIndex = 9;
            this.pnlbuttonpressed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetButtonPressedBG);
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(12, 207);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(99, 16);
            this.label130.TabIndex = 8;
            this.label130.Text = "Button Pressed";
            // 
            // pnlitemselectedbegin
            // 
            this.pnlitemselectedbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlitemselectedbegin.Location = new System.Drawing.Point(143, 56);
            this.pnlitemselectedbegin.Name = "pnlitemselectedbegin";
            this.pnlitemselectedbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlitemselectedbegin.TabIndex = 7;
            this.pnlitemselectedbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetItemSelectedBegin);
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(10, 58);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(128, 16);
            this.label131.TabIndex = 6;
            this.label131.Text = "Item Selected Begin";
            // 
            // pnlitemselected
            // 
            this.pnlitemselected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlitemselected.Location = new System.Drawing.Point(240, 29);
            this.pnlitemselected.Name = "pnlitemselected";
            this.pnlitemselected.Size = new System.Drawing.Size(41, 20);
            this.pnlitemselected.TabIndex = 5;
            this.pnlitemselected.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetItemSelected);
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.Location = new System.Drawing.Point(147, 32);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(90, 16);
            this.label132.TabIndex = 4;
            this.label132.Text = "Item Selected";
            // 
            // pnlbuttonselected
            // 
            this.pnlbuttonselected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbuttonselected.Location = new System.Drawing.Point(110, 181);
            this.pnlbuttonselected.Name = "pnlbuttonselected";
            this.pnlbuttonselected.Size = new System.Drawing.Size(41, 20);
            this.pnlbuttonselected.TabIndex = 5;
            this.pnlbuttonselected.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetButtonSelectedBG);
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(7, 181);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(102, 16);
            this.label133.TabIndex = 4;
            this.label133.Text = "Button Selected";
            // 
            // pnlcheckbg
            // 
            this.pnlcheckbg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlcheckbg.Location = new System.Drawing.Point(79, 29);
            this.pnlcheckbg.Name = "pnlcheckbg";
            this.pnlcheckbg.Size = new System.Drawing.Size(41, 20);
            this.pnlcheckbg.TabIndex = 3;
            this.pnlcheckbg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetCheckBG);
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.Location = new System.Drawing.Point(10, 29);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(68, 16);
            this.label134.TabIndex = 2;
            this.label134.Text = "Check BG";
            // 
            // label135
            // 
            this.label135.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label135.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label135.Location = new System.Drawing.Point(6, 0);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(301, 29);
            this.label135.TabIndex = 1;
            this.label135.Text = "Advanced";
            this.label135.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlmore
            // 
            this.pnlmore.Controls.Add(this.pnlpressedbegin);
            this.pnlmore.Controls.Add(this.btnback);
            this.pnlmore.Controls.Add(this.label138);
            this.pnlmore.Controls.Add(this.pnlselectedbegin);
            this.pnlmore.Controls.Add(this.pnlpressedend);
            this.pnlmore.Controls.Add(this.label137);
            this.pnlmore.Controls.Add(this.label139);
            this.pnlmore.Controls.Add(this.pnlselectedend);
            this.pnlmore.Controls.Add(this.pnlpressedmiddle);
            this.pnlmore.Controls.Add(this.label140);
            this.pnlmore.Controls.Add(this.label142);
            this.pnlmore.Controls.Add(this.pnlselectedmiddle);
            this.pnlmore.Controls.Add(this.label145);
            this.pnlmore.Controls.Add(this.label147);
            this.pnlmore.Location = new System.Drawing.Point(139, 43);
            this.pnlmore.Name = "pnlmore";
            this.pnlmore.Size = new System.Drawing.Size(311, 256);
            this.pnlmore.TabIndex = 14;
            // 
            // pnlpressedbegin
            // 
            this.pnlpressedbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpressedbegin.Location = new System.Drawing.Point(170, 107);
            this.pnlpressedbegin.Name = "pnlpressedbegin";
            this.pnlpressedbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlpressedbegin.TabIndex = 17;
            this.pnlpressedbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetPressedBegin);
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.btnback.Location = new System.Drawing.Point(6, 184);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(90, 32);
            this.btnback.TabIndex = 18;
            this.btnback.Text = "<< Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnadvanced_Click);
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(13, 108);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(151, 16);
            this.label138.TabIndex = 16;
            this.label138.Text = "Pressed Gradient Begin";
            // 
            // pnlselectedbegin
            // 
            this.pnlselectedbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlselectedbegin.Location = new System.Drawing.Point(169, 29);
            this.pnlselectedbegin.Name = "pnlselectedbegin";
            this.pnlselectedbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlselectedbegin.TabIndex = 11;
            this.pnlselectedbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetSelectedBegin);
            // 
            // pnlpressedend
            // 
            this.pnlpressedend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpressedend.Location = new System.Drawing.Point(162, 159);
            this.pnlpressedend.Name = "pnlpressedend";
            this.pnlpressedend.Size = new System.Drawing.Size(41, 20);
            this.pnlpressedend.TabIndex = 15;
            this.pnlpressedend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetPressedEnd);
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.Location = new System.Drawing.Point(12, 30);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(154, 16);
            this.label137.TabIndex = 10;
            this.label137.Text = "Selected Gradient Begin";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(15, 162);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(140, 16);
            this.label139.TabIndex = 14;
            this.label139.Text = "Pressed Gradient End";
            // 
            // pnlselectedend
            // 
            this.pnlselectedend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlselectedend.Location = new System.Drawing.Point(161, 81);
            this.pnlselectedend.Name = "pnlselectedend";
            this.pnlselectedend.Size = new System.Drawing.Size(41, 20);
            this.pnlselectedend.TabIndex = 9;
            this.pnlselectedend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetSelectedEnd);
            // 
            // pnlpressedmiddle
            // 
            this.pnlpressedmiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpressedmiddle.Location = new System.Drawing.Point(179, 134);
            this.pnlpressedmiddle.Name = "pnlpressedmiddle";
            this.pnlpressedmiddle.Size = new System.Drawing.Size(41, 20);
            this.pnlpressedmiddle.TabIndex = 13;
            this.pnlpressedmiddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetPressedMiddle);
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(16, 138);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(157, 16);
            this.label140.TabIndex = 12;
            this.label140.Text = "Pressed Gradient Middle";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(14, 84);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(143, 16);
            this.label142.TabIndex = 8;
            this.label142.Text = "Selected Gradient End";
            // 
            // pnlselectedmiddle
            // 
            this.pnlselectedmiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlselectedmiddle.Location = new System.Drawing.Point(182, 56);
            this.pnlselectedmiddle.Name = "pnlselectedmiddle";
            this.pnlselectedmiddle.Size = new System.Drawing.Size(41, 20);
            this.pnlselectedmiddle.TabIndex = 5;
            this.pnlselectedmiddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetSelectedMiddle);
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.Location = new System.Drawing.Point(18, 58);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(160, 16);
            this.label145.TabIndex = 4;
            this.label145.Text = "Selected Gradient Middle";
            // 
            // label147
            // 
            this.label147.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label147.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label147.Location = new System.Drawing.Point(6, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(301, 29);
            this.label147.TabIndex = 1;
            this.label147.Text = "Advanced";
            this.label147.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnldropdown
            // 
            this.pnldropdown.Controls.Add(this.pnlddborder);
            this.pnldropdown.Controls.Add(this.label117);
            this.pnldropdown.Controls.Add(this.pnlmarginend);
            this.pnldropdown.Controls.Add(this.label120);
            this.pnldropdown.Controls.Add(this.pnlmarginmiddle);
            this.pnldropdown.Controls.Add(this.label121);
            this.pnldropdown.Controls.Add(this.pnlmarginbegin);
            this.pnldropdown.Controls.Add(this.label122);
            this.pnldropdown.Controls.Add(this.pnlhcolor);
            this.pnldropdown.Controls.Add(this.label123);
            this.pnldropdown.Controls.Add(this.pnlhborder);
            this.pnldropdown.Controls.Add(this.label125);
            this.pnldropdown.Controls.Add(this.label126);
            this.pnldropdown.Location = new System.Drawing.Point(139, 43);
            this.pnldropdown.Name = "pnldropdown";
            this.pnldropdown.Size = new System.Drawing.Size(311, 256);
            this.pnldropdown.TabIndex = 12;
            // 
            // pnlddborder
            // 
            this.pnlddborder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlddborder.Location = new System.Drawing.Point(216, 80);
            this.pnlddborder.Name = "pnlddborder";
            this.pnlddborder.Size = new System.Drawing.Size(41, 20);
            this.pnlddborder.TabIndex = 11;
            this.pnlddborder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuBorder);
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(167, 81);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(49, 16);
            this.label117.TabIndex = 10;
            this.label117.Text = "Border";
            // 
            // pnlmarginend
            // 
            this.pnlmarginend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmarginend.Location = new System.Drawing.Point(224, 55);
            this.pnlmarginend.Name = "pnlmarginend";
            this.pnlmarginend.Size = new System.Drawing.Size(41, 20);
            this.pnlmarginend.TabIndex = 9;
            this.pnlmarginend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MarginEnd);
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.Location = new System.Drawing.Point(148, 56);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(76, 16);
            this.label120.TabIndex = 8;
            this.label120.Text = "Margin End";
            // 
            // pnlmarginmiddle
            // 
            this.pnlmarginmiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmarginmiddle.Location = new System.Drawing.Point(117, 80);
            this.pnlmarginmiddle.Name = "pnlmarginmiddle";
            this.pnlmarginmiddle.Size = new System.Drawing.Size(41, 20);
            this.pnlmarginmiddle.TabIndex = 7;
            this.pnlmarginmiddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MarginMiddle);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(12, 80);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(93, 16);
            this.label121.TabIndex = 6;
            this.label121.Text = "Margin Middle";
            // 
            // pnlmarginbegin
            // 
            this.pnlmarginbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmarginbegin.Location = new System.Drawing.Point(101, 55);
            this.pnlmarginbegin.Name = "pnlmarginbegin";
            this.pnlmarginbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlmarginbegin.TabIndex = 5;
            this.pnlmarginbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MarginBegin);
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.Location = new System.Drawing.Point(12, 55);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(87, 16);
            this.label122.TabIndex = 4;
            this.label122.Text = "Margin Begin";
            // 
            // pnlhcolor
            // 
            this.pnlhcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlhcolor.Location = new System.Drawing.Point(249, 29);
            this.pnlhcolor.Name = "pnlhcolor";
            this.pnlhcolor.Size = new System.Drawing.Size(41, 20);
            this.pnlhcolor.TabIndex = 5;
            this.pnlhcolor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HighlightColor);
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.Location = new System.Drawing.Point(156, 29);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(95, 16);
            this.label123.TabIndex = 4;
            this.label123.Text = "Highlight Color";
            // 
            // pnlhborder
            // 
            this.pnlhborder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlhborder.Location = new System.Drawing.Point(115, 29);
            this.pnlhborder.Name = "pnlhborder";
            this.pnlhborder.Size = new System.Drawing.Size(41, 20);
            this.pnlhborder.TabIndex = 3;
            this.pnlhborder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HighlightBorder);
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.Location = new System.Drawing.Point(10, 29);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(104, 16);
            this.label125.TabIndex = 2;
            this.label125.Text = "Highlight Border";
            // 
            // label126
            // 
            this.label126.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label126.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label126.Location = new System.Drawing.Point(6, 0);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(301, 29);
            this.label126.TabIndex = 1;
            this.label126.Text = "Drop-Down Menus";
            this.label126.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlbasic
            // 
            this.pnlbasic.Controls.Add(this.pnlmenutextcolor);
            this.pnlbasic.Controls.Add(this.label118);
            this.pnlbasic.Controls.Add(this.pnldropdownbg);
            this.pnlbasic.Controls.Add(this.label115);
            this.pnlbasic.Controls.Add(this.pnlstatusend);
            this.pnlbasic.Controls.Add(this.label114);
            this.pnlbasic.Controls.Add(this.pnlstatusbegin);
            this.pnlbasic.Controls.Add(this.label107);
            this.pnlbasic.Controls.Add(this.pnltoolbarend);
            this.pnlbasic.Controls.Add(this.label77);
            this.pnlbasic.Controls.Add(this.pnltoolbarmiddle);
            this.pnlbasic.Controls.Add(this.label76);
            this.pnlbasic.Controls.Add(this.pnltoolbarbegin);
            this.pnlbasic.Controls.Add(this.label75);
            this.pnlbasic.Controls.Add(this.pnlmenubarend);
            this.pnlbasic.Controls.Add(this.label73);
            this.pnlbasic.Controls.Add(this.pnlmenubarbegin);
            this.pnlbasic.Controls.Add(this.label42);
            this.pnlbasic.Controls.Add(this.label41);
            this.pnlbasic.Location = new System.Drawing.Point(139, 43);
            this.pnlbasic.Name = "pnlbasic";
            this.pnlbasic.Size = new System.Drawing.Size(311, 256);
            this.pnlbasic.TabIndex = 10;
            // 
            // pnlmenutextcolor
            // 
            this.pnlmenutextcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmenutextcolor.Location = new System.Drawing.Point(85, 129);
            this.pnlmenutextcolor.Name = "pnlmenutextcolor";
            this.pnlmenutextcolor.Size = new System.Drawing.Size(41, 20);
            this.pnlmenutextcolor.TabIndex = 17;
            this.pnlmenutextcolor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetMenuTextColor);
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(11, 131);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(69, 16);
            this.label118.TabIndex = 16;
            this.label118.Text = "Text Color";
            // 
            // pnldropdownbg
            // 
            this.pnldropdownbg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnldropdownbg.Location = new System.Drawing.Point(228, 104);
            this.pnldropdownbg.Name = "pnldropdownbg";
            this.pnldropdownbg.Size = new System.Drawing.Size(41, 20);
            this.pnldropdownbg.TabIndex = 15;
            this.pnldropdownbg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DropDownBG);
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(132, 106);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(92, 16);
            this.label115.TabIndex = 14;
            this.label115.Text = "Dropdown BG";
            // 
            // pnlstatusend
            // 
            this.pnlstatusend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlstatusend.Location = new System.Drawing.Point(84, 104);
            this.pnlstatusend.Name = "pnlstatusend";
            this.pnlstatusend.Size = new System.Drawing.Size(41, 20);
            this.pnlstatusend.TabIndex = 13;
            this.pnlstatusend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusEnd);
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(10, 106);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(72, 16);
            this.label114.TabIndex = 12;
            this.label114.Text = "Status End";
            // 
            // pnlstatusbegin
            // 
            this.pnlstatusbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlstatusbegin.Location = new System.Drawing.Point(254, 81);
            this.pnlstatusbegin.Name = "pnlstatusbegin";
            this.pnlstatusbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlstatusbegin.TabIndex = 11;
            this.pnlstatusbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusBegin);
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.Location = new System.Drawing.Point(169, 81);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(83, 16);
            this.label107.TabIndex = 10;
            this.label107.Text = "Status Begin";
            // 
            // pnltoolbarend
            // 
            this.pnltoolbarend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltoolbarend.Location = new System.Drawing.Point(254, 55);
            this.pnltoolbarend.Name = "pnltoolbarend";
            this.pnltoolbarend.Size = new System.Drawing.Size(41, 20);
            this.pnltoolbarend.TabIndex = 9;
            this.pnltoolbarend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolBarEnd);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(161, 55);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(87, 16);
            this.label77.TabIndex = 8;
            this.label77.Text = "Tool Bar End";
            // 
            // pnltoolbarmiddle
            // 
            this.pnltoolbarmiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltoolbarmiddle.Location = new System.Drawing.Point(117, 80);
            this.pnltoolbarmiddle.Name = "pnltoolbarmiddle";
            this.pnltoolbarmiddle.Size = new System.Drawing.Size(41, 20);
            this.pnltoolbarmiddle.TabIndex = 7;
            this.pnltoolbarmiddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolBarMiddle);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(12, 80);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(104, 16);
            this.label76.TabIndex = 6;
            this.label76.Text = "Tool Bar Middle";
            // 
            // pnltoolbarbegin
            // 
            this.pnltoolbarbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltoolbarbegin.Location = new System.Drawing.Point(117, 55);
            this.pnltoolbarbegin.Name = "pnltoolbarbegin";
            this.pnltoolbarbegin.Size = new System.Drawing.Size(41, 20);
            this.pnltoolbarbegin.TabIndex = 5;
            this.pnltoolbarbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolBarBegin);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(12, 55);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(98, 16);
            this.label75.TabIndex = 4;
            this.label75.Text = "Tool Bar Begin";
            // 
            // pnlmenubarend
            // 
            this.pnlmenubarend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmenubarend.Location = new System.Drawing.Point(249, 29);
            this.pnlmenubarend.Name = "pnlmenubarend";
            this.pnlmenubarend.Size = new System.Drawing.Size(41, 20);
            this.pnlmenubarend.TabIndex = 5;
            this.pnlmenubarend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuEnd);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(156, 29);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(92, 16);
            this.label73.TabIndex = 4;
            this.label73.Text = "Menu Bar End";
            // 
            // pnlmenubarbegin
            // 
            this.pnlmenubarbegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmenubarbegin.Location = new System.Drawing.Point(115, 29);
            this.pnlmenubarbegin.Name = "pnlmenubarbegin";
            this.pnlmenubarbegin.Size = new System.Drawing.Size(41, 20);
            this.pnlmenubarbegin.TabIndex = 3;
            this.pnlmenubarbegin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuBegin);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(10, 29);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(103, 16);
            this.label42.TabIndex = 2;
            this.label42.Text = "Menu Bar Begin";
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label41.Location = new System.Drawing.Point(6, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(301, 29);
            this.label41.TabIndex = 1;
            this.label41.Text = "The Basics";
            this.label41.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlmenusintro
            // 
            this.pnlmenusintro.Controls.Add(this.label116);
            this.pnlmenusintro.Controls.Add(this.label124);
            this.pnlmenusintro.Location = new System.Drawing.Point(139, 43);
            this.pnlmenusintro.Name = "pnlmenusintro";
            this.pnlmenusintro.Size = new System.Drawing.Size(311, 256);
            this.pnlmenusintro.TabIndex = 11;
            // 
            // label116
            // 
            this.label116.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label116.BackColor = System.Drawing.Color.Transparent;
            this.label116.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(6, 29);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(300, 221);
            this.label116.TabIndex = 4;
            this.label116.Text = resources.GetString("label116.Text");
            this.label116.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label124
            // 
            this.label124.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label124.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label124.Location = new System.Drawing.Point(6, 0);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(301, 29);
            this.label124.TabIndex = 1;
            this.label124.Text = "Menus - Intro";
            this.label124.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlmenucategories
            // 
            this.pnlmenucategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlmenucategories.Controls.Add(this.btnmisc);
            this.pnlmenucategories.Controls.Add(this.btnadvanced);
            this.pnlmenucategories.Controls.Add(this.btndropdown);
            this.pnlmenucategories.Controls.Add(this.btnbasic);
            this.pnlmenucategories.Location = new System.Drawing.Point(6, 42);
            this.pnlmenucategories.Name = "pnlmenucategories";
            this.pnlmenucategories.Size = new System.Drawing.Size(128, 257);
            this.pnlmenucategories.TabIndex = 9;
            // 
            // btnmisc
            // 
            this.btnmisc.BackColor = System.Drawing.Color.White;
            this.btnmisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmisc.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmisc.Location = new System.Drawing.Point(4, 105);
            this.btnmisc.Name = "btnmisc";
            this.btnmisc.Size = new System.Drawing.Size(119, 29);
            this.btnmisc.TabIndex = 7;
            this.btnmisc.Text = "Misc.";
            this.btnmisc.UseVisualStyleBackColor = false;
            // 
            // btnadvanced
            // 
            this.btnadvanced.BackColor = System.Drawing.Color.White;
            this.btnadvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadvanced.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadvanced.Location = new System.Drawing.Point(4, 70);
            this.btnadvanced.Name = "btnadvanced";
            this.btnadvanced.Size = new System.Drawing.Size(119, 29);
            this.btnadvanced.TabIndex = 6;
            this.btnadvanced.Text = "Advanced";
            this.btnadvanced.UseVisualStyleBackColor = false;
            this.btnadvanced.Click += new System.EventHandler(this.btnadvanced_Click);
            // 
            // btndropdown
            // 
            this.btndropdown.BackColor = System.Drawing.Color.White;
            this.btndropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndropdown.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndropdown.Location = new System.Drawing.Point(4, 35);
            this.btndropdown.Name = "btndropdown";
            this.btndropdown.Size = new System.Drawing.Size(119, 29);
            this.btndropdown.TabIndex = 5;
            this.btndropdown.Text = "Drop-Downs";
            this.btndropdown.UseVisualStyleBackColor = false;
            this.btndropdown.Click += new System.EventHandler(this.btndropdown_Click);
            // 
            // btnbasic
            // 
            this.btnbasic.BackColor = System.Drawing.Color.White;
            this.btnbasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbasic.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbasic.Location = new System.Drawing.Point(4, 0);
            this.btnbasic.Name = "btnbasic";
            this.btnbasic.Size = new System.Drawing.Size(119, 29);
            this.btnbasic.TabIndex = 4;
            this.btnbasic.Text = "Basic Customization";
            this.btnbasic.UseVisualStyleBackColor = false;
            this.btnbasic.Click += new System.EventHandler(this.btnbasic_Click);
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(72, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(332, 29);
            this.label74.TabIndex = 0;
            this.label74.Text = "Menu Customization";
            // 
            // tmrfix
            // 
            this.tmrfix.Interval = 5000;
            // 
            // Shifter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 323);
            this.Controls.Add(this.pgcontents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Shifter";
            this.Text = "Shifter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Shifter_Load);
            this.catholder.ResumeLayout(false);
            this.pnlshifterintro.ResumeLayout(false);
            this.pnlshifterintro.PerformLayout();
            this.pnldesktopoptions.ResumeLayout(false);
            this.pnlapplauncheroptions.ResumeLayout(false);
            this.pnlapplauncheroptions.PerformLayout();
            this.pnldesktopintro.ResumeLayout(false);
            this.pnldesktopintro.PerformLayout();
            this.pnlpanelbuttonsoptions.ResumeLayout(false);
            this.pnlpanelbuttonsoptions.PerformLayout();
            this.pnldesktoppaneloptions.ResumeLayout(false);
            this.pnldesktoppaneloptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesktoppanelheight)).EndInit();
            this.pnldesktopbackgroundoptions.ResumeLayout(false);
            this.pnldesktopbackgroundoptions.PerformLayout();
            this.pnlpanelclockoptions.ResumeLayout(false);
            this.pnlpanelclockoptions.PerformLayout();
            this.pnldesktoppreview.ResumeLayout(false);
            this.predesktoppanel.ResumeLayout(false);
            this.prepnlpanelbuttonholder.ResumeLayout(false);
            this.prepnlpanelbutton.ResumeLayout(false);
            this.prepnlpanelbutton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pretbicon)).EndInit();
            this.pretimepanel.ResumeLayout(false);
            this.pretimepanel.PerformLayout();
            this.preapplaunchermenuholder.ResumeLayout(false);
            this.predesktopappmenu.ResumeLayout(false);
            this.predesktopappmenu.PerformLayout();
            this.Panel10.ResumeLayout(false);
            this.pnlwindowsoptions.ResumeLayout(false);
            this.pnlwindowsintro.ResumeLayout(false);
            this.pnlwindowsintro.PerformLayout();
            this.pnlbuttonoptions.ResumeLayout(false);
            this.pnlbuttonoptions.PerformLayout();
            this.pnlclosebuttonoptions.ResumeLayout(false);
            this.pnlclosebuttonoptions.PerformLayout();
            this.pnlrollupbuttonoptions.ResumeLayout(false);
            this.pnlrollupbuttonoptions.PerformLayout();
            this.pnlminimizebuttonoptions.ResumeLayout(false);
            this.pnlminimizebuttonoptions.PerformLayout();
            this.pnltitlebaroptions.ResumeLayout(false);
            this.pnltitlebaroptions.PerformLayout();
            this.pnlborderoptions.ResumeLayout(false);
            this.pnlborderoptions.PerformLayout();
            this.pnltitletextoptions.ResumeLayout(false);
            this.pnltitletextoptions.PerformLayout();
            this.pnlwindowsobjects.ResumeLayout(false);
            this.pnlwindowpreview.ResumeLayout(false);
            this.prepgleft.ResumeLayout(false);
            this.prepgright.ResumeLayout(false);
            this.pretitlebar.ResumeLayout(false);
            this.pretitlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prepnlicon)).EndInit();
            this.pnlreset.ResumeLayout(false);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.pnldesktopcomposition.ResumeLayout(false);
            this.pnlfancywindows.ResumeLayout(false);
            this.pnlfancywindows.PerformLayout();
            this.pnlfancydragging.ResumeLayout(false);
            this.pnlfancydragging.PerformLayout();
            this.pnlfancyintro.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.pnlmenus.ResumeLayout(false);
            this.pnladvanced.ResumeLayout(false);
            this.pnladvanced.PerformLayout();
            this.pnlmore.ResumeLayout(false);
            this.pnlmore.PerformLayout();
            this.pnldropdown.ResumeLayout(false);
            this.pnldropdown.PerformLayout();
            this.pnlbasic.ResumeLayout(false);
            this.pnlbasic.PerformLayout();
            this.pnlmenusintro.ResumeLayout(false);
            this.pnlmenucategories.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ColorDialog ColorDialog1;
        private System.Windows.Forms.Timer clocktick;
        private System.Windows.Forms.Timer customizationtime;
        private System.Windows.Forms.Timer timerearned;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnapply;
        private System.Windows.Forms.Panel catholder;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnmenus;
        private System.Windows.Forms.Button btnwindows;
        private System.Windows.Forms.Button btndesktop;
        private System.Windows.Forms.Panel pnlshifterintro;
        private System.Windows.Forms.Label Label66;
        private System.Windows.Forms.Label Label65;
        private System.Windows.Forms.Label Label64;
        private System.Windows.Forms.Label Label63;
        private System.Windows.Forms.Panel pnldesktopoptions;
        private System.Windows.Forms.Panel pnlpanelbuttonsoptions;
        private System.Windows.Forms.Panel pnlpanelbuttontextcolour;
        private System.Windows.Forms.Label Label101;
        private System.Windows.Forms.TextBox txtpanelbuttontexttop;
        private System.Windows.Forms.Label Label104;
        private System.Windows.Forms.TextBox txtpanelbuttontextside;
        private System.Windows.Forms.Label Label106;
        private System.Windows.Forms.Label Label93;
        private System.Windows.Forms.TextBox txtpanelbuttontop;
        private System.Windows.Forms.Label Label94;
        private System.Windows.Forms.TextBox txtpanelbuttoninitalgap;
        private System.Windows.Forms.Label Label108;
        private System.Windows.Forms.TextBox txtpanelbuttonicontop;
        private System.Windows.Forms.Label Label110;
        private System.Windows.Forms.TextBox txtpanelbuttoniconside;
        private System.Windows.Forms.Label Label112;
        private System.Windows.Forms.TextBox txtpanelbuttoniconsize;
        private System.Windows.Forms.TextBox txtpanelbuttoniconheight;
        private System.Windows.Forms.Label Label105;
        private System.Windows.Forms.ComboBox cbpanelbuttontextstyle;
        private System.Windows.Forms.ComboBox cbpanelbuttonfont;
        private System.Windows.Forms.Label Label100;
        private System.Windows.Forms.TextBox txtpaneltextbuttonsize;
        private System.Windows.Forms.Label Label102;
        private System.Windows.Forms.Label Label103;
        private System.Windows.Forms.Label Label98;
        private System.Windows.Forms.TextBox txtpanelbuttongap;
        private System.Windows.Forms.Label Label99;
        private System.Windows.Forms.Label Label96;
        private System.Windows.Forms.TextBox txtpanelbuttonheight;
        private System.Windows.Forms.Label Label97;
        private System.Windows.Forms.Label Label92;
        private System.Windows.Forms.TextBox txtpanelbuttonwidth;
        private System.Windows.Forms.Label Label91;
        private System.Windows.Forms.Panel pnlpanelbuttoncolour;
        private System.Windows.Forms.Label Label95;
        private System.Windows.Forms.Panel pnldesktoppaneloptions;
        private System.Windows.Forms.Button btnpanelbuttons;
        private System.Windows.Forms.Label Label27;
        private System.Windows.Forms.ComboBox combodesktoppanelposition;
        private System.Windows.Forms.Label Label46;
        private System.Windows.Forms.Label Label47;
        private System.Windows.Forms.NumericUpDown txtdesktoppanelheight;
        private System.Windows.Forms.Label Label48;
        private System.Windows.Forms.Panel pnldesktoppanelcolour;
        private System.Windows.Forms.Label Label49;
        private System.Windows.Forms.Panel pnlapplauncheroptions;
        private System.Windows.Forms.Label Label71;
        private System.Windows.Forms.TextBox txtapplauncherwidth;
        private System.Windows.Forms.Label Label72;
        private System.Windows.Forms.TextBox txtappbuttonlabel;
        private System.Windows.Forms.Label Label51;
        private System.Windows.Forms.Label Label50;
        private System.Windows.Forms.Panel pnlmaintextcolour;
        private System.Windows.Forms.ComboBox comboappbuttontextstyle;
        private System.Windows.Forms.ComboBox comboappbuttontextfont;
        private System.Windows.Forms.Label Label37;
        private System.Windows.Forms.Label Label38;
        private System.Windows.Forms.TextBox txtappbuttontextsize;
        private System.Windows.Forms.Label Label39;
        private System.Windows.Forms.Label Label40;
        private System.Windows.Forms.Panel pnlmainbuttonactivated;
        private System.Windows.Forms.Label Label28;
        private System.Windows.Forms.Label Label35;
        private System.Windows.Forms.TextBox txtapplicationsbuttonheight;
        private System.Windows.Forms.Label Label36;
        private System.Windows.Forms.Panel pnlmainbuttoncolour;
        private System.Windows.Forms.Label Label43;
        private System.Windows.Forms.Panel pnldesktopintro;
        private System.Windows.Forms.Label Label69;
        private System.Windows.Forms.Label Label70;
        private System.Windows.Forms.Panel pnlpanelclockoptions;
        private System.Windows.Forms.Panel pnlclockbackgroundcolour;
        private System.Windows.Forms.Label Label44;
        private System.Windows.Forms.ComboBox comboclocktextstyle;
        private System.Windows.Forms.ComboBox comboclocktextfont;
        private System.Windows.Forms.Label Label26;
        private System.Windows.Forms.Label Label29;
        private System.Windows.Forms.TextBox txtclocktextfromtop;
        private System.Windows.Forms.Label Label30;
        private System.Windows.Forms.Label Label31;
        private System.Windows.Forms.TextBox txtclocktextsize;
        private System.Windows.Forms.Label Label32;
        private System.Windows.Forms.Label Label33;
        private System.Windows.Forms.Panel pnlpanelclocktextcolour;
        private System.Windows.Forms.Label Label34;
        private System.Windows.Forms.Panel pnldesktopbackgroundoptions;
        private System.Windows.Forms.Panel pnldesktopcolour;
        private System.Windows.Forms.Label Label45;
        private System.Windows.Forms.Panel Panel10;
        private System.Windows.Forms.Button btndesktopitself;
        private System.Windows.Forms.Button btnpanelclock;
        private System.Windows.Forms.Button btnapplauncher;
        private System.Windows.Forms.Button btndesktoppanel;
        private System.Windows.Forms.Panel pnldesktoppreview;
        private System.Windows.Forms.Panel predesktoppanel;
        private System.Windows.Forms.FlowLayoutPanel prepnlpanelbuttonholder;
        private System.Windows.Forms.Panel prepnlpanelbutton;
        private System.Windows.Forms.PictureBox pretbicon;
        private System.Windows.Forms.Label pretbctext;
        private System.Windows.Forms.Panel pretimepanel;
        private System.Windows.Forms.Label prepaneltimetext;
        private System.Windows.Forms.Panel preapplaunchermenuholder;
        private System.Windows.Forms.MenuStrip predesktopappmenu;
        private System.Windows.Forms.ToolStripMenuItem ApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KnowledgeInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShiftoriumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TerminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShifterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShutdownToolStripMenuItem;
        private System.Windows.Forms.Panel pnlwindowsoptions;
        private System.Windows.Forms.Panel pnlbuttonoptions;
        private System.Windows.Forms.Panel pnlminimizebuttonoptions;
        private System.Windows.Forms.Label Label82;
        private System.Windows.Forms.Label Label83;
        private System.Windows.Forms.Panel pnlminimizebuttoncolour;
        private System.Windows.Forms.TextBox txtminimizebuttonside;
        private System.Windows.Forms.Label Label84;
        private System.Windows.Forms.Label Label85;
        private System.Windows.Forms.TextBox txtminimizebuttonheight;
        private System.Windows.Forms.Label Label86;
        private System.Windows.Forms.Label Label87;
        private System.Windows.Forms.TextBox txtminimizebuttontop;
        private System.Windows.Forms.Label Label88;
        private System.Windows.Forms.Label Label89;
        private System.Windows.Forms.TextBox txtminimizebuttonwidth;
        private System.Windows.Forms.Label Label90;
        private System.Windows.Forms.Panel pnlrollupbuttonoptions;
        private System.Windows.Forms.Label Label54;
        private System.Windows.Forms.Label Label55;
        private System.Windows.Forms.Panel pnlrollupbuttoncolour;
        private System.Windows.Forms.TextBox txtrollupbuttonside;
        private System.Windows.Forms.Label Label56;
        private System.Windows.Forms.Label Label57;
        private System.Windows.Forms.TextBox txtrollupbuttonheight;
        private System.Windows.Forms.Label Label58;
        private System.Windows.Forms.Label Label59;
        private System.Windows.Forms.TextBox txtrollupbuttontop;
        private System.Windows.Forms.Label Label60;
        private System.Windows.Forms.Label Label61;
        private System.Windows.Forms.TextBox txtrollupbuttonwidth;
        private System.Windows.Forms.Label Label62;
        private System.Windows.Forms.ComboBox combobuttonoption;
        private System.Windows.Forms.Label Label52;
        private System.Windows.Forms.Panel pnlclosebuttonoptions;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Panel pnlclosebuttoncolour;
        private System.Windows.Forms.TextBox txtclosebuttonfromside;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.TextBox txtclosebuttonheight;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtclosebuttonfromtop;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.TextBox txtclosebuttonwidth;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Panel pnltitlebaroptions;
        private System.Windows.Forms.Label Label80;
        private System.Windows.Forms.TextBox txticonfromtop;
        private System.Windows.Forms.Label Label81;
        private System.Windows.Forms.Label Label78;
        private System.Windows.Forms.TextBox txticonfromside;
        private System.Windows.Forms.Label Label79;
        private System.Windows.Forms.Label lbcornerwidthpx;
        private System.Windows.Forms.TextBox txttitlebarcornerwidth;
        private System.Windows.Forms.Label lbcornerwidth;
        private System.Windows.Forms.Panel pnltitlebarrightcornercolour;
        private System.Windows.Forms.Panel pnltitlebarleftcornercolour;
        private System.Windows.Forms.Label lbrightcornercolor;
        private System.Windows.Forms.Label lbleftcornercolor;
        private System.Windows.Forms.CheckBox cboxtitlebarcorners;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txttitlebarheight;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Panel pnltitlebarcolour;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel pnlborderoptions;
        private System.Windows.Forms.CheckBox cbindividualbordercolours;
        private System.Windows.Forms.Panel pnlborderbottomrightcolour;
        private System.Windows.Forms.Label lbbright;
        private System.Windows.Forms.Panel pnlborderbottomcolour;
        private System.Windows.Forms.Label lbbottom;
        private System.Windows.Forms.Panel pnlborderbottomleftcolour;
        private System.Windows.Forms.Label lbbleft;
        private System.Windows.Forms.Panel pnlborderrightcolour;
        private System.Windows.Forms.Label lbright;
        private System.Windows.Forms.Panel pnlborderleftcolour;
        private System.Windows.Forms.Label lbleft;
        private System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Panel pnlbordercolour;
        private System.Windows.Forms.TextBox txtbordersize;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Panel pnltitletextoptions;
        private System.Windows.Forms.ComboBox combotitletextposition;
        private System.Windows.Forms.Label Label53;
        private System.Windows.Forms.ComboBox combotitletextstyle;
        private System.Windows.Forms.ComboBox combotitletextfont;
        private System.Windows.Forms.Label Label23;
        private System.Windows.Forms.Label Label17;
        private System.Windows.Forms.TextBox txttitletextside;
        private System.Windows.Forms.Label Label18;
        private System.Windows.Forms.Label Label19;
        private System.Windows.Forms.TextBox txttitletexttop;
        private System.Windows.Forms.Label Label20;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.TextBox txttitletextsize;
        private System.Windows.Forms.Label Label22;
        private System.Windows.Forms.Label Label24;
        private System.Windows.Forms.Panel pnltitletextcolour;
        private System.Windows.Forms.Label Label25;
        private System.Windows.Forms.Panel pnlwindowsintro;
        private System.Windows.Forms.Label Label68;
        private System.Windows.Forms.Label Label67;
        private System.Windows.Forms.Panel pnlwindowsobjects;
        private System.Windows.Forms.Button btnborders;
        private System.Windows.Forms.Button btnbuttons;
        private System.Windows.Forms.Button btntitletext;
        private System.Windows.Forms.Button btntitlebar;
        private System.Windows.Forms.Panel pnlwindowpreview;
        private System.Windows.Forms.Panel prepgcontent;
        private System.Windows.Forms.Panel prepgbottom;
        private System.Windows.Forms.Panel prepgleft;
        private System.Windows.Forms.Panel prepgbottomlcorner;
        private System.Windows.Forms.Panel prepgright;
        private System.Windows.Forms.Panel prepgbottomrcorner;
        private System.Windows.Forms.Panel pretitlebar;
        private System.Windows.Forms.Panel preminimizebutton;
        private System.Windows.Forms.PictureBox prepnlicon;
        private System.Windows.Forms.Panel prerollupbutton;
        private System.Windows.Forms.Panel preclosebutton;
        private System.Windows.Forms.Label pretitletext;
        private System.Windows.Forms.Panel prepgtoplcorner;
        private System.Windows.Forms.Panel prepgtoprcorner;
        private System.Windows.Forms.Panel pnlreset;
        private System.Windows.Forms.Label Label113;
        private System.Windows.Forms.Button btnresetallsettings;
        private System.Windows.Forms.Label Label109;
        private System.Windows.Forms.Label Label111;
        private System.Windows.Forms.Panel pgcontents;
        private System.Windows.Forms.Timer tmrfix;
        private System.Windows.Forms.Timer tmrdelay;
        private Panel pnlmenus;
        private Label label74;
        private Panel pnlmenucategories;
        private Button btnmisc;
        private Button btnadvanced;
        private Button btndropdown;
        private Button btnbasic;
        private Panel pnlbasic;
        private Panel pnlmenubarend;
        private Label label73;
        private Panel pnlmenubarbegin;
        private Label label42;
        private Label label41;
        private Panel pnltoolbarend;
        private Label label77;
        private Panel pnltoolbarmiddle;
        private Label label76;
        private Panel pnltoolbarbegin;
        private Label label75;
        private Panel pnlstatusend;
        private Label label114;
        private Panel pnlstatusbegin;
        private Label label107;
        private Panel pnldropdownbg;
        private Label label115;
        private Panel pnlmenusintro;
        private Label label116;
        private Label label124;
        private Panel pnldropdown;
        private Panel pnlmarginend;
        private Label label120;
        private Panel pnlmarginmiddle;
        private Label label121;
        private Panel pnlmarginbegin;
        private Label label122;
        private Panel pnlhcolor;
        private Label label123;
        private Panel pnlhborder;
        private Label label125;
        private Label label126;
        private Panel pnlddborder;
        private Label label117;
        private Panel pnlmenutextcolor;
        private Label label118;
        private Panel pnladvanced;
        private Panel pnlitemselectedend;
        private Label label129;
        private Panel pnlbuttonpressed;
        private Label label130;
        private Panel pnlitemselectedbegin;
        private Label label131;
        private Panel pnlitemselected;
        private Label label132;
        private Panel pnlbuttonselected;
        private Label label133;
        private Panel pnlcheckbg;
        private Label label134;
        private Label label135;
        private Panel pnlbuttonchecked;
        private Label label136;
        private Button btnmorebuttons;
        private Panel pnlmore;
        private Panel pnlpressedbegin;
        private Button btnback;
        private Label label138;
        private Panel pnlselectedbegin;
        private Panel pnlpressedend;
        private Label label137;
        private Label label139;
        private Panel pnlselectedend;
        private Panel pnlpressedmiddle;
        private Label label140;
        private Label label142;
        private Panel pnlselectedmiddle;
        private Label label145;
        private Label label147;
        private Panel pnlalhover;
        private Label label119;
        private Button btndesktopicons;
        private Button btnwindowcomposition;
        private Panel pnldesktopcomposition;
        private Panel pnlfancywindows;
        private Label label149;
        private Panel pnlfancydragging;
        private Label label156;
        private Panel panel18;
        private Panel panel19;
        private Label label157;
        private Panel panel20;
        private Label label158;
        private Panel panel21;
        private Label label159;
        private Panel panel22;
        private Label label160;
        private Panel panel23;
        private Label label161;
        private Panel panel24;
        private Label label162;
        private Label label163;
        private Panel panel25;
        private Panel panel26;
        private Label label164;
        private Panel panel27;
        private Label label165;
        private Panel panel28;
        private Label label166;
        private Panel panel29;
        private Label label167;
        private Panel panel30;
        private Label label168;
        private Panel panel31;
        private Label label169;
        private Panel panel32;
        private Label label170;
        private Panel panel33;
        private Label label171;
        private Panel panel34;
        private Label label172;
        private Label label173;
        private Panel pnlfancyintro;
        private Label label174;
        private Label label175;
        private Panel panel36;
        private Button btnfancydragging;
        private Button btnfancywindows;
        private Label label176;
        private ComboBox cbcloseanim;
        private Label label128;
        private ComboBox cbopenanim;
        private Label label127;
        private ComboBox cbdrageffect;
        private Label label141;
        private TextBox txtfadespeed;
        private Label label155;
        private TextBox txtdragfadedec;
        private Label label143;
        private TextBox txtdragopacitydec;
        private Label label144;
        private TextBox txtshakeminoffset;
        private Label label148;
        private TextBox txtshakemax;
        private Label label146;
        private TextBox txtwinfadedec;
        private Label label150;
        private TextBox txtwinfadespeed;
        private Label label151;
    }
}