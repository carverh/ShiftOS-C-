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
            this.pnlcontrols = new System.Windows.Forms.Panel();
            this.btngo = new System.Windows.Forms.Button();
            this.btnhome = new System.Windows.Forms.Button();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.wbshiftnet = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlcontrols.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlcontrols
            // 
            this.pnlcontrols.BackColor = System.Drawing.Color.Gray;
            this.pnlcontrols.Controls.Add(this.btngo);
            this.pnlcontrols.Controls.Add(this.btnhome);
            this.pnlcontrols.Controls.Add(this.txtaddress);
            this.pnlcontrols.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlcontrols.Location = new System.Drawing.Point(0, 0);
            this.pnlcontrols.Name = "pnlcontrols";
            this.pnlcontrols.Size = new System.Drawing.Size(792, 42);
            this.pnlcontrols.TabIndex = 0;
            // 
            // btngo
            // 
            this.btngo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btngo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnhome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.txtaddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtaddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtaddress.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.txtaddress.Location = new System.Drawing.Point(85, 12);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(640, 20);
            this.txtaddress.TabIndex = 0;
            this.txtaddress.Text = "shiftnet://main";
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // wbshiftnet
            // 
            this.wbshiftnet.AllowWebBrowserDrop = false;
            this.wbshiftnet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbshiftnet.IsWebBrowserContextMenuEnabled = false;
            this.wbshiftnet.Location = new System.Drawing.Point(0, 42);
            this.wbshiftnet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbshiftnet.Name = "wbshiftnet";
            this.wbshiftnet.Size = new System.Drawing.Size(792, 463);
            this.wbshiftnet.TabIndex = 1;
            this.wbshiftnet.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.LinkInterceptor);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wbshiftnet);
            this.panel1.Controls.Add(this.pnlcontrols);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 505);
            this.panel1.TabIndex = 2;
            // 
            // Shiftnet
            // 
            this.AcceptButton = this.btngo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnhome;
            this.ClientSize = new System.Drawing.Size(792, 505);
            this.Controls.Add(this.panel1);
            this.Name = "Shiftnet";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlcontrols.ResumeLayout(false);
            this.pnlcontrols.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlcontrols;
        private System.Windows.Forms.WebBrowser wbshiftnet;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Button btnhome;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Panel panel1;

    }
}