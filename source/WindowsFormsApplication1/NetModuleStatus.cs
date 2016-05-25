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
    public partial class NetModuleStatus : UserControl
    {
        private Module _module = null;

        public NetModuleStatus(Module m)
        {
            _module = m;
            InitializeComponent();
            var t = new Timer();
            t.Tick += (object s, EventArgs a) =>
            {
                lbinfo.Text = _module.Hostname;
                pghealth.MaxValue = _module.GetTotalHP();
                pghealth.Value = _module.HP;
                if(_module.HP == _module.GetTotalHP())
                {
                    if(this.Visible == true)
                    {
                        this.Hide();
                    }
                }
                else
                {
                    if(this.Visible == false)
                    {
                        this.Show();
                    }
                }
            };
            t.Interval = 100;
            t.Start();
        }
    }
}
