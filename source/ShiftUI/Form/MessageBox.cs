using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftUI
{
    public class MessageBox : Form
    {
        
        public static void Show(string message, string title)
        {
            var m = new MessageBox(title, message);
            
            m.TopMost = true;
            m.ShowDialog();
        }

        public MessageBox(string title, string message)
        {
            var pnlbottom = new FlowLayoutPanel();
            pnlbottom.Height = 30;
            pnlbottom.BackColor = Application.CurrentSkin.MessageBox_BottomPanel;
            var pnltop = new Panel();
            pnlbottom.Dock = DockStyle.Bottom;
            pnltop.Dock = DockStyle.Fill;
            this.Widgets.Add(pnlbottom);
            pnlbottom.Show();
            this.Widgets.Add(pnltop);
            pnltop.Show();
            var btnok = new Button();
            btnok.Text = "OK";
            btnok.AutoSize = true;
            btnok.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlbottom.Widgets.Add(btnok);
            btnok.Show();
            btnok.Click += (s, a) =>
            {
                this.Close();
            };
            var lblmessage = new Label();
            lblmessage.Padding = new Padding(25);
            lblmessage.Text = message;
            lblmessage.Dock = DockStyle.Fill;
            pnltop.Widgets.Add(lblmessage);
            lblmessage.Show();
            //autosize the form
            int newheight = 10;
            for(int i = 0; i < lblmessage.Text.Length; i++)
            {
                if ((i % 2) == 0)
                    newheight += 10;
            }
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.Height = newheight + pnlbottom.Height;
            this.Load += (o, a) =>
            {
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            };
            this.Text = title;
        }
    }
}
