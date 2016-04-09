namespace ShiftOS
{
    partial class QuickChat
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
            this.pnlsetnick = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnconnect = new System.Windows.Forms.Button();
            this.txtsetnick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmessages = new System.Windows.Forms.RichTextBox();
            this.pnlcontrols = new System.Windows.Forms.Panel();
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.lbnick = new System.Windows.Forms.Label();
            this.tmrimfuckinglucky = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlsetnick.SuspendLayout();
            this.pnlcontrols.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlsetnick);
            this.panel1.Controls.Add(this.txtmessages);
            this.panel1.Controls.Add(this.pnlcontrols);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 414);
            this.panel1.TabIndex = 0;
            // 
            // pnlsetnick
            // 
            this.pnlsetnick.Controls.Add(this.label2);
            this.pnlsetnick.Controls.Add(this.btnconnect);
            this.pnlsetnick.Controls.Add(this.txtsetnick);
            this.pnlsetnick.Controls.Add(this.label1);
            this.pnlsetnick.Location = new System.Drawing.Point(198, 88);
            this.pnlsetnick.Name = "pnlsetnick";
            this.pnlsetnick.Size = new System.Drawing.Size(289, 184);
            this.pnlsetnick.TabIndex = 2;
            this.pnlsetnick.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 80);
            this.label2.TabIndex = 3;
            this.label2.Text = "QuickChat is the finest chat application for ShiftOS! All you have to do is enter" +
    " your nickname in the field below and hit \"Connect!\"";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnconnect
            // 
            this.btnconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconnect.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnconnect.Location = new System.Drawing.Point(196, 152);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(90, 29);
            this.btnconnect.TabIndex = 2;
            this.btnconnect.Text = "Connect!";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // txtsetnick
            // 
            this.txtsetnick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsetnick.BackColor = System.Drawing.Color.Gray;
            this.txtsetnick.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsetnick.ForeColor = System.Drawing.Color.White;
            this.txtsetnick.Location = new System.Drawing.Point(24, 121);
            this.txtsetnick.Name = "txtsetnick";
            this.txtsetnick.Size = new System.Drawing.Size(239, 13);
            this.txtsetnick.TabIndex = 1;
            this.txtsetnick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsetnick_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to QuickChat!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtmessages
            // 
            this.txtmessages.BackColor = System.Drawing.Color.White;
            this.txtmessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmessages.DetectUrls = false;
            this.txtmessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmessages.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.txtmessages.ForeColor = System.Drawing.Color.Black;
            this.txtmessages.Location = new System.Drawing.Point(0, 0);
            this.txtmessages.Name = "txtmessages";
            this.txtmessages.ReadOnly = true;
            this.txtmessages.Size = new System.Drawing.Size(701, 380);
            this.txtmessages.TabIndex = 1;
            this.txtmessages.Text = "";
            this.txtmessages.TextChanged += new System.EventHandler(this.txtmessages_TextChanged);
            // 
            // pnlcontrols
            // 
            this.pnlcontrols.BackColor = System.Drawing.Color.Gray;
            this.pnlcontrols.Controls.Add(this.txtmessage);
            this.pnlcontrols.Controls.Add(this.btnsend);
            this.pnlcontrols.Controls.Add(this.lbnick);
            this.pnlcontrols.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlcontrols.ForeColor = System.Drawing.Color.White;
            this.pnlcontrols.Location = new System.Drawing.Point(0, 380);
            this.pnlcontrols.Name = "pnlcontrols";
            this.pnlcontrols.Size = new System.Drawing.Size(701, 34);
            this.pnlcontrols.TabIndex = 0;
            // 
            // txtmessage
            // 
            this.txtmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmessage.BackColor = System.Drawing.Color.White;
            this.txtmessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtmessage.ForeColor = System.Drawing.Color.Black;
            this.txtmessage.Location = new System.Drawing.Point(70, 6);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(547, 19);
            this.txtmessage.TabIndex = 2;
            // 
            // btnsend
            // 
            this.btnsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsend.Enabled = false;
            this.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsend.Location = new System.Drawing.Point(623, 3);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 28);
            this.btnsend.TabIndex = 1;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // lbnick
            // 
            this.lbnick.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbnick.Location = new System.Drawing.Point(0, 0);
            this.lbnick.Name = "lbnick";
            this.lbnick.Size = new System.Drawing.Size(100, 34);
            this.lbnick.TabIndex = 0;
            this.lbnick.Text = "Nickname";
            this.lbnick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrimfuckinglucky
            // 
            this.tmrimfuckinglucky.Enabled = true;
            this.tmrimfuckinglucky.Tick += new System.EventHandler(this.tmrimfuckinglucky_Tick);
            // 
            // QuickChat
            // 
            this.AcceptButton = this.btnsend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 414);
            this.Controls.Add(this.panel1);
            this.Name = "QuickChat";
            this.Text = "QuickChat";
            this.Load += new System.EventHandler(this.QuickChat_Load);
            this.panel1.ResumeLayout(false);
            this.pnlsetnick.ResumeLayout(false);
            this.pnlsetnick.PerformLayout();
            this.pnlcontrols.ResumeLayout(false);
            this.pnlcontrols.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtmessages;
        private System.Windows.Forms.Panel pnlcontrols;
        private System.Windows.Forms.Timer tmrimfuckinglucky;
        private System.Windows.Forms.Label lbnick;
        private System.Windows.Forms.TextBox txtmessage;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Panel pnlsetnick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.TextBox txtsetnick;
        private System.Windows.Forms.Label label1;
    }
}