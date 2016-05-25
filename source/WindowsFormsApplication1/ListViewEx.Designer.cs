namespace ShiftOS
{
    partial class ListViewEx
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
            this.tblist = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tblist
            // 
            this.tblist.AutoSize = true;
            this.tblist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblist.ColumnCount = 2;
            this.tblist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblist.Location = new System.Drawing.Point(0, 0);
            this.tblist.Name = "tblist";
            this.tblist.RowCount = 2;
            this.tblist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblist.Size = new System.Drawing.Size(521, 343);
            this.tblist.TabIndex = 0;
            // 
            // ListViewEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblist);
            this.Name = "ListViewEx";
            this.Size = new System.Drawing.Size(521, 343);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblist;
    }
}
