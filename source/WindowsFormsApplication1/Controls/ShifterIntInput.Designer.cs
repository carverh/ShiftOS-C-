namespace ShiftOS
{
    partial class ShifterIntInput
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
            this.txttext = new ShiftUI.TextBox();
            this.Label51 = new ShiftUI.Label();
            this.SuspendLayout();
            // 
            // txttext
            // 
            this.txttext.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Right)));
            this.txttext.BackColor = System.Drawing.Color.White;
            this.txttext.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txttext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttext.ForeColor = System.Drawing.Color.Black;
            this.txttext.Location = new System.Drawing.Point(174, 3);
            this.txttext.MinimumSize = new System.Drawing.Size(5, 2);
            this.txttext.Name = "txttext";
            this.txttext.Size = new System.Drawing.Size(36, 22);
            this.txttext.TabIndex = 32;
            this.txttext.TextChanged += new System.EventHandler(this.txttext_TextChanged);
            // 
            // Label51
            // 
            this.Label51.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.Label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label51.Location = new System.Drawing.Point(0, 0);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(168, 29);
            this.Label51.TabIndex = 31;
            this.Label51.Text = "Label:";
            this.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShifterIntInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.Widgets.Add(this.txttext);
            this.Widgets.Add(this.Label51);
            this.Name = "ShifterIntInput";
            this.Size = new System.Drawing.Size(213, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ShiftUI.TextBox txttext;
        private ShiftUI.Label Label51;

    }
}
