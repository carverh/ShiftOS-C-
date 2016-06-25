using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class WidgetManager : Form
    {
        public WidgetManager()
        {
            InitializeComponent();
        }

        private void WidgetManager_Load(object sender, EventArgs e)
        {
            SetupList();
        }

        public void SetupList()
        {
            lvwidgets.Items.Clear();
            foreach(ColumnHeader c in lvwidgets.Columns)
            {
                c.Width = lvwidgets.Width / 2;
            }
            if(!Directory.Exists(Paths.WidgetFiles))
            {
                Directory.CreateDirectory(Paths.WidgetFiles);
            }
            foreach(var f in Directory.GetFiles(Paths.WidgetFiles))
            {
                var finf = new FileInfo(f);
                if(finf.Extension == ".json")
                {
                    var json = File.ReadAllText(finf.FullName);
                    var widget = JsonConvert.DeserializeObject<DesktopWidgetModel>(json);
                    var lv = new ListViewItem();
                    lv.Text = widget.Name;
                    lv.Tag = widget;
                    lvwidgets.Items.Add(lv);
                    lv.SubItems.Add(widget.Description);
                }
            }
        }

        private DesktopWidgetModel SelectedFutureWidget = null;

        private void lvwidgets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFutureWidget = (DesktopWidgetModel)lvwidgets.SelectedItems[0].Tag;
            cbpanel.Items.Clear();
            foreach(var p in API.CurrentSkin.DesktopPanels)
            {
                cbpanel.Items.Add(p.Position);
            }
            cbpanel.Text = (string)cbpanel.Items[0];
        }

        private void btndone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try {
                if (cbpanel.Text != null)
                {
                    var w = new Skinning.DesktopWidget();
                    w.Name = SelectedFutureWidget.Name;
                    w.Panel = cbpanel.Text;
                    w.XLocation = Convert.ToInt32(txtx.Text);
                    w.Width = Convert.ToInt32(txtwidth.Text);
                    w.Lua = SelectedFutureWidget.Lua;
                    w.Type = SelectedFutureWidget.Type;
                    API.CurrentSkin.Widgets.Add(w);
                    GC.Collect();
                    API.CurrentSession.SetupWidgets();
                    Skinning.Utilities.saveskin();
                }
                else
                {
                    API.CreateInfoboxSession("Please select a location.", "Please select a desktop panel for the new widget!", infobox.InfoboxMode.Info);
                }
            }
            catch
            {
                API.CreateInfoboxSession("Missing information", "Not enough valid info was given for the new widget. Remember, the width and location must be valid integers and the position must be either \"Top\" or \"Bottom\".", infobox.InfoboxMode.Info);
            }
            GC.Collect();
        }

        private void tmrcheckvalid_Tick(object sender, EventArgs e)
        {
            if(SelectedFutureWidget != null)
            {
                btnadd.Show();
                lbwidth.Show();
                txtwidth.Show();
                cbpanel.Show();
                label1.Show();
                txtx.Show();
            }
            else
            {
                btnadd.Hide();
                lbwidth.Hide();
                txtwidth.Hide();
                cbpanel.Hide();
                label1.Hide();
                txtx.Hide();
            }
        }

        private void btninstallwidgets_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".wgt", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if (res != "fail")
                {
                    try
                    {
                        if(!Directory.Exists(Paths.WidgetFiles))
                        {
                            Directory.CreateDirectory(Paths.WidgetFiles);
                        }
                        if(Directory.Exists(Paths.Mod_Temp + "_newwidget"))
                        {
                            Directory.Delete(Paths.Mod_Temp + "_newwidget", true);
                        }
                        ZipFile.ExtractToDirectory(res, Paths.Mod_Temp + "_newwidget");
                        foreach(var f in Directory.GetFiles(Paths.Mod_Temp + "_newwidget"))
                        {
                            var finf = new FileInfo(f);
                            File.Copy(f, res + OSInfo.DirectorySeparator + finf.Name, true);
                        }
                        SetupList();
                    }
                    catch
                    {
                        API.CreateInfoboxSession("Invalid widget pack.", "The widget pack you selected is not a valid widget pack.", infobox.InfoboxMode.Info);
                    }
                }
            };
        }
    }

    public class DesktopWidgetModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WidgetType Type { get; set; }
        public string Lua { get; set; }
    }

    public enum WidgetType
    {
        Icon,
        Menu,
        DisplayText,
        FreePanel
    }
}
