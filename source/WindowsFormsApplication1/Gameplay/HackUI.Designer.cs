namespace ShiftOS
{
    partial class HackUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HackUI));
            this.tbui = new ShiftUI.TableLayoutPanel();
            this.pnlenemy = new ShiftUI.Panel();
            this.lbenemycompromised = new ShiftUI.Label();
            this.lbenemystats = new ShiftUI.Label();
            this.txtyourconsole = new ShiftUI.TextBox();
            this.pnlyou = new ShiftUI.Panel();
            this.lbcompromised = new ShiftUI.Label();
            this.lbstats = new ShiftUI.Label();
            this.txtenemyconsole = new ShiftUI.TextBox();
            this.btnnext = new ShiftUI.Button();
            this.pnlbuy = new ShiftUI.Panel();
            this.txthostname = new ShiftUI.TextBox();
            this.lbhostname = new ShiftUI.Label();
            this.txtgrade = new ShiftUI.TextBox();
            this.lbgrade = new ShiftUI.Label();
            this.lbmoduleinfo = new ShiftUI.Label();
            this.cmbbuyable = new ShiftUI.ComboBox();
            this.label4 = new ShiftUI.Label();
            this.btndonebuying = new ShiftUI.Button();
            this.pnldefensemanager = new ShiftUI.Panel();
            this.btnbuy = new ShiftUI.Button();
            this.label3 = new ShiftUI.Label();
            this.cmbmodules = new ShiftUI.ComboBox();
            this.label1 = new ShiftUI.Label();
            this.button1 = new ShiftUI.Button();
            this.pnlpcinfo = new ShiftUI.Panel();
            this.lbtargets = new ShiftUI.Label();
            this.btnpoweroff = new ShiftUI.Button();
            this.btnupgrade = new ShiftUI.Button();
            this.lbpcinfo = new ShiftUI.Label();
            this.lbmoduletitle = new ShiftUI.Label();
            this.btncloseinfo = new ShiftUI.Button();
            this.flcontrols = new ShiftUI.FlowLayoutPanel();
            this.btnaddmodule = new ShiftUI.Button();
            this.lbcodepoints = new ShiftUI.Label();
            this.btntogglemusic = new ShiftUI.Button();
            this.lbsong = new ShiftUI.Label();
            this.panel2 = new ShiftUI.Panel();
            this.pgpong = new ShiftUI.Panel();
            this.lblcountdown = new ShiftUI.Label();
            this.ball = new ShiftUI.Panel();
            this.paddleHuman = new ShiftUI.PictureBox();
            this.paddleComputer = new ShiftUI.Panel();
            this.lbllevelandtime = new ShiftUI.Label();
            this.lblstatsY = new ShiftUI.Label();
            this.lblstatsX = new ShiftUI.Label();
            this.pnltutorial = new ShiftUI.Panel();
            this.lbtutorial = new ShiftUI.Label();
            this.tmrplayerhealthdetect = new ShiftUI.Timer(this.components);
            this.tmrenemyhealthdetect = new ShiftUI.Timer(this.components);
            this.tmrredraw = new ShiftUI.Timer(this.components);
            this.tmrvisualizer = new ShiftUI.Timer(this.components);
            this.pongGameTimer = new ShiftUI.Timer(this.components);
            this.counter = new ShiftUI.Timer(this.components);
            this.tmrcountdown = new ShiftUI.Timer(this.components);
            this.tbui.SuspendLayout();
            this.pnlenemy.SuspendLayout();
            this.pnlyou.SuspendLayout();
            this.pnlbuy.SuspendLayout();
            this.pnldefensemanager.SuspendLayout();
            this.pnlpcinfo.SuspendLayout();
            this.flcontrols.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pgpong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paddleHuman)).BeginInit();
            this.pnltutorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbui
            // 
            this.tbui.CellBorderStyle = ShiftUI.TableLayoutPanelCellBorderStyle.Single;
            this.tbui.ColumnCount = 2;
            this.tbui.ColumnStyles.Add(new ShiftUI.ColumnStyle(ShiftUI.SizeType.Percent, 50F));
            this.tbui.ColumnStyles.Add(new ShiftUI.ColumnStyle(ShiftUI.SizeType.Percent, 50F));
            this.tbui.Widgets.Add(this.pnlenemy, 1, 1);
            this.tbui.Widgets.Add(this.txtyourconsole, 0, 1);
            this.tbui.Widgets.Add(this.pnlyou, 0, 0);
            this.tbui.Widgets.Add(this.txtenemyconsole, 1, 0);
            this.tbui.Dock = ShiftUI.DockStyle.Fill;
            this.tbui.Location = new System.Drawing.Point(0, 0);
            this.tbui.Name = "tbui";
            this.tbui.RowCount = 2;
            this.tbui.RowStyles.Add(new ShiftUI.RowStyle(ShiftUI.SizeType.Percent, 50F));
            this.tbui.RowStyles.Add(new ShiftUI.RowStyle(ShiftUI.SizeType.Percent, 50F));
            this.tbui.Size = new System.Drawing.Size(1339, 710);
            this.tbui.TabIndex = 0;
            // 
            // pnlenemy
            // 
            this.pnlenemy.BackColor = System.Drawing.Color.Black;
            this.pnlenemy.Widgets.Add(this.lbenemycompromised);
            this.pnlenemy.Widgets.Add(this.lbenemystats);
            this.pnlenemy.Dock = ShiftUI.DockStyle.Fill;
            this.pnlenemy.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.pnlenemy.ForeColor = System.Drawing.Color.White;
            this.pnlenemy.Location = new System.Drawing.Point(673, 358);
            this.pnlenemy.Name = "pnlenemy";
            this.pnlenemy.Size = new System.Drawing.Size(662, 348);
            this.pnlenemy.TabIndex = 4;
            // 
            // lbenemycompromised
            // 
            this.lbenemycompromised.AutoSize = true;
            this.lbenemycompromised.Location = new System.Drawing.Point(161, 90);
            this.lbenemycompromised.Name = "lbenemycompromised";
            this.lbenemycompromised.Size = new System.Drawing.Size(47, 11);
            this.lbenemycompromised.TabIndex = 1;
            this.lbenemycompromised.Text = "label1";
            this.lbenemycompromised.Visible = false;
            // 
            // lbenemystats
            // 
            this.lbenemystats.AutoSize = true;
            this.lbenemystats.Location = new System.Drawing.Point(13, 13);
            this.lbenemystats.Name = "lbenemystats";
            this.lbenemystats.Size = new System.Drawing.Size(131, 11);
            this.lbenemystats.TabIndex = 0;
            this.lbenemystats.Text = "Enemy Health: 100%";
            // 
            // txtyourconsole
            // 
            this.txtyourconsole.BackColor = System.Drawing.Color.Black;
            this.txtyourconsole.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtyourconsole.Dock = ShiftUI.DockStyle.Fill;
            this.txtyourconsole.ForeColor = System.Drawing.Color.LightGreen;
            this.txtyourconsole.Location = new System.Drawing.Point(4, 358);
            this.txtyourconsole.Multiline = true;
            this.txtyourconsole.Name = "txtyourconsole";
            this.txtyourconsole.Size = new System.Drawing.Size(662, 348);
            this.txtyourconsole.TabIndex = 3;
            // 
            // pnlyou
            // 
            this.pnlyou.BackColor = System.Drawing.Color.Black;
            this.pnlyou.Widgets.Add(this.lbcompromised);
            this.pnlyou.Widgets.Add(this.lbstats);
            this.pnlyou.Dock = ShiftUI.DockStyle.Fill;
            this.pnlyou.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.pnlyou.ForeColor = System.Drawing.Color.White;
            this.pnlyou.Location = new System.Drawing.Point(4, 4);
            this.pnlyou.Name = "pnlyou";
            this.pnlyou.Size = new System.Drawing.Size(662, 347);
            this.pnlyou.TabIndex = 1;
            this.pnlyou.MouseDown += new ShiftUI.MouseEventHandler(this.playfield_MouseDown);
            // 
            // lbcompromised
            // 
            this.lbcompromised.AutoSize = true;
            this.lbcompromised.Location = new System.Drawing.Point(66, 88);
            this.lbcompromised.Name = "lbcompromised";
            this.lbcompromised.Size = new System.Drawing.Size(103, 11);
            this.lbcompromised.TabIndex = 3;
            this.lbcompromised.Text = "SYSTEM DAMAGED";
            this.lbcompromised.Visible = false;
            // 
            // lbstats
            // 
            this.lbstats.AutoSize = true;
            this.lbstats.Location = new System.Drawing.Point(13, 13);
            this.lbstats.Name = "lbstats";
            this.lbstats.Size = new System.Drawing.Size(138, 11);
            this.lbstats.TabIndex = 0;
            this.lbstats.Text = "System Health: 100%";
            // 
            // txtenemyconsole
            // 
            this.txtenemyconsole.BackColor = System.Drawing.Color.Black;
            this.txtenemyconsole.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtenemyconsole.Dock = ShiftUI.DockStyle.Fill;
            this.txtenemyconsole.ForeColor = System.Drawing.Color.LightGreen;
            this.txtenemyconsole.Location = new System.Drawing.Point(673, 4);
            this.txtenemyconsole.Multiline = true;
            this.txtenemyconsole.Name = "txtenemyconsole";
            this.txtenemyconsole.Size = new System.Drawing.Size(662, 347);
            this.txtenemyconsole.TabIndex = 2;
            // 
            // btnnext
            // 
            this.btnnext.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(294, 161);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(66, 23);
            this.btnnext.TabIndex = 9;
            this.btnnext.Text = "Next >>";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Visible = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // pnlbuy
            // 
            this.pnlbuy.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.pnlbuy.Widgets.Add(this.txthostname);
            this.pnlbuy.Widgets.Add(this.lbhostname);
            this.pnlbuy.Widgets.Add(this.txtgrade);
            this.pnlbuy.Widgets.Add(this.lbgrade);
            this.pnlbuy.Widgets.Add(this.lbmoduleinfo);
            this.pnlbuy.Widgets.Add(this.cmbbuyable);
            this.pnlbuy.Widgets.Add(this.label4);
            this.pnlbuy.Widgets.Add(this.btndonebuying);
            this.pnlbuy.Location = new System.Drawing.Point(7, 405);
            this.pnlbuy.Name = "pnlbuy";
            this.pnlbuy.Size = new System.Drawing.Size(382, 299);
            this.pnlbuy.TabIndex = 6;
            this.pnlbuy.Visible = false;
            // 
            // txthostname
            // 
            this.txthostname.BackColor = System.Drawing.Color.Black;
            this.txthostname.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txthostname.ForeColor = System.Drawing.Color.White;
            this.txthostname.Location = new System.Drawing.Point(186, 236);
            this.txthostname.Name = "txthostname";
            this.txthostname.Size = new System.Drawing.Size(186, 18);
            this.txthostname.TabIndex = 10;
            // 
            // lbhostname
            // 
            this.lbhostname.AutoSize = true;
            this.lbhostname.Location = new System.Drawing.Point(112, 240);
            this.lbhostname.Name = "lbhostname";
            this.lbhostname.Size = new System.Drawing.Size(68, 11);
            this.lbhostname.TabIndex = 9;
            this.lbhostname.Text = "Hostname:";
            // 
            // txtgrade
            // 
            this.txtgrade.BackColor = System.Drawing.Color.Black;
            this.txtgrade.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtgrade.ForeColor = System.Drawing.Color.White;
            this.txtgrade.Location = new System.Drawing.Point(65, 236);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(40, 18);
            this.txtgrade.TabIndex = 8;
            this.txtgrade.TextChanged += new System.EventHandler(this.txtgrade_TextChanged);
            // 
            // lbgrade
            // 
            this.lbgrade.AutoSize = true;
            this.lbgrade.Location = new System.Drawing.Point(12, 240);
            this.lbgrade.Name = "lbgrade";
            this.lbgrade.Size = new System.Drawing.Size(47, 11);
            this.lbgrade.TabIndex = 7;
            this.lbgrade.Text = "Grade:";
            // 
            // lbmoduleinfo
            // 
            this.lbmoduleinfo.Location = new System.Drawing.Point(10, 63);
            this.lbmoduleinfo.Name = "lbmoduleinfo";
            this.lbmoduleinfo.Size = new System.Drawing.Size(367, 156);
            this.lbmoduleinfo.TabIndex = 6;
            this.lbmoduleinfo.Text = resources.GetString("lbmoduleinfo.Text");
            // 
            // cmbbuyable
            // 
            this.cmbbuyable.BackColor = System.Drawing.Color.Black;
            this.cmbbuyable.DropDownStyle = ShiftUI.ComboBoxStyle.DropDownList;
            this.cmbbuyable.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.cmbbuyable.ForeColor = System.Drawing.Color.White;
            this.cmbbuyable.FormattingEnabled = true;
            this.cmbbuyable.Location = new System.Drawing.Point(12, 38);
            this.cmbbuyable.Name = "cmbbuyable";
            this.cmbbuyable.Size = new System.Drawing.Size(360, 19);
            this.cmbbuyable.TabIndex = 3;
            this.cmbbuyable.SelectedIndexChanged += new System.EventHandler(this.cmbbuyable_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 11);
            this.label4.TabIndex = 2;
            this.label4.Text = "Buy Module";
            // 
            // btndonebuying
            // 
            this.btndonebuying.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btndonebuying.AutoSize = true;
            this.btndonebuying.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btndonebuying.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btndonebuying.Location = new System.Drawing.Point(341, 273);
            this.btndonebuying.Name = "btndonebuying";
            this.btndonebuying.Size = new System.Drawing.Size(38, 23);
            this.btndonebuying.TabIndex = 1;
            this.btndonebuying.Text = "Buy";
            this.btndonebuying.UseVisualStyleBackColor = true;
            this.btndonebuying.Click += new System.EventHandler(this.btndonebuying_Click);
            // 
            // pnldefensemanager
            // 
            this.pnldefensemanager.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.pnldefensemanager.Widgets.Add(this.btnbuy);
            this.pnldefensemanager.Widgets.Add(this.label3);
            this.pnldefensemanager.Widgets.Add(this.cmbmodules);
            this.pnldefensemanager.Widgets.Add(this.label1);
            this.pnldefensemanager.Widgets.Add(this.button1);
            this.pnldefensemanager.Location = new System.Drawing.Point(395, 424);
            this.pnldefensemanager.Name = "pnldefensemanager";
            this.pnldefensemanager.Size = new System.Drawing.Size(382, 280);
            this.pnldefensemanager.TabIndex = 5;
            this.pnldefensemanager.Visible = false;
            // 
            // btnbuy
            // 
            this.btnbuy.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnbuy.AutoSize = true;
            this.btnbuy.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnbuy.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnbuy.Location = new System.Drawing.Point(199, 254);
            this.btnbuy.Name = "btnbuy";
            this.btnbuy.Size = new System.Drawing.Size(122, 23);
            this.btnbuy.TabIndex = 7;
            this.btnbuy.Text = "Buy new module.";
            this.btnbuy.UseVisualStyleBackColor = true;
            this.btnbuy.Click += new System.EventHandler(this.btnbuy_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(367, 156);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // cmbmodules
            // 
            this.cmbmodules.BackColor = System.Drawing.Color.Black;
            this.cmbmodules.DropDownStyle = ShiftUI.ComboBoxStyle.DropDownList;
            this.cmbmodules.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.cmbmodules.ForeColor = System.Drawing.Color.White;
            this.cmbmodules.FormattingEnabled = true;
            this.cmbmodules.Location = new System.Drawing.Point(12, 38);
            this.cmbmodules.Name = "cmbmodules";
            this.cmbmodules.Size = new System.Drawing.Size(360, 19);
            this.cmbmodules.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 11);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add Module";
            // 
            // button1
            // 
            this.button1.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(327, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Done.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pnlpcinfo
            // 
            this.pnlpcinfo.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.pnlpcinfo.Widgets.Add(this.lbtargets);
            this.pnlpcinfo.Widgets.Add(this.btnpoweroff);
            this.pnlpcinfo.Widgets.Add(this.btnupgrade);
            this.pnlpcinfo.Widgets.Add(this.lbpcinfo);
            this.pnlpcinfo.Widgets.Add(this.lbmoduletitle);
            this.pnlpcinfo.Widgets.Add(this.btncloseinfo);
            this.pnlpcinfo.Location = new System.Drawing.Point(783, 424);
            this.pnlpcinfo.Name = "pnlpcinfo";
            this.pnlpcinfo.Size = new System.Drawing.Size(382, 280);
            this.pnlpcinfo.TabIndex = 7;
            this.pnlpcinfo.Visible = false;
            // 
            // lbtargets
            // 
            this.lbtargets.Location = new System.Drawing.Point(12, 165);
            this.lbtargets.Name = "lbtargets";
            this.lbtargets.Size = new System.Drawing.Size(367, 86);
            this.lbtargets.TabIndex = 9;
            this.lbtargets.Text = "Targets";
            // 
            // btnpoweroff
            // 
            this.btnpoweroff.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnpoweroff.AutoSize = true;
            this.btnpoweroff.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnpoweroff.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnpoweroff.Location = new System.Drawing.Point(85, 254);
            this.btnpoweroff.Name = "btnpoweroff";
            this.btnpoweroff.Size = new System.Drawing.Size(80, 23);
            this.btnpoweroff.TabIndex = 8;
            this.btnpoweroff.Text = "Power Off";
            this.btnpoweroff.UseVisualStyleBackColor = true;
            this.btnpoweroff.Click += new System.EventHandler(this.btnpoweroff_Click);
            // 
            // btnupgrade
            // 
            this.btnupgrade.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnupgrade.AutoSize = true;
            this.btnupgrade.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnupgrade.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnupgrade.Location = new System.Drawing.Point(171, 254);
            this.btnupgrade.Name = "btnupgrade";
            this.btnupgrade.Size = new System.Drawing.Size(150, 23);
            this.btnupgrade.TabIndex = 7;
            this.btnupgrade.Text = "Upgrade This Module";
            this.btnupgrade.UseVisualStyleBackColor = true;
            this.btnupgrade.Click += new System.EventHandler(this.btnupgrade_Click);
            // 
            // lbpcinfo
            // 
            this.lbpcinfo.Location = new System.Drawing.Point(12, 41);
            this.lbpcinfo.Name = "lbpcinfo";
            this.lbpcinfo.Size = new System.Drawing.Size(367, 86);
            this.lbpcinfo.TabIndex = 6;
            this.lbpcinfo.Text = resources.GetString("lbpcinfo.Text");
            // 
            // lbmoduletitle
            // 
            this.lbmoduletitle.AutoSize = true;
            this.lbmoduletitle.Location = new System.Drawing.Point(10, 12);
            this.lbmoduletitle.Name = "lbmoduletitle";
            this.lbmoduletitle.Size = new System.Drawing.Size(75, 11);
            this.lbmoduletitle.TabIndex = 2;
            this.lbmoduletitle.Text = "Add Module";
            // 
            // btncloseinfo
            // 
            this.btncloseinfo.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btncloseinfo.AutoSize = true;
            this.btncloseinfo.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btncloseinfo.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btncloseinfo.Location = new System.Drawing.Point(327, 254);
            this.btncloseinfo.Name = "btncloseinfo";
            this.btncloseinfo.Size = new System.Drawing.Size(52, 23);
            this.btncloseinfo.TabIndex = 1;
            this.btncloseinfo.Text = "Done.";
            this.btncloseinfo.UseVisualStyleBackColor = true;
            this.btncloseinfo.Click += new System.EventHandler(this.btncloseinfo_Click);
            // 
            // flcontrols
            // 
            this.flcontrols.Widgets.Add(this.btnaddmodule);
            this.flcontrols.Widgets.Add(this.lbcodepoints);
            this.flcontrols.Widgets.Add(this.btntogglemusic);
            this.flcontrols.Widgets.Add(this.lbsong);
            this.flcontrols.Dock = ShiftUI.DockStyle.Bottom;
            this.flcontrols.Location = new System.Drawing.Point(0, 710);
            this.flcontrols.Name = "flcontrols";
            this.flcontrols.Size = new System.Drawing.Size(1339, 31);
            this.flcontrols.TabIndex = 4;
            // 
            // btnaddmodule
            // 
            this.btnaddmodule.AutoSize = true;
            this.btnaddmodule.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnaddmodule.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnaddmodule.Location = new System.Drawing.Point(3, 3);
            this.btnaddmodule.Name = "btnaddmodule";
            this.btnaddmodule.Size = new System.Drawing.Size(87, 23);
            this.btnaddmodule.TabIndex = 0;
            this.btnaddmodule.Text = "Add Module";
            this.btnaddmodule.UseVisualStyleBackColor = true;
            this.btnaddmodule.Click += new System.EventHandler(this.btnaddmodule_Click);
            // 
            // lbcodepoints
            // 
            this.lbcodepoints.Location = new System.Drawing.Point(96, 0);
            this.lbcodepoints.Name = "lbcodepoints";
            this.lbcodepoints.Size = new System.Drawing.Size(127, 26);
            this.lbcodepoints.TabIndex = 1;
            this.lbcodepoints.Text = "Codepoints:";
            this.lbcodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btntogglemusic
            // 
            this.btntogglemusic.AutoSize = true;
            this.btntogglemusic.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btntogglemusic.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btntogglemusic.Location = new System.Drawing.Point(229, 3);
            this.btntogglemusic.Name = "btntogglemusic";
            this.btntogglemusic.Size = new System.Drawing.Size(101, 23);
            this.btntogglemusic.TabIndex = 2;
            this.btntogglemusic.Text = "Toggle Music";
            this.btntogglemusic.UseVisualStyleBackColor = true;
            this.btntogglemusic.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbsong
            // 
            this.lbsong.Location = new System.Drawing.Point(336, 0);
            this.lbsong.Name = "lbsong";
            this.lbsong.Size = new System.Drawing.Size(414, 26);
            this.lbsong.TabIndex = 3;
            this.lbsong.Text = "Codepoints:";
            this.lbsong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Widgets.Add(this.pgpong);
            this.panel2.Widgets.Add(this.pnltutorial);
            this.panel2.Widgets.Add(this.pnlbuy);
            this.panel2.Widgets.Add(this.pnlpcinfo);
            this.panel2.Widgets.Add(this.pnldefensemanager);
            this.panel2.Widgets.Add(this.tbui);
            this.panel2.Widgets.Add(this.flcontrols);
            this.panel2.Dock = ShiftUI.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1339, 741);
            this.panel2.TabIndex = 1;
            // 
            // pgpong
            // 
            this.pgpong.BackColor = System.Drawing.Color.Black;
            this.pgpong.Widgets.Add(this.lblcountdown);
            this.pgpong.Widgets.Add(this.ball);
            this.pgpong.Widgets.Add(this.paddleHuman);
            this.pgpong.Widgets.Add(this.paddleComputer);
            this.pgpong.Widgets.Add(this.lbllevelandtime);
            this.pgpong.Widgets.Add(this.lblstatsY);
            this.pgpong.Widgets.Add(this.lblstatsX);
            this.pgpong.ForeColor = System.Drawing.Color.White;
            this.pgpong.Location = new System.Drawing.Point(0, 0);
            this.pgpong.Name = "pgpong";
            this.pgpong.Size = new System.Drawing.Size(700, 400);
            this.pgpong.TabIndex = 22;
            this.pgpong.Visible = false;
            this.pgpong.MouseMove += new ShiftUI.MouseEventHandler(this.pongMain_MouseMove);
            // 
            // lblcountdown
            // 
            this.lblcountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountdown.Location = new System.Drawing.Point(187, 152);
            this.lblcountdown.Name = "lblcountdown";
            this.lblcountdown.Size = new System.Drawing.Size(315, 49);
            this.lblcountdown.TabIndex = 7;
            this.lblcountdown.Text = "3";
            this.lblcountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblcountdown.Visible = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Gray;
            this.ball.Location = new System.Drawing.Point(300, 152);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.TabIndex = 2;
            // 
            // paddleHuman
            // 
            this.paddleHuman.BackColor = System.Drawing.Color.Gray;
            this.paddleHuman.Location = new System.Drawing.Point(10, 134);
            this.paddleHuman.Name = "paddleHuman";
            this.paddleHuman.Size = new System.Drawing.Size(20, 100);
            this.paddleHuman.TabIndex = 3;
            this.paddleHuman.TabStop = false;
            // 
            // paddleComputer
            // 
            this.paddleComputer.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Right)));
            this.paddleComputer.BackColor = System.Drawing.Color.Gray;
            this.paddleComputer.Location = new System.Drawing.Point(666, 134);
            this.paddleComputer.MaximumSize = new System.Drawing.Size(20, 100);
            this.paddleComputer.Name = "paddleComputer";
            this.paddleComputer.Size = new System.Drawing.Size(20, 100);
            this.paddleComputer.TabIndex = 1;
            // 
            // lbllevelandtime
            // 
            this.lbllevelandtime.Dock = ShiftUI.DockStyle.Top;
            this.lbllevelandtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllevelandtime.Location = new System.Drawing.Point(0, 0);
            this.lbllevelandtime.Name = "lbllevelandtime";
            this.lbllevelandtime.Size = new System.Drawing.Size(700, 22);
            this.lbllevelandtime.TabIndex = 4;
            this.lbllevelandtime.Text = "Level: 1";
            this.lbllevelandtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblstatsY
            // 
            this.lblstatsY.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.lblstatsY.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatsY.Location = new System.Drawing.Point(542, 356);
            this.lblstatsY.Name = "lblstatsY";
            this.lblstatsY.Size = new System.Drawing.Size(144, 35);
            this.lblstatsY.TabIndex = 11;
            this.lblstatsY.Text = "Yspeed:";
            this.lblstatsY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblstatsX
            // 
            this.lblstatsX.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.lblstatsX.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatsX.Location = new System.Drawing.Point(3, 356);
            this.lblstatsX.Name = "lblstatsX";
            this.lblstatsX.Size = new System.Drawing.Size(144, 35);
            this.lblstatsX.TabIndex = 5;
            this.lblstatsX.Text = "Xspeed: ";
            this.lblstatsX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnltutorial
            // 
            this.pnltutorial.Widgets.Add(this.btnnext);
            this.pnltutorial.Widgets.Add(this.lbtutorial);
            this.pnltutorial.Location = new System.Drawing.Point(174, 161);
            this.pnltutorial.Name = "pnltutorial";
            this.pnltutorial.Size = new System.Drawing.Size(363, 187);
            this.pnltutorial.TabIndex = 10;
            this.pnltutorial.Visible = false;
            // 
            // lbtutorial
            // 
            this.lbtutorial.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.lbtutorial.Location = new System.Drawing.Point(-2, 50);
            this.lbtutorial.Name = "lbtutorial";
            this.lbtutorial.Size = new System.Drawing.Size(367, 86);
            this.lbtutorial.TabIndex = 9;
            this.lbtutorial.Text = resources.GetString("lbtutorial.Text");
            this.lbtutorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtutorial.Visible = false;
            // 
            // tmrplayerhealthdetect
            // 
            this.tmrplayerhealthdetect.Tick += new System.EventHandler(this.tmrplayerhealthdetect_Tick);
            // 
            // tmrenemyhealthdetect
            // 
            this.tmrenemyhealthdetect.Tick += new System.EventHandler(this.tmrenemyhealthdetect_Tick);
            // 
            // tmrredraw
            // 
            this.tmrredraw.Tick += new System.EventHandler(this.tmrredraw_Tick);
            // 
            // tmrvisualizer
            // 
            this.tmrvisualizer.Tick += new System.EventHandler(this.tmrvisualizer_Tick);
            // 
            // pongGameTimer
            // 
            this.pongGameTimer.Interval = 30;
            this.pongGameTimer.Tick += new System.EventHandler(this.pongGameTimer_Tick);
            // 
            // counter
            // 
            this.counter.Interval = 1000;
            this.counter.Tick += new System.EventHandler(this.counter_Tick);
            // 
            // tmrcountdown
            // 
            this.tmrcountdown.Interval = 1000;
            this.tmrcountdown.Tick += new System.EventHandler(this.tmrcountdown_Tick);
            // 
            // HackUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1339, 741);
            this.Widgets.Add(this.panel2);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "HackUI";
            this.Text = "HackUI";
            this.FormClosing += new ShiftUI.FormClosingEventHandler(this.this_Closing);
            this.Load += new System.EventHandler(this.HackUI_Load);
            this.tbui.ResumeLayout(false);
            this.tbui.PerformLayout();
            this.pnlenemy.ResumeLayout(false);
            this.pnlenemy.PerformLayout();
            this.pnlyou.ResumeLayout(false);
            this.pnlyou.PerformLayout();
            this.pnlbuy.ResumeLayout(false);
            this.pnlbuy.PerformLayout();
            this.pnldefensemanager.ResumeLayout(false);
            this.pnldefensemanager.PerformLayout();
            this.pnlpcinfo.ResumeLayout(false);
            this.pnlpcinfo.PerformLayout();
            this.flcontrols.ResumeLayout(false);
            this.flcontrols.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pgpong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paddleHuman)).EndInit();
            this.pnltutorial.ResumeLayout(false);
            this.pnltutorial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.TableLayoutPanel tbui;
        private ShiftUI.Panel pnlyou;
        private ShiftUI.Panel pnlbuy;
        private ShiftUI.TextBox txthostname;
        private ShiftUI.Label lbhostname;
        private ShiftUI.TextBox txtgrade;
        private ShiftUI.Label lbgrade;
        private ShiftUI.Label lbmoduleinfo;
        private ShiftUI.ComboBox cmbbuyable;
        private ShiftUI.Label label4;
        private ShiftUI.Button btndonebuying;
        private ShiftUI.Panel pnldefensemanager;
        private ShiftUI.Button btnbuy;
        private ShiftUI.Label label3;
        private ShiftUI.ComboBox cmbmodules;
        private ShiftUI.Label label1;
        private ShiftUI.Button button1;
        private ShiftUI.Button btnnext;
        private ShiftUI.Panel pnlpcinfo;
        private ShiftUI.Label lbtargets;
        private ShiftUI.Button btnpoweroff;
        private ShiftUI.Button btnupgrade;
        private ShiftUI.Label lbpcinfo;
        private ShiftUI.Label lbmoduletitle;
        private ShiftUI.Button btncloseinfo;
        private ShiftUI.FlowLayoutPanel flcontrols;
        private ShiftUI.Button btnaddmodule;
        private ShiftUI.Label lbcompromised;
        private ShiftUI.Label lbstats;
        private ShiftUI.TextBox txtyourconsole;
        private ShiftUI.TextBox txtenemyconsole;
        private ShiftUI.Panel pnlenemy;
        private ShiftUI.Label lbenemycompromised;
        private ShiftUI.Label lbenemystats;
        private ShiftUI.Panel panel2;
        private ShiftUI.Timer tmrplayerhealthdetect;
        private ShiftUI.Timer tmrenemyhealthdetect;
        private ShiftUI.Timer tmrredraw;
        private ShiftUI.Label lbcodepoints;
        private ShiftUI.Button btntogglemusic;
        private ShiftUI.Label lbsong;
        private ShiftUI.Panel pnltutorial;
        private ShiftUI.Label lbtutorial;
        private ShiftUI.Timer tmrvisualizer;
        internal ShiftUI.Panel pgpong;
        internal ShiftUI.Label lblcountdown;
        internal ShiftUI.Panel ball;
        internal ShiftUI.PictureBox paddleHuman;
        internal ShiftUI.Panel paddleComputer;
        internal ShiftUI.Label lbllevelandtime;
        internal ShiftUI.Label lblstatsY;
        internal ShiftUI.Label lblstatsX;
        internal ShiftUI.Timer pongGameTimer;
        internal ShiftUI.Timer counter;
        internal ShiftUI.Timer tmrcountdown;
    }
}