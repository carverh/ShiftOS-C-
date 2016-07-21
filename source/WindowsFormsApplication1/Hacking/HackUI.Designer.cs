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
            this.tbui = new System.Windows.Forms.TableLayoutPanel();
            this.pnlenemy = new System.Windows.Forms.Panel();
            this.lbenemycompromised = new System.Windows.Forms.Label();
            this.lbenemystats = new System.Windows.Forms.Label();
            this.txtyourconsole = new System.Windows.Forms.TextBox();
            this.pnlyou = new System.Windows.Forms.Panel();
            this.lbcompromised = new System.Windows.Forms.Label();
            this.lbstats = new System.Windows.Forms.Label();
            this.txtenemyconsole = new System.Windows.Forms.TextBox();
            this.btnnext = new System.Windows.Forms.Button();
            this.pnlbuy = new System.Windows.Forms.Panel();
            this.txthostname = new System.Windows.Forms.TextBox();
            this.lbhostname = new System.Windows.Forms.Label();
            this.txtgrade = new System.Windows.Forms.TextBox();
            this.lbgrade = new System.Windows.Forms.Label();
            this.lbmoduleinfo = new System.Windows.Forms.Label();
            this.cmbbuyable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btndonebuying = new System.Windows.Forms.Button();
            this.pnldefensemanager = new System.Windows.Forms.Panel();
            this.btnbuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbmodules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlpcinfo = new System.Windows.Forms.Panel();
            this.lbtargets = new System.Windows.Forms.Label();
            this.btnpoweroff = new System.Windows.Forms.Button();
            this.btnupgrade = new System.Windows.Forms.Button();
            this.lbpcinfo = new System.Windows.Forms.Label();
            this.lbmoduletitle = new System.Windows.Forms.Label();
            this.btncloseinfo = new System.Windows.Forms.Button();
            this.flcontrols = new System.Windows.Forms.FlowLayoutPanel();
            this.btnaddmodule = new System.Windows.Forms.Button();
            this.lbcodepoints = new System.Windows.Forms.Label();
            this.btntogglemusic = new System.Windows.Forms.Button();
            this.lbsong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgpong = new System.Windows.Forms.Panel();
            this.lblcountdown = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.Panel();
            this.paddleHuman = new System.Windows.Forms.PictureBox();
            this.paddleComputer = new System.Windows.Forms.Panel();
            this.lbllevelandtime = new System.Windows.Forms.Label();
            this.lblstatsY = new System.Windows.Forms.Label();
            this.lblstatsX = new System.Windows.Forms.Label();
            this.pnltutorial = new System.Windows.Forms.Panel();
            this.lbtutorial = new System.Windows.Forms.Label();
            this.tmrplayerhealthdetect = new System.Windows.Forms.Timer(this.components);
            this.tmrenemyhealthdetect = new System.Windows.Forms.Timer(this.components);
            this.tmrredraw = new System.Windows.Forms.Timer(this.components);
            this.tmrvisualizer = new System.Windows.Forms.Timer(this.components);
            this.pongGameTimer = new System.Windows.Forms.Timer(this.components);
            this.counter = new System.Windows.Forms.Timer(this.components);
            this.tmrcountdown = new System.Windows.Forms.Timer(this.components);
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
            this.tbui.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbui.ColumnCount = 2;
            this.tbui.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbui.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbui.Controls.Add(this.pnlenemy, 1, 1);
            this.tbui.Controls.Add(this.txtyourconsole, 0, 1);
            this.tbui.Controls.Add(this.pnlyou, 0, 0);
            this.tbui.Controls.Add(this.txtenemyconsole, 1, 0);
            this.tbui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbui.Location = new System.Drawing.Point(0, 0);
            this.tbui.Name = "tbui";
            this.tbui.RowCount = 2;
            this.tbui.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbui.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbui.Size = new System.Drawing.Size(1339, 710);
            this.tbui.TabIndex = 0;
            // 
            // pnlenemy
            // 
            this.pnlenemy.BackColor = System.Drawing.Color.Black;
            this.pnlenemy.Controls.Add(this.lbenemycompromised);
            this.pnlenemy.Controls.Add(this.lbenemystats);
            this.pnlenemy.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.txtyourconsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtyourconsole.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.pnlyou.Controls.Add(this.lbcompromised);
            this.pnlyou.Controls.Add(this.lbstats);
            this.pnlyou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlyou.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.pnlyou.ForeColor = System.Drawing.Color.White;
            this.pnlyou.Location = new System.Drawing.Point(4, 4);
            this.pnlyou.Name = "pnlyou";
            this.pnlyou.Size = new System.Drawing.Size(662, 347);
            this.pnlyou.TabIndex = 1;
            this.pnlyou.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playfield_MouseDown);
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
            this.txtenemyconsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtenemyconsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtenemyconsole.ForeColor = System.Drawing.Color.LightGreen;
            this.txtenemyconsole.Location = new System.Drawing.Point(673, 4);
            this.txtenemyconsole.Multiline = true;
            this.txtenemyconsole.Name = "txtenemyconsole";
            this.txtenemyconsole.Size = new System.Drawing.Size(662, 347);
            this.txtenemyconsole.TabIndex = 2;
            // 
            // btnnext
            // 
            this.btnnext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.pnlbuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlbuy.Controls.Add(this.txthostname);
            this.pnlbuy.Controls.Add(this.lbhostname);
            this.pnlbuy.Controls.Add(this.txtgrade);
            this.pnlbuy.Controls.Add(this.lbgrade);
            this.pnlbuy.Controls.Add(this.lbmoduleinfo);
            this.pnlbuy.Controls.Add(this.cmbbuyable);
            this.pnlbuy.Controls.Add(this.label4);
            this.pnlbuy.Controls.Add(this.btndonebuying);
            this.pnlbuy.Location = new System.Drawing.Point(7, 405);
            this.pnlbuy.Name = "pnlbuy";
            this.pnlbuy.Size = new System.Drawing.Size(382, 299);
            this.pnlbuy.TabIndex = 6;
            this.pnlbuy.Visible = false;
            // 
            // txthostname
            // 
            this.txthostname.BackColor = System.Drawing.Color.Black;
            this.txthostname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.txtgrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.cmbbuyable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbuyable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btndonebuying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndonebuying.AutoSize = true;
            this.btndonebuying.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btndonebuying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.pnldefensemanager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnldefensemanager.Controls.Add(this.btnbuy);
            this.pnldefensemanager.Controls.Add(this.label3);
            this.pnldefensemanager.Controls.Add(this.cmbmodules);
            this.pnldefensemanager.Controls.Add(this.label1);
            this.pnldefensemanager.Controls.Add(this.button1);
            this.pnldefensemanager.Location = new System.Drawing.Point(395, 424);
            this.pnldefensemanager.Name = "pnldefensemanager";
            this.pnldefensemanager.Size = new System.Drawing.Size(382, 280);
            this.pnldefensemanager.TabIndex = 5;
            this.pnldefensemanager.Visible = false;
            // 
            // btnbuy
            // 
            this.btnbuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuy.AutoSize = true;
            this.btnbuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnbuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.cmbmodules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmodules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.pnlpcinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlpcinfo.Controls.Add(this.lbtargets);
            this.pnlpcinfo.Controls.Add(this.btnpoweroff);
            this.pnlpcinfo.Controls.Add(this.btnupgrade);
            this.pnlpcinfo.Controls.Add(this.lbpcinfo);
            this.pnlpcinfo.Controls.Add(this.lbmoduletitle);
            this.pnlpcinfo.Controls.Add(this.btncloseinfo);
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
            this.btnpoweroff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnpoweroff.AutoSize = true;
            this.btnpoweroff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnpoweroff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnupgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupgrade.AutoSize = true;
            this.btnupgrade.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnupgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btncloseinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btncloseinfo.AutoSize = true;
            this.btncloseinfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btncloseinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.flcontrols.Controls.Add(this.btnaddmodule);
            this.flcontrols.Controls.Add(this.lbcodepoints);
            this.flcontrols.Controls.Add(this.btntogglemusic);
            this.flcontrols.Controls.Add(this.lbsong);
            this.flcontrols.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flcontrols.Location = new System.Drawing.Point(0, 710);
            this.flcontrols.Name = "flcontrols";
            this.flcontrols.Size = new System.Drawing.Size(1339, 31);
            this.flcontrols.TabIndex = 4;
            // 
            // btnaddmodule
            // 
            this.btnaddmodule.AutoSize = true;
            this.btnaddmodule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddmodule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btntogglemusic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btntogglemusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.panel2.Controls.Add(this.pgpong);
            this.panel2.Controls.Add(this.pnltutorial);
            this.panel2.Controls.Add(this.pnlbuy);
            this.panel2.Controls.Add(this.pnlpcinfo);
            this.panel2.Controls.Add(this.pnldefensemanager);
            this.panel2.Controls.Add(this.tbui);
            this.panel2.Controls.Add(this.flcontrols);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1339, 741);
            this.panel2.TabIndex = 1;
            // 
            // pgpong
            // 
            this.pgpong.BackColor = System.Drawing.Color.Black;
            this.pgpong.Controls.Add(this.lblcountdown);
            this.pgpong.Controls.Add(this.ball);
            this.pgpong.Controls.Add(this.paddleHuman);
            this.pgpong.Controls.Add(this.paddleComputer);
            this.pgpong.Controls.Add(this.lbllevelandtime);
            this.pgpong.Controls.Add(this.lblstatsY);
            this.pgpong.Controls.Add(this.lblstatsX);
            this.pgpong.ForeColor = System.Drawing.Color.White;
            this.pgpong.Location = new System.Drawing.Point(0, 0);
            this.pgpong.Name = "pgpong";
            this.pgpong.Size = new System.Drawing.Size(700, 400);
            this.pgpong.TabIndex = 22;
            this.pgpong.Visible = false;
            this.pgpong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pongMain_MouseMove);
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
            this.paddleComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paddleComputer.BackColor = System.Drawing.Color.Gray;
            this.paddleComputer.Location = new System.Drawing.Point(666, 134);
            this.paddleComputer.MaximumSize = new System.Drawing.Size(20, 100);
            this.paddleComputer.Name = "paddleComputer";
            this.paddleComputer.Size = new System.Drawing.Size(20, 100);
            this.paddleComputer.TabIndex = 1;
            // 
            // lbllevelandtime
            // 
            this.lbllevelandtime.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.lblstatsY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblstatsX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.pnltutorial.Controls.Add(this.btnnext);
            this.pnltutorial.Controls.Add(this.lbtutorial);
            this.pnltutorial.Location = new System.Drawing.Point(174, 161);
            this.pnltutorial.Name = "pnltutorial";
            this.pnltutorial.Size = new System.Drawing.Size(363, 187);
            this.pnltutorial.TabIndex = 10;
            this.pnltutorial.Visible = false;
            // 
            // lbtutorial
            // 
            this.lbtutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1339, 741);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HackUI";
            this.Text = "HackUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_Closing);
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

        private System.Windows.Forms.TableLayoutPanel tbui;
        private System.Windows.Forms.Panel pnlyou;
        private System.Windows.Forms.Panel pnlbuy;
        private System.Windows.Forms.TextBox txthostname;
        private System.Windows.Forms.Label lbhostname;
        private System.Windows.Forms.TextBox txtgrade;
        private System.Windows.Forms.Label lbgrade;
        private System.Windows.Forms.Label lbmoduleinfo;
        private System.Windows.Forms.ComboBox cmbbuyable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndonebuying;
        private System.Windows.Forms.Panel pnldefensemanager;
        private System.Windows.Forms.Button btnbuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbmodules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Panel pnlpcinfo;
        private System.Windows.Forms.Label lbtargets;
        private System.Windows.Forms.Button btnpoweroff;
        private System.Windows.Forms.Button btnupgrade;
        private System.Windows.Forms.Label lbpcinfo;
        private System.Windows.Forms.Label lbmoduletitle;
        private System.Windows.Forms.Button btncloseinfo;
        private System.Windows.Forms.FlowLayoutPanel flcontrols;
        private System.Windows.Forms.Button btnaddmodule;
        private System.Windows.Forms.Label lbcompromised;
        private System.Windows.Forms.Label lbstats;
        private System.Windows.Forms.TextBox txtyourconsole;
        private System.Windows.Forms.TextBox txtenemyconsole;
        private System.Windows.Forms.Panel pnlenemy;
        private System.Windows.Forms.Label lbenemycompromised;
        private System.Windows.Forms.Label lbenemystats;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer tmrplayerhealthdetect;
        private System.Windows.Forms.Timer tmrenemyhealthdetect;
        private System.Windows.Forms.Timer tmrredraw;
        private System.Windows.Forms.Label lbcodepoints;
        private System.Windows.Forms.Button btntogglemusic;
        private System.Windows.Forms.Label lbsong;
        private System.Windows.Forms.Panel pnltutorial;
        private System.Windows.Forms.Label lbtutorial;
        private System.Windows.Forms.Timer tmrvisualizer;
        internal System.Windows.Forms.Panel pgpong;
        internal System.Windows.Forms.Label lblcountdown;
        internal System.Windows.Forms.Panel ball;
        internal System.Windows.Forms.PictureBox paddleHuman;
        internal System.Windows.Forms.Panel paddleComputer;
        internal System.Windows.Forms.Label lbllevelandtime;
        internal System.Windows.Forms.Label lblstatsY;
        internal System.Windows.Forms.Label lblstatsX;
        internal System.Windows.Forms.Timer pongGameTimer;
        internal System.Windows.Forms.Timer counter;
        internal System.Windows.Forms.Timer tmrcountdown;
    }
}