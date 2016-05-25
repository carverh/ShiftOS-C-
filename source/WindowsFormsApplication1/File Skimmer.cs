using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class File_Skimmer : Form
    {
        /// <summary>
        /// Opens a file in the proper program.
        /// </summary>
        /// <param name="filepath">Path to the file.</param>
        public void OpenFile(string filepath)
        {
            bool success = true;
            FileInfo finf = new FileInfo(filepath);
            switch(finf.Extension)
            {
                case ".saa":
                    if(API.Upgrades["shiftnet"] == true)
                    {
                        API.LaunchMod(finf.FullName);
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case ".txt":
                    if (API.Upgrades["textpadopen"] == true)
                    {
                        var pad = new TextPad();
                        pad.txtuserinput.Text = File.ReadAllText(finf.FullName);
                        API.CreateForm(pad, "TextPad", Properties.Resources.iconTextPad);
                    } else
                    {
                        success = false;
                    }
                    break;
                case ".pkg":
                case ".stp":
                    if (API.Upgrades["shiftnet"] == true)
                    {
                        API.CreateInfoboxSession("Package Installation", "Would you like to install the package?", infobox.InfoboxMode.YesNo);
                        API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                        {
                            var result = API.GetInfoboxResult();
                            if (result == "Yes")
                            {
                                try
                                {
                                    var res = Package_Grabber.ExtractPackage(finf.FullName);
                                    if (res == "fail")
                                    {
                                        throw new Exception("Michael was dumb and messed something up.");
                                    }
                                    else
                                    {
                                        Package_Grabber.InstallPackage(res + "\\");
                                        API.CreateInfoboxSession("Package Installer - Success", "The package has been installed successfully!", infobox.InfoboxMode.Info);
                                        API.UpdateWindows();
                                        API.CurrentSession.SetupDesktop();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (API.DeveloperMode == true)
                                    {
                                        API.CreateInfoboxSession("Package Installer - Error", ex.Message, infobox.InfoboxMode.Info);
                                    }
                                    else
                                    {
                                        API.CreateInfoboxSession("Package Installer - Error", "An error has occurred while installing the package.", infobox.InfoboxMode.Info);
                                    }
                                }
                            }
                        };
                    }
                    else {
                        success = false;
                    }
                    break;
                case ".skn":
                    if(API.Upgrades["skinning"] == true)
                    {
                        var loader = new SkinLoader();
                        API.CreateForm(loader, API.LoadedNames.SkinLoaderName, Properties.Resources.iconSkinLoader);
                        loader.LoadSkin(finf.FullName);
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case ".spk":
                    if (API.Upgrades["skinning"] == true)
                    {
                        var loader = new SkinLoader();
                        loader.LoadedPack = finf.FullName;
                        API.CreateForm(loader, API.LoadedNames.SkinLoaderName, Properties.Resources.iconSkinLoader);
                        loader.SetupPackUI();
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                default:
                    success = false;
                    break;
            }
            //If we made it this far and nothing happened, tell the user.
            if(success == false)
            {
                API.CreateInfoboxSession("File Skimmer", "File Skimmer cannot find a program to open this file.", infobox.InfoboxMode.Info);
            }
        }

        /// <summary>
        /// The File Skimmer.
        /// </summary>
        public File_Skimmer()
        {
            MountMgr.Init();
            InitializeComponent();
        }

        public File_Skimmer(FileSkimmerMode mode, string filters)
        {
            InitializeComponent();
            Mode = mode;
            Filters = filters.Split(';');
        }

        public string CurrentFolder = Paths.SaveRoot;

        private void File_Skimmer_Load(object sender, EventArgs e)
        {
            SetupUI();
            ListFiles();
            lvfiles.DoubleClick += (object s, EventArgs a) =>
            {
                if(lvfiles.SelectedItems.Count > 0)
                {
                    var item = lvfiles.SelectedItems[0];
                    string tag = (string)item.Tag;
                    if(Directory.Exists(tag))
                    {
                        txtfilename.Text = new DirectoryInfo(tag).Name;
                        CurrentFolder = tag;
                        ListFiles();
                        
                    } else
                    {
                        if(File.Exists(tag))
                        {
                            if(Mode == FileSkimmerMode.Open)
                            {
                                FileInfo finf = new FileInfo(tag);
                                txtfilename.Text = finf.Name.Replace(finf.Extension, "");
                                btnperformaction_Click(s, a);
                            }
                            else if(Mode == FileSkimmerMode.Default)
                            {
                                OpenFile(tag);
                            }
                        } else
                        {
                            if(tag == "_uponedir")
                            {
                                if (lbcurrentfolder.Text != "/")
                                {
                                    if (lbcurrentfolder.Text == MountPoint.Replace("\\", "/"))
                                    {
                                        CurrentFolder = Paths.SaveRoot;
                                        ListFiles();
                                    }
                                    else
                                    {
                                        CurrentFolder = Directory.GetParent(CurrentFolder).FullName;
                                        ListFiles();
                                    }
                                } else
                                {
                                    API.CreateInfoboxSession("Can't read directory", "File Skimmer is not able to read the requested directory as it is not formatted with the ShiftFS file system.", infobox.InfoboxMode.Info);
                                }
                            }
                            else if(tag.StartsWith("drv:"))
                            {
                                string drivepath = tag.Remove(0, 4);
                                CurrentFolder = drivepath;
                                MountPoint = drivepath;
                                ListFiles();
                            }
                        }
                    }
                }
            };

            txtfilename.KeyDown += (object s, KeyEventArgs a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    a.SuppressKeyPress = true;
                    btnperformaction_Click(s, (EventArgs)a);
                }
            };
        }

        string MountPoint = null;

        /// <summary>
        /// Lists all the files in the current folder.
        /// </summary>
        public void ListFiles()
        {
            MountMgr.Init();
            SetupImages();
            txtfilename.Text = "";
            //SetupUI();
            newFolderToolStripMenuItem.Visible = API.Upgrades["fsnewfolder"];
            deleteToolStripMenuItem.Visible = API.Upgrades["fsdelete"];
            if(newFolderToolStripMenuItem.Visible == false && deleteToolStripMenuItem.Visible == false)
            {
                menuStrip1.Hide();
            } else
            {
                menuStrip1.Show();
            }
            lbcurrentfolder.Text = CurrentFolder.Replace(Paths.SaveRoot, "/").Replace("\\", "/").Replace("//", "/");
            lvfiles.Items.Clear();
            lvfiles.LargeImageList = imgtypes;
            ListViewItem upone = new ListViewItem();
            upone.Text = "Up One Level";
            upone.Tag = "_uponedir";
            upone.ImageKey = "directory";
            lvfiles.Items.Add(upone);
            if(CurrentFolder == Paths.SaveRoot)
            {
                foreach(var drive in MountMgr.links)
                {
                    var dinf = new DirectoryInfo(drive.Key);
                    var item = new ListViewItem();
                    item.Text = drive.Value;
                    item.Tag = "drv:" + dinf.FullName;
                    lvfiles.Items.Add(item);
                    item.ImageKey = "directory";
                }
            }
            foreach (string dir in Directory.GetDirectories(CurrentFolder))
            {
                var dirinf = new DirectoryInfo(dir);
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = dirinf.Name;
                lvitem.Tag = dirinf.FullName;
                lvitem.ImageKey = "directory";
                if (!dirinf.Name.StartsWith("_"))
                {
                    lvfiles.Items.Add(lvitem);
                }
                else {
                    if (API.DeveloperMode == true)
                    {
                        lvfiles.Items.Add(lvitem);
                    }
                }
            }
            foreach (string file in Directory.GetFiles(CurrentFolder))
            {
                var dirinf = new FileInfo(file);
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = dirinf.Name;
                lvitem.Tag = dirinf.FullName;
                lvitem.ImageKey = GetFileType(dirinf.Extension);
                if (!dirinf.Name.StartsWith("_"))
                {
                    AddItem(lvitem);
                }
                else {
                    if (API.DeveloperMode == true)
                    {
                        AddItem(lvitem);
                    }
                }
            }

        }

        public FileSkimmerMode Mode = FileSkimmerMode.Default;
        public string FileName = "";
        private string[] Filters = null;

        /// <summary>
        /// Sets up the user interface.
        /// </summary>
        private void SetupUI()
        {
            switch(Mode)
            {
                case FileSkimmerMode.Default:
                    Filters = null;
                    this.toolStrip2.Hide();
                    break;
                case FileSkimmerMode.Open:
                    this.toolStrip2.Show();
                    this.btnperformaction.Text = "Open";
                    cbfiletypes.Items.Clear();
                    foreach (string filter in Filters)
                    {
                        cbfiletypes.Items.Add(filter);
                    }
                    selectedFilter = Filters[0];
                    cbfiletypes.Text = Filters[0];
                    break;
                case FileSkimmerMode.Save:
                    this.toolStrip2.Show();
                    this.btnperformaction.Text = "Save";
                    cbfiletypes.Items.Clear();
                    foreach (string filter in Filters)
                    {
                        cbfiletypes.Items.Add(filter);
                    }
                    selectedFilter = Filters[0];
                    cbfiletypes.Text = Filters[0];
                    break;
                case FileSkimmerMode.OpenFolder:
                    this.toolStrip2.Show();
                    this.btnperformaction.Text = "Open";
                    cbfiletypes.Visible = false;
                    selectedFilter = "dir";
                    break;
            }
        }

        /// <summary>
        /// UI mode.
        /// </summary>
        public enum FileSkimmerMode
        {
            Default,
            Open,
            Save,
            OpenFolder
        }

        /// <summary>
        /// Adds an item to the file list.
        /// </summary>
        /// <param name="item">Item to add.</param>
        private void AddItem(ListViewItem item)
        {
            if (Mode == FileSkimmerMode.Default)
            {
                lvfiles.Items.Add(item);
            } else if(Mode == FileSkimmerMode.OpenFolder) {
                if (Directory.Exists(item.Tag.ToString()))
                {
                    lvfiles.Items.Add(item);
                }
            } else
            {
                if (item.Text.ToLower().EndsWith(selectedFilter.ToLower()))
                {
                    lvfiles.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Adds appropriate icons from icon registry to display files.
        /// </summary>
        public void SetupImages()
        {
            imgtypes.Images.Clear();
            imgtypes.Images.Add("application", API.GetIcon("SAAFile"));
            imgtypes.Images.Add("directory", API.GetIcon("Folder"));
            imgtypes.Images.Add("doc", API.GetIcon("TextFile"));
            imgtypes.Images.Add("skin", API.GetIcon("SkinFile"));
            imgtypes.Images.Add("package", API.GetIcon("SetupPackage"));
            imgtypes.Images.Add("none", API.GetIcon("UnrecognizedFile"));
        }

        /// <summary>
        /// Returns proper file ID based on extension
        /// </summary>
        /// <param name="extension">Extension to test.</param>
        /// <returns>The File ID.</returns>
        public string GetFileType(string extension)
        {
            SetupImages();
            switch(extension)
            {
                case ".owd":
                case ".doc":
                case ".docx":
                case ".txt":
                    return "doc";
                    break;
                case ".exe":
                case ".saa":
                    return "application";
                    break;
                case ".stp":
                case ".pkg":
                case ".mod":
                    return "package";
                    break;
                case ".skn":
                case ".spk":
                    return "skin";
                    break;
                default:
                    return "none";
                    break;

            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Create New Folder", "Please enter the name of the folder.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string dname = API.GetInfoboxResult();
                if (dname != "" && dname != "Cancelled")
                {
                    string dirsepchar = "";
                    switch (OSInfo.GetPlatformID())
                    {
                        case "microsoft":
                            dirsepchar = "\\";
                            break;
                        default:
                            dirsepchar = "/";
                            break;
                    }
                    if (dname.Contains("/") || dname.Contains("\\"))
                    {
                        API.CreateInfoboxSession("Error", "Directories cannot have '\\' or '/' in their names!", infobox.InfoboxMode.Info);
                    }
                    else {
                        string fullname = CurrentFolder + dirsepchar + dname;
                        try
                        {
                            if (!Directory.Exists(fullname))
                            {
                                Directory.CreateDirectory(fullname);
                            }
                        }
                        catch (Exception ex)
                        {
                            API.CreateInfoboxSession("Error", "File Skimmer could not create the directory.", infobox.InfoboxMode.Info);
                        }
                    }
                }
                ListFiles();
            };
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = "nothing";
            if(lvfiles.SelectedItems.Count > 0)
            {
                var lvitem = lvfiles.SelectedItems[0];
                string lvtag = (string)lvitem.Tag;
                switch(lvtag)
                {
                    
                    case "_upOne":
                        res = "up";
                        break;
                    default:
                        if(Directory.Exists(lvtag))
                        {
                            res = "dir";
                        } else
                        {
                            if(File.Exists(lvtag))
                            {
                                res = "file";
                            }
                        }
                        break;
                }
                switch(res)
                {
                    case "file":
                        API.CreateInfoboxSession("Delete File", "Are you sure you want to delete this file?", infobox.InfoboxMode.YesNo);
                        API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                        {
                            if(API.GetInfoboxResult() == "Yes")
                            {
                                File.Delete(lvtag);
                                ListFiles();
                            }
                        };
                        break;
                    case "dir":
                        var fname = lvtag;
                        if(CheckTag(fname) == true)
                        {
                            API.CreateInfoboxSession("Permission denied", "You cannot delete this directory as you are denied permission.", infobox.InfoboxMode.Info);
                        }
                        else
                        {
                            API.CreateInfoboxSession("Delete Folder", "Are you sure you want to delete this folder? Everything inside it will be permanently lost!", infobox.InfoboxMode.YesNo);
                            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                            {
                                if (API.GetInfoboxResult() == "Yes")
                                {
                                    Directory.Delete(lvtag, true);
                                    ListFiles();
                                }
                            };
                        }
                        break;
                    case "up":
                        API.CreateInfoboxSession("File Skimmer", "You cannot delete the 'Up One Level' file because it is not a real file.", infobox.InfoboxMode.Info);
                        break;
                }
            }
        }

        /// <summary>
        /// No idea what this does but it seems to be needed so don't touch it.
        /// </summary>
        /// <param name="fullpath">Path to a file.</param>
        /// <returns>Oh NOW I know what this does. It returns whether this file can be deleted or if it's a vital save file.</returns>
        private bool CheckTag(string fullpath)
        {
            var correct = fullpath + OSInfo.DirectorySeparator;
            if (correct == Paths.SystemDir || correct == Paths.Applications || correct == Paths.Skins || correct == Paths.ToBeLoaded || correct == Paths.LoadedSkin || correct == Paths.SoftwareData || correct == Paths.Drivers || correct == Paths.Mod_AppLauncherEntries || correct == Paths.Mod_Temp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string selectedFilter = null;

        private void cbfiletypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFilter = (string)cbfiletypes.SelectedItem;
            ListFiles();
        }

        private void btnperformaction_Click(object sender, EventArgs e)
        {
            if (txtfilename.Text != "")
            {
                string dirsepchar = "\\";
                switch (OSInfo.GetPlatformID())
                {
                    case "microsoft":
                        dirsepchar = "\\";
                        break;
                    default:
                        dirsepchar = "/";
                        break;
                }
                string fullPath = null;
                if (Mode == FileSkimmerMode.OpenFolder)
                {
                    fullPath = CurrentFolder + dirsepchar + txtfilename.Text;
                }
                else {
                    fullPath = CurrentFolder + dirsepchar + txtfilename.Text.Replace(selectedFilter, "") + selectedFilter;
                }
                    FileName = fullPath;
                this.Close();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            FileName = "";
            this.Close();
        }

        private void lvfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itm = lvfiles.SelectedItems[0];
                if(File.Exists(itm.Tag.ToString()))
                {
                    txtfilename.Text = itm.Text;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
