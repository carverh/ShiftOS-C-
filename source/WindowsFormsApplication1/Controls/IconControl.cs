using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.IO;

namespace ShiftOS
{
    public partial class IconWidget : UserWidget
    {
        public IconWidget()
        {
            InitializeComponent();
        }

        private void IconWidget_Load(object sender, EventArgs e)
        {
            pblarge.Top = (this.Height - pblarge.Height) / 2;
        }

        

        public Image LargeImage
        {
            get
            {
                return pblarge.Image;
            }
            set
            {
                pblarge.Image = value;
            }
        }

        public string IconName
        {
            get
            {
                return lbname.Text;

            }
            set
            {
                lbname.Text = value;
            }
        }
        
        private void pblarge_Click(object sender, EventArgs e)
        {
            API.CreateGraphicPickerSession($"Icon - {IconName}", false);
            API.GraphicPickerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                if(API.GraphicPickerSession.IdleImage != null)
                {
                    LargeImage = API.GraphicPickerSession.IdleImage;
                }
            };
        }
    }

    
}
