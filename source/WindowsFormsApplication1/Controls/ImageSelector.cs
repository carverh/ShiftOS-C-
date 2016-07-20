using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;
using System.IO;

namespace ShiftOS
{
    public partial class ImageSelector : UserWidget
    {
        public ImageSelector()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get
            {
                return btnselect.BackgroundImage;
            }
        }

        private string _ImagePath = null;

        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".pic;.png;.jpg;.bmp", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    var finf = new FileInfo(res);
                    _ImagePath = finf.Name;
                    btnselect.BackgroundImage = Image.FromFile(res);
                    btnselect.BackgroundImageLayout = ImageLayout.Center;
                }
            };
        }
    }
}
