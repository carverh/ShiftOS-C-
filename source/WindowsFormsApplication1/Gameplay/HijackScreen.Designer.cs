using System;

namespace ShiftOS
{
    partial class HijackScreen
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
            this.lblHijack = new ShiftUI.Label();
            this.conversationtimer = new ShiftUI.Timer(this.components);
            this.textgen = new ShiftUI.Timer(this.components);
            this.lblhackwords = new ShiftUI.Label();
            this.hackeffecttimer = new ShiftUI.Timer(this.components);
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnskip = new ShiftUI.Button();
            this.SuspendLayout();
            // 
            // lblHijack
            // 
            this.lblHijack.Anchor = ShiftUI.AnchorStyles.None;
            this.lblHijack.AutoSize = true;
            this.lblHijack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHijack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHijack.ForeColor = System.Drawing.Color.DimGray;
            this.lblHijack.Location = new System.Drawing.Point(143, 193);
            this.lblHijack.Name = "lblHijack";
            this.lblHijack.Size = new System.Drawing.Size(18, 25);
            this.lblHijack.TabIndex = 0;
            this.lblHijack.Text = "\\";
            // 
            // textgen
            // 
            this.textgen.Interval = 20;
            // 
            // lblhackwords
            // 
            this.lblhackwords.AutoSize = true;
            this.lblhackwords.Dock = ShiftUI.DockStyle.Fill;
            this.lblhackwords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhackwords.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblhackwords.Location = new System.Drawing.Point(0, 0);
            this.lblhackwords.Name = "lblhackwords";
            this.lblhackwords.Size = new System.Drawing.Size(127, 18);
            this.lblhackwords.TabIndex = 1;
            this.lblhackwords.Text = "Hijack in progress";
            // 
            // hackeffecttimer
            // 
            this.hackeffecttimer.Interval = 50;
            // 
            // btnskip
            // 
            this.btnskip.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnskip.ForeColor = System.Drawing.Color.White;
            this.btnskip.Location = new System.Drawing.Point(566, 422);
            this.btnskip.Name = "btnskip";
            this.btnskip.Size = new System.Drawing.Size(75, 23);
            this.btnskip.TabIndex = 2;
            this.btnskip.Text = "Skip";
            this.btnskip.UseVisualStyleBackColor = true;
            this.btnskip.Visible = false;
            this.btnskip.Click += new System.EventHandler(this.btnskip_Click);
            // 
            // HijackScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(653, 457);
            this.Widgets.Add(this.btnskip);
            this.Widgets.Add(this.lblhackwords);
            this.Widgets.Add(this.lblHijack);
            this.Name = "HijackScreen";
            this.Text = "ShiftOS";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.HijackScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal ShiftUI.Label lblHijack;
        internal ShiftUI.Timer conversationtimer;
        internal ShiftUI.Timer textgen;
        internal ShiftUI.Label lblhackwords;
        internal ShiftUI.Timer hackeffecttimer;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        #endregion

        private ShiftUI.Button btnskip;
    }
}