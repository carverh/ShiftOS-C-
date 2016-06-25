using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ShiftOS
{
    public partial class BitnoteDigger : Form
    {
        /// <summary>
        /// GUI for the Bitnote Digger fake Appscape Package.
        /// </summary>
        public BitnoteDigger()
        {
            InitializeComponent();
        }

        private void BitnoteDigger_Load(object sender, EventArgs e)
        {
            getdiggergrade();
            updatestats();
        }

        /// <summary>
        /// Model for a digger grade.
        /// </summary>
        public class diggergrade
        {
            public string Name { get; set; }
            public int Level { get; set; }
        }

        /// <summary>
        /// Retrieves the proper digger grade.
        /// </summary>
        public void getdiggergrade()
        {
            if(!File.Exists(Paths.Drivers + "BNDigger.dri"))
            {
                var d = new diggergrade();
                d.Level = 1;
                d.Name = "Surface Scratcher";
                bitnotediggergrade = d;
                File.WriteAllText(Paths.Drivers + "BNDigger.dri", API.BitnoteEncryption.Encrypt(JsonConvert.SerializeObject(d)));
            }
            else
            {
                string enc = File.ReadAllText(Paths.Drivers + "BNDigger.dri");
                bitnotediggergrade = JsonConvert.DeserializeObject<diggergrade>(API.BitnoteEncryption.Decrypt(enc));
            }
        }

        /// <summary>
        /// Saves the digger grade to the save game.
        /// </summary>
        public void SaveDigger()
        {
            var d = bitnotediggergrade;
            File.WriteAllText(Paths.Drivers + "BNDigger.dri", API.BitnoteEncryption.Encrypt(JsonConvert.SerializeObject(d)));
        }

        public decimal bitnotesmined = 0;
        public diggergrade bitnotediggergrade = null;
        public double miningspeed = 0.00005;

        /// <summary>
        /// Sets up digger statistics.
        /// </summary>
        public void updatestats()
        {
            lbldiggerstatsgrade.Text = "Digger Grade: " + bitnotediggergrade.Name;
            switch (bitnotediggergrade.Level)
            {
                case 1:
                    lbldiggerstatsname.Text = "Surface Scratcher";
                    lbldiggerstatsspeed.Text = "Speed: 0.00001";
                    miningspeed = 0.00001;
                    break;
                case 2:
                    lbldiggerstatsname.Text = "Name: Sediment Mover";
                    lbldiggerstatsspeed.Text = "Speed: 0.00002";
                    miningspeed = 0.00002;
                    break;
                case 3:
                    lbldiggerstatsname.Text = "Name: Rock Crusher";
                    lbldiggerstatsspeed.Text = "0.00004";
                    miningspeed = 0.00004;
                    break;
                case 4:
                    lbldiggerstatsname.Text = "Name: Massive Drill";
                    lbldiggerstatsspeed.Text = "Speed: 0.00008";
                    miningspeed = 0.00008;
                    break;
                case 5:
                    lbldiggerstatsname.Text = "Name: Kola";
                    lbldiggerstatsspeed.Text = "Speed: 0.00016";
                    miningspeed = 0.00016;
                    break;
            }
            turbomodespeed.Text = (miningspeed * 2).ToString();
        }

        /// <summary>
        /// Updates the digger.
        /// </summary>
        /// <param name="grade">New grade.</param>
        /// <param name="price">Price (BTN) to subtract.</param>
        /// <param name="name">New name.</param>
        public void updategrade(int grade, decimal price, string name)
        {
            if (API.BitnoteAddress.Bitnotes >= price)
            {
                if (bitnotediggergrade.Level < grade)
                {
                    bitnotediggergrade.Level = grade;
                    bitnotediggergrade.Name = name;
                    API.BitnoteAddress.Bitnotes -= price;
                    API.CreateInfoboxSession("Upgraded to " + name,
                        "Your digger has been successfully upgraded to grade " + grade + ". The '" + name + "'",
                        infobox.InfoboxMode.Info);
                    SaveDigger();
                    updatestats();
                }
                else {
                    API.CreateInfoboxSession("Aready Upgraded",
                        "The Bitnote Digger is already upgraded to grade " + bitnotediggergrade.Level.ToString() + ". There is no point in downgrading to grade " + grade,
                        infobox.InfoboxMode.Info);
                }
            }
            else {
                API.CreateInfoboxSession("Insufficient Funds",
                "You do not have enough Bitnotes to complete this purchase",
                infobox.InfoboxMode.Info);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrcalcbitnotesmined_Tick(object sender, EventArgs e)
        {
            bitnotesmined += Convert.ToDecimal(miningspeed);
            lbltotalbitcoinsmined.Text = (Math.Round(bitnotesmined, 5)).ToString("#.#####");
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnstart_Click(object sender, EventArgs e)
        {
            tmrcalcbitnotesmined.Start();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnstop_Click(object sender, EventArgs e)
        {
            tmrcalcbitnotesmined.Stop();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnsend_Click(object sender, EventArgs e)
        {
            if (txtsendaddress.Text == API.BitnoteAddress.Address)
            {
                API.BitnoteAddress.Bitnotes += bitnotesmined;
            }
            bitnotesmined = 0;
            lbltotalbitcoinsmined.Text = (Math.Round(bitnotesmined, 5)).ToString("#.#####");
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnturbomode_Click(object sender, EventArgs e)
        {
            if (tmrturbomode.Enabled == false)
            {
                miningspeed = (miningspeed * 2);
                tmrturbomode.Start();
                btnturbomode.Text = "Disable Turbo Mode";
            }
            else {
                miningspeed = (miningspeed / 2);
                tmrturbomode.Stop();
                btnturbomode.Text = "Activate Turbo Mode";
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrturbomode_Tick(object sender, EventArgs e)
        {
            if (API.Codepoints >= 1)
            {
                API.RemoveCodepoints(1);
            }
            else {
                miningspeed = (miningspeed / 2);
                tmrturbomode.Stop();
                btnturbomode.Text = "Activate Turbo Mode";
                API.CreateInfoboxSession("Turbo Mode disabled",
                "Turbo Mode has been disabled due to your lack of Code Points.",
                infobox.InfoboxMode.Info);
            }
        }

        private void btnupgrade_Click(object sender, EventArgs e)
        {
            string newname = "Surface Scratcher";
            double price = 1;
            switch (bitnotediggergrade.Name) {
                case "Surface Scratcher":
                    newname = "Name: Sediment Mover";
                    price = 1.5;
                    break;
                case "Sediment Mover":
                    newname = "Name: Rock Crusher";
                    price = 2;
                    break;
                case "Rock Crusher":
                    newname = "Name: Massive Drill";
                    price = 4;
                    break;
                case "Massive Drill":
                    newname = "Name: Kola";
                    price = 8;
                    break;

            }
            updategrade(bitnotediggergrade.Level + 1, (decimal)price, newname);

        }
    }
}
