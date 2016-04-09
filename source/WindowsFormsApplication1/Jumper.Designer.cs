namespace ShiftOS
{
    partial class Jumper
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
            this.pnlstatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnplay = new System.Windows.Forms.Button();
            this.lbstatus = new System.Windows.Forms.Label();
            this.lbstatus2 = new System.Windows.Forms.Label();
            this.ground = new System.Windows.Forms.Panel();
            this.tmrscreenupdate = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.pnlstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlstatus
            // 
            this.pnlstatus.Controls.Add(this.btnplay);
            this.pnlstatus.Controls.Add(this.lbstatus);
            this.pnlstatus.Controls.Add(this.lbstatus2);
            this.pnlstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlstatus.Location = new System.Drawing.Point(0, 408);
            this.pnlstatus.Name = "pnlstatus";
            this.pnlstatus.Size = new System.Drawing.Size(800, 30);
            this.pnlstatus.TabIndex = 0;
            // 
            // btnplay
            // 
            this.btnplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnplay.Location = new System.Drawing.Point(3, 3);
            this.btnplay.Name = "btnplay";
            this.btnplay.Size = new System.Drawing.Size(75, 23);
            this.btnplay.TabIndex = 0;
            this.btnplay.Text = "Play";
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // lbstatus
            // 
            this.lbstatus.Location = new System.Drawing.Point(84, 0);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(137, 23);
            this.lbstatus.TabIndex = 1;
            this.lbstatus.Text = "Codepoints: 0";
            this.lbstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbstatus2
            // 
            this.lbstatus2.Location = new System.Drawing.Point(227, 0);
            this.lbstatus2.Name = "lbstatus2";
            this.lbstatus2.Size = new System.Drawing.Size(137, 23);
            this.lbstatus2.TabIndex = 2;
            this.lbstatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ground
            // 
            this.ground.Location = new System.Drawing.Point(87, 262);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(200, 35);
            this.ground.TabIndex = 1;
            // 
            // tmrscreenupdate
            // 
            this.tmrscreenupdate.Interval = 500;
            this.tmrscreenupdate.Tick += new System.EventHandler(this.tmrscreenupdate_Tick);
            // 
            // player
            // 
            this.player.Image = global::ShiftOS.Properties.Resources.jumperplayer;
            this.player.Location = new System.Drawing.Point(219, 96);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(32, 32);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            // 
            // Jumper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.player);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.pnlstatus);
            this.Name = "Jumper";
            this.Text = "Jumper";
            this.pnlstatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlstatus;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.Panel ground;
        private System.Windows.Forms.Timer tmrscreenupdate;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label lbstatus2;
    }
}