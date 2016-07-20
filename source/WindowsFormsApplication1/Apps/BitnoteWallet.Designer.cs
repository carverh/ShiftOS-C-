namespace ShiftOS
{
    partial class BitnoteWallet
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
            this.fltopbar = new ShiftUI.FlowLayoutPanel();
            this.btnsend = new ShiftUI.Button();
            this.btnsync = new ShiftUI.Button();
            this.sendpanel = new ShiftUI.Panel();
            this.txtamount = new ShiftUI.TextBox();
            this.txtrecipient = new ShiftUI.TextBox();
            this.label2 = new ShiftUI.Label();
            this.label1 = new ShiftUI.Label();
            this.btnconfirmsend = new ShiftUI.PictureBox();
            this.panel1 = new ShiftUI.Panel();
            this.lbmybitnotes = new ShiftUI.Label();
            this.label4 = new ShiftUI.Label();
            this.txtmyaddress = new ShiftUI.TextBox();
            this.label3 = new ShiftUI.Label();
            this.tmrrefresh = new ShiftUI.Timer(this.components);
            this.fltopbar.SuspendLayout();
            this.sendpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnconfirmsend)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fltopbar
            // 
            this.fltopbar.BackColor = System.Drawing.Color.Gray;
            this.fltopbar.Widgets.Add(this.btnsend);
            this.fltopbar.Widgets.Add(this.btnsync);
            this.fltopbar.Dock = ShiftUI.DockStyle.Top;
            this.fltopbar.ForeColor = System.Drawing.Color.White;
            this.fltopbar.Location = new System.Drawing.Point(0, 0);
            this.fltopbar.Name = "fltopbar";
            this.fltopbar.Size = new System.Drawing.Size(551, 30);
            this.fltopbar.TabIndex = 0;
            // 
            // btnsend
            // 
            this.btnsend.BackgroundImageLayout = ShiftUI.ImageLayout.None;
            this.btnsend.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnsend.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnsend.Location = new System.Drawing.Point(3, 3);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 23);
            this.btnsend.TabIndex = 0;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btnsync
            // 
            this.btnsync.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnsync.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnsync.Location = new System.Drawing.Point(84, 3);
            this.btnsync.Name = "btnsync";
            this.btnsync.Size = new System.Drawing.Size(113, 23);
            this.btnsync.TabIndex = 1;
            this.btnsync.Text = "Sync My Bitnotes";
            this.btnsync.UseVisualStyleBackColor = true;
            this.btnsync.Click += new System.EventHandler(this.btnsync_Click);
            // 
            // sendpanel
            // 
            this.sendpanel.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.sendpanel.Widgets.Add(this.txtamount);
            this.sendpanel.Widgets.Add(this.txtrecipient);
            this.sendpanel.Widgets.Add(this.label2);
            this.sendpanel.Widgets.Add(this.label1);
            this.sendpanel.Widgets.Add(this.btnconfirmsend);
            this.sendpanel.Location = new System.Drawing.Point(306, 143);
            this.sendpanel.Name = "sendpanel";
            this.sendpanel.Size = new System.Drawing.Size(233, 105);
            this.sendpanel.TabIndex = 1;
            this.sendpanel.Visible = false;
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(82, 34);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(148, 20);
            this.txtamount.TabIndex = 4;
            // 
            // txtrecipient
            // 
            this.txtrecipient.Location = new System.Drawing.Point(82, 4);
            this.txtrecipient.Name = "txtrecipient";
            this.txtrecipient.Size = new System.Drawing.Size(148, 20);
            this.txtrecipient.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipient:";
            // 
            // btnconfirmsend
            // 
            this.btnconfirmsend.Image = global::ShiftOS.Properties.Resources.Send;
            this.btnconfirmsend.Location = new System.Drawing.Point(129, 75);
            this.btnconfirmsend.Name = "btnconfirmsend";
            this.btnconfirmsend.Size = new System.Drawing.Size(101, 27);
            this.btnconfirmsend.SizeMode = ShiftUI.PictureBoxSizeMode.AutoSize;
            this.btnconfirmsend.TabIndex = 0;
            this.btnconfirmsend.TabStop = false;
            this.btnconfirmsend.Click += new System.EventHandler(this.btnconfirmsend_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Widgets.Add(this.lbmybitnotes);
            this.panel1.Widgets.Add(this.label4);
            this.panel1.Widgets.Add(this.txtmyaddress);
            this.panel1.Widgets.Add(this.label3);
            this.panel1.Widgets.Add(this.fltopbar);
            this.panel1.Widgets.Add(this.sendpanel);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 260);
            this.panel1.TabIndex = 2;
            // 
            // lbmybitnotes
            // 
            this.lbmybitnotes.AutoSize = true;
            this.lbmybitnotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbmybitnotes.Location = new System.Drawing.Point(7, 203);
            this.lbmybitnotes.Name = "lbmybitnotes";
            this.lbmybitnotes.Size = new System.Drawing.Size(91, 31);
            this.lbmybitnotes.TabIndex = 6;
            this.lbmybitnotes.Text = "0 BTN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(7, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "I have:";
            // 
            // txtmyaddress
            // 
            this.txtmyaddress.Location = new System.Drawing.Point(10, 136);
            this.txtmyaddress.Name = "txtmyaddress";
            this.txtmyaddress.Size = new System.Drawing.Size(290, 20);
            this.txtmyaddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(7, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "My Address:";
            // 
            // tmrrefresh
            // 
            this.tmrrefresh.Enabled = true;
            this.tmrrefresh.Tick += new System.EventHandler(this.tmrrefresh_Tick);
            // 
            // BitnoteWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 260);
            this.Widgets.Add(this.panel1);
            this.Name = "BitnoteWallet";
            this.Text = "BitnoteWallet";
            this.Load += new System.EventHandler(this.BitnoteWallet_Load);
            this.fltopbar.ResumeLayout(false);
            this.sendpanel.ResumeLayout(false);
            this.sendpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnconfirmsend)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.FlowLayoutPanel fltopbar;
        private ShiftUI.Button btnsend;
        private ShiftUI.Button btnsync;
        private ShiftUI.Panel sendpanel;
        private ShiftUI.Panel panel1;
        private ShiftUI.PictureBox btnconfirmsend;
        private ShiftUI.TextBox txtamount;
        private ShiftUI.TextBox txtrecipient;
        private ShiftUI.Label label2;
        private ShiftUI.Label label1;
        private ShiftUI.Label lbmybitnotes;
        private ShiftUI.Label label4;
        private ShiftUI.TextBox txtmyaddress;
        private ShiftUI.Label label3;
        private ShiftUI.Timer tmrrefresh;
    }
}