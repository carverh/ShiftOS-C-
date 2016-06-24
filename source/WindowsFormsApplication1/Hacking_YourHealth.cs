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
    public partial class Hacking_YourHealth : Form
    {
        public Hacking_YourHealth()
        {
            InitializeComponent();
        }

        public Hacking_YourHealth(EnemyHacker enemy)
        {
            EnemyNet = enemy;
            InitializeComponent();
        }

        public Computer ThisPC = null;
        public Hacking_Enemy EnemyScreen = null;
        public EnemyHacker EnemyNet = null;
        private decimal TotalHP = 0;

        private List<Module> MyNetwork = new List<Module>();

        private void Hacking_YourHealth_Load(object sender, EventArgs e)
        {
            AntiVirusBounds = new List<Rectangle>();
            TutorialNetwork.Add(new Module(SystemType.Core, 1, "localhost"));
            foreach(var m in GetMyNet())
            {
                if(m.Type == SystemType.Core)
                {
                    MyNetwork.Add(m);
                }
            }
            VisualizeNetwork();
            if (EnemyNet != null)
            {
                var h = new Hacking_Enemy(this, EnemyNet);
                tmrhealthdetect.Start();
                EnemyScreen = h;
                API.CreateForm(h, "Enemy Hacker", Properties.Resources.iconTerminal);

            }
            else
            {
                var h = new Hacking_Enemy(this, Hacking.EnemyHackers[new Random().Next(0, Hacking.EnemyHackers.Count - 1)]);
                tmrhealthdetect.Start();
                EnemyScreen = h;
                API.CreateForm(h, "Enemy Hacker", Properties.Resources.iconTerminal);
            }
            ThisPC.EnemyComputer = EnemyScreen.ThisPC;
            if(IsTutorial)
            {
                SetupTutorialUI(0);
            }
        }

        private void VisualizeNetwork()
        {
            AllComputers = new List<Computer>();
            foreach(Module m in MyNetwork)
            {
                if (AllComputers.Count <= 10)
                {
                    var c = m.Deploy();
                    if (c.Type == SystemType.Core)
                    {
                        ThisPC = c;
                    }
                    AddModule(c);
                }
            }
        }

        

        private void btnvirus_Click(object sender, EventArgs e)
        {
            ThisPC.EnemyComputer.LaunchAttack(AttackType.Virus);
        }

        public List<Computer> AllComputers = null;

        private void tmrhealthdetect_Tick(object sender, EventArgs e)
        {
            var rnd = new Random();
            int chance = 0;
            foreach(var pc in AllComputers)
            {
                if (pc.Disabled == false)
                {
                    if (pc.Enemies != null)
                    {
                        foreach (var enemy in pc.Enemies)
                        {
                            if (EnemyScreen.AllComputers.Contains(enemy))
                            {
                                chance = rnd.Next(1, 15);
                                if (chance == 7)
                                {
                                    if (IsTutorial)
                                    {
                                        if (TutorialProgress == 32 || TutorialProgress == 9)
                                        {
                                            enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                        }
                                    }
                                    else {
                                        enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            decimal health = 0;
            EnemyScreen.Enemy = this;
            foreach (var pc in AllComputers)
            {
                health += (decimal)pc.HP;
            }
            if(health > TotalHP)
            {
                TotalHP = health;
            }
            decimal percent = (health / TotalHP) * 100;
            lbstats.Text = $"System Health: {percent}%";
            if(ThisPC.HP <= 0)
            {
                API.CreateInfoboxSession("System compromised.", "The enemy hacker has overthrown your defenses and compromised your system. You will need to wait an hour before you can start another hack battle.", infobox.InfoboxMode.Info);
                Hacking.Failure = true;
                Hacking.FailDate = DateTime.Now;
                UserRequestedClose = false;
                this.Close();
                EnemyScreen.UserRequestedClose = false;
                EnemyScreen.Close();
                this.Close();
            }
        }

        public bool UserRequestedClose = true;

        private void this_Closing(object sender, FormClosingEventArgs e)
        {
            if (UserRequestedClose == false)
            {
                tmrhealthdetect.Stop();
                foreach (var pc in AllComputers)
                {
                    pc.HP = 0;
                }
            }
        }

        public Computer SelectedComputer = null;

        public void AddModule(Computer newModule) {
            panel1.Controls.Add(newModule);
            int hp = newModule.HP;

            TotalHP += newModule.HP;
            AllComputers.Add(newModule);
            newModule.Show();
            newModule.OnDestruction += (object s, EventArgs a) =>
            {
                if (this.SelectedComputer == newModule)
                {
                    SelectedComputer = null;
                }
                if(newModule.Type == SystemType.Firewall)
                {
                    Firewall_Destroy(newModule);
                }
                AllComputers.Remove(newModule);
                newModule.Dispose();
            };
            newModule.Select += (object s, EventArgs e) =>
            {
                SelectedComputer = newModule;
                ShowPCInfo(newModule.Hostname);
                if(IsTutorial)
                {
                    if(TutorialProgress == 6)
                    {
                        if(newModule == ThisPC)
                        {
                            SetupTutorialUI(7);
                        }
                    }
                }
            };
            newModule.HP_Decreased += new EventHandler(System_Damaged);
            newModule.OnRepair += new EventHandler(System_Repaired);
            if (newModule.Type == SystemType.Antivirus || newModule.Type == SystemType.RepairModule)
            {
                var b = newModule.GetAreaOfEffect();
                AntiVirusBounds.Add(b);
                panel1.Refresh();
                newModule.AntivirusRepair += (object s, EventArgs a) =>
                {
                    foreach (Computer pc in AllComputers)
                    {
                        if (pc != newModule && pc.Bounds.IntersectsWith(b))
                        {
                            if (newModule.Type == SystemType.RepairModule)
                            {
                                if (pc.HP < newModule.HP)
                                {
                                    if (pc.HP < pc.GetTotal())
                                    {
                                        pc.Repair(1);
                                    }
                                }

                            }
                            else {
                                if (pc.HP < 10)
                                {
                                    pc.Repair(1);
                                }
                            }
                        }
                    }
                };

            }
            if(newModule.Type == SystemType.Firewall)
            {
                var b = newModule.GetAreaOfEffect();
                AntiVirusBounds.Add(b);
                panel1.Refresh();
                Firewall_Deflect(newModule);
            }
            if(newModule.Type == SystemType.ServerStack)
            {
                newModule.MassDDoS += (object s, EventArgs a) =>
                {
                    EnemyScreen.Worm();
                };
            }
        }

        public void Worm()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 10);

            foreach (Computer c in AllComputers)
            {
                if (r == 5)
                {
                    c.Disable();
                }
            }
        }

        public void ShowPCInfo(string hostname)
        {
            Module mod = null;
            foreach(var m in GetMyNet())
            {
                if(m.Hostname == hostname)
                {
                    mod = m;
                }
            }
            if(mod != null)
            {
                pnlpcinfo.Show();
                lbmoduletitle.Text = "Module Info - " + hostname;
                lbpcinfo.Text = $"Hostname: {hostname}{Environment.NewLine}Type: {mod.Type.ToString()}";
                if (mod.Type == SystemType.Core)
                {
                    lbpcinfo.Text += Environment.NewLine + "This represents your main system. If this module is destroyed, you will automatically lose the battle. Protect it at all costs.";
                    btnupgrade.Hide();
                    btnpoweroff.Hide();
                }
                else {
                    lbpcinfo.Text += $"{Environment.NewLine}Grade: {mod.Grade}";
                    if (mod.Grade < 4)
                    {
                        btnupgrade.Show();
                    }
                    else
                    {
                        btnupgrade.Hide();
                    }
                    btnpoweroff.Show();
                }
            }
            Computer c = null;
            foreach(var pc in AllComputers)
            {
                if(pc.Hostname == hostname)
                {
                    c = pc;
                }
            }
            if(c != null)
            {
                lbtargets.Text = "Targets: ";
                if (c.Enemies != null)
                {
                    if(c.Enemies.Count > 0)
                    {
                        foreach(var pc in c.Enemies)
                        {
                            lbtargets.Text += " " + pc.Hostname + ",";
                        }
                    }
                    else
                    {
                        lbtargets.Text += " - Click on an enemy module to target it.";
                    }
                }
                else
                {
                    lbtargets.Text += " - Click on an enemy module to target it.";
                }
                lbtargets.Text += Environment.NewLine + "Some modules will not fire at their targets.";
            }
        }

        public void Firewall_Deflect(Computer fwall)
        {
            //Safegaurd...
            if(fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach(var pc in AllComputers)
                {
                    if (pc != fwall)
                    {
                        if (pc.Bounds.IntersectsWith(r))
                        {
                            pc.DamageDefector = fwall.Grade;
                        }
                    }
                }
            }
        }

        public void Firewall_Destroy(Computer fwall)
        {
            //Safegaurd...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllComputers)
                {
                    if (pc.Bounds.IntersectsWith(r))
                    {
                        pc.DamageDefector = 1;
                        UpdateFirewalls();
                    }
                }
            }
        }

        public void UpdateFirewalls()
        {
            foreach(var pc in AllComputers)
            {
                if(pc.Type == SystemType.Firewall)
                {
                    Firewall_Deflect(pc);
                }
            }
        }


        private void System_Repaired(object s, EventArgs e)
        {
            var c = (Computer)s;
            lbcompromised.Text = "System regenerating...";
            int location = c.Left - (lbcompromised.Width / 4);
            int y = c.Top - 25;
            lbcompromised.Location = new Point(location, y);
            lbcompromised.Show();
            c.Flash(lbcompromised);
            
        }


        private void System_Damaged(object s, EventArgs e)
        {
            var c = (Computer)s;
            lbcompromised.Text = "System damaged!";
            int location = c.Left - (lbcompromised.Width / 4);
            int y = c.Top - 25;
            lbcompromised.Location = new Point(location, y);
            lbcompromised.Show();
            c.Flash(lbcompromised);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnemyScreen.Worm();
        }

        private void btnaddmodule_Click(object sender, EventArgs e)
        {
            SetupModuleList();
            pnldefensemanager.Visible = !pnldefensemanager.Visible;
            if(IsTutorial)
            {
                if(TutorialProgress == 12)
                {
                    SetupTutorialUI(13);
                }
            }
        }

        private Dictionary<string, SystemType> FutureModules = null;
        public List<Module> TutorialNetwork = new List<Module>();

        public void SetupModuleList()
        {
            FutureModules = new Dictionary<string, SystemType>();
            cmbmodules.Items.Clear();
            List<Module> net = null;
            if(IsTutorial)
            {
                net = TutorialNetwork;
            }
            else
            {
                net = Hacking.MyNetwork;
            }
            foreach (var item in net)
            {
                Computer m = null;
                foreach(var mod in AllComputers)
                {
                    if(mod.Hostname == item.Hostname)
                    {
                        m = mod;
                    }
                }
                if (m == null)
                {
                    cmbmodules.Items.Add(item.Hostname);
                    FutureModules.Add(item.Hostname, item.Type);
                }
            }
            
        }

        bool PlacingNewModule = false;
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbmodules.Text != "")
            {
                PlacingNewModule = true;
                pnldefensemanager.Hide();
                if (IsTutorial)
                {
                    if (TutorialProgress == 20)
                    {
                        SetupTutorialUI(21);
                    }
                }
            }
        }

        private void playfield_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlacingNewModule == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (AllComputers.Count < 10)
                    {
                        bool cont = true;
                        try
                        {
                            SystemType type = FutureModules[cmbmodules.Text];
                        }
                        catch 
                        {
                            cont = false;
                            API.CreateInfoboxSession("Error", "Please select a module type.", infobox.InfoboxMode.Info);
                        }
                        if (cont == true)
                        {
                            var coordinates = panel1.PointToClient(Cursor.Position);
                            int x = coordinates.X;
                            int y = coordinates.Y;

                            var m = new Module(FutureModules[cmbmodules.Text], 1, cmbmodules.Text);
                            foreach (var mod in GetMyNet())
                            {
                                if (mod.Hostname == cmbmodules.Text)
                                {
                                    m = mod;
                                }
                            }
                            m.X = x;
                            m.Y = y;
                            var c = m.Deploy();
                            AddModule(c);
                            API.RemoveCodepoints(10);
                            pnldefensemanager.Hide();
                            if(IsTutorial)
                            {
                                if(TutorialProgress == 21)
                                {
                                    SetupTutorialUI(22);
                                }
                                else if(TutorialProgress == 25)
                                {
                                    SetupTutorialUI(26);
                                }
                            }
                        }
                        PlacingNewModule = false;
                    }
                    else
                    {
                        API.CreateInfoboxSession("Too much deployed modules", "You can have a maximum of 10 modules deployed on your network, including your main system. You will have to wait for one to be destroyed.", infobox.InfoboxMode.Info);
                        PlacingNewModule = false;
                    }
                }
                else
                {
                    PlacingNewModule = false;
                }
            }
        }

        public List<FutureModule> BuyableModules = null;

        public void SetupBuyable()
        {
            if(!IsTutorial)
            {
                BuyableModules = Hacking.GetFutureModules();
            }
            cmbbuyable.Items.Clear();
            foreach(var m in BuyableModules)
            {
                cmbbuyable.Items.Add(m.Name);
            }
            lbmoduleinfo.Text = "";
            txtgrade.Text = "1";
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            if(IsTutorial)
            {
                if(TutorialProgress == 14)
                {
                    SetupTutorialUI(15);
                }
            }
            SetupBuyable();
            pnlbuy.Show();
            pnldefensemanager.Hide();
        }

        public List<Rectangle> AntiVirusBounds = null;
        public List<Rectangle> IndicatorsToDestroy = new List<Rectangle>();
        private void boundpaint(object sender, PaintEventArgs e)
        {
            foreach(Rectangle r in IndicatorsToDestroy)
            {
                AntiVirusBounds.Remove(r);
                var sb = new SolidBrush(Color.Black);
                var p = new Pen(sb);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                p.Width = 2;
                e.Graphics.DrawRectangle(p, r);

            }
            IndicatorsToDestroy.Clear();
            foreach (Rectangle r in AntiVirusBounds)
            {
                IndicatorsToDestroy.Add(r);
                tmrredraw.Start();
                var sb = new SolidBrush(Color.White);
                var p = new Pen(sb);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                p.Width = 2;
                e.Graphics.DrawRectangle(p, r);
            }
        }

        private void tmrredraw_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
            tmrredraw.Stop();
        }

        private void SetupModuleInfo()
        {
            bool cont = false;
            FutureModule m = null;
            foreach(var mod in BuyableModules)
            {
                if(mod.Name == cmbbuyable.Text)
                {
                    m = mod;
                    cont = true;
                }
            }
            if(cont == true)
            {
                lbmoduleinfo.Text = m.Name;
                lbmoduleinfo.Text += Environment.NewLine + $"Cost: {m.Cost * Convert.ToInt32(txtgrade.Text)} CP";
                lbmoduleinfo.Text += Environment.NewLine + $"Description: {Environment.NewLine}{m.Description}";
            }
        }

        private void cmbbuyable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupModuleInfo();
            if(IsTutorial)
            {
                if(TutorialProgress == 17)
                {
                    if(cmbbuyable.Text == "Antivirus")
                    {
                        SetupTutorialUI(18);
                    }
                }
            }
        }

        private void txtgrade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int g = Convert.ToInt32(txtgrade.Text);
                if(g < 1)
                {
                    txtgrade.Text = "1";
                }
                else if(g > 4)
                {
                    txtgrade.Text = "4";
                }
                SetupModuleInfo();
            }
            catch
            {
                txtgrade.Text = "1";
                SetupModuleInfo();
            }
        }

        public List<Module> GetMyNet()
        {
            if(IsTutorial)
            {
                return TutorialNetwork;
            }
            else
            {
                return Hacking.MyNetwork;
            }
        }

        private void btndonebuying_Click(object sender, EventArgs e)
        {
            var mod = new FutureModule("", 0, "", SystemType.Core);
            bool cont = false;
            foreach(var m in BuyableModules)
            {
                if(m.Name == cmbbuyable.Text)
                {
                    mod = m;
                    cont = true;
                }
            }
            if(cont == true)
            {
                if(API.Codepoints >= mod.Cost)
                {
                    if (txthostname.Text != "")
                    {
                        bool cont2 = true;
                        string hname = txthostname.Text.Replace(" ", "_");
                        foreach (var pc in GetMyNet())
                        {
                            if (pc.Hostname == hname)
                            {
                                cont2 = false;
                            }
                        }
                        if (cont2 == true)
                        {
                            GetMyNet().Add(new Module(mod.Type, Convert.ToInt32(txtgrade.Text), hname));
                            API.RemoveCodepoints(mod.Cost);
                            API.CreateInfoboxSession("Module added.", "To deploy the module to the network, select 'Add Module' and choose the hostname from the menu.", infobox.InfoboxMode.Info);
                            pnlbuy.Hide();
                            if(IsTutorial)
                            {
                                if(TutorialProgress == 19)
                                {
                                    SetupTutorialUI(20);
                                }
                                else if(TutorialProgress == 24)
                                {
                                    SetupTutorialUI(25);
                                }
                            }
                        }
                        else
                        {
                            API.CreateInfoboxSession("Please enter a unique hostname.", "No two computers can share the same hostname. Please choose another.", infobox.InfoboxMode.Info);
                        }
                    }
                    else
                    {
                        API.CreateInfoboxSession("Please enter a hostname.", "It is best to enter a hostname for your new computer so you know which one it is.", infobox.InfoboxMode.Info);
                    }

                }
                else
                {
                    API.CreateInfoboxSession("Insufficient Codepoints", "You do not have enough Codepoints to buy this module.", infobox.InfoboxMode.Info);
                }
            }
        }

        private void btncloseinfo_Click(object sender, EventArgs e)
        {
            SelectedComputer = null;
            pnlpcinfo.Hide();
            Hacking.SaveCharacters();
        }

        private void btnpoweroff_Click(object sender, EventArgs e)
        {
            //Remove the computer from the game.
            panel1.Controls.Remove(SelectedComputer);
            AllComputers.Remove(SelectedComputer);
            btnpoweroff.Hide();
        }

        private void btnupgrade_Click(object sender, EventArgs e)
        {
            int price = 20 * SelectedComputer.Grade;
            if(API.Codepoints >= price)
            {
                foreach(var m in GetMyNet())
                {
                    if(m.Hostname == SelectedComputer.Hostname)
                    {
                        SelectedComputer.Grade += 1;
                        m.Grade += 1;
                        Hacking.SaveCharacters();
                        API.CreateInfoboxSession("Upgrade successful.", "Your module has been upgraded.", infobox.InfoboxMode.Info);
                    }
                }
            }
            else
            {
                API.CreateInfoboxSession("Insufficient funds", $"You need at least {price} CP to upgrade this module.", infobox.InfoboxMode.Info);
            }
            ShowPCInfo(SelectedComputer.Hostname);
        }

        public int TutorialProgress = 0;
        public bool IsTutorial = false;
        
        public void SetupTutorialUI(int p)
        {
            TutorialProgress = p;
            lbtutorial.Show();
            switch(p)
            {
                case 0:
                    lbtutorial.Text = "Welcome to the Hacker Battle tutorial. This guide will teach you the fundamentals and basics of taking part in a Hacker Battle. When you're done here, you'll have all you need for a very basic network.";
                    btnaddmodule.Hide();
                    btnnext.Show();
                    break;
                case 1:
                    lbtutorial.Text = "When a battle commenses, you will see two windows. The one on the left, is your network. You can view information about all computers on the network, buy new systems, upgrade them and deploy them.";
                    break;
                case 2:
                    lbtutorial.Text = "On the right is the enemy's network. This window will show you the strength (HP) of all enemy systems, and will allow you to target specific systems to take down.";
                    break;
                case 3:
                    lbtutorial.Text = "On the top-left corner of both windows is the network health indicator. It will display a percentage of the entire network health.";
                    break;
                case 4:
                    lbtutorial.Text = "If the enemy's total network health hits 0%, or his core's strength hits 0%, you win.";
                    break;
                case 5:
                    lbtutorial.Text = "However, if the same happens to you, you will lose the battle.";
                    break;
                case 6:
                    lbtutorial.Text = "You can click on your Core to view information about it.";
                    btnnext.Hide();
                    break;
                case 7:
                    lbtutorial.Text = "When you click on a module, you can see information about it, such as it's grade level, HP, and type. This module is a Core, so it has no grade level. It currently has 100 HP.";
                    btnnext.Show();
                    break;
                case 8:
                    lbtutorial.Text = "When a module is selected you can left-click an enemy module to target it. This will make the selected module attempt to fire at the target. Cores are very weak, but are capable of bringing a target down by 1 HP.";
                    break;
                case 9:
                    lbtutorial.Text = "The enemy Core is attacking your Core now. Looks like it's time to fight back. Select your core, and target the enemy's Core to fight back.";
                    btnnext.Hide();
                    break;
                case 10:
                    lbtutorial.Text = "Phew! He couldn't do much damage before we fought back. In a real battle, modules won't just stop fighting randomly, but for the purpose of this tutorial, your Core will stop attacking the enemy Core.";
                    btnnext.Show();
                    ThisPC.Enemies.Clear();
                    break;
                case 11:
                    lbtutorial.Text = "Should your Core fall to a fatal state in the future, you can deploy some defenses to slow the enemy down. Any hacker knows it's best to disable defenses before attacking the main target.";
                    ThisPC.HP = 5;
                    break;
                case 12:
                    lbtutorial.Text = "We will look at ways of healing damaged modules now. You can add new modules to the network by clicking the [Add Module] button in the lower-left corner.";
                    btnaddmodule.Show();
                    btnnext.Hide();
                    break;
                case 13:
                    lbtutorial.Text = "You can select a module from the list of hostnames. Only modules that are not powered on will display in the menu.";
                    btnnext.Show();
                    BuyableModules = new List<FutureModule>();
                    BuyableModules.Add(new FutureModule("Antivirus", 0, "This module will heal any other module within it's area of effect to 10 HP. Higher grades can improve it's area of effect.", SystemType.Antivirus));
                    break;
                case 14:
                    lbtutorial.Text = "In this demonstration, you have no other modules to deploy. You will need to buy some modules to get started. Click [Buy New Module] to continue.";
                    btnnext.Hide();
                    break;
                case 15:
                    lbtutorial.Text = "Let's go over the user interface, shall we? At the top is a list of all possible module types.";
                    btnnext.Show();
                    btndonebuying.Hide();
                    lbgrade.Hide();
                    txtgrade.Hide();
                    txthostname.Hide();
                    lbhostname.Hide();
                    lbmoduleinfo.Hide();
                    break;
                case 16:
                    lbtutorial.Text = "Below that, is the cost and description of the selected module type. It's invisible right now, but when you select a new module, it will populate.";
                    lbmoduleinfo.Show();
                    break;
                case 17:
                    lbtutorial.Text = "We need an Antivirus module, so go ahead and select it from the menu.";
                    btnnext.Hide();
                    break;
                case 18:
                    lbtutorial.Text = "Normally, an Antivirus would cost us 15 Codepoints, however since this is a tutorial, it is free.";
                    btnnext.Show();
                    break;
                case 19:
                    lbtutorial.Text = "Below the description is the Hostname box. A Hostname is used to identify the new module. Pick something you'll remember as this new Antivirus, then click [Buy] to purchase it.";
                    btnnext.Hide();
                    lbhostname.Show();
                    txthostname.Show();
                    btndonebuying.Show();
                    break;
                case 20:
                    btnnext.Hide();
                    lbtutorial.Text = "Now that we have an antivirus module, go ahead and deploy it by selecting [Add Module], choosing the hostname you entered, and clicking [Done].";
                    break;
                case 21:
                    btnnext.Hide();
                    lbtutorial.Text = "Alrighty. Now you get to choose where you place your module. Simply left-click in a blank area where you'd like to place the module. Right-click to cancel. Oh, be sure to place close to our Core!";
                    break;
                case 22:
                    lbtutorial.Text = "The Antivirus has been placed. You may've noticed that white dotted box around it when you placed it. If the Core is even slightly within the box, the Antivirus will heal it back to 10 HP.";
                    btnnext.Show();
                    break;
                case 23:
                    lbtutorial.Text = "The higher the Antivirus' grade, the bigger this area of effect becomes. However, it will always only be able to heal modules to 10 HP.";
                    break;
                case 24:
                    lbtutorial.Text = "A Turret has been added to the list of buyable modules. Go pick one up!";
                    btnnext.Hide();
                    BuyableModules.Clear();
                    BuyableModules.Add(new FutureModule("Turret", 0, "It's not super-effective, but the Turret will blast through any Grade 1 defenses pretty quickly. The higher the grade, the higher the strength.", SystemType.Turret));
                    break;
                case 25:
                    lbtutorial.Text = "Turrets can fire damaging viruses at their targets. Go ahead and place your Turret somewhere within the Antivirus's Area of Effect.";
                    break;
                case 26:
                    lbtutorial.Text = "Notice how the Turret only has 10 HP, just like the Antivirus?";
                    btnnext.Show();
                    break;
                case 27:
                    lbtutorial.Text = "This is because both the Antivirus and Turret are at Grade 1. There are four grades of modules you can get, and you can easily upgrade by selecting a module and choosing [Upgrade This Module].";
                    break;
                case 28:
                    lbtutorial.Text = "Upgrading a module will increase it's max HP. Grade 1 is 10 HP, Grade 2 is 20 HP, Grade 3 is 40 HP, and Grade 4 is 80 HP.";
                    break;
                case 29:
                    lbtutorial.Text = "Some modules will have a higher attack rate based on their grade. Others may throw more damaging attacks, and any module's Area of Effect (if it has one) will grow.";
                    break;
                case 30:
                    lbtutorial.Text = "Another tip: Multiple modules can target the same module, and a module can have multiple targets. This means that you can have your Core and your Turret both attack the enemy Core.";
                    break;
                case 31:
                    lbtutorial.Text = "Some modules do not work on a target-based system. Some may work using an area-of-effect system (like an Antivirus), and some may target the entire enemy network.";
                    break;
                case 32:
                    lbtutorial.Text = "We have reset both your Cores' health. Go ahead and finish off the enemy Core using your newfound skills.";
                    ThisPC.HP = 100;
                    EnemyScreen.ThisPC.HP = 100;
                    btnnext.Hide();
                    BuyableModules = new List<FutureModule>();
                    BuyableModules.Add(new FutureModule("Antivirus", 0, "This module will heal any other module within it's area of effect to 10 HP. Higher grades can improve it's area of effect.", SystemType.Antivirus));
                    BuyableModules.Add(new FutureModule("Turret", 0, "It's not super-effective, but the Turret will blast through any Grade 1 defenses pretty quickly. The higher the grade, the higher the strength.", SystemType.Turret));
                    break;
                default:
                    lbtutorial.Text = "This concludes the Hacker Battle tutorial. Happy hunting, soldier. Just kidding. Stay safe.";
                    btnnext.Text = "Close";
                    break;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if(btnnext.Text == "Close")
            {
                UserRequestedClose = false;
                this.Close();
                EnemyScreen.UserRequestedClose = false;
                EnemyScreen.Close();
            }
            SetupTutorialUI(TutorialProgress + 1);
        }
    }

    public enum ConnectionDirection
    {
        Left, Right, Top, Bottom, NoBridge
    }
}
