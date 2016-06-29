using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Computer : UserControl
    {
        public int TotalHP = 100;

        public Online.Hacking.NetTransmitter Transmitter = null;

        public Computer()
        {
            InitializeComponent();
        }

        int _HP = 100;

        public void Repair(int hp)
        {
            this._HP += hp;
            Transmitter?.send_message(Online.Hacking.NetTransmitter.Messages.SetHealth, $"{Hostname} {_HP}");
            var h = OnRepair;
            if(h != null)
            {
                h(this, new EventArgs());
            }
        }

        public event EventHandler OnRepair;

        public int HP
        {
            get
            {
                return _HP;
            }
            set
            {
                _HP = value;
            }
        }

        
        public SystemType Type
        {
            get; set;
        }


        List<Connection> _Connections = null;


        public Connection[] Connections {
            get
            {
                return 
                    _Connections.ToArray();
                
            }
        }

        public bool Enemy { get; set; }
        public Computer EnemyComputer { get; set; }

        public int GetDamageRate()
        {
            switch(Grade)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 4;
                case 4:
                    return 8;
                default:
                    return 1;
            }
        }

        public int GetChance()
        {
            switch (Grade)
            {
                case 1:
                    return 200;
                case 2:
                    return 150;
                case 3:
                    return 100;
                case 4:
                    return 50;
                default:
                    return 200;
            }
        }

        public AttackType GetProperType()
        {
            switch(Type)
            {
                case SystemType.DedicatedDDoS:
                    return AttackType.DDoS;
                case SystemType.Core:
                    return AttackType.Core;
                case SystemType.Turret:
                    return AttackType.Virus;
                default:
                    return AttackType.None;
            }
        }

        public List<Computer> Enemies = null;

        public void LaunchAttack(AttackType type)
        {
            var rnd = new Random();
            switch (type)
            {
                case AttackType.Virus:
                    int chance = rnd.Next(1, 10);
                    if(chance == 5)
                    {
                        int rate = 1;
                        Deteriorate(rate);
                    }
                    break;
                case AttackType.DDoS:
                    int cmax = GetChance();
                    int c = rnd.Next(0, cmax);
                    if(c == 50)
                    {
                        this.Disable();
                    }
                    break;
            }
        }

        public void LaunchAttack(AttackType type, int rate)
        {
            switch (type)
            {
                case AttackType.Virus:
                    var rnd = new Random();
                    int chance = rnd.Next(1, 10);
                    if (chance == 5)
                    {
                        Deteriorate(rate);
                    }
                    break;
                case AttackType.Core:
                    LaunchAttack(AttackType.Virus); //Small virus attack as last resort.
                    break;
                default:
                    LaunchAttack(type);
                    break;
            }
        }

        public string Hostname { get; set; }

        internal void throw_repaired()
        {
            OnRepair?.Invoke(this, new EventArgs());
        }

        internal void throw_damaged()
        {
            HP_Decreased?.Invoke(this, new EventArgs());
        }

        public event EventHandler HP_Decreased;
        
        public void Deteriorate(int amount)
        {
            if (amount == 1 && DamageDefector > 1)
            {

            }
            else {
                this._HP -= amount / DamageDefector;
                Transmitter?.send_message(Online.Hacking.NetTransmitter.Messages.SetHealth, $"{Hostname} {_HP}");
                EventHandler handler = HP_Decreased;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }

        public bool Disabled = false;

        public void Disable()
        {
            Transmitter?.send_message(Online.Hacking.NetTransmitter.Messages.Disabled, $"{Hostname}");
            var t = new Timer();
            t.Interval = 1000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                if(i == 5)
                {
                    Disabled = false;
                    this.BackColor = Color.White;
                    t.Stop();
                }
                else
                {
                    Disabled = true;
                    this.BackColor = Color.Gray;
                }
                i += 1;
            };
            t.Start();
        }

        public void Flash(Label l)
        {
            int i = 100;
            var t = new Timer();
            int p = 0;
            t.Interval = i;
            t.Tick += (object s, EventArgs a) =>
            {
                if (p == 10)
                {
                    t.Stop();
                    this.BackColor = Color.White;
                    l.Hide();
                }
                else {
                    if (this.BackColor == Color.White)
                    {
                        this.BackColor = Color.Black;
                    }
                    else
                    {
                        this.BackColor = Color.White;
                    }
                }
                p += 1;
            };
            t.Start();
        }
        public event EventHandler AntivirusRepair;

        public event EventHandler OnAIAttack;

        public void ThrowEnemyAttack()
        {
            var h = OnAIAttack;
            if(h != null)
            {
                h(this, new EventArgs());
            }
        }

        public int Grade { get; set; }

        public Rectangle GetAreaOfEffect()
        {
            int r = 50;
            switch(Grade)
            {
                case 1:
                    r = 50;
                    break;
                case 2:
                    r = 100;
                    break;
                case 3:
                    r = 150;
                    break;
                case 4:
                    r = 200;
                    break;
            }
            return new Rectangle(this.Left - r, this.Top - r, this.Width + (r * 2), this.Height + (r * 2));

        }

        public int DamageDefector = 1;

        public int GetTotal()
        {
            switch (Type)
            {
                case SystemType.Core:
                    return 100;
                default:
                    switch (Grade)
                    {
                        case 1:
                            return 10;
                        case 2:
                            return 20;
                        case 3:
                            return 40;
                        case 4:
                            return 80;
                        default:
                            return 10;
                    }
            }
        }

        public Timer HealthTimer = null;

        public bool AlreadyEnslaved = false;
        public bool Enslaved = false;

        public event EventHandler EnslavedModule;


        public event EventHandler MassDDoS;

        private void Computer_Load(object sender, EventArgs e)
        {
            Enemies = new List<Computer>();
            var t = new Timer();
            t.Interval = 100;
            t.Tick += (object s, EventArgs a) =>
            {
                if (this.HP > 0)
                {
                    lbstats.Text = $"HP: {_HP}";
                    if(!Enemy)
                    {
                        foreach(var m in Hacking.MyNetwork)
                        {
                            if(m.Hostname == Hostname)
                            {
                                m.HP = _HP;
                            }
                        }
                    }
                    switch (Type)
                    {
                        case SystemType.Core:
                            this.Size = new Size(64, 64);
                            try
                            {
                                this.Location = new Point(
                                        (this.Parent.Width - this.Width) / 2,
                                        (this.Parent.Height - this.Height) / 2
                                    );
                            }
                            catch 
                            {

                            }
                            break;
                        case SystemType.RepairModule:
                        case SystemType.Antivirus:
                            var r = new Random();
                            int i = r.Next(0, 20);
                            if (i == 10)
                            {
                                EventHandler handler = AntivirusRepair;
                                if (handler != null)
                                {
                                    handler(this, new EventArgs());
                                }
                            }
                            this.Size = new Size(32, 32);
                            break;
                        case SystemType.ModuleStealer:
                            var rnd = new Random();
                            int num = rnd.Next(0, 2500 / Grade);
                            if(num == 25)
                            {
                                StolenModule?.Invoke(this, new EventArgs());
                            }
                            break;
                        case SystemType.Enslaver:
                            if (AlreadyEnslaved == false)
                            {
                                var ernd = new Random();
                                int num2 = ernd.Next(0, 2500 / Grade);
                                if (num2 == 25)
                                {
                                    AlreadyEnslaved = true;
                                    EnslavedModule?.Invoke(this, new EventArgs());
                                }
                            }
                            break;
                        case SystemType.ServerStack:
                            var r2 = new Random();
                            int i2 = r2.Next(0, GetChance());
                            if (i2 == GetChance() / 2)
                            {
                                EventHandler handler = this.MassDDoS;
                                if (handler != null)
                                {
                                    handler(this, new EventArgs());
                                }
                            }
                            this.Size = new Size(48, 48);
                            break;
                        default:
                            this.Size = new Size(32, 32);
                            break;
                    }
                    if (Disabled == false)
                    {
                        if (API.Upgrades["limitlesscustomshades"] == true)
                        {
                            if(_HP > TotalHP / 2)
                            {
                                this.BackColor = Color.Green;
                                lbstats.ForeColor = Color.Black;
                            }
                            else
                            {
                                if(_HP > TotalHP / 3)
                                {
                                    this.BackColor = Color.Orange;
                                    lbstats.ForeColor = Color.Black;
                                }
                                else
                                {
                                    this.BackColor = Color.Red;
                                    lbstats.ForeColor = Color.White;
                                }
                            }
                        }
                        if (Enemy == true)
                        {
                            var rnd = new Random();
                            int chance = rnd.Next(0, 100);
                            if (chance == 50)
                            {
                                ThrowEnemyAttack();
                            }
                        }
                    }
                }
                else
                {
                    t.Stop();
                    this.Visible = false;
                    ThrowDestroyed();
                }
            };
            t.Start();
            HealthTimer = t;
        }

        public event EventHandler StolenModule;

        public event EventHandler OnDestruction;

        public void ThrowDestroyed()
        {
            var h = OnDestruction;
            if(h != null)
            {
                h(this, new EventArgs());
            }
        }

        public event EventHandler Select;

        private void lbstats_Click(object sender, EventArgs e)
        {
            var h = this.Select;
            if(h != null)
            {
                h(this, e);
            }
        }
    }

    public enum SystemType
    {
        Core = 0,
        Antivirus = 1,
        DedicatedDDoS = 2,
        Turret = 3,
        FTPServer = 4,
        Firewall = 5,
        ServerStack = 6,
        Enslaver = 7,
        RepairModule = 9,
        ModuleStealer = 8,
    }

    public enum AttackType {
        Virus,
        DDoS,
        Worm,
        Spazzer,
        Backdoor,
        None,
        Core,
    }

}
