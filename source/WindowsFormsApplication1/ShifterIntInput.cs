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
    public partial class ShifterIntInput : IShifterSetting
    {
        public ShifterIntInput()
        {
            InitializeComponent();
        }

        public bool NoDecimal
        {
            get;
            set;
        }

        public override string Text
        {
            get { return Label51.Text; }
            set { Label51.Text = value; }
        }

        public override object Value
        {
            get {
                if (NoDecimal)
                    return Convert.ToInt32(txttext.Text);
                else
                    return Convert.ToDecimal(txttext.Text);
            }
            set
            {
                txttext.Text = value.ToString();
            }
        }

        private void txttext_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (NoDecimal)
                    Value = Convert.ToInt32(txttext.Text);
                else
                    Value = Convert.ToDecimal(txttext.Text);
                InvokeEvent(sender, e);
            }
            catch
            {
                txttext.Text = Value.ToString();
            }
        }
    }
}
