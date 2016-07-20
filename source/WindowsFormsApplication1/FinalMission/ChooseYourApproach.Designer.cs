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
            this.pnlmain = new ShiftUI.Panel();
            this.lbdesc = new ShiftUI.Label();
            this.lbtitle = new ShiftUI.Label();
            this.pnldescription = new ShiftUI.Panel();
            this.choicedesc = new ShiftUI.Label();
            this.fldescbuttons = new ShiftUI.FlowLayoutPanel();
            this.btnbegin = new ShiftUI.Button();
            this.choicetitle = new ShiftUI.Label();
            this.panel1 = new ShiftUI.Panel();
            this.pnlchoices = new ShiftUI.Panel();
            this.choiceWidget3 = new ShiftOS.FinalMission.ChoiceWidget();
            this.choiceWidget2 = new ShiftOS.FinalMission.ChoiceWidget();
            this.cc_sidewithdevx = new ShiftOS.FinalMission.ChoiceWidget();
            this.pnlconfirm = new ShiftUI.Panel();
            this.lbconfirm = new ShiftUI.Label();
            this.label2 = new ShiftUI.Label();
            this.button1 = new ShiftUI.Button();
            this.button2 = new ShiftUI.Button();
            this.flowLayoutPanel1 = new ShiftUI.FlowLayoutPanel();
            this.button3 = new ShiftUI.Button();
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
            this.pnlmain.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlmain.Widgets.Add(this.lbdesc);
            this.pnlmain.Widgets.Add(this.lbtitle);
            this.pnlmain.Location = new System.Drawing.Point(318, 27);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(692, 178);
            this.pnlmain.TabIndex = 0;
            // 
            // lbdesc
            // 
            this.lbdesc.Dock = ShiftUI.DockStyle.Fill;
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
            this.lbtitle.Dock = ShiftUI.DockStyle.Top;
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
            this.pnldescription.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnldescription.Widgets.Add(this.choicedesc);
            this.pnldescription.Widgets.Add(this.fldescbuttons);
            this.pnldescription.Widgets.Add(this.choicetitle);
            this.pnldescription.Location = new System.Drawing.Point(318, 357);
            this.pnldescription.Name = "pnldescription";
            this.pnldescription.Size = new System.Drawing.Size(692, 178);
            this.pnldescription.TabIndex = 1;
            // 
            // choicedesc
            // 
            this.choicedesc.Dock = ShiftUI.DockStyle.Fill;
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
            this.fldescbuttons.Widgets.Add(this.btnbegin);
            this.fldescbuttons.Dock = ShiftUI.DockStyle.Bottom;
            this.fldescbuttons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fldescbuttons.Location = new System.Drawing.Point(0, 141);
            this.fldescbuttons.Name = "fldescbuttons";
            this.fldescbuttons.Size = new System.Drawing.Size(692, 37);
            this.fldescbuttons.TabIndex = 2;
            // 
            // btnbegin
            // 
            this.btnbegin.AutoSize = true;
            this.btnbegin.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnbegin.FlatStyle = ShiftUI.FlatStyle.Flat;
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
            this.choicetitle.Dock = ShiftUI.DockStyle.Top;
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
            this.pnlchoices.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlchoices.Widgets.Add(this.choiceWidget3);
            this.pnlchoices.Widgets.Add(this.choiceWidget2);
            this.pnlchoices.Widgets.Add(this.cc_sidewithdevx);
            this.pnlchoices.Location = new System.Drawing.Point(510, 228);
            this.pnlchoices.MaximumSize = new System.Drawing.Size(338, 91);
            this.pnlchoices.MinimumSize = new System.Drawing.Size(338, 91);
            this.pnlchoices.Name = "pnlchoices";
            this.pnlchoices.Size = new System.Drawing.Size(338, 91);
            this.pnlchoices.TabIndex = 3;
            // 
            // choiceWidget3
            // 
            this.choiceWidget3.ChoiceName = "Destroy DevX";
            this.choiceWidget3.Dock = ShiftUI.DockStyle.Fill;
            this.choiceWidget3.Location = new System.Drawing.Point(112, 0);
            this.choiceWidget3.Name = "choiceWidget3";
            this.choiceWidget3.Number = 2;
            this.choiceWidget3.Size = new System.Drawing.Size(114, 91);
            this.choiceWidget3.TabIndex = 2;
            this.choiceWidget3.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // choiceWidget2
            // 
            this.choiceWidget2.ChoiceName = "End it all";
            this.choiceWidget2.Dock = ShiftUI.DockStyle.Right;
            this.choiceWidget2.Location = new System.Drawing.Point(226, 0);
            this.choiceWidget2.Name = "choiceWidget2";
            this.choiceWidget2.Number = 3;
            this.choiceWidget2.Size = new System.Drawing.Size(112, 91);
            this.choiceWidget2.TabIndex = 1;
            this.choiceWidget2.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // cc_sidewithdevx
            // 
            this.cc_sidewithdevx.ChoiceName = "Side with DevX";
            this.cc_sidewithdevx.Dock = ShiftUI.DockStyle.Left;
            this.cc_sidewithdevx.Location = new System.Drawing.Point(0, 0);
            this.cc_sidewithdevx.Name = "cc_sidewithdevx";
            this.cc_sidewithdevx.Number = 1;
            this.cc_sidewithdevx.Size = new System.Drawing.Size(112, 91);
            this.cc_sidewithdevx.TabIndex = 0;
            this.cc_sidewithdevx.Selected += new System.EventHandler(this.cc_sidewithdevx_Selected);
            // 
            // pnlconfirm
            // 
            this.pnlconfirm.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlconfirm.Widgets.Add(this.lbconfirm);
            this.pnlconfirm.Widgets.Add(this.flowLayoutPanel1);
            this.pnlconfirm.Widgets.Add(this.label2);
            this.pnlconfirm.Location = new System.Drawing.Point(56, 27);
            this.pnlconfirm.Name = "pnlconfirm";
            this.pnlconfirm.Size = new System.Drawing.Size(1220, 449);
            this.pnlconfirm.TabIndex = 4;
            this.pnlconfirm.Visible = false;
            // 
            // lbconfirm
            // 
            this.lbconfirm.Dock = ShiftUI.DockStyle.Fill;
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
            this.label2.Dock = ShiftUI.DockStyle.Top;
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
            this.button1.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = ShiftUI.FlatStyle.Flat;
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
            this.button2.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.button2.FlatStyle = ShiftUI.FlatStyle.Flat;
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
            this.flowLayoutPanel1.Widgets.Add(this.button3);
            this.flowLayoutPanel1.Dock = ShiftUI.DockStyle.Bottom;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 412);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1220, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.button3.FlatStyle = ShiftUI.FlatStyle.Flat;
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
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1328, 547);
            this.Widgets.Add(this.button2);
            this.Widgets.Add(this.button1);
            this.Widgets.Add(this.pnlconfirm);
            this.Widgets.Add(this.pnlchoices);
            this.Widgets.Add(this.panel1);
            this.Widgets.Add(this.pnldescription);
            this.Widgets.Add(this.pnlmain);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "ChooseYourApproach";
            this.Text = "ChooseYourApproach";
            this.FormClosing += new ShiftUI.FormClosingEventHandler(this.onClose);
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

        private ShiftUI.Panel pnlmain;
        private ShiftUI.Label lbdesc;
        private ShiftUI.Label lbtitle;
        private ShiftUI.Panel pnldescription;
        private ShiftUI.Label choicedesc;
        private ShiftUI.FlowLayoutPanel fldescbuttons;
        private ShiftUI.Button btnbegin;
        private ShiftUI.Label choicetitle;
        private ShiftUI.Panel panel1;
        private ShiftUI.Panel pnlchoices;
        private ChoiceWidget choiceWidget3;
        private ChoiceWidget choiceWidget2;
        private ChoiceWidget cc_sidewithdevx;
        private ShiftUI.Panel pnlconfirm;
        private ShiftUI.Label lbconfirm;
        private ShiftUI.Label label2;
        private ShiftUI.Button button1;
        private ShiftUI.Button button2;
        private ShiftUI.FlowLayoutPanel flowLayoutPanel1;
        private ShiftUI.Button button3;
    }
}