namespace ShiftOS
{
    partial class Hacking_YourHealth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hacking_YourHealth));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlpcinfo = new System.Windows.Forms.Panel();
            this.lbtargets = new System.Windows.Forms.Label();
            this.btnpoweroff = new System.Windows.Forms.Button();
            this.btnupgrade = new System.Windows.Forms.Button();
            this.lbpcinfo = new System.Windows.Forms.Label();
            this.lbmoduletitle = new System.Windows.Forms.Label();
            this.btncloseinfo = new System.Windows.Forms.Button();
            this.pnldefensemanager = new System.Windows.Forms.Panel();
            this.btnbuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbmodules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlbuy = new System.Windows.Forms.Panel();
            this.txthostname = new System.Windows.Forms.TextBox();
            this.lbhostname = new System.Windows.Forms.Label();
            this.txtgrade = new System.Windows.Forms.TextBox();
            this.lbgrade = new System.Windows.Forms.Label();
            this.lbmoduleinfo = new System.Windows.Forms.Label();
            this.cmbbuyable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btndonebuying = new System.Windows.Forms.Button();
            this.flcontrols = new System.Windows.Forms.FlowLayoutPanel();
            this.btnaddmodule = new System.Windows.Forms.Button();
            this.lbcompromised = new System.Windows.Forms.Label();
            this.lbstats = new System.Windows.Forms.Label();
            this.tmrhealthdetect = new System.Windows.Forms.Timer(this.components);
            this.tmrredraw = new System.Windows.Forms.Timer(this.components);
            this.lbtutorial = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlpcinfo.SuspendLayout();
            this.pnldefensemanager.SuspendLayout();
            this.pnlbuy.SuspendLayout();
            this.flcontrols.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pnlbuy);
            this.panel1.Controls.Add(this.pnldefensemanager);
            this.panel1.Controls.Add(this.btnnext);
            this.panel1.Controls.Add(this.lbtutorial);
            this.panel1.Controls.Add(this.pnlpcinfo);
            this.panel1.Controls.Add(this.flcontrols);
            this.panel1.Controls.Add(this.lbcompromised);
            this.panel1.Controls.Add(this.lbstats);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 461);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.boundpaint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playfield_MouseDown);
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
            this.pnlpcinfo.Location = new System.Drawing.Point(399, 144);
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
            // pnldefensemanager
            // 
            this.pnldefensemanager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnldefensemanager.Controls.Add(this.btnbuy);
            this.pnldefensemanager.Controls.Add(this.label3);
            this.pnldefensemanager.Controls.Add(this.cmbmodules);
            this.pnldefensemanager.Controls.Add(this.label1);
            this.pnldefensemanager.Controls.Add(this.button1);
            this.pnldefensemanager.Location = new System.Drawing.Point(3, 147);
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
            this.pnlbuy.Location = new System.Drawing.Point(3, 128);
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
            // flcontrols
            // 
            this.flcontrols.Controls.Add(this.btnaddmodule);
            this.flcontrols.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flcontrols.Location = new System.Drawing.Point(0, 430);
            this.flcontrols.Name = "flcontrols";
            this.flcontrols.Size = new System.Drawing.Size(793, 31);
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
            // lbcompromised
            // 
            this.lbcompromised.AutoSize = true;
            this.lbcompromised.Location = new System.Drawing.Point(251, 85);
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
            // tmrhealthdetect
            // 
            this.tmrhealthdetect.Tick += new System.EventHandler(this.tmrhealthdetect_Tick);
            // 
            // tmrredraw
            // 
            this.tmrredraw.Interval = 5000;
            this.tmrredraw.Tick += new System.EventHandler(this.tmrredraw_Tick);
            // 
            // lbtutorial
            // 
            this.lbtutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtutorial.Location = new System.Drawing.Point(411, 13);
            this.lbtutorial.Name = "lbtutorial";
            this.lbtutorial.Size = new System.Drawing.Size(367, 86);
            this.lbtutorial.TabIndex = 8;
            this.lbtutorial.Text = resources.GetString("lbtutorial.Text");
            this.lbtutorial.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbtutorial.Visible = false;
            // 
            // btnnext
            // 
            this.btnnext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(712, 102);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(66, 23);
            this.btnnext.TabIndex = 9;
            this.btnnext.Text = "Next >>";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Visible = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // Hacking_YourHealth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 461);
            this.Controls.Add(this.panel1);
            this.Name = "Hacking_YourHealth";
            this.Text = "Hacking_YourHealth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_Closing);
            this.Load += new System.EventHandler(this.Hacking_YourHealth_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlpcinfo.ResumeLayout(false);
            this.pnlpcinfo.PerformLayout();
            this.pnldefensemanager.ResumeLayout(false);
            this.pnldefensemanager.PerformLayout();
            this.pnlbuy.ResumeLayout(false);
            this.pnlbuy.PerformLayout();
            this.flcontrols.ResumeLayout(false);
            this.flcontrols.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbstats;
        private System.Windows.Forms.Timer tmrhealthdetect;
        private System.Windows.Forms.Label lbcompromised;
        private System.Windows.Forms.FlowLayoutPanel flcontrols;
        private System.Windows.Forms.Button btnaddmodule;
        private System.Windows.Forms.Panel pnldefensemanager;
        private System.Windows.Forms.ComboBox cmbmodules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnbuy;
        private System.Windows.Forms.Timer tmrredraw;
        private System.Windows.Forms.Panel pnlbuy;
        private System.Windows.Forms.TextBox txtgrade;
        private System.Windows.Forms.Label lbgrade;
        private System.Windows.Forms.Label lbmoduleinfo;
        private System.Windows.Forms.ComboBox cmbbuyable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndonebuying;
        private System.Windows.Forms.TextBox txthostname;
        private System.Windows.Forms.Label lbhostname;
        private System.Windows.Forms.Panel pnlpcinfo;
        private System.Windows.Forms.Button btnpoweroff;
        private System.Windows.Forms.Button btnupgrade;
        private System.Windows.Forms.Label lbpcinfo;
        private System.Windows.Forms.Label lbmoduletitle;
        private System.Windows.Forms.Button btncloseinfo;
        private System.Windows.Forms.Label lbtargets;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Label lbtutorial;
    }
}