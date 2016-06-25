using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    /// <summary>
    /// Hacker battles and stuff like that.
    /// </summary>
    public class Hacking
    {
        public static List<Character> Characters = new List<Character>();
        public static List<HackTool> Tools = new List<HackTool>();
        public static List<EnemyHacker> EnemyHackers = new List<EnemyHacker>();
        public static List<Module> MyNetwork = new List<Module>();
        public static bool Failure = false;
        public static DateTime FailDate = DateTime.Now;
        internal static string HackerBattleAward = null;
        public static Timer RepairTimer = null;

        public static Module MyCore
        {
            get
            {
                var m = new Module(SystemType.Core, 1, "invalid");
                foreach(var mod in MyNetwork)
                {
                    if(mod.Hostname == "localhost")
                    {
                        m = mod;
                    }
                }
                return m;
            }
        }

        /// <summary>
        /// Gives a shiftorium upgrade for free.
        /// </summary>
        /// <param name="id">Upgrade ID.</param>
        public static void GiveUpgrade(string id)
        {
            API.Upgrades[id] = true;
        }

        /// <summary>
        /// Increases skill of a character.
        /// </summary>
        /// <param name="cid">The character ID.</param>
        public static void IncreaseSkill(int cid)
        {
            var rnd = new Random();
            int newspeed = rnd.Next(0, 5);
            int newskill = rnd.Next(0, 10);
            Characters[cid].Speed += newspeed;
            Characters[cid].Skill += newskill;
            SaveCharacters();
            API.CreateInfoboxSession("Hack complete.", $"{Characters[cid].Name} has successfully completed their hack. {Characters[cid].Name} has gained {newspeed} Speed Points, and {newskill} Skill Points.", infobox.InfoboxMode.Info);
        }

        /// <summary>
        /// Applies a hack.
        /// </summary>
        /// <param name="hack">Type of hack to apply.</param>
        public static void GiveHack(Hack hack)
        {
            switch (hack)
            {
                case Hack.PayoutIncrease:
                    API.CurrentSave.CodepointMultiplier += 1;
                    break;
                case Hack.PriceDrop:
                    API.CurrentSave.PriceDivider += 1;
                    break;
            }
        }
        
        /// <summary>
        /// Add a new character.
        /// </summary>
        /// <param name="ch">The new character.</param>
        public static void AddCharacter(Character ch)
        {
            bool c = true;
            foreach(var character in Characters)
            {
                if(character.Name == ch.Name)
                {
                    c = false;
                }
            }
            if(c == true)
            {
                Characters.Add(ch);
                SaveCharacters();
            }
        }

        /// <summary>
        /// Adds a new hacking tool.
        /// </summary>
        /// <param name="ch">The hacking tool.</param>
        public static void AddTool(HackTool ch)
        {
            if (!Tools.Contains(ch))
            {
                Tools.Add(ch);
            }
        }

        /// <summary>
        /// Returns a random hack type.
        /// </summary>
        /// <returns>The hack type.</returns>
        public static Hack GetRandomHack()
        {
            var t = new List<Hack>(Enum.GetValues(typeof(Hack)).Cast<Hack>());
            var rnd = new Random();
            return t[rnd.Next(0, t.Count - 1)];
        } 

        /// <summary>
        /// Start a hack with a character.
        /// </summary>
        /// <param name="cid">Character to hire.</param>
        /// <param name="hack">Type of hack to pull off.</param>
        public static void StartHackWithCharacter(int cid, Hack hack)
        {
            var h = Characters[cid];
            var f = new Form();
            f.BackColor = Color.Black;
            f.ForeColor = Color.White;
            f.Font = new Font(OSInfo.GetMonospaceFont(), 9);
            var l = new Label();
            int p = 0;
            int speed = 10000 / h.Speed; //If a hacker has a speed of one, it will take 10,000 milliseconds to move 1% in the hack progress. Divide it by a thousand, you get 1,000 seconds.
            var t = new Timer();
            t.Interval = speed;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
            switch (API.CurrentSkin.desktoppanelposition)
            {
                case "Top":
                    f.Location = new Point(5, API.CurrentSkin.desktoppanelheight + 5);
                    break;
                case "Bottom":
                    f.Location = new Point(5, 5);
                    break;
            }

            f.Controls.Add(l);
            l.Show();
            l.TextAlign = ContentAlignment.MiddleCenter;
            f.Height = 25;
            f.TopMost = true;
            l.Text = $"Progress: {p}%";
            l.Dock = DockStyle.Fill;
            t.Tick += (object s, EventArgs a) =>
            {
                if (l.Text != "Hack failed.")
                {
                    if (p <= 100)
                    {
                        l.Text = $"Progress: {p}%";
                        int fail = new Random().Next(0, h.Skill * h.Speed);
                        if (fail == 1)
                        {
                            l.Text = "Hack failed.";
                        }
                    }
                    else
                    {
                        GiveHack(hack);
                        f.Close();
                        t.Stop();
                        IncreaseSkill(cid);
                    }
                }
                else
                {
                    f.Close();
                    t.Stop();
                }

                p += 1;
            };
            t.Start();
        }

        /// <summary>
        /// Hacker Battles: List of modules the user can buy.
        /// </summary>
        /// <returns>The list that was created by the method. What did you think it would return? A boolean?</returns>
        public static List<FutureModule> GetFutureModules()
        {
            var lst = new List<FutureModule>();
            lst.Add(new FutureModule("Antivirus", 15, "This module will heal any other module within it's area of effect to 10 HP. Higher grades can improve it's area of effect.", SystemType.Antivirus));
            lst.Add(new FutureModule("Enslaver", 75, "The Enslaver is a scary module for an opposing network. At any time, the Enslaver can take over any module on the enemy network and turn it against them.", SystemType.Enslaver));
            lst.Add(new FutureModule("Module Thief", 100, "The Module Thief can hack into the enemy's network and attempt to steal one of their modules and bring them into your network temporarily though. Be careful though, it might not work all the time!", SystemType.ModuleStealer));
            lst.Add(new FutureModule("Dedicated DDoS module", 10, "This module will attempt to disable the enemy network by sending a DDoS attack allowing you to take a breather.", SystemType.DedicatedDDoS));
            lst.Add(new FutureModule("Turret", 5, "It's not super-effective, but the Turret will blast through any Grade 1 defenses pretty quickly. The higher the grade, the higher the strength.", SystemType.Turret));
            lst.Add(new FutureModule("Firewall", 20, "Will decrease the amount of damage taken by any module within it's area of effect. The higher the grade, the bigger the area of effect and more protection it offers.", SystemType.Firewall));
            lst.Add(new FutureModule("Repair Module", 150, "Slowly repairs all modules within the area of effect to the same HP as the repair module.", SystemType.RepairModule));
            lst.Add(new FutureModule("Server Stack", 250, "Capable of sending a worm attack to the entire enemy network, preventing it from attacking until it can recover.", SystemType.ServerStack));
            return lst;
        }

        /// <summary>
        /// Hire a character to attempt to hack a Shiftorium Upgrade.
        /// </summary>
        /// <param name="cid">The character.</param>
        /// <param name="upgrade">The upgrade ID.</param>
        public static void StartHackWithCharacter(int cid, string upgrade)
        {
            if (upgrade == "random")
            {
                StartHackWithCharacter(cid, GetRandomHack());
            }
            else {
                var h = Characters[cid];
                var f = new Form();
                f.BackColor = Color.Black;
                f.ForeColor = Color.White;
                f.Font = new Font(OSInfo.GetMonospaceFont(), 9);
                var l = new Label();
                int p = 0;
                int speed = 10000 / h.Speed; //If a hacker has a speed of one, it will take 10,000 milliseconds to move 1% in the hack progress. Divide it by a thousand, you get 1,000 seconds.
                var t = new Timer();
                t.Interval = speed;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Show();
                switch (API.CurrentSkin.desktoppanelposition)
                {
                    case "Top":
                        f.Location = new Point(5, API.CurrentSkin.desktoppanelheight + 5);
                        break;
                    case "Bottom":
                        f.Location = new Point(5, 5);
                        break;
                }

                f.Controls.Add(l);
                l.Show();
                l.TextAlign = ContentAlignment.MiddleCenter;
                f.Height = 25;
                f.TopMost = true;
                l.Text = $"Progress: {p}%";
                l.Dock = DockStyle.Fill;
                t.Tick += (object s, EventArgs a) =>
                {
                    if (l.Text != "Hack failed.")
                    {
                        if (p <= 100)
                        {
                            l.Text = $"Progress: {p}%";
                            int fail = new Random().Next(0, h.Skill * h.Speed);
                            if (fail == 1)
                            {
                                l.Text = "Hack failed.";
                            }
                        }
                        else
                        {
                            GiveUpgrade(upgrade);
                            f.Close();
                            t.Stop();
                            IncreaseSkill(cid);
                        }
                    }
                    else
                    {
                        f.Close();
                        t.Stop();
                    }

                    p += 1;
                };
                t.Start();
            }
        }

        /// <summary>
        /// Start a hack with a tool.
        /// </summary>
        /// <param name="cid">Tool ID.</param>
        /// <param name="hack">The hack type.</param>
        public static void StartHack(int cid, Hack hack)
        {
            var h = Tools[cid];
            switch (h.Name)
            {
                case "Destabilizer Attack":
                    var t = new Timer();
                        t.Interval = 100;
                    var rnd = new Random();
                    t.Tick += (object s, EventArgs a) =>
                    {
                        int r = rnd.Next(0, 100);
                        if (r == 90)
                        {
                            t.Stop();

                            API.CreateInfoboxSession("Hack complete.", "The hack has been completed.", infobox.InfoboxMode.Info);
                            GiveHack(hack);
                        }
                        else
                        {
                            try {
                                int p = rnd.Next(0, 10);
                                switch (p)
                                {
                                    case 1:
                                        API.OpenProgram("shiftorium");
                                        break;
                                    case 2:
                                        API.OpenProgram("ki");
                                        break;
                                    case 3:
                                        API.CreateInfoboxSession(API.Encryption.Encrypt("Praise Lord Michael"), API.Encryption.Encrypt("You will bow down to me."), infobox.InfoboxMode.Info);
                                        break;
                                    case 4:
                                        API.PlaySound(Properties.Resources._3beepvirus);
                                        break;
                                    case 5:
                                        API.CurrentSession.BackColor = Color.White;
                                        break;
                                    case 6:
                                        API.CurrentSession.BackColor = Color.Black;
                                        break;
                                    case 7:
                                        API.PlaySound(Properties.Resources.dial_up_modem_02);
                                        break;
                                    case 8:
                                        API.PlaySound(Properties.Resources.writesound);
                                        break;
                                    case 9:
                                        API.PlaySound(Properties.Resources.typesound);
                                        break;
                                }
                            }
                            catch
                            {
                                t.Stop();
                                var tr = new Terminal();
                                tr.Show();
                                tr.WindowState = FormWindowState.Maximized;
                                tr.txtterm.BackColor = Color.Red;
                                tr.Crash();
                            }
                        }
                    };
                    t.Start();


                    break;
            }
        }

        /// <summary>
        /// Start a hack with a tool, to attempt to get an upgrade.
        /// </summary>
        /// <param name="cid">Tool ID.</param>
        /// <param name="upgrade">Upgrade ID.</param>
        public static void StartHack(int cid, string upgrade)
        {
            if (upgrade == "random")
            {
                StartHack(cid, GetRandomHack());
            }
            else {
                var h = Tools[cid];
                switch(h.Name)
                {
                    case "Destabilizer Attack":
                        var t = new Timer();
                        t.Interval = 1000 / h.Effectiveness;
                        var rnd = new Random();
                        t.Tick += (object s, EventArgs a) =>
                        {
                            int r = rnd.Next(0, 100);
                            if(r == 90)
                            {
                                t.Stop();
                                API.CreateInfoboxSession("Hack complete.", "The hack has been completed.", infobox.InfoboxMode.Info);
                                GiveUpgrade(upgrade);
                                                    }
                            else
                            {
                                int p = rnd.Next(0, 10);
                                switch(p)
                                {
                                    case 1:
                                        API.OpenProgram("shiftorium");
                                        break;
                                    case 2:
                                        API.OpenProgram("ki");
                                        break;
                                    case 3:
                                        API.CreateInfoboxSession(API.Encryption.Encrypt("Praise Lord Michael"), API.Encryption.Encrypt("You will bow down to me."), infobox.InfoboxMode.Info);
                                        break;
                                    case 4:
                                        API.PlaySound(Properties.Resources._3beepvirus);
                                        break;
                                    case 5:
                                        API.CurrentSession.BackColor = Color.White;
                                        break;
                                    case 6:
                                        API.CurrentSession.BackColor = Color.Black;
                                        break;
                                    case 7:
                                        API.PlaySound(Properties.Resources.dial_up_modem_02);
                                        break;
                                    case 8:
                                        API.PlaySound(Properties.Resources.writesound);
                                        break;
                                    case 9:
                                        API.PlaySound(Properties.Resources.typesound);
                                        break;
                                }
                            }
                        };
                        t.Start();

                        
                        break;
                }
            }
        }

        /// <summary>
        /// Initiates the Hacker Battle training simulation.
        /// </summary>
        public static void StartBattleTutorial()
        {
            var e = new EnemyHacker("Tutorial", "Tutorial hacker", "Tutorial hacker", 0, 0, "easy");
            var y = new HackUI(e);
            y.IsTutorial = true;
            API.CreateForm(y, "You", Properties.Resources.iconTerminal);
        }

        /// <summary>
        /// Loads characters and other data from the save file.
        /// </summary>
        public static void GetCharacters()
        {
            if (File.Exists(Paths.SystemDir + "_hackers.json"))
            {
                Characters = JsonConvert.DeserializeObject<List<Character>>(API.Encryption.Decrypt(File.ReadAllText(Paths.SystemDir + "_hackers.json")));
            }
            else
            {
                var c = new Character("BinaryFire", "I may not be good, but it's what I like to do. You don't need to pay me.", 25, 10, 0);
                AddCharacter(c);
                File.WriteAllText(Paths.SystemDir + "_hackers.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(Characters)));
            }
            if(File.Exists(Paths.SystemDir + "_hacktools.json"))
            {
                Tools = JsonConvert.DeserializeObject<List<HackTool>>(API.Encryption.Decrypt(File.ReadAllText(Paths.SystemDir + "_hacktools.json")));
            }
            else
            {
                var c = new HackTool("Destabilizer Attack", 10, "Destabilize ShiftOS by causing it to go beyond what it can do, opening many programs at once, and making it do things it was NEVER intended to do.");
                AddTool(c);
                File.WriteAllText(Paths.SystemDir + "_hacktools.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(Tools)));

            }
            if (File.Exists(Paths.SystemDir + "_enemies.json"))
            {
                EnemyHackers = JsonConvert.DeserializeObject<List<EnemyHacker>>(API.Encryption.Decrypt(File.ReadAllText(Paths.SystemDir + "_enemies.json")));
            }
            else
            {
                var c = new EnemyHacker("Tutorial", "Enter the Tutorial Sequence.", "", 0, 0, "Easy");
                EnemyHackers.Add(c);
                File.WriteAllText(Paths.SystemDir + "enemies.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(EnemyHackers)));

            }
            if (File.Exists(Paths.Drivers + "Network.dri"))
            {
                MyNetwork = JsonConvert.DeserializeObject<List<Module>>(API.Encryption.Decrypt(File.ReadAllText(Paths.Drivers + "Network.dri")));
            }
            else
            {
                var c = new Module(SystemType.Core, 1, "localhost");
                c.HP = 100; //bugfix: core not appearing during battle on new save
                c.X = 0;
                c.Y = 0;
                MyNetwork.Add(c);
                File.WriteAllText(Paths.Drivers + "Network.dri", API.Encryption.Encrypt(JsonConvert.SerializeObject(MyNetwork)));

            }
            List<Module> coresToRemove = new List<Module>();
            foreach(var m in MyNetwork)
            {
                if(m.Type == SystemType.Core && m != MyCore)
                {
                    coresToRemove.Add(m);
                }
            }
            foreach(var m in coresToRemove)
            {
                MyNetwork.Remove(m);
            }
            RepairTimer = new Timer();
            RepairTimer.Interval = 2000;
            var r = new Random();
            RepairTimer.Tick += (object s, EventArgs a) =>
            {
                var repairable = new List<Module>();
                foreach(var mod in MyNetwork)
                {
                    if(mod.HP < mod.GetTotalHP())
                    {
                        repairable.Add(mod);
                    }
                }
                int index = r.Next(0, repairable.Count);
                try
                {
                    int increase = 1;
                    foreach(var mod in MyNetwork)
                    {
                        if(mod.Type == SystemType.RepairModule)
                        {
                            increase += mod.HP / 4;
                        }
                    }
                   
                    var m = repairable[index];
                    while(m.HP + increase > m.GetTotalHP())
                    {
                        increase -= 1;
                    }
                    if(m.HP < m.GetTotalHP())
                    {
                        m.HP += increase;
                    }
                }
                catch
                {

                }
            };
            RepairTimer.Start();
        }

        /// <summary>
        /// Saves characters and other data to the save file.
        /// </summary>
        public static void SaveCharacters()
        {
            if (MyNetwork == null)
            {
                MyNetwork = new List<Module>();
                var c = new Module(SystemType.Core, 1, "localhost");
                c.HP = 100; //bugfix: core not appearing during battle on new save
                c.X = 0;
                c.Y = 0;
                MyNetwork.Add(c);
            }
            File.WriteAllText(Paths.SystemDir + "_hackers.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(Characters)));
            File.WriteAllText(Paths.SystemDir + "_hacktools.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(Tools)));
            File.WriteAllText(Paths.Drivers + "Network.dri", API.Encryption.Encrypt(JsonConvert.SerializeObject(MyNetwork)));
            File.WriteAllText(Paths.SystemDir + "_enemies.json", API.Encryption.Encrypt(JsonConvert.SerializeObject(EnemyHackers)));

        }

        /// <summary>
        /// Tells user about the 'help hacking' command.
        /// </summary>
        public static void StartTutorial()
        {
            API.CreateInfoboxSession("Upgrade Category Not Available", "This upgrade category requires more capability from the OS, and is locked. You can type 'help hacking' in the Terminal for more info.", infobox.InfoboxMode.Info);
        }
    }

    public class Character
    {
        /// <summary>
        /// Creates a new hirable character.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="bio">The bio of the character.</param>
        /// <param name="skill">Starting skill level.</param>
        /// <param name="speed">Starting speed level.</param>
        /// <param name="cost">Amount of Codepoints required to hire the hacker.</param>
        public Character(string name, string bio, int skill, int speed, int cost)
        {
            Name = name;
            Skill = skill;
            Speed = speed;
            Cost = cost;
            Bio = bio;
        }

        public string Name { get; set; }
        public int Speed { get; set; }
        public int Skill { get; set; }
        public int Cost { get; set; }
        public string Bio { get; set; }
    }

    public class HackTool
    {
        /// <summary>
        /// Creates a new hacking tool.
        /// </summary>
        /// <param name="name">Tool name.</param>
        /// <param name="effectiveness">Effectiveness level.</param>
        /// <param name="description">Tool description.</param>
        public HackTool(string name, int effectiveness, string description)
        {
            Name = name;
            Effectiveness = effectiveness;
            Description = description;
        }

        public string Name { get; set; }
        public int Effectiveness { get; set; }
        public string Description { get; set; }
    }
    
    /// <summary>
    /// Enum representing a type of hack.
    /// </summary>
    public enum Hack
    {
        PriceDrop,
        PayoutIncrease,
    }

    public class Module
    {
        /// <summary>
        /// Creates a new module.
        /// </summary>
        /// <param name="t">Type of module.</param>
        /// <param name="grade">Starting grade level.</param>
        /// <param name="hname">Hostname.</param>
        public Module(SystemType t, int grade, string hname)
        {
            Hostname = hname;
            Type = t;
            Grade = grade;
        }

        public string Hostname { get; set; }
        public ModuleType ModuleType { get; set; }
        public SystemType Type { get; set; }
        public int HP { get; set; }
        public int Grade { get; set; }
        /// <summary>
        /// X position on the virtual network.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y position on the virtual network.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Deploys the module to a Computer control that can actually do things.
        /// </summary>
        /// <returns>The new computer.</returns>
        public Computer Deploy()
        {
            var c = new Computer();
            c.TotalHP = GetTotalHP(); //for proper status display
            c.Hostname = Hostname;
            c.Type = Type;
            c.HP = HP;
            c.Visible = true;
            c.Grade = Grade;
            if(X != 0 && Y != 0)
            {
                c.Location = new Point(X, Y);
            }
            return c;
        }

        public int GetTotalHP()
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
    }

    /// <summary>
    /// Unused...
    /// </summary>
    public enum ModuleType
    {
        Offensive,
        Defensive
    }

    public class EnemyHacker
    {
        /// <summary>
        /// An enemy network.
        /// </summary>
        /// <param name="name">Leader or network name.</param>
        /// <param name="description">Network Description</param>
        /// <param name="fdesc">If the leader becomes a friend, what will his bio be?</param>
        /// <param name="fskill">If the leader becomes a friend, what will his skill be?</param>
        /// <param name="fspeed">If the leader becomes a friend, what will his speed be?</param>
        /// <param name="difficulty">Arbitrary value that means absolutely nothing.</param>
        public EnemyHacker(string name, string description, string fdesc, int fskill, int fspeed, string difficulty) 
        {
            Name = name;
            Description = description;
            FriendDesc = fdesc;
            FriendSkill = fskill;
            FriendSpeed = fspeed;
            Difficulty = difficulty;
            Network = new List<Module>();
            var m = new Module(SystemType.Core, 1, name.ToLower().Replace(" ", "_"));
            m.X = 0;
            m.Y = 0;
            Network.Add(m); //Hacker will always have a core system.
        }

        public bool IsLeader = false;
        public string Name { get; set; }
        public string FriendDesc { get; set; }
        public string Description { get; set; }
        public int FriendSpeed { get; set; }
        public int FriendSkill { get; set; }
        public string Difficulty { get; set; }
        public List<Module> Network { get; set; }
        
        /// <summary>
        /// Add a new module to this hacker's network.
        /// </summary>
        /// <param name="m">The module to add.</param>
        public void AddModule(Module m)
        {
            Network.Add(m);
        }

        /// <summary>
        /// Befriends the leader.
        /// </summary>
        /// <param name="cost">How much will it cost to hire him?</param>
        public void Befriend(int cost)
        {
            var c = new Character(Name, FriendDesc, FriendSpeed, FriendSkill, cost);
            Hacking.AddCharacter(c);
            Hacking.SaveCharacters();
        }

        
    }

    public class FutureModule
    {
        /// <summary>
        /// A purchasable module.
        /// </summary>
        /// <param name="name">Module name.</param>
        /// <param name="cost">Cost in Codepoints</param>
        /// <param name="description">Module description</param>
        /// <param name="type">Module type.</param>
        public FutureModule(string name, int cost, string description, SystemType type)
        {
            Name = name;
            Description = description;
            Type = type;
            Cost = cost;
        }

        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public SystemType Type { get; set; }
    }
}
