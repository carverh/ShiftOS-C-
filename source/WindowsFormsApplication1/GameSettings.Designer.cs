namespace ShiftOS
{
    partial class GameSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbgame = new System.Windows.Forms.Label();
            this.pgsound = new ShiftOS.ProgressBarEX();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pgsound);
            this.panel1.Controls.Add(this.lbgame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 432);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lbgame
            // 
            this.lbgame.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbgame.Location = new System.Drawing.Point(0, 0);
            this.lbgame.Name = "lbgame";
            this.lbgame.Size = new System.Drawing.Size(665, 23);
            this.lbgame.TabIndex = 1;
            this.lbgame.Text = "ShiftOS settings";
            this.lbgame.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pgsound
            // 
            this.pgsound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgsound.BackColor = System.Drawing.Color.White;
            this.pgsound.BlockSeparation = 3;
            this.pgsound.BlockWidth = 5;
            this.pgsound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgsound.Color = System.Drawing.Color.Black;
            this.pgsound.ForeColor = System.Drawing.Color.Gray;
            this.pgsound.Label = "Music Volume:";
            this.pgsound.Location = new System.Drawing.Point(13, 67);
            this.pgsound.MaxValue = 100;
            this.pgsound.MinValue = 0;
            this.pgsound.Name = "pgsound";
            this.pgsound.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal;
            this.pgsound.ShowLabel = true;
            this.pgsound.ShowValue = true;
            this.pgsound.Size = new System.Drawing.Size(640, 32);
            this.pgsound.Step = 10;
            this.pgsound.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous;
            this.pgsound.TabIndex = 2;
            this.pgsound.Value = 0;
            this.pgsound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.set_music_volume);
            this.pgsound.MouseLeave += new System.EventHandler(this.pgsound_MouseLeave);
            this.pgsound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pgsound_MouseMove);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(665, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "* Click and drag to set any percentage values!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 432);
            this.Controls.Add(this.panel1);
            this.Name = "GameSettings";
            this.Text = "GameSettings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ProgressBarEX pgsound;
        private System.Windows.Forms.Label lbgame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}