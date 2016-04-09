using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms; //Message boxes
namespace SaveSystem
{
    /// <summary>
    /// This does NOT include Shiftorium upgrades. See the Shiftorium Repository for them.
    /// </summary>
    public class Save
    {
        public int codepoints = 0;
        public bool forceclose = false;
        public int movablewindownumber = 50;
        public bool terminalfullscreen = true;
        public bool newgame = true;
        public string actualshiftversion = "0.1.1"; //ShiftOS 0.0.x died a peaceful death last June.
        public string username = "user";
        public string TerminalName = "Terminal";
        public string ShiftoriumName = "Shiftorium";
        public string osname = "shiftos";
        public string ingameversion = "0.0.1.0";
        public string ColorPickerName = "Color Picker";
        public string FileSkimmerName = "File Skimmer";
        public string password;
        public bool ChristmasRewardPast = false;
        public int CodepointMultiplier = 1;
        public int PriceDivider = 1;
        public string CloudID = "";
    }

    public class PrivateBitnoteAddress
    {
        public string Address = null;
        public decimal Bitnotes = 0;
    }

    public class Utilities
    {
        public static Save LoadedSave = null;
        public static PrivateBitnoteAddress BitnoteAddress = null;

        /// <summary>
        /// Load the game.
        /// </summary>
        public static void loadGame()
        {
            ShiftoriumRegistry.UpdateShiftorium();
            string rawjson = File.ReadAllText(Paths.SaveFile);
            if (rawjson.StartsWith("{"))
            {
                LoadedSave = JsonConvert.DeserializeObject<Save>(rawjson);
            } else
            {
                LoadedSave = JsonConvert.DeserializeObject<Save>(API.Encryption.Decrypt(rawjson));
            }
            LoadBTNAddress();
            Hacking.GetCharacters();
        }

        /// <summary>
        /// Load the user's private bitnote address.
        /// </summary>
        public static void LoadBTNAddress()
        {
            if(File.Exists(Paths.Bitnote))
            {
                BitnoteAddress = JsonConvert.DeserializeObject<PrivateBitnoteAddress>(API.BitnoteEncryption.Decrypt(File.ReadAllText(Paths.Bitnote)));
                
            }
            else
            {
                BitnoteAddress = new PrivateBitnoteAddress();
                BitnoteAddress.Bitnotes = 0;
                BitnoteAddress.Address = GenerateNewBitnoteAddress();
            }
        }

        /// <summary>
        /// Generate a random bitnote address.
        /// </summary>
        /// <returns>The address.</returns>
        public static string GenerateNewBitnoteAddress()
        {
            var rnd = new Random();
            int raw = rnd.Next(10000000, 99999999);
            string enc = API.Encryption.Encrypt(raw.ToString());
            return enc.Replace("/", "").Replace("\\", "").Replace("=", "");
        }

        /// <summary>
        /// Saves the private bitnote address.
        /// </summary>
        public static void SaveBitnoteAddress()
        {
            File.WriteAllText(Paths.Bitnote, API.BitnoteEncryption.Encrypt(JsonConvert.SerializeObject(BitnoteAddress)));
        }

        /// <summary>
        /// Saves the game.
        /// </summary>
        public static void saveGame()
        {
            string rawjson = JsonConvert.SerializeObject(LoadedSave);
            if (API.DeveloperMode == true)
            {
                File.WriteAllText(Paths.SaveFile, rawjson);
            } else
            {
                File.WriteAllText(Paths.SaveFile, API.Encryption.Encrypt(rawjson));
            }
            //Shiftorium
            string shiftoriumjson = JsonConvert.SerializeObject(ShiftoriumRegistry.ShiftoriumUpgrades);
            if (API.DeveloperMode == true)
            {
                File.WriteAllText(Paths.SystemDir + "_shiftorium.json", shiftoriumjson);
            }
            else
            {
                File.WriteAllText(Paths.SystemDir + "_shiftorium.json", API.Encryption.Encrypt(shiftoriumjson));
            }
            SaveBitnoteAddress();
            Hacking.SaveCharacters();
        }

        /// <summary>
        /// Put ShiftOS in a New Game state.
        /// </summary>
        public static void NewGame()
        {
            Paths.WriteFileSystem(); //Writes the file system.
            LoadedSave = new Save(); //Create a new Save
            ShiftoriumRegistry.SetDefaultShiftoriumValues();
            string rawjson = JsonConvert.SerializeObject(LoadedSave);
            if (API.DeveloperMode == true)
            {
                File.WriteAllText(Paths.SaveFile, rawjson);
            }
            else
            {
                File.WriteAllText(Paths.SaveFile, API.Encryption.Encrypt(rawjson));
            }
            File.WriteAllText(Paths.SystemDir + "_engineInfo.txt", "engine hash: #62586247262346484");
            string shiftoriumjson = JsonConvert.SerializeObject(ShiftoriumRegistry.ShiftoriumUpgrades);
            if (API.DeveloperMode == true)
            {
                File.WriteAllText(Paths.SystemDir + "_shiftorium.json", shiftoriumjson);
            }
            else
            {
                File.WriteAllText(Paths.SystemDir + "_shiftorium.json", API.Encryption.Encrypt(shiftoriumjson));
            }
            Hacking.GetCharacters(); //I'm retarded. The save routine doesn't compensate for new games.
        }

        /// <summary>
        /// Check for a ShiftOS-Next or ShiftOS 0.0.x save.
        /// </summary>
        public static void CheckForOlderSaves()
        {
            if (OSInfo.GetPlatformID() == "microsoft")
            {
                if (Directory.Exists(Paths.SaveRoot))
                {
                    if (!File.Exists(Paths.SystemDir + "_engineInfo.txt"))
                    {
                        MessageBox.Show("WARNING: Older ShiftOS saves are no longer supported. This save will be converted to the new format, and will not be readable by either ShiftOS-Next or the legacy ShiftOS.");
                        NewGame();
                    }
                }
            }
        }
    }

    public class ShiftoriumRegistry
    {
        public static Dictionary<string, bool> ShiftoriumUpgrades = new Dictionary<string, bool>();


        public static List<Shiftorium.Upgrade> DefaultUpgrades = new List<Shiftorium.Upgrade>();


        /// <summary>
        /// Adds upgrade info (such as CP, description, etc) to the registry. Add your Shiftorium upgrades here.
        /// </summary>
        public static void setUpgrades()
        {
            DefaultUpgrades.Clear();
            //Dummy Upgrades.
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Dummy1 - 0 CP", null, null, "dummy", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Dummy2 - 0 CP", null, null, "dummy", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Dummy3 - 0 CP", null, null, "dummy", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Dummy4 - 0 CP", null, null, "dummy", "useful"));

