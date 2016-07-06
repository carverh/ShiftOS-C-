using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaveSystem;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using ShiftOS.FinalMission;

namespace ShiftOS
{
    public partial class ShiftOSDesktop : Form
    {
        public ShiftOSDesktop()
        {
            InitializeComponent();
        }

        //Event handler with no arguments.
        public delegate void EmptyEventHandler();

        //Event handler that passes a List<T>
        public delegate void ListEventHandler<T>(List<T> lst);

        //Window draw event handler.
        public delegate void WindowDrawEventHandler(Form win);

        //Event handler for passing a single control (e.g, a desktop panel) to the Lua API.
        public delegate void ControlDrawEventHandler(string ControlGUID);

        //Lua events.
        public event EmptyEventHandler OnDesktopReload;
        public event ListEventHandler<ApplauncherItem> OnAppLauncherPopulate;
        public event ListEventHandler<PanelButton> OnPanelButtonPopulate;
        public event EmptyEventHandler OnClockSkin;
        public event EmptyEventHandler CtrlTPressed;
        public event EmptyEventHandler OnUnityCheck;
        public event WindowDrawEventHandler WindowOpened;
        public event WindowDrawEventHandler WindowClosed;
        public event WindowDrawEventHandler WindowSkinReset;
        public event WindowDrawEventHandler TitlebarReset;
        public event WindowDrawEventHandler BorderReset;
        public event ListEventHandler<DesktopIcon> DesktopIconsPopulated;
        public event EmptyEventHandler OnUnityToggle;
        public event ControlDrawEventHandler OnDesktopPanelDraw;

        public void InvokeWindowOp(string operation, Form win)
        {
            switch(operation)
            {
                case "open":
                    WindowOpened?.Invoke(win);
                    break;
                case "close":
                    WindowClosed?.Invoke(win);
                    break;
                case "tbar_redraw":
                    TitlebarReset?.Invoke(win);
                    break;
                case "brdr_redraw":
                    BorderReset?.Invoke(win);
                    break;
                case "redraw":
                    WindowSkinReset?.Invoke(win);
                    break;
            }
        }

        public void AllowCtrlTIntercept()
        {
            _resetCtrlTEvent();
            CtrlTLuaIntercept = true;
        }

        public void DisableCtrlTIntercept()
        {
            _resetCtrlTEvent();
            CtrlTLuaIntercept = false;
        }


        private void _resetCtrlTEvent()
        {
            CtrlTPressed = null;
        }

        private bool CtrlTLuaIntercept = false;

        public bool UnityEnabled = false;

        public ToolStripMenuItem AppLauncher { get { return this.ApplicationsToolStripMenuItem; } }

        public List<Control> CurrentWidgets = null;

        public void SetUnityMode()
        {
            if (UnityEnabled == true)
            {
                UnityEnabled = false;
            }
            else
            {
                UnityEnabled = true;
            }
            OnUnityToggle?.Invoke(); //We want this to be invoked BEFORE the desktop reset in case the user wants to do things with the desktop during reset.
            SetupDesktop();
            
        }

        public void SetUnityMode(bool value)
        {
            UnityEnabled = value;
            SetupDesktop();
        }

        public void EndGame_AttachEvents()
        {
            FinalMission.EndGameHandler.ObjectiveCompleted += (object s, EventArgs a) =>
            {
            };
            FinalMission.EndGameHandler.MissionComplete += (object s, EventArgs a) =>
            {
                API.LimitedMode = false;
                SetupDesktop();
                API.CloseEverything();
                switch (FinalMission.EndGameHandler.CurrentChoice)
                {
                    case Choice.SideWithDevX:
                        var t = new System.Windows.Forms.Timer();
                        t.Interval = 10000;
                        t.Tick += (object se, EventArgs ea) =>
                        {
                            var tp = new TextPad();
                            API.CreateForm(tp, API.LoadedNames.TextpadName, API.GetIcon("TextPad"));
                            tp.txtuserinput.Text = Properties.Resources.You_Passed;
                            tp.FormClosing += (sen, args) =>
                            {
                                API.Upgrades["storycomplete"] = true;
                            };
                            t.Stop();
                        };
                        t.Start();
                        break;
                }
            };
        }

        

        public void InvokeCTRLT()
        {
            if (CtrlTLuaIntercept == true)
            {
                CtrlTPressed?.Invoke();
            }
            else
            {
                //Show terminal on CTRL+T

                API.CreateForm(new Terminal(), API.CurrentSave.TerminalName, Properties.Resources.iconTerminal);
            }
        }

        private void ShiftOSDesktop_Load(object sender, EventArgs e)
        {
            Viruses.CheckForInfected();
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += (object s, KeyEventArgs ea) =>
            {
                if (ea.KeyCode == Keys.T && ea.Control)
                {
                    InvokeCTRLT();
                }
                else if (ea.KeyCode == Keys.D && ea.Control)
                {
                    if (API.DeveloperMode == true)
                    {
                        if (ShowDebug == true)
                        {
                            ShowDebug = false;
                        }
                        else
                        {
                            ShowDebug = true;
                        }
                    }
                }
            };
            CheckIfNew();

            API.CurrentSession = this;


            System.Windows.Forms.Timer clocktick = new System.Windows.Forms.Timer();
            clocktick.Interval = 2;
            clocktick.Tick += (object s, EventArgs a) =>
            {
                if (API.Upgrades["hacking"])
                {
                    if (API.Upgrades["hackerbattles"] == false)
                    {
                        var rnd = new Random();
                        int c = rnd.Next(1, 1000);
                        if (c == 500)
                        {
                            var t = new Terminal();
                            API.CreateForm(t, API.LoadedNames.TerminalName, Properties.Resources.iconTerminal);
                            t.StartHackerBattleIntro();
                        }
                    }
                }
                paneltimetext.Text = API.GetTime();
                if (ShowDebug == true)
                {
                    lbldebug.Show();
                    lblog.Show();
                    switch (API.CurrentSkin.desktoppanelposition)
                    {
                        case "Top":
                            lbldebug.Location = new Point(5, this.Height - lbldebug.Height - 3);
                            lblog.Location = new Point(this.Width - lblog.Width - 5, this.Height - lblog.Height - 3);
                            break;
                        case "Bottom":
                            lbldebug.Location = new Point(5, 4);
                            lblog.Location = new Point(this.Width - lblog.Width - 5, 4);
                            break;
                    }
                    if (File.Exists(Paths.SystemDir + "_Log.txt"))
                    {
                        lblog.Text = File.ReadAllText(Paths.SystemDir + "_Log.txt");
                    }
                    else
                    {
                        lblog.Hide();
                    }
                    lbldebug.Text = " === DEBUG INFO === \n";
                    lbldebug.Text += "ShiftOS Version: " + API.CurrentSave.actualshiftversion + "\n";
                    lbldebug.Text += "Save Dir On Disk: " + Paths.SaveRoot + "\n";
                    lbldebug.Text += "Codepoints: " + API.CurrentSave.codepoints.ToString() + "\n";
                    lbldebug.Text += "DevMode: " + API.DeveloperMode.ToString() + "\n";
                    lbldebug.Text += "PlatformIdent: " + OSInfo.GetPlatformID() + "\n";
                    lbldebug.Text += "Running Mods: " + API.RunningModProcesses.Count.ToString() + "\n";
                }
                else
                {
                    lbldebug.Hide();
                    lblog.Hide();
                }
                if (Viruses.InfectedWith("seized"))
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 255);
                    int g = rnd.Next(0, 255);
                    int b = rnd.Next(0, 255);
                    this.BackColor = Color.FromArgb(r, g, b);
                    this.BackgroundImage = null;
                }
                if (Viruses.InfectedWith("ow"))
                {
                    Random rand = new Random();
                    switch (rand.Next(0, 3)) {
                        case 0:
                            API.PlaySound(Properties.Resources.writesound);
                            break;
                        case 1:
                            API.PlaySound(Properties.Resources.typesound);
                            break;
                        case 2:
                            API.PlaySound(Properties.Resources.infobox);
                            break;
                    }
                }
            };
            clocktick.Start();

