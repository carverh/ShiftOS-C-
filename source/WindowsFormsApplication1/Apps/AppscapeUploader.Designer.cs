namespace ShiftOS
{
    partial class AppscapeUploader
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
            this.lbtitle = new System.Windows.Forms.Label();
            this.pnlmain = new System.Windows.Forms.Panel();
            this.Page0 = new System.Windows.Forms.Panel();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.lbprice = new System.Windows.Forms.Label();
            this.lbaddress = new System.Windows.Forms.Label();
            this.cbsell = new System.Windows.Forms.CheckBox();
            this.txtpackagedescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpackagename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Page1 = new System.Windows.Forms.Panel();
            this.btncompilesaa = new System.Windows.Forms.Button();
            this.btnscreenshot = new System.Windows.Forms.Button();
            this.btnicon = new System.Windows.Forms.Button();
            this.btnsaa = new System.Windows.Forms.Button();
            this.Page2 = new System.Windows.Forms.Panel();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldescription = new System.Windows.Forms.Label();
            this.pnlactions = new System.Windows.Forms.FlowLayoutPanel();
            this.btndone = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.pnlmain.SuspendLayout();
            this.Page0.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.pnlactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbtitle
            // 
            this.lbtitle.BackColor = System.Drawing.Color.Gray;
            this.lbtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbtitle.ForeColor = System.Drawing.Color.White;
            this.lbtitle.Location = new System.Drawing.Point(0, 0);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lbtitle.Size = new System.Drawing.Size(711, 49);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Welcome!";
            this.lbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlmain
            // 
            this.pnlmain.BackColor = System.Drawing.Color.Gray;
            this.pnlmain.Controls.Add(this.Page0);
            this.pnlmain.Controls.Add(this.Page1);
            this.pnlmain.Controls.Add(this.Page2);
            this.pnlmain.Controls.Add(this.lbldescription);
            this.pnlmain.Controls.Add(this.pnlactions);
            this.pnlmain.Controls.Add(this.lbtitle);
            this.pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlmain.Location = new System.Drawing.Point(0, 0);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(711, 485);
            this.pnlmain.TabIndex = 1;
            // 
            // Page0
            // 
            this.Page0.Controls.Add(this.txtprice);
            this.Page0.Controls.Add(this.lbprice);
            this.Page0.Controls.Add(this.lbaddress);
            this.Page0.Controls.Add(this.cbsell);
            this.Page0.Controls.Add(this.txtpackagedescription);
            this.Page0.Controls.Add(this.label2);
            this.Page0.Controls.Add(this.txtpackagename);
            this.Page0.Controls.Add(this.label1);
            this.Page0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0.Location = new System.Drawing.Point(0, 135);
            this.Page0.Name = "Page0";
            this.Page0.Size = new System.Drawing.Size(711, 314);
            this.Page0.TabIndex = 3;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(542, 239);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(89, 20);
            this.txtprice.TabIndex = 8;
            this.txtprice.Visible = false;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            // 
            // lbprice
            // 
            this.lbprice.AutoSize = true;
            this.lbprice.Location = new System.Drawing.Point(505, 242);
            this.lbprice.Name = "lbprice";
            this.lbprice.Size = new System.Drawing.Size(34, 13);
            this.lbprice.TabIndex = 7;
            this.lbprice.Text = "Price:";
            this.lbprice.Visible = false;
            this.lbprice.Click += new System.EventHandler(this.lbprice_Click);
            // 
            // lbaddress
            // 
            this.lbaddress.Location = new System.Drawing.Point(211, 242);
            this.lbaddress.Name = "lbaddress";
            this.lbaddress.Size = new System.Drawing.Size(275, 45);
            this.lbaddress.TabIndex = 5;
            this.lbaddress.Text = "All profit made from this package will be sent to the Bitnote Address defined in " +
    "your Dev Lounge; if it is non-existent, Bitnotes simply won\'t arrive.";
            this.lbaddress.Visible = false;
            this.lbaddress.Click += new System.EventHandler(this.lbaddress_Click);
            // 
            // cbsell
            // 
            this.cbsell.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbsell.AutoSize = true;
            this.cbsell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbsell.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.cbsell.Location = new System.Drawing.Point(98, 235);
            this.cbsell.Name = "cbsell";
            this.cbsell.Size = new System.Drawing.Size(92, 24);
            this.cbsell.TabIndex = 4;
            this.cbsell.Text = "Sell for Bitnotes";
            this.cbsell.UseVisualStyleBackColor = true;
            this.cbsell.CheckedChanged += new System.EventHandler(this.cbsell_CheckedChanged);
            // 
            // txtpackagedescription
            // 
            this.txtpackagedescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpackagedescription.Location = new System.Drawing.Point(100, 44);
            this.txtpackagedescription.Multiline = true;
            this.txtpackagedescription.Name = "txtpackagedescription";
            this.txtpackagedescription.Size = new System.Drawing.Size(591, 189);
            this.txtpackagedescription.TabIndex = 3;
            this.txtpackagedescription.TextChanged += new System.EventHandler(this.txtpackagedescription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtpackagename
            // 
            this.txtpackagename.Location = new System.Drawing.Point(100, 15);
            this.txtpackagename.Name = "txtpackagename";
            this.txtpackagename.Size = new System.Drawing.Size(258, 20);
            this.txtpackagename.TabIndex = 1;
            this.txtpackagename.TextChanged += new System.EventHandler(this.txtpackagename_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.btncompilesaa);
            this.Page1.Controls.Add(this.btnscreenshot);
            this.Page1.Controls.Add(this.btnicon);
            this.Page1.Controls.Add(this.btnsaa);
            this.Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page1.Location = new System.Drawing.Point(0, 135);
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(711, 314);
            this.Page1.TabIndex = 4;
            // 
            // btncompilesaa
            // 
            this.btncompilesaa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncompilesaa.AutoSize = true;
            this.btncompilesaa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btncompilesaa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncompilesaa.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btncompilesaa.Location = new System.Drawing.Point(4, 282);
            this.btncompilesaa.Name = "btncompilesaa";
            this.btncompilesaa.Size = new System.Drawing.Size(82, 26);
            this.btncompilesaa.TabIndex = 7;
            this.btncompilesaa.Text = "Compile SAA";
            this.btncompilesaa.UseVisualStyleBackColor = true;
            this.btncompilesaa.Click += new System.EventHandler(this.btncompilesaa_Click);
            // 
            // btnscreenshot
            // 
            this.btnscreenshot.AutoSize = true;
            this.btnscreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnscreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnscreenshot.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnscreenshot.Location = new System.Drawing.Point(12, 76);
            this.btnscreenshot.Name = "btnscreenshot";
            this.btnscreenshot.Size = new System.Drawing.Size(121, 26);
            this.btnscreenshot.TabIndex = 6;
            this.btnscreenshot.Text = "Select App Screenshot";
            this.btnscreenshot.UseVisualStyleBackColor = true;
            this.btnscreenshot.Click += new System.EventHandler(this.btnscreenshot_Click);
            // 
            // btnicon
            // 
            this.btnicon.AutoSize = true;
            this.btnicon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnicon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnicon.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnicon.Location = new System.Drawing.Point(12, 44);
            this.btnicon.Name = "btnicon";
            this.btnicon.Size = new System.Drawing.Size(92, 26);
            this.btnicon.TabIndex = 5;
            this.btnicon.Text = "Select App Icon";
            this.btnicon.UseVisualStyleBackColor = true;
            this.btnicon.Click += new System.EventHandler(this.btnicon_Click);
            // 
            // btnsaa
            // 
            this.btnsaa.AutoSize = true;
            this.btnsaa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnsaa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsaa.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnsaa.Location = new System.Drawing.Point(12, 9);
            this.btnsaa.Name = "btnsaa";
            this.btnsaa.Size = new System.Drawing.Size(92, 26);
            this.btnsaa.TabIndex = 4;
            this.btnsaa.Text = "Select App SAA";
            this.btnsaa.UseVisualStyleBackColor = true;
            this.btnsaa.Click += new System.EventHandler(this.btnsaa_Click);
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.txtconfirm);
            this.Page2.Controls.Add(this.label3);
            this.Page2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page2.Location = new System.Drawing.Point(0, 135);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(711, 314);
            this.Page2.TabIndex = 7;
            // 
            // txtconfirm
            // 
            this.txtconfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtconfirm.Location = new System.Drawing.Point(19, 49);
            this.txtconfirm.Multiline = true;
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(672, 259);
            this.txtconfirm.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Confirm Package Settings:";
            // 
            // lbldescription
            // 
            this.lbldescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbldescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbldescription.ForeColor = System.Drawing.Color.White;
            this.lbldescription.Location = new System.Drawing.Point(0, 49);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lbldescription.Size = new System.Drawing.Size(711, 86);
            this.lbldescription.TabIndex = 2;
            this.lbldescription.Text = "label1";
            // 
            // pnlactions
            // 
            this.pnlactions.Controls.Add(this.btndone);
            this.pnlactions.Controls.Add(this.btnnext);
            this.pnlactions.Controls.Add(this.btnback);
            this.pnlactions.Controls.Add(this.btncancel);
            this.pnlactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlactions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlactions.ForeColor = System.Drawing.Color.White;
            this.pnlactions.Location = new System.Drawing.Point(0, 449);
            this.pnlactions.Name = "pnlactions";
            this.pnlactions.Size = new System.Drawing.Size(711, 36);
            this.pnlactions.TabIndex = 1;
            // 
            // btndone
            // 
            this.btndone.AutoSize = true;
            this.btndone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btndone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndone.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btndone.Location = new System.Drawing.Point(660, 3);
            this.btndone.Name = "btndone";
            this.btndone.Size = new System.Drawing.Size(48, 26);
            this.btndone.TabIndex = 0;
            this.btndone.Text = "Done!";
            this.btndone.UseVisualStyleBackColor = true;
            this.btndone.Click += new System.EventHandler(this.btndone_Click);
            // 
            // btnnext
            // 
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnnext.Location = new System.Drawing.Point(612, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(42, 26);
            this.btnnext.TabIndex = 1;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnback
            // 
            this.btnback.AutoSize = true;
            this.btnback.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btnback.Location = new System.Drawing.Point(564, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(42, 26);
            this.btnback.TabIndex = 2;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btncancel
            // 
            this.btncancel.AutoSize = true;
            this.btncancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.btncancel.Location = new System.Drawing.Point(508, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(50, 26);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // AppscapeUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 485);
            this.Controls.Add(this.pnlmain);
            this.Name = "AppscapeUploader";
            this.Text = "AppscapeUploader";
            this.Load += new System.EventHandler(this.AppscapeUploader_Load);
            this.pnlmain.ResumeLayout(false);
            this.Page0.ResumeLayout(false);
            this.Page0.PerformLayout();
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.pnlactions.ResumeLayout(false);
            this.pnlactions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.FlowLayoutPanel pnlactions;
        private System.Windows.Forms.Button btndone;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.Panel Page0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpackagedescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpackagename;
        private System.Windows.Forms.Panel Page1;
        private System.Windows.Forms.Button btnsaa;
        private System.Windows.Forms.Button btnscreenshot;
        private System.Windows.Forms.Button btnicon;
        private System.Windows.Forms.Panel Page2;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncompilesaa;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label lbprice;
        private System.Windows.Forms.Label lbaddress;
        private System.Windows.Forms.CheckBox cbsell;
    }
}