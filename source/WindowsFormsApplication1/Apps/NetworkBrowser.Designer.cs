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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnscreen = new System.Windows.Forms.Button();
            this.pnlmynet = new System.Windows.Forms.Panel();
            this.pgtotalhealth = new ShiftOS.ProgressBarEX();
            this.flmodules = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btntier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnstartbattle = new System.Windows.Forms.Button();
            this.lbnets = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbnetdesc = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.tmrcalctotal = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnlonline = new System.Windows.Forms.Panel();
            this.lbonlinedesc = new System.Windows.Forms.Label();
            this.lbonlineheader = new System.Windows.Forms.Label();
            this.lbonlineservers = new System.Windows.Forms.ListBox();
            this.btnjoinlobby = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlmynet.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlonline.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlonline);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnscreen);
            this.panel1.Controls.Add(this.pnlmynet);
            this.panel1.Controls.Add(this.btntier);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnstartbattle);
            this.panel1.Controls.Add(this.lbnets);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 495);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Screen:";
            // 
            // btnscreen
            // 
            this.btnscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.pnlmynet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlmynet.Controls.Add(this.pgtotalhealth);
            this.pnlmynet.Controls.Add(this.flmodules);
            this.pnlmynet.Controls.Add(this.label5);
            this.pnlmynet.Controls.Add(this.label4);
            this.pnlmynet.Location = new System.Drawing.Point(12, 12);
            this.pnlmynet.Name = "pnlmynet";
            this.pnlmynet.Size = new System.Drawing.Size(404, 447);
            this.pnlmynet.TabIndex = 6;
            // 
            // pgtotalhealth
            // 
            this.pgtotalhealth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // flmodules
            // 
            this.flmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flmodules.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flmodules.Location = new System.Drawing.Point(7, 140);
            this.flmodules.Name = "flmodules";
            this.flmodules.Size = new System.Drawing.Size(394, 298);
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
            this.btntier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btntier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tier:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(419, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 71);
            this.label1.TabIndex = 3;
            this.label1.Text = "When you\'re ready, click \'Start Battle\' to begin the hacker battle.";
            // 
            // btnstartbattle
            // 
            this.btnstartbattle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstartbattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lbnets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbnetdesc);
            this.panel2.Controls.Add(this.lbtitle);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(549, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Battle online!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlonline
            // 
            this.pnlonline.Controls.Add(this.btnjoinlobby);
            this.pnlonline.Controls.Add(this.lbonlineservers);
            this.pnlonline.Controls.Add(this.lbonlinedesc);
            this.pnlonline.Controls.Add(this.lbonlineheader);
            this.pnlonline.Location = new System.Drawing.Point(12, 12);
            this.pnlonline.Name = "pnlonline";
            this.pnlonline.Size = new System.Drawing.Size(404, 447);
            this.pnlonline.TabIndex = 10;
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
            // lbonlineservers
            // 
            this.lbonlineservers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbonlineservers.BackColor = System.Drawing.Color.Black;
            this.lbonlineservers.ForeColor = System.Drawing.Color.White;
            this.lbonlineservers.FormattingEnabled = true;
            this.lbonlineservers.Location = new System.Drawing.Point(1, 72);
            this.lbonlineservers.Name = "lbonlineservers";
            this.lbonlineservers.Size = new System.Drawing.Size(389, 329);
            this.lbonlineservers.TabIndex = 4;
            this.lbonlineservers.SelectedIndexChanged += new System.EventHandler(this.lbonlineservers_SelectedIndexChanged);
            // 
            // btnjoinlobby
            // 
            this.btnjoinlobby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnjoinlobby.Enabled = false;
            this.btnjoinlobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnjoinlobby.Location = new System.Drawing.Point(306, 415);
            this.btnjoinlobby.Name = "btnjoinlobby";
            this.btnjoinlobby.Size = new System.Drawing.Size(84, 23);
            this.btnjoinlobby.TabIndex = 8;
            this.btnjoinlobby.Text = "Join Lobby";
            this.btnjoinlobby.UseVisualStyleBackColor = true;
            this.btnjoinlobby.Click += new System.EventHandler(this.btnjoinlobby_Click);
            // 
            // NetworkBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 495);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "NetworkBrowser";
            this.Text = "NetworkBrowser";
            this.Load += new System.EventHandler(this.NetworkBrowser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlmynet.ResumeLayout(false);
            this.pnlmynet.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlonline.ResumeLayout(false);
            this.pnlonline.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnstartbattle;
        private System.Windows.Forms.ListBox lbnets;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbnetdesc;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Button btntier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnscreen;
        private System.Windows.Forms.Panel pnlmynet;
        private System.Windows.Forms.FlowLayoutPanel flmodules;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ProgressBarEX pgtotalhealth;
        private System.Windows.Forms.Timer tmrcalctotal;
        private System.Windows.Forms.Panel pnlonline;
        private System.Windows.Forms.Label lbonlinedesc;
        private System.Windows.Forms.Label lbonlineheader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbonlineservers;
        private System.Windows.Forms.Button btnjoinlobby;
    }
}