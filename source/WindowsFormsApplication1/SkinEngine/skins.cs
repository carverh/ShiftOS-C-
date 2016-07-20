using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System;
using ShiftOS;
using System.IO.Compression;
using ShiftUI;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Skinning
{
    public class Skin : ShiftUI.ShiftOS.Skin
    {
        //ShiftUI inherits: Anything marked with 'public new' is inherited
        //from ShiftUI.ShiftOS.Skin, and is marked this way to provide a
        //default value that JSON.NET can deserialize but also have
        //ShiftUI see it.

        

        public new Color ButtonBackColor_Pressed = Color.Black;

        public new Color ProgressBar_BackgroundColor = Color.Black;
        //Widget Positions
        public string ALPosition = "Top";
        public string PanelButtonPosition = "Top";
        public string ClockPosition = "Top";

        //WINDOW SETTINGS/IMAGES
        //images
        public new int titlebarlayout = 3;
        public new int borderleftlayout = 3;
        public new int borderrightlayout = 3;
        public new int borderbottomlayout = 3;
        public new int closebtnlayout = 3;
        public new int rollbtnlayout = 3;
        public new int minbtnlayout = 3;
        public new int rightcornerlayout = 3;
        public new int leftcornerlayout = 3;
        // Late entry: need to fix window code to include this
        public new int bottomleftcornerlayout = 3;
        public new int bottomrightcornerlayout = 3;
        public new Color bottomleftcornercolour = Color.Gray;

        public new Color bottomrightcornercolour = Color.Gray;

        public new bool enablebordercorners = false;
        // settings
        public new Size closebtnsize = new Size(22, 22);
        public new Size rollbtnsize = new Size(22, 22);
        public new Size minbtnsize = new Size(22, 22);
        public new int titlebarheight = 30;
        public new int titlebariconsize = 16;
        public new int closebtnfromtop = 5;
        public new int closebtnfromside = 2;
        public new int rollbtnfromtop = 5;
        public new int rollbtnfromside = 26;
        public new int minbtnfromtop = 5;
        public new int minbtnfromside = 52;
        public new int borderwidth = 2;
        public new bool enablecorners = false;
        public new int titlebarcornerwidth = 5;
        public new int titleiconfromside = 4;
        public new int titleiconfromtop = 4;
        //colours
        public new Color titlebarcolour = Color.Gray;
        public new Color borderleftcolour = Color.Gray;
        public new Color borderrightcolour = Color.Gray;
        public new Color borderbottomcolour = Color.Gray;
        public new Color closebtncolour = Color.Black;
        public new Color closebtnhovercolour = Color.Black;
        public new Color closebtnclickcolour = Color.Black;
        public new Color rollbtncolour = Color.Black;
        public new Color rollbtnhovercolour = Color.Black;
        public new Color rollbtnclickcolour = Color.Black;
        public new Color minbtncolour = Color.Black;
        public new Color minbtnhovercolour = Color.Black;
        public new Color minbtnclickcolour = Color.Black;
        public new Color rightcornercolour = Color.Gray;
        public new Color leftcornercolour = Color.Gray;
        // Text
        public new string titletextfontfamily = "Microsoft Sans Serif";
        public new int titletextfontsize = 10;
        public new FontStyle titletextfontstyle = FontStyle.Bold;
        public new string titletextpos = "Left";
        public new int titletextfromtop = 3;
        public new int titletextfromside = 24;

        public new Color titletextcolour = Color.White;
        //DESKTOP
        public Color desktoppanelcolour = Color.Gray;
        public Color desktopbackgroundcolour = Color.Black;
        public int desktoppanelheight = 24;
        public string desktoppanelposition = "Top";
        public Color clocktextcolour = Color.Black;
        public Color clockbackgroundcolor = Color.Gray;
        public int panelclocktexttop = 3;
        public int panelclocktextsize = 10;
        public string panelclocktextfont = "Byington";
        public FontStyle panelclocktextstyle = FontStyle.Bold;
        public Color applauncherbuttoncolour = Color.Gray;
        public Color applauncherbuttonclickedcolour = Color.Gray;
        public Color applauncherbackgroundcolour = Color.Gray;
        public Color applaunchermouseovercolour = Color.Gray;
        public Color applicationsbuttontextcolour = Color.Black;
        public int applicationbuttonheight = 24;
        public int applicationbuttontextsize = 10;
        public string applicationbuttontextfont = "Byington";
        public FontStyle applicationbuttontextstyle = FontStyle.Bold;
        public string applicationlaunchername = "Applications";
        public string titletextposition = "Left";
        public int applaunchermenuholderwidth = 100;
        public int panelbuttonicontop = 3;
        public int panelbuttoniconside = 4;
        public int panelbuttoniconsize = 16;
        public int panelbuttonheight = 20;
        public int panelbuttonwidth = 185;
        public Color panelbuttoncolour = Color.Black;
        public Color panelbuttontextcolour = Color.White;
        public int panelbuttontextsize = 10;
        public string panelbuttontextfont = "Byington";
        public FontStyle panelbuttontextstyle = FontStyle.Regular;
        public int panelbuttontextside = 16;
        public int panelbuttontexttop = 2;
        public int panelbuttongap = 4;
        public int panelbuttonfromtop = 2;

        public int panelbuttoninitialgap = 8;
        public int launcheritemsize = 10;
        public string launcheritemfont = "Byington";
        public FontStyle launcheritemstyle = FontStyle.Regular;

        public Color launcheritemcolour = Color.Black;
        // Images
        public int desktoppanellayout = 3;
        public int desktopbackgroundlayout = 3;
        public int panelclocklayout = 3;
        public int applauncherlayout = 3;

        public int panelbuttonlayout = 3;
        
        //Locations...

        public int userTextboxX = 171;
        public int userTextBoxY = 202;
        public int passTextBoxX = 171;
        public int passTextBoxY = 243;
        public int loginbtnX = 268;
        public int loginbtnY = 286;
        public int shutdownbtnX = 1755;

        public int shutdownbtnY = 979;

        /* IMAGE PATHS
        These tell ShiftOS where skin images are.
        */

        public string applauncherclickpath = null;
        public string panelbuttonpath = null;
        public string applaunchermouseoverpath = null;
        public string applauncherpath = null;
        public string panelclockpath = null;
        public string desktopbackgroundpath = null;
        public string desktoppanelpath = null;
        public string minbtnhoverpath = null;
        public string minbtnclickpath = null;
        public string rightcornerpath = null;
        public string titlebarpath = null;
        public string borderrightpath = null;
        public string borderleftpath = null;
        public string borderbottompath = null;
        public string closebtnpath = null;
        public string closebtnhoverpath = null;
        public string closebtnclickpath = null;
        public string rollbtnpath = null;
        public string rollbtnhoverpath = null;
        public string rollbtnclickpath = null;
        public string minbtnpath = null;
        public string leftcornerpath = null;
        public string bottomleftcornerpath = null;
        public string bottomrightcornerpath = null;

        //Menu Renderer Colors
        public Color Menu_ButtonSelectedHighlight = Color.Black;
        public Color Menu_ButtonSelectedHighlightBorder = Color.Black;
        public Color Menu_ButtonPressedHighlight = Color.Black;
        public Color Menu_ButtonPressedHighlightBorder = Color.Black;
        public Color Menu_ButtonCheckedHighlight = Color.White;
        public Color Menu_ButtonCheckedHighlightBorder = Color.White;
        public Color Menu_ButtonPressedBorder = Color.Black;
        public Color Menu_ButtonSelectedBorder = Color.Black;
        public Color Menu_ButtonCheckedGradientBegin = Color.White;
        public Color Menu_ButtonCheckedGradientMiddle = Color.White;
        public Color Menu_ButtonCheckedGradientEnd = Color.White;
        public Color Menu_ButtonSelectedGradientBegin = Color.Black;
        public Color Menu_ButtonSelectedGradientMiddle = Color.Black;
        public Color Menu_ButtonSelectedGradientEnd = Color.Black;
        public Color Menu_ButtonPressedGradientBegin = Color.Black;
        public Color Menu_ButtonPressedGradientMiddle = Color.Black;
        public Color Menu_ButtonPressedGradientEnd = Color.Black;
        public Color Menu_CheckBackground = Color.White;
        public Color Menu_CheckSelectedBackground = Color.Gray;
        public Color Menu_CheckPressedBackground = Color.White;
        public Color Menu_ImageMarginGradientBegin = Color.Gray;
        public Color Menu_ImageMarginGradientMiddle = Color.Gray;
        public Color Menu_ImageMarginGradientEnd = Color.Gray;
        public Color Menu_MenuStripGradientBegin = Color.Gray;
        public Color Menu_MenuStripGradientEnd = Color.Gray;
        public Color Menu_MenuItemSelected = Color.Black;
        public Color Menu_MenuItemBorder = Color.Gray;
        public Color Menu_MenuBorder = Color.Gray;
        public Color Menu_MenuItemSelectedGradientBegin = Color.Black;
        public Color Menu_MenuItemSelectedGradientEnd = Color.Black;
        public Color Menu_MenuItemPressedGradientBegin = Color.Black;
        public Color Menu_MenuItemPressedGradientMiddle = Color.Black;
        public Color Menu_MenuItemPressedGradientEnd = Color.Black;
        public Color Menu_RaftingContainerGradientBegin = Color.Black;
        public Color Menu_RaftingContainerGradientEnd = Color.Gray;
        public Color Menu_SeparatorDark = Color.Black;
        public Color Menu_SeparatorLight = Color.Black;
        public Color Menu_StatusStripGradientBegin = Color.Gray;
        public Color Menu_StatusStripGradientEnd = Color.Gray;
        public Color Menu_ToolStripBorder = Color.Gray;
        public Color Menu_ToolStripDropDownBackground = Color.Gray;
        public Color Menu_ToolStripGradientBegin = Color.Gray;
        public Color Menu_ToolStripGradientMiddle = Color.Gray;
        public Color Menu_ToolStripGradientEnd = Color.Gray;
        public Color Menu_ToolStripContentPanelGradientBegin = Color.Gray;
        public Color Menu_ToolStripContentPanelGradientEnd = Color.Gray;
        public Color Menu_ToolStripPanelGradientBegin = Color.Gray;
        public Color Menu_ToolStripPanelGradientEnd = Color.Gray;
        public Color Menu_TextColor = Color.White;

        //New
        public Color TerminalTextColor = Color.White;
        public Color TerminalBackColor = Color.Black;
        public string TerminalFontStyle = OSInfo.GetMonospaceFont();

        //Name Packs
        public string EmbeddedNamePackPath = "names.npk";

        //Desktop Icons
        public Color IconTextColor = Color.White;

        //Window Animation
        public int WindowFadeTime = 1; //Interval between each decrease in opacity
        public decimal WindowFadeSpeed = Convert.ToDecimal(0.1); //Speed of opacity decrease
        public WindowAnimationStyle WindowCloseAnimation = WindowAnimationStyle.Fade; //Animation style for close
        public WindowAnimationStyle WindowOpenAnimation = WindowAnimationStyle.Fade; //Animation style for open
        public WindowDragEffect DragAnimation = WindowDragEffect.Fade;
        public double DragFadeLevel = 0.5;
        public double DragFadeSpeed = 0.1;
        public int DragFadeInterval = 1;

        //Shake
        public int ShakeSpeed = 10;
        public int ShakeMaxOffset = 250;
        public int ShakeMinOffset = 0;

        //Desktop Panel
        public List<DesktopWidget> Widgets = new List<DesktopWidget>();
        public List<DesktopPanel> DesktopPanels = new List<DesktopPanel>();
    }

    public class DesktopWidget
    {
        public string Name { get; set; }
        public string Panel { get; set; } //either top or bottom
        public string Icon { get; set; }
        public int Width { get; set; }
        public int XLocation { get; set; }
        public WidgetType Type { get; set; }
        public string Lua { get; set; }
    }

    public class ShiftOSIcon
    {
        /// <summary>
        /// Creates a new icon
        /// </summary>
        /// <param name="id">New ID</param>
        public ShiftOSIcon(string id)
        {
            SmallPath = id + "_small";
            LargePath = id + "_large";
        }

        public string SmallPath { get; set; }
        public string LargePath { get; set; }
    }

    public class DesktopPanel
    {
        public string Position = "Top";
        public int Height = 24;
        public Color BackgroundColor = Color.Gray;
        public Image BackgroundImage = null;
        public string ImagePath = null;
    }

    public class PanelWidget
    {
        public string type = "applauncher";
    }

    public class NamePack
    {
        public string TerminalName = "Terminal";
        public string ArtpadName = "Artpad";
        public string TextpadName = "TextPad";
        public string ShiftoriumName = "Shiftorium";
        public string KnowledgeInputName = "Knowledge Input";
        public string PongName = "Pong";
        public string ShifterName = "Shifter";
        public string FileSkimmerName = "File Skimmer";
        public string SkinLoaderName = "Skin Loader";
        public string ShutdownName = "Shut Down";
        public string UnityName = "Unity Mode";
        public string NameChangerName = "Name Changer";
    }

    public class IconSet
    {
        public Image Terminal = ShiftOS.Properties.Resources.iconTerminal;
        public Image Artpad = ShiftOS.Properties.Resources.iconArtpad;
        public Image Textpad = ShiftOS.Properties.Resources.iconTextPad;
        public Image Shiftorium = ShiftOS.Properties.Resources.iconShiftorium;
        public Image KnowledgeInput = ShiftOS.Properties.Resources.iconKnowledgeInput;
        public Image Pong = ShiftOS.Properties.Resources.iconPong;
        public Image Shifter = ShiftOS.Properties.Resources.iconShifter;
        public Image FileSkimmer = ShiftOS.Properties.Resources.iconFileSkimmer;
        public Image SkinLoader = ShiftOS.Properties.Resources.iconSkinLoader;
        public Image Shutdown = ShiftOS.Properties.Resources.iconshutdown;
        public Image Unity = ShiftOS.Properties.Resources.iconunitytoggle;
        public Image NameChanger = ShiftOS.Properties.Resources.iconNameChanger;

    }

    public class IconPack
    {
        public string Terminal = "Terminal";
        public string Artpad = "Artpad";
        public string Textpad = "TextPad";
        public string Shiftorium = "Shiftorium";
        public string KnowledgeInput = "Knowledge Input";
        public string Pong = "Pong";
        public string Shifter = "Shifter";
        public string FileSkimmer = "File Skimmer";
        public string SkinLoader = "Skin Loader";
        public string Shutdown = "Shut Down";
        public string Unity = "Unity Mode";
        public string NameChanger = "Name Changer";

    }

    public class Images
    {
        public Image applauncherclick = null;
        public Image panelbutton = null;
        public Image applaunchermouseover = null;
        public Image applauncher = null;
        public Image panelclock = null;
        public Image desktopbackground = null;
        public Image desktoppanel = null;
        public Image minbtnhover = null;
        public Image minbtnclick = null;
        public Image rightcorner = null;
        public Image titlebar = null;
        public Image borderright = null;
        public Image borderleft = null;
        public Image borderbottom = null;
        public Image closebtn = null;
        public Image closebtnhover = null;
        public Image closebtnclick = null;
        public Image rollbtn = null;
        public Image rollbtnhover = null;
        public Image rollbtnclick = null;
        public Image minbtn = null;
        public Image leftcorner = null;
        public Image bottomleftcorner = null;
        public Image bottomrightcorner = null;
    }
    /// <summary>
    /// ShiftOS 'Sharp' Skin Engine - Completely reworked ShiftOS skin system written in C# by Michael VanOverbeek
    /// </summary>
    public class Utilities {
        public static Dictionary<string, Image> IconRegistry = new Dictionary<string, Image>();
        public static Color globaltransparencycolour = Color.FromArgb(1, 0, 1);
        public static NamePack LoadedNames = null;
        public static Skin loadedSkin = null;
        public static Images loadedskin_images = null;

        /// <summary>
        /// Load a bitmap from the skin.
        /// </summary>
        /// <param name="fileName">Bitmap name.</param>
        /// <returns>The bitmap</returns>
        public static Bitmap GetImage(string fileName)
        {
            Bitmap ret;
            if (File.Exists(Paths.LoadedSkin + fileName))
            {
                using (Image img = Image.FromFile(Paths.LoadedSkin + fileName))
                {
                    ret = new Bitmap(img);
                }
            } else
            {
                ret = null;
            }
            return ret;
        }

        /// <summary>
        /// Load the name pack embedded in the skin.
        /// </summary>
        public static void LoadEmbeddedNamePack()
        {
            if(loadedSkin != null)
            {
                if(loadedSkin.EmbeddedNamePackPath != null)
                {
                    if(File.Exists(Paths.LoadedSkin + loadedSkin.EmbeddedNamePackPath))
                    {
                        string json = File.ReadAllText(Paths.LoadedSkin + loadedSkin.EmbeddedNamePackPath);
                        LoadedNames = JsonConvert.DeserializeObject<NamePack>(json);
                        try {
                            //bug-check
                            if (LoadedNames.NameChangerName == null)
                            {
                                LoadedNames.NameChangerName = "Name Changer";
                            }
                        }
                        catch
                        {
                            LoadedNames = new NamePack();
                        }
                    }
                    else
                    {
                        LoadedNames = new NamePack();
                    }
                }
                else
                {
                    LoadedNames = new NamePack();
                }
            }
            else
            {
                LoadedNames = new NamePack();
            }
        }

        /// <summary>
        /// Loads background images for all desktop panels
        /// </summary>
        public static void LoadPanels()
        {
            foreach(var pnl in loadedSkin.DesktopPanels)
            {
                string dpath = Paths.LoadedSkin + "panels" + OSInfo.DirectorySeparator + pnl.ImagePath;
                if (File.Exists(dpath))
                {
                    pnl.BackgroundImage = Image.FromFile(dpath);
                }
            }
        }
        
        /// <summary>
        /// Saves background images of panels
        /// </summary>
        public static void SavePanels()
        {
            string dir = Paths.LoadedSkin + "panels";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            foreach (var pnl in loadedSkin.DesktopPanels)
            {
                if (pnl.BackgroundImage != null)
                {
                    try
                    {
                        pnl.ImagePath = pnl.Position + loadedSkin.DesktopPanels.IndexOf(pnl).ToString();
                        string dpath = Paths.LoadedSkin + "panels" + OSInfo.DirectorySeparator + pnl.ImagePath;
                        pnl.BackgroundImage.Save(dpath);
                        pnl.BackgroundImage = null;
                    }
                    catch
                    {
                        pnl.ImagePath = null;
                        pnl.BackgroundImage = null;
                    }
                }
            }
        }
        /// <summary>
        /// Randomize some skin variables. Used for a virus.
        /// </summary>
        public static void Randomize()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 5000) == 25)
            {
                loadedSkin.desktoppanelheight = rnd.Next(2, 200);
                switch (rnd.Next(0, 10))
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                        loadedSkin.desktoppanelposition = "Top";
                        break;
                    default:
                        loadedSkin.desktoppanelposition = "Bottom";
                        break;
                }
                API.CurrentSession.SetupDesktop();
                API.UpdateWindows();
            }
        }

        /// <summary>
        /// Save the loaded name pack to the skin.
        /// </summary>
        public static void SaveEmbeddedNamePack()
        {
            if (loadedSkin != null)
            {
                if (loadedSkin.EmbeddedNamePackPath != null)
                {
                    if (File.Exists(Paths.LoadedSkin + loadedSkin.EmbeddedNamePackPath))
                    {
                        string json = JsonConvert.SerializeObject(LoadedNames);
                        File.WriteAllText(Paths.LoadedSkin + loadedSkin.EmbeddedNamePackPath, json);
                    }
                    else
                    {
                        loadedSkin.EmbeddedNamePackPath = "names.npk";
                        string json = JsonConvert.SerializeObject(LoadedNames);
                        File.WriteAllText(Paths.LoadedSkin + loadedSkin.EmbeddedNamePackPath, json);
                    }
                }
                
            }
        }

        /// <summary>
        /// Save a bitmap to the skin.
        /// </summary>
        /// <param name="img">Bitmap to save</param>
        /// <param name="Name">New filename</param>
        private static void saveimage(Image img, string Name)
        {
            string fullPath = Paths.LoadedSkin + Name;
            if(File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            if (img != null)
            {
                img.Save(fullPath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        /// <summary>
        /// Load the skin.
        /// </summary>
        public static void loadskin()
        {
            if (Directory.Exists(Paths.LoadedSkin))
            {
                string rawData = File.ReadAllText(Paths.LoadedSkin + "data.json");
                loadedSkin = JsonConvert.DeserializeObject<Skin>(rawData);
                if (File.Exists(Paths.LoadedSkin + "panels.json"))
                {
                    try
                    {
                        string panels = File.ReadAllText(Paths.LoadedSkin + "panels.json");
                        loadedSkin.DesktopPanels = JsonConvert.DeserializeObject<List<DesktopPanel>>(panels);
                        Application.LoadSkin(loadedSkin); //Send the skin to ShiftUI so buttons and stuff get rendered with custom colors.
                        LoadPanels();
                    }
                    catch
                    {

                    }
                }
                loadimages();
                LoadEmbeddedNamePack();

            }
            else
            {
                loadedSkin = new Skin();
                loadedskin_images = new Images();
                saveskin();
            }
        }

        /// <summary>
        /// Load skin from .skn file
        /// </summary>
        /// <param name="filepath">File to load.</param>
        public static void loadsknfile(string filepath)
        {
            try
            {
                //Extract the .SKN
                loadedSkin = new Skin();
                loadedskin_images = new Images();
                API.ExtractFile(filepath, Paths.LoadedSkin, true);
                //OK, so the skin's been extracted.
                //Now, let's load in the skin data.
                string rawData = File.ReadAllText(Paths.LoadedSkin + "data.json");
                loadedSkin = JsonConvert.DeserializeObject<Skin>(rawData);
                //Now, images.
                loadimages();
            } catch
            {
                API.CreateInfoboxSession("Error loading skin", "An error has occurred while loading the skin file. This could be because the skin file is no longer supported by this version of ShiftOS.", infobox.InfoboxMode.Info);
            }
        }

        /// <summary>
        /// Load images from the skin.
        /// </summary>
        public static void loadimages()
        {
            loadedskin_images = new Images();
            loadedskin_images.applauncherclick = GetImage(loadedSkin.applauncherclickpath);
            loadedskin_images.panelbutton = GetImage(loadedSkin.panelbuttonpath);
            loadedskin_images.applaunchermouseover = GetImage(loadedSkin.applaunchermouseoverpath);
            loadedskin_images.applauncher = GetImage(loadedSkin.applauncherpath);
            loadedskin_images.panelclock = GetImage(loadedSkin.panelclockpath);
            loadedskin_images.desktopbackground = GetImage(loadedSkin.desktopbackgroundpath);
            loadedskin_images.desktoppanel = GetImage(loadedSkin.desktoppanelpath);
            loadedskin_images.minbtnhover = GetImage(loadedSkin.minbtnhoverpath);
            loadedskin_images.minbtnclick = GetImage(loadedSkin.minbtnclickpath);
            loadedskin_images.rightcorner = GetImage(loadedSkin.rightcornerpath);
            loadedskin_images.titlebar = GetImage(loadedSkin.titlebarpath);
            loadedskin_images.borderright = GetImage(loadedSkin.borderrightpath);
            loadedskin_images.borderleft = GetImage(loadedSkin.borderleftpath);
            loadedskin_images.borderbottom = GetImage(loadedSkin.borderbottompath);
            loadedskin_images.closebtn = GetImage(loadedSkin.closebtnpath);
            loadedskin_images.closebtnhover = GetImage(loadedSkin.closebtnhoverpath);
            loadedskin_images.closebtnclick = GetImage(loadedSkin.closebtnclickpath);
            loadedskin_images.rollbtn = GetImage(loadedSkin.rollbtnpath);
            loadedskin_images.rollbtnhover = GetImage(loadedSkin.rollbtnhoverpath);
            loadedskin_images.rollbtnclick = GetImage(loadedSkin.rollbtnclickpath);
            loadedskin_images.minbtn = GetImage(loadedSkin.minbtnpath);
            loadedskin_images.leftcorner = GetImage(loadedSkin.leftcornerpath);
            loadedskin_images.bottomleftcorner = GetImage(loadedSkin.bottomleftcornerpath);
            loadedskin_images.bottomrightcorner = GetImage(loadedSkin.bottomrightcornerpath);
            try
            {
                IconRegistry = new Dictionary<string, Image>();
                foreach (var f in Directory.GetFiles(Paths.Icons))
                {
                    var finf = new FileInfo(f);
                    byte[] fBytes = File.ReadAllBytes(finf.FullName);
                    MemoryStream fStream = new MemoryStream(fBytes);
                    IconRegistry.Add(finf.Name, Image.FromStream(fStream));
                    fStream.Close();
                }
            }
            catch
            {
                GenDefaultIconPack();
            }
        }

        /// <summary>
        /// Generates the default icon pack if none exists.
        /// </summary>
        public static void GenDefaultIconPack()
        {
            IconRegistry = new Dictionary<string, Image>();
            if(Directory.Exists(Paths.Icons))
            {
                Directory.Delete(Paths.Icons, true);
            }
            Directory.CreateDirectory(Paths.Icons);
            SaveIcon(ShiftOS.Properties.Resources.iconTerminal, "Terminal");
            SaveIcon(ShiftOS.Properties.Resources.iconShiftorium, "Shiftorium");
            SaveIcon(ShiftOS.Properties.Resources.iconShifter, "Shifter");
            SaveIcon(ShiftOS.Properties.Resources.iconNameChanger, "NameChanger");
            SaveIcon(ShiftOS.Properties.Resources.iconTextPad, "TextPad");
            SaveIcon(ShiftOS.Properties.Resources.iconFileSkimmer, "FileSkimmer");
            SaveIcon(ShiftOS.Properties.Resources.iconArtpad, "Artpad");
            SaveIcon(ShiftOS.Properties.Resources.iconunitytoggle, "Unity");
            SaveIcon(ShiftOS.Properties.Resources.iconshutdown, "Shutdown");
            SaveIcon(ShiftOS.Properties.Resources.iconInfoBox_fw, "Infobox");
            SaveIcon(ShiftOS.Properties.Resources.iconKnowledgeInput, "KI");
            SaveIcon(ShiftOS.Properties.Resources.iconPong, "Pong");
            SaveIcon(ShiftOS.Properties.Resources.iconSkinLoader, "SkinLoader");
            SaveIcon(ShiftOS.Properties.Resources.iconIconManager, "IconManager");
            SaveIcon(ShiftOS.Properties.Resources.fileicondirectory, "Folder");
            SaveIcon(ShiftOS.Properties.Resources.fileicondoc, "TextFile");
            SaveIcon(ShiftOS.Properties.Resources.fileiconnone, "UnrecognizedFile");
            SaveIcon(ShiftOS.Properties.Resources.fileiconsaa, "SAAFile");
            SaveIcon(ShiftOS.Properties.Resources.fileiconsetup, "SetupPackage");
            SaveIcon(ShiftOS.Properties.Resources.skinfile, "SkinFile");
            IconRegistry = new Dictionary<string, Image>();
            foreach (var f in Directory.GetFiles(Paths.Icons))
            {
                var finf = new FileInfo(f);
                byte[] fBytes = File.ReadAllBytes(finf.FullName);
                MemoryStream fStream = new MemoryStream(fBytes);
                IconRegistry.Add(finf.Name, Image.FromStream(fStream));
                fStream.Close();
            }
        }

        /// <summary>
        /// Saves the icon to the registry.
        /// </summary>
        /// <param name="img">Icon to save</param>
        /// <param name="title">Icon title</param>
        public static void SaveIcon(Image img, string title)
        {
            img.Save(Paths.Icons + title, ImageFormat.Png);

        } 

        /// <summary>
        /// Saves all skin images
        /// </summary>
        public static void saveimages()
        {
            //Set image paths.
            loadedSkin.applauncherclickpath = "applauncherclick";
            loadedSkin.panelbuttonpath = "panelbutton";
            loadedSkin.applaunchermouseoverpath = "applaunchermouseover";
            loadedSkin.applauncherpath = "applauncher";
            loadedSkin.panelclockpath = "panelclock";
            loadedSkin.desktopbackgroundpath = "desktopbackground";
            loadedSkin.desktoppanelpath = "desktoppanel";
            loadedSkin.minbtnhoverpath = "minbtnhover";
            loadedSkin.minbtnclickpath = "minbtnclick";
            loadedSkin.rightcornerpath = "rightcorner";
            loadedSkin.titlebarpath = "titlebar";
            loadedSkin.borderrightpath = "borderright";
            loadedSkin.borderleftpath = "borderleft";
            loadedSkin.borderbottompath = "borderbottom";
            loadedSkin.closebtnpath = "closebtn";
            loadedSkin.closebtnhoverpath = "closebtnhover";
            loadedSkin.closebtnclickpath = "closebtnclick";
            loadedSkin.rollbtnpath = "rollbtn";
            loadedSkin.rollbtnhoverpath = "rollbtnhover";
            loadedSkin.rollbtnclickpath = "rollbtnclick";
            loadedSkin.minbtnpath = "minbtn";
            loadedSkin.leftcornerpath = "leftcornerpath";
            loadedSkin.bottomleftcornerpath = "bottomleftcorner";
            loadedSkin.bottomrightcornerpath = "bottomrightcorner";
            //Save to new paths.
            saveimage(loadedskin_images.applauncherclick, loadedSkin.applauncherclickpath);
            saveimage(loadedskin_images.panelbutton, loadedSkin.panelbuttonpath);
            saveimage(loadedskin_images.applaunchermouseover, loadedSkin.applaunchermouseoverpath);
            saveimage(loadedskin_images.applauncher, loadedSkin.applauncherpath);
            saveimage(loadedskin_images.panelclock, loadedSkin.panelclockpath);
            saveimage(loadedskin_images.desktopbackground, loadedSkin.desktopbackgroundpath);
            saveimage(loadedskin_images.desktoppanel, loadedSkin.desktoppanelpath);
            saveimage(loadedskin_images.minbtnhover, loadedSkin.minbtnhoverpath);
            saveimage(loadedskin_images.minbtnclick, loadedSkin.minbtnclickpath);
            saveimage(loadedskin_images.rightcorner, loadedSkin.rightcornerpath);
            saveimage(loadedskin_images.titlebar, loadedSkin.titlebarpath);
            saveimage(loadedskin_images.borderright, loadedSkin.borderrightpath);
            saveimage(loadedskin_images.borderleft, loadedSkin.borderleftpath);
            saveimage(loadedskin_images.borderbottom, loadedSkin.borderbottompath);
            saveimage(loadedskin_images.closebtn, loadedSkin.closebtnpath);
            saveimage(loadedskin_images.closebtnhover, loadedSkin.closebtnhoverpath);
            saveimage(loadedskin_images.closebtnclick, loadedSkin.closebtnclickpath);
            saveimage(loadedskin_images.rollbtn, loadedSkin.rollbtnpath);
            saveimage(loadedskin_images.rollbtnhover, loadedSkin.rollbtnhoverpath);
            saveimage(loadedskin_images.rollbtnclick, loadedSkin.rollbtnclickpath);
            saveimage(loadedskin_images.minbtn, loadedSkin.minbtnpath);
            saveimage(loadedskin_images.leftcorner, loadedSkin.leftcornerpath);
            saveimage(loadedskin_images.bottomleftcorner, loadedSkin.bottomleftcornerpath);
            saveimage(loadedskin_images.bottomrightcorner, loadedSkin.bottomrightcornerpath);
            foreach(KeyValuePair<string, Image> kv in IconRegistry)
            {
                if(kv.Value != null)
                {
                    SaveIcon(kv.Value, kv.Key);
                }
            }

        }

        /// <summary>
        /// Saves the skin to a new .skn file
        /// </summary>
        /// <param name="filePath">Target .skn file</param>
        public static void saveskintofile(string filePath)
        {
            saveskin();
            ZipFile.CreateFromDirectory(Paths.LoadedSkin, filePath);
        }

        /// <summary>
        /// Saves the skin.
        /// </summary>
        public static void saveskin()
        {
            saveimages();
            string rawjson = JsonConvert.SerializeObject(loadedSkin);
            File.WriteAllText(Paths.LoadedSkin + "data.json", rawjson);
            SavePanels();
            string panels = JsonConvert.SerializeObject(loadedSkin.DesktopPanels);
            File.WriteAllText(Paths.LoadedSkin + "panels.json", panels);
            SaveEmbeddedNamePack();
        }
    }

    public class MyToolStripRenderer : ToolStripProfessionalRenderer
    {
        public MyToolStripRenderer() : base(new ShiftOSColorTable())
        {
            
        }

        public MyToolStripRenderer(ProfessionalColorTable table) : base(table)
        {

        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Text == API.CurrentSkin.applicationlaunchername)
            {
                e.TextColor = API.CurrentSkin.applicationsbuttontextcolour;
            }
            else {
                e.TextColor = API.CurrentSkin.Menu_TextColor;
            }
            base.OnRenderItemText(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        
    }
}