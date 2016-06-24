using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Drawing;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net;
using System.ComponentModel;

namespace ShiftOS
{
    public static class Consts
    {
        public const string Version = "0.1.2";
    }

    public class Settings
    {
        public int MusicVolume { get; set; }
    }

    public class PanelButton
    {
        /// <summary>
        /// Initializes a new instance of a Panel Button model.
        /// </summary>
        /// <param name="name">The text displayed on the button.</param>
        /// <param name="icon">The icon displayed on the button.</param>
        /// <param name="formToManage">The form that is managed by the button.</param>
        public PanelButton(string name, Image icon, ref Form formToManage)
        {
            Name = name;
            Icon = icon;
            FormToManage = formToManage;
        }

        public string Name { get; set; }
        public Image Icon { get; set; }
        public Form FormToManage { get; set; }
    }

    public class ApplauncherItem
    {
        public ApplauncherItem(string name, Image icn, string lua, bool disp) 
        {
            Name = name;
            Icon = icn;
            Lua = lua;
            Display = disp;
        }
        public string Name { get; set; }
        public Image Icon { get; set; }
        public string Lua { get; set; } //ShiftCode that decides what ShiftOS will do when the item is clicked.
        public bool Display { get; set; }
    }

    public class ModApplauncherItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        /// <summary>
        /// Legacy mod AL entries for compatibilty
        /// </summary>
        public string ShiftCode { get; set; } //ShiftCode that decides what ShiftOS will do when the item is clicked.
        
        public string Lua { get; set; }