            if (API.Upgrades["trmfiles"] == true)
            {
                if (File.Exists(Paths.SystemDir + "AutoStart.trm"))
                {
                    var t = new Terminal();
                    t.runterminalfile(Paths.SystemDir + "AutoStart.trm");
                }
            }
            API.LoadAliases();
        }

        public void CheckIfNew()
        {
            if (Utilities.LoadedSave.newgame == true)
            {
                HijackScreen hijack = new HijackScreen();
                this.Opacity = 0;
                hijack.Show();
            }
            else
            {
                SetupDesktop();
            }
        }

        public List<Panel> DesktopPanels = null;
        public FlowLayoutPanel PanelButtonHolder { get { return pnlpanelbuttonholder; } }
        public Panel AppLauncherPanel { get { return applaunchermenuholder; } }
        public Panel Clock { get { return timepanel; } }
        public Control SelectedObject = null;

        private string SelectedIconName = null;

        public void SetupDesktop()
        {
            SetupRenderers();
            SetupDesktopPanel();
            SetupAppLauncher();
            SetupDesktopIcons();
            SetupGNOME2Elements();
            SetupPanelClock();
            SetupPanelButtons();
            CheckUnity();
            SetupWidgets();
            CheckForChristmas();
            //Set up the context menus.
            addDesktopPanelToolStripMenuItem.Visible = API.Upgrades["advanceddesktop"];
            widgetManagerToolStripMenuItem.Visible = API.Upgrades["advanceddesktop"];
            if (API.Upgrades["advanceddesktop"])
            {
                AppLauncherPanel.ContextMenuStrip = cbwidget;
                Clock.ContextMenuStrip = cbwidget;
                PanelButtonHolder.ContextMenuStrip = cbwidget;
            }
            else
            {
                AppLauncherPanel.ContextMenuStrip = null;
                Clock.ContextMenuStrip = null;
                PanelButtonHolder.ContextMenuStrip = null;
            }
            if (DesktopPanels != null) {
                foreach (var dp in DesktopPanels)
                {
                    if (API.Upgrades["advanceddesktop"])
                    {
                        dp.ContextMenuStrip = cbdpanel;
                    }
                    else
                    {
                        dp.ContextMenuStrip = cbdpanel;
                    }
                }
            }
            OnDesktopReload?.Invoke();
        }

        public void SetupWidgets()
        {
            foreach (var w in API.CurrentSkin.Widgets)
            {
                foreach (var dp in DesktopPanels)
                {
                    var t = (Skinning.DesktopPanel)dp.Tag;
                    if (t.Position == w.Panel)
                    {
                        SetupWidget(dp, w);
                    }
                }
            }
        }
    
        public void SetupWidget(Panel p, Skinning.DesktopWidget w)
        {
            if(WidgetsToMaintain != null)
            {
                foreach(var wid in WidgetsToMaintain)
                {
                    wid.Dispose();
                }
            }
            WidgetsToMaintain = new List<Control>();
            Control ctrl = null;
            switch(w.Type)
            {
                case WidgetType.FreePanel:
                    ctrl = new Panel();
                    break;
                case WidgetType.Icon:
                    ctrl = new PictureBox();
                    break;
                case WidgetType.DisplayText:
                    ctrl = new Label();
                    var l = (Label)ctrl;
                    l.ForeColor = API.CurrentSkin.clocktextcolour;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    break;
            }
            if(ctrl != null)
            {
                p.Controls.Add(ctrl);
                ctrl.Show();
                ctrl.BringToFront();
                ctrl.Left = w.XLocation;
                if(w.Type != WidgetType.Icon)
                {
                    ctrl.Top = 0;
                    ctrl.Width = w.Width;
                    ctrl.Height = p.Height;
                }
                else
                {
                    ctrl.Size = new Size(16, 16);
                    ctrl.Top = (p.Height - ctrl.Height) / 2;
                }
                try
                {
                    GC.Collect();
                    var l = new LuaInterpreter();
                    l.ThisDirectory = Paths.WidgetFiles;
                    l.mod(w.Lua);
                    if (w.Type == WidgetType.Icon)
                    {
                        try
                        {
                            ctrl.BackgroundImage = API.GetIcon(w.Icon);
                        }
                        catch
                        {
                            ctrl.BackgroundImage = API.GetIcon(w.Name);
                        }
                    }
                    var cb_thiswidget = new ContextMenuStrip();
                    var remove = cb_thiswidget.Items.Add($"Remove this {w.Name}");
                    remove.Click += (object s, EventArgs a) =>
                    {
                        API.CurrentSkin.Widgets.Remove(w);
                        ctrl.Dispose();
                        Skinning.Utilities.saveskin();
                    };
                    var move = cb_thiswidget.Items.Add("Move Widget");
                    move.Click += (object s, EventArgs e) =>
                    {
                        ctrl.Tag = w;
                        MovingControl = ctrl;
                    };
                    ToolStripMenuItem move_to = (ToolStripMenuItem)cb_thiswidget.Items.Add("Move to...");
                    foreach(var dp in DesktopPanels)
                    {
                        var tag = (Skinning.DesktopPanel)dp.Tag;
                        var pnlloc = move_to.DropDownItems.Add(tag.Position);
                        pnlloc.Click += (object s, EventArgs a) =>
                        {
                            w.Panel = pnlloc.Text;
                            ChangePosition(ctrl, dp);
                            Skinning.Utilities.saveskin();
                        };
                    }
                    var setwidth = cb_thiswidget.Items.Add("Set Width");
                    setwidth.Click += (object s, EventArgs a) =>
                    {
                        API.CreateInfoboxSession($"Set {w.Name} Width", $"Please enter a new width value for this {w.Name}.", infobox.InfoboxMode.TextEntry);
                        API.InfoboxSession.FormClosing += (object f, FormClosingEventArgs fc) =>
                        {
                            var text = API.GetInfoboxResult();
                            try
                            {
                                w.Width = Convert.ToInt32(text);
                                ctrl.Width = w.Width;
                                Skinning.Utilities.saveskin();
                            }
                            catch
                            {
                                AddNotification("Invalid width", "You have entered an invalid width.");
                            }
                        };
                    };
                    ctrl.ContextMenuStrip = cb_thiswidget;
                    GC.Collect();
                    WidgetsToMaintain.Add(ctrl);
                    l.mod.widget(ctrl);
                    
                }
                catch
                {
                    API.CreateInfoboxSession("Widget Error", $"An error has occurred creating this \"{w.Name}\". It'll stay, but it may not function as intended.", infobox.InfoboxMode.Info);
                }

            }

        }

        public List<Control> WidgetsToMaintain = null;

        public Control MovingControl = null;

        public bool WidgetContains(string Name)
        {
            Skinning.DesktopWidget widget = null;

            foreach(var w in API.CurrentSkin.Widgets)
            {
                if(w.Name == Name)
                {
                    widget = w;
                }
            }

            if(widget == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetupDesktopIcons()
        {
            if (UnityEnabled == true)
            {
                flicons.Hide();
            }
            else
            {
                flicons.Show();
            }
            if (API.Upgrades["desktopicons"] == true)
            {
                flicons.ContextMenuStrip = cmbdesktopoptions;
                DesktopIconManager.GetIcons();
                   flicons.Controls.Clear();
                foreach (DesktopIcon dl in DesktopIconManager.Icons)
                {
                    dl.ContextMenuStrip = cmbfactions;
                    dl.MouseDown += (object s, MouseEventArgs a) =>
                    {
                        if (a.Button == MouseButtons.Right)
                        {
                            SelectedIconName = dl.IconName;
                        }
                    };
                    flicons.Controls.Add(dl);
                }
                DesktopIconsPopulated?.Invoke(DesktopIconManager.Icons);
            }

        }

        public void SetupRenderers()
        {
            //Set global ToolStrip Renderer to the ShiftOS Skinning Engine renderer with it's default color table
            ToolStripManager.Renderer = new Skinning.MyToolStripRenderer();
            //Set the App Launcher's renderer to the ShiftOS Skinning Engine renderer, with the App Launcher-specific color table.
            desktopappmenu.Renderer = new Skinning.MyToolStripRenderer(new AppLauncherColorTable());

        }


        public void SetupDesktopPanel()
        {
            if (DesktopPanels != null)
            {
                foreach (var pnl in DesktopPanels)
                {
                    if (this.Controls.Contains(pnl))
                    {
                        pnl.Hide();
                        this.Controls.Remove(pnl);
                    }
                }
            }
            var old_list = new List<Skinning.DesktopPanel>();
            var dp = new Skinning.DesktopPanel();
            dp.Position = API.CurrentSkin.desktoppanelposition;
            dp.Height = API.CurrentSkin.desktoppanelheight;
            dp.BackgroundColor = API.CurrentSkin.desktoppanelcolour;
            dp.BackgroundImage = API.CurrentSkinImages.desktoppanel;
            old_list.Add(dp);

            if (API.CurrentSkin.DesktopPanels.Count == 0)
            {
                API.CurrentSkin.DesktopPanels = old_list;
            }
            if(API.Upgrades["advanceddesktop"])
            {
                SetupPanels(API.CurrentSkin.DesktopPanels);
            }
            else
            {
                if(API.Upgrades["desktoppanel"])
                {
                    SetupPanels(old_list);
                }
            }
            desktopappmenu.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.applauncherlayout;
        }

        public void SetupPanels(List<Skinning.DesktopPanel> lst)
        {
            DesktopPanels = new List<Panel>();
            API.DEF_PanelGUIDs.Clear();
            foreach (var dp in lst)
            {
                Panel pnl = new Panel();
                pnl.BackColor = dp.BackgroundColor;
                switch (dp.Position)
                {
                    case "Top":
                        pnl.Dock = DockStyle.Top;
                        break;
                    case "Bottom":
                        pnl.Dock = DockStyle.Bottom;
                        break;
                }
                pnl.Tag = dp;
                pnl.Height = dp.Height;
                pnl.MouseMove += (object s, MouseEventArgs a) =>
                {
                    if (MovingControl != null)
                    {
                        var newloc = new Point(a.X + 15, 0);
                        var proper = pnl.PointToClient(newloc);
                        MovingControl.Location = proper;
                    }
                };
                pnl.MouseDown += (object s, MouseEventArgs a) =>
                {
                    if (MovingControl != null)
                    {
                        if (a.Button == MouseButtons.Left)
                        {
                            var w = (Skinning.DesktopWidget)MovingControl.Tag;
                            w.XLocation = MovingControl.Left;
                            Skinning.Utilities.saveskin();
                        }
                        else if (a.Button == MouseButtons.Left)
                        {
                            var w = (Skinning.DesktopWidget)MovingControl.Tag;
                            MovingControl.Left = w.XLocation;
                            Skinning.Utilities.saveskin();

                        }
                        MovingControl = null;
                    }
                };
                DesktopPanels.Add(pnl);
                if (API.Upgrades["desktoppanel"] == true)
                {
                    if (dp.BackgroundImage == null)
                    {
                        pnl.BackgroundImage = null;
                    }
                    else
                    {
                        pnl.BackgroundImage = dp.BackgroundImage;
                        pnl.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.desktoppanellayout;
                        pnl.BackColor = Color.Transparent;
                    }
                    if (lst.Count > 1)
                    {
                        if (API.CurrentSkin.ALPosition == dp.Position)
                        {
                            ChangePosition(AppLauncherPanel, pnl);
                        }
                        if (API.CurrentSkin.PanelButtonPosition == dp.Position)
                        {
                            ChangePosition(PanelButtonHolder, pnl);
                        }
                        if (API.CurrentSkin.ClockPosition == dp.Position)
                        {
                            ChangePosition(Clock, pnl);
                        }
                    }
                    else
                    {
                        ChangePosition(AppLauncherPanel, pnl);
                        ChangePosition(PanelButtonHolder, pnl);
                        ChangePosition(Clock, pnl);
                    }
                    pnl.MouseDown += (object s, MouseEventArgs a) =>
                    {
                        if (a.Button == MouseButtons.Right)
                        {
                            SelectedObject = pnl;
                        }
                    };
                    if (API.Upgrades["advanceddesktop"])
                    {
                        pnl.ContextMenuStrip = cbdpanel;
                    }
                    else
                    {
                        pnl.ContextMenuStrip = null;
                    }
                    pnl.Size = new Size(desktoppanel.Size.Width, dp.Height);
                    this.Controls.Add(pnl);
                    pnl.Show();
                }
                else
                {
                    pnl.Hide();
                    this.Controls.Remove(pnl);
                }
                string guid = Guid.NewGuid().ToString();
                API.DEF_PanelGUIDs.Add(guid, pnl);
                OnDesktopPanelDraw?.Invoke(guid);
            }

        }

        public void SetupAppLauncher()
        {
            NewToolStripMenuItem.Visible = API.Upgrades["fsnewfolder"];
            ArtpadPictureToolStripMenuItem.Visible = /*API.Upgrades["artpadsave"]*/false; // not yet implemented
            TextDocumentToolStripMenuItem.Visible = API.Upgrades["textpadsave"];
            NewSkin.Visible = API.Upgrades["skinning"];
            scriptToolStripMenuItem.Visible = /*API.Upgrades["shiftnet"]*/false; //not yet implemented
            API.GetAppLauncherItems();
            if (API.Upgrades["applaunchermenu"] == true)
            {
                ApplicationsToolStripMenuItem.Font = new Font(API.CurrentSkin.applicationbuttontextfont, API.CurrentSkin.applicationbuttontextsize, API.CurrentSkin.applicationbuttontextstyle);
                ApplicationsToolStripMenuItem.Text = API.CurrentSkin.applicationlaunchername;
                ApplicationsToolStripMenuItem.DropDownItems.Clear();
                if (API.Upgrades["alshiftnetapps"] == true)
                {
                    imgshiftnetapps.Images.Clear();
                    ApplicationsToolStripMenuItem.DropDown.ImageList = imgshiftnetapps;
                    //Mods
                    if (!Directory.Exists(Paths.Mod_AppLauncherEntries))
                    {
                        Directory.CreateDirectory(Paths.Mod_AppLauncherEntries);
                    }
                    foreach (string file in Directory.GetFiles(Paths.Mod_AppLauncherEntries))
                    {
                        string json = File.ReadAllText(file);
                        var TEMP_AL = JsonConvert.DeserializeObject<ModApplauncherItem>(json);
                        string lua;
                        if (TEMP_AL.Lua != null)
                        {
                            lua = TEMP_AL.Lua;
                        }
                        else
                        {
                            string path = TEMP_AL.ShiftCode.Replace("runSAA:", "");
                            lua = "launch_mod('/Shiftum42/Apps/" + TEMP_AL.AppDirectory.Replace("\"", "\\\"").Replace("'", "\\'") + "/" + path + "')";
                        }

                        ApplauncherItem NewAL = null;
                        try
                        {
                            NewAL = new ApplauncherItem(TEMP_AL.Name, Image.FromFile(Paths.Applications + TEMP_AL.AppDirectory + "\\" + TEMP_AL.Icon), lua, true);
                            imgshiftnetapps.Images.Add(file, NewAL.Icon);
                        }
                        catch 
                        {
                            NewAL = new ApplauncherItem(TEMP_AL.Name, null, lua, true);
                        }
                        var mitem = new ToolStripMenuItem();
                        mitem.ImageKey = file;
                        mitem.Text = NewAL.Name;
                        mitem.Tag = TEMP_AL;
                        mitem.ImageScaling = ToolStripItemImageScaling.None;
                        mitem.Visible = NewAL.Display;

                        mitem.Click += (object s, EventArgs a) =>
                        {
                            API.LaunchMod(NewAL.Lua.Replace("launch_mod('", "").Replace("/Shiftum42/Apps/", Paths.Applications).Replace("/", OSInfo.DirectorySeparator).Replace("')", ""));
                        };
                        ApplicationsToolStripMenuItem.DropDownItems.Add(mitem);
                    }
                    ApplicationsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
                }



                foreach (ApplauncherItem aitem in API.AppLauncherItems)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = aitem.Name;
                    item.Tag = aitem;
                    imgshiftnetapps.Images.Add(item.Text, aitem.Icon);
                    item.ImageKey = item.Text;
                    item.Visible = aitem.Display;
                    item.ImageScaling = ToolStripItemImageScaling.None;
                    ApplicationsToolStripMenuItem.DropDownItems.Add(item);
                    item.Click += new EventHandler(this.RunAppFromLauncher);
                }

                ApplicationsToolStripMenuItem.Height = API.CurrentSkin.applicationbuttonheight;
                if (API.CurrentSkinImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.Text = "";
                    ApplicationsToolStripMenuItem.BackColor = Color.Transparent;
                }
                else {
                    ApplicationsToolStripMenuItem.Text = API.CurrentSkin.applicationlaunchername;
                    ApplicationsToolStripMenuItem.BackColor = API.CurrentSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImage = null;
                }

                applaunchermenuholder.Width = API.CurrentSkin.applaunchermenuholderwidth;
                desktopappmenu.Width = API.CurrentSkin.applaunchermenuholderwidth;
                ApplicationsToolStripMenuItem.Width = API.CurrentSkin.applaunchermenuholderwidth;
                ApplicationsToolStripMenuItem.ForeColor = API.CurrentSkin.applicationsbuttontextcolour;
                applaunchermenuholder.Height = API.CurrentSkin.applicationbuttonheight;
                desktopappmenu.Height = API.CurrentSkin.applicationbuttonheight;
                ApplicationsToolStripMenuItem.Height = API.CurrentSkin.applicationbuttonheight;

                if (API.CurrentSkinImages.applauncher != null)
                {
                    ApplicationsToolStripMenuItem.BackgroundImage = API.CurrentSkinImages.applauncher;
                }
                else {
                    ApplicationsToolStripMenuItem.BackColor = API.CurrentSkin.applauncherbackgroundcolour;
                    ApplicationsToolStripMenuItem.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.applauncherlayout;
                }
                ApplicationsToolStripMenuItem.BackColor = API.CurrentSkin.applauncherbuttoncolour;
            }
            else {
                ApplicationsToolStripMenuItem.Visible = false;
            }
            OnAppLauncherPopulate?.Invoke(API.AppLauncherItems);
        }

        public void SetupGNOME2Elements()
        {
            if (API.Upgrades["gray"] == true)
            {
                this.ContextMenuStrip = cmbdesktopoptions;
                NewToolStripMenuItem.Visible = API.Upgrades["desktopicons"];
                addDesktopPanelToolStripMenuItem.Visible = API.Upgrades["advanceddesktop"];
                widgetManagerToolStripMenuItem.Visible = API.Upgrades["advanceddesktop"]; //Uncomment when mid game bridge sequence finished.


            }

            appLauncherToolStripMenuItem.Visible = API.Upgrades["applaunchermenu"];
            clockToolStripMenuItem1.Visible = API.Upgrades["desktoppanelclock"];
            panelButtonsToolStripMenuItem.Visible = API.Upgrades["panelbuttons"];

            PanelButtonHolder.ContextMenuStrip = cbwidget;
            AppLauncherPanel.ContextMenuStrip = cbwidget;
            Clock.ContextMenuStrip = cbwidget;
            paneltimetext.MouseDown += (object s, MouseEventArgs a) =>
            {
                if (a.Button == MouseButtons.Right)
                {
                    SelectedObject = Clock;
                }
            };
            ApplicationsToolStripMenuItem.MouseDown += (object s, MouseEventArgs a) =>
            {
                if (a.Button == MouseButtons.Right)
                {
                    SelectedObject = AppLauncherPanel;
                }
            };
            PanelButtonHolder.MouseDown += (object s, MouseEventArgs a) =>
            {
                if (a.Button == MouseButtons.Right)
                {
                    SelectedObject = PanelButtonHolder;
                }
            };
            wlocmenu.DropDownItems.Clear();
            if (API.Upgrades["advanceddesktop"])
            {
                foreach (var p in DesktopPanels)
                {
                    var dp = (Skinning.DesktopPanel)p.Tag;
                    p.ContextMenuStrip = cbdpanel;
                    var itm = new ToolStripMenuItem();
                    itm.Text = dp.Position;
                    wlocmenu.DropDownItems.Add(itm);
                    itm.Click += (object s, EventArgs a) =>
                    {
                        if (SelectedObject != null)
                        {
                            if (SelectedObject == AppLauncherPanel)
                            {
                                API.CurrentSkin.ALPosition = itm.Text;
                            }
                            else if (SelectedObject == Clock)
                            {
                                API.CurrentSkin.ClockPosition = itm.Text;
                            }
                            else if (SelectedObject == PanelButtonHolder)
                            {
                                API.CurrentSkin.PanelButtonPosition = itm.Text;
                            }
                            SelectedObject.Parent.Controls.Remove(SelectedObject);
                            SetupDesktopPanel();
                            Skinning.Utilities.saveskin();
                        }
                    };
                }
            }
        }

        public void SetupPanelClock()
        {
            if (API.Upgrades["desktoppanelclock"] == true)
            {

                paneltimetext.ForeColor = API.CurrentSkin.clocktextcolour;

                if (API.CurrentSkinImages.panelclock == null)
                {
                    timepanel.BackColor = API.CurrentSkin.clockbackgroundcolor;
                    timepanel.BackgroundImage = null;
                }
                else {
                    timepanel.BackColor = Color.Transparent;
                    timepanel.BackgroundImage = API.CurrentSkinImages.panelclock;
                    timepanel.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.panelclocklayout;
                }
                paneltimetext.Font = new Font(API.CurrentSkin.panelclocktextfont, API.CurrentSkin.panelclocktextsize, API.CurrentSkin.panelclocktextstyle);
                timepanel.Size = new Size(paneltimetext.Width + 3, timepanel.Height);
                paneltimetext.Location = new Point(0, API.CurrentSkin.panelclocktexttop);
                timepanel.Show();
            }
            else {
                timepanel.Hide();
            }
            OnClockSkin?.Invoke();
        }

        public void CheckUnity()
        {
            if (UnityEnabled == true)
            {
                this.TransparencyKey = Color.FromArgb(1, 0, 1);
                this.BackColor = Color.FromArgb(1, 0, 1);
                this.BackgroundImage = null;
            }
            else
            {
                this.TransparencyKey = Color.BurlyWood;
                this.BackColor = API.CurrentSkin.desktopbackgroundcolour;

                this.BackgroundImage = API.CurrentSkinImages.desktopbackground;
                var d = DateTime.Now;
                if (d.Day == 25 && d.Month == 12)
                {
                    if (API.CurrentSave.ChristmasRewardPast == false)
                    {
                        this.BackgroundImage = Properties.Resources.christmas_skin;
                    }
                }
                this.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.desktopbackgroundlayout;

            }
            OnUnityCheck?.Invoke();
        }

        public void CheckForChristmas()
        {
            //Christmas - Codepoints gift
            //Christmas Skin
            var date = DateTime.Now;
            if (date.Day == 25 && date.Month == 12)
            {
                if (API.CurrentSave.newgame == false && API.CurrentSave.ChristmasRewardPast == false)
                {
                    API.CurrentSave.ChristmasRewardPast = true;
                    API.CreateInfoboxSession("Merry Christmas!", "Merry Christmas from all of the developers of ShiftOS. To celebrate Christmas, you have been given 1000 Codepoints for you to spend on Shiftorium Upgrades. We have also set your desktop background for the occasion.", infobox.InfoboxMode.Info);
                    API.AddCodepoints(1000);
                }
                SaveSystem.Utilities.saveGame();
            }
            else
            {
                API.CurrentSave.ChristmasRewardPast = false; //Christmas is a yearly event, so just in case, every day that isn't Christmas, the 'Christmas' variable is set to false so that we can celebrate every year.
                SaveSystem.Utilities.saveGame();
            }
        }

        public void ChangePosition(Control ctrl, Panel newPanel)
        {
            try {
                ctrl.Parent.Controls.Remove(ctrl);
                newPanel.Controls.Add(ctrl);
            }
            catch
            {
                newPanel.Controls.Add(ctrl);
            }
            ctrl.BringToFront();
        }

        public void SetupPanelButtons()
        {
            pnlpanelbuttonholder.Controls.Clear();
            if (API.Upgrades["panelbuttons"] == true)
            {
                foreach (PanelButton pbtn in API.PanelButtons)
                {
                    Panel pnl = new Panel();
                    Label lbl = new Label();
                    PictureBox pb = new PictureBox();

                    pnl.Visible = true;

                    pb.Image = pbtn.Icon;
                    lbl.Text = pbtn.Name;

                    pnl.Margin = new Padding(0, API.CurrentSkin.panelbuttonfromtop, API.CurrentSkin.panelbuttongap, 0);

                    setpanelbuttonappearnce(ref pnl, ref pb, ref lbl);

                    setuppanelbuttonicons(ref pb, pbtn.Icon);

                    pnlpanelbuttonholder.Controls.Add(pnl);
                    pnl.ContextMenuStrip = null;
                    pnl.Show();
                    pnl.Click += new EventHandler(this.PanelButton_Click);
                    pb.Click += new EventHandler(this.PanelButton_Click);
                    lbl.Click += new EventHandler(this.PanelButton_Click);
                    pnl.Tag = pbtn;
                    pb.Tag = pbtn;
                    lbl.Tag = pbtn;
                }
                pnlpanelbuttonholder.Padding = new Padding(API.CurrentSkin.panelbuttoninitialgap, 0, 0, 0);
            }
            OnPanelButtonPopulate?.Invoke(API.PanelButtons);
        }

        public void setuppanelbuttonicons(ref PictureBox tbicon, Image image)
        {
            tbicon.Image = image;
            tbicon.SizeMode = PictureBoxSizeMode.StretchImage;
            tbicon.Size = new Size(API.CurrentSkin.panelbuttoniconsize, API.CurrentSkin.panelbuttoniconsize);
        }

        public void setpanelbuttonappearnce(ref Panel panelbutton, ref PictureBox icon, ref Label text)
        {
            panelbutton.Controls.Add(text);
            panelbutton.Controls.Add(icon);
            text.Show();
            if (API.Upgrades["appicons"] == true)
            {
                icon.Show();
            }
            icon.Location = new Point(API.CurrentSkin.panelbuttoniconside, API.CurrentSkin.panelbuttonicontop);
            icon.Size = new Size(API.CurrentSkin.panelbuttoniconsize, API.CurrentSkin.panelbuttoniconsize);
            panelbutton.Size = new Size(API.CurrentSkin.panelbuttonwidth, API.CurrentSkin.panelbuttonheight);
            panelbutton.BackColor = API.CurrentSkin.panelbuttoncolour;
            panelbutton.BackgroundImage = API.CurrentSkinImages.panelbutton;
            panelbutton.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.panelbuttonlayout;
            text.BackColor = Color.Transparent;
            text.AutoSize = false;
            text.Width = panelbutton.Width - API.CurrentSkin.panelbuttontextside - API.CurrentSkin.panelbuttoniconsize - API.CurrentSkin.panelbuttoniconside; 
            icon.BackColor = Color.Transparent;
            text.ForeColor = API.CurrentSkin.panelbuttontextcolour;
            text.Font = new Font(API.CurrentSkin.panelbuttontextfont, API.CurrentSkin.panelbuttontextsize, API.CurrentSkin.panelbuttontextstyle);
            text.Location = new Point(API.CurrentSkin.panelbuttontextside, API.CurrentSkin.panelbuttontexttop);
        }

        public void RunAppFromLauncher(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ApplauncherItem aitem = (ApplauncherItem)item.Tag;
            var li = new LuaInterpreter();
            li.mod(aitem.Lua);
            
            li = null;
        }

        public void PanelButton_Click(object sender, EventArgs e)
        {
            if (API.Upgrades["usefulpanelbuttons"])
            {
                Control ctrl = (Control)sender;
                try
                {
                    PanelButton pbtn = (PanelButton)ctrl.Tag;
                    var frm = pbtn.FormToManage;
                    if(frm.Left < Screen.PrimaryScreen.Bounds.Width)
                    {
                        API.MinimizeForm(frm);
                    }
                    else
                    {
                        API.ToggleMinimized(frm);
                    }
                }
                catch 
                {

                }
            }
        }

        private void ALHover(object sender, EventArgs e)
        {
            if (API.CurrentSkinImages.applaunchermouseover != null)
            {
                desktopappmenu.BackgroundImage = API.CurrentSkinImages.applaunchermouseover;
            }
        }

        private void ALReset(object sender, EventArgs e)
        {
            if (API.CurrentSkinImages.applauncher != null)
            {
                desktopappmenu.BackgroundImage = API.CurrentSkinImages.applauncher;
            }
        }

        private void ALClick(object sender, MouseEventArgs e)
        {
            if (API.CurrentSkinImages.applauncherclick != null)
            {
                desktopappmenu.BackgroundImage = API.CurrentSkinImages.applauncherclick;
            }
        }

        private bool ShowDebug = false;

        private void clocktick_Tick(object sender, EventArgs e)
        {
        }

        public void AddNotification(string title, string message)
        {
            var n = new Notification(title, message);
            switch(API.CurrentSkin.desktoppanelposition)
            {
                case "Top":
                    n.Location = new Point(this.Width - n.Width, desktoppanel.Height);
                    break;
                case "Bottom":
                    n.Location = new Point(this.Width - n.Width, this.Height - n.Height - desktoppanel.Height);
                    break;
            }
            this.Controls.Add(n);
            n.Show();
            n.BringToFront();
        }

        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("New Folder", "Please enter the name of your new folder.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetInfoboxResult();
                if(!Directory.Exists(Paths.Desktop + res))
                {
                    Directory.CreateDirectory(Paths.Desktop + res);
                    SetupDesktop();
                }
                else
                {
                    API.CreateInfoboxSession("Can't create folder", "That folder already exists. Please use a different name.", infobox.InfoboxMode.Info);
                }
            };
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(Paths.Desktop + SelectedIconName))
            {
                API.CreateInfoboxSession("Delete File", "Would you really like to delete this file?", infobox.InfoboxMode.YesNo);
                API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var res = API.GetInfoboxResult();
                    if(res == "Yes")
                    {
                        File.Delete(Paths.Desktop + SelectedIconName);
                    }
                };
            }
            else if(Directory.Exists(Paths.Desktop + SelectedIconName))
            {
                API.CreateInfoboxSession("Delete Folder", "Would you really like to delete this folder and all of it's contents?", infobox.InfoboxMode.YesNo);
                API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var res = API.GetInfoboxResult();
                    if (res == "Yes")
                    {
                        Directory.Delete(Paths.Desktop + SelectedIconName, true);
                    }
                };
            }
            else
            {
                API.CreateInfoboxSession("Error", "You cannot delete this icon.", infobox.InfoboxMode.Info);
            }
            SetupDesktop();
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void NewSkin_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Export Skin", "Please enter a name for your skin.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetInfoboxResult();
                if (res != "Cancelled")
                {
                    if (!File.Exists(Paths.Desktop + res + ".skn"))
                    {
                        Skinning.Utilities.saveskintofile(Paths.Desktop + res + ".skn");
                        SetupDesktopIcons();
                    }
                }
            };
        }

        private void addDesktopPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(API.CurrentSkin.DesktopPanels.Count < 2)
            {
                string no = "Top";
                string yes = "Bottom";
                if (API.CurrentSkin.DesktopPanels.Count == 0)
                {
                    no = API.CurrentSkin.desktoppanelposition;
                }
                else {
                    foreach (var pnl in API.CurrentSkin.DesktopPanels)
                    {
                        no = pnl.Position;
                    }
                }
                switch(no)
                {
                    case "Top":
                        yes = "Bottom";
                        break;
                    case "Bottom":
                        yes = "Top";
                        break;
                }
                var dp = new Skinning.DesktopPanel();
                dp.Height = 24;
                dp.Position = yes;
                dp.BackgroundColor = Color.White;
                API.CurrentSkin.DesktopPanels.Add(dp);
                SetupDesktop();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            API.CurrentSkin.DesktopPanels.Remove((Skinning.DesktopPanel)SelectedObject.Tag);
            Skinning.Utilities.saveskin();
            SetupDesktopPanel();
        }

        private void clockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dp = (Skinning.DesktopPanel)SelectedObject.Tag;
            API.CurrentSkin.ClockPosition = dp.Position;
            Skinning.Utilities.saveskin();
            SetupDesktop(); 
        }

        private void panelButtonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dp = (Skinning.DesktopPanel)SelectedObject.Tag;
            API.CurrentSkin.PanelButtonPosition = dp.Position;
            Skinning.Utilities.saveskin();
            SetupDesktop();
        }

        private void appLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dp = (Skinning.DesktopPanel)SelectedObject.Tag;
            API.CurrentSkin.ALPosition = dp.Position;
            Skinning.Utilities.saveskin();
            SetupDesktop();
        }

        private void widgetManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.CreateForm(new WidgetManager(), "Widget Manager", API.GetIcon("WidgetManager"));
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dp = (Skinning.DesktopPanel)SelectedObject.Tag;
            API.CreateForm(new PanelManager(dp), "Panel Options", API.GetIcon("PanelOptions"));
        }

        private void TextDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("New Text Document", "Please type a name for your document.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (o, a) =>
            {
                var res = API.GetInfoboxResult();
                if(res != "Cancelled")
                {
                    if(!File.Exists(Paths.Desktop + res + ".txt"))
                    {
                        File.WriteAllText(Paths.Desktop + res + ".txt", "");
                        SetupDesktopIcons();
                    }
                    else
                    {
                        API.CreateInfoboxSession("File exists!", "The file name you entered already exists.", infobox.InfoboxMode.Info);
                    }
                }
            };
        }
    }

    public class DesktopIconManager
    {
        public static List<DesktopIcon> Icons = null;
        public static List<IconModel> Models = null;

        public static void GetIcons()
        {
            Icons = new List<DesktopIcon>();
            Models = new List<IconModel>();
            API.GetAppLauncherItems();
            if (!Directory.Exists(Paths.Desktop))
            {
                Directory.CreateDirectory(Paths.Desktop);
            }
            else
            {
                foreach (string dir in Directory.GetDirectories(Paths.Desktop))
                {
                    //Get dir info
                    var dinf = new DirectoryInfo(dir);
                    //Create new IconModel
                    var m = new IconModel();
                    //Set name to dir name
                    m.Name = dinf.Name;
                    //Set type to Directory
                    m.Type = IconType.Directory;
                    //Set lua to open directory in File Skimmer
                    m.Lua = $"fileskimmer('/Home/Desktop/{dinf.Name}')";
                    Models.Add(m);
                }
                foreach (string file in Directory.GetFiles(Paths.Desktop))
                {
                    //Get file info
                    var finf = new FileInfo(file);
                    //Create new IconModel
                    var icm = new IconModel();
                    //Set IconModel name to filename
                    icm.Name = finf.Name;
                    //Set IconModel's type based on file extension
                    switch (finf.Extension.ToLower()) //Make the string lower-case for ease of use.
                    {
                        case ".desktop":
                            //Desktop script.
                            icm.Type = IconType.Script;
                            icm.Lua = File.ReadAllText(finf.FullName); //The Lua that is to be ran by this script is in the file.
                            break;
                        case ".sct":
                            //Desktop Shortcut - NYI
                            break;
                        default:
                            //File.
                            icm.Type = IconType.File;
                            icm.Lua = $"fopen('/Home/Desktop/{finf.Name}')";
                            break;
                    }
                    Models.Add(icm);
                }
            }
            
            foreach(IconModel m in Models)
            {
                var d = new DesktopIcon();
                d.IconName = m.Name;
                d.LuaAction = m.Lua;
                switch(m.Type)
                {
                    case IconType.Directory:
                        d.Icon = API.GetIcon("Folder");
                        break;
                    default:
                        var finf = new FileInfo(Paths.Desktop + d.IconName);
                        switch(finf.Extension)
                        {
                            case ".txt":
                            case ".doc":
                            case ".owd":
                            case ".docx":
                                d.Icon = API.GetIcon("TextFile");
                                break;
                            case ".skn":
                            case ".spk":
                                d.Icon = API.GetIcon("SkinFile");
                                break;
                            case ".saa":
                                d.Icon = API.GetIcon("SAAFile");
                                break;
                            case ".pkg":
                            case ".stp":
                                d.Icon = API.GetIcon("SetupPackage");
                                break;
                            default:
                                d.Icon = API.GetIcon("UnrecognizedFile");
                                break;
                        }
                        break;
                }
                Icons.Add(d);
            }
            foreach (ApplauncherItem al in API.AppLauncherItems)
            {
                if (al.Display == true)
                {
                    var dl = new DesktopIcon();
                    dl.Icon = al.Icon;
                    dl.IconName = al.Name;
                    dl.LuaAction = al.Lua;
                    Icons.Add(dl);
                }
            }

        }

        public class IconModel
        {
            public string Name { get; set; }
            public IconType Type { get; set; }
            public string Lua { get; set; }
        }

        public enum IconType
        {
            Directory,
            Script,
            File,
            Shortcut
        }
    }

    class AppLauncherColorTable : ProfessionalColorTable
    {
        public override Color ButtonSelectedHighlight
        {
            get { return API.CurrentSkin.Menu_ButtonSelectedHighlight; }
        }
        public override Color ButtonSelectedHighlightBorder
        {
            get { return API.CurrentSkin.Menu_ButtonSelectedHighlight; }
        }
        public override Color ButtonPressedHighlight
        {
            get { return API.CurrentSkin.Menu_ButtonPressedHighlight; }
        }
        public override Color ButtonPressedHighlightBorder
        {
            get { return API.CurrentSkin.Menu_ButtonPressedHighlight; }
        }
        public override Color ButtonCheckedHighlight
        {
            get { return API.CurrentSkin.Menu_ButtonCheckedHighlight; }
        }
        public override Color ButtonCheckedHighlightBorder
        {
            get { return API.CurrentSkin.Menu_ButtonCheckedHighlightBorder; }
        }
        public override Color ButtonPressedBorder
        {
            get {
                if (API.CurrentSkinImages.applauncherclick == null)
                {
                    return API.CurrentSkin.Menu_ButtonPressedBorder;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color ButtonSelectedBorder
        {
            get {
                if (API.CurrentSkinImages.applauncherclick == null)
                {
                    return API.CurrentSkin.Menu_ButtonSelectedBorder;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color ButtonCheckedGradientBegin
        {
            get { return API.CurrentSkin.Menu_ButtonCheckedGradientBegin; }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ButtonCheckedGradientMiddle; }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get { return API.CurrentSkin.Menu_ButtonCheckedGradientEnd; }
        }
        public override Color ButtonSelectedGradientBegin
        {
            get { return API.CurrentSkin.Menu_ButtonSelectedGradientBegin; }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ButtonSelectedGradientMiddle; }
        }
        public override Color ButtonSelectedGradientEnd
        {
            get { return API.CurrentSkin.Menu_ButtonSelectedGradientEnd; }
        }
        public override Color ButtonPressedGradientBegin
        {
            get { return API.CurrentSkin.Menu_ButtonPressedGradientBegin; }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ButtonPressedGradientMiddle; }
        }
        public override Color ButtonPressedGradientEnd
        {
            get { return API.CurrentSkin.Menu_ButtonPressedGradientEnd; }
        }
        public override Color CheckBackground
        {
            get { return API.CurrentSkin.Menu_CheckBackground; }
        }
        public override Color CheckSelectedBackground
        {
            get { return API.CurrentSkin.Menu_CheckSelectedBackground; }
        }
        public override Color CheckPressedBackground
        {
            get { return API.CurrentSkin.Menu_CheckPressedBackground; }
        }
        public override Color GripDark
        {
            get { return Color.Transparent; }
        }
        public override Color GripLight
        {
            get { return Color.Transparent; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientBegin; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientMiddle; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientEnd; }
        }
        public override Color ImageMarginRevealedGradientBegin
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientBegin; }
        }
        public override Color ImageMarginRevealedGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientMiddle; }
        }
        public override Color ImageMarginRevealedGradientEnd
        {
            get { return API.CurrentSkin.Menu_ImageMarginGradientEnd; }
        }
        public override Color MenuStripGradientBegin
        {
            get { return API.CurrentSkin.Menu_MenuStripGradientBegin; }
        }
        public override Color MenuStripGradientEnd
        {
            get { return API.CurrentSkin.Menu_MenuStripGradientEnd; }
        }
        public override Color MenuItemSelected
        {
            get { return API.CurrentSkin.Menu_MenuItemSelected; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Transparent; }
        }
        public override Color MenuBorder
        {
            get { return API.CurrentSkin.Menu_MenuBorder; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get {
                if (API.CurrentSkinImages.applaunchermouseover == null)
                {
                    return API.CurrentSkin.applaunchermouseovercolour;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                if (API.CurrentSkinImages.applaunchermouseover == null)
                {
                    return API.CurrentSkin.applaunchermouseovercolour;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                if (API.CurrentSkinImages.applauncherclick == null)
                {
                    return API.CurrentSkin.Menu_MenuItemPressedGradientBegin;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                if (API.CurrentSkinImages.applauncherclick == null)
                {
                    return API.CurrentSkin.Menu_MenuItemPressedGradientMiddle;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                if (API.CurrentSkinImages.applauncherclick == null)
                {
                    return API.CurrentSkin.Menu_MenuItemPressedGradientEnd;
                }
                else
                {
                    return Color.Transparent;
                }
            }
        }

        public override Color RaftingContainerGradientBegin
        {
            get { return API.CurrentSkin.Menu_RaftingContainerGradientBegin; }
        }
        public override Color RaftingContainerGradientEnd
        {
            get { return API.CurrentSkin.Menu_RaftingContainerGradientEnd; }
        }
        public override Color SeparatorDark
        {
            get { return API.CurrentSkin.Menu_SeparatorDark; }
        }
        public override Color SeparatorLight
        {
            get { return API.CurrentSkin.Menu_SeparatorLight; }
        }
        public override Color StatusStripGradientBegin
        {
            get { return API.CurrentSkin.Menu_StatusStripGradientBegin; }
        }
        public override Color StatusStripGradientEnd
        {
            get { return API.CurrentSkin.Menu_StatusStripGradientEnd; }
        }
        public override Color ToolStripBorder
        {
            get { return API.CurrentSkin.Menu_ToolStripBorder; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return API.CurrentSkin.Menu_ToolStripDropDownBackground; }
        }
        public override Color ToolStripGradientBegin
        {
            get { return API.CurrentSkin.Menu_ToolStripGradientBegin; }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return API.CurrentSkin.Menu_ToolStripGradientMiddle; }
        }
        public override Color ToolStripGradientEnd
        {
            get { return API.CurrentSkin.Menu_ToolStripGradientEnd; }
        }
        public override Color ToolStripContentPanelGradientBegin
        {
            get { return API.CurrentSkin.Menu_ToolStripContentPanelGradientBegin; }
        }
        public override Color ToolStripContentPanelGradientEnd
        {
            get { return API.CurrentSkin.Menu_ToolStripContentPanelGradientEnd; }
        }
        public override Color ToolStripPanelGradientBegin
        {
            get { return API.CurrentSkin.Menu_ToolStripPanelGradientBegin; }
        }
        public override Color ToolStripPanelGradientEnd
        {
            get { return API.CurrentSkin.Menu_ToolStripPanelGradientEnd; }
        }
        public override Color OverflowButtonGradientBegin
        {
            get { return Color.Transparent; }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get { return Color.Transparent; }
        }
        public override Color OverflowButtonGradientEnd
        {
            get { return Color.Transparent; }
        }
    }
}