using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class ShifterGraphicInput : IShifterSetting
    {
        public ShifterGraphicInput()
        {
            InitializeComponent();
            pnlmainbuttoncolour.Click += (o, e) =>
            {
                API.CreateGraphicPickerSession(Text, false);
                API.GraphicPickerSession.FormClosing += (s, a) =>
                {
                    var res = API.GetGraphicPickerResult();
                    if(res != "fail")
                    {
                        pnlmainbuttoncolour.BackgroundImage = API.GraphicPickerSession.IdleImage;
                        InvokeEvent(o, e);
                    }
                };
            };
        }

        public override string Text
        {
            get { return lblabel.Text; }
            set { lblabel.Text = value; }
        }

        public override object Value
        {
            get { return pnlmainbuttoncolour.BackgroundImage; }
            set
            {
                pnlmainbuttoncolour.BackgroundImage = (Image)value;
            }
        }

    }
}
