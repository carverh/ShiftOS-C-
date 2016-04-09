namespace ShiftOS
{
    partial class AlternateDesktop
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
            this.pnlcontext = new System.Windows.Forms.Panel();
            this.pnlapplauncher = new System.Windows.Forms.Panel();
            this.pnlsidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.lbclock = new System.Windows.Forms.Label();
            this.ClockTick = new System.Windows.Forms.Timer(this.components);
            this.lblapplabel = new System.Windows.Forms.Label();
            this.apptick = new System.Windows.Forms.Timer(this.components);
            this.pnlcontext.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlcontext
            // 
            this.pnlcontext.BackColor = System.Drawing.Color.Gray;
            this.pnlcontext.Controls.Add(this.lbclock);
            this.pnlcontext.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlcontext.Location = new System.Drawing.Point(0, 0);
            this.pnlcontext.Name = "pnlcontext";
            this.pnlcontext.Size = new System.Drawing.Size(936, 28);
            this.pnlcontext.TabIndex = 0;
            // 
            // pnlapplauncher
            // 
            this.pnlapplauncher.BackColor = System.Drawing.Color.Gray;
            this.pnlapplauncher.Location = new System.Drawing.Point(71, 47);
            this.pnlapplauncher.Name = "pnlapplauncher";
            this.pnlapplauncher.Size = new System.Drawing.Size(664, 353);
            this.pnlapplauncher.TabIndex = 1;
            this.pnlapplauncher.Visible = false;
            // 
            // pnlsidebar
            // 
            this.pnlsidebar.BackColor = System.Drawing.Color.Gray;
            this.pnlsidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlsidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlsidebar.Location = new System.Drawing.Point(0, 28);
            this.pnlsidebar.Name = "pnlsidebar";
            this.pnlsidebar.Size = new System.Drawing.Size(52, 509);
            this.pnlsidebar.TabIndex = 2;
            // 
            // lbclock
            // 
            this.lbclock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbclock.Location = new System.Drawing.Point(820, 0);
            this.lbclock.Name = "lbclock";
            this.lbclock.Size = new System.Drawing.Size(113, 28);
            this.lbclock.TabIndex = 0;
            this.lbclock.Text = "500023";
            this.lbclock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ClockTick
            // 
            this.ClockTick.Enabled = true;
            this.ClockTick.Tick += new System.EventHandler(this.ClockTick_Tick);
            // 
            // lblapplabel
            // 
            this.lblapplabel.AutoSize = true;
            this.lblapplabel.Location = new System.Drawing.Point(823, 313);
            this.lblapplabel.Name = "lblapplabel";
            this.lblapplabel.Size = new System.Drawing.Size(35, 13);
            this.lblapplabel.TabIndex = 3;
            this.lblapplabel.Text = "label1";
            this.lblapplabel.Visible = false;
            // 
            // apptick
            // 
            this.apptick.Enabled = true;
            this.apptick.Interval = 2000;
            this.apptick.Tick += new System.EventHandler(this.apptick_Tick);
            // 
            // AlternateDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(936, 537);
            this.Controls.Add(this.lblapplabel);
            this.Controls.Add(this.pnlsidebar);
            this.Controls.Add(this.pnlapplauncher);
            this.Controls.Add(this.pnlcontext);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AlternateDesktop";
            this.Text = "AlternateDesktop";
            this.Load += new System.EventHandler(this.AlternateDesktop_Load);
            this.pnlcontext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlcontext;
        private System.Windows.Forms.Label lbclock;
        private System.Windows.Forms.Panel pnlapplauncher;
        private System.Windows.Forms.FlowLayoutPanel pnlsidebar;
        private System.Windows.Forms.Timer ClockTick;
        private System.Windows.Forms.Label lblapplabel;
        private System.Windows.Forms.Timer apptick;
    }
}