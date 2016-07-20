namespace ShiftOS
{
    partial class NetworkBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkBrowser));
            this.panel1 = new ShiftUI.Panel();
            this.pnlonline = new ShiftUI.Panel();
            this.btnjoinlobby = new ShiftUI.Button();
            this.lbonlineservers = new ShiftUI.ListBox();
            this.lbonlinedesc = new ShiftUI.Label();
            this.lbonlineheader = new ShiftUI.Label();
            this.button1 = new ShiftUI.Button();
            this.label3 = new ShiftUI.Label();
            this.btnscreen = new ShiftUI.Button();
            this.pnlmynet = new ShiftUI.Panel();
            this.flmodules = new ShiftUI.FlowLayoutPanel();
            this.label5 = new ShiftUI.Label();
            this.label4 = new ShiftUI.Label();
            this.btntier = new ShiftUI.Button();
            this.label2 = new ShiftUI.Label();
            this.label1 = new ShiftUI.Label();
            this.btnstartbattle = new ShiftUI.Button();
            this.lbnets = new ShiftUI.ListBox();
            this.panel2 = new ShiftUI.Panel();
            this.lbnetdesc = new ShiftUI.Label();
            this.lbtitle = new ShiftUI.Label();
            this.tmrcalctotal = new ShiftUI.Timer(this.components);
            this.pgtotalhealth = new ShiftOS.ProgressBarEX();
            this.label6 = new ShiftUI.Label();
            this.label7 = new ShiftUI.Label();
            this.txtmyname = new ShiftUI.TextBox();
            this.txtmydescription = new ShiftUI.TextBox();
            this.panel1.SuspendLayout();
            this.pnlonline.SuspendLayout();
            this.pnlmynet.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.pnlmynet);
            this.panel1.Widgets.Add(this.pnlonline);
            this.panel1.Widgets.Add(this.button1);
            this.panel1.Widgets.Add(this.label3);
            this.panel1.Widgets.Add(this.btnscreen);
            this.panel1.Widgets.Add(this.btntier);
            this.panel1.Widgets.Add(this.label2);
            this.panel1.Widgets.Add(this.label1);
            this.panel1.Widgets.Add(this.btnstartbattle);
            this.panel1.Widgets.Add(this.lbnets);
            this.panel1.Widgets.Add(this.panel2);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 495);
            this.panel1.TabIndex = 0;
            // 
            // pnlonline
            // 
            this.pnlonline.Widgets.Add(this.btnjoinlobby);
            this.pnlonline.Widgets.Add(this.lbonlineservers);
            this.pnlonline.Widgets.Add(this.lbonlinedesc);
            this.pnlonline.Widgets.Add(this.lbonlineheader);
            this.pnlonline.Location = new System.Drawing.Point(12, 12);
            this.pnlonline.Name = "pnlonline";
            this.pnlonline.Size = new System.Drawing.Size(404, 447);
            this.pnlonline.TabIndex = 10;
            // 
            // btnjoinlobby
            // 
            this.btnjoinlobby.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnjoinlobby.Enabled = false;
            this.btnjoinlobby.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnjoinlobby.Location = new System.Drawing.Point(306, 415);
            this.btnjoinlobby.Name = "btnjoinlobby";
            this.btnjoinlobby.Size = new System.Drawing.Size(84, 23);
            this.btnjoinlobby.TabIndex = 8;
            this.btnjoinlobby.Text = "Join Lobby";
            this.btnjoinlobby.UseVisualStyleBackColor = true;
            this.btnjoinlobby.Click += new System.EventHandler(this.btnjoinlobby_Click);
            // 
            // lbonlineservers
            // 
            this.lbonlineservers.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lbonlineservers.BackColor = System.Drawing.Color.Black;
            this.lbonlineservers.ForeColor = System.Drawing.Color.White;
            this.lbonlineservers.FormattingEnabled = true;
            this.lbonlineservers.Location = new System.Drawing.Point(1, 72);
            this.lbonlineservers.Name = "lbonlineservers";
            this.lbonlineservers.Size = new System.Drawing.Size(389, 329);
            this.lbonlineservers.TabIndex = 4;
            this.lbonlineservers.SelectedIndexChanged += new System.EventHandler(this.lbonlineservers_SelectedIndexChanged);
            // 
            // lbonlinedesc
            // 
            this.lbonlinedesc.Location = new System.Drawing.Point(4, 37);
            this.lbonlinedesc.Name = "lbonlinedesc";
            this.lbonlinedesc.Size = new System.Drawing.Size(386, 364);
            this.lbonlinedesc.TabIndex = 3;
            this.lbonlinedesc.Text = "You can battle other Shifters over the Internet by joining a lobby and waiting fo" +
    "r a match to be made. Please select a server from the list below.";
            // 
            // lbonlineheader
            // 
            this.lbonlineheader.AutoSize = true;
            this.lbonlineheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbonlineheader.Location = new System.Drawing.Point(3, 5);
            this.lbonlineheader.Name = "lbonlineheader";
            this.lbonlineheader.Size = new System.Drawing.Size(106, 20);
            this.lbonlineheader.TabIndex = 2;
            this.lbonlineheader.Text = "Online battles";
            // 
            // button1
            // 
            this.button1.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.button1.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(549, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Battle online!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Screen:";
            // 
            // btnscreen
            // 
            this.btnscreen.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnscreen.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnscreen.Location = new System.Drawing.Point(332, 465);
            this.btnscreen.Name = "btnscreen";
            this.btnscreen.Size = new System.Drawing.Size(84, 23);
            this.btnscreen.TabIndex = 7;
            this.btnscreen.Text = "Network List";
            this.btnscreen.UseVisualStyleBackColor = true;
            this.btnscreen.Click += new System.EventHandler(this.btnscreen_Click);
            // 
            // pnlmynet
            // 
            this.pnlmynet.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlmynet.Widgets.Add(this.txtmydescription);
            this.pnlmynet.Widgets.Add(this.txtmyname);
            this.pnlmynet.Widgets.Add(this.label7);
            this.pnlmynet.Widgets.Add(this.label6);
            this.pnlmynet.Widgets.Add(this.pgtotalhealth);
            this.pnlmynet.Widgets.Add(this.flmodules);
            this.pnlmynet.Widgets.Add(this.label5);
            this.pnlmynet.Widgets.Add(this.label4);
            this.pnlmynet.Location = new System.Drawing.Point(12, 12);
            this.pnlmynet.Name = "pnlmynet";
            this.pnlmynet.Size = new System.Drawing.Size(404, 447);
            this.pnlmynet.TabIndex = 6;
            // 
            // flmodules
            // 
            this.flmodules.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.flmodules.FlowDirection = ShiftUI.FlowDirection.TopDown;
            this.flmodules.Location = new System.Drawing.Point(7, 140);
            this.flmodules.Name = "flmodules";
            this.flmodules.Size = new System.Drawing.Size(394, 219);
            this.flmodules.TabIndex = 3;
            this.flmodules.WrapContents = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(397, 58);
            this.label5.TabIndex = 2;
            this.label5.Text = "Below you can see your network\'s total health, as well as a list of any damaged m" +
    "odules\' health. If \'localhost\' is on the list and it\'s health is 0, you cannot p" +
    "articipate in any battles.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "My Network";
            // 
            // btntier
            // 
            this.btntier.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btntier.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btntier.Location = new System.Drawing.Point(47, 465);
            this.btntier.Name = "btntier";
            this.btntier.Size = new System.Drawing.Size(75, 23);
            this.btntier.TabIndex = 5;
            this.btntier.Text = "1";
            this.btntier.UseVisualStyleBackColor = true;
            this.btntier.Click += new System.EventHandler(this.btntier_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tier:";
            // 
            // label1
            // 
            this.label1.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(419, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 71);
            this.label1.TabIndex = 3;
            this.label1.Text = "When you\'re ready, click \'Start Battle\' to begin the hacker battle.";
            // 
            // btnstartbattle
            // 
            this.btnstartbattle.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnstartbattle.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnstartbattle.Location = new System.Drawing.Point(638, 465);
            this.btnstartbattle.Name = "btnstartbattle";
            this.btnstartbattle.Size = new System.Drawing.Size(75, 23);
            this.btnstartbattle.TabIndex = 2;
            this.btnstartbattle.Text = "Start Battle";
            this.btnstartbattle.UseVisualStyleBackColor = true;
            this.btnstartbattle.Click += new System.EventHandler(this.btnstartbattle_Click);
            // 
            // lbnets
            // 
            this.lbnets.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lbnets.BackColor = System.Drawing.Color.Black;
            this.lbnets.ForeColor = System.Drawing.Color.White;
            this.lbnets.FormattingEnabled = true;
            this.lbnets.Location = new System.Drawing.Point(13, 17);
            this.lbnets.Name = "lbnets";
            this.lbnets.Size = new System.Drawing.Size(403, 433);
            this.lbnets.TabIndex = 1;
            this.lbnets.SelectedIndexChanged += new System.EventHandler(this.lbnets_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.panel2.Widgets.Add(this.lbnetdesc);
            this.panel2.Widgets.Add(this.lbtitle);
            this.panel2.Location = new System.Drawing.Point(422, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 326);
            this.panel2.TabIndex = 0;
            // 
            // lbnetdesc
            // 
            this.lbnetdesc.Location = new System.Drawing.Point(5, 36);
            this.lbnetdesc.Name = "lbnetdesc";
            this.lbnetdesc.Size = new System.Drawing.Size(283, 290);
            this.lbnetdesc.TabIndex = 1;
            this.lbnetdesc.Text = resources.GetString("lbnetdesc.Text");
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbtitle.Location = new System.Drawing.Point(4, 4);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(129, 20);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Network Browser";
            // 
            // tmrcalctotal
            // 
            this.tmrcalctotal.Enabled = true;
            this.tmrcalctotal.Tick += new System.EventHandler(this.tmrcalctotal_Tick);
            // 
            // pgtotalhealth
            // 
            this.pgtotalhealth.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pgtotalhealth.BackColor = System.Drawing.Color.Black;
            this.pgtotalhealth.BlockSeparation = 3;
            this.pgtotalhealth.BlockWidth = 5;
            this.pgtotalhealth.Color = System.Drawing.Color.Gray;
            this.pgtotalhealth.Label = "Progress:";
            this.pgtotalhealth.Location = new System.Drawing.Point(7, 98);
            this.pgtotalhealth.MaxValue = 100;
            this.pgtotalhealth.MinValue = 0;
            this.pgtotalhealth.Name = "pgtotalhealth";
            this.pgtotalhealth.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal;
            this.pgtotalhealth.ShowLabel = false;
            this.pgtotalhealth.ShowValue = true;
            this.pgtotalhealth.Size = new System.Drawing.Size(394, 32);
            this.pgtotalhealth.Step = 10;
            this.pgtotalhealth.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous;
            this.pgtotalhealth.TabIndex = 4;
            this.pgtotalhealth.Value = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Your name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description:";
            // 
            // txtmyname
            // 
            this.txtmyname.Location = new System.Drawing.Point(74, 366);
            this.txtmyname.MaxLength = 18;
            this.txtmyname.Name = "txtmyname";
            this.txtmyname.Size = new System.Drawing.Size(186, 20);
            this.txtmyname.TabIndex = 7;
            this.txtmyname.TextChanged += new System.EventHandler(this.txtmyname_TextChanged);
            // 
            // txtmydescription
            // 
            this.txtmydescription.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.txtmydescription.Location = new System.Drawing.Point(74, 397);
            this.txtmydescription.Name = "txtmydescription";
            this.txtmydescription.Size = new System.Drawing.Size(316, 20);
            this.txtmydescription.TabIndex = 8;
            this.txtmydescription.TextChanged += new System.EventHandler(this.txtmydescription_TextChanged);
            // 
            // NetworkBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 495);
            this.Widgets.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "NetworkBrowser";
            this.Text = "NetworkBrowser";
            this.FormClosing += new ShiftUI.FormClosingEventHandler(this.stop_matchmake);
            this.Load += new System.EventHandler(this.NetworkBrowser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlonline.ResumeLayout(false);
            this.pnlonline.PerformLayout();
            this.pnlmynet.ResumeLayout(false);
            this.pnlmynet.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.Label label1;
        private ShiftUI.Button btnstartbattle;
        private ShiftUI.ListBox lbnets;
        private ShiftUI.Panel panel2;
        private ShiftUI.Label lbnetdesc;
        private ShiftUI.Label lbtitle;
        private ShiftUI.Button btntier;
        private ShiftUI.Label label2;
        private ShiftUI.Label label3;
        private ShiftUI.Button btnscreen;
        private ShiftUI.Panel pnlmynet;
        private ShiftUI.FlowLayoutPanel flmodules;
        private ShiftUI.Label label5;
        private ShiftUI.Label label4;
        private ProgressBarEX pgtotalhealth;
        private ShiftUI.Timer tmrcalctotal;
        private ShiftUI.Panel pnlonline;
        private ShiftUI.Label lbonlinedesc;
        private ShiftUI.Label lbonlineheader;
        private ShiftUI.Button button1;
        private ShiftUI.ListBox lbonlineservers;
        private ShiftUI.Button btnjoinlobby;
        private ShiftUI.TextBox txtmydescription;
        private ShiftUI.TextBox txtmyname;
        private ShiftUI.Label label7;
        private ShiftUI.Label label6;
    }
}