            /*Add new upgrades below.

            Adding an upgrade is as simple as:
            DefaultUpgrades.Add(new Shiftorium.Upgrade("<title> - <cost> CP", <preview image>, "<description>", "<dependencies>"));

            If you were to uncomment that, and replace <cost> with a real integer, and <preview image> with a real System.Drawing.Image, 
            an upgrade named '<title>' with description '<description>' would be added to the Shiftorium.

            Checking if the upgrade is bought, is as simple as:
            if(SaveSystem.ShiftoriumRegistry.ShiftoriumUpgrades["<id>"] == true) {
                //Do code if the upgrade is bought
            }
            else
            {
                //Do code if the upgrade is not bought.
            }

            <id> will always be a lowercase version of <title> in the above tutorial on adding new upgrades, with no spaces.
            For example, an upgrade with a title of "ShiftOS Shiftorium Upgrade" would have an ID of "shiftosshiftoriumupgrade".

            Also, the last argument in 'new Shiftorium.Upgrade()', <dependencies> is simple.

            If your upgrade can be bought at the beginning of the game, and doesn't require any other upgrades, put 'null' as the argument.

            If your upgrade depends on another upgrade, put that upgrade's ID as the argument.

            For example: "Titlebar" depends on "Gray", as you'll see, "Titlebar"'s dependencies argument is set to 'gray'.

            If your upgrade depends on multiple features, separate each upgrade ID by a semicolon.

            Like this: "upgrade1;upgrade2;upgrade3' and so on. Do not put a semicolon at the end of the string.

            Some upgrades, like 'Shift Desktop Panel' use this, requiring both the Shifter and the desktop panel upgrades.

            ShiftOS will automatically ckeck to see if all dependencies of an upgrade have been purchased before letting the user buy it.

            */
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Gray - 20 CP", ShiftOS.Properties.Resources.upgradegray, "Everything doesn't always have to be black and white. Give your programs and GUI some depth by mixing black and white together to form grey." + Environment.NewLine + Environment.NewLine + "Note: You are unable to make controls grey until you buy the Shifter.", null, "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Title Bar - 80 CP", ShiftOS.Properties.Resources.upgradetitlebar, "Your windows are looking extremely bare right now. You know what they need? A gray bar on top of them! What is the gray bar for you ask?" + Environment.NewLine + Environment.NewLine + "Depending on what kind of person you are it either \"Does Nothing\" or \"Looks Pretty\". The Title Bar has a lot of future potential though…", "gray", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Seconds Since Midnight - 10 CP", ShiftOS.Properties.Resources.upgradesecondssincemidnight, "Ever wondered how many seconds have passed since the clock struck midnight? No?" + Environment.NewLine + Environment.NewLine + "Well for just 9.99 codepoints (rounded to the nearest codepoint) you will finally have the answer to that question you have no intention of knowing the answer to.", null, "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Minutes Since Midnight - 20 CP", ShiftOS.Properties.Resources.upgrademinutesssincemidnight, "Most people would find looking out their window a better indication of what time it is than being told how many seconds have passed since midnight." + Environment.NewLine + Environment.NewLine + "If you are like most people then enhancing the computers ability to tell the time is critical.", "secondssincemidnight", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Hours Since Midnight - 40 CP", ShiftOS.Properties.Resources.upgradehoursssincemidnight, "Need a somewhat normal method of time tracking? Well now you can have it with the Hours Past Midnight time format." + Environment.NewLine + Environment.NewLine + "It's not perfectly accurate but it's easier than trying to work out the time from how many seconds or minutes have passed since midnight.", "minutessincemidnight", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Username - 15 CP", ShiftOS.Properties.Resources.upgradecustomusername, "Sick of being known as \"User\"? Want to be recognized and labeled? Then you need to replace the default username with your own!" + Environment.NewLine + Environment.NewLine + "If you want ShiftOS to refer to you by name then you are going to need this upgrade.", null, "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Windows Anywhere - 25 CP", ShiftOS.Properties.Resources.upgradewindowsanywhere, "Having all windows open in the center of the screen is seriously limiting when it comes to multitasking." + Environment.NewLine + Environment.NewLine + "Buying this upgrade is essential if you plan on multitasking or even if you just hate having windows centered in the middle of screen.", null, "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Multitasking - 50 CP", ShiftOS.Properties.Resources.upgrademultitasking, "These days people have many windows up on their computer so they can edit photos while they watch videos and chat to their friends about how good at multitasking they are." + Environment.NewLine + Environment.NewLine + "If you like multitasking and having lots of windows open then buy this upgrade!", "windowsanywhere", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Auto Scroll Terminal - 5 CP", ShiftOS.Properties.Resources.upgradeautoscrollterminal, "Getting sick of the terminal filling up with text leaving you not knowing what you have typed unless you start typing more?" + Environment.NewLine + Environment.NewLine + "Then buy this upgrade to keep the terminal scrolled to the bottom so you can always see the latest stuff you've typed.", null, "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Movable Windows - 75 CP", ShiftOS.Properties.Resources.upgrademoveablewindows, "Although it's nice to be able to type commands in the terminal to teleport windows to any spot on the screen it’s a little time consuming and difficult at times." + Environment.NewLine + Environment.NewLine + "Well, with Movable Windows you can move Windows with the keyboard WASD keys.", "windowsanywhere", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Draggable Windows - 150 CP", ShiftOS.Properties.Resources.upgradedraggablewindows, "So... I heard you have a Title Bar? I also heard that you have Movable Windows. Although Movable Windows are nice they aren't perfect." + Environment.NewLine + Environment.NewLine + "Buy this upgrade if you want to drag windows around by their Title Bar! Trust me... Its ultra-efficient!", "titlebar;movablewindows", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Window Borders - 40 CP", ShiftOS.Properties.Resources.upgradewindowborders, "A borderless window on your desktop is like a picture hung on the wall without a frame. It looks completely out of place and awful!" + Environment.NewLine + Environment.NewLine + "Without this upgrade your overlapping windows will look extremely messy and appear to merge with each other,", "gray", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("PM and AM - 60 CP", ShiftOS.Properties.Resources.upgradeamandpm, "You may be able read the time as it is now but by splitting the time into two 12 hour periods other less intelligent people around you will have an easier time reading the time." + Environment.NewLine + Environment.NewLine + "This upgrade is necessary to stop your families and friends brains exploding!", "minuteaccuracytime", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Minute Accuracy Time - 80 CP", ShiftOS.Properties.Resources.upgrademinuteaccuracytime, "Want to be completely normal for once? Well Shift your time format into one 60x more accurate. " + Environment.NewLine + Environment.NewLine + "Most people these days make plans to meet at certain times such as 5:30pm so knowing the exact minute of the exact hour is very important.", "hourssincemidnight", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Split Second Time - 100 CP", ShiftOS.Properties.Resources.upgradesplitsecondaccuracy, "You already know the exact time down to the very last minute. Do you really need to know the exact second?" + Environment.NewLine + Environment.NewLine + "If so then give this upgrade a whirl but I'm sure you have better things to do than throw 100 codepoints away like this.", "minuteaccuracytime", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Title Text - 40 CP", ShiftOS.Properties.Resources.upgradetitletext, "Since looking at a program won't tell you the name of it you need Title Text. Unless of course you want to go through the trouble of remembering the name of the program..." + Environment.NewLine + Environment.NewLine + "Title Text sits in the top left hand corner of the title bar to label each program.", "titlebar", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Close Button - 90 CP", ShiftOS.Properties.Resources.upgradeclosebutton, "Closing a program should be as easy as pressing a button. Opening up the terminal and typing \"Close [Program name]\" is just Ridiculous." + Environment.NewLine + Environment.NewLine + "Please, for your own sake... Buy this close button before you waste another second opening up that terminal!", "titlebar", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Desktop Panel - 150 CP", ShiftOS.Properties.Resources.upgradedesktoppanel, "Got a boring blank desktop? Feel it doesn't really serve a purpose? Then you need a desktop panel!" + Environment.NewLine + Environment.NewLine + "This beautiful gray desktop panel will sit at the top of your desktop and do absolutely nothing for only 150 codepoints!", "gray", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Clock - 50 CP", ShiftOS.Properties.Resources.upgradeclock, "You could type \"time\" in the terminal every time you wanted to know what the time was but that's a little inefficient don't you think?" + Environment.NewLine + Environment.NewLine + "Ever wish you could just have the time on the screen all the time? Well, there’s an app for that!", "secondssincemidnight", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("App Launcher Menu - 120 CP", ShiftOS.Properties.Resources.upgradeapplaunchermenu, "Launching programs by typing their names in the terminal is very counterproductive especially if you are bad at spelling." + Environment.NewLine + Environment.NewLine + "A menu on the desktop that displays all programs on your computer and allows you to launch them would be a huge time saver.", "desktoppanel", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Knowledge Input - 20 CP", ShiftOS.Properties.Resources.upgradeknowledgeinput, "What's the point of an App Launcher if it can't launch all your apps?" + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to knowledge input in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermemu", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Clock - 20 CP", ShiftOS.Properties.Resources.upgradealclock, "What's the point of an App Launcher if it can't launch all your apps?" + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to the clock in your app launcher so you can launch it at any time with just a few clicks.", "clock;applaunchermenu", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Shiftorium - 20 CP", ShiftOS.Properties.Resources.upgradealshiftorium, "What's the point of an App Launcher if it can't launch all your apps?" + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to shiftorium in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("App Launcher Shutdown - 40 CP", ShiftOS.Properties.Resources.upgradeapplaunchershutdown, "You want a complete graphical interface with no reliance on the terminal right? That means every possible function of the operating system must be achievable graphically." + Environment.NewLine + Environment.NewLine + "You may not shut down too often but hey, it beats opening the terminal...", "applaunchermenu", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Windowed Terminal - 45 CP", ShiftOS.Properties.Resources.upgradewindowedterminal, "A nice big terminal is useful however it can sometimes get in the way of what you are doing." + Environment.NewLine + Environment.NewLine + "With a few tweaks we may be able to program a command that allows the terminal to switch between a full screen and windowed state.", "multitasking", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Desktop Panel Clock - 75 CP", ShiftOS.Properties.Resources.upgradedesktoppanelclock, "Want to always know what the time is without typing \"time\" in the terminal or opening up an entire application?" + Environment.NewLine + Environment.NewLine + "Well, with this somewhat expensive but extremely affordable clock you will know what the time is no matter what you are doing.", "desktoppanel;clock", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Terminal Scrollbar - 20 CP", ShiftOS.Properties.Resources.upgradeterminalscrollbar, "It’s great having the terminal windowed so it doesn't block the view of your desktop but at the same time size can be an issue." + Environment.NewLine + Environment.NewLine + "This problem can easily be fixed however by adding a scrollbar to the terminal when it's windowed.", "autoscrollterminal", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("KI Addons - 15 CP", ShiftOS.Properties.Resources.upgradekiaddons, "Knowledge input is a great game to play if you want to earn codepoints but what happens when you run out of things to guess?" + Environment.NewLine + Environment.NewLine + "This upgrade will allow you to install add-ons for knowledge input.", null, "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("KI Car Brands - 10 CP", ShiftOS.Properties.Resources.upgradeskicarbrands, "Need some more lists for Knowledge input? Why not add a list of automobile manufacturers to guess?" + Environment.NewLine + Environment.NewLine + "You know the brand of car you drive right? Toyota Maybe? Suzuki? Or maybe you have a Ferrari... come on you can do this!", "kiaddons", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("KI Game Consoles - 10 CP", ShiftOS.Properties.Resources.upgradesgameconsoles, "Need some more lists for Knowledge input? Why not add a list of game consoles to guess?" + Environment.NewLine + Environment.NewLine + "You know the name of your game console right? Playstation 4 Maybe? Xbox one? Or maybe you have a Ouya... come on you can do this!", "kiaddons", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Gray Shades - 40 CP", ShiftOS.Properties.Resources.upgradegrayshades, "Seeing gray on your computer screen may be a nice break from  black and white but why have just one shade of gray when you can have 3?" + Environment.NewLine + Environment.NewLine + "More shades of gray increase the uniqueness of your ShiftOS interface by expanding your range of colour options in the Shifter.", "gray", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Gray Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradegrayshadeset, "3 Shades of gray may be better than 1 shade but why not get a full gray shade set complete with 8 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of gray.", "grayshades", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Gray Shades - 100 CP", ShiftOS.Properties.Resources.upgradegraycustom, "Forget about having 8 shades of gray because this upgrade will allow you to crack the colour value code giving you the ability to create your own custom shades of gray." + Environment.NewLine + Environment.NewLine + "Further research may even allow us to create other basic colours.", "fullgrayshadeset", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Purple - 20 CP", ShiftOS.Properties.Resources.upgradepurple, "Now that we have the RBG colours \"Red\" and \"Blue\" we are able to mix them together to form purple which symbolizes spirituality, royalty, magic and mystery." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Purple.", "red;green;blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Purple Shades - 40 CP", ShiftOS.Properties.Resources.upgradepurpleshades, "Having a splash of purple may be cool but why have just one shade of purple when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of purple.", "purple", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Purple Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradepurpleshadeset, "3 Shades of purple may be better than 1 shade but why not get a full purple shade set complete with 16 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of purple.", "purpleshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Purple Shades - 100 CP", ShiftOS.Properties.Resources.upgradepurplecustom, "16 shades of purple gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own purple shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullpurpleshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Blue - 20 CP", ShiftOS.Properties.Resources.upgradeblue, "Blue may be the colour of the sky and the ocean but it’s also an important colour that may allow us to create more colours if we mix it with red." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Blue.", "customgrayshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Blue Shades - 40 CP", ShiftOS.Properties.Resources.upgradeblueshades, "Having a splash of blue may be cool but why have just one shade of blue when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of blue.", "blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Blue Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradeblueshadeset, "3 Shades of blue may be better than 1 shade but why not get a full blue shade set complete with 16 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of blue.", "blueshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Blue Shades - 100 CP", ShiftOS.Properties.Resources.upgradebluecustom, "16 shades of blue gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own blue shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullblueshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Green - 20 CP", ShiftOS.Properties.Resources.upgradegreen, "Green may be the colour of nature and life but it’s also an important colour that may allow us to create more colours if we mix it with red." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Green.", "customgrayshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Green Shades - 40 CP", ShiftOS.Properties.Resources.upgradegreenshades, "Having a splash of green may be cool but why have just one shade of green when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of green.", "green", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Green Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradegreenshadeset, "3 Shades of green may be better than 1 shade but why not get a full green shade set complete with 16 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of green.", "greenshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Green Shades - 100 CP", ShiftOS.Properties.Resources.upgradegreencustom, "16 shades of green gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own green shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullgreenshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Yellow - 20 CP", ShiftOS.Properties.Resources.upgradeyellow, "Now that we have the RBG colours \"Red\" and \"Green\" we are able to mix them together to form yellow which symbolizes happiness, creativity and high intellect." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Yellow.", "red;green;blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Yellow Shades - 40 CP", ShiftOS.Properties.Resources.upgradeyellowshades, "Having a splash of yellow may be cool but why have just one shade of yellow when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of yellow.", "yellow", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Yellow Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradeyellowshadeset, "3 Shades of yellow may be better than 1 shade but why not get a full yellow shade set complete with 10 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of yellow.", "yellowshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Yellow Shades - 100 CP", ShiftOS.Properties.Resources.upgradeyellowcustom, "10 shades of yellow gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own yellow shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullyellowshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Orange - 20 CP", ShiftOS.Properties.Resources.upgradeorange, "Now that we have the RBG colours \"Red\" and \"Green\" we are able to mix them together to form orange which symbolizes enthusiasm and creativity." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Orange.", "red;green;blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Orange Shades - 40 CP", ShiftOS.Properties.Resources.upgradeorangeshades, "Having a splash of orange may be cool but why have just one shade of orange when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of orange.", "orange", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Orange Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradeorangeshadeset, "3 Shades of orange may be better than 1 shade but why not get a full orange shade set complete with 6 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of orange.", "orangeshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Orange Shades - 100 CP", ShiftOS.Properties.Resources.upgradeorangecustom, "6 shades of orange gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own orange shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullorangeshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Brown - 20 CP", ShiftOS.Properties.Resources.upgradebrown, "Now that we have the all the RBG colours we are able to mix them together to form brown which symbolizes laziness and the earth." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Brown.", "red;green;blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Brown Shades - 40 CP", ShiftOS.Properties.Resources.upgradebrownshades, "Having a splash of brown may be cool but why have just one shade of brown when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of brown.", "brown", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Brown Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradebrownshadeset, "3 Shades of brown may be better than 1 shade but why not get a full brown shade set complete with 16 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of brown.", "brownshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Brown Shades - 100 CP", ShiftOS.Properties.Resources.upgradebrowncustom, "16 shades of brown gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own brown shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullbrownshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Red - 20 CP", ShiftOS.Properties.Resources.upgradered, "Red may be a demonic and evil colour that symbolizes hate and rage but it’s a very important colour that may allow us to create more colours if we mix it with Blue or Green." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to red.", "customgrayshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Red Shades - 40 CP", ShiftOS.Properties.Resources.upgraderedshades, "Having a splash of red may be cool but why have just one shade of red when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of red.", "red", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Red Shade Set - 60 CP", ShiftOS.Properties.Resources.upgraderedshadeset, "3 Shades of red may be better than 1 shade but why not get a full red shade set complete with 9 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of red.", "redshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Red Shades - 100 CP", ShiftOS.Properties.Resources.upgraderedcustom, "9 shades of red gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own red shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullredshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Pink - 20 CP", ShiftOS.Properties.Resources.upgradepink, "Now that we have the all the RBG colours we are able to mix them together to form pink which symbolizes universal love and beauty." + Environment.NewLine + Environment.NewLine + "Buying this upgrade would enable you to set various UI elements in ShiftOS to Pink.", "red;green;blue", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Pink Shades - 40 CP", ShiftOS.Properties.Resources.upgradepinkshades, "Having a splash of pink may be cool but why have just one shade of pink when you can have 3?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to get more shades of pink.", "pink", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Full Pink Shade Set - 60 CP", ShiftOS.Properties.Resources.upgradepinkshadeset, "3 Shades of pink may be better than 1 shade but why not get a full pink shade set complete with 6 shades?" + Environment.NewLine + Environment.NewLine + "Further upgrades may even allow you to create your own custom shades of pink.", "pinkshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Custom Pink Shades - 100 CP", ShiftOS.Properties.Resources.upgradepinkcustom, "6 shades of pink gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own pink shades." + Environment.NewLine + Environment.NewLine + "Eventually we may be able to limitlessly create shades of any colour.", "fullpinkshadeset", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Basic Custom shade - 50 CP", ShiftOS.Properties.Resources.anycolourshade, "Now that we can create shades of colours based on certain rules our level of customization is very high." + Environment.NewLine + Environment.NewLine + "With further research ShiftOS may be able to support the ability to make a shade not linked to the rules of a certain colour.", "custompinkshades;customblueshades;custompurpleshades;customorangeshades;custombrownshades;customyellowshades;customredshades;customgreenshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("General Custom Shades - 100 CP", ShiftOS.Properties.Resources.anycolourshade2, "There isn’t much use making a single custom colour that looks mostly gray. Further research into optimizing ShiftOS may improve its compatibility with the RGB colour system." + Environment.NewLine + Environment.NewLine + "This would lead to a higher range in values and shades being stored.", "basiccustomshade", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Advanced Custom Shades - 250 CP", ShiftOS.Properties.Resources.anycolourshade3, "4 savable shade spaces is nowhere near decent for storing custom colours and with RGB limits of 100 to 200 the colours are still looking quite dull." + Environment.NewLine + Environment.NewLine + "More research into optimizing ShiftOS may further break these limits.", "generalcustomshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Limitless Custom Shades - 500 CP", ShiftOS.Properties.Resources.anycolourshade4, "It’s time to break all RGB colour limits forever! This upgrade may be expensive but it will allow us to master the RGB colour system." + Environment.NewLine + Environment.NewLine + "With total native RGB colour support in ShiftOS we will limitlessly be able to make millions of shades of colours.", "advancedcustomshades", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shifter - 40 CP", ShiftOS.Properties.Resources.upgradeshifter, "For system compatibility reasons practically all ShiftOS elements are designed to display in gray style and look dull." + Environment.NewLine + Environment.NewLine + "We may be able to overcome this dull interface however if the user is given the option to customize it through the use of an application.", "gray", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Shifter - 20 CP", ShiftOS.Properties.Resources.upgradealshifter, "What's the point of an App Launcher if it can't launch all your apps? " + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to the shifter in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu;shifter", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Roll Up Command - 10 CP", ShiftOS.Properties.Resources.upgraderollupcommand, "Running out of space on your desktop? Wish you could keep a window running in the background without completely closing it?" + Environment.NewLine + Environment.NewLine + "Well you 're in luck. The roll up command will allow you to roll windows up to their title bar when you want to save space.", "titlebar", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Roll Up Button - 45 CP", ShiftOS.Properties.Resources.upgraderollupbutton, "Are you a fan of the Roll Up functionality? Are you absolutely sick of opening up the terminal and typing in a command every time you want to roll up a window?" + Environment.NewLine + Environment.NewLine + "This upgrade will making rolling up windows much quicker!", "rollupcommand", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Desktop - 20 CP", ShiftOS.Properties.Resources.upgradeshiftdesktop, "The shifter is currently unable to change any settings but this simple upgrade may be able to add a module that allows you to change the colour of the desktop background." + Environment.NewLine + Environment.NewLine + "This may even unlock further Shifter functionality.", "shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Panel Clock - 20 CP", ShiftOS.Properties.Resources.upgradeshiftpanelclock, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Desktop Panel Clock.", "desktoppanelclock;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift App Launcher - 20 CP", ShiftOS.Properties.Resources.upgradeshiftapplauncher, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the App Launcher.", "applaunchermenu;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Desktop Panel - 20 CP", ShiftOS.Properties.Resources.upgradeshiftdesktoppanel, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Desktop Panel.", "desktoppanel;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Title Bar - 20 CP", ShiftOS.Properties.Resources.upgradeshifttitlebar, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Title Bar.", "titlebar;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Title Text - 20 CP", ShiftOS.Properties.Resources.upgradeshifttitletext, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Title Text.", "titletext;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Title Buttons - 20 CP", ShiftOS.Properties.Resources.upgradeshiftbuttons, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Title Buttons.", "closebutton;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Borders - 20 CP", ShiftOS.Properties.Resources.upgradeshiftborders, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Window Borders.", "windowborders;shifter", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Pong - 70 CP", ShiftOS.Properties.Resources.upgradepong, "Finding it difficult to list more words with knowledge input? Everyone has their limits right? Well how about a game of pong?" + Environment.NewLine + Environment.NewLine + "This game is sure to get your adrenalin going and you can earn codepoints as you play it!", null, "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Pong - 20 CP", ShiftOS.Properties.Resources.upgradealpong, "What's the point of an App Launcher if it can't launch all your apps? " + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to pong in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu;pong", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL File Skimmer - 20 CP", ShiftOS.Properties.Resources.upgradealfileskimmer, "What's the point of an App Launcher if it can't launch all your apps? " + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to the file skimmer in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu;fileskimmer", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Textpad - 20 CP", ShiftOS.Properties.Resources.upgradealtextpad, "What's the point of an App Launcher if it can't launch all your apps? " + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to textpad in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu;textpad", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("File Skimmer - 60 CP", ShiftOS.Properties.Resources.upgradefileskimmer, "Almost all computers come with some form of permanent data storage." + Environment.NewLine + Environment.NewLine + "ShiftOS is storing data on your storage device (e.g. HDD or SSD) however without a way to view and browse through these files you are practically locked out of your own computer.", "gray", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Textpad - 65 CP", ShiftOS.Properties.Resources.upgradetextpad, "Need to quickly jot down something but you can’t find a pen and paper nearby? There’s an app for that!" + Environment.NewLine + Environment.NewLine + "With the Textpad you will be able to jot down whatever you like and have it displayed in all its glory on your computer screen.", "gray", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Textpad New - 25 CP", ShiftOS.Properties.Resources.upgradetextpadnew, "Have you ever been typing a document and thought ‘I don’t like what I’m writing’. Closing and opening the entire application to clear the text is too much effort right?" + Environment.NewLine + Environment.NewLine + "Well if you get this upgrade clearing the text can be as easy as pressing a button.", "textpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Textpad Save - 25 CP", ShiftOS.Properties.Resources.upgradetextpadsave, "Have you just written something worth keeping with Textpad? Well, what a shame you can’t save it…" + Environment.NewLine + Environment.NewLine + "Or can you? That’s right, with this upgrade your award winning documents can sit safely on your storage device.", "fileskimmer;textpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Textpad Open - 25 CP", ShiftOS.Properties.Resources.upgradetextpadopen, "Sure you can open your text files by going to all the effort of opening File Skimmer and then clicking on the file you want to open but it doesn’t have to be that hard." + Environment.NewLine + Environment.NewLine + "Wouldn't an open button make life much easier?", "fileskimmer;textpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("FS New Folder - 25 CP", ShiftOS.Properties.Resources.upgradefileskimmernew, "There are a few folders within the ShiftOS file system that you can sort your data into but why limit yourself?" + Environment.NewLine + Environment.NewLine + "In an operating system that you can shift to your liking surely you should be able to create your own folders right?", "fileskimmer", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("FS Delete - 25 CP", ShiftOS.Properties.Resources.upgradefileskimmerdelete, "You’re not a hoarder are you? If you are stop reading this and go look for another upgrade." + Environment.NewLine + Environment.NewLine + "If you keep every file you create your storage device is sure to get cluttered… seriously, you need a delete button!", "fileskimmer", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("KI Elements - 10 CP", ShiftOS.Properties.Resources.upgradekielements, "Need some more lists for Knowledge input? Why not add a list of Elements to guess?" + Environment.NewLine + Environment.NewLine + "You studied the periodic table of elements in highschool right? Hydrogen, oxygen, lead, silver… you can do this!", "kiaddons", "useful"));
            //new
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Panel Buttons - 75 CP", ShiftOS.Properties.Resources.upgradepanelbuttons, "A desktop panel seems like it could be useful for a variety of different features." + Environment.NewLine + Environment.NewLine + "Maybe with a little more research we could find a way to display the names of all your open programs in the desktop panel", "desktoppanel", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Minimize Command - 20 CP", ShiftOS.Properties.Resources.upgrademinimizecommand, "Ever wanted to completely remove a program from the screen without actually closing it?" + Environment.NewLine + Environment.NewLine + "Well with a minimize command this may actually become possible and allow you to save the state of hidden programs in the process!", "titlebar", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Minimize Button - 50 CP", ShiftOS.Properties.Resources.upgrademinimizebutton, "As useful as the minimize feature is you still have to go to all the effort of opening the terminal and typing in a command to use it." + Environment.NewLine + Environment.NewLine + "Wouldn’t a button in the title of each window be more efficient?", "minimizecommand", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Useful Panel Buttons - 40 CP", ShiftOS.Properties.Resources.upgradeusefulpanelbuttons, "How can you call those things on the desktop panel ‘panel buttons’ when they aren’t even clickable?." + Environment.NewLine + Environment.NewLine + "A graphical unminimize feature would be handy and those panel buttons might help us…", "panelbuttons;minimizecommand", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad - 75 CP", ShiftOS.Properties.Resources.upgradeartpad, "Ever wanted to play around with pixels on your screen?" + Environment.NewLine + Environment.NewLine + "Well it looks like your newest companion may become the Artpad but be sure you know your x and y coordinates!", "gray", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 4 - 10 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit4, "With just two pixels you can’t make very interesting artworks." + Environment.NewLine + Environment.NewLine + "Doubling the pixel limit to 4 should more than double the variety of unique creations you can make with the artpad.", "artpad", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 8 - 20 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit8, "Earlier I lied about 4 pixels giving you many different types of unique artistic opportunities." + Environment.NewLine + Environment.NewLine + "A pixel limit of 8 may be a little limiting though and its still dirt cheap.", "artpadpixellimit4", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 16 - 30 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit16, "8 pixels may not be great but 16 is looking a little more pristine." + Environment.NewLine + Environment.NewLine + "It may be a silly rhyme but it’s true.", "artpadpixellimit8", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 64 - 50 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit64, "Step right up to a pixel limit 4x greater than your current one." + Environment.NewLine + Environment.NewLine + "Isn’t it usually double you say? Well this time around its quadruple but unfortunately it does come with a dearer price.", "artpadpixellimit16", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 256 - 75 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit256, "Finally we are on the verge on a decent pixel limit. Think of what you could do with 256 pixels" + Environment.NewLine + Environment.NewLine + "The width and height of your canvas could be huge!", "artpadpixellimit64", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 1024 - 100 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit1024, "Ahh, now we’re talking. This is an upgrade that will do you a world of good." + Environment.NewLine + Environment.NewLine + "It’s a shame it’s is so expensive but good things always come at a cost.", "artpadpixellimit256", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 4096 - 150 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit4096, " With a pixel limit of 4096 you would have the ability to make canvases 64 by 64 pixels." + Environment.NewLine + Environment.NewLine + "Do you really think you will need this high of a pixel limit?", "artpadpixellimit1024", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 16384 - 200 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit16384, "You may think your current pixel limit is good but you aren’t seen nothing yet." + Environment.NewLine + Environment.NewLine + "For some true 4x zoomed freehand drawing don’t miss this upgrade.", "artpadpixellimit4096", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Limit 65536 - 250 CP", ShiftOS.Properties.Resources.upgradeartpadpixellimit65536, "Oh come on how much higher can the pixel limit go?" + Environment.NewLine + Environment.NewLine + "I doubt you actually need it but aren’t you curious how much higher this goes?", "artpadpixellimit16384", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Limitless Pixels - 350 CP", ShiftOS.Properties.Resources.upgradeartpadlimitlesspixels, "This is what you’ve been waiting for all this time after purchasing all those pixel limit upgrades" + Environment.NewLine + Environment.NewLine + "It may be ultra-expensive but you won’t have to ever get another after this one.", "artpadpixellimit65536", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad New - 10 CP", ShiftOS.Properties.Resources.upgradeartpadnew, "Ever wanted to start a fresh with a new canvas without restarting Artpad" + Environment.NewLine + Environment.NewLine + "With a little research it may be possible to add a button to do just that whenever you want.", "artpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Save - 50 CP", ShiftOS.Properties.Resources.upgradeartpadsave, "Artpad may be fun to play around with but wouldn’t saving be an amazing feature?" + Environment.NewLine + Environment.NewLine + "Saving your pictures may even generate codepoints and the saved pictures might be able to be used for something.", "fileskimmer;artpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Load - 50 CP", ShiftOS.Properties.Resources.upgradeartpadload, "Sometimes after making something and saving it you wish to alter it slightly to enhance it" + Environment.NewLine + Environment.NewLine + "A load feature in the Artpad should let you modify saved .pic files by allowing you to load them up again with the click of a button.", "fileskimmer;artpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Undo - 40 CP", ShiftOS.Properties.Resources.upgradeartpadundo, "Ever spilt your paint over your masterpiece? It’s an awful feeling right?" + Environment.NewLine + Environment.NewLine + "Well in situations like these an undo feature would be very useful so for backup I would definitely get this upgrade.", "artpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Redo - 40 CP", ShiftOS.Properties.Resources.upgradeartpadredo, "Ever clicked undo too many times and found that you have lost a large portion of work" + Environment.NewLine + Environment.NewLine + "For cases like these a redo button can be quite handy but obviously you could save your codepoints by just being careful with the undo button.", "artpadundo", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pixel Placer - 20 CP", ShiftOS.Properties.Resources.upgradeartpadpixelplacer, "The pixel setter allows you to set pixels but do you really want to go around trying to pinpoint and calculate x and y coordinates" + Environment.NewLine + Environment.NewLine + "Clicking the pixel you want to change directly would be much more efficient don’t you agree?", "artpad", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad PP Movement Mode - 20 CP", ShiftOS.Properties.Resources.upgradeartpadpixelplacermovementmode, "Constantly clicking each individual pixel on your canvas using the Pixel Placer can be very time consuming and tiring for your hands" + Environment.NewLine + Environment.NewLine + "Wouldn’t it be easier to just click and drag? Well there’s an upgrade for that!", "artpadpixelplacer", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Pencil - 30 CP", ShiftOS.Properties.Resources.upgradeartpadpenciltool, "Does the buggy Pixel placer movement mode annoy you when it skips pixels?" + Environment.NewLine + Environment.NewLine + "Well with a little more research we may be able to develop a new tool that can draw much more smoothly.", "artpadppmovementmode", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Paint Brush - 30 CP", ShiftOS.Properties.Resources.upgradeartpadpaintbrushtool, "Ever wanted to paint with a tool that can paint free handedly and be big, small, circular or square?" + Environment.NewLine + Environment.NewLine + "This paint brush tool may be the tool you want then and its pretty cheap too.", "artpadppmovementmode", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Line Tool - 30 CP", ShiftOS.Properties.Resources.upgradeartpadlinetool, "Having difficulty drawing strait lines? Then you obviously need a line tool." + Environment.NewLine + Environment.NewLine + "With a line tool you will be able to draw straight lines from any point to any point on your canvas.", "artpadpencil", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Oval Tool - 40 CP", ShiftOS.Properties.Resources.upgradeartpadovaltool, "Drawing perfect circles is a very tricky process especially if zoomed right in on the canvas" + Environment.NewLine + Environment.NewLine + "With a bit of research we may be able to discover a tool that calculates how to draw circles without much effort on our side.", "artpadlinetool", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Rectangle Tool - 40 CP", ShiftOS.Properties.Resources.upgradeartpadrectangletool, "Drawing perfect squares is a time consuming process especially if you are trying to draw them perfectly straight" + Environment.NewLine + Environment.NewLine + "With a bit of research we may be able to discover a tool that calculates how to draw squares without much effort on our side.", "artpadovaltool", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Eraser - 20 CP", ShiftOS.Properties.Resources.upgradeartpaderaser, "Made a little mistake and want to erase it? Sounds like you need an eraser" + Environment.NewLine + Environment.NewLine + "With a little bit of research an eraser tool may not be too far away as overall its just a paintbrush set to the colour of the canvas.", "artpadpencil", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Fill Tool - 60 CP", ShiftOS.Properties.Resources.upgradeartpadfilltool, "Instead of coloring in every single individual pixel sometimes it is more appropriate to simply draw an outline and instantly fill a space in." + Environment.NewLine + Environment.NewLine + "If that’s a feature you’re interested in then you should definitely buy this upgrade.", "artpadpaintbrush", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Text Tool - 45 CP", ShiftOS.Properties.Resources.upgradeartpadtexttool, "drawing text is very difficult but if you can pull it off then well done, nice accomplishment!" + Environment.NewLine + Environment.NewLine + "For those who can’t though research into a text drawing tool would be very handy unless you don’t require text in your artwork.", "artpadrectangletool", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 4 Color Pallets - 10 CP", ShiftOS.Properties.Resources.upgradeartpad4colorpallets, "Having just 2 colours in your work may give it an interesting style but overall its very limiting." + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 8 Color Pallets - 20 CP", ShiftOS.Properties.Resources.upgradeartpad8colorpallets, "4 colour pallets is still very limiting and a lot less than your average paint program." + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad4colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 16 Color Pallets - 35 CP", ShiftOS.Properties.Resources.upgradeartpad16colorpallets, "8 colours is still going to leave you changing the colour of your pallets quite often." + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad8colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 32 Color Pallets - 50 CP", ShiftOS.Properties.Resources.upgradeartpad32colorpallets, "16 colours is definitely usable but it certainly could get better than that right?" + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad16colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 64 Color Pallets - 100 CP", ShiftOS.Properties.Resources.upgradeartpad64colorpallets, "32 colours is slightly more than average for a paint program but don’t you want extreme?" + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad32colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad 128 Color Pallets - 150 CP", ShiftOS.Properties.Resources.upgradeartpad128colorpallets, "For some people 64 colour pallets may already be overkill but for the extremists like yourself it’s just not enough." + Environment.NewLine + Environment.NewLine + "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.", "artpad64colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Artpad Custom Pallets - 75 CP", ShiftOS.Properties.Resources.updatecustomcolourpallets, "It can be annoying when things are set in stone and can’t be changed." + Environment.NewLine + Environment.NewLine + "Let’s not let that happen to the Artpad by programming the colour pallets to be resizable by the user.", "artpad128colorpallets", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Skinning - 80 CP", ShiftOS.Properties.Resources.upgradeskinning, "Static colours of the windows and desktop in ShiftOS are beginning to look boring and unprofessional." + Environment.NewLine + Environment.NewLine + "Since the artpad is able to save .pic file we may be able to use them as UI elements.", "artpad;fileskimmer;shifter", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Artpad - 20 CP", ShiftOS.Properties.Resources.upgradealartpad, "What's the point of an App Launcher if it can't launch all your apps? " + Environment.NewLine + Environment.NewLine + "Use this tweak to add a shortcut to artpad in your app launcher so you can launch it at any time with just a few clicks.", "applaunchermenu;artpad", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Panel Buttons - 20 CP", ShiftOS.Properties.Resources.upgradeshiftpanelbuttons, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" + Environment.NewLine + Environment.NewLine + "This module will allow you to modify the Desktop Panel Buttons.", "panelbuttons;shifter", "useful"));
            // 0.0.8
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Resizable Windows - 40 CP", ShiftOS.Properties.Resources.upgraderesize, "You can move and rollup windows, but with a few more Code Point, we may be able to let you change their size!" + Environment.NewLine + Environment.NewLine + "This upgrade will allow you to resize any resizable window.", "draggablewindows;windowborders", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Change OS Name - 15 CP", ShiftOS.Properties.Resources.upgradeosname, "Getting sick of being 'user@shiftos $>' Well now you can change that, how about 'user@ThEBesToSEver'?" + Environment.NewLine + Environment.NewLine + "(We like self adverising here)", null, "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("System Information - 40 CP", ShiftOS.Properties.Resources.upgradesysinfo, "Don't know your PC specs? Need to find out? want to know what version of ShiftOS your running?" + Environment.NewLine + Environment.NewLine + "Well, this is the app for you. May I present: the System Information App!", null, "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("TRM Files - 50 CP", ShiftOS.Properties.Resources.upgradetrm, "Typing commands into the terminal is all very well, but what about pre-writing the commands so you can use them at any time? What about the ability to create terminal files?" + Environment.NewLine + Environment.NewLine + "This upgrade will allow you to save textpad documents in .trm format, meaning they will run in the terminal if valid.", "fileskimmer", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Launcher Items - 20 CP", ShiftOS.Properties.Resources.upgradeshiftitems, "So you can shift the Applications Launcher button. Great, but arn't the menu items a little boring?" + Environment.NewLine + Environment.NewLine + "The Shift Launcher Items upgrade allow you to customize launcher items, as well as the button.", "shiftapplauncher", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Virus Scanner - 200 CP", ShiftOS.Properties.Resources.upgradevirusscanner, "ShiftOS is the most secure operating system ever made, but here's a virus scanner in case you feeling extra cautious..." + Environment.NewLine + Environment.NewLine + "Just making sure you're aware, this scans for viruses, it doesn't remove them...", null, "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("VS Removal Grade 1 - 100 CP", ShiftOS.Properties.Resources.upgraderemoveth1, "If your doing things properly, there is no need for this... But wounldn't it be good to remove viruses if you did find them?" + Environment.NewLine + Environment.NewLine + "This extention for the Virus Scanner will give it the ablitity to remove level 1 viruses.", "virusscanner", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("VS Removal Grade 2 - 100 CP", ShiftOS.Properties.Resources.upgraderemoveth2, "Wow, DevX better see this, still buying virus protection? You must be doing something dodgy..." + Environment.NewLine + Environment.NewLine + "This extention for the Virus Scanner will give it the ablitity to remove level 2 viruses.", "vsremovalgrade1", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("VS Removal Grade 3 - 100 CP", ShiftOS.Properties.Resources.upgraderemoveth3, "Ok, I'm calling DevX now! Seroiusly, you really don't need this... But give me your Code Points anyway!" + Environment.NewLine + Environment.NewLine + "This extention for the Virus Scanner will give it the ablitity to remove level 3 viruses.", "vsremovalgrade2", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("VS Removal Grade 4 - 100 CP", ShiftOS.Properties.Resources.upgraderemoveth4, "Fine, whatever. I'll stop warning you against useless upgrades. Why should I care. Just gime the money OK?" + Environment.NewLine + Environment.NewLine + "This extention for the Virus Scanner will give it the ablitity to remove level 4 viruses.", "vsremovalgrade3", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("App Icons - 15 CP", ShiftOS.Properties.Resources.iconArtpad, "Ever wanted to see an icon of the application on it's window, or on it's Panel Button, or on it's App Launcher entry? Well, this upgrade will allow that, for the low price of 13 CP!", "titletext", "fancy"));

            //0.1.x/re-adds
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Unity Mode - 1000 CP", ShiftOS.Properties.Resources.upgradeunitymode, "ShiftOS uses " + OSInfo.GetPlatformID() + " native code to run, but what if we extended our OS abstraction layer to be able to run the OS's desktop and applications? Hmmmm... this'd make for great compatibility with many software.", "limitlesscustomshades;multitasking", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Unity - 25 CP", ShiftOS.Properties.Resources.upgradealunitymode, "We have the ability to turn Unity on and off through the terminal, but let's make it better by adding an entry in the App Launcher!", "applaunchermenu;unitymode", "fancy"));

            //0.1.x/new
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Zoomable Terminal - 50 CP", ShiftOS.Properties.Resources.upgradeautoscrollterminal, "Now that the terminal can be scrolled, it can be useful to zoom the terminal in and out to make it more readable. Buy this upgrade and you can zoom the Terminal by holding CTRL and scrolling up or down", "terminalscrollbar", "useful"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Advanced Shifter - 100 CP", ShiftOS.Properties.Resources.upgradeadvancedshifter, "We can customize so much of ShiftOS now. App Launcher, desktop panel, titlebar, you name it. But let's do more. Let's allow even DEEPER customization, such as system menus and window backgrounds.", "shifter;skinning;shiftapplauncher;shiftdesktoppanel;shifttitlebar;basiccustomshade", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift System Menus - 25 CP", null, "The Shifter can now access deeper layers of the system, but what about adding a category to the Shifter that lets us modify something? This upgrade will add a new 'Menus' category where you can customize all aspects of the ShiftOS menu system.", "advancedshifter", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("AL Shiftnet Apps - 15 CP", null, "With the Shiftnet installed and the ability to install even more applications, it's time to make them easier to run. With this upgrade, all your Shiftnet Apps can be ran from the App Launcher!", "shiftnet", "software"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Set Terminal Colors - 25 CP", null, "Do you want to spice up your terminal? Well, apply this upgrade and you'll be able to change it's text and background colors.", "skinning", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Set Terminal Font - 5 CP", null, "Ever wanted to set the font style of your Terminal? Well, this is the upgrade for you. Use the \"font\" command to set the font style.", "setterminalcolors", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Name Changer - 50 CP", null, "This upgrade allows you to change the names of ShiftOS applications.", "applaunchermenu", "software"));

            //0.1.x/non-shiftorium
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shiftnet - 0 CP", null, "Shiftorium Upgrade for Shiftnet and Shiftnet Package Manager", "nodisplay", "fundamental"));

            //0.1.1/re-adds
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Desktop Icons - 50 CP", null, "A brilliant new invention from the ShiftOS developers has come: Desktop Icons - These, much like the App Launcher, allow you to launch applications as well as other files from the desktop.", "alshiftnetapps", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Desktop Icons - 25 CP", null, "This upgrade allows the customization of ShiftOS desktop icons.", "advancedshifter;desktopicons", "fancy"));

