using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    class Viruses
    {
        public static Dictionary<string, string> Infections = new Dictionary<string, string>();

        public static void CheckForInfected()
        {
            VirusTimer.Interval = 1000;
            Infections.Clear();
            Scan(Paths.SaveRoot);
            VirusTimer.Tick += new EventHandler(VirusTimer_Tick);
            VirusTimer.Start();
        }
        
        public static void VirusTimer_Tick(object sender, EventArgs e)
        {
            ShiftoriumKiller.KillRandomUpgrade();
            if(InfectedWith("beepseverysecond"))
            {
                API.PlaySound(Properties.Resources._3beepvirus);
            }
            if(InfectedWith("imtheshifternow"))
            {
                Skinning.Utilities.Randomize();
            }
        }
        
        public static void Scan(string directory)
        {
            foreach(string file in Directory.GetFiles(directory))
            {
                CheckInfected(file);
            }
            foreach(string dir in Directory.GetDirectories(directory))
            {
                if(dir != Paths.Mod_Temp) {
                    Scan(dir);
                }
            }
        }

        public static void ScanForInfectable(string directory, ref List<string> file_list)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                var finf = new FileInfo(file);
                switch (finf.Extension) {
                    case ".skn":
                    case ".spk":
                    case ".dri":
                    case ".stp":
                    case ".pkg":
                        if (finf.Name != "HDD.dri")
                        {
                            file_list.Add(file);
                        }
                        break;
            }
            }
            foreach (string dir in Directory.GetDirectories(directory))
            {
                if (dir != Paths.Mod_Temp)
                {
                    ScanForInfectable(dir, ref file_list);
                }
            }
        }
        const string virusfilename = "00110";


        public static void CheckInfected(string filepath) {
            var finf = new FileInfo(filepath);
            switch(finf.Extension)
            {
                case ".stp":
                case ".spk":
                case ".pkg":
                case ".skn":
                    if (File.Exists(finf.FullName))
                    {
                        try {
                            string pth = Paths.SystemDir + "_virusregister";
                            API.ExtractFile(finf.FullName, pth, false);
                            string dirsep = "\\";
                            switch (OSInfo.GetPlatformID())
                            {
                                case "microsoft":
                                    dirsep = "\\";
                                    break;
                                default:
                                    dirsep = "/";
                                    break;
                            }
                            if (File.Exists(pth + dirsep + virusfilename))
                            {
                                string encrypted = File.ReadAllText(pth + dirsep + virusfilename);
                                if (encrypted != "" && encrypted != null)
                                {
                                    foreach (string line in API.Encryption.Decrypt(encrypted).Split(';'))
                                    {
                                        if (Infections.ContainsKey(line))
                                        {
                                            Infections[line] += ";" + finf.FullName;
                                        }
                                        else {
                                            Infections.Add(line, finf.FullName);
                                        }
                                    }
                                }
                            }
                            Directory.Delete(pth, true);
                        }
                        catch
                        {
                            API.LogException("Corrupted package file detected while checking for infections... skipping.", false);
                        }
                    }
                    break;
                case ".dri":
                    if (finf.Name != "HDD.dri" && !finf.Name.Contains("BN") && finf.Name != "Network.dri")
                    {
                        if (File.ReadAllText(finf.FullName) != "")
                        {
                            string encrypted = File.ReadAllText(finf.FullName);
                            try
                            {
                                foreach (string line in API.Encryption.Decrypt(encrypted).Split(';'))
                                {
                                    if (Infections.ContainsKey(line))
                                    {
                                        Infections[line] += ";" + finf.FullName;
                                    }
                                    else {
                                        Infections.Add(line, finf.FullName);
                                    }
                                }
                            }
                            catch
                            {
                                if (encrypted != "")
                                {
                                    string decrypted = API.Encryption.Decrypt(encrypted);
                                    if (Infections.ContainsKey(decrypted))
                                    {
                                        Infections[decrypted] += ";" + finf.FullName;
                                    }
                                    else {
                                        Infections.Add(decrypted, finf.FullName);
                                    }
                                }
                            }
                        }
                    }
                    break;
                
            }
        }

        public enum VirusID
        {
            ShiftoriumKiller,
            WindowsEverywhere,
            WindowMicrofier,
            Bye,
            WindowSpazzer,
            KeyboardFucker,
            ImTheShifterNow,
            ThanksfortheInfo,
            SkinInterceptor,
            HolyFuckMyEars,
            BeepsEverySecond,
            MouseTrap,
            Seized,
            FileFucker,
        }

        public class FileFucker
        {
            public static void GetSomeFiles(string directory, ref List<string> file_list)
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    var finf = new FileInfo(file);
                    switch (finf.Extension)
                    {
                        case ".npk":
                        case ".docx":
                        case ".doc":
                        case ".owd":
                        case ".txt":
                            if (finf.Name != "names.npk" && finf.Name != "_Log.txt")
                            {
                                file_list.Add(file);
                            }
                            break;
                    }
                }
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    if (dir != Paths.Mod_Temp)
                    {
                        GetSomeFiles(dir, ref file_list);
                    }
                }
            }

            public static void Infect()
            {
                List<string> files = new List<string>();
                GetSomeFiles(Paths.SaveRoot, ref files);
                var rnd = new Random();
                string fname = files[rnd.Next(0, files.Count - 1)];
                string fcontents = File.ReadAllText(fname);
                string encrypted = API.Encryption.Encrypt(fcontents);
                File.WriteAllText(fname, encrypted);
            }
        }

        public static bool InfectedWith(string id)
        {
            if(Infections.ContainsKey("virus:" + id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void InfectFile(string FileName, VirusID id)
        {
            bool cont = false;
            string infectionString = "virus:";
            switch (id)
            {
                case VirusID.WindowSpazzer:
                    infectionString = "virus:windowspazzer";
                    break;
                case VirusID.WindowMicrofier:
                    infectionString = "virus:windowmicrofier";
                    break;
                case VirusID.Bye:
                    infectionString = "virus:bye";
                    break;
                case VirusID.ShiftoriumKiller:
                    infectionString = "virus:shiftoriumkiller";
                    break;
                case VirusID.WindowsEverywhere:
                    infectionString = "virus:windowseverywhere";
                    break;
                case VirusID.KeyboardFucker:
                    infectionString = "virus:keyboardfucker";
                    break;
                case VirusID.ImTheShifterNow:
                    infectionString = "virus:imtheshifternow";
                    break;
                case VirusID.ThanksfortheInfo:
                    infectionString = "virus:thanksfortheinfo";
                    break;
                case VirusID.SkinInterceptor:
                    infectionString = "virus:skininterceptor";
                    break;
                case VirusID.HolyFuckMyEars:
                    infectionString = "virus:holyfuckmyears";
                    break;
                case VirusID.BeepsEverySecond:
                    infectionString = "virus:beepseverysecond";
                    break;
                case VirusID.Seized:
                    infectionString = "virus:seized";
                    break;
                case VirusID.FileFucker:
                    infectionString = "virus:filefucker";
                    break;
            }
            FileInfo finf = new FileInfo(FileName);
            switch(finf.Extension)
            {
                case ".skn":
                case ".spk":
                case ".stp":
                case ".pkg":
                    if(!Directory.Exists(Paths.Mod_Temp))
                    {
                        Directory.CreateDirectory(Paths.Mod_Temp);
                    }
                    string pth = Paths.SystemDir + "_virusinfect1";
                    API.ExtractFile(finf.FullName, pth, false);
                    string dirsep = "\\";
                    switch (OSInfo.GetPlatformID())
                    {
                        case "microsoft":
                            dirsep = "\\";
                            break;
                        default:
                            dirsep = "/";
                            break;
                    }
                    InfectFile(pth + dirsep + virusfilename, id);
                    File.Delete(finf.FullName);
                    ZipFile.CreateFromDirectory(pth, FileName);
                    Directory.Delete(pth, true);
                    break;
                case ".dri":
                    if(finf.Name == "HDD.dri" || finf.Name.Contains("BN") || finf.Name == "Network.dri")
                    {
                        throw new NotHappeningException("You're not going to attempt to infect that file, are you?");
                    }
                    else
                    {
                        try {
                            string encryptedfile = File.ReadAllText(finf.FullName);
                            string unencryptedfile = API.Encryption.Decrypt(encryptedfile);
                            unencryptedfile += ";" + infectionString;
                            File.WriteAllText(finf.FullName, API.Encryption.Encrypt(unencryptedfile));
                        }
                        catch
                        {
                            File.WriteAllText(finf.FullName, API.Encryption.Encrypt(infectionString));
                        }
                    }
                    break;
                default:
                    cont = true;
                    break;
                    
            }
            if (cont == true)
            {
                if (finf.Name == virusfilename)
                {
                    try
                    {
                        string encryptedfile = File.ReadAllText(finf.FullName);
                        string unencryptedfile = API.Encryption.Decrypt(encryptedfile);
                        unencryptedfile += ";" + infectionString;
                        File.WriteAllText(finf.FullName, API.Encryption.Encrypt(unencryptedfile));
                    }
                    catch
                    {
                        File.WriteAllText(finf.FullName, API.Encryption.Encrypt(infectionString));
                    }
                }
            }
            CheckForInfected();
        }

        public static void DisInfect(string FileName)
        {
            FileInfo finf = new FileInfo(FileName);
            switch (finf.Extension)
            {
                case ".skn":
                case ".spk":
                case ".stp":
                case ".pkg":
                    string pth = Paths.SystemDir + "_viruscheck";
                    API.ExtractFile(finf.FullName, pth, false);
                    string dirsep = "\\";
                    switch (OSInfo.GetPlatformID())
                    {
                        case "microsoft":
                            dirsep = "\\";
                            break;
                        default:
                            dirsep = "/";
                            break;
                    }
                    if (File.Exists(pth + dirsep + virusfilename))
                    {
                        File.Delete(pth + dirsep + virusfilename);
                    }
                    File.Delete(finf.FullName);
                    ZipFile.CreateFromDirectory(pth, finf.FullName);
                    Directory.Delete(pth, true);
                    break;
                case ".dri":
                    if (finf.Name == "HDD.dri" || finf.Name.Contains("BN") || finf.Name == "Network.dri")
                    {
                        throw new NotHappeningException("You're not going to attempt to infect that file, are you?");
                    }
                    else
                    {
                        try
                        {
                            string encryptedfile = File.ReadAllText(finf.FullName);
                            string unencryptedfile = API.Encryption.Decrypt(encryptedfile);
                            unencryptedfile = "";
                            File.WriteAllText(finf.FullName, API.Encryption.Encrypt(unencryptedfile));
                        }
                        catch 
                        {
                            File.WriteAllText(finf.FullName, "");
                        }
                    }
                    break;


            }
            CheckForInfected();
        }

        public static void InfectFile(string FileName, string id)
        {
            bool cont = false;
            string infectionString = "virus:" + id;
            FileInfo finf = new FileInfo(FileName);
            switch (finf.Extension)
            {
                case ".skn":
                case ".spk":
                case ".stp":
                case ".pkg":
                    string pth = Paths.SystemDir + "_virusinfect2";
                    API.ExtractFile(finf.FullName, pth, false);
                    string dirsep = "\\";
                    switch (OSInfo.GetPlatformID())
                    {
                        case "microsoft":
                            dirsep = "\\";
                            break;
                        default:
                            dirsep = "/";
                            break;
                    }
                    InfectFile(pth + dirsep + virusfilename, id);
                    File.Delete(finf.FullName);
                    ZipFile.CreateFromDirectory(pth, finf.FullName);
                    Directory.Delete(pth, true);
                    break;
                case ".dri":
                    if (finf.Name == "HDD.dri" || finf.Name.Contains("BN") || finf.Name == "Network.dri")
                    {
                        throw new NotHappeningException("You're not going to attempt to infect that file, are you?");
                    }
                    else
                    {
                        try
                        {
                            string encryptedfile = File.ReadAllText(finf.FullName);
                            string unencryptedfile = API.Encryption.Decrypt(encryptedfile);
                            unencryptedfile += ";" + infectionString;
                            File.WriteAllText(finf.FullName, API.Encryption.Encrypt(unencryptedfile));
                        }
                        catch 
                        {
                            File.WriteAllText(finf.FullName, API.Encryption.Encrypt(infectionString));
                        }
                    }
                    break;
                default:
                    cont = true;
                    break;

            }
            if (cont == true)
            {
                if (finf.Name == virusfilename)
                {
                    try
                    {
                        string encryptedfile = File.ReadAllText(finf.FullName);
                        string unencryptedfile = API.Encryption.Decrypt(encryptedfile);
                        unencryptedfile += ";" + infectionString;
                        File.WriteAllText(finf.FullName, API.Encryption.Encrypt(unencryptedfile));
                    }
                    catch 
                    {
                        File.WriteAllText(finf.FullName, API.Encryption.Encrypt(infectionString));
                    }
                }
            }
            CheckForInfected();
        }


        public static void InfectRandom()
        {
            var rnd = new Random();
            var files = new List<string>();
            ScanForInfectable(Paths.SaveRoot, ref files);
            string filetoinfect = files[rnd.Next(0, files.Count - 1)];
            VirusID v = VirusID.ShiftoriumKiller;
            int vid = rnd.Next(0, 11);
            switch(vid)
            {
                case 0:
                    v = VirusID.ShiftoriumKiller;
                    break;
                case 1:
                    v = VirusID.WindowsEverywhere;
                    break;
                case 2:
                    v = VirusID.ImTheShifterNow;
                    break;
                case 3:
                    v = VirusID.BeepsEverySecond;
                    break;
                case 4:
                    v = VirusID.FileFucker;
                    break;
                case 5:
                    v = VirusID.MouseTrap;
                    break;
                case 6:
                    v = VirusID.Seized;
                    break;
                case 7:
                    v = VirusID.SkinInterceptor;
                    break;
                case 8:
                    v = VirusID.ThanksfortheInfo;
                    break;
                case 9:
                    v = VirusID.KeyboardFucker;
                    break;
                case 10:
                    v = VirusID.WindowMicrofier;
                    break;
                case 11:
                    v = VirusID.Bye;
                    break;
                case 12:
                    v = VirusID.WindowSpazzer;
                    break;
            }
            InfectFile(filetoinfect, v);
        }

        public static void DropDevXPayload()
        {
            //Viruses...
            var files = new List<string>();
            ScanForInfectable(Paths.SaveRoot, ref files);
            try {
                var rnd = new Random();
                string file = files[rnd.Next(0, files.Count - 1)];
                InfectFile(file, VirusID.ImTheShifterNow);
                InfectFile(file, VirusID.MouseTrap);
            }
            catch
            {
                DropDevXPayload();
            }
            
        }

        private static Timer VirusTimer = new Timer();

        public class ShiftoriumKiller
        { 
            public static void KillRandomUpgrade()
            {
                if(Viruses.InfectedWith("shiftoriumkiller"))
                {
                    int id = new Random().Next(0, SaveSystem.ShiftoriumRegistry.DefaultUpgrades.Count - 1);
                    Shiftorium.Upgrade upg = SaveSystem.ShiftoriumRegistry.DefaultUpgrades[id];
                    int chance = new Random().Next(0, 100);
                    if(chance == 50)
                    {
                        Shiftorium.Utilities.Unbuy(upg.id);
                    }
                }
            }
        }

        public class KeyboardInceptor
        {
            public static string[] Chars =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "~", "!", "@", "#", "$", "%", "^", "&", "(", ")", "-", "_", "=", "+",
                "/", "?", "\\", "|", "[", "]", "{", "}", "'", "\"", ";", ":", ".", ">", ",", "<",
            };

            public static string Intercept()
            {
                Random rnd = new Random();
                int shouldbeupper = rnd.Next(0, 10);
                switch(shouldbeupper)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                        return Chars[rnd.Next(0, Chars.Length - 1)].ToUpper();
                    default:
                        return Chars[rnd.Next(0, Chars.Length - 1)].ToLower();
                }
            }
        }
    }

    public class NotHappeningException : Exception
    {
        public NotHappeningException() : base("You tried to do something that ain't gonna happen.")
        {

        }

        public NotHappeningException(string message) : base(message)
        {

        }
    }

}
