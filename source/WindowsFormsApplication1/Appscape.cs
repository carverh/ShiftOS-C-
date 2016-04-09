using NetSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Appscape : Form
    {
        /// <summary>
        /// Front-end for the Appscape Package Manager.
        /// </summary>
        public Appscape()
        {
            InitializeComponent();
        }

        private List<AppscapeClient> clients = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            clients = new List<AppscapeClient>();
            foreach(var ip in Package_Grabber.clients.Keys)
            {
                if (Package_Grabber.clients[ip].IsConnected)
                {
                    var client = new AppscapeClient(ip);
                    client.OnSuccessfulDownload += (object s, EventArgs a) =>
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (AddressToSendTo != null)
                            {
                                var w = new BitnoteWallet();
                                while(w.Clients == null)
                                {

                                }
                                if (API.BitnoteAddress.Bitnotes >= CurrentItemCost)
                                {
                                    if (w.AddBitnotesToAddress(AddressToSendTo, CurrentItemCost))
                                    {
                                        API.CreateInfoboxSession("Package downloaded.", "The package has been successfully downloaded to your system.", infobox.InfoboxMode.Info);
                                        API.BitnoteAddress.Bitnotes -= CurrentItemCost;
                                    }
                                    else
                                    {
                                        API.CreateInfoboxSession("Server-side Bitnote Error", "We couldn't complete the transaction, but the package was still downloaded. No Bitnotes have been taken from your account.", infobox.InfoboxMode.Info);
                                    }
                                }
                                else
                                {
                                    File.Delete((string)s);
                                    API.CreateInfoboxSession("Insufficient funds.", "You do not have enough Bitnotes to complete the transaction.", infobox.InfoboxMode.Info);
                                }
                            }
                        }));
                    };
                    client.OnPackagesReceived += (object s, EventArgs a) =>
                    {
                        this.Invoke(new Action(() => { lvmypackages.Items.Clear(); }));
                        foreach (AppscapePackage package in client.Packages)
                        {
                            ListViewItem lvitem = new ListViewItem();
                            lvitem.Text = package.Name;
                            package.Server = client.IP;
                            lvitem.Tag = package;
                            this.Invoke(new Action(() =>
                            {
                                lvmypackages.Columns[0].Width = lvmypackages.Width;
                                if (MyDevProfile != null && LoungeClient != null)
                                {
                                    if (package.DevKey == MyDevProfile.DevKey)
                                    {
                                        var lvmy = new ListViewItem();
                                        lvmy.Text = package.Name;
                                        lvmy.Tag = package;
                                        lvmypackages.Items.Add(lvmy);
                                        lvmy.SubItems.Add(package.Cost.ToString());
                                    }
                                }
                                lvpackages.Items.Add(lvitem);
                                if (package.DevKey != null)
                                {
                                    client.GetDevList();
                                    try {
                                        var obj = client.DevList[package.DevKey];
                                        if (obj != null)
                                        {
                                            lvitem.SubItems.Add(obj.Name);
                                        }
                                        else
                                        {
                                            lvitem.SubItems.Add("Unknown");
                                        }
                                    }
                                    catch
                                    {
                                        lvitem.SubItems.Add("Unknown");
                                    }

                                }
                                else {
                                    lvitem.SubItems.Add("Unknown");
                                }
                                lvitem.SubItems.Add(package.Cost.ToString());
                            }));
                        }
                    };
                    client.OnSkinDataReceived += (object s, EventArgs a) =>
                    {
                        foreach (SkinData skin in client.Skins)
                        {
                            var item = new ListViewItem();
                            item.Text = skin.Name;
                            skin.Server = client.IP;
                            item.Tag = skin;
                            this.Invoke(new Action(() =>
                            {
                                lvpackages.Items.Add(item);
                                item.SubItems.Add("<NYI>");
                                item.SubItems.Add(skin.Cost.ToString());
                            }));
                        }
                    };
                    client.OnDevListSync += (object s, EventArgs a) =>
                    {
                        API.CurrentSession.Invoke(new Action(() =>
                        {
                            foreach (ListViewItem itm in lvpackages.Items)
                            {
                                if (DataType == "apps")
                                {
                                    var pkg = (AppscapePackage)itm.Tag;
                                    foreach (ListViewItem.ListViewSubItem subItem in itm.SubItems)
                                    {
                                        if (subItem.Text == "Unknown")
                                        { /********************************************************************************************************************************************************************************/
                                            if (client.DevList != null && pkg.DevKey != null)
                                            {
                                                if (client.DevList.ContainsKey(pkg.DevKey))
                                                {
                                                    var dev = client.DevList[pkg.DevKey];
                                                    subItem.Text = dev.Name;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }));
                    };
                    client.GetDevList();
                    clients.Add(client);
                }
            }
            SetupList();
            pnllist.BringToFront();
    
        }


        /// <summary>
        /// Sets up Appscape's package listing.
        /// </summary>
        public void SetupList()
        {
            if (DataType == "apps")
            {
                btnapps.BackColor = Color.Black;
                btnapps.ForeColor = Color.White;
                btnskins.BackColor = Color.White;
                btnskins.ForeColor = Color.Black;
            }
            else
            {
                btnapps.BackColor = Color.White;
                btnapps.ForeColor = Color.Black;
                btnskins.BackColor = Color.Black;
                btnskins.ForeColor = Color.White;
            }
            columnHeader1.Width = lvpackages.Width / 3;
            columnHeader2.Width = lvpackages.Width / 3;
            columnHeader3.Width = lvpackages.Width / 3;

            lvpackages.Items.Clear();
            pnlsearch.BackColor = API.CurrentSkin.titlebarcolour;
            pnlsearch.ForeColor = API.CurrentSkin.titletextcolour;
            if (DataType == "apps")
            {
                foreach (var client in clients)
                {
                    client.GetDevList();
                    client.GetPackageData();
                }
                
            }
            else
            {
                foreach (var client in clients)
                {
                    client.GetSkinData();
                }
                
            }
        }

        private string DownloadPath = "";

        private void lvpackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvpackages.SelectedItems.Count > 0)
            {
                lvpackages.SelectedItems[0].BackColor = Color.Gray;
                pnldownload.Show();
                foreach (ListViewItem lv in lvpackages.Items)
                {
                    lv.BackColor = Color.White;
                }
                if (DataType == "apps")
                {
                    AppscapePackage pkg = (AppscapePackage)lvpackages.SelectedItems[0].Tag;
                    lbpkgname.Text = pkg.Name;
                    lbpkgdescription.Text = pkg.Description;
                    try {
                        pbappscreenshot.Show();
                        pbappscreenshot.Load(pkg.ScreenshotPath);
                    }
                    catch(Exception ex)
                    {
                        pbappscreenshot.Hide();
                    }
                    if (pkg.SetupFile == "" || pkg.SetupFile == null)
                    {
                        pnldownload.Hide();
                    }
                    else
                    {
                        pnldownload.Show();
                        lbdownloadpath.Text = "This package will download to: " + pkg.Name + ".stp.";
                        if (!pkg.SetupFile.EndsWith(".stp"))
                        {
                            pkg.SetupFile = pkg.SetupFile + ".stp";
                        }
                        
                        foreach(var c in clients)
                        {
                            if(c.IP == pkg.Server)
                            {
                                DownloadClient = c;
                            }
                        }
                        DownloadPath = pkg.SetupFile;
                    }
                    try {
                        pbappicon.Show();
                        pbappicon.Load("http://playshiftos.ml/appscape/packages/" + pkg.PkgIconPath);
                    }
                    catch(Exception ex)
                    {
                        pbappicon.Hide();
                    }
                        if (pkg.Cost == 0)
                    {
                        CurrentItemCost = Convert.ToDecimal(pkg.Cost);
                    }
                    else {
                        CurrentItemCost = Convert.ToDecimal(pkg.Cost.ToString("#.#####"));
                    }
                        if(pkg.DevKey != null)
                    {
                        pnlauthordetails.Show();
                        lbauthorname.Text = "Author: " + GetModderByDevID(pkg.DevKey).Key.Name;
                        lbauthordescription.Text = GetModderByDevID(pkg.DevKey).Key.Bio;
                        AddressToSendTo = GetModderByDevID(pkg.DevKey).Key.BitnoteAddress;
                    }
                        else
                    {
                        pnlauthordetails.Hide();
                        //Classic packages.
                        if(pkg.Address != null)
                        {
                            AddressToSendTo = pkg.Address;
                        }
                        else
                        {
                            AddressToSendTo = null;
                        }
                    }
                }
                else
                {
                    var skin = (SkinData)lvpackages.SelectedItems[0].Tag;
                    lbpkgname.Text = skin.Name;
                    lbpkgdescription.Text = "Author: " + skin.Author + Environment.NewLine;
                    if (skin.Download.EndsWith(".skn"))
                    {
                        lbpkgdescription.Text += "Type: Single Skin (.skn)" + Environment.NewLine;
                    }
                    else
                    {
                        lbpkgdescription.Text += "Type: Skin Pack (.spk)" + Environment.NewLine;
                    }
                    if (skin.Screenshot != null)
                    {
                        pbappscreenshot.Show();
                        pbappscreenshot.Load(skin.Screenshot);
                    }
                    else
                    {
                        pbappscreenshot.Hide();
                    }
                    if (skin.Icon != null)
                    {
                        pbappicon.Show();
                        pbappicon.Load("http://shiftos.shiftgames.ml/appscape/skins/" + skin.Icon);
                    }
                    else
                    {
                        pbappicon.Hide();
                    }
                    if (skin.Cost == 0)
                    {
                        CurrentItemCost = Convert.ToDecimal(skin.Cost);
                    }
                    else {
                        CurrentItemCost = Convert.ToDecimal(skin.Cost.ToString("#.#####"));
                    }
                    lbpkgdescription.Text += Environment.NewLine + skin.Description;
                    lbdownloadpath.Text = "This skin will download to C:\\ShiftOS\\Home\\Downloads\\" + skin.Download;
                    foreach(var c in clients)
                    {
                        if(c.IP == skin.Server)
                        {
                            DownloadClient = c;
                        }
                    }
                    DownloadPath =  skin.Download;
                }
            }
        }

        public decimal CurrentItemCost = 0;
        public string AddressToSendTo = null;
        public AppscapeClient DownloadClient = null;
        public AppscapeClient LoungeClient = null;

        private void btndownload_Click(object sender, EventArgs e)
        {
            if (API.BitnoteAddress != null)
            {
                try
                {
                    if (API.BitnoteAddress.Bitnotes >= CurrentItemCost)
                    {
                        WebClient wc = new WebClient();
                        if (!Directory.Exists(Paths.Home + OSInfo.DirectorySeparator + "Downloads"))
                        {
                            Directory.CreateDirectory(Paths.Home + OSInfo.DirectorySeparator + "Downloads");
                        }
                        switch(DataType)
                        {
                            case "apps":
                                DownloadClient.DownloadPackage(DownloadPath);
                                break;
                            default:
                                DownloadClient.DownloadSkin(DownloadPath);
                                break;
                        }
                        
                    }
                    else
                    {
                        API.CreateInfoboxSession("Appscape - Not enough bitnotes!", "You do not have enough Bitnotes to buy this package.", infobox.InfoboxMode.Info);
                    }
                }
                catch (Exception wex)
                {
                    API.CreateInfoboxSession("Error", "An error has occurred while downloading the package." + Environment.NewLine + Environment.NewLine + wex.Message, infobox.InfoboxMode.Info);
                }
            }
            else
            {
                API.CreateInfoboxSession("No Bitnote Address Found", "It seems that your computer is not linked with a Bitnote address. Please go to shiftnet://main/bitnote/home.rnp for more information.", infobox.InfoboxMode.Info);
            }
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            var u = new AppscapeUploader(MyDevProfile, LoungeClient);
            API.CreateForm(u, "Appscape Uploader", Properties.Resources.iconAppscape);
        }

        public string DataType = "apps";

        private void btnapps_Click(object sender, EventArgs e)
        {
            pnllist.BringToFront();
            DataType = "apps";
            SetupList();
        }

        private void btnskins_Click(object sender, EventArgs e)
        {
            pnllist.BringToFront();
            DataType = "skins";
            SetupList();
        }

        private void lvpackages_DoubleClick(object sender, EventArgs e)
        {
            if(lvpackages.SelectedItems.Count > 0)
            {
                pnlpackageinfo.BringToFront();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (object s, DoWorkEventArgs a) =>
            {
                this.Invoke(new Action(() =>
                {
                    SetupList();
                }));
                if (txtsearch.Text != "")
                {
                    this.Invoke(new Action(() =>
                    {
                        pnllist.BringToFront();
                    }));
                    var newlst = new List<ListViewItem>();
                    this.Invoke(new Action(() =>
                    {
                        foreach (ListViewItem item in lvpackages.Items)
                        {
                            if (item.Text.ToLower().Replace(" ", "").Contains(txtsearch.Text.ToLower().Replace(" ", "")))
                            {
                                newlst.Add(item);
                            }
                        }
                        lvpackages.Items.Clear();
                    }));
                    foreach (ListViewItem itm in newlst)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lvpackages.Items.Add(itm);
                        }));
                    }
                }
            };
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Gets developer info using the specified key.
        /// 
        /// Bugs: If two servers contain the same key, the first key the method sees will be returned.
        /// </summary>
        /// <param name="DevID">The key to search for.</param>
        /// <returns>A pair containing the developer info as well as the client that contained the key.</returns>
        public KeyValuePair<AppscapeModder, AppscapeClient> GetModderByDevID(string DevID)
        {
            AppscapeModder dev = null;
            AppscapeClient clt = null;
            foreach (var client in clients)
            {
                if (client.DevList.ContainsKey(DevID))
                {
                    if (dev == null)
                    {
                        dev = client.DevList[DevID];
                        clt = client;
                    }
                }

            }
            return new KeyValuePair<AppscapeModder, AppscapeClient>(dev, clt);
        }

        private Dictionary<string, AppscapeModder> LocalDevList = null;

        /// <summary>
        /// Adds a new developer key to the specified client's listing.
        /// </summary>
        /// <param name="client">The client to add to.</param>
        public void GenerateNewDevKey(AppscapeClient client)
        {
            var rnd = new Random();
            int key = rnd.Next(1, 99999999);
            var dev = new AppscapeModder();
            dev.DevKey = key.ToString();
            dev.Name = "Modder";
            bool done = false;
            if (!client.DevList.ContainsKey(key.ToString()))
            {
                if (done != true)
                {
                    client.DevList.Add(dev.DevKey, dev);
                    client.UploadDevList(client.DevList);
                    done = true;
                    API.CreateInfoboxSession("Success.", $"Your new developer key is {dev.DevKey}. As long as you are connected to the {client.IP} repository, you can use this key to enter the Appscape Lounge, make a name for yourself, and start uploading.", infobox.InfoboxMode.Info);
                }
            }
        }

        private void btngetkey_Click(object sender, EventArgs e)
        {
            pnlchoosenetwork.BringToFront();
            SetupNetworks();
        }

        /// <summary>
        /// Lists all available Appscape repositories a key can be added to.
        /// </summary>
        private void SetupNetworks()
        {
            clhostnameheader.Width = lvnets.Width;
            lvnets.Items.Clear();
            foreach(var c in clients)
            {
                var lv = new ListViewItem();
                lv.Text = c.IP;
                lv.Tag = c;
                lvnets.Items.Add(lv);
            }
        }

        private AppscapeModder MyDevProfile = null;

        /// <summary>
        /// Sets up the Developer Lounge.
        /// </summary>
        public void SetupLounge()
        {
            pnllounge.BringToFront();
            //List of all my packages
            lvmypackages.Items.Clear();
            foreach (var client in clients)
            {
                client.GetPackageData();
            }

            //My name.
            lbmyname.Text = MyDevProfile.Name;
            txtmoddername.Text = MyDevProfile.Name;
            //Biography.
            lbmybio.Text = MyDevProfile.Bio;
            txtbio.Text = MyDevProfile.Bio;
            //My Bitnote Address
            txtbitnoteaddress.Text = MyDevProfile.BitnoteAddress;

        }

        private void btnlounge_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Appscape Developer Lounge", "Please enter your Developer Key to enter the Lounge.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetInfoboxResult();
                bool cont = true;
                if (res != "fail")
                {
                    try
                    {
                        var dev = GetModderByDevID(res);
                        MyDevProfile = dev.Key;
                        LoungeClient = dev.Value;
                        SetupLounge();
                    }
                    catch
                    {
                        cont = false;
                    }
                }
                if (cont != true)
                    API.CreateInfoboxSession("Appscape Developer Lounge", "That Developer Key was not found in the database.", infobox.InfoboxMode.Info);
            };
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var c = LoungeClient;
            c.DevList[MyDevProfile.DevKey] = MyDevProfile;
            c.UploadDevList(c.DevList);
            btnapps_Click(sender, e);
        }

        private void txtbitnoteaddress_TextChanged(object sender, EventArgs e)
        {
            MyDevProfile.BitnoteAddress = txtbitnoteaddress.Text;
        }

        private void txtbio_TextChanged(object sender, EventArgs e)
        {
            MyDevProfile.Bio = txtbio.Text;
        }

        private void txtmoddername_TextChanged(object sender, EventArgs e)
        {
            MyDevProfile.Name = txtmoddername.Text;
        }

        private AppscapePackage PackageToEdit = null;

        private void btnedit_Click(object sender, EventArgs e)
        {
            if(lvmypackages.SelectedItems.Count > 0)
            {
                ListViewItem itm = lvmypackages.SelectedItems[0];
                AppscapePackage pkg = (AppscapePackage)itm.Tag;
                PackageToEdit = pkg;
                pnlpackageeditor.BringToFront();
                SetupEditor();
            }
        }

        /// <summary>
        /// Sets up the package editor.
        /// </summary>
        private void SetupEditor()
        {
            if(PackageToEdit.Cost > 0)
            {
                cbsell.Checked = true;
            }
            txtprice.Text = PackageToEdit.Cost.ToString();
            txtpackagename.Text = PackageToEdit.Name;
            txtpackagedescription.Text = PackageToEdit.Description;
            SAAFile = null;
        }

        private string SAAFile = null;

        private void cbsell_CheckedChanged(object sender, EventArgs e)
        {
            lbprice.Visible = cbsell.Checked;
            lbaddress.Visible = cbsell.Checked;
            txtprice.Visible = cbsell.Checked;
            
        }

        private void btndonecustomizing_Click(object sender, EventArgs e)
        {
            bool ContinueUpload = true;
            //Create new package and assign values
            var pkg = PackageToEdit;
            var OldName = pkg.Name.Replace(" ", "_");
            pkg.Name = txtpackagename.Text;
            pkg.Description = txtpackagedescription.Text;
            if (cbsell.Checked == true)
            {
                try
                {
                    pkg.Cost = Convert.ToDecimal(Convert.ToDecimal(txtprice.Text).ToString("#.#####"));
                }
                catch (Exception ex)
                {
                    ContinueUpload = false;
                    API.CreateInfoboxSession("Error", "You have entered an incorrect price value.", infobox.InfoboxMode.Info);
                }
            }
            else {
                pkg.Cost = 0;
            }
            pkg.PkgIconPath = "";
            if (ContinueUpload == true)
            {

                if (!Directory.Exists(Paths.Mod_Temp + "newapm"))
                {
                    Directory.CreateDirectory(Paths.Mod_Temp + "newapm");
                }
                else
                {
                    Directory.Delete(Paths.Mod_Temp + "newapm", true);
                    Directory.CreateDirectory(Paths.Mod_Temp + "newapm");
                }

                //Copy app SAA and icon to package folder
                if (SAAFile != null)
                {
                    File.Copy(SAAFile, Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "app.saa");
                }
                else
                {
                    var wc = new WebClient();
                    wc.DownloadFile("http://playshiftos.ml/appscape/packages/" + OldName + ".stp", Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "app.saa");
                }
                Properties.Resources.iconShiftnet.Save(Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "Icon.bmp");
                
                //Create AL meta file for package (so it will display in the app launcher)
                var al = new ModApplauncherItem();
                al.Display = true;
                al.Icon = "Icon.bmp";
                al.Name = pkg.Name;
                al.ShiftCode = "runSAA:app.saa";
                al.AppDirectory = al.Name;

                //Serialize AL meta file and copy to package
                var json = JsonConvert.SerializeObject(al);
                File.WriteAllText(Paths.Mod_Temp + "newapm" + OSInfo.DirectorySeparator + "applauncher", json);

                //Package file to .stp and upload to Appscape
                ZipFile.CreateFromDirectory(Paths.Mod_Temp + "newapm", Paths.Mod_Temp + pkg.Name.Replace(" ", "_") + ".stp");
                LoungeClient.UploadPackage(pkg, File.ReadAllBytes(Paths.Mod_Temp + pkg.Name.Replace(" ", "_") + ".stp"));
                btnapps_Click(sender, e);

                SetupLounge();
                pnllounge.BringToFront();
            }
        }

        private void btnsaa_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".saa", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    SAAFile = res;
                    btnsaa.Text = new FileInfo(SAAFile).Name;
                }
            };
        }

        private void btnrequest_Click(object sender, EventArgs e)
        {
            if(lvnets.SelectedItems.Count > 0)
            {
                try
                {
                    GenerateNewDevKey((AppscapeClient)lvnets.SelectedItems[0].Tag);
                }
                catch
                {
                    API.CreateInfoboxSession("Error", "An error has occurred trying to process the request.", infobox.InfoboxMode.Info);
                }
            }
        }
    }

    public class AppscapeClient
    {
        #region Constructor

        /// <summary>
        /// Represents a client that communicates with an Appscape repository.
        /// 
        /// Generally you shouldn't need to create an instance of this unless you messed up Appscape and are desperately trying to fix it by rewriting it, in which case you really should've just rolled back the source code. xD
        /// </summary>
        /// <param name="ip_address">IP address of the repo. This can be found in Package_Grabber.clients.Keys.</param>
        public AppscapeClient(string ip_address)
        {
            try {
                var c = Package_Grabber.clients[ip_address];
                c.OnReceived += (object s, NetReceivedEventArgs<NetObject> a) =>
                {
                    var obj = (ObjectModel)a.Data.Object;
                    switch (_mode)
                    {
                        case "getapps":
                            try
                            {
                                Packages = (List<AppscapePackage>)obj.OptionalObject;
                                var h = OnPackagesReceived;
                                if (h != null)
                                {
                                    h(obj, new EventArgs());
                                }
                            }
                            catch
                            {

                            }

                            break;
                        case "get_devlist":
                            try {
                                if (obj.OptionalObject != null)
                                {
                                    if (DevList == null)
                                    {
                                        DevList = new Dictionary<string, AppscapeModder>();
                                    }
                                    var lst = (List<string>)obj.OptionalObject;
                                    foreach (string json in lst)
                                    {
                                        var dev = JsonConvert.DeserializeObject<AppscapeModder>(json);
                                        if (!DevList.ContainsKey(dev.DevKey))
                                        {
                                            DevList.Add(dev.DevKey, dev);
                                        }
                                    }
                                    var h = OnDevListSync;
                                    if (h != null)
                                    {
                                        h(obj, new EventArgs());
                                    }
                                }
                            }
                            catch
                            {

                            }
                            break;
                        case "getskins":
                            try
                            {
                                Skins = (List<SkinData>)obj.OptionalObject;
                                var h = OnSkinDataReceived;
                                if (h != null)
                                {
                                    h(obj, new EventArgs());
                                }
                            }
                            catch
                            {

                            }
                            break;
                        default:
                            try {
                                var command = (ObjectModel)a.Data.Object;
                                string[] args = command.Command.Split(' ');
                                switch (args[0])
                                {
                                    case "package_bytes":
                                        byte[] package = (byte[])command.OptionalObject;
                                        File.WriteAllBytes($"{Paths.Home}{OSInfo.DirectorySeparator}Downloads{OSInfo.DirectorySeparator}{args[1]}", package);
                                        var h = OnSuccessfulDownload;
                                        if (h != null)
                                        {
                                            h($"{Paths.Home}{OSInfo.DirectorySeparator}Downloads{ OSInfo.DirectorySeparator}{args[1]}", new EventArgs());
                                        }
                                        break;
                                    case "skin_bytes":
                                        byte[] skin = (byte[])command.OptionalObject;
                                        File.WriteAllBytes($"{Paths.Home}{OSInfo.DirectorySeparator}Downloads{OSInfo.DirectorySeparator}{args[1]}", skin);
                                        var ha = OnSuccessfulDownload;
                                        if (ha != null)
                                        {
                                            ha($"{Paths.Home}{OSInfo.DirectorySeparator}Downloads{ OSInfo.DirectorySeparator}{args[1]}", new EventArgs());
                                        }
                                        break;
                                }
                            }
                            catch
                            {

                            }
                            break;
                    }
                };
                _IP = ip_address;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("IP address not found in client list.");
            }
        }

        #endregion

        #region Events

        public event EventHandler OnPackagesReceived;
        public event EventHandler OnSkinDataReceived;
        public event EventHandler OnDevListSync;
        public event EventHandler OnDevGrabbed;
        public event EventHandler OnSuccessfulDownload;

        #endregion

        #region Variables

        public List<AppscapePackage> Packages = null;
        public List<SkinData> Skins = null;
        public Dictionary<string, AppscapeModder> DevList = null;
        private string _mode = "";
        private string _IP = "";
        public string IP { get { return _IP; } }
        
        #endregion

        #region Methods

        /// <summary>
        /// Connects to Appscape server and grabs app package listings.
        /// </summary>
        public void GetPackageData()
        {
            _mode = "getapps";
            Package_Grabber.SendMessage(_IP, "apm getapps");

        }

        /// <summary>
        /// Connects to server and requests a list of all developers.
        /// </summary>
        public void GetDevList()
        {
            _mode = "get_devlist";
            Package_Grabber.SendMessage(_IP, "get_devlist");
        }

        /// <summary>
        /// Downloads a package.
        /// </summary>
        /// <param name="pkg">Package name to download.</param>
        public void DownloadPackage(string pkg)
        {
            _mode = "";
            Package_Grabber.SendMessage(_IP, $"apm getpackage {pkg}");
        }

        /// <summary>
        /// Downloads a skin.
        /// </summary>
        /// <param name="skn">The skin name to download.</param>
        public void DownloadSkin(string skn)
        {
            _mode = "";
            Package_Grabber.SendMessage(_IP, $"apm getskin {skn}");
        }


        /// <summary>
        /// Uploads a new package to the server.
        /// </summary>
        /// <param name="pkgMeta">Package metadata (name, description, etc)</param>
        /// <param name="pkg">Byte array representing the .stp file to upload.</param>
        public void UploadPackage(AppscapePackage pkgMeta, byte[] pkg)
        {
            pkgMeta.SetupFile = pkgMeta.Name.Replace(" ", "_") + ".stp";
            Package_Grabber.SendMessage(_IP, $"apm uploadmeta {pkgMeta.Name.Replace(" ", "_")}.json", pkgMeta);
            Package_Grabber.SendMessage(_IP, $"apm upload {pkgMeta.SetupFile}", pkg);
        }

        /// <summary>
        /// Connects to Appscape server and grabs skin listings.
        /// </summary>
        public void GetSkinData()
        {
            _mode = "getskins";
            Package_Grabber.SendMessage(_IP, "apm getskins");

        }

        /// <summary>
        /// Contacts the server to save the devlist.
        /// </summary>
        /// <param name="dict">Updated dev list to save.</param>
        public void UploadDevList(Dictionary<string, AppscapeModder> dict)
        {
            Package_Grabber.SendMessage(_IP, "apm uploaddevlist", dict);
        }

        #endregion
    }
}
