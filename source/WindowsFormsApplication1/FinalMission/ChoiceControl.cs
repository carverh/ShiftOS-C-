using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS.FinalMission
{
    [DefaultEvent("Selected")]
    public partial class ChoiceControl : UserControl
    {
        public ChoiceControl()
        {
            InitializeComponent();
        }

        public int Number
        {
            get { return Convert.ToInt32(lbnumber.Text); }
            set { lbnumber.Text = value.ToString(); }
        }

        public string ChoiceName
        {
            get
            {
                return lbdescription.Text;
            }
            set
            {
                lbdescription.Text = value;
            }
        }

        public event EventHandler Selected;

        private void lbdescription_Click(object sender, EventArgs e)
        {
            var h = this.Selected;
            if(h != null)
            {
                h(this, e);
            }
        }
    }
}
