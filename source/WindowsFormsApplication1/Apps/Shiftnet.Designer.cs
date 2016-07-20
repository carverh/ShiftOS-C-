using System;

namespace ShiftOS
{
    partial class Shiftnet
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
            this.pnlcontrols = new ShiftUI.Panel();
            this.btngo = new ShiftUI.Button();
            this.btnhome = new ShiftUI.Button();
            this.txtaddress = new ShiftUI.TextBox();
            this.wbshiftnet = new Gecko.GeckoWebBrowser();
            this.panel1 = new ShiftUI.Panel();
            this.pnlcontrols.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlcontrols
            // 
            this.pnlcontrols.BackColor = System.Drawing.Color.Gray;
            this.pnlcontrols.Widgets.Add(this.btngo);
            this.pnlcontrols.Widgets.Add(this.btnhome);
            this.pnlcontrols.Widgets.Add(this.txtaddress);
            this.pnlcontrols.Dock = ShiftUI.DockStyle.Top;
            this.pnlcontrols.Location = new System.Drawing.Point(0, 0);
            this.pnlcontrols.Name = "pnlcontrols";
            this.pnlcontrols.Size = new System.Drawing.Size(792, 42);
            this.pnlcontrols.TabIndex = 0;
            // 
            // btngo
            // 
            this.btngo.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.btngo.DialogResult = ShiftUI.DialogResult.Cancel;
            this.btngo.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btngo.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btngo.ForeColor = System.Drawing.Color.White;
            this.btngo.Location = new System.Drawing.Point(731, 9);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(45, 23);
            this.btngo.TabIndex = 2;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // btnhome
            // 
            this.btnhome.DialogResult = ShiftUI.DialogResult.Cancel;
            this.btnhome.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnhome.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnhome.ForeColor = System.Drawing.Color.White;
            this.btnhome.Location = new System.Drawing.Point(4, 12);
            this.btnhome.Name = "btnhome";
            this.btnhome.Size = new System.Drawing.Size(75, 23);
            this.btnhome.TabIndex = 1;
            this.btnhome.Text = "Home";
            this.btnhome.UseVisualStyleBackColor = true;
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            // 
            // txtaddress
            // 
            this.txtaddress.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.txtaddress.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtaddress.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.txtaddress.Location = new System.Drawing.Point(85, 12);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(640, 20);
            this.txtaddress.TabIndex = 0;
            this.txtaddress.Text = "shiftnet://main";
            // 
            // wbshiftnet
            // 
            this.wbshiftnet.Dock = (System.Windows.Forms.DockStyle)ShiftUI.DockStyle.Fill;
            this.wbshiftnet.Location = new System.Drawing.Point(0, 42);
            this.wbshiftnet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbshiftnet.Name = "wbshiftnet";
            this.wbshiftnet.Size = new System.Drawing.Size(792, 463);
            this.wbshiftnet.TabIndex = 1;
            this.wbshiftnet.Navigating += new EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(this.LinkInterceptor);
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.wbshiftnet.ToWidget());
            this.panel1.Widgets.Add(this.pnlcontrols);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 505);
            this.panel1.TabIndex = 2;
            // 
            // Shiftnet
            // 
            this.AcceptButton = this.btngo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.CancelButton = this.btnhome;
            this.ClientSize = new System.Drawing.Size(792, 505);
            this.Widgets.Add(this.panel1);
            this.Name = "Shiftnet";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlcontrols.ResumeLayout(false);
            this.pnlcontrols.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel pnlcontrols;
        private Gecko.GeckoWebBrowser wbshiftnet;
        private ShiftUI.Button btngo;
        private ShiftUI.Button btnhome;
        private ShiftUI.TextBox txtaddress;
        private ShiftUI.Panel panel1;

    }
}