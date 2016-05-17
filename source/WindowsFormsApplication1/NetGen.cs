using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class NetGen : Form
    {
        public NetGen()
        {
            InitializeComponent();
        }

        private EnemyHacker network = null;
        private int stage = 0;
        private List<Computer> potentialModules = null;
        private Module fmod = null;

        private void NetGen_Load(object sender, EventArgs e)
        {
            SetupUI();
            potentialModules = new List<Computer>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetupUI()
        {
            btnback.Hide();
            
            switch(stage)
            {
                case 0:
                    lbtitle.Text = "Network Information";
                    lbdescription.Text = "Information about the network.";
                    pnlnetinf.BringToFront();
                    break;
                case 1:
                    //create net
                    network = new EnemyHacker(txtnetname.Text, txtnetdesc.Text, txtnetdesc.Text, 0, 0, "unknown");
                    var c = network.Network[0].Deploy();
                    c.Left = (pnlnetdesign.Width - 64) / 2;
                    c.Top = (pnlnetdesign.Height - 64) / 2;
                    pnlnetdesign.Controls.Add(c);
                    c.Select += (s, a) =>
                    {
                        ShowSysInf(c);
                    };
                    c.Show();
                    lbtitle.Text = "Playfield Designer";
                    lbdescription.Text = "Design the playfield of the network. Strategically place defensive and offensive modules to protect the Core from attacks. You can have a maximum of 20 objects (minus core) on-screen.";
                    pnlnetdesign.BringToFront();
                    btnnext.Text = "Finish";
                    break;
                case 2:
                    var tp = new TextPad();
                    var core = network.Network[0];
                    core.X = 0;
                    core.Y = 0;
                    foreach (var pc in potentialModules)
                    {
                        var m = new Module(pc.Type, pc.Grade, pc.Hostname);
                        m.X = pc.Left;
                        m.Y = pc.Top;
                        network.AddModule(m);
                    }
                    var json = JsonConvert.SerializeObject(network);
                    API.CreateForm(tp, "Network JSON", API.GetIcon("TextPad"));
                    tp.txtuserinput.Text = json;
                    this.Close();
                    break;
            }

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            stage += 1;
            SetupUI();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            stage -= 1;
        }

        private void btnaddmodule_Click(object sender, EventArgs e)
        {
            SetupBuyable();
            pnlbuy.Visible = !pnlbuy.Visible;
        }

        List<FutureModule> BuyableModules = null;

        public void SetupBuyable()
        {
            BuyableModules = Hacking.GetFutureModules();
            cmbbuyable.Items.Clear();
            foreach (var m in BuyableModules)
            {
                cmbbuyable.Items.Add(m.Name);
            }
            lbmoduleinfo.Text = "";
            txtgrade.Text = "1";
        }

        private void SetupModuleInfo()
        {
            bool cont = false;
            FutureModule m = null;
            foreach (var mod in BuyableModules)
            {
                if (mod.Name == cmbbuyable.Text)
                {
                    m = mod;
                    cont = true;
                }
            }
            if (cont == true)
            {
                lbmoduleinfo.Text = m.Name;
                lbmoduleinfo.Text += Environment.NewLine + $"Cost: {m.Cost * Convert.ToInt32(txtgrade.Text)} CP";
                lbmoduleinfo.Text += Environment.NewLine + $"Description: {Environment.NewLine}{m.Description}";
            }
        }

        private void cmbbuyable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupModuleInfo();
        }

        private void txtgrade_TextChanged(object sender, EventArgs e)
        {
            int grade = 0;
            int.TryParse(txtgrade.Text, out grade);
            if(grade < 1)
            {
                txtgrade.Text = "1";
            }
            else if(grade > 4)
            {
                txtgrade.Text = "4";
            }
        }

        bool PlacingNewModule = false;

        private void btndonebuying_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cmbbuyable.Text))
            {
                if(!string.IsNullOrEmpty(cmbbuyable.Text))
                {
                    int grade = Convert.ToInt32(txtgrade.Text);
                    string hostname = txthostname.Text;
                    FutureModule m = null;
                    foreach(var mod in BuyableModules)
                    {
                        if(mod.Name == cmbbuyable.Text)
                        {
                            m = mod;
                        }
                    }
                    if(m != null)
                    {
                        bool cont = true;
                        if (potentialModules.Count <= 20)
                        {
                            foreach (var pc in potentialModules)
                            {
                                if (pc.Hostname == hostname)
                                {
                                    cont = false;
                                }
                            }
                        }
                        else
                        {
                            cont = false;
                        }
                        if(cont)
                        {
                            var newModule = new Module(m.Type, grade, hostname);
                            fmod = newModule;
                            PlacingNewModule = true;
                            pnlbuy.Hide();
                        }
                        else
                        {
                            API.CreateInfoboxSession("Can't place new module", "Either an existing module with the same hostname already exists in the field, or you have hit the maximum.", infobox.InfoboxMode.Info);
                        }
                    }
                }
            }
        }

        private void place_module(object sender, MouseEventArgs e)
        {
            if (PlacingNewModule == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var coordinates = pnlnetdesign.PointToClient(Cursor.Position);
                    int x = coordinates.X;
                    int y = coordinates.Y;

                    var computerToPlace = fmod.Deploy();
                    computerToPlace.Location = new Point(x, y);
                    pnlnetdesign.Controls.Add(computerToPlace);
                    potentialModules.Add(computerToPlace);
                    computerToPlace.Select += (s, a) =>
                    {
                        ShowSysInf(computerToPlace);
                    };
                    computerToPlace.Show();
                }
                else
                {
                    PlacingNewModule = false;
                }
            }
        }

        private Computer SelectedSystem = null;

        public void ShowSysInf(Computer pc)
        {
            pnlpcinfo.Left = pnlbuy.Left;
            var nl = Environment.NewLine;
            SelectedSystem = pc;
            pnlpcinfo.Show();
            lbpcinfo.Text = $"Hostname: {SelectedSystem.Hostname}";
            lbpcinfo.Text += $"{nl}Max HP: {SelectedSystem.HP}";
            lbpcinfo.Text += $"{nl}Grade: {SelectedSystem.Grade}";
            lbpcinfo.Text += $"{nl}Type: {SelectedSystem.Type}"; 
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(SelectedSystem != null)
            {
                potentialModules.Remove(SelectedSystem);
                pnlnetdesign.Controls.Remove(SelectedSystem);
                SelectedSystem.Dispose();
            }
            SelectedSystem = null;
            pnlpcinfo.Hide();
        }

        private void btncloseinfo_Click(object sender, EventArgs e)
        {
            SelectedSystem = null;
            pnlpcinfo.Hide();
        }
    }
}
