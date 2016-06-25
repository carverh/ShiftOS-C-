using System;
using System.IO;
using System.Windows.Forms;

namespace ShiftOS
{
    /// <summary>
    /// ShiftOS Path Variables.
    /// 
    /// This class is cross-platform enabled, and will adapt to the currently running OS.
    /// </summary>
	public class Paths
	{
		public OSInfo oi = new OSInfo();

		public static string SaveRoot;
			public static string Home;
				public static string Desktop;
				public static string Documents;
				public static string Music;
				public static string Pictures;
				public static string Skins;
				public static string Videos;
			public static string SystemDir;
                public static string AutoStart;
                public static string APIs;
				public static string SkinDir;
					public static string LoadedSkin;
                        public static string Icons;
					public static string ToBeLoaded;
				public static string Drivers;
					public static string SaveFile;
                    public static string Bitnote;
                public static string Applications;
                    public static string PackageManager;
                    public static string Shiftnet;
            public static string SoftwareData;
                public static string KnowledgeInput;
	
        //Mod Directories
        public static string Mod_Temp;
        public static string Mod_AppLauncherEntries;
        public static string Desktop_Icons;
        public static string WidgetFiles;

        /// <summary>
        /// Registers path variables.
        /// </summary>
		public static void RegisterPaths()
		{
			switch (OSInfo.GetPlatformID()) {
			case "microsoft":
                    var windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                    var splitter = windir.Split('\\');
                    var driveletter = splitter[0];
                    SaveRoot = $"{driveletter}\\ShiftOS";
				Home = SaveRoot + "\\Home\\";
				Desktop = Home + "Desktop\\";
				Documents = Home + "Documents\\";
				Music = Home + "Music\\";
				Pictures = Home + "Pictures\\";
				Skins = Home + "Skins\\";
				Videos = Home + "Videos\\";
				SystemDir = SaveRoot + "\\Shiftum42\\";
				SkinDir = SystemDir + "SkinData\\";
				LoadedSkin = SkinDir + "Loaded\\";
				ToBeLoaded = SkinDir + "Preview\\";
				Drivers = SystemDir + "Drivers\\";
				SaveFile = Drivers + "HDD.dri";
                    SoftwareData = SaveRoot + "\\SoftwareData";
                    KnowledgeInput = SoftwareData + "\\_knowledgeinput\\";
                    Applications = SystemDir + "Apps\\";
                    PackageManager = Applications + "Package Manager\\";
                    Shiftnet = Applications + "Shiftnet\\";
                    Mod_AppLauncherEntries = SystemDir + "_applauncher\\";
                    Mod_Temp = SystemDir + "_temp\\";
                    AutoStart = SystemDir + "AutoStart\\";
                    Bitnote = Drivers + "BNWallet.dri";
                    Icons = LoadedSkin + "Icons\\";
                    WidgetFiles = SystemDir + "Widgets\\";
                    APIs = SystemDir + "APIs\\";
				break;
			default:
				SaveRoot = OSInfo.homePath () + "/.local/lib/.shiftos";
				Home = SaveRoot + "/Home/";
				Desktop = Home + "Desktop/";
				Documents = Home + "Documents/";
				Music = Home + "Music/";
				Pictures = Home + "Pictures/";
				Skins = Home + "Skins/";
				Videos = Home + "Videos/";
				SystemDir = SaveRoot + "/Shiftum42/";
				SkinDir = SystemDir + "SkinData/";
				LoadedSkin = SkinDir + "Loaded/";
				ToBeLoaded = SkinDir + "Preview/";
				Drivers = SystemDir + "Drivers/";
				SaveFile = Drivers + "HDD.dri";
                    SoftwareData = SaveRoot + "/SoftwareData";
                    KnowledgeInput = SoftwareData + "/_knowledgeinput/";
                    Applications = SystemDir + "/Apps/";
                    PackageManager = Applications + "Package Manager/";
                    Shiftnet = Applications + "Shiftnet/";
                    Mod_AppLauncherEntries = SystemDir + "_applauncher/";
                    Mod_Temp = SystemDir + "_temp/";
                    AutoStart = SystemDir + "AutoStart/";
                    Bitnote = Drivers + "BNWallet.dri";
                    Icons = LoadedSkin + "Icons/";
                    WidgetFiles = SystemDir + "Widgets/";
                    APIs = SystemDir + "APIs/";
                    break;
			}

		}

		/// <summary>
		/// Writes the barebones ShiftOS file system; skipping folders like the Desktop, which will appear as the user upgrades the OS.
		/// </summary>
		public static void WriteFileSystem() {
			WriteDirectory (SaveRoot);
			WriteDirectory (Home);
			WriteDirectory (Documents);
			WriteDirectory (SystemDir);
			WriteDirectory (SkinDir);
			WriteDirectory (LoadedSkin);
			WriteDirectory (ToBeLoaded);
            WriteDirectory(Drivers);
		}

        /// <summary>
        /// Create a directory
        /// </summary>
        /// <param name="dir">New DIR.</param>
		public static void WriteDirectory(string dir) {
			if(!Directory.Exists(dir)) {
				Console.WriteLine ("[FS] Creating directory '{0}'", dir);
				Directory.CreateDirectory (dir);
			} else {
				Console.WriteLine ("[FS] That directory at {0} exists.", dir);
			}
		}

	}
}