            //0.1.1/hidden
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Other Player Story - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("DevX Furious - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Aiden Nirh - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Hacker101 - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Other Player Rescue - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Hacking - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Hack Command - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Hacker Battles - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Mid Game Bridge - 0 CP", null, null, "nodisplay", "fundamental"));

            //0.1.1/new
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Fancy Effects - 5000 CP", null, "Have you ever wanted to make your operating system look fancy, adding fade effects and other animations to various parts of the UI? If so, this upgrade is for you!", "limitlesscustomshades;shiftnet", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Shift Fancy Effects - 45 CP", null, "ShiftOS is looking pretty darn fine now. But, let's make it look even better. With this upgrade you will be able to customize fancy effects in the Shifter!", "advancedshifter;fancyeffects", "fancy"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Icon Manager - 45 CP", null, "Add even more customization options to ShiftOS using the new Icon Manager. This tool allows you to change almost any icon on the system!", "advancedshifter;appicons", "useful"));
            //0.1.1/category
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Useful - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Fancy - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("Software - 0 CP", null, null, "nodisplay", "fundamental"));
            DefaultUpgrades.Add(new Shiftorium.Upgrade("HoloChat - 0 CP", null, null, "nodisplay", "fundamental"));
        }

        /// <summary>
        /// Updates the registry.
        /// </summary>
        public static void UpdateShiftorium()
        {
            ShiftoriumUpgrades.Clear();

            SetDefaultShiftoriumValues();
            try
            {
                string shiftoriumjson = File.ReadAllText(Paths.SystemDir + "_shiftorium.json");
                var newUpgrades = new Dictionary<string, bool>();
                if (shiftoriumjson.StartsWith("{"))
                {
                    newUpgrades = JsonConvert.DeserializeObject<Dictionary<string, bool>>(shiftoriumjson);
                }
                else
                {
                    newUpgrades = JsonConvert.DeserializeObject<Dictionary<string, bool>>(API.Encryption.Decrypt(shiftoriumjson));
                }
                foreach (KeyValuePair<string, bool> kv in newUpgrades)
                {
                    try
                    {
                        ShiftoriumUpgrades[kv.Key] = kv.Value;
                    } catch(Exception ex)
                    {
                        Console.WriteLine("[Shiftorium/Registry] [ERROR] Upgrade {0} from disk doesn't seem to be found in the 'Default Upgrades' dictionary. This may be caused by a bug.", kv.Key);
                    }
                }
            }
            catch (Exception ex)
            {
                string shiftoriumjson = JsonConvert.SerializeObject(ShiftoriumUpgrades);
                if (API.DeveloperMode == true)
                {
                    File.WriteAllText(Paths.SystemDir + "_shiftorium.json", shiftoriumjson);
                }
                else
                {
                    File.WriteAllText(Paths.SystemDir + "_shiftorium.json", API.Encryption.Encrypt(shiftoriumjson));
                }
            }
        }

        /// <summary>
        /// This void adds the DEFAULT Shiftorium Upgrade values to the Upgrade dictionary to prevent a crash. Add new upgrades here.
        /// </summary>
        public static void SetDefaultShiftoriumValues()
        {
            setUpgrades();
            foreach (Shiftorium.Upgrade upgrade in DefaultUpgrades)
            {
                ShiftoriumUpgrades.Add(upgrade.id, false);
            }
        }
}
}

