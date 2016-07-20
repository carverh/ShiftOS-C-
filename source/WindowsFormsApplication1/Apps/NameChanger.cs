using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    
    public partial class NameChanger : Form
    {
        public NameChanger()
        {
            InitializeComponent();
        }

        public NamePackModel np = new NamePackModel();

        public void LoadModel()
        {
            var n = Skinning.Utilities.LoadedNames;
            np.ArtpadName = n.ArtpadName;
            np.TextpadName = n.TextpadName;
            np.PongName = n.PongName;
            np.TerminalName = n.TerminalName;
            np.ShutdownName = n.ShutdownName;
            np.ShifterName = n.ShifterName;
            np.NameChangerName = n.NameChangerName;
            np.ShiftoriumName = n.ShiftoriumName;
            np.UnityName = n.UnityName;
            np.KnowledgeInputName = n.KnowledgeInputName;
            np.SkinLoaderName = n.SkinLoaderName;
            np.FileSkimmerName = n.FileSkimmerName;
        }

        public void SaveModel()
        {
            var json = JsonConvert.SerializeObject(np);
            File.WriteAllText(Paths.LoadedSkin + "names.npk", json);
        }

        private void NameChanger_Load(object sender, EventArgs e)
        {
            LoadModel();
            propertyGrid1.SelectedObject = np;
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            int cp = new Random().Next(1, 5);
            SaveModel();
            API.CreateInfoboxSession("Name Changer", "The new Name Pack has been applied! You have earned " + cp.ToString() + " Codepoints!", infobox.InfoboxMode.Info);
            Skinning.Utilities.saveskin();
            API.CurrentSession.SetupDesktop();
            API.AddCodepoints(cp);
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".npk", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    string json = File.ReadAllText(res);
                    np = JsonConvert.DeserializeObject<NamePackModel>(json);
                }
            };
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".npk", File_Skimmer.FileSkimmerMode.Save);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    string json = JsonConvert.SerializeObject(np);
                    File.WriteAllText(res, json);
                }
            };
        }
    }
    public class NamePackModel
    {
        public string TerminalName { get; set; }
        public string ArtpadName { get; set; }
        public string TextpadName { get; set; }
        public string ShiftoriumName { get; set; }
        public string KnowledgeInputName { get; set; }
        public string PongName { get; set; }
        public string ShifterName { get; set; }
        public string FileSkimmerName { get; set; }
        public string SkinLoaderName { get; set; }
        public string ShutdownName { get; set; }
        public string UnityName { get; set; }
        public string NameChangerName { get; set; }
    }
}
