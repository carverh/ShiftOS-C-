namespace ShiftOS
{
    partial class ShiftnetDecryptor
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
            this.label1 = new ShiftUI.Label();
            this.txtstatus = new ShiftUI.RichTextBox();
            this.txtaddress = new ShiftUI.TextBox();
            this.label2 = new ShiftUI.Label();
            this.btnstart = new ShiftUI.Button();
            this.panel1 = new ShiftUI.Panel();
            this.tmrdecrypt = new ShiftUI.Timer(this.components);
            this.pgstatus = new ShiftOS.ProgressBarEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(744, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = " == Decryption Status ==";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtstatus
            // 
            this.txtstatus.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.txtstatus.BackColor = System.Drawing.Color.Black;
            this.txtstatus.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtstatus.ForeColor = System.Drawing.Color.White;
            this.txtstatus.Location = new System.Drawing.Point(17, 151);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.Size = new System.Drawing.Size(740, 280);
            this.txtstatus.TabIndex = 2;
            this.txtstatus.Text = "";
            // 
            // txtaddress
            // 
            this.txtaddress.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.txtaddress.BackColor = System.Drawing.Color.Gray;
            this.txtaddress.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtaddress.Location = new System.Drawing.Point(100, 121);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(590, 16);
            this.txtaddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address:";
            // 
            // btnstart
            // 
            this.btnstart.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.btnstart.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnstart.Location = new System.Drawing.Point(697, 119);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(60, 23);
            this.btnstart.TabIndex = 5;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Widgets.Add(this.btnstart);
            this.panel1.Widgets.Add(this.label2);
            this.panel1.Widgets.Add(this.txtaddress);
            this.panel1.Widgets.Add(this.txtstatus);
            this.panel1.Widgets.Add(this.label1);
            this.panel1.Widgets.Add(this.pgstatus);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 443);
            this.panel1.TabIndex = 6;
            // 
            // tmrdecrypt
            // 
            this.tmrdecrypt.Tick += new System.EventHandler(this.tmrdecrypt_Tick);
            // 
            // pgstatus
            // 
            this.pgstatus.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pgstatus.BackColor = System.Drawing.Color.Black;
            this.pgstatus.BlockSeparation = 3;
            this.pgstatus.BlockWidth = 5;
            this.pgstatus.Color = System.Drawing.Color.Gray;
            this.pgstatus.ForeColor = System.Drawing.Color.White;
            this.pgstatus.Location = new System.Drawing.Point(13, 59);
            this.pgstatus.MaxValue = 100;
            this.pgstatus.MinValue = 0;
            this.pgstatus.Name = "pgstatus";
            this.pgstatus.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal;
            this.pgstatus.ShowValue = true;
            this.pgstatus.Size = new System.Drawing.Size(744, 32);
            this.pgstatus.Step = 10;
            this.pgstatus.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Blocks;
            this.pgstatus.TabIndex = 0;
            this.pgstatus.Value = 0;
            // 
            // ShiftnetDecryptor
            // 
            this.AcceptButton = this.btnstart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 443);
            this.Widgets.Add(this.panel1);
            this.Name = "ShiftnetDecryptor";
            this.Text = "ShiftnetDecryptor";
            this.Load += new System.EventHandler(this.ShiftnetDecryptor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBarEX pgstatus;
        private ShiftUI.Label label1;
        private ShiftUI.RichTextBox txtstatus;
        private ShiftUI.TextBox txtaddress;
        private ShiftUI.Label label2;
        private ShiftUI.Button btnstart;
        private ShiftUI.Panel panel1;
        private ShiftUI.Timer tmrdecrypt;
    }
}