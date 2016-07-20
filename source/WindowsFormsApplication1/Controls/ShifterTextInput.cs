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
    public partial class ShifterTextInput : IShifterSetting
    {
        public ShifterTextInput()
        {
            InitializeComponent();
            txttext.TextChanged += (o, e) =>
            {
                Value = txttext.Text;
                InvokeEvent(o, e);
            };
        }

        public override string Text
        {
            get
            {
                return Label51.Text;
            }
            set
            {
                Label51.Text = value;
            }
        }

        public override object Value
        {
            get
            {
                return txttext.Text;
            }
            set
            {
                txttext.Text = value as string;
            }
        }


        
    }

    public class IShifterSetting : UserWidget
    {
        public virtual string Text { get; set; }
        public virtual object Value { get; set; }
        public event EventHandler OnValueChange;

        public void InvokeEvent(object s, EventArgs a)
        {
            OnValueChange?.Invoke(s, a);
        }
    }

}
