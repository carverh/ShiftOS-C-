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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnstart = new System.Windows.Forms.Button();
            this.tmr_setupui = new System.Windows.Forms.Timer(this.components);
            this.lbprompt = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbprompt);
            this.panel1.Controls.Add(this.flbuttons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 189);
            this.panel1.TabIndex = 0;
            // 
            // flbuttons
            // 
            this.flbuttons.Controls.Add(this.btnstart);
            this.flbuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flbuttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flbuttons.Location = new System.Drawing.Point(0, 155);
            this.flbuttons.Name = "flbuttons";
            this.flbuttons.Size = new System.Drawing.Size(518, 32);
            this.flbuttons.TabIndex = 0;
            // 
            // btnstart
            // 
            this.btnstart.AutoSize = true;
            this.btnstart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lbprompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbprompt.Location = new System.Drawing.Point(0, 0);
            this.lbprompt.Margin = new System.Windows.Forms.Padding(50);
            this.lbprompt.Name = "lbprompt";
            this.lbprompt.Padding = new System.Windows.Forms.Padding(15);
            this.lbprompt.Size = new System.Drawing.Size(518, 155);
            this.lbprompt.TabIndex = 1;
            this.lbprompt.Text = "label1";
            // 
            // MissionGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(520, 189);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MissionGuide";
            this.Text = "MissionGuide";
            this.panel1.ResumeLayout(false);
            this.flbuttons.ResumeLayout(false);
            this.flbuttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flbuttons;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Timer tmr_setupui;
        private System.Windows.Forms.Label lbprompt;
    }
}