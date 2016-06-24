using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShiftOS;
using SaveSystem;

namespace Shiftorium
{
    public partial class Frontend : Form
    {
        public Frontend()
        {
            InitializeComponent();
        }

        List<Upgrade> AvailableUpgrades = new List<Upgrade>();
        Upgrade selectedUpgrade = null;

        private void tmrcodepointsupdate_Tick(object sender, EventArgs e)
        {
            lbcodepoints.Text = "Codepoints: " + API.Codepoints.ToString();
        }

        private void Frontend_Load(object sender, EventArgs e)
        {
            ColumnHeader name = new ColumnHeader();
            name.Text = "Upgrade Name";
            name.Width = lbupgrades.Width;
            
            lbupgrades.Columns.Add(name);
            GetUpgrades();
        }

        public void GetUpgrades()
        {
            bool ShowUpgrades = true;
            lbupgrades.Items.Clear();
            AvailableUpgrades.Clear();
            Categories.Clear();
            foreach (Upgrade upgrade in Utilities.GetAvailable())
            {
                AvailableUpgrades.Add(upgrade);
            }
            GetCategories();
            try {
                lbcategory.Text = Categories[SelectedCategory].ToUpper();
                if(lbcategory.Text != "FUNDAMENTAL") {
                    if(API.Upgrades["hacking"] == false)
                    {
                        Hacking.StartTutorial();
                        PreviousCategory();
                    }
                    else
                    {
                        if(API.Upgrades.ContainsKey(lbcategory.Text.ToLower()))
                        {
                            if(API.Upgrades[lbcategory.Text.ToLower()] == false)
                            {
                                btnhack.Show();
                                ShowUpgrades = false;
                            }
                            else
                            {
                                btnhack.Hide();
                            }
                        }
                    }
                }
                else
                {
                    btnhack.Hide();
                }
            }
            catch
            {
                lbcategory.Text = "No upgrades!";
            }
            foreach(Upgrade upg in AvailableUpgrades)
            {
                if (ShowUpgrades == true)
                {
                    AddItem(upg);
                }
            }
        }

        public void AddItem(Upgrade upgrade)
        {
            ListViewItem lv = new ListViewItem();
            var c = upgrade.Cost / API.CurrentSave.PriceDivider;
            lv.Text = upgrade.Name.Replace(upgrade.Cost.ToString(), c.ToString());
            lv.Tag = upgrade.id;
            if (upgrade.Category.ToUpper() == lbcategory.Text.ToUpper())
            {
                if (!upgrade.id.Contains("dummy"))
                {
                    lbupgrades.Items.Add(lv);
                }
            }
        }

        public void GetCategories()
        {
            foreach(var upg in AvailableUpgrades)
            {
                if(Categories.Contains(upg.Category))
                {
                }
                else
                {
                    Categories.Add(upg.Category);
                }
            }
        }

        private void lbupgrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                ListViewItem item = lbupgrades.SelectedItems[0];
                string upg = (string)item.Tag;
                foreach (Upgrade upgrade in AvailableUpgrades)
                {
                    if (upgrade.id == upg)
                    {
                        pnlintro.Hide();
                        lbupgradename.Text = upgrade.Name.Replace($" - {upgrade.Cost} CP", "");
                        lbudescription.Text = upgrade.Description;
                        btnbuy.Show();
                        lbprice.Text = (upgrade.Cost / API.CurrentSave.PriceDivider).ToString() + " CP";
                        picpreview.Image = upgrade.Preview;
                        selectedUpgrade = upgrade;
                    }
                }
            } catch
            {
                //do nothing.
            }

        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            if(Utilities.Buy(selectedUpgrade) == true)
            {
                btnbuy.Hide();
                lbprice.Text = "Upgrade installed.";
            }
            else
            {
                lbprice.Text = "Can't afford!";
            }
            GetUpgrades();
            lbupgrades.Focus();
        }

        public List<string> Categories = new List<string>();
        public int SelectedCategory = 0;

        public void PreviousCategory()
        {
            if(SelectedCategory > 0)
            {
                SelectedCategory -= 1;
                GetUpgrades();
            }
            else
            {
                API.PlaySound(ShiftOS.Properties.Resources._3beepvirus);
            }
        }

        public void NextCategory()
        {
            if (SelectedCategory < Categories.Count - 1)
            {
                SelectedCategory += 1;
                GetUpgrades();
            }
            else
            {
                API.PlaySound(ShiftOS.Properties.Resources._3beepvirus);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            PreviousCategory();
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            NextCategory();
        }

        private void btnhack_Click(object sender, EventArgs e)
        {
            if(API.Upgrades["multitasking"] == true)
            {
                var t = new Terminal();
                API.CreateForm(t, API.LoadedNames.TerminalName, ShiftOS.Properties.Resources.iconTerminal);
                t.StartHackingSession(lbcategory.Text.ToLower());
            }
            else
            {
                API.CreateInfoboxSession("Dependencies not met.", "You need the following upgrades: Multitasking to embark on this activity.", infobox.InfoboxMode.Info);
            }
        }
    }
}
