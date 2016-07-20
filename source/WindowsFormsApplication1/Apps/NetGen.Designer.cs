namespace ShiftOS
{
    partial class NetGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetGen));
            this.panel1 = new ShiftUI.Panel();
            this.pnlnetdesign = new ShiftUI.Panel();
            this.pnlpcinfo = new ShiftUI.Panel();
            this.btndelete = new ShiftUI.Button();
            this.lbpcinfo = new ShiftUI.Label();
            this.lbmoduletitle = new ShiftUI.Label();
            this.btncloseinfo = new ShiftUI.Button();
            this.flowLayoutPanel1 = new ShiftUI.FlowLayoutPanel();
            this.btnaddmodule = new ShiftUI.Button();
            this.pnlbuy = new ShiftUI.Panel();
            this.txthostname = new ShiftUI.TextBox();
            this.lbhostname = new ShiftUI.Label();
            this.txtgrade = new ShiftUI.TextBox();
            this.lbgrade = new ShiftUI.Label();
            this.lbmoduleinfo = new ShiftUI.Label();
            this.cmbbuyable = new ShiftUI.ComboBox();
            this.label4 = new ShiftUI.Label();
            this.btndonebuying = new ShiftUI.Button();
            this.pnlnetinf = new ShiftUI.Panel();
            this.label6 = new ShiftUI.Label();
            this.cbdifficulty = new ShiftUI.ComboBox();
            this.txtfspeed = new ShiftUI.TextBox();
            this.label5 = new ShiftUI.Label();
            this.txtfskill = new ShiftUI.TextBox();
            this.label3 = new ShiftUI.Label();
            this.txtnetdesc = new ShiftUI.TextBox();
            this.label2 = new ShiftUI.Label();
            this.txtnetname = new ShiftUI.TextBox();
            this.label1 = new ShiftUI.Label();
            this.flbuttons = new ShiftUI.FlowLayoutPanel();
            this.btnnext = new ShiftUI.Button();
            this.btnback = new ShiftUI.Button();
            this.pnlnetinfo = new ShiftUI.Panel();
            this.lbdescription = new ShiftUI.Label();
            this.lbtitle = new ShiftUI.Label();
            this.btnloadfromtemplate = new ShiftUI.Button();
            this.pnltemplates = new ShiftUI.Panel();
            this.label9 = new ShiftUI.Label();
            this.cbnets = new ShiftUI.ComboBox();
            this.label10 = new ShiftUI.Label();
            this.btnrecreate = new ShiftUI.Button();
            this.panel1.SuspendLayout();
            this.pnlnetdesign.SuspendLayout();
            this.pnlpcinfo.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlbuy.SuspendLayout();
            this.pnlnetinf.SuspendLayout();
            this.flbuttons.SuspendLayout();
            this.pnlnetinfo.SuspendLayout();
            this.pnltemplates.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.pnltemplates);
            this.panel1.Widgets.Add(this.pnlnetdesign);
            this.panel1.Widgets.Add(this.pnlnetinf);
            this.panel1.Widgets.Add(this.flbuttons);
            this.panel1.Widgets.Add(this.pnlnetinfo);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 591);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new ShiftUI.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlnetdesign
            // 
            this.pnlnetdesign.Widgets.Add(this.pnlpcinfo);
            this.pnlnetdesign.Widgets.Add(this.flowLayoutPanel1);
            this.pnlnetdesign.Widgets.Add(this.pnlbuy);
            this.pnlnetdesign.Dock = ShiftUI.DockStyle.Fill;
            this.pnlnetdesign.Location = new System.Drawing.Point(0, 76);
            this.pnlnetdesign.Name = "pnlnetdesign";
            this.pnlnetdesign.Size = new System.Drawing.Size(894, 484);
            this.pnlnetdesign.TabIndex = 6;
            this.pnlnetdesign.MouseDown += new ShiftUI.MouseEventHandler(this.place_module);
            // 
            // pnlpcinfo
            // 
            this.pnlpcinfo.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.pnlpcinfo.Widgets.Add(this.btndelete);
            this.pnlpcinfo.Widgets.Add(this.lbpcinfo);
            this.pnlpcinfo.Widgets.Add(this.lbmoduletitle);
            this.pnlpcinfo.Widgets.Add(this.btncloseinfo);
            this.pnlpcinfo.Location = new System.Drawing.Point(43, 167);
            this.pnlpcinfo.Name = "pnlpcinfo";
            this.pnlpcinfo.Size = new System.Drawing.Size(382, 280);
            this.pnlpcinfo.TabIndex = 9;
            this.pnlpcinfo.Visible = false;
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btndelete.AutoSize = true;
            this.btndelete.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btndelete.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btndelete.Location = new System.Drawing.Point(106, 254);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(59, 23);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Widgets.Add(this.btnaddmodule);
            this.flowLayoutPanel1.Dock = ShiftUI.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 453);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(894, 31);
            this.flowLayoutPanel1.TabIndex = 8;
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
            this.pnlbuy.Location = new System.Drawing.Point(3, 148);
            this.pnlbuy.Name = "pnlbuy";
            this.pnlbuy.Size = new System.Drawing.Size(382, 299);
            this.pnlbuy.TabIndex = 7;
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
            this.label4.Text = "Add Module";
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
            // pnlnetinf
            // 
            this.pnlnetinf.Widgets.Add(this.label6);
            this.pnlnetinf.Widgets.Add(this.cbdifficulty);
            this.pnlnetinf.Widgets.Add(this.txtfspeed);
            this.pnlnetinf.Widgets.Add(this.label5);
            this.pnlnetinf.Widgets.Add(this.txtfskill);
            this.pnlnetinf.Widgets.Add(this.label3);
            this.pnlnetinf.Widgets.Add(this.txtnetdesc);
            this.pnlnetinf.Widgets.Add(this.label2);
            this.pnlnetinf.Widgets.Add(this.txtnetname);
            this.pnlnetinf.Widgets.Add(this.label1);
            this.pnlnetinf.Dock = ShiftUI.DockStyle.Fill;
            this.pnlnetinf.Location = new System.Drawing.Point(0, 76);
            this.pnlnetinf.Name = "pnlnetinf";
            this.pnlnetinf.Size = new System.Drawing.Size(894, 484);
            this.pnlnetinf.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 11);
            this.label6.TabIndex = 11;
            this.label6.Text = "Difficulty (Tier)";
            // 
            // cbdifficulty
            // 
            this.cbdifficulty.BackColor = System.Drawing.Color.Black;
            this.cbdifficulty.DropDownStyle = ShiftUI.ComboBoxStyle.DropDownList;
            this.cbdifficulty.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.cbdifficulty.ForeColor = System.Drawing.Color.Green;
            this.cbdifficulty.FormattingEnabled = true;
            this.cbdifficulty.Items.AddRange(new object[] {
            "easy",
            "medium",
            "hard"});
            this.cbdifficulty.Location = new System.Drawing.Point(170, 222);
            this.cbdifficulty.Name = "cbdifficulty";
            this.cbdifficulty.Size = new System.Drawing.Size(121, 19);
            this.cbdifficulty.TabIndex = 10;
            // 
            // txtfspeed
            // 
            this.txtfspeed.BackColor = System.Drawing.Color.Black;
            this.txtfspeed.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtfspeed.ForeColor = System.Drawing.Color.Green;
            this.txtfspeed.Location = new System.Drawing.Point(142, 172);
            this.txtfspeed.Name = "txtfspeed";
            this.txtfspeed.Size = new System.Drawing.Size(41, 18);
            this.txtfspeed.TabIndex = 9;
            this.txtfspeed.TextChanged += new System.EventHandler(this.txtfspeed_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.TabIndex = 8;
            this.label5.Text = "F. Speed";
            // 
            // txtfskill
            // 
            this.txtfskill.BackColor = System.Drawing.Color.Black;
            this.txtfskill.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtfskill.ForeColor = System.Drawing.Color.Green;
            this.txtfskill.Location = new System.Drawing.Point(142, 146);
            this.txtfskill.Name = "txtfskill";
            this.txtfskill.Size = new System.Drawing.Size(41, 18);
            this.txtfskill.TabIndex = 7;
            this.txtfskill.TextChanged += new System.EventHandler(this.txtfskill_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 11);
            this.label3.TabIndex = 6;
            this.label3.Text = "F. Skill";
            // 
            // txtnetdesc
            // 
            this.txtnetdesc.BackColor = System.Drawing.Color.Black;
            this.txtnetdesc.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtnetdesc.ForeColor = System.Drawing.Color.Green;
            this.txtnetdesc.Location = new System.Drawing.Point(142, 80);
            this.txtnetdesc.Name = "txtnetdesc";
            this.txtnetdesc.Size = new System.Drawing.Size(492, 18);
            this.txtnetdesc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 11);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // txtnetname
            // 
            this.txtnetname.BackColor = System.Drawing.Color.Black;
            this.txtnetname.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtnetname.ForeColor = System.Drawing.Color.Green;
            this.txtnetname.Location = new System.Drawing.Point(142, 56);
            this.txtnetname.Name = "txtnetname";
            this.txtnetname.Size = new System.Drawing.Size(231, 18);
            this.txtnetname.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 11);
            this.label1.TabIndex = 2;
            this.label1.Text = "Network Name:";
            // 
            // flbuttons
            // 
            this.flbuttons.Widgets.Add(this.btnnext);
            this.flbuttons.Widgets.Add(this.btnback);
            this.flbuttons.Dock = ShiftUI.DockStyle.Bottom;
            this.flbuttons.FlowDirection = ShiftUI.FlowDirection.RightToLeft;
            this.flbuttons.Location = new System.Drawing.Point(0, 560);
            this.flbuttons.Name = "flbuttons";
            this.flbuttons.Size = new System.Drawing.Size(894, 31);
            this.flbuttons.TabIndex = 0;
            // 
            // btnnext
            // 
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(846, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(45, 23);
            this.btnnext.TabIndex = 0;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnback
            // 
            this.btnback.AutoSize = true;
            this.btnback.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnback.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnback.Location = new System.Drawing.Point(795, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(45, 23);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pnlnetinfo
            // 
            this.pnlnetinfo.Widgets.Add(this.btnloadfromtemplate);
            this.pnlnetinfo.Widgets.Add(this.lbdescription);
            this.pnlnetinfo.Widgets.Add(this.lbtitle);
            this.pnlnetinfo.Dock = ShiftUI.DockStyle.Top;
            this.pnlnetinfo.Location = new System.Drawing.Point(0, 0);
            this.pnlnetinfo.Name = "pnlnetinfo";
            this.pnlnetinfo.Size = new System.Drawing.Size(894, 76);
            this.pnlnetinfo.TabIndex = 1;
            // 
            // lbdescription
            // 
            this.lbdescription.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lbdescription.Location = new System.Drawing.Point(15, 31);
            this.lbdescription.Name = "lbdescription";
            this.lbdescription.Size = new System.Drawing.Size(867, 36);
            this.lbdescription.TabIndex = 1;
            this.lbdescription.Text = "Information about the network.";
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Lucida Console", 13F);
            this.lbtitle.Location = new System.Drawing.Point(12, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(217, 18);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Network Information";
            // 
            // btnloadfromtemplate
            // 
            this.btnloadfromtemplate.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnloadfromtemplate.AutoSize = true;
            this.btnloadfromtemplate.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnloadfromtemplate.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnloadfromtemplate.Location = new System.Drawing.Point(683, 47);
            this.btnloadfromtemplate.Name = "btnloadfromtemplate";
            this.btnloadfromtemplate.Size = new System.Drawing.Size(199, 23);
            this.btnloadfromtemplate.TabIndex = 2;
            this.btnloadfromtemplate.Text = "This button breaks things.";
            this.btnloadfromtemplate.UseVisualStyleBackColor = true;
            this.btnloadfromtemplate.Visible = false;
            this.btnloadfromtemplate.Click += new System.EventHandler(this.btnloadfromtemplate_Click);
            // 
            // pnltemplates
            // 
            this.pnltemplates.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.pnltemplates.Widgets.Add(this.label9);
            this.pnltemplates.Widgets.Add(this.cbnets);
            this.pnltemplates.Widgets.Add(this.label10);
            this.pnltemplates.Widgets.Add(this.btnrecreate);
            this.pnltemplates.Location = new System.Drawing.Point(256, 146);
            this.pnltemplates.Name = "pnltemplates";
            this.pnltemplates.Size = new System.Drawing.Size(382, 299);
            this.pnltemplates.TabIndex = 8;
            this.pnltemplates.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 156);
            this.label9.TabIndex = 6;
            this.label9.Text = "Please choose a network from the above list. Net Generator will attempt to grab d" +
    "ata about the network and recreate it for you.";
            // 
            // cbnets
            // 
            this.cbnets.BackColor = System.Drawing.Color.Black;
            this.cbnets.DropDownStyle = ShiftUI.ComboBoxStyle.DropDownList;
            this.cbnets.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.cbnets.ForeColor = System.Drawing.Color.White;
            this.cbnets.FormattingEnabled = true;
            this.cbnets.Location = new System.Drawing.Point(12, 38);
            this.cbnets.Name = "cbnets";
            this.cbnets.Size = new System.Drawing.Size(360, 19);
            this.cbnets.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 11);
            this.label10.TabIndex = 2;
            this.label10.Text = "Load from Network";
            // 
            // btnrecreate
            // 
            this.btnrecreate.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnrecreate.AutoSize = true;
            this.btnrecreate.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnrecreate.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnrecreate.Location = new System.Drawing.Point(334, 273);
            this.btnrecreate.Name = "btnrecreate";
            this.btnrecreate.Size = new System.Drawing.Size(45, 23);
            this.btnrecreate.TabIndex = 1;
            this.btnrecreate.Text = "Done";
            this.btnrecreate.UseVisualStyleBackColor = true;
            this.btnrecreate.Click += new System.EventHandler(this.btnrecreate_Click);
            // 
            // NetGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(894, 591);
            this.Widgets.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "NetGen";
            this.Text = "NetGen";
            this.Load += new System.EventHandler(this.NetGen_Load);
            this.panel1.ResumeLayout(false);
            this.pnlnetdesign.ResumeLayout(false);
            this.pnlpcinfo.ResumeLayout(false);
            this.pnlpcinfo.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlbuy.ResumeLayout(false);
            this.pnlbuy.PerformLayout();
            this.pnlnetinf.ResumeLayout(false);
            this.pnlnetinf.PerformLayout();
            this.flbuttons.ResumeLayout(false);
            this.flbuttons.PerformLayout();
            this.pnlnetinfo.ResumeLayout(false);
            this.pnlnetinfo.PerformLayout();
            this.pnltemplates.ResumeLayout(false);
            this.pnltemplates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.FlowLayoutPanel flbuttons;
        private ShiftUI.TextBox txtnetname;
        private ShiftUI.Label label1;
        private ShiftUI.Panel pnlnetinfo;
        private ShiftUI.Label lbdescription;
        private ShiftUI.Label lbtitle;
        private ShiftUI.TextBox txtnetdesc;
        private ShiftUI.Label label2;
        private ShiftUI.Button btnnext;
        private ShiftUI.Button btnback;
        private ShiftUI.Panel pnlnetdesign;
        private ShiftUI.Panel pnlnetinf;
        private ShiftUI.FlowLayoutPanel flowLayoutPanel1;
        private ShiftUI.Button btnaddmodule;
        private ShiftUI.Panel pnlbuy;
        private ShiftUI.TextBox txthostname;
        private ShiftUI.Label lbhostname;
        private ShiftUI.TextBox txtgrade;
        private ShiftUI.Label lbgrade;
        private ShiftUI.Label lbmoduleinfo;
        private ShiftUI.ComboBox cmbbuyable;
        private ShiftUI.Label label4;
        private ShiftUI.Button btndonebuying;
        private ShiftUI.Panel pnlpcinfo;
        private ShiftUI.Button btndelete;
        private ShiftUI.Label lbpcinfo;
        private ShiftUI.Label lbmoduletitle;
        private ShiftUI.Button btncloseinfo;
        private ShiftUI.Label label6;
        private ShiftUI.ComboBox cbdifficulty;
        private ShiftUI.TextBox txtfspeed;
        private ShiftUI.Label label5;
        private ShiftUI.TextBox txtfskill;
        private ShiftUI.Label label3;
        private ShiftUI.Button btnloadfromtemplate;
        private ShiftUI.Panel pnltemplates;
        private ShiftUI.Label label9;
        private ShiftUI.ComboBox cbnets;
        private ShiftUI.Label label10;
        private ShiftUI.Button btnrecreate;
    }
}