namespace ShiftOS.FinalMission
{
    partial class MissionGuide
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
            this.panel1 = new ShiftUI.Panel();
            this.flbuttons = new ShiftUI.FlowLayoutPanel();
            this.btnstart = new ShiftUI.Button();
            this.tmr_setupui = new ShiftUI.Timer(this.components);
            this.lbprompt = new ShiftUI.Label();
            this.panel1.SuspendLayout();
            this.flbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.panel1.Widgets.Add(this.lbprompt);
            this.panel1.Widgets.Add(this.flbuttons);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 189);
            this.panel1.TabIndex = 0;
            // 
            // flbuttons
            // 
            this.flbuttons.Widgets.Add(this.btnstart);
            this.flbuttons.Dock = ShiftUI.DockStyle.Bottom;
            this.flbuttons.FlowDirection = ShiftUI.FlowDirection.RightToLeft;
            this.flbuttons.Location = new System.Drawing.Point(0, 155);
            this.flbuttons.Name = "flbuttons";
            this.flbuttons.Size = new System.Drawing.Size(518, 32);
            this.flbuttons.TabIndex = 0;
            // 
            // btnstart
            // 
            this.btnstart.AutoSize = true;
            this.btnstart.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnstart.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnstart.Location = new System.Drawing.Point(435, 3);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(80, 23);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Let\'s go.";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // tmr_setupui
            // 
            this.tmr_setupui.Enabled = true;
            this.tmr_setupui.Tick += new System.EventHandler(this.tmr_setupui_Tick);
            // 
            // lbprompt
            // 
            this.lbprompt.Dock = ShiftUI.DockStyle.Fill;
            this.lbprompt.Location = new System.Drawing.Point(0, 0);
            this.lbprompt.Margin = new ShiftUI.Padding(50);
            this.lbprompt.Name = "lbprompt";
            this.lbprompt.Padding = new ShiftUI.Padding(15);
            this.lbprompt.Size = new System.Drawing.Size(518, 155);
            this.lbprompt.TabIndex = 1;
            this.lbprompt.Text = "label1";
            // 
            // MissionGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(520, 189);
            this.Widgets.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "MissionGuide";
            this.Text = "MissionGuide";
            this.panel1.ResumeLayout(false);
            this.flbuttons.ResumeLayout(false);
            this.flbuttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.FlowLayoutPanel flbuttons;
        private ShiftUI.Button btnstart;
        private ShiftUI.Timer tmr_setupui;
        private ShiftUI.Label lbprompt;
    }
}