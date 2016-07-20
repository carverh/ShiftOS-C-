namespace ShiftOS.Apps
{
    partial class Cheats
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
            this.getAllUpgrades = new System.Windows.Forms.Button();
            this.progressDisplay = new System.Windows.Forms.ProgressBar();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.AddMoney = new System.Windows.Forms.Button();
            this.Online = new System.Windows.Forms.Button();
            this.AddMoneyQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getAllUpgrades
            // 
            this.getAllUpgrades.Location = new System.Drawing.Point(30, 37);
            this.getAllUpgrades.Name = "getAllUpgrades";
            this.getAllUpgrades.Size = new System.Drawing.Size(147, 23);
            this.getAllUpgrades.TabIndex = 0;
            this.getAllUpgrades.Text = "Get All Upgrades";
            this.getAllUpgrades.UseVisualStyleBackColor = true;
            this.getAllUpgrades.Click += new System.EventHandler(this.getAllUpgrades_Click);
            // 
            // progressDisplay
            // 
            this.progressDisplay.Enabled = false;
            this.progressDisplay.Location = new System.Drawing.Point(12, 351);
            this.progressDisplay.Name = "progressDisplay";
            this.progressDisplay.Size = new System.Drawing.Size(492, 23);
            this.progressDisplay.Step = 1;
            this.progressDisplay.TabIndex = 1;
            // 
            // LogBox
            // 
            this.LogBox.AcceptsReturn = true;
            this.LogBox.Location = new System.Drawing.Point(12, 242);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(492, 103);
            this.LogBox.TabIndex = 2;
            this.LogBox.Text = " --- LOG ---";
            this.LogBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddMoney
            // 
            this.AddMoney.Location = new System.Drawing.Point(170, 94);
            this.AddMoney.Name = "AddMoney";
            this.AddMoney.Size = new System.Drawing.Size(67, 23);
            this.AddMoney.TabIndex = 3;
            this.AddMoney.Text = "Add";
            this.AddMoney.UseVisualStyleBackColor = true;
            this.AddMoney.Click += new System.EventHandler(this.AddMoney_Click);
            // 
            // Online
            // 
            this.Online.Enabled = false;
            this.Online.Location = new System.Drawing.Point(12, 213);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(152, 23);
            this.Online.TabIndex = 4;
            this.Online.Text = "Win Online";
            this.Online.UseVisualStyleBackColor = true;
            this.Online.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddMoneyQty
            // 
            this.AddMoneyQty.Location = new System.Drawing.Point(30, 96);
            this.AddMoneyQty.Name = "AddMoneyQty";
            this.AddMoneyQty.Size = new System.Drawing.Size(134, 20);
            this.AddMoneyQty.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add CodePoints:";
            // 
            // Cheats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddMoneyQty);
            this.Controls.Add(this.Online);
            this.Controls.Add(this.AddMoney);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.progressDisplay);
            this.Controls.Add(this.getAllUpgrades);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cheats";
            this.Text = "Cheats";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getAllUpgrades;
        private System.Windows.Forms.ProgressBar progressDisplay;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button AddMoney;
        private System.Windows.Forms.Button Online;
        private System.Windows.Forms.TextBox AddMoneyQty;
        private System.Windows.Forms.Label label1;
    }
}