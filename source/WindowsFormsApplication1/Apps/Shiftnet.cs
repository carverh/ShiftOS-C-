using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ShiftOS
{
    public partial class Shiftnet : Form
    {
        public Shiftnet()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitialSetup();
        }

        public void InitialSetup()
        {
            pnlcontrols.BackColor = API.CurrentSkin.titlebarcolour;
            wbshiftnet.DocumentText = WebLayer.VisitSite("shiftnet://main");
            txtaddress.Text = WebLayer.LastUrl;
        }

        private void LinkInterceptor(object sender, WebBrowserNavigatingEventArgs e)
        {
            var url = e.Url.OriginalString;
            if (url != "about:blank")
            {
                var surl = url.Replace("http://", "shiftnet://");
                wbshiftnet.DocumentText = WebLayer.VisitSite(surl);
                txtaddress.Text = WebLayer.LastUrl;
            }
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            if (txtaddress.Text.ToLower().StartsWith("shiftnet://"))
            {
                wbshiftnet.DocumentText = WebLayer.VisitSite(txtaddress.Text);
                txtaddress.Text = WebLayer.LastUrl;
            }
            else
            {
                wbshiftnet.DocumentText = WebLayer.VisitSite("shiftnet://not_found");
                txtaddress.Text = WebLayer.LastUrl;
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            wbshiftnet.DocumentText = WebLayer.VisitSite("shiftnet://main");
            txtaddress.Text = WebLayer.LastUrl;
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class WebLayer
    {
        public static String serverurl = "http://playshiftos.ml";
        private static string HtmlTemplate = "<html><head><title>Shiftnet Page</title><link rel=\"stylesheet\" href=\"" + serverurl + "/shiftnet.css\"/></head><body>#BODY#</body></html>";
        public static string LastUrl = null;

        public static string VisitSite(string url)
        {
            var wc = new WebClient();
            if (url.ToLower().EndsWith(".stml") || url.ToLower().EndsWith(".rnp"))
            {
                try
                {
                    string content = wc.DownloadString(url.Replace("shiftnet://", serverurl  + "/shiftnet/www/"));
                    if (content.StartsWith("<!STML>"))
                    {
                        LastUrl = url;
                        return HtmlTemplate.Replace("#BODY#", content.Replace("<!STML>", ""));
                    }
                    else
                    {
                        LastUrl = "shiftnet:not_found";

                        return HtmlTemplate.Replace("#BODY#", "That page was not found.");
                    }
                }
                catch 
                {
                    LastUrl = "shiftnet://not_found";
                    return HtmlTemplate.Replace("#BODY#", "That page was not found.");
                }
            }
            else
            {
                if (url.EndsWith("/"))
                {
                    return VisitSite(url + "home.rnp");
                }
                else
                {
                    return VisitSite(url + "/home.rnp");
                }

            }
        }
    }

}
