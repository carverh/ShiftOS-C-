using Newtonsoft.Json;
using ShiftOS.FinalMission;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Terminal : Form
    {
        string current_dir = "";

        public Terminal()
        {
            InitializeComponent();
            current_dir = Paths.SaveRoot;
        }

        public Terminal(bool modlog)
        {
            ModLogger = modlog;
            InitializeComponent();
            API.LoggerTerminal = this;
            current_dir = Paths.SaveRoot;
        }


        public bool ModLogger = false;

        private void Terminal_Load(object sender, EventArgs e)
        {
            objToWriteTo = this.txtterm;
            SaveSystem.Utilities.LoadedSave.newgame = false;
            if (API.Upgrades["windowedterminal"] == true)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

            txtterm.KeyDown += new KeyEventHandler(txtterm_KeyPress);
            txtterm.Click += new EventHandler(txtterm_Click);
            tmrfirstrun.Tick += new EventHandler(tmrfirstrun_Tick);
            tmrshutdown.Tick += new EventHandler(tmrshutdown_Tick);
            if (Hacking == false)
            {
                WriteLine(prefix);
            }
            txtterm.Select(txtterm.TextLength, 0);
            if (API.Upgrades["terminalscrollbar"] == true)
            {
                txtterm.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                txtterm.ScrollBars = ScrollBars.None;

            }
            txtterm.MouseWheel += (object s, MouseEventArgs a) =>
            {
                if (Zooming == true)
                {
                    txtterm.ScrollBars = ScrollBars.None;
                    if (ZoomMultiplier > 0)
                    {
                        if (a.Delta > 0)
                        {
                            ZoomMultiplier += 1;
                        }
                        else
                        {
                            ZoomMultiplier -= 1;
                        }
                        ResetTerminalFont();
                    }
                    else
                    {
                        ZoomMultiplier = 1;
                    }
                }
            };
            ResetTerminalFont();
            StartLogCheck();
            tmrsetfont.Start();


        }


        private void StartLogCheck()
        {
            if (ModLogger == true)
            {
                var tmrlog = new System.Windows.Forms.Timer();
                tmrlog.Interval = 500;
                tmrlog.Tick += (object s, EventArgs a) =>
                {
                    if (File.Exists(Paths.Mod_Temp + "cmdlog"))
                    {
                        string log = File.ReadAllText(Paths.Mod_Temp + "cmdlog");
                        API.CreateInfoboxSession("test", log, infobox.InfoboxMode.Info);
                    }
                };
                tmrlog.Start();
            }
        }

        public string[] cmds;
        public int rolldownsize;
        public int oldbordersize;
        public int oldtitlebarheight;
        public bool justopened = false;
        public bool needtorollback = false;
        public int minimumsizewidth = 350;

        public int minimumsizeheight = 200;

        public string EndOfAlias;
        public string command;
        int trackpos;
        int firstrun;
        public bool sendinputtomod = false;

        string prefix = $"{API.Username}@{API.OSName} $> ";

        private void ReadCommand()
        {
            command = txtterm.Lines[txtterm.Lines.Length - 1];
            command = command.Replace(prefix, "");
            command = command.ToLower();
        }

        internal void StartDanaRossStory()
        {
            var t = new Thread(new ThreadStart(new Action(() =>
            {
                WriteLine("User <65.48.121.24> connecting as 'Dana'");
                API.PlaySound(Properties.Resources.dial_up_modem_02);
                WriteLine("Dana: Hey! That was quite the battle, huh?");
                BeepSleep(1000);
                WriteLine("Dana: Well - since you beat me, let me let you in on a little secret.");
                BeepSleep(3000);
                WriteLine("Dana: ShiftOS's desktop may seem pretty complicated and customizable for you right now, but trust me. It gets better.");
                BeepSleep(2500);
                WriteLine("Dana: I'm gonna patch your Shiftorium so you can get some neat upgrades!");
                BeepSleep(3000);
                WriteLine("Dana: Also, if you feel like doing more hacker battles, why not check out Tier 2 in the Network Browser?");
                BeepSleep(2750);
                WriteLine("Dana: I've also added my network modules to your network - you'll just have to wait for them to regenerate.");
                BeepSleep(500);
                WriteLine("Dana: Well, talk to you some other time!");
                BeepSleep(1000);
                this.Invoke(new Action(() =>
                {
                    API.Upgrades["midgamebridge"] = true;
                    this.Close();
                }));
            })));
            t.Start();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtterm_Click(object sender, EventArgs e)
        {
            txtterm.Select(txtterm.TextLength, 0);
            txtterm.ScrollToCaret();
        }

        public void SelectBottom()
        {
            txtterm.Focus();
            txtterm.Select(txtterm.TextLength, 0);
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtterm_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control)
            {
                if (API.Upgrades["zoomableterminal"] == true)
                {
                    Zooming = true;
                }
            }

            if (e.KeyCode == Keys.T && e.Control && blockctrlt == false)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }

            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    trackpos = trackpos - 1;
                    break;
                case Keys.Alt:
                    trackpos = trackpos - 1;
                    break;
                case Keys.CapsLock:
                    trackpos = trackpos - 1;
                    break;
                case Keys.ControlKey:
                    trackpos = trackpos - 1;
                    break;
                case Keys.LWin:
                    trackpos = trackpos - 1;
                    break;
                case Keys.RWin:
                    trackpos = trackpos - 1;
                    break;
                case Keys.Right:
                    if (Hacking == false)
                    {
                        if (txtterm.SelectionStart == txtterm.TextLength)
                        {
                            trackpos = trackpos - 1;
                        }
                    }
                    else
                    {
                        switch (SelectedMode)
                        {
                            case 1:
                                if (SelectedCharacter < ShiftOS.Hacking.Tools.Count - 1)
                                {
                                    SelectedCharacter += 1;
                                    ShowTools();
                                }
                                break;
                            case 2:
                                if (SelectedCharacter < ShiftOS.Hacking.Characters.Count - 1)
                                {
                                    SelectedCharacter += 1;
                                    ShowChar();
                                }
                                break;
                        }
                    }
                    break;
                case Keys.Left:
                    if (Hacking == false)
                    {
                        if (trackpos < 1)
                        {
                            e.SuppressKeyPress = true;
                            trackpos = trackpos - 1;
                        }
                        else
                        {
                            trackpos = trackpos - 2;
                        }
                    }
                    else
                    {
                        switch (SelectedMode)
                        {
                            case 1:
                                if (SelectedCharacter > 0)
                                {
                                    SelectedCharacter -= 1;
                                    ShowTools();
                                }

                                break;
                            case 2:
                                if (SelectedCharacter > 0)
                                {
                                    SelectedCharacter -= 1;
                                    ShowChar();
                                }
                                break;

                        }
                    }
                    break;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    ReadCommand();
                    if (API.LastRanCommand != "" && command == "")
                    {
                        txtterm.Text += API.LastRanCommand;
                        trackpos += API.LastRanCommand.Length;
                        txtterm.Select(txtterm.TextLength, 0);
                    }
                    else
                    {
                        trackpos = trackpos - 1;
                    }
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    trackpos = trackpos - 1;
                    break;
                case Keys.D1:
                    if (Hacking == true)
                    {
                        SelectedMode = 1;
                        Hack_ShowCharacters();
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        trackpos -= 1;
                    }
                    break;
                case Keys.D2:
                    if (Hacking == true && SelectedMode == 0)
                    {
                        SelectedMode = 2;
                        Hack_ShowCharacters();
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        trackpos -= 1;
                    }
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (LuaMode == false)
                {
                    if (Hacking == false)
                    {
                        ReadCommand();
                        if (command != "")
                        {
                            DoCommand();
                        }

                        if (command == "clear")
                        {
                            txtterm.Text = txtterm.Text + prefix;
                            txtterm.Select(txtterm.Text.Length, 0);
                        }
                        else
                        {
                            txtterm.Text = txtterm.Text + Environment.NewLine + prefix;
                            txtterm.Select(txtterm.Text.Length, 0);
                        }
                        trackpos = 0;
                    }
                    else
                    {
                        switch (SelectedMode)
                        {
                            case 1:
                                ShiftOS.Hacking.StartHack(SelectedCharacter, UpgradeToHack);
                                this.Close();
                                break;
                            case 2:
                                var c = ShiftOS.Hacking.Characters[SelectedCharacter].Cost;
                                if (API.Codepoints >= c)
                                {
                                    API.RemoveCodepoints(c);
                                    ShiftOS.Hacking.StartHackWithCharacter(SelectedCharacter, UpgradeToHack);
                                    this.Close();
                                }
                                else
                                {
                                    WriteLine("You can't afford to pay this partner. Please choose another.");
                                }
                                break;
                        }
                    }
                }
                else
                {
                    trackpos = 0;
                    var lua = txtterm.Lines[txtterm.Lines.Length - 1];
                    try
                    {
                        Interpreter.mod(lua);
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
                    }
                    if (LuaMode == true)
                    {
                        WriteLine("");
                    }
                    txtterm.Select(txtterm.TextLength, 0);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Back)
                {
                }
                else
                {
                    if (Viruses.InfectedWith("keyboardfucker"))
                    {
                        var rnd = new Random();
                        if (rnd.Next(0, 20) == 10)
                        {
                            e.Handled = true;
                            txtterm.Text += Viruses.KeyboardInceptor.Intercept();
                            trackpos += 1;
                        }
                        else
                        {
                            trackpos += 1;
                        }
                    }
                    else
                    {
                        trackpos = trackpos + 1;
                    }
                }
            }

            if (e.KeyCode == Keys.Back)
            {
                if (trackpos < 1)
                {
                    e.SuppressKeyPress = true;
                }
                else
                {
                    if (txtterm.SelectedText.Length < 1)
                    {
                        trackpos = trackpos - 1;
                    }
                    else
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }

            if (SaveSystem.ShiftoriumRegistry.ShiftoriumUpgrades["autoscrollterminal"] == true)
            {
                txtterm.Select(txtterm.TextLength, 0);
                txtterm.ScrollToCaret();
            }

        }

        public void SetPrefix(string _prefix)
        {
            prefix = _prefix;
        }


        /// <summary>
        /// Call after creating a Terminal to let Maureen Fenn talk
        /// to the player about the Shiftnet and the Appscape Package Manager.
        /// </summary>
        public void StartShiftnetStory()
        {
            System.Windows.Forms.Timer tmrstory = new System.Windows.Forms.Timer();
            tmrstory.Interval = 10000;
            WriteLine("IP <hidden@shiftnet> connecting as 'Maureen Fenn'...");
            API.PlaySound(Properties.Resources.dial_up_modem_02);
            var t = new Thread(new ThreadStart(new Action(() =>
            {
                WriteLine("Maureen Fenn: Hey there, user! I have something to show you.");
                BeepSleep(4000);
                WriteLine("Maureen Fenn: So, there's this thing called the 'Shiftnet'");
                BeepSleep(3750);
                WriteLine("Maureen Fenn: Turns out, that DevX wants to keep it a secret, as such he only installed it on his and my systems.");
                BeepSleep(4250);
                WriteLine("Maureen Fenn: But what's the point of listening to DevX when we have people like you who like to experiment?");
                BeepSleep(4000);
                WriteLine("Maureen Fenn: Well, to be fair - he can destroy whatever he wants. Just like he did my company, Minimatch.");
                BeepSleep(3000);
                WriteLine("Maureen Fenn: But who cares! I'm going to install a few things on your system.");
                API.Upgrades["shiftnet"] = true;
                this.Invoke(new Action(() =>
                {
                    this.command = "spkg install shiftnet";
                    this.DoCommand();
                }));
                WriteLine("Shiftnet installed on system...");
                Thread.Sleep(4000);
                WriteLine("Maureen Fenn: All done! Oh - just before I leave... go ahead and explore the Shiftnet!");
                BeepSleep(3000);
                WriteLine("Maureen Fenn: But, be careful. Don't venture off the main server. You never know what's elsewhere...");
                BeepSleep(1000);
                WriteLine("Maureen Fenn: Well, bye!");
                this.Invoke(new Action(() =>
                {
                    API.CurrentSession.SetupDesktop();
                    this.Close();
                }));
            })));
            t.Start();
        }

        /// <summary>
        /// *BEEP* ZZZZZZZZzzzzzzzzzzz.......
        /// </summary>
        /// <param name="time">Time to sleep.</param>
        private void BeepSleep(int time)
        {
            API.PlaySound(Properties.Resources.writesound);
            Thread.Sleep(time);
        }

        private LuaInterpreter Interpreter = null;
        private bool blockctrlt = false;

        private List<string> GetFonts()
        {
            var lst = new List<string>();
            // Get the installed fonts collection.
            InstalledFontCollection allFonts = new InstalledFontCollection();

            // Get an array of the system's font familiies.
            FontFamily[] fontFamilies = allFonts.Families;

            // Display the font families.
            foreach (FontFamily myFont in fontFamilies)
            {
                lst.Add(myFont.Name.ToLower());
            }
            //font_family

            return lst;
        }

        public List<string> GetColorList()
        {
            var lst = new List<string>();
            if (API.Upgrades["red"] == true)
                lst.Add("red");
            if (API.Upgrades["green"] == true)
                lst.Add("green");
            if (API.Upgrades["blue"] == true)
                lst.Add("blue");
            if (API.Upgrades["brown"] == true)
                lst.Add("brown");
            if (API.Upgrades["purple"] == true)
                lst.Add("purple");
            if (API.Upgrades["yellow"] == true)
                lst.Add("yellow");
            if (API.Upgrades["orange"] == true)
                lst.Add("orange");
            if (API.Upgrades["pink"] == true)
                lst.Add("pink");
            if (API.Upgrades["gray"] == true)
                lst.Add("gray");
            lst.Add("black");
            lst.Add("white");
            return lst;
        }

        public Color SetColor(string name)
        {
            Color col = Color.White;
            switch (name)
            {
                case "black":
                    col = Color.Black;
                    break;
                case "white":
                    col = Color.White;
                    break;
                case "gray":
                    col = Color.Gray;
                    break;
                case "red":
                    col = Color.Red;
                    break;
                case "green":
                    col = Color.Green;
                    break;
                case "blue":
                    col = Color.Blue;
                    break;
                case "brown":
                    col = Color.Brown;
                    break;
                case "purple":
                    col = Color.Purple;
                    break;
                case "yellow":
                    col = Color.Yellow;
                    break;
                case "orange":
                    col = Color.Orange;
                    break;
            }
            return col;
        }

        private bool LuaMode = false;

        public string GetPath(string path)
        {
            return path.Replace(Paths.SaveRoot, "").Replace(OSInfo.DirectorySeparator, "/");
        }

        public string GetParent(string path)
        {
            if (new DirectoryInfo(path).Parent.FullName.Contains("ShiftOS"))
            {
                var d = new DirectoryInfo(path);
                return d.Parent.FullName;
            }
            else
            {
                return path;
            }
        }

        public void DoCommand()
        {
            //Grab the type of this class using Reflection.
            var terminal = this.GetType();
            string[] cmdargs = command.Split(' ');
            var method_info = terminal.GetMethod("cmd_" + cmdargs[0].ToLower());
            if (method_info != null)
            {
                method_info.Invoke(this, new object[] { cmdargs });
            }
            else
            {
                terminal.GetMethod("cmd_default").Invoke(this, new object[] { cmdargs });
            }
        }

        #region Terminal command methods

        /*
         * Adding terminal commands has been changed.
         * 
         * It's now done in a way that doesn't require hardcoding.
         * 
         * Simply add a new method here with a prefix 'cmd_', for example 'cmd_05tray', and
         * one argument of type 'string[]'. Then, put all the stuff you want your command to
         * do in that method, and try running your command (without the 'cmd_' prefix) in the
         * Terminal and it should work just fine.
         * 
         * Thanks to @carverh for inspiring this by making all commands their own function.
         */

        public void cmd_dir(String[] args)
        {
            if (API.Upgrades["fileskimmer"])
            {
                foreach (var d in Directory.GetDirectories(current_dir))
                {
                    WriteLine($"[DIR] {new DirectoryInfo(d).Name}");
                }
                foreach (var d in Directory.GetFiles(current_dir))
                {
                    WriteLine($"{new FileInfo(d).Name}");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_cd(String[] args)
        {
            try
            {
                if (API.Upgrades["fileskimmer"])
                {
                    if (args[1] == "..")
                    {
                        if (GetPath(current_dir) != "/")
                        {
                            current_dir = GetParent(current_dir);
                            SetPrefix($"{API.Username}@{API.OSName} in {GetPath(current_dir)} $> ");
                        }
                        else
                        {
                            WriteLine("cd: Can't go up past the root.");
                        }
                    }
                    else
                    {
                        string newdir = current_dir + OSInfo.DirectorySeparator;
                        foreach (var dir in Directory.GetDirectories(current_dir))
                        {
                            if (new DirectoryInfo(dir).Name.ToLower() == args[1])
                                newdir = dir;
                        }
                        current_dir = newdir;
                        SetPrefix($"{API.Username}@{API.OSName} in {GetPath(current_dir)} $> ");
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine("cd: " + e);
            }
        }


        public void cmd_upg(String[] args)
        {
            if (API.DeveloperMode)
            {
                try
                {
                    switch (args[1])
                    {
                        case "get":
                            WriteLine(API.Upgrades[args[2]].ToString());
                            break;
                    }
                }
                catch
                {

                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_endgame_test(String[] args)
        {
            if (API.DeveloperMode)
            {
                try
                {
                    switch (args[1])
                    {
                        case "choice_screen":
                            var cscreen = new ShiftOS.FinalMission.ChooseYourApproach();
                            cscreen.WindowState = FormWindowState.Maximized;
                            //cscreen.TopMost = true;
                            cscreen.Show();
                            break;
                        case "limitedmode":
                            API.LimitedMode = !API.LimitedMode;
                            WriteLine($"Limited mode set to {API.LimitedMode}.");
                            break;
                    }
                }
                catch
                {
                    WriteLine("Invalid arguments.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_htutorial(String[] args)
        {
            ShiftOS.Hacking.StartBattleTutorial();
        }

        public void cmd_fake_buy(String[] args)
        {
            if (API.DeveloperMode)
            {
                try
                {
                    if (API.Upgrades.ContainsKey(args[1]))
                    {
                        API.Upgrades[args[1]] = true;
                        WriteLine($"Bought upgrade {args[1]}.");
                        API.CurrentSession.SetupAppLauncher();
                        API.UpdateWindows();
                        SaveSystem.Utilities.saveGame();
                    }
                    else
                    {
                        WriteLine("Upgrade not found.");
                    }
                }
                catch
                {
                    WriteLine("fake_buy: Bad arguments.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_connections(String[] args)
        {
            try
            {
                switch (args[1])
                {
                    case "list":
                        foreach (var client in Package_Grabber.clients)
                        {
                            WriteLine($"Hostname: {client.Key}, Port: {client.Value.RemotePort}, Online: {client.Value.IsConnected}");
                        }
                        break;
                    case "gui":
                        API.CreateForm(new ConnectionManager(), "Connections", API.GetIcon("Connections"));
                        break;
                    case "drop":
                        foreach (var client in Package_Grabber.clients)
                        {
                            Package_Grabber.Disconnect(client.Key);
                        }
                        break;
                    case "add":
                        string host = args[2];
                        int port = 0;
                        int.TryParse(args[3], out port);
                        if (!Package_Grabber.clients.ContainsKey(host))
                        {
                            Package_Grabber.ConnectToServer(host, port);
                            WriteLine("Connection to host established successfully.");
                        }
                        else
                        {
                            var c = Package_Grabber.clients[host];
                            if (c.IsConnected == false)
                            {
                                c.Connect(host, port);
                                WriteLine("Re-established connection with host.");
                            }
                            else
                            {
                                WriteLine("This host has been connected to already.");
                            }
                        }
                        break;
                }
            }
            catch
            {
                WriteLine("connections: Missing arguments.");
            }
        }

        public void cmd_story(String[] args)
        {
            if (API.DeveloperMode == true && API.Upgrades["shiftnet"])
            {
                try
                {
                    switch (args[1])
                    {
                        case "aidennirh":
                            StartAidenNirhStory();
                            break;
                        case "devxfurious":
                            StartDevXFuriousStory();
                            break;
                        case "battletut":
                            StartHackerBattleIntro();
                            break;
                        case "otherplayer":
                            StartDevXFuriousStory();
                            break;
                        case "hacker101":
                            StartHacker101Story();
                            break;
                    }
                }
                catch
                {
                    WriteLine("Missing arguments.");
                }
            }
            else { wrongcommand(); }
        }

        public void cmd_make(String[] args)
        {
            try
            {
                string path = command.Replace("make ", "");
                string realpath = $"{Paths.SaveRoot}{path.Replace("/", OSInfo.DirectorySeparator)}";
                if (File.Exists(realpath + OSInfo.DirectorySeparator + "main.lua"))
                {
                    WriteLine("Compiling to " + path + ".saa");
                    ZipFile.CreateFromDirectory(realpath, realpath + ".saa");
                }
                else
                {
                    WriteLine($"make: *** No rule to make target \"{realpath}\". Stop.");
                }
            }
            catch
            {
                WriteLine("make: Invalid arguments.");
            }
        }

        public void cmd_devupg(String[] args)
        {
            if (API.DeveloperMode)
            {
                WriteLine("Upgrading your system...");
                foreach (var upg in Shiftorium.Utilities.GetAvailable())
                {
                    API.Upgrades[upg.id] = true;
                    WriteLine("Installed upgrade \"" + upg.Name + "\"...");
                }
                API.UpdateWindows();
                API.CurrentSession.SetupDesktop();
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_netgen(String[] args)
        {
            WriteLine("Starting netgen...");
            API.CreateForm(new NetGen(), "Network Generator", API.GetIcon("Terminal"));
        }

        public void cmd_lua(String[] args)
        {
            if (API.DeveloperMode == true)
            {
                try
                {
                    string f = args[1];
                    WriteLine(f);
                    f = command.Remove(0, 4);
                    WriteLine(f);
                    string real = $"{Paths.SaveRoot}{f.Replace("/", OSInfo.DirectorySeparator)}";
                    WriteLine(real);
                    if (File.Exists(real))
                    {
                        WriteLine("Running Lua script at " + f + ".");
                        var l = new LuaInterpreter(real);
                    }
                    else
                    {
                        WriteLine("Lua script file not found.");
                    }
                }
                catch
                {
                    this.LuaMode = true;
                    this.Interpreter = new LuaInterpreter();
                    this.Interpreter.mod.print = new Action<string>((text) => WriteLine(text));
                    this.Interpreter.mod.exit = new Action(() =>
                    {
                        this.LuaMode = false;
                        this.Interpreter = null;
                        WriteLine($"{API.CurrentSave.username}@{API.CurrentSave.osname} $> ");
                    });
                    WriteLine("ShiftOS Lua Interpreter - v1.0");
                    WriteLine("Created by Michael VanOverbeek");
                    WriteLine(Environment.NewLine + "How to use: Simply type some Lua code and watch it come to life. Code can be executed on one line, and unlike most interpreters, you can access code from one line in another.");
                    WriteLine(Environment.NewLine + "When you're done, simply press the Enter key to execute the code." + Environment.NewLine);
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_hack(String[] args)
        {
            if (API.Upgrades["hacking"] == true)
            {
                StartHackingSession("random");
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_vscan(String[] args)
        {
            if (API.Upgrades["virusscanner"] == true)
            {
                WriteLine("Scanning for infected files...");
                var goodList = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> kv in Viruses.Infections)
                {
                    if (kv.Value.Contains(";"))
                    {
                        foreach (string file in kv.Value.Split(';'))
                        {
                            if (goodList.ContainsKey(file))
                            {
                                goodList[file] += ", " + kv.Key;
                            }
                            else
                            {
                                goodList.Add(file, kv.Key);
                            }
                        }
                    }
                    else
                    {
                        if (goodList.ContainsKey(kv.Value))
                        {
                            goodList[kv.Value] += ", " + kv.Key;
                        }
                        else
                        {
                            goodList.Add(kv.Value, kv.Key);
                        }
                    }
                }
                WriteLine("Scan complete.");
                if (goodList.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kv in goodList)
                    {
                        WriteLine("File " + kv.Key + " is infected with " + kv.Value + ". Disinfecting...");
                        Viruses.DisInfect(kv.Key);
                    }
                    WriteLine("Disinfection complete.");
                }
                else
                {
                    WriteLine("No infections found. You are safe.");
                }
            }
        }

        public void cmd_infections(String[] args)
        {
            if (API.DeveloperMode == true)
            {
                foreach (KeyValuePair<string, string> kv in Viruses.Infections)
                {
                    WriteLine(kv.Key + " @ " + kv.Value);
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_binarywater(String[] args)
        {
            if (API.DeveloperMode)
            {
                ShiftOS.Hacking.AddCharacter(new Character("Philip Adams", "Hello, and welcome to another episode of OSFirstTimer.", 100, 100, 0));
                WriteLine("Philip Adams is now in the list of hirable hackers.");
                WriteLine("\" I Don't Think This is Canon \" -Carver");
            }
            else
            {
                WriteLine("I see you went in the ShiftOS source code... ummm yeah... this isn't a developer mode release so I can't just give you a full-skilled hacker even if you beg.");
            }
        }

        public void cmd_color(String[] args)
        {
            try
            {
                if (API.Upgrades["setterminalcolors"] == true)
                {

                    Color bcol = SetColor(args[1]);
                    Color tcol = SetColor(args[2]);
                    API.CurrentSkin.TerminalTextColor = tcol;
                    API.CurrentSkin.TerminalBackColor = bcol;

                }
            }
            catch (Exception)
            {
                WriteLine("color: Missing arguments.");
            }
        }

        public void cmd_encrypt(String[] args)
        {
            if (API.DeveloperMode == true)
            {
                string messageToEncrypt = command.Replace("encrypt ", "");
                string encryptedMessage = API.Encryption.Encrypt(messageToEncrypt);
                WriteLine("Encrypted Message: " + encryptedMessage);
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_font(String[] args)
        {
            if (API.Upgrades["setterminalfont"] == true)
            {
                var fname = command.Replace("font ", "");
                if (GetFonts().Contains(fname))
                {
                    API.CurrentSkin.TerminalFontStyle = fname;
                }
                else
                {
                    WriteLine("font: Unrecognized font name \"" + fname + "\". Note: Font names are case sensitive.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_colorlist(String[] args)
        {
            if (API.Upgrades["setterminalcolors"] == true)
            {
                foreach (string itm in GetColorList())
                {
                    WriteLine(itm);
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_spkg(String[] args)
        {
            if (!API.LimitedMode)
            {
                if (API.Upgrades["shiftnet"] == true)
                {
                    try
                    {
                        switch (args[1].ToLower())
                        {
                            case "install":
                                if (args[2] != null && args[2] != "")
                                {
                                    string pkgname = args[2].ToLower().Replace(".pkg", "");
                                    if (Package_Grabber.GetPackage(pkgname) == true)
                                    {
                                        WriteLine("Downloaded package '" + pkgname + "' from shiftnet://main/spkg/ successfully. Installing now.");
                                        string r = Package_Grabber.ExtractPackage();
                                        if (r == "fail")
                                        {
                                            WriteLine("[FATAL] Could not install package.");
                                            WriteLine("spkg: Killed.");
                                        }
                                        else
                                        {
                                            WriteLine("Extracted " + pkgname + " to " + r + "...");
                                            var res2 = Package_Grabber.InstallPackage(r + "\\");
                                            if (res2 != "success")
                                            {
                                                WriteLine("[FATAL] Could not install package. " + res2);
                                                WriteLine("spkg: Killed.");
                                            }
                                            else
                                            {
                                                WriteLine("[DONE] Package installed.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        WriteLine("spkg: Package '" + args[2] + "' not found.");
                                    }
                                }
                                break;
                            default:
                                WriteLine("spkg: Invalid argument: " + args[1]);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLine("spkg: " + ex.Message);
                    }
                }
                else
                {
                    wrongcommand();
                }
            }
            else
            {
                try
                {
                    if (args[2] == "god_utils")
                    {
                        if (FinalMission.EndGameHandler.GodModeInstallEnabled == true)
                        {
                            var t = new Thread(new ThreadStart(new Action(() =>
                            {
                                WriteLine("Downloading package 'god_utils'... Please wait.");
                                Thread.Sleep(10000);
                                WriteLine("Download complete.");
                                Thread.Sleep(100);
                                WriteLine("Beginning installation.");
                                Thread.Sleep(1000);
                                WriteLine(@" == GOD MODE ==
God Mode gives you FULL control of ShiftOS. You can add/remove Codepoints, buy or unbuy Shiftorium upgrades, and can do whatever you want.
Installing core applications...");
                                Thread.Sleep(250);
                                WriteLine("Installing subpackage 'json_edit'...");
                                Thread.Sleep(250);
                                WriteLine("Installing subpackage 'upgrade_mod'...");
                                Thread.Sleep(100);
                                WriteLine("Installing subpackage 'hijacker'...");
                                Thread.Sleep(500);
                                WriteLine(@" == HIJACKER by DevX ==
HIJACKER is a utility that allows you to hijack any system and install ShiftOS on it during a hacker battle.");
                                Thread.Sleep(100);
                                WriteLine("[hijacker] Injecting HIJACKER code into hbattleui.sft...");
                                Thread.Sleep(150);
                                WriteLine("[hijacker] Done.");
                                this.Invoke(new Action(() =>
                                {
                                    StartChoice1EndStory();
                                }));
                            })));
                            t.Start();
                        }
                        else
                        {
                            WriteLine("spkg: Package '" + args[2] + "' not found.");
                        }
                    }
                    else
                    {
                        WriteLine("spkg: Package '" + args[2] + "' not found.");
                    }
                }
                catch
                {
                    WriteLine("spkg: Missing arguments.");
                }
            }
        }

        /// <summary>
        /// Command Functions, to Be Used For ShiftBatch
        /// </summary>
        /// <param name="args">String[] args</param>
        public void cmd_alias(String[] args)
        {
            try
            {
                switch (args[1])
                {
                    case "-?":
                    case "--help":
                        WriteLine("Aliases Help" + Environment.NewLine);
                        WriteLine("Alias is a command that lets you create aliases for other commands. You could make a command 'upgrade' alias 'shiftorium' if you wanted." + Environment.NewLine);
                        WriteLine("Arguments:");
                        WriteLine(" -h, --help: Displays this screen.");
                        WriteLine("-a, --add <alias> <command>: Adds a new alias.");
                        WriteLine("-d, --delete <alias>: Deletes an alias.");
                        WriteLine("-l, --list: Shows all available aliases.");
                        break;
                    case "--add":
                    case "-a":
                        if (API.AddAlias(args[2], command.Replace("alias " + args[1] + " " + args[2] + " ", "")))
                        {
                            WriteLine("Alias added successfully.");
                            API.SaveAliases();
                        }
                        else
                        {
                            WriteLine("That alias already exists.");
                        }
                        break;
                    case "--delete":
                    case "-d":
                        if (API.RemoveAlias(args[2]) == true)
                        {
                            WriteLine("Alias \"" + args[2] + "\" removed successfully.");
                            API.SaveAliases();
                        }
                        else
                        {
                            WriteLine("That alias doesn't exist.");
                        }
                        break;
                    case "-l":
                    case "--list":
                        WriteLine("Aliases:");
                        foreach (KeyValuePair<string, string> kv in API.CommandAliases)
                        {
                            WriteLine(kv.Key + " => " + kv.Value);
                        }
                        break;
                    default:
                        WriteLine("alias: Invalid argument. Try alias --help for help with the Alias command.");
                        break;
                }
            }
            catch
            {
                WriteLine("alias: Missing arguments. Try alias --help for help with the Alias command.");
            }
        }

        public void cmd_username(String[] args)
        {
            if (API.Upgrades["customusername"] == true)
            {
                try
                {
                    API.CurrentSave.username = args[1];
                }
                catch
                {
                    WriteLine("username: Missing arguments.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_osname(String[] args)
        {
            if (API.Upgrades["customusername"] == true)
            {
                try
                {
                    API.CurrentSave.osname = args[1];
                }
                catch
                {
                    WriteLine("osname: Missing arguments.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_unity(String[] args)
        {
            if (API.Upgrades["unitymode"] == true)
            {
                API.CurrentSession.SetUnityMode();
                API.CurrentSession.SetupDesktop();
                txtterm.Focus();
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_time(String[] args)
        {
            if (API.Upgrades["pmandam"] == false)
            {
                if (API.Upgrades["hourssincemidnight"] == false)
                {
                    if (API.Upgrades["minutessincemidnight"] == false)
                    {
                        if (API.Upgrades["secondssincemidnight"] == true)
                        {
                            WriteLine("Since midnight, " + API.GetTime() + " seconds have passed.");
                        }
                        else
                        {
                            wrongcommand();
                        }
                    }
                    else
                    {
                        WriteLine("Since midnight, " + API.GetTime() + " minutes have passed.");
                    }
                }
                else
                {
                    WriteLine("Since Midnight, " + API.GetTime() + " hours have passed.");
                }
            }
            else
            {
                WriteLine("Current time: " + API.GetTime());
            }
        }

        public void cmd_saa(String[] args)
        {
            if (API.Upgrades["shiftnet"])
            {
                var f = command.Replace("saa ", "");
                if (f.StartsWith("/"))
                {
                    var withoutslash = f.Remove(0, 1);
                    var dirsep = OSInfo.DirectorySeparator;
                    var rightdir = $"{Paths.SaveRoot}{dirsep}{f.Replace("/", dirsep)}";
                    if (File.Exists(rightdir))
                    {
                        var finf = new FileInfo(rightdir);
                        if (finf.Extension == ".saa")
                        {
                            API.LaunchMod(finf.FullName);
                        }
                        else
                        {
                            WriteLine("saa: Cannot launch the file '" + finf.FullName + " because it isn't a valid stand-alone app.");
                        }
                    }
                    else
                    {
                        WriteLine("saa: Cannot launch the file '" + f + "' because it doesn't exist.");
                    }
                }
                else
                {
                    WriteLine("saa: Cannot launch the file '" + f + "' because it doesn't exist.");
                }
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_help(String[] args)
        {
            try
            {
                showhelp(args[1]);
            }
            catch
            {
                showhelp();
            }
        }

        public void cmd_cp(String[] args)
        {
            WriteLine("You have " + API.Codepoints.ToString() + " Codepoints.");
        }

        public void cmd_shutdown(String[] args)
        {
            API.ShutDownShiftOS();
        }

        public void cmd_clear(String[] args)
        {
            txtterm.Text = "";
        }

        public void cmd_close(String[] args)
        {
            if (command.Contains("close "))
            {
                var pid = command.Replace("close ", "");
                if (API.CloseProgram(pid) == true)
                {
                    WriteLine("Closed all running " + pid + "s.");
                }
                else
                {
                    WriteLine("No processes with id '" + pid + "' were found!");
                }
            }
            else
            {
                WriteLine("Insufficient arguments.");
            }
        }

        public void cmd_05tray(String[] args)
        {
            if (API.DeveloperMode == true)
            {
                API.AddCodepoints(500);
                WriteLine("You've been granted 500 Codepoints.");
            }
            else
            {
                wrongcommand();
            }
        }

        public void cmd_debug(String[] args)
        {
            if (API.DeveloperMode == true)
            {
                try
                {
                    switch (args[1].ToLower())
                    {
                        case "shiftnet-story":
                            WriteLine("Debugging Shiftnet Story...");
                            StartShiftnetStory();
                            break;
                        case "devmode":
                            API.DeveloperMode = false;
                            WriteLine("Turned off developer mode. Use the passcode to turn it back on.");
                            break;
                        default:
                            WriteLine("Invalid argument: " + args[1] + ". Debug can only debug the following: 'shiftnet-story'.");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    WriteLine("debug: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    switch (args[1].ToLower())
                    {
                        case "developers123":
                            WriteLine("Turned Developer Mode on!");
                            API.DeveloperMode = true;
                            break;
                        default:
                            WriteLine("debug: lp0 is on fire");  // Keeps Cheaters from Flooding The Fourms With "The Debug Mode Doesn't Work"
                            break;
                    }
                }
                catch
                {
                    WriteLine("debug: lp0 is on fire");  // Keeps Cheaters from Flooding The Fourms With "The Debug Mode Doesn't Work"
                }
            }
        }

        public void cmd_echo(String[] args)
        {
            if (command.Contains("echo "))
            {
                WriteLine(command.Replace("echo ", ""));
            }
            else
            {
                WriteLine("echo: Insufficient Parameters.");
            }
        }

        public void cmd_default(String[] args)
        {
            if (API.OpenProgram(args[0]) == false)
            {
                if (API.Upgrades["trmfiles"] == false)
                {
                    bool done = false;
                    foreach (KeyValuePair<string, string> kv in API.CommandAliases)
                    {
                        if (kv.Key == command)
                        {
                            command = kv.Value;
                            done = true;
                            DoCommand();
                        }

                    }
                    if (done == false)
                    {
                        wrongcommand();
                    }
                }
                else
                {
                    var f = command.Replace("\\", "/");
                    if (f.StartsWith("/"))
                    {
                        var withoutslash = f.Remove(0, 1);
                        var dirsep = OSInfo.DirectorySeparator;
                        var proper = $"{Paths.SaveRoot}{dirsep}{withoutslash.Replace("/", dirsep)}";
                        if (File.Exists(proper))
                        {
                            runterminalfile(proper);
                        }
                        else
                        {
                            wrongcommand();
                        }
                    }
                    else
                    {
                        bool done = false;
                        foreach (KeyValuePair<string, string> kv in API.CommandAliases)
                        {
                            if (kv.Key == command)
                            {
                                command = kv.Value;
                                done = true;
                                DoCommand();
                            }

                        }
                        if (done == false)
                        {
                            // Lua Executer By Carver Harrison (@carverh)
                            if (File.Exists("C:\\ShiftOS\\LuaApps\\" + args[0] + ".lua"))
                            {
                                String lp = "C:\\ShiftOS\\LuaApps\\" + args[0] + ".lua";
                                WriteLine(lp);
                                var l = new LuaInterpreter(lp);
                            }
                            else
                            {
                                wrongcommand();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// About Box, Created By Carver Harrison
        /// </summary>
        /// <param name="args">String[] args</param>
        public void cmd_about(String[] args)
        {
            API.CreateInfoboxSession("About ShiftOS", "ShiftOS Version " + ProductVersion + "\n Copyright 2014-2016 ShiftOS Dev Team \n Type 'credits' in Terminal to Show Credits", infobox.InfoboxMode.Info);
        }

        // HISTACOM REFERENCES, DO NOT REMOVE, CRUCIAL FOR SECRET STORY ARC
        public void cmd_histacom_year(String[] args)
        {
            WriteLine("Year: 2002");
        }

        public void cmd_histacom_timedistorter(String[] args)
        {
            WriteLine("Package 'timedistorter' not installed");
        }

        #endregion

        private void StartChoice1EndStory()
        {
            var t = new System.Windows.Forms.Timer();
            int i = 0;
            t.Interval = 4000;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("User '<unknown>' connected as '???'");
                        break;
                    case 1:
                        WriteLine($"???: {API.Username}! What are you doing!?");
                        break;
                    case 2:
                        WriteLine("???: I went onto the Hacker Alliance room earlier and DevX was on there...");
                        break;
                    case 3:
                        WriteLine("???: And he told me you SIDED WITH HIM.");
                        break;
                    case 4:
                        WriteLine("???: This is a HUGE mistake! Listen!");
                        break;
                    case 5:
                        WriteLine("???: He's lying to you. Listen. DevX is not what you think he is.");
                        break;
                    case 6:
                        WriteLine("???: He isn't a human! He's an AI! We were all played!");
                        break;
                    case 7:
                        WriteLine("???: I'm telling the truth, I swear!");
                        break;
                    case 8:
                        WriteLine("???: You want proof? - holochat_cmd: ERROR: Remote host closed connection.");
                        WriteLine("But if he is an AI, who created him?");
                        break;
                    case 9:
                        WriteLine("spkg: Rebooting system in 8 seconds.");
                        break;
                    case 11:
                        API.Upgrades["titlebar"] = false;
                        API.Upgrades["windowedterminal"] = false; //terminals must be fullscreen
                        var trm = new Terminal();
                        this.Close();
                        API.CreateForm(trm, "Terminal", API.GetIcon("Terminal"));
                        trm.StartReboot();
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        public void StartReboot()
        {
            txtterm.Text = "";
            var t1 = new Thread(new ThreadStart(new Action(() =>
            {
                Thread.Sleep(500);
                WriteLine("shift-init: Disconnecting From System Bus...");
                Thread.Sleep(1000);
                this.Invoke(new Action(() =>
                {
                    txtterm.Text = "";
                }));
                Thread.Sleep(1000);
                WriteLine("Welcome to ShiftOS.");
                Thread.Sleep(500);
                WriteLine("Starting core...");
                API.Upgrades["windowedterminal"] = true;
                Thread.Sleep(450);
                WriteLine($"Your username is {API.Username}.");
                Thread.Sleep(100);
                WriteLine($"You have {API.Codepoints} Codepoints.");
                WriteLine("Loading modules...");
                Thread.Sleep(750);
                foreach (var upg in API.Upgrades)
                {
                    if (upg.Value == true)
                    {
                        WriteLine($"Loaded module {upg.Key}...");
                    }
                    Thread.Sleep(100);
                }
                WriteLine("Starting desktop.");
                this.Invoke(new Action(() =>
                {
                    var s = new ShiftOSDesktop();
                    s.Show();
                    s.EndGame_AttachEvents();
                }));
                Thread.Sleep(1000);
                this.Invoke(new Action(() =>
                {
                    FinalMission.EndGameHandler.GoToNextObjective();
                }));
                API.Upgrades["titlebar"] = true;
            })));
            t1.Start();
        }

        public void Crash()
        {
            txtterm.Text = "";
            WriteLine(" *** SYSTEM PANIC *** ");
            WriteLine(Environment.NewLine);
            WriteLine("PANIC_ID: 750_15_4W3S0M3");
            WriteLine("PANIC_DESC: System became too unstable to function properly. In 5 seconds, your session will be resumed.");
            var t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            int p = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                if (p == 4)
                {
                    t.Stop();
                    this.Close();
                }
                p += 1;
            };
            t.Start();
        }

        private void wrongcommand()
        {
            txtterm.Text = txtterm.Text + Environment.NewLine + "Command not recognized - Type 'help' for a list of commands!" + Environment.NewLine;
        }

        bool Hacking = false;

        private Control objToWriteTo = null;
        private string UpgradeToHack = null;

        public void StartHackingSession(string id)
        {
            UpgradeToHack = id;
            objToWriteTo = txtterm;
            Hacking = true;
            txtterm.ReadOnly = true;
            WriteLine("To continue, choose which way you  ");
            WriteLine("would like to go about this.       ");
            WriteLine("                                   ");
            WriteLine("1. Go it alone.                    ");
            WriteLine("2. Hire someone.                   ");
            WriteLine("                                   ");
            WriteLine("Press the key that corresponds to  ");
            WriteLine("the option you want.               ");

        }

        public void showhackinghelp()
        {
            WriteLine(" - Hacking - ");
            WriteLine(Environment.NewLine + "Hacking allows you to gain more features and upgrades by unlocking more of the OS's capabilities.");
            WriteLine(Environment.NewLine + "There are two ways you can execute a hack:");
            WriteLine(" - On your own: It'll take skill, and time, but if you have the correct tools you can do it on your own.");
            WriteLine(" - With a more competent partner: You have the option of employing a partner from a list of various hackers. The speed and success of the hack depends on their skill, and how fast they can pull it off. You will need to pay them a fee of Codepoints however. They can also grant you tools to do it on your own.");
            WriteLine(Environment.NewLine + "Some hacks are capable of:");
            WriteLine(" - Decreasing or increasing the price of Shiftorium Upgrades");
            WriteLine(" - Decreasing or increasing the amount of Codepoints earned by doing various tasks.");
            WriteLine(" - Unlocking more upgrades.");
            WriteLine(Environment.NewLine + "To start a hack, go to a locked or empty Shiftorium category and click the \"Hack It\" button.");
            API.Upgrades["hacking"] = true;
        }

        public void showhelp(string topic)
        {
            switch (topic)
            {
                case "hacking":
                    showhackinghelp();
                    break;
                default:
                    WriteLine("No help available for this topic. Try 'help' for general help.");
                    break;
            }
        }

        public void showhelp()
        {
            listinfo();
            WriteLine(" ");
            listcommands();
            listprograms();
        }

        private void listprograms()
        {
            WriteLine("Programs installed: " + Environment.NewLine);
            WriteLine(" - terminal: A command-line application that lets you run programs in ShiftOS");
            WriteLine(" - shiftorium: An application where you can buy upgrades and new apps using codepoints.");
            /* TEMP-REMOVED - I just can't get it to work.
            WriteLine(" - jumper: A simple 'jump over the obstacle' game.");
            */
            WriteLine(" - knowledge_input: Test your knowledge, and gain some Codepoints too.");
            if (API.Upgrades["shifter"] == true)
                WriteLine(" - shifter: Allows you to customize ShiftOS.");
            if (API.Upgrades["skinning"] == true)
                WriteLine(" - skinloader: Load and save ShiftOS skins.");
            if (API.Upgrades["pong"] == true)
                WriteLine(" - pong: A good ole' game of Pong.");
            if (API.Upgrades["fileskimmer"] == true)
                WriteLine(" - fileskimmer: Browse the files on your computer.");
            if (API.Upgrades["textpad"] == true)
                WriteLine(" - textpad: \"Write, save, and open a text document.\" - Philip Adams");
            if (API.Upgrades["artpad"] == true)
                WriteLine(" - artpad: A simple, but useful drawing application.");
            if (API.Upgrades["shiftnet"] == true)
                WriteLine("Also, more apps can be run by opening .saa files. Apps can also be installed using spkg or by double clicking .pkg or .stp files.");
        }

        public void listcommands()
        {
            WriteLine(" == Commands == " + Environment.NewLine);
            WriteLine(" - clear: Clears the screen.");
            WriteLine(" - shutdown: Shuts down your PC.");
            WriteLine(" - codepoints: Shows how many codepoints you have.");
            WriteLine(" - help: Shows this screen.");
            if (API.Upgrades["secondssincemidnight"] == true)
            {
                WriteLine(" - time: Shows the current time.");
            }
            if (API.Upgrades["unitymode"] == true)
                WriteLine(" - unity: Toggles Unity Mode.");
            if (API.Upgrades["customusername"] == true)
            {
                WriteLine(" - username <new_name>: Changes your username.");
                WriteLine(" - osname <newname>: Changes the operating system name.");
            }
            if (API.Upgrades["shiftnet"] == true)
            {
                WriteLine(" - saa: Runs a specified .saa file.");
                WriteLine(" - spkg: Shiftnet Package Manager (more info at shiftnet://main/spkg");
            }
        }

        public void listinfo()
        {
            WriteLine(SaveSystem.Utilities.LoadedSave.osname + " - Version " + SaveSystem.Utilities.LoadedSave.ingameversion);
            WriteLine("==========================" + Environment.NewLine);
            WriteLine(" == Info == " + Environment.NewLine);
            if (API.Upgrades["applaunchermenu"] == true)
            {
                WriteLine(" - Apps can be run using the App Launcher on the desktop.");
            }
            else
            {
                WriteLine(" - Apps can be run by typing their name in the Terminal.");
            }
            if (API.Upgrades["windowedterminal"] == true)
            {
                WriteLine(" - The Terminal runs in a window.");
            }
            else
            {
                WriteLine(" - The Terminal runs fullscreen at all times.");
            }
            if (API.Upgrades["titlebar"] == true)
            {
                WriteLine(" - Applications have a titlebar to help distinguish between other apps.");
            }
            if (API.Upgrades["windowborders"] == true)
            {
                WriteLine(" - Applications have a window border to help distinguish between other apps.");
            }
            if (API.Upgrades["multitasking"] == true)
            {
                WriteLine(" - Multiple apps can be run at the same time, and you can even run more than one of the same app!");
            }
            if (API.Upgrades["movablewindows"] == true)
            {
                WriteLine(" - Applications can be moved using CTRL+W,A,S,D.");
            }
            if (API.Upgrades["draggablewindows"] == true)
            {
                WriteLine(" - You can drag apps around the screen by dragging their titlebars.");
            }
            if (API.Upgrades["resizablewindows"] == true)
            {
                WriteLine(" - You can resize windows by dragging their borders.");
            }
            if (API.Upgrades["panelbuttons"] == true)
            {
                WriteLine($" - A list of open apps is shown at the {API.CurrentSkin.desktoppanelposition.ToLower()} of the screen.");
            }
            if (API.Upgrades["usefulpanelbuttons"] == true)
            {
                WriteLine(" - You can minimize and restore apps using the panel buttons.");
            }
            if (API.Upgrades["titletext"] == true)
            {
                WriteLine(" - Apps display their names on the titlebar.");
            }
            if (API.Upgrades["appicons"] == true)
            {
                WriteLine(" - Apps display their icons, and they are displayed in their titlebars.");
            }
            if (API.Upgrades["autoscrollterminal"] == true)
            {
                WriteLine(" - The Terminal will automatically scroll to the bottom.");
            }
            if (API.Upgrades["terminalscrollbar"] == true)
            {
                WriteLine(" - You can scroll up and down the Terminal's buffer.");
            }
            if (API.Upgrades["zoomableterminal"] == true)
            {
                WriteLine(" - You can zoom the Terminal in and out by holding CTRL and scrolling up or down.");
            }
        }


        // ERROR: Handles clauses are not supported in C#
        private void tmrfirstrun_Tick(object sender, EventArgs e)
        {
            switch (firstrun)
            {
                case 1:
                    txtterm.Text = txtterm.Text + "Installation Successfull" + Environment.NewLine;
                    blockctrlt = true;
                    break;
                case 2:
                    txtterm.Text = txtterm.Text + "IP 199.108.232.1 Connecting..." + Environment.NewLine + "User@" + SaveSystem.Utilities.LoadedSave.osname + " $> ";
                    API.PlaySound(Properties.Resources.dial_up_modem_02);
                    break;
                case 12:
                    txtterm.Text = txtterm.Text + "IP 199.108.232.1 Connected!" + Environment.NewLine + "User@" + SaveSystem.Utilities.LoadedSave.osname + " $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 15:
                    txtterm.Text = txtterm.Text + "DevX: Hi, my name is DevX and you are now using an early version of my operating system \"ShiftOS\"." + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 22:
                    txtterm.Text = txtterm.Text + "DevX: Currently the terminal is open and I am using it to communicate with you remotely." + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 28:
                    txtterm.Text = txtterm.Text + "DevX: ShiftOS is going to be the most revolutionary operating system in the world that will run on every electronic device you can think of." + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 36:
                    txtterm.Text = txtterm.Text + "DevX: I can't tell you much about my future plans right now but if you can help me then I may tell you more in future" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 44:
                    txtterm.Text = txtterm.Text + "DevX: ShiftOS is barely usable in it's current state so I need you to help me evolve it using codepoints" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 50:
                    txtterm.Text = txtterm.Text + "DevX: Once you acquire codepoints you can use them to upgrade certain components of ShiftOS or add new software" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 59:
                    txtterm.Text = txtterm.Text + "DevX: I'll close the terminal now and send you to the blank ShiftOS desktop" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 65:
                    txtterm.Text = txtterm.Text + "DevX: You can open and close the terminal at any time by pressing CTRL + T" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 70:
                    txtterm.Text = txtterm.Text + "DevX: Once you are on the desktop open the terminal, type \"help\" and then press enter for a guide on using ShiftOS" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 80:
                    txtterm.Text = txtterm.Text + "DevX: Gotta run now but I'll contact you soon to see how you are going with evolving ShiftOS for me while I... Work on something else" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 89:
                    txtterm.Text = txtterm.Text + "DevX: Remember to always click the black desktop first and then press press CTRL + T to open the terminal otherwise the terminal won't open!" + Environment.NewLine + "User@ShiftOS $> ";
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 94:
                    API.PlaySound(Properties.Resources.typesound);
                    txtterm.Text = "User@" + SaveSystem.Utilities.LoadedSave.osname + " $> ";
                    tmrfirstrun.Stop();
                    this.Close();
                    blockctrlt = false;
                    SaveSystem.Utilities.saveGame();
                    break;
            }
            firstrun = firstrun + 1;
            txtterm.SelectionStart = txtterm.TextLength;
        }

        public void runterminalfile(string path)
        {
            if (File.Exists(path))
            {
                string[] cmds = File.ReadAllLines(path);
                foreach (string cmd in cmds)
                {
                    command = cmd;
                    DoCommand();
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrshutdown_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void WriteLine(string text)
        {
            API.CurrentSession.Invoke(new Action(() =>
            {
                if (txtterm.Text.Length > 0)
                {
                    txtterm.Text += Environment.NewLine + text;
                }
                else
                {
                    txtterm.Text += text;
                }
                txtterm.Select(txtterm.TextLength, 0);
                txtterm.ScrollToCaret();
            }));
        }
        private bool Zooming = false;

        private void ScrollDeactivate(object sender, KeyEventArgs e)
        {
            if (Zooming == true)
            {
                Zooming = false;
            }
        }

        private int ZoomMultiplier = 1;

        private void ResetTerminalFont()
        {
            string fname = "Font";
            if (API.Upgrades["setterminalfont"] == true)
            {
                fname = API.CurrentSkin.TerminalFontStyle;
            }
            else
            {
                fname = OSInfo.GetMonospaceFont();
            }
            int fsize = 9 * ZoomMultiplier;
            try
            {
                txtterm.Font = new Font(fname, fsize);
            }
            catch
            {
                txtterm.Font = new Font(fname, 9);
            }
        }

        private void Zoom(object sender, ScrollEventArgs e)
        {

        }

        private void ScrollTerm(object sender, MouseEventArgs e)
        {
            if (Zooming == true)
            {

            }
            else
            {
                if (API.Upgrades["terminalscrollbar"] == true)
                {
                    txtterm.ScrollBars = ScrollBars.Vertical;
                }
            }
        }

        private void tmrsetfont_Tick(object sender, EventArgs e)
        {
            ResetTerminalFont();
            if (API.Upgrades["setterminalcolors"] == true)
            {
                txtterm.BackColor = API.CurrentSkin.TerminalBackColor;
                txtterm.ForeColor = API.CurrentSkin.TerminalTextColor;
            }
        }

        public void ShowTools()
        {
            txtterm.Text = "";
            try
            {
                var h = ShiftOS.Hacking.Tools[SelectedCharacter];
                WriteLine(" == Attack Select ==");
                WriteLine($"Attack: {SelectedCharacter + 1}/{ShiftOS.Hacking.Tools.Count}");
                WriteLine($"Name: {h.Name}");
                WriteLine($"Effectiveness: {h.Effectiveness}");
                WriteLine($"Description: {h.Description}");
                WriteLine(Environment.NewLine + "LEFT: Previous Attack, RIGHT: Next Attack, ENTER: Confirm");
            }
            catch
            {
                WriteLine("There are no entries to display in this list.");
            }
        }

        private void Hack_ShowCharacters()
        {
            switch (SelectedMode)
            {
                case 1:
                    ShiftOS.Hacking.GetCharacters();
                    SelectedCharacter = 0;
                    ShowTools();
                    break;
                case 2:
                    ShiftOS.Hacking.GetCharacters();
                    SelectedCharacter = 0;
                    ShowChar();
                    break;
            }
        }

        private void InstallMidGameDesktop()
        {
            //throw new NotImplementedException();
        }

        int SelectedMode = 0;
        int SelectedCharacter = 0;

        public void ShowChar()
        {
            txtterm.Text = "";
            var h = ShiftOS.Hacking.Characters[SelectedCharacter];
            WriteLine(" == Partner Select ==");
            WriteLine($"Partner: {SelectedCharacter + 1}/{ShiftOS.Hacking.Characters.Count}");
            WriteLine($"Name: {h.Name}");
            WriteLine($"Skill: {h.Skill}/100");
            WriteLine($"Speed: {h.Speed}/100");
            WriteLine($"Cost: {h.Cost}");
            WriteLine($"Bio: {h.Bio}");
            WriteLine(Environment.NewLine + "LEFT: Previous Partner, RIGHT: Next Partner, ENTER: Confirm");
        }

        public void StartShellShock()
        {
            var t = new Thread(new ThreadStart(new Action(() =>
            {
                Thread.Sleep(300);
                WriteLine("Sending false packet to shiftnet://devx/tracker...");
                Thread.Sleep(100);
                WriteLine("Awaiting reply from server...");
                Thread.Sleep(5000);
                WriteLine("Got reply with header \"SOS_TRK_GET\".");
                Thread.Sleep(50);
                WriteLine("[kernel] Sending usage log to server...");
                WriteLine("Intercepting outgoing request...");
                Thread.Sleep(200);
                WriteLine("Got packet contents...");
                Thread.Sleep(25);
                WriteLine("Sifting...");
                Thread.Sleep(500);
                WriteLine("Found connection data for shiftnet://devx/tracker.");
                Thread.Sleep(100);
                WriteLine(@"Username: devx
Password: z7fjsd3");
                Thread.Sleep(100);
                WriteLine("Authenticating with SSH server on shiftnet://devx/tracker running Ubuntu 666...");
                Thread.Sleep(1000);
                WriteLine("[SSH] Access granted.");
                Thread.Sleep(100);
                WriteLine($"[Message] ???: We're in. In about 75 seconds DevX's server will go down. It'll be quite cool actually, Don't know if you've ever seen a forkbomb in action, but because you're in an SSH session with DevX's server and I'm also controlling the same session you're gonna see one. Oh, yeah, this server's the only one of his that doesn't actually run ShiftOS.");
                Thread.Sleep(25000);
                this.Invoke(new Action(() =>
                {
                    txtterm.Text = "";
                }));
                int i = 60;
                while (i >= 1)
                {
                    Thread.Sleep(1000);
                    WriteLine($"Beginning attack on server in {i} seconds.");
                    i -= 1;
                }
                WriteLine("[devx@tracker ~]$ ");
                string cmd = ":`(`)`{` `:`|`:` `&` `}`;`:"; // <sarcasm> yep. I'm pretending to use a forkbomb on DevX's server. This'll be FUN to code. </sarcasm>
                foreach (string c in cmd.Split('`'))
                {
                    Thread.Sleep(100);
                    this.Invoke(new Action(() =>
                    {
                        txtterm.Text += c;
                    }));
                }
                WriteLine("[devx@tracker ~]$ ");
                WriteLine("[Message] ???: Alright. I entered the command for you. Looks like it did nothing. DevX wouldn't even know what's happening... but keep your terminal open for 30 seconds.");
                Thread.Sleep(30000);
                this.Invoke(new Action(() =>
                {
                    FinalMission.EndGameHandler.GoToNextObjective();
                }));
                int progress = 0;
                while (progress <= 10000)
                {
                    int r = new Random().Next(0, 1);
                    switch (r)
                    {
                        case 0:
                            WriteLine("-bash: fork: Resource temporarily unavailable");
                            break;
                        case 1:
                            WriteLine("-bash: fork: retry: Resource temporarily unavailable");
                            break;
                    }
                    Thread.Sleep(progress / 10);
                    progress++;
                }
                WriteLine("[SSH] Connection to server dropped.");
                this.Invoke(new Action(() =>
                {
                    FinalMission.EndGameHandler.GoToNextObjective();
                }));
                this.Invoke(new Action(() => { this.Close(); }));
            })));
            t.Start();
        }

        internal void StartBridgeToMidGame()
        {
            var t2 = new System.Windows.Forms.Timer();
            t2.Interval = 4000;
            int i2 = 0;
            t2.Tick += (object s, EventArgs e) =>
            {
                switch (i2)
                {
                    case 0:
                        if (API.Upgrades["hacker101"] == true)
                        {
                            WriteLine("Hacker101: Hello. We meet again. The Other Player told me about your situation.");
                        }
                        else
                        {
                            API.Upgrades["hacker101"] = true;
                            WriteLine("Hacker101: The Other Player told me about your situation.");
                        }
                        break;
                    case 1:
                        WriteLine("Hacker101: Lemme guess. DevX found out about you having the Shiftnet, didn't he...");
                        break;
                    case 2:
                        WriteLine("Hacker101: Well I guess we'll have to fight fire with fire. You remember that person who told you about Hacker Battles?");
                        break;
                    case 3:
                        WriteLine("Hacker101: It's time you know who he is. He is, in fact, me, and to continue on about Hacker Battles...");
                        break;
                    case 4:
                        WriteLine("Hacker101: I can help you take down DevX, but we'll need to take down his defenses and get into his network.");
                        break;
                    case 5:
                        WriteLine("Hacker101: DevX's network of servers is larger than any datacenter on Earth, and it'll take time to plan the perfect attack.");
                        break;
                    case 6:
                        WriteLine("Hacker101: Think of it this way. DevX has a network of networks, each with their own leader.");
                        break;
                    case 7:
                        WriteLine("Hacker101: I can help you find these networks, but it's up to you to take 'em down.");
                        break;
                    case 8:
                        WriteLine("Hacker101: Of course, it's hard to hack a network if you don't know how to start a battle.");
                        break;
                    case 9:
                        WriteLine("Hacker101: Introducing the Battle Preparation Screen.");
                        break;
                    case 10:
                        WriteLine("Hacker101: It'll show you any network I've found, and it'll tell you some useful info about it.");
                        break;
                    case 11:
                        WriteLine("Hacker101: However the spkg package for this thing is HUGE, and will require lots of tweaks to the ShiftOS desktop. spkg will hopefully administer the tweaks for you, but here's a rundown of what'll happen.");
                        break;
                    case 12:
                        WriteLine("Hacker101: For one, you'll be able to have multiple desktop panels to fit more widgets on them.");
                        break;
                    case 13:
                        WriteLine("Hacker101: And if you have the App Launcher, it will get sorted so it doesn't take up the entire screen when you get so many applications installed.");
                        break;
                    case 14:
                        WriteLine("Hacker101: And the rest is a surprise. I'll initiate the install sequence.");
                        break;
                    case 15:
                        InstallMidGameDesktop();
                        break;
                }
                i2 += 1;
            };

            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;

            t.Tick += (object s, EventArgs a) =>
            {


                switch (i)
                {
                    case 0:
                        WriteLine("IP <hidden> connecting as Hacker101...");
                        break;
                    case 1:
                        WriteLine("Hacker101: Hello, ShiftOS user. I am a hacker.");
                        break;
                    case 2:
                        if (API.BitnoteAddress != null)
                        {
                            WriteLine($"Hacker101: I can prove it. You have {API.Codepoints} Codepoints, your Bitnote Address is {API.BitnoteAddress.Address}, and you have {API.BitnoteAddress.Bitnotes}. That's your private address, by the way.");
                        }
                        else
                        {
                            WriteLine($"Hacker101: I can prove it. You have {API.Codepoints} Codepoints, and you do not have a Bitnote Address.");
                        }
                        break;
                    case 3:
                        WriteLine("Hacker101: Enough fun in games. Listen. There are two things you need to know.");
                        break;
                    case 4:
                        WriteLine("Hacker101: Thing #1. DevX isn't real.");
                        break;
                    case 5:
                        WriteLine("Hacker101: I've decompiled parts of ShiftOS. And you know what I found?");
                        break;
                    case 6:
                        WriteLine("Hacker101: Everything DevX says. Everything he does. Everything he THINKS. It's all hardcoded directly into ShiftOS's core.");
                        break;
                    case 7:
                        WriteLine("Hacker101: Want proof? Here. I'll run a quick Lua script for you.");
                        string DecompiledCode = Properties.Resources.DecompiledCode;
                        var l = new LuaInterpreter();
                        Form win = l.mod.create_window("Decompiled Code", null, 720, 480);
                        TextBox txt = new TextBox();
                        txt.Multiline = true;
                        txt.Text = Properties.Resources.DecompiledCode;
                        txt.BorderStyle = BorderStyle.None;
                        txt.BackColor = Color.Black;
                        txt.ForeColor = Color.White;
                        txt.Font = new Font(OSInfo.GetMonospaceFont(), 9);
                        l.mod.set_dock(txt, "fill");
                        l.mod.add_widget_to_window(win, txt);
                        break;
                    case 8:
                        WriteLine("Hacker101: Not only is that some nice, smokin' fresh C# code directly from ShiftOS, but that's a nice steaming pile of bird poop on DevX's doorstep.");
                        break;
                    case 9:
                        WriteLine("Hacker101: Thing #2. The Shiftnet holds some secrets.");
                        break;
                    case 10:
                        WriteLine("Hacker101: What kind of secrets, I hear you ask through your microphone (jesus, do you seriously talk to us with your voice? Are you that bored?)");
                        break;
                    case 11:
                        WriteLine("Hacker101: Well. I'm talking, pieces of a Lua script that could help stop DevX dead in his digital tracks.");
                        break;
                    case 12:
                        WriteLine("Hacker101: All you gotta do is use my decryption utilities to find the pieces of this encrypted script, download them, decrypt them, and the utility will automatically piece them together for you.");
                        break;
                    case 13:
                        WriteLine("Hacker101: Shiftnet pages ending with .enc are your best bet.");
                        break;
                    case 14:
                        WriteLine("Hacker101: You can install the utilities using spkg install secret.");
                        break;
                    case 15:
                        WriteLine("Hacker101: Then, when the application installs, run it, and use the password 'binary_hell' to install the REAL utilities.");
                        break;
                    case 16:
                        WriteLine("Hacker101: Anyways, that wraps that up. But hang on. One more thing...");
                        t.Stop();
                        ShiftOS.Hacking.AddCharacter(new Character("Hacker101", "Let's get the job done.", 75, 45, 5));
                        t2.Start();
                        break;
                }
                i += 1;
            };
            if (API.Upgrades["hacker101"] == true)
            {
                t2.Start();
            }
            else
            {
                t.Start();
            }


        }

        internal void StartAidenNirhStory()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("User 151.43.85.33 connecting as \"Aiden\"...");
                        break;
                    case 2:
                        WriteLine($"Aiden: Hey there, {API.Username}1 I'm Aiden Nirh.");
                        break;
                    case 3:
                        WriteLine("Aiden: Have you seen Appscape?");
                        break;
                    case 4:
                        WriteLine("Aiden: It's my package manager for ShiftOS. It's pretty neat.");
                        break;
                    case 5:
                        WriteLine("Aiden: You should check it out, it's on the Shiftnet at shiftnet://main/appscape!");
                        break;
                    case 6:
                        WriteLine("Aiden: But remember, when browsing the Shiftnet try not to venture from the main server!");
                        break;
                    case 7:
                        API.Upgrades["aidennirh"] = true;
                        t.Stop();
                        this.Close();
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        internal void StartHacker101Story()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;

            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("IP <hidden> connecting as Hacker101...");
                        break;
                    case 1:
                        WriteLine("Hacker101: Hello, ShiftOS user. I am a hacker.");
                        break;
                    case 2:
                        if (API.BitnoteAddress != null)
                        {
                            WriteLine($"Hacker101: I can prove it. You have {API.Codepoints} Codepoints, your Bitnote Address is {API.BitnoteAddress.Address}, and you have {API.BitnoteAddress.Bitnotes}. That's your private address, by the way.");
                        }
                        else
                        {
                            WriteLine($"Hacker101: I can prove it. You have {API.Codepoints} Codepoints, and you do not have a Bitnote Address.");
                        }
                        break;
                    case 3:
                        WriteLine("Hacker101: Enough fun in games. Listen. There are two things you need to know.");
                        break;
                    case 4:
                        WriteLine("Hacker101: Thing #1. DevX isn't real.");
                        break;
                    case 5:
                        WriteLine("Hacker101: I've decompiled parts of ShiftOS. And you know what I found?");
                        break;
                    case 6:
                        WriteLine("Hacker101: Everything DevX says. Everything he does. Everything he THINKS. It's all hardcoded directly into ShiftOS's core.");
                        break;
                    case 7:
                        WriteLine("Hacker101: Want proof? Here. I'll run a quick Lua script for you.");
                        string DecompiledCode = Properties.Resources.DecompiledCode;
                        var l = new LuaInterpreter();
                        Form win = l.mod.create_window("Decompiled Code", null, 720, 480);
                        TextBox txt = new TextBox();
                        txt.Multiline = true;
                        txt.Text = Properties.Resources.DecompiledCode;
                        txt.BorderStyle = BorderStyle.None;
                        txt.BackColor = Color.Black;
                        txt.ForeColor = Color.White;
                        txt.Font = new Font(OSInfo.GetMonospaceFont(), 9);
                        l.mod.set_dock(txt, "fill");
                        l.mod.add_widget_to_window(win, txt);
                        break;
                    case 8:
                        WriteLine("Hacker101: Not only is that some nice, smokin' fresh C# code directly from ShiftOS, but that's a nice steaming pile of bird poop on DevX's doorstep.");
                        break;
                    case 9:
                        WriteLine("Hacker101: Thing #2. The Shiftnet holds some secrets.");
                        break;
                    case 10:
                        WriteLine("Hacker101: What kind of secrets, I hear you ask through your microphone (jesus, do you seriously talk to us with your voice? Are you that bored?)");
                        break;
                    case 11:
                        WriteLine("Hacker101: Well. I'm talking, pieces of a Lua script that could help stop DevX dead in his digital tracks.");
                        break;
                    case 12:
                        WriteLine("Hacker101: All you gotta do is use my decryption utilities to find the pieces of this encrypted script, download them, decrypt them, and the utility will automatically piece them together for you.");
                        break;
                    case 13:
                        WriteLine("Hacker101: Shiftnet pages ending with .enc are your best bet.");
                        break;
                    case 14:
                        WriteLine("Hacker101: You can install the utilities using spkg install secret.");
                        break;
                    case 15:
                        WriteLine("Hacker101: Then, when the application installs, run it, and use the password 'binary_hell' to install the REAL utilities.");
                        break;
                    case 16:
                        WriteLine("Hacker101: Now go. We need that script. I know a friend who will help you get your hard drive back from DevX if you can do this.");
                        t.Stop();
                        ShiftOS.Hacking.AddCharacter(new Character("Hacker101", "Let's get the job done.", 75, 45, 5));
                        API.Upgrades["hacker101"] = true;
                        this.Close();
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        internal void StartOtherPlayerSysFix()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("User <hidden> connected as ???.");
                        break;
                    case 1:
                        if (API.Upgrades["otherplayerstory"] == true)
                        {
                            WriteLine($"???: {API.Username}! Did he find out? Oh God, I hope he can see this...");
                        }
                        else
                        {
                            WriteLine("???: Hello? Uhhhh, is this stupid thing working?");
                        }
                        break;
                    case 2:
                        if (API.Upgrades["otherplayerstory"] == true)
                        {
                            WriteLine("???: Ahh. Good. You can read this. It's me, the other player.");
                        }
                        else
                        {
                            WriteLine("???: Thank heaven. You can hear me. Don't ask who I am.");
                        }
                        break;
                    case 3:
                        WriteLine("???: Looks like DevX hit you hard. Guess he found out you had the Shiftnet.");
                        break;
                    case 4:
                        WriteLine("???: Relax. It's not your fault.");
                        break;
                    case 5:
                        WriteLine("???: Actually, the Shiftnet regularly sends data about it's usage, unencrypted, directly to DevX.");
                        break;
                    case 6:
                        WriteLine("???: This code seems to be embedded into all .saa files. It's actually how I found out about you.");
                        break;
                    case 7:
                        WriteLine("???: It seems weird, I know, but everytime you run a .saa file, an uplink is made to DevX's servers");
                        break;
                    case 8:
                        if (API.Upgrades["otherplayerstory"] == true)
                        {
                            WriteLine("???: And, well, I think we could use this. I'll see if Hacker101 can track this uplink. If he can, you will know it the next time you run a .saa.");
                        }
                        else
                        {
                            WriteLine("???: And, well, I think we could use this. I have a friend who's good with his hacking skills. I'll see if he can help you stop DevX dead. If he can, he will contact you next time you run a .saa.");
                        }
                        break;
                    case 9:
                        WriteLine("???: Anyways, connected to your system, I can see your desktop. Looks pretty messed up, huh?");
                        break;
                    case 10:
                        WriteLine("???: You're lucky you don't have the Windows Everywhere virus.");
                        break;
                    case 11:
                        Viruses.InfectFile(Paths.Drivers + "Keyboard.dri", Viruses.VirusID.WindowsEverywhere);
                        Viruses.CheckForInfected();
                        WriteLine("???: Crap! I spoke too soon.");
                        break;
                    case 12:
                        WriteLine("???: Alright. I'll see if I can hijack your Shiftorium Registry, install a virus scanner, and get rid of the viruses.");
                        break;
                    case 13:
                        API.Upgrades["virusscanner"] = true;
                        var trm = new Terminal();
                        API.CreateForm(trm, API.LoadedNames.TerminalName, Properties.Resources.iconTerminal);
                        trm.command = "vscan";
                        trm.DoCommand();
                        break;
                    case 14:
                        WriteLine("???: All better. I hope. As for those random files on your desktop, well, it seems DevX dropped some sort of secret message onto your system.");
                        break;
                    case 15:
                        WriteLine("???: Go ahead and try to decrypt it. The Shiftnet Lua API is very useful.");
                        break;
                    case 16:
                        if (API.Upgrades["otherplayerstory"] == true)
                        {
                            WriteLine("???: Anyways, I'm gonna go work with Hacker101, discuss those .saa uplinks, and see if we can come up with a suitable attack plan.");
                        }
                        else
                        {
                            WriteLine("???: Well, your system is all better. You don't have to thank me. Just, when you open a .saa file, I'll try to contact you if I'm not busy.");
                        }
                        break;
                    case 17:
                        WriteLine("???: Talk to you soon. And, remember. ShiftOS is like a forest. DevX is the predator, you are the prey. Watch your back.");
                        break;
                    case 18:
                        t.Stop();
                        this.Close();
                        API.Upgrades["otherplayerrescue"] = true;
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        internal void StartHackerBattleIntro()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        API.Upgrades["hackerbattles"] = true;
                        API.Upgrades["hackcommand"] = true;
                        WriteLine("IP address <unidentified> connecting with no identity...");
                        break;
                    case 1:
                        WriteLine("Hey there. So I see you're into hacking.");
                        break;
                    case 2:
                        WriteLine("Oh, how rude of me. You don't know if I'm DevX or not.");
                        break;
                    case 3:
                        WriteLine("Well now you do. I will not show my identity, but I am not DevX.");
                        break;
                    case 4:
                        WriteLine("Anyways. There are two things you must know about hacking within ShiftOS.");
                        break;
                    case 5:
                        WriteLine("1. You can hack more than just the Shiftorium. Look around the user interface for any 'Hack it' buttons.");
                        break;
                    case 6:
                        WriteLine("Also, running 'hack' in the Terminal will let you do even more damage to DevX's security systems as well as give you some advantages.");
                        break;
                    case 7:
                        WriteLine("Ever wanted to make the Shiftorium have a bit of a sale, or even better, make all applications pay out more Codepoints than DevX intends?");
                        break;
                    case 8:
                        WriteLine("Well that 'hack' command is useful then. Go ahead. Try it in another Terminal window. But good God do not close this one.");
                        break;
                    case 9:
                        WriteLine("Because there's one more thing you need to know.");
                        break;
                    case 10:
                        WriteLine("You are not the only person DevX has contacted with ShiftOS.");
                        break;
                    case 11:
                        WriteLine("There are others. Some of them, friendly. Some of them, knowledgable enough to help you.");
                        break;
                    case 12:
                        WriteLine("ShiftOS is like a private community. Anyone can contact anyone provided they have the skill to get in.");
                        break;
                    case 13:
                        WriteLine("Meaning, you may meet some very cool people.");
                        break;
                    case 14:
                        WriteLine("But some of us are... how do you say it... hostile.");
                        break;
                    case 15:
                        WriteLine("Enter the era of Hacker Battles.");
                        break;
                    case 16:
                        WriteLine("It's a network-vs-network every-man-for-himself affair. You'll meet criminals, hackers, agencies and much more.");
                        break;
                    case 17:
                        WriteLine("All offering a little surprise if you can take their network down.");
                        break;
                    case 18:
                        WriteLine("And it's best you get trained, for at any time, anyone could challenge you to one.");
                        break;
                    case 19:
                        WriteLine("And the amount of networks devastated due to untrained users picking a fight with the wrong person is alarmingly huge.");
                        break;
                    case 20:
                        WriteLine("I'll launch a practice program which will teach you the Hacker Battle interface and the fundamentals.");
                        break;
                    case 21:
                        WriteLine("And if you can complete the entire training session, you will be able to defend against anyone who dare battle you.");
                        break;
                    case 22:
                        WriteLine("Starting training session #53D8G in 5 seconds....");
                        break;
                    case 23:
                        WriteLine("Don't worry. It shouldn't be too difficult for you.");
                        t.Stop();
                        ShiftOS.Hacking.StartBattleTutorial();
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        internal void StartDevXFuriousStory()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("IP 199.108.232.1 Connecting...");
                        break;
                    case 1:
                        WriteLine("DevX: WHAT HAVE YOU DONE?");
                        break;
                    case 2:
                        WriteLine("DevX: How the HELL did you get the Shiftnet?");
                        break;
                    case 3:
                        WriteLine("DevX: What sites have you seen? TALK TO ME.");
                        break;
                    case 4:
                        WriteLine("DevX: Alright, got nothing to say? Fine. You will pay for this...");
                        break;
                    case 5:
                        WriteLine("DevX: I don't know what I'll do... I don't know when I'll do it... but you will wish you never touched a computer in your life...");
                        break;
                    case 6:
                        t.Stop();
                        Viruses.DropDevXPayload();
                        this.Close();
                        var trm = new Terminal();
                        API.CreateForm(trm, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
                        trm.StartDevXFuriousStory2();
                        break;
                }
                i += 1;
            };
            t.Start();
        }

        private void StartDevXFuriousStory2()
        {
            var t = new Thread(new ThreadStart(new Action(() =>
            {
                WriteLine("User '???' connecting...");
                API.PlaySound(Properties.Resources.dial_up_modem_02);
                WriteLine("???: Hello? Ummm... this is awkward...");
                BeepSleep(3000);
                WriteLine("???: Listen - I'm a hacker. Well, not really. I'm friends with one.");
                BeepSleep(3000);
                WriteLine("???: Seems like DevX completely obliterated your system with one of his viruses.");
                BeepSleep(2500);
                WriteLine("???: I'll fix that for you.");
                API.Upgrades["virusscanner"] = true;
                this.Invoke(new Action(() =>
                {
                    this.command = "vscan";
                    this.DoCommand();
                }));
                BeepSleep(1000);
                WriteLine("???: Better? Cool. Now, I need your help.");
                BeepSleep(1250);
                WriteLine("???: I can't reveal my identity yet - but I co-own this chat-room...");
                BeepSleep(1175);
                WriteLine("???: It's called the 'Hacker Alliance'.");
                BeepSleep(1000);
                WriteLine("???: I'm going to install something called 'HoloChat' on your system. It'll be quick.");
                BeepSleep(2000);
                WriteLine("Installing HoloChat...");
                API.Upgrades["holochat"] = true;
                Thread.Sleep(100);
                WriteLine("Done. Resetting desktop...");
                this.Invoke(new Action(() => { API.CurrentSession.SetupDesktop(); }));
                WriteLine("Done.");
                Thread.Sleep(3000);
                WriteLine("???: Alright - I'll talk to you soon. Just join that chat room when you're ready.");
                BeepSleep(1000);
                this.Invoke(new Action(() =>
                {
                    this.Close();
                }));
            })));
            t.Start();
        }
        public void StartOtherPlayerStory()
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 4000;
            int i = 0;
            t.Tick += (object s, EventArgs a) =>
            {
                switch (i)
                {
                    case 0:
                        WriteLine("IP Address <hidden> is connecting as '???'...");
                        break;
                    case 1:
                        WriteLine("Connection established.");
                        break;
                    case 2:
                        WriteLine("???: Hi, ShiftOS user. I have something to tell you.");
                        break;
                    case 3:
                        WriteLine("???: I'm not a hacker. I'm not a programmer. I am just like you.");
                        break;
                    case 4:
                        WriteLine("???: I am... the Other Player.");
                        break;
                    case 5:
                        WriteLine("???: I too have heard DevX's story about ShiftOS being an experimental operating system.");
                        break;
                    case 6:
                        WriteLine("???: I have also met another user. We'll call him... I don't know... Robert.");
                        break;
                    case 7:
                        WriteLine("???: And this Robert guy, well, he knows a lot about ShiftOS, and DevX.");
                        break;
                    case 8:
                        WriteLine("???: Robert is a fake name I'm calling him. You might know him as Hacker101.");
                        break;
                    case 9:
                        WriteLine("???: Anyways, He told me about you, so I figured I would help you get out of this mess.");
                        break;
                    case 10:
                        WriteLine("???: He said he'll help me get my hard drive back, and get ShiftOS off my system. Once he does, I'll tell you.");
                        break;
                    case 11:
                        WriteLine("???: In the meantime, I have one word for you. Survive. Do NOT let DevX get to you. Do not fall for his tricks. Just play along until I contact you.");
                        break;
                    case 12:
                        WriteLine("???: I'll talk to you about this soon.");
                        break;
                    case 13:
                        t.Stop();
                        this.Close();
                        API.Upgrades["otherplayerstory1"] = true;
                        break;
                }
                i += 1;
            };
            t.Start();
        }
    }
}
