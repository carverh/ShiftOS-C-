namespace ShiftOS.FinalMission
{
    partial class ChooseYourApproach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseYourApproach));
            this.pnlmain = new System.Windows.Forms.Panel();
            this.lbdesc = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.pnldescription = new System.Windows.Forms.Panel();
            this.choicedesc = new System.Windows.Forms.Label();
            this.fldescbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnbegin = new System.Windows.Forms.Button();
            this.choicetitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlchoices = new System.Windows.Forms.Panel();
            this.choiceControl3 = new ShiftOS.FinalMission.ChoiceControl();
            this.choiceControl2 = new ShiftOS.FinalMission.ChoiceControl();
            this.cc_sidewithdevx = new ShiftOS.FinalMission.ChoiceControl();
            this.pnlconfirm = new System.Windows.Forms.Panel();
            this.lbconfirm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlmain.SuspendLayout();
            this.pnldescription.SuspendLayout();
            this.fldescbuttons.SuspendLayout();
            this.pnlchoices.SuspendLayout();
            this.pnlconfirm.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlmain
            // 
            this.pnlmain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlmain.Controls.Add(this.lbdesc);
            this.pnlmain.Controls.Add(this.lbtitle);
            this.pnlmain.Location = new System.Drawing.Point(318, 27);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(692, 178);
            this.pnlmain.TabIndex = 0;
            // 
            // lbdesc
            // 
            this.lbdesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbdesc.Location = new System.Drawing.Point(0, 38);
            this.lbdesc.Name = "lbdesc";
            this.lbdesc.Size = new System.Drawing.Size(692, 140);
            this.lbdesc.TabIndex = 1;
            this.lbdesc.Text = resources.GetString("lbdesc.Text");
            this.lbdesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbdesc.Click += new System.EventHandler(this.lbdesc_Click);
            // 
            // lbtitle
            // 
            this.lbtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbtitle.Font = new System.Drawing.Font("Lucida Console", 19F);
            this.lbtitle.Location = new System.Drawing.Point(0, 0);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(692, 38);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Choose your approach";
            this.lbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnldescription
            // 
            this.pnldescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldescription.Controls.Add(this.choicedesc);
            this.pnldescription.Controls.Add(this.fldescbuttons);
            this.pnldescription.Controls.Add(this.choicetitle);
            this.pnldescription.Location = new System.Drawing.Point(318, 357);
            this.pnldescription.Name = "pnldescription";
            this.pnldescription.Size = new System.Drawing.Size(692, 178);
            this.pnldescription.TabIndex = 1;
            // 
            // choicedesc
            // 
            this.choicedesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choicedesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.choicedesc.Location = new System.Drawing.Point(0, 38);
            this.choicedesc.Name = "choicedesc";
            this.choicedesc.Size = new System.Drawing.Size(692, 103);
            this.choicedesc.TabIndex = 1;
            this.choicedesc.Text = "DevX caused all of this. He hijacked your computer and put ShiftOS on it, and mad" +
    "e you work harder than ever just to make it usable.\r\n\r\nNow it\'s time to use all " +
    "your skills to take him down.";
            this.choicedesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fldescbuttons
            // 
            this.fldescbuttons.Controls.Add(this.btnbegin);
            this.fldescbuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fldescbuttons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fldescbuttons.Location = new System.Drawing.Point(0, 141);
            this.fldescbuttons.Name = "fldescbuttons";
            this.fldescbuttons.Size = new System.Drawing.Size(692, 37);
            this.fldescbuttons.TabIndex = 2;
            // 
            // btnbegin
            // 
            this.btnbegin.AutoSize = true;
            this.btnbegin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnbegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbegin.Location = new System.Drawing.Point(3, 3);
            this.btnbegin.Name = "btnbegin";
            this.btnbegin.Size = new System.Drawing.Size(62, 32);
            this.btnbegin.TabIndex = 0;
            this.btnbegin.Text = "Begin";
            this.btnbegin.UseVisualStyleBackColor = true;
            this.btnbegin.Click += new System.EventHandler(this.btnbegin_Click);
            // 
            // choicetitle
            // 
            this.choicetitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.choicetitle.Font = new System.Drawing.Font("Lucida Console", 19F);
            this.choicetitle.Location = new System.Drawing.Point(0, 0);
            this.choicetitle.Name = "choicetitle";
            this.choicetitle.Size = new System.Drawing.Size(692, 38);
            this.choicetitle.TabIndex = 0;
            this.choicetitle.Text = "Defeat DevX";
            this.choicetitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(648, -76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 2;
            // 
            // pnlchoices
            // 
            this.pnlchoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlchoices.Controls.Add(this.choiceControl3);
            this.pnlchoices.Controls.Add(this.choiceControl2);
            this.pnlchoices.Controls.Add(this.cc_sidewithdevx);
            this.pnlchoices.Location = new System.Drawing.Point(510, 228);
            this.pnlchoices.MaximumSize = new System.Drawing.Size(338, 91);
            this.pnlchoices.MinimumSize = new System.Drawing.Size(338, 91);
            this.pnlchoices.Name = "pnlchoices";
            this.pnlchoices.Size = new System.Drawing.Size(338, 91);
            this.pnlchoices.TabIndex = 3;
            // 
            // choiceControl3
            // 
            this.choiceControl3.ChoiceName = "Destroy DevX";
            this.choiceControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choiceControl3.Location = new System.Drawing.Point(112, 0);
            this.choiceControl3.Name = "choiceControl3";
            this.choiceControl3.Number = 2;
            this.choiceControl3.Size = new System.Drawing.Size(114, 91);
            this.choiceControl3.TabIndex = 2;
            this.choiceControl3.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // choiceControl2
            // 
            this.choiceControl2.ChoiceName = "End it all";
            this.choiceControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.choiceControl2.Location = new System.Drawing.Point(226, 0);
            this.choiceControl2.Name = "choiceControl2";
            this.choiceControl2.Number = 3;
            this.choiceControl2.Size = new System.Drawing.Size(112, 91);
            this.choiceControl2.TabIndex = 1;
            this.choiceControl2.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // cc_sidewithdevx
            // 
            this.cc_sidewithdevx.ChoiceName = "Side with DevX";
            this.cc_sidewithdevx.Dock = System.Windows.Forms.DockStyle.Left;
            this.cc_sidewithdevx.Location = new System.Drawing.Point(0, 0);
            this.cc_sidewithdevx.Name = "cc_sidewithdevx";
            this.cc_sidewithdevx.Number = 1;
            this.cc_sidewithdevx.Size = new System.Drawing.Size(112, 91);
            this.cc_sidewithdevx.TabIndex = 0;
            this.cc_sidewithdevx.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // pnlconfirm
            // 
            this.pnlconfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlconfirm.Controls.Add(this.lbconfirm);
            this.pnlconfirm.Controls.Add(this.flowLayoutPanel1);
            this.pnlconfirm.Controls.Add(this.label2);
            this.pnlconfirm.Location = new System.Drawing.Point(56, 27);
            this.pnlconfirm.Name = "pnlconfirm";
            this.pnlconfirm.Size = new System.Drawing.Size(1220, 449);
            this.pnlconfirm.TabIndex = 4;
            this.pnlconfirm.Visible = false;
            // 
            // lbconfirm
            // 
            this.lbconfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbconfirm.Location = new System.Drawing.Point(0, 38);
            this.lbconfirm.Name = "lbconfirm";
            this.lbconfirm.Size = new System.Drawing.Size(1220, 374);
            this.lbconfirm.TabIndex = 1;
            this.lbconfirm.Text = resources.GetString("lbconfirm.Text");
            this.lbconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 19F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1220, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start This Mission";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1233, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Toggle Music";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1210, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "Return to Desktop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 412);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1220, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 32);
            this.button3.TabIndex = 0;
            this.button3.Text = "Ready.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChooseYourApproach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1328, 547);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlconfirm);
            this.Controls.Add(this.pnlchoices);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnldescription);
            this.Controls.Add(this.pnlmain);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChooseYourApproach";
            this.Text = "ChooseYourApproach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClose);
            this.Load += new System.EventHandler(this.ChooseYourApproach_Load);
            this.pnlmain.ResumeLayout(false);
            this.pnldescription.ResumeLayout(false);
            this.fldescbuttons.ResumeLayout(false);
            this.fldescbuttons.PerformLayout();
            this.pnlchoices.ResumeLayout(false);
            this.pnlconfirm.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Label lbdesc;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Panel pnldescription;
        private System.Windows.Forms.Label choicedesc;
        private System.Windows.Forms.FlowLayoutPanel fldescbuttons;
        private System.Windows.Forms.Button btnbegin;
        private System.Windows.Forms.Label choicetitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlchoices;
        private ChoiceControl choiceControl3;
        private ChoiceControl choiceControl2;
        private ChoiceControl cc_sidewithdevx;
        private System.Windows.Forms.Panel pnlconfirm;
        private System.Windows.Forms.Label lbconfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button3;
    }
}