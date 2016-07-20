namespace ShiftOS
{
    partial class ShifterColorInput
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
            this.pnlmainbuttoncolour = new ShiftUI.Panel();
            this.lblabel = new ShiftUI.Label();
            this.SuspendLayout();
            // 
            // pnlmainbuttoncolour
            // 
            this.pnlmainbuttoncolour.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlmainbuttoncolour.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.pnlmainbuttoncolour.Location = new System.Drawing.Point(128, 3);
            this.pnlmainbuttoncolour.MaximumSize = new System.Drawing.Size(41, 20);
            this.pnlmainbuttoncolour.Name = "pnlmainbuttoncolour";
            this.pnlmainbuttoncolour.Size = new System.Drawing.Size(41, 20);
            this.pnlmainbuttoncolour.TabIndex = 3;
            // 
            // lblabel
            // 
            this.lblabel.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lblabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblabel.Location = new System.Drawing.Point(3, 6);
            this.lblabel.Name = "lblabel";
            this.lblabel.Size = new System.Drawing.Size(122, 19);
            this.lblabel.TabIndex = 2;
            this.lblabel.Text = "Main Button Colour:";
            this.lblabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShifterColorInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.Widgets.Add(this.pnlmainbuttoncolour);
            this.Widgets.Add(this.lblabel);
            this.Name = "ShifterColorInput";
            this.Size = new System.Drawing.Size(173, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel pnlmainbuttoncolour;
        private ShiftUI.Label lblabel;

    }
}
