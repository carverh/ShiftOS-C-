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
    public partial class Connection : UserWidget
    {
        public Connection()
        {
            InitializeComponent();
        }

        Computer conleft;
        Computer conright;

        public Computer ConnectionLeft
        {
            get
            {
                return conleft;
            }
        }

        public Computer ConnectionRight
        {
            get
            {
                return conright;
            }
        }
    }
}