        public Form FormToOpen { get; set; } //If ShiftCode == "openForm", ShiftOS will open this form.
        public bool Display { get; set; }
        public string AppDirectory { get; set; }
    }


    public class API
    {

        /// <summary>
        /// Settings file.
        /// </summary>
        public static Settings LoadedSettings = null;

        /// <summary>
        /// Whether or not dev commands like '05tray' are available.
        /// Typically, this is set to true if the release is classified as
        /// an alpha, beta, or release candidate.
        /// 
        /// Turn it off if the release is the final RC, or the stable release!
        /// 
        /// Enabling developer mode will cause the save engine to not encrypt the save file
        /// or Shiftorium Registry on save, enabling you to easily modify your save
        /// to test new features or to bring in lots of codepoints. This is why
        /// Developer mode should ALWAYS be off in non-dev releases, to prevent cheating.
        /// </summary>
        public static bool DeveloperMode = true;

        /// <summary>
        /// If this is true, only certain applications will open and only
        /// certain features will work.
        /// 
        /// This is useful for story plots like the End Game where you don't
        /// want the user being distracted by novelty features when they should
        /// be focusing on what's happening.
        /// 
        /// Think of it like the opposite of what Developer Mode would do.
        /// </summary>
        public static bool LimitedMode = false;

        public static bool InfoboxesPlaySounds = true;

        public static void SkinControl(Control c)
        {
            if(c is Button)
            {
                var b = c as Button;
                b.FlatStyle = FlatStyle.Flat;
            }
            if(c is Panel || c is FlowLayoutPanel)
            {
                foreach(Control child in c.Controls)
                {
                    SkinControl(child);
                }
            }
        }

        public static List<Process> RunningModProcesses = new List<Process>();
        public static Dictionary<string, string> CommandAliases = new Dictionary<string, string>();
        public static Terminal LoggerTerminal = null;
        
        /// <summary>
        /// Logs an exception to the log.
        /// </summary>
        /// <param name="Message">The text to log.</param>
        /// <param name="fatal">Is it a fatal crash?</param>
        public static void LogException(string Message, bool fatal)
        {
            if(!File.Exists(Paths.SystemDir + "_Log.txt"))
            {
                if (fatal == true)
                {
                    File.WriteAllText(Paths.SystemDir + "_Log.txt", GetLogTime() + " [ExWatch/WARNING] ShiftOS has encountered an UNHANDLED exception with message \"" + Message + "\". Report this to Michael as well as what you were doing when it happened ASAP.");
                }
                else
                {
                    File.WriteAllText(Paths.SystemDir + "_Log.txt", GetLogTime() + " ShiftOS encountered a handled exception with message \"" + Message + "\" and was able to keep going. Ignore this.");
                }
            }
            else
            {
                List<string> Entries = new List<string>();
                foreach(string entry in File.ReadAllLines(Paths.SystemDir + "_Log.txt")) {
                    Entries.Add(entry);
                }
                if (fatal == true)
                {
                    Entries.Add(GetLogTime() + " [ExWatch/WARNING] ShiftOS has encountered an UNHANDLED exception with message \"" + Message + "\". Report this to Michael as well as what you were doing when it happened ASAP.");
                }
                else
                {
                    Entries.Add(GetLogTime() + " ShiftOS encountered a handled exception with message \"" + Message + "\" and was able to keep going. Ignore this.");
                }
                File.WriteAllLines(Paths.SystemDir + "_Log.txt", Entries.ToArray());
            }
        }

        /// <summary>
        /// Logs text to the log file.
        /// </summary>
        /// <param name="Message">The text to log.</param>
        public static void Log(string Message)
        {
            if (!File.Exists(Paths.SystemDir + "_Log.txt"))
            {
                File.WriteAllText(Paths.SystemDir + "_Log.txt", GetLogTime() + " " + Message);
            }
            else
            {
                List<string> Entries = new List<string>();
                foreach (string entry in File.ReadAllLines(Paths.SystemDir + "_Log.txt"))
                {
                    Entries.Add(entry);
                }
                Entries.Add(GetLogTime() + " " + Message);
                File.WriteAllLines(Paths.SystemDir + "_Log.txt", Entries.ToArray());
            }
        }

        /// <summary>
        /// Gets a proper-formatted date/time string for the log.
        /// </summary>
        /// <returns></returns>
        public static string GetLogTime()
        {
            return "[" + DateTime.Now.ToLongDateString() + "\\" + DateTime.Now.ToLongTimeString() + "]";
        }
        
        /// <summary>
        /// Property representing the currently loaded name pack.
        /// </summary>
        public static Skinning.NamePack LoadedNames
        {
            get
            {
                if (Skinning.Utilities.LoadedNames != null)
                {
                    return Skinning.Utilities.LoadedNames;
                }
                else
                {
                    Skinning.Utilities.LoadedNames = new Skinning.NamePack();
                    Skinning.Utilities.loadedSkin.EmbeddedNamePackPath = "names.npk";
                    Skinning.Utilities.SaveEmbeddedNamePack();
                    Log("[Name Changer] Couldn't locate loaded name pack, using default name pack.");
                    return Skinning.Utilities.LoadedNames;
                }
            }
        }

        /// <summary>
        /// Adds a command line alias.
        /// </summary>
        /// <param name="key">Alias name</param>
        /// <param name="value">Command to run.</param>
        /// <returns></returns>
        public static bool AddAlias(string key, string value)
        {
            if(!AliasExists(key))
            {
                CommandAliases.Add(key, value);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Saves alias list to save game.
        /// </summary>
        public static void SaveAliases()
        {
            string json = JsonConvert.SerializeObject(CommandAliases);
            File.WriteAllText(Paths.SystemDir + "_aliases.json", json);
        }

        /// <summary>
        /// Loads alias list from the save game.
        /// </summary>
        public static void LoadAliases()
        {
            if (File.Exists(Paths.SystemDir + "_aliases.json")) {
                string json = File.ReadAllText(Paths.SystemDir + "_aliases.json");
                CommandAliases = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                CommandAliases = new Dictionary<string, string>();
            }

        }

        /// <summary>
        /// Removes an alias from the list.
        /// </summary>
        /// <param name="key">Alias to remove.</param>
        /// <returns>Whether the alias could be removed.</returns>
        public static bool RemoveAlias(string key)
        {
            if(AliasExists(key))
            {
                CommandAliases.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the provided alias exists.
        /// </summary>
        /// <param name="key">The alias to check.</param>
        /// <returns>Whether the alias exists.</returns>
        public static bool AliasExists(string key)
        {
            bool no = false;
            foreach(KeyValuePair<string, string> kv in CommandAliases)
            {
                if(kv.Key == key)
                {
                    no = true;
                }
            }
            return no;
        }

        /// <summary>
        /// I have no idea what this does - Michael
        /// </summary>
        /// <param name="AppName"></param>
        public static void CreateNewLoggerTerminal(string AppName)
        {
            CreateForm(new Terminal(true), AppName, Properties.Resources.iconTerminal);
        }

        public const string HiddenAPMCommand = "0Ifm0DcBBy10VZo/p4r1Jg==";
        public const string HiddenBTNConvertCommand = "js2qrls5kvZnutMbfH46sUKzKVrBtjzPlWn/wIIe/3g=";
        public const string HiddenDodgeCommand = "mpL4WPUoDcZrsXnNUJ5RWQ==";
        public const string HiddenLabyrinthCommand = "NbNzpplGKaS5D/RdwrQMXw==";
        public const string HiddenQuickChatCommand = "iQm+/qDqgkHT/zgPiYRlZQ==";
        public const string HiddenShiftnetCommand = "NCM++hbZox7B+m9tXRXGnw==";
        public const string HiddenBWalletCommand = "1nLiZELFcaxkXDufrLuyfw==";
        public const string HiddenBDiggerCommand = "g/efSjsaglt//dr3XHnPOw==";
        public const string HiddenDecryptorCommand = "CYPXaweggfWAuS7ONt/OPQ==";

        /// <summary>
        /// Launches an saa file, hooks it up to the Lua API, and runs it.
        /// </summary>
        /// <param name="modSAA">File to run.</param>
        public static void LaunchMod(string modSAA)
        {
            if (!LimitedMode)
            {
                if (Upgrades["shiftnet"] == true)
                {
                    if (File.Exists(modSAA))
                    {
                        if (File.ReadAllText(modSAA) == HiddenAPMCommand)
                        {
                            CreateForm(new Appscape(), "Appscape Package Manager", Properties.Resources.iconAppscape);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenDecryptorCommand)
                        {
                            CreateForm(new ShiftnetDecryptor(), "Shiftnet Decryptor", Properties.Resources.iconShiftnet);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenBDiggerCommand)
                        {
                            CreateForm(new BitnoteDigger(), "Bitnote Digger", Properties.Resources.iconBitnoteDigger);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenBWalletCommand)
                        {
                            CreateForm(new BitnoteWallet(), "Bitnote Wallet", Properties.Resources.iconBitnoteWallet);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenShiftnetCommand)
                        {
                            CreateForm(new Shiftnet(), "Shiftnet", Properties.Resources.iconShiftnet);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenBTNConvertCommand)
                        {
                            CreateForm(new BitnoteConverter(), "Bitnote Converter", Properties.Resources.iconBitnoteWallet);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenDodgeCommand)
                        {
                            CreateForm(new Dodge(), "Dodge", Properties.Resources.iconDodge);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenLabyrinthCommand)
                        {
                            CreateForm(new Labyrinth(), "Labyrinth", null);
                        }
                        else if (File.ReadAllText(modSAA) == HiddenQuickChatCommand)
                        {
                            CreateForm(new QuickChat(), "QuickChat", null);
                        }
                        else
                        {
                            try
                            {
                                ExtractFile(modSAA, Paths.Mod_Temp, true);
                                var l = new LuaInterpreter(Paths.Mod_Temp + "main.lua");
                            }
                            catch (Exception ex)
                            {
                                LogException("Error launching mod file (.saa): " + ex.Message, false);
                                CreateInfoboxSession("Error", "Could not launch the .saa file you specified. It is unsupported by this version of ShiftOS.", infobox.InfoboxMode.Info);
                            }
                        }
                        var story_rnd = new Random();
                        int story_chance = story_rnd.Next(0, 3);
                        switch (story_chance) {
                            case 2:
                                if(API.Upgrades["holochat"] == false)
                                {
                                    var t = new Terminal();
                                    API.CreateForm(t, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
                                    t.StartDevXFuriousStory();
                                    t.BringToFront();
                                }
                                break;
                        }

                    }
                    else
                    {
                        throw new ModNotFoundException();
                    }
                }
            }
            else
            {
                CreateInfoboxSession("Limited mode", "ShiftOS is in limited mode and cannot perform this action. Please complete the current Mission first.", infobox.InfoboxMode.Info);
            }
        }
        

        /// <summary>
        /// Source: http://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
        /// 
        /// String cryptography wrapper for ShiftOS.
        /// </summary>
        public static class Encryption
        {
            private static readonly string passPhrase = "h8gf9dh790df87h9";

            // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
            // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
            // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            // This constant is used to determine the keysize of the encryption algorithm.
            private const int keysize = 256;

            /// <summary>
            /// Encrypt a string.
            /// </summary>
            /// <param name="plainText">Raw string to encrypt.</param>
            /// <returns>The encrypted string.</returns>
            public static string Encrypt(string plainText)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Decrypts an encrypted string.
            /// </summary>
            /// <param name="cipherText">The encrypted string.</param>
            /// <returns>The decrypted string.</returns>
            public static string Decrypt(string cipherText)
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Property representing the current client Bitnote address.
        /// </summary>
        public static SaveSystem.PrivateBitnoteAddress BitnoteAddress
        {
            get
            {
                return SaveSystem.Utilities.BitnoteAddress;
            }
        }

        public static class BitnoteEncryption
        {
            private static readonly string passPhrase = "jonathan_ladouceur_sucks_and_bitnotes_rock";

            // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
            // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
            // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            // This constant is used to determine the keysize of the encryption algorithm.
            private const int keysize = 256;

            /// <summary>
            /// Encrypts text using the bitnote passphrase.
            /// </summary>
            /// <param name="plainText">The raw string.</param>
            /// <returns>The encrypted string.</returns>
            public static string Encrypt(string plainText)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Decrypts an encrypted string using the Bitnote passphrase.
            /// </summary>
            /// <param name="cipherText">The encrypted text.</param>
            /// <returns>The decrypted text.</returns>
            public static string Decrypt(string cipherText)
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Creates a new File Skimmer session.
        /// </summary>
        /// <param name="Filters">What file types can be shown when the mode is set to Open, or what file types can be saved to when mode is set to Save.</param>
        /// <param name="mode">The display mode of the File Skimmer.</param>
        public static void CreateFileSkimmerSession(string Filters, File_Skimmer.FileSkimmerMode mode)
        {
            FileSkimmerSession = new File_Skimmer(mode, Filters);
            CreateForm(FileSkimmerSession, "File Skimmer", Properties.Resources.iconFileSkimmer);
        }

        /// <summary>
        /// Call this during a closing event on a File Skimmer session to get the user's input.
        /// </summary>
        /// <returns>The user's input.</returns>
        public static string GetFSResult()
        {
            string result = "";
            if (FileSkimmerSession != null)
            {
                if (FileSkimmerSession.FileName != "")
                {
                    result = FileSkimmerSession.FileName;
                }
                else
                {
                    result = "fail";
                }
            }
            else
            {
                result = "fail";
                throw new InvalidSessionException("The File Skimmer session was not started. Try running API.CreateFileSkimmerSession().");
            }
            return result;
        }

        public static File_Skimmer FileSkimmerSession = null;


        public static List<PanelButton> PanelButtons = new List<PanelButton>();
        public static string LastRanCommand = "";

        public static List<ApplauncherItem> AppLauncherItems = new List<ApplauncherItem>();

        /// <summary>
        /// A dictionary of every single icon entry in the Icon Manager.
        /// </summary>
        public static Dictionary<string, Image> IconRegistry
        {
            get
            {
                return Skinning.Utilities.IconRegistry;
            }
        }

        /// <summary>
        /// Gets an icon from the Icon Registry.
        /// </summary>
        /// <param name="id">The ID of the icon.</param>
        /// <returns>The icon, if it exists, null if it doesn't.</returns>
        public static Image GetIcon(string id)
        {
            if(IconRegistry != null)
            {
                if(IconRegistry.ContainsKey(id))
                {
                    return IconRegistry[id];
                }
                else
                {
                    return Properties.Resources.NoIconFound;
                }
            }
            else
            {
                return Properties.Resources.NoIconFound;
            }
        }

        /// <summary>
        /// Creates a list of App Launcher Items based on what you've bought in the Shiftorium.
        /// </summary>
        public static void GetAppLauncherItems()
        {
            Skinning.Utilities.LoadEmbeddedNamePack();
            //System Applications
            AppLauncherItems.Clear();
            if (!LimitedMode)
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.ArtpadName, GetIcon("Artpad"), "open_program('artpad')", Upgrades["alartpad"]));
            AppLauncherItems.Add(new ApplauncherItem(LoadedNames.FileSkimmerName, GetIcon("FileSkimmer"), "open_program('file_skimmer')", Upgrades["alfileskimmer"]));
            if (!LimitedMode)
            {
                AppLauncherItems.Add(new ApplauncherItem("Network Browser", GetIcon("NetworkBrowser"), "open_program('netbrowse')", Upgrades["networkbrowser"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.SkinLoaderName, GetIcon("SkinLoader"), "open_program('skinloader')", Upgrades["skinning"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.ShiftoriumName, GetIcon("Shiftorium"), "open_program('shiftorium')", Upgrades["alshiftorium"]));
            }
            AppLauncherItems.Add(new ApplauncherItem("HoloChat", GetIcon("HoloChat"), "open_program('holochat')", API.Upgrades["holochat"]));
            if (!LimitedMode)
            {
                AppLauncherItems.Add(new ApplauncherItem("Icon Manager", GetIcon("IconManager"), "open_program('iconmanager')", Upgrades["iconmanager"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.ShifterName, GetIcon("Shifter"), "open_program('shifter')", Upgrades["alshifter"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.NameChangerName, GetIcon("NameChanger"), "open_program('name_changer')", Upgrades["namechanger"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.PongName, GetIcon("Pong"), "open_program('pong')", Upgrades["alpong"]));
            }
            if(LimitedMode)
            {
                AppLauncherItems.Add(new ApplauncherItem("Quest Viewer", GetIcon("QuestViewer"), "open_program('quests')", true));
            }
            AppLauncherItems.Add(new ApplauncherItem(LoadedNames.TextpadName, GetIcon("TextPad"), "open_program('textpad')", Upgrades["altextpad"]));
            AppLauncherItems.Add(new ApplauncherItem(LoadedNames.TerminalName, GetIcon("Terminal"), "open_terminal()", true));
            if (!LimitedMode)
            {
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.KnowledgeInputName, GetIcon("KI"), "open_program('ki')", true));


                //System Features
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.UnityName, GetIcon("Unity"), "toggle_unity()", Upgrades["alunity"]));
                AppLauncherItems.Add(new ApplauncherItem(LoadedNames.ShutdownName, GetIcon("Shutdown"), "shutdown()", Upgrades["applaunchershutdown"]));
            }
        }

        /// <summary>
        /// The current Skin.
        /// </summary>
        public static Skinning.Skin CurrentSkin
        {
            get
            {
                return Skinning.Utilities.loadedSkin;
            }
        }

        public static ShiftOSDesktop CurrentSession = null; //The current ShiftOS desktop session.

        /// <summary>
        /// All the graphical elements of the current Skin.
        /// </summary>
        public static Skinning.Images CurrentSkinImages
        {
            get
            {
                return Skinning.Utilities.loadedskin_images;
            }
        }

        /// <summary>
        /// Plays a sound inside the Properties.Resources class.
        /// </summary>
        /// <param name="file">The unmanaged memory stream to play.</param>
        public static void PlaySound(UnmanagedMemoryStream file)
        {
            Stream str = file;
            SoundPlayer player = new SoundPlayer(str);
            player.Play();
        }

        /// <summary>
        /// Plays a sound from a byte[] array. Useful for MP3s and other formats.
        /// </summary>
        /// <param name="file">The byte[] aray</param>
        public static void PlaySound(byte[] file)
        {
            Stream mstr = new MemoryStream(file);
            SoundPlayer player = new SoundPlayer(mstr);
            player.Play();
        }

        /// <summary>
        /// Shiftorium upgrades.
        /// </summary>
        public static Dictionary<string, bool> Upgrades
        {
            get
            {
                return SaveSystem.ShiftoriumRegistry.ShiftoriumUpgrades;
            }
        }

        /// <summary>
        /// Creates a graphic picker session.
        /// </summary>
        /// <param name="GraphicName">The title of the graphic.</param>
        /// <param name="ShowMouseImages">Should the user be able to pick mouse-over/mouse-down images?</param>
        public static void CreateGraphicPickerSession(string GraphicName, bool ShowMouseImages)
        {
            GraphicPickerSession = new Graphic_Picker(GraphicName, ShowMouseImages);
            CreateForm(GraphicPickerSession, GraphicName, Properties.Resources.icongraphicpicker);
        }

        public static Graphic_Picker GraphicPickerSession = null;

        /// <summary>
        /// Call this in a closing event of a Graphic Picker session to get whether the user actually chose images.
        /// </summary>
        /// <returns>"OK" if the user chose an image, "fail" if not and "fail" if the session wasn't created.</returns>
        public static string GetGraphicPickerResult()
        {
            if(GraphicPickerSession != null)
            {
                string result = null;
                if (GraphicPickerSession.Result == "OK")
                {
                    result = "OK";
                }
                else
                {
                    result = "fail";
                }
                return result;
            }
            else {
                return "fail";
                throw new InvalidSessionException();
            }
        }

        /// <summary>
        /// The name of the OS defined by the user.
        /// </summary>
        public static string OSName
        {
            get
            {
                return SaveSystem.Utilities.LoadedSave.osname;
            }
            set
            {
                SaveSystem.Utilities.LoadedSave.osname = value;
            }
        }

        /// <summary>
        /// The username defined by the user.
        /// </summary>
        public static string Username
        {
            get
            {
                return SaveSystem.Utilities.LoadedSave.username;
            }
            set
            {
                SaveSystem.Utilities.LoadedSave.username = value;
            }
        }

        /// <summary>
        /// Current ammount of codepoints.
        /// </summary>
        public static int Codepoints
        {
            get
            {
                return SaveSystem.Utilities.LoadedSave.codepoints;
            }
        }

        /// <summary>
        /// Adds the specified amount of Codepoints.
        /// </summary>
        /// <param name="cp">Amount to add.</param>
        public static void AddCodepoints(int cp)
        {
            SaveSystem.Utilities.LoadedSave.codepoints += cp * CurrentSave.CodepointMultiplier;
        }

        /// <summary>
        /// Removes the specified amount of Codepoints if you have enough.
        /// </summary>
        /// <param name="cp">Amount to remove.</param>
        public static void RemoveCodepoints(int cp)
        {
            if (Codepoints >= cp)
            {
                SaveSystem.Utilities.LoadedSave.codepoints -= cp;
            }
        }


        /// <summary>
        /// The proper way to shut down ShiftOS.
        /// </summary>
        public static void ShutDownShiftOS()
        {
            File.WriteAllText(Paths.SystemDir + "settings.json", JsonConvert.SerializeObject(LoadedSettings));
            Audio.running = false;
            if (!LimitedMode)
            {
                //Disconnect from server.
                try
                {
                    foreach (var ip in Package_Grabber.clients)
                    {
                        if (ip.Value.IsConnected)
                            ip.Value.Disconnect();
                    }
                }
                catch
                {

                }
                //Close all mods.
                WindowComposition.ShuttingDown = true;
                if (RunningModProcesses.Count > 0)
                {
                    foreach (Process mod in RunningModProcesses)
                    {
                        try
                        {
                            mod.Kill();
                        }
                        catch (Exception ex)
                        {
                            LogException(ex.Message, false);
                        }
                    }
                    SaveSystem.Utilities.saveGame();
                    Application.Exit();

                }
                SaveSystem.Utilities.saveGame();
                //Right before the game closes...
                try
                {
                    if (Directory.Exists(Paths.Mod_Temp))
                        Directory.Delete(Paths.Mod_Temp, true);
                }
                catch (Exception ex)
                {
                    API.LogException(ex.Message, false);
                }
                finally
                {
                    //Alright, ShiftOS! HAVE AT IT!
                    Application.Exit();
                }
            }
            else
            {
                CreateInfoboxSession("Limited mode", "ShiftOS is in limited mode and cannot be shut down. Please complete the current mission before shutting down.", infobox.InfoboxMode.Info);
            }
        }

        /// <summary>
        /// Special zip file extractor method.
        /// </summary>
        /// <param name="zipFile">File to extract.</param>
        /// <param name="dir">Target directory.</param>
        /// <param name="deleteDir">Delete the target first?</param>
        public static void ExtractFile(string zipFile, string dir, bool deleteDir)
        {
            if (Directory.Exists(dir) && deleteDir == true)
            {
                Directory.Delete(dir, true);
                Directory.CreateDirectory(dir);
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            ZipFile.ExtractToDirectory(zipFile, dir);
        }

        /// <summary>
        /// Close all open applications (besides Desktop, and HijackScreen.)
        /// </summary>
        public static void CloseEverything()
        {
            PanelButtons.Clear();
            OpenPrograms.Clear();
            List<Form> formsToClose = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                switch (frm.Name)
                {
                    case "ShiftOSDesktop":
                    case "HijackScreen":
                        //Do nothing.
                        break;
                    default:
                        formsToClose.Add(frm);
                        break;
                }
            }
            foreach (Form frm in formsToClose)
            {
                frm.Close();
            }
        }

        /// <summary>
        /// Current save.
        /// </summary>
        public static SaveSystem.Save CurrentSave
        {
            get
            {
                return SaveSystem.Utilities.LoadedSave;
            }
        }

        public static List<Form> OpenPrograms = new List<Form>();
        public static List<WindowBorder> BordersToUpdate = new List<WindowBorder>();

        /// <summary>
        /// Transforms a standard Windows Form into a ShiftOS form.
        /// </summary>
        /// <param name="formToCreate">The Windows Form object to create.</param>
        /// <param name="AppName">Title to display</param>
        /// <param name="AppIcon">Icon to display on the titlebar.</param>
        public static void CreateForm(Form formToCreate, string AppName, Image AppIcon)
        {
            if(API.CurrentSession == null)
            {
                API.CurrentSession = new ShiftOSDesktop();
            }
            try
            {
                if (Upgrades["multitasking"] == false && formToCreate.Name != "infobox")
                {
                    CloseEverything();
                }
                var bw = new BackgroundWorker();
                bw.DoWork += (object sen, DoWorkEventArgs eva) =>
                {
                    WindowComposition.SafeToAddControls = false;
                //bugfix: Close any terminal if WindowedTerminal isn't installed.
                if (Upgrades["windowedterminal"] == false)
                    {
                        API.CurrentSession.Invoke(new Action(() =>
                        {
                            foreach (Form frm in OpenPrograms)
                            {
                                if (frm.Name.ToLower() == "terminal")
                                {
                                    API.CurrentSession.Invoke(new Action(() =>
                                    {
                                        frm.Close();
                                    }));
                                }
                            }
                        }));
                    }
                    WindowBorder brdr = new WindowBorder(AppName, AppIcon);
                    brdr.Name = "api_brdr";
                    formToCreate.Controls.Add(brdr);
                    formToCreate.ShowInTaskbar = false;
                    brdr.Show();
                    formToCreate.FormBorderStyle = FormBorderStyle.None;
                    brdr.Dock = DockStyle.Fill;
                    BordersToUpdate.Add(brdr);
                    List<Control> duplicates = new List<Control>();
                    foreach (Control ctrl in formToCreate.Controls)
                    {
                        if (ctrl.Name != "api_brdr")
                        {
                            ctrl.Hide();
                            brdr.pgcontents.Controls.Add(ctrl);
                            duplicates.Add(ctrl);
                        }
                    }
                    foreach (Control ctrl in duplicates)
                    {
                        try
                        {
                            formToCreate.Controls.Remove(ctrl);
                            ctrl.Show();
                            SkinControl(ctrl);
                        }
                        catch
                        {
                            API.CurrentSession.Invoke(new Action(() =>
                            {
                                ctrl.Show();
                                SkinControl(ctrl);
                            }));
                        }
                    }
                    WindowComposition.ShowForm(formToCreate, CurrentSkin.WindowOpenAnimation);
                    API.CurrentSession.Invoke(new Action(() =>
                    {
                        brdr.justopened = true;
                        formToCreate.TopMost = true;

                    //Open terminal on CTRL+T press on any form.
                    formToCreate.KeyDown += (object sender, KeyEventArgs e) =>
                        {
                            if (e.KeyCode == Keys.T && e.Control && formToCreate.Name != "Terminal")
                            {
                                CreateForm(new Terminal(), CurrentSave.TerminalName, Properties.Resources.iconTerminal);
                            }
                            if (formToCreate.Name != "Terminal" || Upgrades["windowedterminal"] == true)
                            {
                            //Movable Windows
                            if (API.Upgrades["movablewindows"] == true)
                                {
                                    if (e.KeyCode == Keys.A && e.Control)
                                    {
                                        e.Handled = true;
                                        formToCreate.Location = new Point(formToCreate.Location.X - 30, formToCreate.Location.Y);
                                    }
                                    if (e.KeyCode == Keys.D && e.Control)
                                    {
                                        e.Handled = true;
                                        formToCreate.Location = new Point(formToCreate.Location.X + 30, formToCreate.Location.Y);
                                    }
                                    if (e.KeyCode == Keys.W && e.Control)
                                    {
                                        e.Handled = true;
                                        formToCreate.Location = new Point(formToCreate.Location.X, formToCreate.Location.Y - 30);
                                    }
                                    if (e.KeyCode == Keys.S && e.Control)
                                    {
                                        e.Handled = true;
                                        formToCreate.Location = new Point(formToCreate.Location.X, formToCreate.Location.Y + 30);
                                    }
                                }
                            }
                        };
                        formToCreate.TransparencyKey = Skinning.Utilities.globaltransparencycolour;
                        OpenPrograms.Add(formToCreate);
                        if (AppName == "Enemy Hacker")
                        {
                            API.CurrentSession.Invoke(new Action(() =>
                            {
                                formToCreate.Left = Screen.PrimaryScreen.Bounds.Width - formToCreate.Width;
                            }));
                        }
                        else if (AppName == "You")
                        {
                            API.CurrentSession.Invoke(new Action(() =>
                            {
                                formToCreate.Left = 0;
                            }));
                        }
                    }));
                    WindowComposition.SafeToAddControls = true;
                };
                bw.RunWorkerAsync();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Semi-working way to implement form rolling.
        /// </summary>
        /// <param name="formToRoll">The form to roll.</param>
        public static void RollForm(Form formToRoll)
        {
            if (formToRoll.Height == CurrentSkin.titlebarheight)
            {
                string xyraw = (string)formToRoll.Tag;
                string[] data = xyraw.Split(' ');
                string[] xy = data[0].Split(',');
                int x = Convert.ToInt16(xy[0]);
                int y = Convert.ToInt16(xy[1]);
                int mx = Convert.ToInt16(xy[2]);
                int my = Convert.ToInt16(xy[3]);
                formToRoll.Size = new Size(x, y);
                formToRoll.MinimumSize = new Size(mx, my);
            }
            else {
                formToRoll.Tag = formToRoll.Width.ToString() + "," + formToRoll.Height.ToString() + "," + formToRoll.MinimumSize.Width.ToString() + "," + formToRoll.MinimumSize.Height.ToString() + " " + formToRoll.Location.X.ToString() + "," + formToRoll.Location.Y.ToString();
                formToRoll.MinimumSize = new Size(0, 0);
                formToRoll.Height = API.CurrentSkin.titlebarheight;
            }

        }

        /// <summary>
        /// Makes all open applications load their skin data.
        /// </summary>
        public static void UpdateWindows()
        {
            try
            {
                foreach (WindowBorder brdr in BordersToUpdate)
                {
                    brdr.setupall();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Gets time based on what Shiftorium Upgrades you've got.
        /// </summary>
        /// <returns>The time.</returns>
        public static string GetTime()
        {
            string time = "nothing";

            if (Upgrades["splitsecondtime"] == true)
            {
                time = DateTime.Now.ToLongTimeString();
            }
            else {
                if (Upgrades["minuteaccuracytime"] == true)
                {
                    if (System.DateTime.Now.Hour < 12)
                    {
                        time = (DateTime.Now.Hour + ":" + String.Format(DateTime.Now.Minute.ToString(), "00")).ToString() + " AM";
                    }
                    else {
                        time = (DateTime.Now.Hour + ":" + String.Format(DateTime.Now.Minute.ToString(), "00")).ToString() + " PM";
                    }
                }
                else {
                    if (Upgrades["pmandam"] == true)
                    {
                        if (System.DateTime.Now.Hour < 12)
                        {
                            time = DateTime.Now.Hour + " AM";
                        }
                        else {
                            time = DateTime.Now.Hour - 12 + " PM";
                        }
                    }
                    else {
                        if (Upgrades["hourssincemidnight"] == true)
                        {
                            time = Math.Floor(System.DateTime.Now.Subtract(System.DateTime.Today).TotalSeconds / 60 / 60).ToString();
                        }
                        else {
                            if (Upgrades["minutessincemidnight"] == true)
                            {
                                time = Math.Floor(System.DateTime.Now.Subtract(System.DateTime.Today).TotalSeconds / 60).ToString();
                            }
                            else {
                                if (Upgrades["secondssincemidnight"] == true)
                                {
                                    time = Math.Floor(System.DateTime.Now.Subtract(System.DateTime.Today).TotalSeconds).ToString();
                                }
                            }
                        }
                    }
                }
            }
            return time;
        }

        /// <summary>
        /// Broken terminal command...
        /// </summary>
        /// <param name="command">Who even knows what this is?</param>
        /// <returns>I don't know.</returns>
        public static bool CloseProgram(string command)
        {
            try
            {
                List<PanelButton> PanelButtonsToKill = new List<PanelButton>();
                bool closed = false;
                foreach (Form app in OpenPrograms)
                {
                    if (app.Name.ToLower() == command)
                    {
                        foreach (PanelButton pbtn in PanelButtons)
                        {
                            if (app.Name.ToLower() == pbtn.FormToManage.Name.ToLower())
                            {
                                PanelButtonsToKill.Add(pbtn);
                            }
                        }
                        app.Close();
                        closed = true;
                    }
                    else
                    {
                        //Because the Shiftorium is referred to as 'Frontend', we must close any 'Frontend' forms if the command is equal to the Shiftorium name.
                        if (app.Name.ToLower() == "frontend" && command == CurrentSave.ShiftoriumName.ToLower())
                        {
                            foreach (PanelButton pbtn in PanelButtons)
                            {
                                if (app.Name.ToLower() == pbtn.FormToManage.Name.ToLower())
                                {
                                    PanelButtonsToKill.Add(pbtn);
                                }
                            }
                            app.Close();
                            closed = true;
                        }
                    }
                }
                foreach (PanelButton pbtn in PanelButtonsToKill)
                {
                    PanelButtons.Remove(pbtn);
                }
                return closed;
            }
            catch
            {
                return false;
            }
        }

        public static void ToggleMinimized(Form frm)
        {
            if ((Point)frm.Tag == frm.Location)
            {
                MinimizeForm(frm);
            }
            else
            {
                UnminimizeForm(frm);
            }
        }

        public static void MinimizeForm(Form frm)
        {
            frm.Tag = frm.Location;
            frm.Location = new Point(99999, 99999);
        }

        public static void UnminimizeForm(Form frm)
        {
            frm.Location = (Point)frm.Tag;
        }

        /// <summary>
        /// Shows an infobox.
        /// </summary>
        /// <param name="Title">Title of Infobox.</param>
        /// <param name="Message">The text to display.</param>
        /// <param name="Mode">User interface mode.</param>
        public static void CreateInfoboxSession(string Title, string Message, infobox.InfoboxMode Mode)
        {
            if (InfoboxSession != null)
            {
                InfoboxSession.Result = "Killed";
                InfoboxSession.Close();
                InfoboxSession = null;
            }
            InfoboxSession = new infobox(Message, Mode);
            CreateForm(InfoboxSession, Title, Properties.Resources.iconInfoBox_fw);
        }

        /// <summary>
        /// Call this on the close event of an Infobox to get the user result.
        /// </summary>
        /// <returns>If mode is "YesNo" then you'll get the button the user clicked. If "TextEntry" then the text the user entered.</returns>
        public static string GetInfoboxResult()
        {
            string Value = "";
            if (InfoboxSession == null)
            {
                throw new InvalidSessionException("An attempt to get the result of an Infobox failed because the Infobox session was null.");
            }
            else
            {
                switch (InfoboxSession.Result)
                {
                    case "OK":
                        if (InfoboxSession.displayMode == infobox.InfoboxMode.TextEntry)
                        {
                            Value = InfoboxSession.TextEntry;
                        }
                        else
                        {
                            Value = "OK";
                        }
                        break;
                    case "Yes":
                        Value = "Yes";
                        break;
                    case "No":
                        Value = "No";
                        break;
                    default:
                        Value = "Cancelled";
                        break;
                }
            }
            return Value;
        }

        public static infobox InfoboxSession = null;

        public class KnowledgeInputData
        {
            public static Dictionary<string, bool> Animals = new Dictionary<string, bool>();
            public static Dictionary<string, bool> Countries = new Dictionary<string, bool>();
            public static Dictionary<string, bool> Fruits = new Dictionary<string, bool>();

            #region "A load of Knowledge Input additions."
            public static void RegisterDictionaries()
            {
                Animals.Add("aardvark", false);
                Animals.Add("albatross", false);
                Animals.Add("alligator", false);
                Animals.Add("alpaca", false);
                Animals.Add("ant", false);
                Animals.Add("anteater", false);
                Animals.Add("antelope", false);
                Animals.Add("ape", false);
                Animals.Add("armadillo", false);
                Animals.Add("ass", false);
                Animals.Add("baboon", false);
                Animals.Add("badger", false);
                Animals.Add("barracuda", false);
                Animals.Add("bat", false);
                Animals.Add("bear", false);
                Animals.Add("beaver", false);
                Animals.Add("bee", false);
                Animals.Add("bison", false);
                Animals.Add("boar", false);
                Animals.Add("buffalo", false);
                Animals.Add("butterfly", false);
                Animals.Add("camel", false);
                Animals.Add("caribou", false);
                Animals.Add("cat", false);
                Animals.Add("caterpillar", false);
                Animals.Add("cow", false);
                Animals.Add("chamois", false);
                Animals.Add("cheetah", false);
                Animals.Add("chicken", false);
                Animals.Add("chimpanzee", false);
                Animals.Add("chinchilla", false);
                Animals.Add("chough", false);
                Animals.Add("clam", false);
                Animals.Add("cobra", false);
                Animals.Add("cockroach", false);
                Animals.Add("cod", false);
                Animals.Add("cormorant", false);
                Animals.Add("coyote", false);
                Animals.Add("crab", false);
                Animals.Add("crane", false);
                Animals.Add("crocodile", false);
                Animals.Add("crow", false);
                Animals.Add("curlew", false);
                Animals.Add("deer", false);
                Animals.Add("dinosaur", false);
                Animals.Add("dog", false);
                Animals.Add("dogfish", false);
                Animals.Add("dolphin", false);
                Animals.Add("donkey", false);
                Animals.Add("dotterel", false);
                Animals.Add("dove", false);
                Animals.Add("dragonfly", false);
                Animals.Add("duck", false);
                Animals.Add("dugong", false);
                Animals.Add("dunlin", false);
                Animals.Add("eagle", false);
                Animals.Add("echidna", false);
                Animals.Add("eel", false);
                Animals.Add("eland", false);
                Animals.Add("elephant", false);
                Animals.Add("elephant seal", false);
                Animals.Add("elk", false);
                Animals.Add("emu", false);
                Animals.Add("falcon", false);
                Animals.Add("ferret", false);
                Animals.Add("finch", false);
                Animals.Add("fish", false);
                Animals.Add("flamingo", false);
                Animals.Add("fly", false);
                Animals.Add("fox", false);
                Animals.Add("frog", false);
                Animals.Add("galago", false);
                Animals.Add("gaur", false);
                Animals.Add("gazelle", false);
                Animals.Add("gerbil", false);
                Animals.Add("giant panda", false);
                Animals.Add("giraffe", false);
                Animals.Add("gnat", false);
                Animals.Add("gnu", false);
                Animals.Add("goat", false);
                Animals.Add("goldfinch", false);
                Animals.Add("goldfish", false);
                Animals.Add("goose", false);
                Animals.Add("gorilla", false);
                Animals.Add("goshawk", false);
                Animals.Add("grasshopper", false);
                Animals.Add("grouse", false);
                Animals.Add("guanaco", false);
                Animals.Add("guineafowl", false);
                Animals.Add("guinea pig", false);
                Animals.Add("gull", false);
                Animals.Add("hamster", false);
                Animals.Add("hare", false);
                Animals.Add("hawk", false);
                Animals.Add("hedgehog", false);
                Animals.Add("heron", false);
                Animals.Add("herring", false);
                Animals.Add("hippopotamus", false);
                Animals.Add("hornet", false);
                Animals.Add("horse", false);
                Animals.Add("human", false);
                Animals.Add("humming bird", false);
                Animals.Add("hyena", false);
                Animals.Add("jackal", false);
                Animals.Add("jaguar", false);
                Animals.Add("jay", false);
                Animals.Add("jellyfish", false);
                Animals.Add("kangaroo", false);
                Animals.Add("koala", false);
                Animals.Add("komodo dragon", false);
                Animals.Add("kouprey", false);
                Animals.Add("kudu", false);
                Animals.Add("lizard", false);
                Animals.Add("lark", false);
                Animals.Add("lemur", false);
                Animals.Add("leopard", false);
                Animals.Add("lion", false);
                Animals.Add("llama", false);
                Animals.Add("lobster", false);
                Animals.Add("locust", false);
                Animals.Add("loris", false);
                Animals.Add("louse", false);
                Animals.Add("lyrebird", false);
                Animals.Add("magpie", false);
                Animals.Add("mallard", false);
                Animals.Add("manatee", false);
                Animals.Add("marten", false);
                Animals.Add("meerkat", false);
                Animals.Add("mink", false);
                Animals.Add("mole", false);
                Animals.Add("monkey", false);
                Animals.Add("moose", false);
                Animals.Add("mosquito", false);
                Animals.Add("mouse", false);
                Animals.Add("mule", false);
                Animals.Add("narwhal", false);
                Animals.Add("newt", false);
                Animals.Add("nightingale", false);
                Animals.Add("octopus", false);
                Animals.Add("okapi", false);
                Animals.Add("opossum", false);
                Animals.Add("oryx", false);
                Animals.Add("ostrich", false);
                Animals.Add("otter", false);
                Animals.Add("owl", false);
                Animals.Add("ox", false);
                Animals.Add("oyster", false);
                Animals.Add("panther", false);
                Animals.Add("parrot", false);
                Animals.Add("partridge", false);
                Animals.Add("peafowl", false);
                Animals.Add("pelican", false);
                Animals.Add("penguin", false);
                Animals.Add("pheasant", false);
                Animals.Add("pig", false);
                Animals.Add("pigeon", false);
                Animals.Add("pony", false);
                Animals.Add("porcupine", false);
                Animals.Add("porpoise", false);
                Animals.Add("prairie dog", false);
                Animals.Add("quail", false);
                Animals.Add("quelea", false);
                Animals.Add("rabbit", false);
                Animals.Add("raccoon", false);
                Animals.Add("rail", false);
                Animals.Add("ram", false);
                Animals.Add("rat", false);
                Animals.Add("raven", false);
                Animals.Add("red deer", false);
                Animals.Add("red panda", false);
                Animals.Add("reindeer", false);
                Animals.Add("rhinoceros", false);
                Animals.Add("rook", false);
                Animals.Add("ruff", false);
                Animals.Add("salamander", false);
                Animals.Add("salmon", false);
                Animals.Add("sand dollar", false);
                Animals.Add("sandpiper", false);
                Animals.Add("sardine", false);
                Animals.Add("scorpion", false);
                Animals.Add("sea lion", false);
                Animals.Add("sea urchin", false);
                Animals.Add("seahorse", false);
                Animals.Add("seal", false);
                Animals.Add("shark", false);
                Animals.Add("sheep", false);
                Animals.Add("shrew", false);
                Animals.Add("shrimp", false);
                Animals.Add("skunk", false);
                Animals.Add("snail", false);
                Animals.Add("snake", false);
                Animals.Add("spider", false);
                Animals.Add("squid", false);
                Animals.Add("squirrel", false);
                Animals.Add("starling", false);
                Animals.Add("stingray", false);
                Animals.Add("stink bug", false);
                Animals.Add("stork", false);
                Animals.Add("swallow", false);
                Animals.Add("swan", false);
                Animals.Add("tapir", false);
                Animals.Add("tarsier", false);
                Animals.Add("termite", false);
                Animals.Add("tiger", false);
                Animals.Add("toad", false);
                Animals.Add("trout", false);
                Animals.Add("turkey", false);
                Animals.Add("turtle", false);
                Animals.Add("vicuña", false);
                Animals.Add("viper", false);
                Animals.Add("vulture", false);
                Animals.Add("wallaby", false);
                Animals.Add("walrus", false);
                Animals.Add("wasp", false);
                Animals.Add("water buffalo", false);
                Animals.Add("weasel", false);
                Animals.Add("whale", false);
                Animals.Add("wolf", false);
                Animals.Add("wolverine", false);
                Animals.Add("wombat", false);
                Animals.Add("woodcock", false);
                Animals.Add("woodpecker", false);
                Animals.Add("worm", false);
                Animals.Add("wren", false);
                Animals.Add("yak", false);
                Animals.Add("zebra", false);
                Animals.Add("bird", false);

                LoadGuesses("Animals");
            }

            #endregion

            public static string Category = null;

            public static void LoadGuesses(string dictionaryToLoad)
            {
                if (!Directory.Exists(Paths.KnowledgeInput))
                {
                    Directory.CreateDirectory(Paths.KnowledgeInput);
                }
                switch (dictionaryToLoad)
                {
                    case "Animals":
                        if (!File.Exists(Paths.KnowledgeInput + "/animals.json"))
                        {
                            string json = JsonConvert.SerializeObject(Animals);
                            File.WriteAllText(Paths.KnowledgeInput + "/animals.json", json);
                        }
                        else
                        {
                            string json = File.ReadAllText(Paths.KnowledgeInput + "/animals.json");
                            Animals = JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
                        }
                        break;
                }
            }

            public static string Guess(string guess)
            {
                switch (Category)
                {
                    case "Animals":
                        try
                        {
                            if (Animals[guess.ToLower()] == true)
                            {
                                return "already_guessed";
                            }
                            else
                            {
                                Animals[guess.ToLower()] = true;
                                return "success";
                            }
                        }
                        catch
                        {
                            API.LogException("User didn't guess a valid knowledge input guess.", false);
                            return "not_valid";
                        }
                    default:
                        return "not_valid";
                }
            }
            public static void SaveGuesses()
            {
                string json = JsonConvert.SerializeObject(Animals);
                File.WriteAllText(Paths.KnowledgeInput + "/animals.json", json);
            }

            public static int GetRightGuesses()
            {
                int guesses = 0;
                switch (Category)
                {
                    case "Animals":
                        foreach (KeyValuePair<string, bool> kv in Animals)
                        {
                            if (Animals[kv.Key] == true)
                            {
                                guesses += 1;
                            }
                        }
                        break;
                }


                return guesses;
            }

            public static int GetLengthOfPossible()
            {
                int len = 0;
                switch (Category)
                {
                    case "Animals":
                        len = Animals.Count;
                        break;
                    default:
                        len = 0;
                        break;
                }


                return len;
            }
        }


        /// <summary>
        /// Opens a program. Used by the Terminal, and Lua.
        /// </summary>
        /// <param name="cmd">Program to open.</param>
        /// <returns>Whether the program could be opened.</returns>
        public static bool OpenProgram(string cmd)
        {
            bool succeeded = true;
            switch (cmd)
            {

                case "settings":
                    API.CreateForm(new GameSettings(), "Settings", API.GetIcon("Settings"));
                    break;
                case "credits":
                    var c = new CreditScroller();
                    c.FormBorderStyle = FormBorderStyle.None;
                    c.Show();
                    c.WindowState = FormWindowState.Maximized;
                    c.TopMost = true;
                    break;
                case "netbrowse":
                    if(Upgrades["networkbrowser"])
                    {
                        CreateForm(new NetworkBrowser(), "Network Browser", GetIcon("NetworkBrowser"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "quests":
                    if(LimitedMode)
                    {
                        CreateForm(new FinalMission.QuestViewer(), "Quest Viewer", GetIcon("QuestViewer"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "iconmanager":
                    if (!LimitedMode)
                    {
                        if (API.Upgrades["iconmanager"])
                        {
                            CreateForm(new IconManager(), "Icon Manager", GetIcon("IconManager"));
                            
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "knowledge_input":
                case "ki":
                    if (!LimitedMode)
                    {
                        API.CreateForm(new KnowledgeInput(), API.LoadedNames.KnowledgeInputName, GetIcon("KI"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "holochat":
                    if(API.Upgrades["holochat"] == true)
                    {
                        API.CreateForm(new HoloChat(), "HoloChat", GetIcon("HoloChat"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "namechanger":
                case "name_changer":
                    if (!LimitedMode)
                    {
                        if (API.Upgrades["namechanger"] == true)
                        {
                            CreateForm(new NameChanger(), LoadedNames.NameChangerName, GetIcon("NameChanger"));
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "artpad":
                    if (!LimitedMode)
                    {
                        if (API.Upgrades["artpad"] == true)
                        {
                            CreateForm(new Artpad(), LoadedNames.ArtpadName, GetIcon("Artpad"));
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "textpad":
                    if(Upgrades["textpad"] == true)
                    {
                        CreateForm(new TextPad(), "TextPad", GetIcon("TextPad"));
                    } else
                    {
                        succeeded = false;
                    }
                    break;
                case "skinloader":
                case "skin_loader":
                    if (!LimitedMode)
                    {
                        if (Upgrades["skinning"] == true)
                        {
                            CreateForm(new SkinLoader(), "Skin Loader", GetIcon("SkinLoader"));
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "shifter":
                    if (!LimitedMode)
                    {
                        if (Upgrades["shifter"] == true)
                        {
                            CreateForm(new Shifter(), "Shifter", GetIcon("Shifter"));
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "pong":
                    if (!LimitedMode)
                    {
                        if (Upgrades["pong"] == true)
                        {
                            CreateForm(new Pong(), "Pong", GetIcon("Pong"));
                        }
                        else
                        {
                            succeeded = false;
                        }
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "file_skimmer":
                    if (Upgrades["fileskimmer"] == true)
                    {
                        CreateForm(new File_Skimmer(), CurrentSave.FileSkimmerName, GetIcon("FileSkimmer"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                case "shiftorium":
                    if (!LimitedMode)
                    {
                        CreateForm(new Shiftorium.Frontend(), LoadedNames.ShiftoriumName, GetIcon("Shiftorium"));
                    }
                    else
                    {
                        succeeded = false;
                    }
                    break;
                default:
                    succeeded = false;
                    break;

            }
            return succeeded;

        }

        /// <summary>
        /// Creates a new color picker session.
        /// </summary>
        /// <param name="colorToChange">The name displayed on the top.</param>
        /// <param name="oldColor">The old color displayed on the Cancel button.</param>
        public static void CreateColorPickerSession(string colorToChange, Color oldColor)
        {
            Color_Picker cp = new Color_Picker(colorToChange, oldColor);
            CreateForm(cp, CurrentSave.ColorPickerName, Properties.Resources.iconColourPicker_fw);
            ColorPickerSession = cp;
        }

        /// <summary>
        /// Gets the color picked by the user. Call this during the close event of a Color Picker.
        /// </summary>
        /// <returns>The user's choice.</returns>
        public static Color GetLastColorFromSession()
        {
            Color lastcol = Color.Black;
            if (ColorPickerSession != null)
            {
                switch (ColorPickerSession.Result)
                {
                    case "OK":
                        lastcol = ColorPickerSession.NewColor;
                        break;
                    default:
                        lastcol = ColorPickerSession.oldcolour;
                        break;
                }
            }
            else
            {
                throw new InvalidSessionException("A valid Color Picker session wasn't found.");
            }
            return lastcol;
        }

        public static Color_Picker ColorPickerSession = null;

        #region "I don't want to be seen."
        public static Color lastcolourpick = Color.White;

        public static Color[] anymemory = new Color[16];
        public static Color[] redmemory = new Color[16];
        public static Color[] greenmemory = new Color[16];
        public static Color[] bluememory = new Color[16];
        public static Color[] orangememory = new Color[16];
        public static Color[] brownmemory = new Color[16];
        public static Color[] purplememory = new Color[16];
        public static Color[] graymemory = new Color[16];
        public static Color[] yellowmemory = new Color[16];
        public static Color[] pinkmemory = new Color[16];
        internal static Dictionary<string, Dictionary<string, object>> LuaShifterRegistry = null;

        #endregion
    }

    public class InvalidSessionException : Exception
    {
        public InvalidSessionException() : base("ShiftOS could not perform actions on an application session, because the session is invalid. Try checking if the session is not 'null' before performing actions on it through the API.")
        {

        }

        public InvalidSessionException(string inner) : base("ShiftOS could not perform actions on an application session, because the session is invalid. Try checking if the session is not 'null' before performing actions on it through the API.", new Exception(inner))
        {

        }
    }

    public class ModNotFoundException : Exception
    {
        public ModNotFoundException() : base("Could not find the mod file specified.")
        {

        }
    }
}
