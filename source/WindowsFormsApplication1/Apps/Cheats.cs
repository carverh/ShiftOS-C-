using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShiftOS.Online.Hacking;

namespace ShiftOS.Apps
{
    public partial class Cheats : Form
    {
        public Cheats()
        {
            InitializeComponent();
        }

        public void SetOptionsEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control != progressDisplay)
                {
                    control.Enabled = enabled;
                }
            }
        }

        private void getAllUpgrades_Click(object sender, EventArgs e)
        {
            progressDisplay.Enabled = true;
            progressDisplay.Value = 0;
            progressDisplay.Maximum = Shiftorium.Utilities.GetAvailable().Count;
            foreach (var upg in Shiftorium.Utilities.GetAvailable())
            {
                API.Upgrades[upg.id] = true;
                progressDisplay.PerformStep();
                WriteLogLine("Installed upgrade \"" + upg.Name + "\"...");
            }
            API.UpdateWindows();
            API.CurrentSession.SetupDesktop();
            progressDisplay.Enabled = false;
        }

        public void WriteLogLine(string line)
        {
            LogBox.AppendText("\n"+line);
        }

        private void AddMoney_Click(object sender, EventArgs e)
        {
            int qty;
            bool isInt = Int32.TryParse(AddMoneyQty.Text, out qty);
            if (!isInt)
            {
                MessageBox.Show("Not a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShiftOS.API.AddCodepoints(qty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Package_Grabber.SendMessage(Matchmaker.SelectedServer.IPAddress, );
        }
    }
}
