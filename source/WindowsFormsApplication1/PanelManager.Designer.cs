namespace ShiftOS
{
    partial class PanelManager
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
            this.pnlmain = new System.Windows.Forms.Panel();
            this.btndone = new System.Windows.Forms.Button();
            this.pnlbgcolor = new System.Windows.Forms.Panel();
            this.Label40 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.txtheight = new System.Windows.Forms.TextBox();
            this.pnlmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlmain
            // 
            this.pnlmain.BackColor = System.Drawing.Color.White;
            this.pnlmain.Controls.Add(this.txtheight);
            this.pnlmain.Controls.Add(this.Label36);
            this.pnlmain.Controls.Add(this.pnlbgcolor);
            this.pnlmain.Controls.Add(this.Label40);
            this.pnlmain.Controls.Add(this.btndone);
            this.pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlmain.ForeColor = System.Drawing.Color.Black;
            this.pnlmain.Location = new System.Drawing.Point(0, 0);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(360, 378);
            this.pnlmain.TabIndex = 0;
            // 
            // btndone
            // 
            this.btndone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndone.Location = new System.Drawing.Point(273, 343);
            this.btndone.Name = "btndone";
            this.btndone.Size = new System.Drawing.Size(75, 23);
            this.btndone.TabIndex = 0;
            this.btndone.Text = "Done";
            this.btndone.UseVisualStyleBackColor = true;
            this.btndone.Click += new System.EventHandler(this.btndone_Click);
            // 
            // pnlbgcolor
            // 
            this.pnlbgcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbgcolor.Location = new System.Drawing.Point(307, 101);
            this.pnlbgcolor.Name = "pnlbgcolor";
            this.pnlbgcolor.Size = new System.Drawing.Size(41, 20);
            this.pnlbgcolor.TabIndex = 22;
            this.pnlbgcolor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setbgcolor);
            // 
            // Label40
            // 
            this.Label40.AutoSize = true;
            this.Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label40.Location = new System.Drawing.Point(12, 101);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(259, 16);
            this.Label40.TabIndex = 23;
            this.Label40.Text = "Background Color (right-click to set image)";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.Location = new System.Drawing.Point(12, 136);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(50, 16);
            this.Label36.TabIndex = 24;
            this.Label36.Text = "Height:";
            // 
            // txtheight
            // 
            this.txtheight.BackColor = System.Drawing.Color.White;
            this.txtheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtheight.ForeColor = System.Drawing.Color.Black;
            this.txtheight.Location = new System.Drawing.Point(325, 134);
            this.txtheight.Name = "txtheight";
            this.txtheight.Size = new System.Drawing.Size(23, 22);
            this.txtheight.TabIndex = 25;
            this.txtheight.TextChanged += new System.EventHandler(this.txtheight_TextChanged);
            // 
            // PanelManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 378);
            this.Controls.Add(this.pnlmain);
            this.Name = "PanelManager";
            this.Text = "PanelManager";
            this.Load += new System.EventHandler(this.PanelManager_Load);
            this.pnlmain.ResumeLayout(false);
            this.pnlmain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Button btndone;
        private System.Windows.Forms.Panel pnlbgcolor;
        private System.Windows.Forms.Label Label40;
        private System.Windows.Forms.Label Label36;
        private System.Windows.Forms.TextBox txtheight;
    }
}