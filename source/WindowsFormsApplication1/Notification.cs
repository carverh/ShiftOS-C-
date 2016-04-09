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
    public partial class Notification : UserControl
    {
        public Notification(string title, string text)
        {
            InitializeComponent();
            Title = title;
            Message = text;
            var t = new Timer();
            t.Interval = 5000;
            t.Tick += (object s, EventArgs a) =>
            {
                this.Dispose();
            };
            t.Start();
        }

        public string Title { get; set; }
        public string Message { get; set; }

        private void Notification_Load(object sender, EventArgs e)
        {
            API.PlaySound(Properties.Resources.rolldown);
            lbtitle.Text = Title;
            lbmessage.Text = Message;
        }
    }
}
