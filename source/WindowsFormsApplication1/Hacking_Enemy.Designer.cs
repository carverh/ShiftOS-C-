namespace ShiftOS
{
    partial class Hacking_Enemy
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
            this.lbcompromised = new System.Windows.Forms.Label();
            this.lbstats = new System.Windows.Forms.Label();
            this.tmrhealthdetect = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbcompromised);
            this.panel1.Controls.Add(this.lbstats);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 458);
            this.panel1.TabIndex = 1;
            // 
            // lbcompromised
            // 
            this.lbcompromised.AutoSize = true;
            this.lbcompromised.Location = new System.Drawing.Point(242, 174);
            this.lbcompromised.Name = "lbcompromised";
            this.lbcompromised.Size = new System.Drawing.Size(47, 11);
            this.lbcompromised.TabIndex = 1;
            this.lbcompromised.Text = "label1";
            this.lbcompromised.Visible = false;
            // 
            // lbstats
            // 
            this.lbstats.AutoSize = true;
            this.lbstats.Location = new System.Drawing.Point(13, 13);
            this.lbstats.Name = "lbstats";
            this.lbstats.Size = new System.Drawing.Size(131, 11);
            this.lbstats.TabIndex = 0;
            this.lbstats.Text = "Enemy Health: 100%";
            // 
            // tmrhealthdetect
            // 
            this.tmrhealthdetect.Tick += new System.EventHandler(this.tmrhealthdetect_Tick);
            // 
            // Hacking_Enemy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 458);
            this.Controls.Add(this.panel1);
            this.Name = "Hacking_Enemy";
            this.Text = "Hacking_Enemy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_Closing);
            this.Load += new System.EventHandler(this.Hacking_Enemy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbstats;
        private System.Windows.Forms.Timer tmrhealthdetect;
        private System.Windows.Forms.Label lbcompromised;
    }
}