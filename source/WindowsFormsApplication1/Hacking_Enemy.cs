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
    public partial class Hacking_Enemy : Form
    {
        public Hacking_Enemy(Hacking_YourHealth enemy, EnemyHacker thisHacker)
        {
            ThisHacker = thisHacker;
            Enemy = enemy;
            InitializeComponent();
        }

        private EnemyHacker ThisHacker { get; set; }
        public Hacking_YourHealth Enemy { get; set; }
        public List<Computer> AllComputers = null;
        public Computer ThisPC { get; set; }
        private void Hacking_Enemy_Load(object sender, EventArgs e)
        {
            AllComputers = new List<Computer>();
            VisualizeNetwork();
            tmrhealthdetect.Start();
            ThisPC.Enemy = true;
        }

        private void VisualizeNetwork()
        {
            var rnd = new Random();
            foreach (Module m in ThisHacker.Network)
            {
                var c = m.Deploy();
                if (c.Type == SystemType.Core)
                {
                    ThisPC = c;
                    ThisPC.EnemyComputer = Enemy.ThisPC;
                    Enemy.ThisPC.EnemyComputer = ThisPC;
                }
                c.Location = new Point(rnd.Next(100, 350), rnd.Next(100, 350));
                AddModule(c);
            }
        }

        public void System_Attacking(object s, EventArgs a)
        {
            int i = new Random().Next(Enemy.AllComputers.Count);
            var pc = Enemy.AllComputers[i];
            var se = (Computer)s;
            pc.LaunchAttack(se.GetProperType());
        }

        public Computer SelectedComputer = null;

        public void AddModule(Computer newModule)
        {
            var rnd = new Random();
            panel1.Controls.Add(newModule);
            foreach(var pc in AllComputers)
            {
                while (newModule.Bounds.IntersectsWith(pc.Bounds))
                {
                    newModule.Location = new Point(rnd.Next(100, 350), rnd.Next(100, 350));
                }
            }
            AllComputers.Add(newModule);
            int hp = newModule.HP;
            TotalHP += (decimal)newModule.HP;
            newModule.Show();
            newModule.OnDestruction += (object s, EventArgs a) =>
            {
                if(this.SelectedComputer == newModule)
                {
                    SelectedComputer = null;
                }
                AllComputers.Remove(newModule);
                newModule.Dispose();
            };
            newModule.Select += (object s, EventArgs a) =>
            {
                bool c = true;
                foreach(var pc in Enemy.SelectedComputer.Enemies)
                {
                    if(pc.Hostname == newModule.Hostname)
                    {
                        c = false;
                    }
                }
                if (c == true)
                {
                    Enemy.SelectedComputer.Enemies.Add(newModule);
                    Enemy.ShowPCInfo(Enemy.SelectedComputer.Hostname);
                    if(Enemy.IsTutorial)
                    {
                        if(Enemy.TutorialProgress == 9)
                        {
                            Enemy.SetupTutorialUI(10);
                        }
                    }
                }
            };
            newModule.HP_Decreased += new EventHandler(System_Damaged);
            newModule.OnRepair += new EventHandler(System_Repaired);
            if (newModule.Type == SystemType.Antivirus)
            {
                var b = newModule.GetAreaOfEffect();
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
            if (newModule.Type == SystemType.Firewall)
            {
                panel1.Refresh();
                Firewall_Deflect(newModule);
            }
            if (newModule.Type == SystemType.ServerStack)
            {
                newModule.MassDDoS += (object s, EventArgs a) =>
                {
                    Enemy.Worm();
                };
            }
        }

        public void Firewall_Deflect(Computer fwall)
        {
            //Safegaurd...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllComputers)
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
            foreach (var pc in AllComputers)
            {
                if (pc.Type == SystemType.Firewall)
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

        private decimal TotalHP = 0;

        private void tmrhealthdetect_Tick(object sender, EventArgs e)
        {
            decimal health = 0;

            var rnd = new Random();
            int chance = 0;
            foreach (var pc in AllComputers)
            {
                if (pc.Disabled == false)
                {
                    foreach (var enemy in Enemy.AllComputers)
                    {
                        chance = rnd.Next(1, 20);
                        if (chance == 10)
                        {
                            if (Enemy.IsTutorial)
                            {
                                if (Enemy.TutorialProgress == 9)
                                {
                                    Enemy.ThisPC.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                }
                                else if (Enemy.TutorialProgress == 32)
                                {
                                    enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                }
                                else
                                {
                                    enemy.Enemies.Clear();
                                }
                            }
                            else {
                                enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                            }
                        }
                    }
                }
            }

            foreach (var pc in AllComputers)
            {
                health += (decimal)pc.HP;
            }
            try {
                decimal percent = (health / TotalHP) * 100;
                lbstats.Text = $"Enemy Health: {percent}%";
                if (ThisPC.HP <= 0)
                {
                    if (Enemy.IsTutorial)
                    {
                        Enemy.SetupTutorialUI(33);
                    }
                    else {
                        API.CreateInfoboxSession("You won.", "You have successfully overthrown the enemy network.", infobox.InfoboxMode.Info);
                        UserRequestedClose = false;
                        Enemy.UserRequestedClose = false;
                        Enemy.Close();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void Worm()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 10);

            foreach (Computer c in AllComputers)
            {
                if(r == 5)
                {
                    c.Disable();
                }
            }
        }

        public bool UserRequestedClose = true;

        private void this_Closing(object sender, FormClosingEventArgs e)
        {
            if(UserRequestedClose == false)
            {
                tmrhealthdetect.Stop();
                foreach(var pc in AllComputers)
                {
                    pc.HP = 0;
                }
            }
        }
    }
}
