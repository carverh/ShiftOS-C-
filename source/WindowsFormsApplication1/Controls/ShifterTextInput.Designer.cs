﻿namespace ShiftOS
{
    partial class ShifterTextInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txttext = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txttext
            // 
            this.txttext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttext.BackColor = System.Drawing.Color.White;
            this.txttext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttext.ForeColor = System.Drawing.Color.Black;
            this.txttext.Location = new System.Drawing.Point(106, 7);
            this.txttext.MinimumSize = new System.Drawing.Size(5, 2);
            this.txttext.Name = "txttext";
            this.txttext.Size = new System.Drawing.Size(116, 22);
            this.txttext.TabIndex = 32;
            // 
            // Label51
            // 
            this.Label51.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label51.Location = new System.Drawing.Point(0, 0);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(100, 29);
            this.Label51.TabIndex = 31;
            this.Label51.Text = "Label:";
            this.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShifterTextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txttext);
            this.Controls.Add(this.Label51);
            this.Name = "ShifterTextInput";
            this.Size = new System.Drawing.Size(222, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttext;
        private System.Windows.Forms.Label Label51;
    }
}
