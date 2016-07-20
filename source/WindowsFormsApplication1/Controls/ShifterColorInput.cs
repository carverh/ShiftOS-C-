using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class ShifterColorInput : IShifterSetting
    {
        public ShifterColorInput()
        {
            InitializeComponent();
            pnlmainbuttoncolour.Click += (o, e) =>
            {
                API.CreateColorPickerSession(Text, pnlmainbuttoncolour.BackColor);
                API.ColorPickerSession.FormClosing += (s, a) =>
                {
                    var res = API.GetLastColorFromSession();
                    pnlmainbuttoncolour.BackColor = res;
                    InvokeEvent(o, e);
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
            get { return pnlmainbuttoncolour.BackColor; }
            set
            {
                pnlmainbuttoncolour.BackColor = (Color)value;
            }
        }


    }
}