namespace Shiftorium
{
    public class Utilities
    {
        /// <summary>
        /// Buy an upgrade.
        /// </summary>
        /// <param name="upgradeToBuy">Upgrade name</param>
        /// <returns>Whether the upgrade could be bought.</returns>
        public static bool Buy(Upgrade upgradeToBuy)
        {
            if(API.Codepoints >= upgradeToBuy.Cost)
            {
                SaveSystem.ShiftoriumRegistry.ShiftoriumUpgrades[upgradeToBuy.id] = true;
                SaveSystem.Utilities.LoadedSave.codepoints -= upgradeToBuy.Cost;
                SaveSystem.Utilities.saveGame();
                API.UpdateWindows();
                API.Log("[Shiftorium] Upgrade \"" + upgradeToBuy.id + "\" bought successfully, game saved.");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method is for a virus.
        /// </summary>
        /// <param name="id"></param>
        public static void Unbuy(string id)
        {
            if(API.Upgrades.ContainsKey(id))
            {
                foreach(Shiftorium.Upgrade upg in SaveSystem.ShiftoriumRegistry.DefaultUpgrades)
                {
                    if(upg.Dependencies.Contains(id))
                    {
                        Unbuy(upg.id);
                    }
                }
                API.Upgrades[id] = false;
                SaveSystem.Utilities.saveGame();
            }
        }

        /// <summary>
        /// Gets all upgrades that have not been bought and returns them to the caller.
        /// </summary>
        /// <returns></returns>
        public static List<Upgrade> GetAvailable()
        {
            List<Upgrade> available = new List<Upgrade>();
            foreach(Upgrade upgrade in SaveSystem.ShiftoriumRegistry.DefaultUpgrades)
            {
                if (SaveSystem.ShiftoriumRegistry.ShiftoriumUpgrades[upgrade.id] == false)
                {
                    try
                    {
                        if (BoughtAllDependencies(upgrade))
                        {
                            available.Add(upgrade);

                        }


                    }
                    catch (Exception ex)
                    {
                        if (upgrade.id.Contains("dummy"))
                        {
                            available.Add(upgrade);

                        }
                    }
                }
                

            }
            return available;
        }

        /// <summary>
        /// Checks if you've bought all the dependencies of this upgrade.
        /// </summary>
        /// <param name="upgradeToCheck">Upgrade to search</param>
        /// <returns>Whether you bought 'em all.</returns>
        public static bool BoughtAllDependencies(Upgrade upgradeToCheck)
        {
            bool yes = true;
            foreach(string id in upgradeToCheck.Dependencies)
            {
                if(API.Upgrades[id] == false)
                {
                    yes = false;
                }
            }
            return yes;
        }
    }

    public class Upgrade
    {
        /// <summary>
        /// Initializes a new Shiftorium Upgrade.
        /// </summary>
        /// <param name="name">Name of the upgrade shown to the user.</param>
        ///<param name="preview">An image that is shown below the upgrade description.</param>
            /// <param name="desc">A small description of the upgrade.</param>
        public Upgrade(string name, Image preview, string desc, string dependencies, string cat) {
            string[] splitname = name.Split('-');

            string[] splitcp = splitname[1].Remove(0, 1).Split(' ');
            int cp = Convert.ToInt16(splitcp[0]);

            if(dependencies != null)
            {
                foreach(string id in dependencies.Split(';'))
                {
                    Dependencies.Add(id);
                }
            }

            Preview = preview;
            id = splitname[0].ToLower().Replace(" ", "");
            Name = name;
            Description = desc;
            Cost = cp;
            Category = cat;
        }
        public List<string> Dependencies = new List<string>();
        public string id = "sampleupgrade";
        public string Name = "Sample Upgrade";
        public int Cost = 0;
        public Image Preview = ShiftOS.Properties.Resources.upgradegray;
        public string Description = "Sample Shiftorium Upgrade.";
        public string Category = "fundamental";
    }
}
