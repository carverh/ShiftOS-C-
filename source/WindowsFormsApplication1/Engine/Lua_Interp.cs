using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicLua;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Gecko;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json;

namespace ShiftOS
{
    public class Lua_API
    {
        public static List<LuaInterpreter> RunningMods = new List<LuaInterpreter>();
        public static bool UseLuaAPI = false;
    }

    public class LuaInterpreter
    {
        public dynamic mod = new DynamicLua.DynamicLua();
        public List<string> Errors = new List<string>();

        /// <summary>
        /// Creates a new Lua interpreter and interprets a .lua file.
        /// </summary>
        /// <param name="modfile">The file to interpret.</param>
        public LuaInterpreter(string modfile)
        {
            Errors.Clear();
            //Initiate the interpreter
            mod = new DynamicLua.DynamicLua();
            //Register core functions with the interpreter
            RegisterCore();
            //Parse the file contents.
            var lua = File.ReadAllText(modfile);
            var t = new System.Windows.Forms.Timer();
            ThisDirectory = Directory.GetParent(modfile).FullName;
            t.Interval = 50;
            t.Tick += (object se, EventArgs ea) =>
            {
                if (Errors.Count > 0)
                {
                    if (API.LoggerTerminal != null)
                    {
                        API.LoggerTerminal.WriteLine(Errors[0]);
                        Errors.Remove(Errors[0]);
                    }
                    else
                    {
                        API.CreateInfoboxSession("Script Error", $"An error has occurred in your script: {Errors[0]}", infobox.InfoboxMode.Info);
                        Errors.Remove(Errors[0]);
                    }
                    ExitScript();
                }
            };
            t.Start();
            try
            {
                mod(lua);
            }
            catch (Exception ex)
            {
                API.CreateInfoboxSession("Mod Interpretation Error", "An error has occurred in your mod." + Environment.NewLine + Environment.NewLine + ex.Message, infobox.InfoboxMode.Info);
            }
        }

        /// <summary>
        /// Creates a new Lua Interpreter but doesn't interpret a file.
        /// </summary>
        public LuaInterpreter()
        {
            Errors.Clear();
            //Initiate the interpreter
            mod = new DynamicLua.DynamicLua();
            //Register core functions with the interpreter
            RegisterCore();
            var t = new System.Windows.Forms.Timer();
            t.Interval = 50;
            ThisDirectory = Paths.SaveRoot;
            t.Tick += (object se, EventArgs ea) =>
            {
                if (Errors.Count > 0)
                {
                    if (API.LoggerTerminal != null)
                    {
                        API.LoggerTerminal.WriteLine(Errors[0]);
                        Errors.Remove(Errors[0]);
                    }
                    else
                    {
                        API.CreateInfoboxSession("Script Error", $"An error has occurred in your script: {Errors[0]}", infobox.InfoboxMode.Info);
                        Errors.Remove(Errors[0]);
                    }
                    ExitScript();
                }
            };
            t.Start();
        }

