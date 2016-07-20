namespace ShiftOS
{
    partial class Computer
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
            if(this.HealthTimer != null)
            {
                this.HealthTimer.Stop();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbstats = new ShiftUI.Label();
            this.SuspendLayout();
            // 
            // lbstats
            // 
            this.lbstats.Dock = ShiftUI.DockStyle.Fill;
            this.lbstats.ForeColor = System.Drawing.Color.Black;
            this.lbstats.Location = new System.Drawing.Point(0, 0);
            this.lbstats.Name = "lbstats";
            this.lbstats.Size = new System.Drawing.Size(64, 64);
            this.lbstats.TabIndex = 0;
            this.lbstats.Text = "HP: 100";
            this.lbstats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbstats.Click += new System.EventHandler(this.lbstats_Click);
            // 
            // Computer
            // 
            this.AutoScaleMode = ShiftUI.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Widgets.Add(this.lbstats);
            this.Name = "Computer";
            this.Size = new System.Drawing.Size(64, 64);
            this.Load += new System.EventHandler(this.Computer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Label lbstats;
    }
}
