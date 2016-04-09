namespace ShiftOS
{
    partial class BitnoteConverter
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
            this.txtcodepoints = new System.Windows.Forms.TextBox();
            this.lbstatus = new System.Windows.Forms.Label();
            this.btnconvert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtcodepoints
            // 
            this.txtcodepoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcodepoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtcodepoints.Location = new System.Drawing.Point(28, 12);
            this.txtcodepoints.Name = "txtcodepoints";
            this.txtcodepoints.Size = new System.Drawing.Size(44, 26);
            this.txtcodepoints.TabIndex = 0;
            this.txtcodepoints.TextChanged += new System.EventHandler(this.txtcodepoints_TextChanged);
            // 
            // lbstatus
            // 
            this.lbstatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbstatus.AutoSize = true;
            this.lbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbstatus.Location = new System.Drawing.Point(78, 16);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(78, 22);
            this.lbstatus.TabIndex = 1;
            this.lbstatus.Text = "> 0 BTN";
            // 
            // btnconvert
            // 
            this.btnconvert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnconvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconvert.Location = new System.Drawing.Point(0, 76);
            this.btnconvert.Name = "btnconvert";
            this.btnconvert.Size = new System.Drawing.Size(229, 23);
            this.btnconvert.TabIndex = 2;
            this.btnconvert.Text = "Convert";
            this.btnconvert.UseVisualStyleBackColor = true;
            this.btnconvert.Click += new System.EventHandler(this.btnconvert_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnconvert);
            this.panel1.Controls.Add(this.lbstatus);
            this.panel1.Controls.Add(this.txtcodepoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 99);
            this.panel1.TabIndex = 3;
            // 
            // BitnoteConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 99);
            this.Controls.Add(this.panel1);
            this.Name = "BitnoteConverter";
            this.Text = "BitnoteConverter";
            this.Load += new System.EventHandler(this.BitnoteConverter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodepoints;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.Button btnconvert;
        private System.Windows.Forms.Panel panel1;
    }
}