        /// <summary>
        /// Registers all core ShiftOS Lua functions with their C# counterparts.
        /// 
        /// This is so we don't have to expose the entire source code to the interpreter. Add new functions here.
        /// </summary>
        public void RegisterCore()
        {
            //Desktop environment
            mod.on_unity_check += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.OnUnityCheck += () =>
                {
                    mod(func + "()");
                };
            });
            mod.on_desktop_reset += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.OnDesktopReload += () =>
                {
                    mod(func + "()");
                };
            });
            mod.on_clock_skin += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.OnClockSkin += () =>
                {
                    mod(func + "()");
                };
            });
            mod.on_window_open += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.WindowOpened += (win) =>
                {
                    mod(func + $"(\"{API.OpenGUIDs[win]}\")");
                };
            });
            mod.get_window = new Func<string, Form>((guid) =>
            {
                Form frm = null;
                foreach(var kv in API.OpenGUIDs)
                {
                    if (kv.Value == guid)
                        frm = kv.Key;
                }
                return frm;
            });
            mod.on_window_close += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.WindowClosed += (win) =>
                {
                    mod(func + $"(\"{API.OpenGUIDs[win]}\")");
                };
            });
            mod.on_window_titlebar_redraw += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.TitlebarReset += (win) =>
                {
                    mod.win = win;
                    mod(func + "(win)");
                };
            });
            mod.on_window_border_redraw += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.BorderReset += (win) =>
                {
                    mod.win = win;
                    mod(func + "(win)");
                };
            });
            mod.on_window_skin += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.WindowSkinReset += (win) =>
                {
                    mod.win = win;
                    mod(func + "(win)");
                };
            });
            mod.get_border = new Func<Form, WindowBorder>((Form win) =>
            {
                WindowBorder b = null;
                foreach(Control c in win.Controls)
                {
                    if ((string)c.Tag == "api_brdr")
                        b = (WindowBorder)c;
                }
                return b;
            });

            mod.on_app_launcher_populate += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.OnAppLauncherPopulate += (items) =>
                {
                    mod.al_items = items;
                    mod(func + "(clr_to_table(al_items))");
                };
            });
            mod.on_panelbutton_populate += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.OnPanelButtonPopulate += (items) =>
                {
                    mod.pb_items = items;
                    mod(func + "(clr_to_table(pb_items))");
                };
            });
            mod.intercept_ctrlt += new Action<string>((func) =>
            {
                API.CurrentSession.AllowCtrlTIntercept();
                API.CurrentSession.CtrlTPressed += () =>
                {
                    mod(func + "()");
                };
            });
            mod.stop_intercept_ctrlt += new Action(() =>
            {
                API.CurrentSession.DisableCtrlTIntercept();
                
            });

            mod.on_desktopicon_populate += new Action<ShiftOSDesktop, string>((desktop, func) =>
            {
                desktop.DesktopIconsPopulated += (items) =>
                {
                    mod.dl_items = items;
                    mod(func + "(clr_to_table(dl_items))");
                };
            });


            mod(@"function clr_to_table(clrlist)
  local t = {}
  local it = clrlist:GetEnumerator()
  while it:MoveNext() do
    t[#t+1] = it.Current
  end
  return t
end");

            mod.httpget = new Func<string, string>((url) =>
            {
                WebRequest request = WebRequest.Create(url);
                Stream requestStream = request.GetResponse().GetResponseStream();
                StreamReader requestRead = new StreamReader(requestStream);
                return requestRead.ReadToEnd();
            });
            //Shifter Extension API
            mod.shifter_add_category = new Action<string>((name) =>
            {
                bool add = true;
                if(API.LuaShifterRegistry == null)
                {
                    API.LuaShifterRegistry = new Dictionary<string, Dictionary<string, object>>();
                }
                foreach(var kv in API.LuaShifterRegistry)
                {
                    if (kv.Key == name)
                        add = false;
                }
                if(add == true)
                {
                    API.LuaShifterRegistry.Add(name, new Dictionary<string, object>());
                }
                else
                {
                    Errors.Add($"shifter_add_category(\"{name}\"): Error: Category already exists!");
                }
            });
            mod.shifter_remove_category = new Action<string>((name) =>
            {
                if(API.LuaShifterRegistry.ContainsKey(name))
                {
                    API.LuaShifterRegistry.Remove(name);
                }
                else
                {
                    Errors.Add($"shifter_remove_category(\"{name}\"): No such category.");
                }
            });
            mod.shifter_add_value = new Action<string, string, object>((cat, name, in_value) =>
            {
                if(API.LuaShifterRegistry.ContainsKey(cat))
                {
                    var lst = API.LuaShifterRegistry[cat];
                    if(!lst.ContainsKey(name))
                    {
                        lst.Add(name, in_value);
                    }
                    else
                    {
                        Errors.Add($"shifter_add_value(\"{cat}\", \"{name}\", in_value): Category was found, but it already contained a value with the specified name.");
                    }
                }
                else
                {
                    Errors.Add($"shifter_add_value(\"{cat}\", \"{name}\", in_value): Category not found.");
                }
            });
            mod.shifter_get_value = new Func<string, string, object>((cat, name) =>
            {
                if (API.LuaShifterRegistry.ContainsKey(cat))
                {
                    var lst = API.LuaShifterRegistry[cat];
                    if (lst.ContainsKey(name))
                    {
                        return lst[name];
                    }
                    else
                    {
                        Errors.Add($"shifter_add_value(\"{cat}\", \"{name}\", in_value): Category was found, but it already contained a value with the specified name.");
                        return null;
                    }
                }
                else
                {
                    Errors.Add($"shifter_add_value(\"{cat}\", \"{name}\", in_value): Category not found.");
                    return null;
                }
            });


            //APIs.
            mod.load_api = new Action<string>((name) =>
            {
                if(File.Exists(Paths.APIs + name + ".lua"))
                {
                    mod(File.ReadAllText(Paths.APIs + name + ".lua"));
                }
            });

            //Functions with Return Values
            mod.get_app_launcher_items = new Func<List<ApplauncherItem>>(() =>
            {
                var lst = new List<ApplauncherItem>();
                API.GetAppLauncherItems();
                foreach(var itm in API.AppLauncherItems)
                {
                    if(itm.Display == true)
                    {
                        lst.Add(itm);
                    }
                }
                return lst;
            });
            mod.local_image = new Func<string, Image>((filepath) => OpenLocalImage(filepath));
            mod.json_serialize = new Func<object, string>((objectToSerialize) => Newtonsoft.Json.JsonConvert.SerializeObject(objectToSerialize));
            mod.json_unserialize = new Func<string, object>((json_string) => Newtonsoft.Json.JsonConvert.DeserializeObject(json_string));
            mod.open_image = new Func<string, Image>((filename) => OpenImage(filename));
            mod.list_add = new Action<Control, string>((lst, itm) =>
            {
                if(lst is ListBox)
                {
                    var box = lst as ListBox;
                    box.Items.Add(itm);
                }
            });
            mod.list_get_selected = new Func<Control, string>((lst) =>
            {
                if(lst is ListBox)
                {
                    return (lst as ListBox).SelectedItem?.ToString();
                }
                else
                {
                    return null;
                }
            });
            mod.get_skin = new Func<Skinning.Skin>(() =>
            {
                return API.CurrentSkin;
            });
            mod.get_skin_images = new Func<Skinning.Images>(() =>
            {
                return API.CurrentSkinImages;
            });
            mod.upgrades = new Func<string, bool>((id) => GetUpgrade(id));
            mod.create_widget = new Func<string, string, int, int, int, int, bool, Control>((type, text, x, y, width, height, dark_mode) => ConstructControl(type, text, x, y, width, height, dark_mode));
            mod.screen_get_width = new Func<int>(() =>
            {
                return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            });
            mod.screen_get_height = new Func<int>(() =>
            {
                return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            });
            mod.create_window_borderless = new Func<int, int, int, int, Form>((x, y, width, height) => CreateForm(x, y, width, height));

            mod.random = new Func<int, int, int>((min, max) =>
            {
                return new Random().Next(min, max);
            });
            mod.color = new Func<int, int, int, Color>((r, g, b) =>
            {
                try
                {
                    return Color.FromArgb(r, g, b);
                }
                catch
                {
                    Errors.Add("Invalid color values. Values must be a minimum of 0 and a maximum of 255.");
                    return new Color();
                }
            });
            mod.get_desktop_session = new Func<Form>(() =>
            {
                return API.CurrentSession;
            });
            mod.get_icon = new Func<string, Image>((id) => API.GetIcon(id));
            mod.add_icon = new Action<string, Image>((id, img) =>
            {
                if(!API.IconRegistry.ContainsKey(id))
                {
                    API.IconRegistry.Add(id, img);
                    Skinning.Utilities.saveimages();
                }
            });
            mod.icon_exists = new Func<string, bool>((id) =>
            {
                return API.IconRegistry.ContainsKey(id);
            });
            mod.create_window = new Func<string, Image, int, int, Form>((title, icon, width, height) => CreateForm(title, icon, width, height));
            mod.get_codepoints = new Func<int>(() => GetCP());
            mod.buy_upgrade = new Func<string, bool>((id) => BuyUPG(id));
            mod.time = new Func<string>(() => API.GetTime());
            mod.encrypt = new Func<string, string>((raw) => API.Encryption.Encrypt_old(raw));
            mod.decrypt = new Func<string, string>((raw) => API.Encryption.Decrypt_old(raw));
            mod.fread = new Func<string, string>((filepath) => SafeFileRead(filepath));
            mod.terminal = new Action<string>((command) =>
            {
                var t = new Terminal();
                API.CreateForm(t, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
                t.command = command;
                t.DoCommand();
            });
            mod.fwrite = new Action<string, string>((path, contents) =>
            {
                if (path.StartsWith("/"))
                {
                    var real_path = $"{Paths.SaveRoot}{path.Replace("/", OSInfo.DirectorySeparator)}";
                    if(!Directory.Exists(real_path))
                    {
                        File.WriteAllText(real_path, contents);
                    } 
                }
            });
            mod.add_menu_item = new Func<string, MenuStrip, ToolStripMenuItem>((text, parent) => AddMenuItem(text, parent));
            mod.add_child_menu_item = new Func<string, ToolStripMenuItem, ToolStripMenuItem>((text, parent) =>
            {
                try
                {
                    var i = new ToolStripMenuItem();
                    i.Text = text;
                    parent.DropDownItems.Add(i);
                    return i;
                }
                catch(Exception ex)
                {
                    Errors.Add("add_child_menu_item(): Error adding child item to parent. " + ex.Message);
                    return null;
                }
            });
            mod.set_anchor = new Action<Control, string>((ctrl, anchorstyle) => SetAnchor(ctrl, anchorstyle));

            //Standard API Functions
            mod.include = new Action<string>((filepath) => IncludeScript(filepath));
            mod.log = new Action<string>((msg) => API.Log(msg));
            mod.add_codepoints = new Action<int>((amount) => API.AddCodepoints(amount));
            mod.remove_codepoints = new Action<int>((amount) => API.RemoveCodepoints(amount));
            mod.launch_mod = new Action<string>((modSAA) => API.LaunchMod(Paths.SaveRoot + modSAA.Replace("/", OSInfo.DirectorySeparator)));
            mod.open_program = new Action<string>((progname) => API.OpenProgram(progname));
            mod.close_program = new Action<string>((progname) => API.CloseProgram(progname));
            mod.close_everything = new Action(() => API.CloseEverything());
            mod.shutdown = new Action(() => API.ShutDownShiftOS());
            mod.update_ui = new Action(() => { API.UpdateWindows(); API.CurrentSession.SetupDesktop(); });
            mod.load_skin = new Action<string>((filepath) => Skinning.Utilities.loadsknfile(filepath));
            mod.save_to_skin_file = new Action<string>((filepath) => Skinning.Utilities.saveskintofile(filepath));
            mod.on_click = new Action<Control, string>((ctrl, funcname) => RegClick(ctrl, funcname));
            mod.add_widget_to_window = new Action<Form, Control>((win, ctrl) => AddCtrl(win, ctrl));
            mod.open_file = new Action<string, string>((filters, function) => OpenFile(filters, function));
            mod.panel_add_widget = new Action<Control, Control>((ctrl, parent) =>
            {
                try {
                    var p = (Panel)parent;
                    p.Controls.Add(ctrl);
                } catch(Exception ex)
                {
                    Errors.Add(ex.Message);
                }
            });
            mod.flow_add_widget = new Action<Control, Control>((ctrl, parent) =>
            {
                try
                {
                    var p = (FlowLayoutPanel)parent;
                    p.Controls.Add(ctrl);
                }
                catch (Exception ex)
                {
                    Errors.Add(ex.Message);
                }
            });
            mod.info = new Action<string, string>((title, message) =>

                API.CreateInfoboxSession(title, message, infobox.InfoboxMode.Info)    

            );
            mod.on_menu_item_activate = new Action<ToolStripMenuItem, string>((item, function) =>
            {
                item.Click += (object s, EventArgs a) =>
                {
                    mod($"{function}()");
                };
            });
            mod.create_timer = new Func<int, System.Windows.Forms.Timer>((interval) =>
            {
                var t = new System.Windows.Forms.Timer();
                t.Interval = interval;
                return t;
            });
            mod.timer_on_tick = new Action<System.Windows.Forms.Timer, string>((tmr, func) =>
            {
                try
                {
                    tmr.Tick += (object s, EventArgs a) =>
                    {
                        mod($"{func}()");
                    };
                }
                catch(Exception ex)
                {
                    Errors.Add(ex.Message);
                }
            });
            mod.add_widget_to_desktop = new Action<Control>((ctrl) => AddToDesktop(ctrl));
            mod.set_dock = new Action<Control, string>((ctrl, dstyle) =>
            {
                API.CurrentSession.Invoke(new Action(() =>
                {
                    switch (dstyle.ToLower())
                    {
                        case "fill":
                            ctrl.Dock = DockStyle.Fill;
                            break;
                        case "top":
                            ctrl.Dock = DockStyle.Top;
                            break;
                        case "bottom":
                            ctrl.Dock = DockStyle.Bottom;
                            break;
                        case "left":
                            ctrl.Dock = DockStyle.Left;
                            break;
                        case "right":
                            ctrl.Dock = DockStyle.Right;
                            break;
                        case "none":
                            ctrl.Dock = DockStyle.None;
                            break;




                    }
                }));
            });
            mod.webview_navigate = new Action<GeckoWebBrowser, string>((wv, url) => Navigate(wv, url));
            mod.open_terminal = new Action(() =>
            {
                var t = new Terminal();
                API.CreateForm(t, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
            });
            mod.create_directory = new Action<string>((path) =>
            {
                path = $"{Paths.SaveRoot}{path.Replace("/", OSInfo.DirectorySeparator)}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            });
            mod.exists = new Func<string, bool>((path) =>
            {
                path = $"{Paths.SaveRoot}{path.Replace("/", OSInfo.DirectorySeparator)}";
                if(Directory.Exists(path))
                {
                    return true;
                }
                else if(File.Exists(path))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            mod.notify = new Action<string, string>((title, message) => API.CurrentSession.AddNotification(title, message));
            mod.download_file = new Action<string, string>((web_address, local) => DownloadFile(web_address, local));
            mod.on_key_down = new Action<Control, string>((ctrl, action) => RegKeyDown(ctrl, action));
            mod.get_files = new Func<string, List<string>>((path) => GetFiles(path));
            mod.get_folders = new Func<string, List<string>>((path) => GetFolders(path));
            mod.zip = new Action<string, string>((source, destination) =>
            {
                var real = $"{Paths.SaveRoot}{source.Replace("/", OSInfo.DirectorySeparator)}";
                if(Directory.Exists(real))
                {
                    var real_dest = $"{Paths.SaveRoot}{destination.Replace("/", OSInfo.DirectorySeparator)}";
                    ZipFile.CreateFromDirectory(real, real_dest);
                }
                else
                {
                    mod.info("Script Error", "Your script tried to zip up a non-existent folder.");
                }
            });
            mod.beep = new Action<int, int>((freq, dur) => Beep(freq, dur));
            mod.color_picker += new Action<string, Color, string>((title, oldcolor, func) =>
            {
                API.CreateColorPickerSession(title, oldcolor);
                API.ColorPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var c = API.GetLastColorFromSession();
                    mod($"{func}(color({c.R}, {c.G}, {c.B}))");
                };
            });
            mod.info_yes_no += new Action<string, string, string>((title, message, func) =>
            {
                API.CreateInfoboxSession(title, message, infobox.InfoboxMode.YesNo);
                API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var res = API.GetInfoboxResult();
                    if(res == "Yes" || res == "No")
                    {
                        mod($"{func}(\"{res}\")");
                    }
                };
            });


            //Script Management
            mod.exit = new Action(() => ExitScript());
            mod.shutdown = new Action(() => API.ShutDownShiftOS());
            mod.toggle_unity = new Action(() => API.CurrentSession.SetUnityMode());
            mod.lua = new Func<string, string>((luacode) =>
            {
                mod(luacode);
                return "success";
                
            });
            mod.fileskimmer_open += new Action<string, string>((filters, func) =>
            {
                API.CreateFileSkimmerSession(filters, File_Skimmer.FileSkimmerMode.Open);
                API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var res = API.GetFSResult();
                    if(res != "fail")
                    {
                        var real_path = res.Replace(Paths.SaveRoot, "/").Replace("\\", "/");
                        mod($"{func}(\"{real_path}\")");
                    }
                };
            });
            mod.open_File = mod.fileskimmer_open;
            mod.fileskimmer_save += new Action<string, string>((filters, func) =>
            {
                API.CreateFileSkimmerSession(filters, File_Skimmer.FileSkimmerMode.Save);
                API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    var res = API.GetFSResult();
                    if (res != "fail")
                    {
                        var real_path = res.Replace(Paths.SaveRoot, "/").Replace("\\", "/");
                        mod($"{func}(\"{real_path}\")");
                    }
                };
            });
            mod.save_File = mod.fileskimmer_save;
            mod.font = new Func<string, int, Font>((style, size) => {
                return new Font(style, size);
            });


            //other
            mod.fileskimmer = new Action<string>((folder) => OpenFS(folder));
            mod.fopen = new Action<string>((file) => OpenFile(file));
            mod.loadstring = new Action<string>((code) => { mod(code); });

            //Multithreading
            mod.new_thread = new Func<string, Thread>((code) =>
            {
                return new Thread(() =>
                {
                    mod(code);
                });
            });
            mod.start_async = new Action<Thread>((t) => { t.Start(); });

            mod.add_applauncher_item = new Action<string, string>((name, lua) =>
            {
                var m = new ModApplauncherItem();
                m.Name = name;
                m.Lua = lua;
                File.WriteAllText(Paths.Mod_AppLauncherEntries + m.Name, JsonConvert.SerializeObject(m));
                API.UpdateWindows();
                API.CurrentSession.SetupDesktop();
            });
            mod.get_loaded_skin = new Func<Skinning.Skin>(() => { return API.CurrentSkin; });
            mod.reload_skin = new Action(() => { API.CurrentSession.SetupDesktop(); API.UpdateWindows(); });
            mod.get_applauncher_item = new Func<string, ToolStripMenuItem>((name) =>
            {
                ToolStripMenuItem i = null;
                foreach(var item in API.CurrentSession.ApplicationsToolStripMenuItem.DropDownItems)
                {
                    try {
                        ToolStripMenuItem it = (ToolStripMenuItem)item;
                        if (it.Text == name)
                        {
                            i = it;
                        }
                    }
                    catch
                    {

                    }
                }
                return i;
            });
            mod.get_menu_item = new Func<ToolStripMenuItem, string, ToolStripMenuItem>((parent, name) =>
            {
                ToolStripMenuItem i = null;
                foreach (ToolStripMenuItem item in parent.DropDownItems)
                {
                    if (item.Text == name)
                    {
                        i = item;
                    }
                }
                return i;
            });
            GC.Collect();
        }


        /// <summary>
        /// Sends a keydown event to Lua when you press a key on the specified control.
        /// </summary>
        /// <param name="ctrl">Control to assign the event to.</param>
        /// <param name="action">Function to call on keydown.</param>
        public void RegKeyDown(Control ctrl, string action)
        { /*                                                                                                                                                                                                                           */
            ctrl.KeyDown += (object s, KeyEventArgs a) =>
            {
                mod($"{action}(\"{a.KeyCode.ToString().ToLower()}\")");
            };
        }

        /// <summary>
        /// Gets a list of files.
        /// </summary>
        /// <param name="dir">Directory to scan.</param>
        /// <returns>A System.Collections.Generic.List of all files.</returns>
        public List<string> GetFiles(string dir)
        {
            if (Directory.Exists($"{Paths.SaveRoot}{dir.Replace("/", OSInfo.DirectorySeparator)}"))
            {
                var luatable = new List<string>();
                foreach (string val in Directory.GetFiles($"{Paths.SaveRoot}{dir.Replace("/", OSInfo.DirectorySeparator)}"))
                {
                    luatable.Add(val);
                }
                return luatable;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of folders.
        /// </summary>
        /// <param name="dir">Directory to scan.</param>
        /// <returns>A System.Collections.Generic.List of all folders.</returns>

        public List<string> GetFolders(string dir)
        {
            if (Directory.Exists($"{Paths.SaveRoot}{dir.Replace("/", OSInfo.DirectorySeparator)}"))
            {
                var luatable = new List<string>();
                foreach(string val in Directory.GetDirectories($"{Paths.SaveRoot}{dir.Replace("/", OSInfo.DirectorySeparator)}"))
                {
                    luatable.Add(val);
                }


                return luatable;
            }
            else
            {
                return null;
            }
        }

        public string ThisDirectory = null;

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="web">Web URL to download</param>
        /// <param name="local">A ShiftOS path to download to.</param>
        public void DownloadFile(string web, string local)
        {
            var wc = new WebClient();
            try
            {
                var real_path = $"{Paths.SaveRoot}{local.Replace("/", OSInfo.DirectorySeparator)}";
                wc.DownloadFile(web, real_path);
                mod.notify("Download complete", "Successfully downloaded file " + web + " from the Internet.");
            }
            catch(Exception ex)
            {
                mod.print("Could not download remote file " + web + ", " + ex.Message);
            }
        }

        /// <summary>
        /// Interprets a script within this interpreter.
        /// </summary>
        /// <param name="filename">Script file.</param>
        public void IncludeScript(string filename)
        {
            var real_file = $"{ThisDirectory}{filename.Replace("/", OSInfo.DirectorySeparator)}";
            var lua = File.ReadAllText(real_file);
            try {
                mod(lua);
            }
            catch(Exception ex)
            {
                mod.info("Script Error", "An error has occurred in your script: " + ex.Message);
            }
        }

        /// <summary>
        /// Open a file skimmer in the specified directory.
        /// </summary>
        /// <param name="dir">Directory to open in.</param>
        public void OpenFS(string dir)
        {
            var f = new File_Skimmer();
            API.CreateForm(f, API.LoadedNames.FileSkimmerName, Properties.Resources.iconFileSkimmer);
            if(dir.StartsWith("/"))
            {
                var real = dir;
                var real_slash = real.Replace("/", OSInfo.DirectorySeparator);
                var real_path = $"{Paths.SaveRoot}{real_slash}";
                f.CurrentFolder = real_path;
                f.ListFiles();
            }
        }

        /// <summary>
        /// Opens a file in the right program.
        /// </summary>
        /// <param name="dir">The file path. Why this is named "dir", which means DIRECTORY, not FILE, by the way, is beyond me.</param>
        public void OpenFile(string dir)
        {
            var f = new File_Skimmer();
            if (dir.StartsWith("/"))
            {
                var real = dir;
                var real_slash = real.Replace("/", OSInfo.DirectorySeparator);
                var real_path = $"{Paths.SaveRoot}{real_slash}";
                f.OpenFile(real_path);
            }
        }

        public List<Form> OpenForms = new List<Form>();

        /// <summary>
        /// Exits the script. What did you think it would do?
        /// </summary>
        public void ExitScript()
        {
            foreach(Form f in OpenForms)
            {
                f.Close();
            }
        }

        /// <summary>
        /// Set control anchor from Lua.
        /// </summary>
        /// <param name="ctrl">Target control</param>
        /// <param name="anchor">Anchor string (for example "top;left;bottom;right" or "top;left" or "top")</param>
        public void SetAnchor(Control ctrl, string anchor)
        {
            var a = AnchorStyles.None;
            var l = anchor.ToLower();
            if(l.Contains("left"))
            {
                a = a | AnchorStyles.Left;
            }
            if (l.Contains("right"))
            {
                a = a | AnchorStyles.Right;
            }
            if (l.Contains("bottom"))
            {
                a = a | AnchorStyles.Bottom;
            }
            if (l.Contains("top"))
            {
                a = a | AnchorStyles.Bottom;
            }
            ctrl.Anchor = a;
        }

        /// <summary>
        /// Navigate a webview to the specified URL.
        /// </summary>
        /// <param name="wv">The webview control. YES, We use Gecko, not Internet Exploder.</param>
        /// <param name="url">The target URL, for example "http://playshiftos.ml/forum"</param>
        public void Navigate(GeckoWebBrowser wv, string url)
        {
            wv.Navigate(url);
        }

        /// <summary>
        /// Add a control to the desktop.
        /// </summary>
        /// <param name="ctrl">The control to add.</param>
        public void AddToDesktop(Control ctrl)
        {
            API.CurrentSession.Controls.Add(ctrl);
        }

        /// <summary>
        /// Add a child to a menu item.
        /// </summary>
        /// <param name="text">New item's text</param>
        /// <param name="parent">New item's parent.</param>
        /// <returns>The new item.</returns>
        public ToolStripMenuItem AddMenuItem(string text, MenuStrip parent)
        {
            var itm = new ToolStripMenuItem();
            itm.Text = text;
            itm.Tag = "menu_item";
            parent.Items.Add(itm);
            return itm;
        }

        /// <summary>
        /// Allows the user to get a user to open a file.
        /// </summary>
        /// <param name="fi">File filter.</param>
        /// <param name="fu">Function to call on select.</param>
        public void OpenFile(string fi, string fu)
        {
            API.CreateFileSkimmerSession(fi, File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                mod($"{fu}(\"{API.GetFSResult().Replace(Paths.SaveRoot, "").Replace("\\", "/")}\")");
            };
        } //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Prompt user to save a file.
        /// </summary>
        /// <param name="fi">File filters.</param>
        /// <param name="fu">Function to call.</param>
        public void SaveFile(string fi, string fu)
        {
            API.CreateFileSkimmerSession(fi, File_Skimmer.FileSkimmerMode.Save);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                mod($"{fu}(\"{API.GetFSResult().Replace(Paths.SaveRoot, "").Replace("\\", "/")}\")");
            };
        }


        /// <summary>
        /// Safely read a file.
        /// </summary>
        /// <param name="path">File to read.</param>
        /// <returns>Contents of the file.</returns>
        public string SafeFileRead(string path)
        {
            string contents = "";
            if(path.StartsWith("/"))
            {
                var real = $"{Paths.SaveRoot}{path.Replace("\\", "/")}";
                if(File.Exists(real))
                {
                    contents = File.ReadAllText(real);

                }
                else
                {
                    Errors.Add("fread(): File not found.");
                }
            }
            else
            {
                Errors.Add("fread(): Path not valid.");
            }
            return contents;
        }

        /// <summary>
        /// Buy a shiftorium upgrade.
        /// </summary>
        /// <param name="id">Upgrade ID.</param>
        /// <returns>Did the upgrade get bought successfully?</returns>
        public bool BuyUPG(string id)
        {
            if(API.Upgrades.ContainsKey(id))
            {
                bool bought = false;
                foreach(Shiftorium.Upgrade upg in SaveSystem.ShiftoriumRegistry.DefaultUpgrades)
                {
                    if(upg.id == id)
                    {
                        bought = Shiftorium.Utilities.Buy(upg);
                    }
                }
                return bought;
            }
            else
            {
                //Upgrade doesn't exist.
                return false;
            }
        }

        /// <summary>
        /// Checks if an upgrade is bought.
        /// </summary>
        /// <param name="id">Upgrade ID.</param>
        /// <returns>Whether or not it is bought</returns>
        public bool GetUpgrade(string id)
        {
            if(API.Upgrades.ContainsKey(id))
            {
                return API.Upgrades[id];
            }
            else
            {
                //Upgrade doesn't exist.
                return false;
            }
        }

        /// <summary>
        /// Gets the current amount of Codepoints.
        /// </summary>
        /// <returns>Can you read? Sorry, it's just... I don't feel like typing the same thing twice...</returns>
        public int GetCP()
        {
            return API.CurrentSave.codepoints;
        }

        /// <summary>
        /// Constructs a WinForms control.
        /// </summary>
        /// <param name="type">Control type.</param>
        /// <param name="text">Control text.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <param name="darkmode">Is it dark?</param>
        /// <returns>The control, all ShiftOS-ified for you.</returns>
        public Control ConstructControl(string type, string text, int x, int y, int width, int height, bool darkmode)
        {
            var ctrl = new Control();
            switch(type.ToLower())
            {
                case "luatextbox":
                    var stxt = new SyntaxRichTextBox();
                    stxt.Text = text;
                    stxt.SetLanguage(SyntaxSettings.Language.Lua);
                    ctrl = stxt;
                    break;
                case "list":
                    var lst = new ListBox();
                    ctrl = lst;
                    break;
                case "button":
                    var btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;
                    if(darkmode)
                    {
                        //Set dark button
                        btn.ForeColor = API.CurrentSkin.titletextcolour;
                        btn.BackColor = API.CurrentSkin.titlebarcolour;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                    }
                    ctrl = (Control)btn;
                    break;
                case "webview":
                    var g = new Gecko.GeckoWebBrowser();
                    g.NoDefaultContextMenu = true;
                    ctrl = (Gecko.GeckoWebBrowser)g;
                    //This control renders HTML, so therefore a dark theme is futile.
                    break;
                case "menustrip":
                    ctrl = new MenuStrip();
                    ctrl.Tag = "menustrip";
                    //Menu Strips are rendered using a custom renderer, thus, DarkMode is not required.
                    break;
                case "panel":
                    ctrl = new Panel();
                    if(darkmode)
                    {
                        ctrl.BackColor = API.CurrentSkin.titlebarcolour;
                        ctrl.ForeColor = API.CurrentSkin.titletextcolour;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                        ctrl.ForeColor = Color.Black;
                    }
                    break;
                case "flow":
                    ctrl = new FlowLayoutPanel();
                    if(darkmode)
                    {
                        ctrl.BackColor = API.CurrentSkin.titlebarcolour;
                        ctrl.ForeColor = API.CurrentSkin.titletextcolour;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                        ctrl.ForeColor = Color.Black;
                    }
                    break;
                case "label":
                    ctrl = new Label();
                    //Text Color and Back Color inherited from parent.
                    break;
                case "textbox":
                    ctrl = new TextBox();
                    if(darkmode)
                    {
                        ctrl.BackColor = API.CurrentSkin.titlebarcolour;
                        ctrl.ForeColor = API.CurrentSkin.titletextcolour;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                        ctrl.ForeColor = Color.Black;
                    }
                    break;
                case "richtextbox":
                    ctrl = new RichTextBox();
                    if(darkmode)
                    {
                        ctrl.BackColor = API.CurrentSkin.titlebarcolour;
                        ctrl.ForeColor = API.CurrentSkin.titletextcolour;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                        ctrl.ForeColor = Color.Black;
                    }
                    break;
                default:
                    ctrl = new Control();
                    if(darkmode)
                    {
                        ctrl.BackColor = API.CurrentSkin.titlebarcolour;
                        ctrl.ForeColor = API.CurrentSkin.titletextcolour;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                        ctrl.ForeColor = Color.Black;
                    }
                    break;
            }
            ctrl.Text = text;
            ctrl.Name = text.ToLower().Replace(" ", "_");
            ctrl.Location = new Point(x, y);
            ctrl.Size = new Size(width, height);
            ctrl.Visible = true;
            return ctrl;
        }


        /// <summary>
        /// Broken, piece of dump beep function.
        /// </summary>
        /// <param name="freq">Frequency.</param>
        /// <param name="duration">Length.</param>
        public void Beep(int freq, int duration)
        {
            Beeper.Play(freq, duration);

        }

        /// <summary>
        /// Adds a control to a window.
        /// </summary>
        /// <param name="win">Target window</param>
        /// <param name="ctrl">Control to add.</param>
        public void AddCtrl(Form win, Control ctrl)
        {
            
            List<WindowBorder> borders = new List<WindowBorder>();
            foreach(Control c in win.Controls)
            {
                if(c.Name == "api_brdr")
                {
                    var b = (WindowBorder)c;
                    b.pgcontents.Controls.Add(ctrl);
                    ctrl.BringToFront();
                    borders.Add(b);
                }
            }
            if(borders.Count == 0)
            {
                win.Controls.Add(ctrl);
            }
            
        }

        /// <summary>
        /// Fire a click event when you click the control.
        /// </summary>
        /// <param name="ctrl">Target control</param>
        /// <param name="funcname">Function to call.</param>
        public void RegClick(Control ctrl, string funcname)
        {
            ctrl.MouseDown += (object s, MouseEventArgs a) =>
            {
                if (a.Button == MouseButtons.Left)
                {
                    mod($"{funcname}()");
                }
            };
        }

        /// <summary>
        /// Creates a ShiftOS window.
        /// </summary>
        /// <param name="title">Window title.</param>
        /// <param name="img">Window icon</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <returns>The new window</returns>
        public Form CreateForm(string title, Image img, int width, int height)
        {
            GC.Collect();
            //Create new Form instance.
            var f = new Form();
            //Set size of form
            if(width < 100)
            {
                width = 100;
            }
            if(height < 100)
            {
                height = 100;
            }
            f.Size = new Size(width, height);
            //ShiftOSify it.
            API.CreateForm(f, title, img);
            //Add to list of forms that should be closed on script exit
            OpenForms.Add(f);
            //Return it.
            return f;
        }

        /// <summary>
        /// Creates a borderless window.
        /// </summary>
        /// <param name="x">Starting X coordinate.</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <returns>The new window.</returns>
        public Form CreateForm(int x, int y, int width, int height)
        {
            GC.Collect();
            //Create new Form instance.
            var f = new Form();
            //Set size of form
            if (width < 100)
            {
                width = 100;
            }
            if (height < 100)
            {
                height = 100;
            }
            f.Size = new Size(width, height);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Location = new Point(x, y);
            f.Show();
            //Add to list of forms that should be closed on script exit
            OpenForms.Add(f);
            //Return it.
            return f;
        }

        /// <summary>
        /// Opens an image file.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Loaded image</returns>
        public Image OpenLocalImage(string filepath)
        {
            if (filepath.StartsWith("/"))
            {
                var real = $"{ThisDirectory}{filepath.Replace("/", OSInfo.DirectorySeparator)}";
                if (File.Exists(real))
                {
                    try
                    {
                        return Image.FromFile(real);
                    }
                    catch (Exception ex)
                    {
                        Errors.Add(ex.Message);
                        return null;
                    }

                }
                else
                {
                    Errors.Add($"open_image({filepath}): File not found.");
                    return null;
                }
            }
            else
            {
                Errors.Add($"open_image({filepath}): Not a valid file path.");
                return null;
            }
        }

        /// <summary>
        /// Opens an image file.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Loaded image</returns>
        public Image OpenImage(string filepath)
        {
            if (filepath.StartsWith("/"))
            {
                var real = $"{Paths.SaveRoot}{filepath.Replace("/", OSInfo.DirectorySeparator)}";
                if(File.Exists(real))
                {
                    try
                    {
                        return Image.FromFile(real);
                    }
                    catch (Exception ex)
                    {
                        Errors.Add(ex.Message);
                        return null;
                    }

                }
                else
                {
                    Errors.Add($"open_image({filepath}): File not found.");
                    return null;
                }
            }
            else
            {
                Errors.Add($"open_image({filepath}): Not a valid file path.");
                return null;
            }
        }
    }

    public class Beeper
    {
        static Thread _beepThread;
        static AutoResetEvent _signalBeep;
        static bool _beeping = false;

        static Beeper()
        {
            _signalBeep = new AutoResetEvent(false);
            _beepThread = new Thread(() =>
            {
                for (;;)
                {
                    while(_beeping == true)
                    {

                    }
                    _beeping = true;
                    Thread.Sleep(_freq);
                    Console.Beep(_freq, _dur);
                    _beeping = false;
                }

            }, 1);
            _beepThread.IsBackground = true;
            _beepThread.Start();
        }
        static int _freq = 38;
        static int _dur = 1000;

        public static void Play(int freq, int dur)
        {
            _freq = freq;
            if (_freq <= 37)
            {
                _freq = 38;
            }

            _dur = dur;
            _signalBeep.Set();
        }
    }


}
