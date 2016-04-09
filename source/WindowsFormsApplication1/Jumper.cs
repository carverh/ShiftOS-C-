using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Jumper : Form
    {
        public Jumper()
        {
            InitializeComponent();
        }

        enum GameStatus
        {
            Idle,
            GameOver,
            Playing
        }

        private GameStatus status = GameStatus.Idle;
        private int JumpingStage = 0; //not jumping

        int gamespeed = 1;
        int codepointsearned = 0;

        Random rand = new Random();

        private void tmrscreenupdate_Tick(object sender, EventArgs e)
        {
            ground.Location = new Point(0, 260);
            ground.Size = new Size(this.ClientRectangle.Width, 2);
            ground.BackColor = Color.Black;
            switch(JumpingStage)
            {
                case 0:
                    player.Location = new Point(100, 228);
                    break;
                case 1:
                    if(player.Location.Y != 200)
                    {
                        player.Location = new Point(player.Location.X, player.Location.Y - 5);
                    } else
                    {
                        JumpingStage = 2;
                    }
                    break;
                case 2:
                    if (player.Location.Y != 228)
                    {
                        player.Location = new Point(player.Location.X, player.Location.Y + 5);
                    }
                    else
                    {
                        JumpingStage = 0;
                        lbstatus.Text = "Landed";
                    }
                    break;
                    
            }
            int randres = rand.Next(0, 9);
            switch(randres)
            {
                case 5:
                    Panel enemy = new Panel();
                    this.Controls.Add(enemy);
                    enemy.Location = new Point(this.ClientRectangle.Width, 227);
                    enemy.BackColor = Color.Black;
                    enemy.Size = new Size(32, 27);
                    enemy.Tag = "enemy";
                    enemy.Show();
                    break;
            }

            foreach (Control ctrl in this.Controls)
            {
                string enemytag = "enemy";
                if (enemytag == (string)ctrl.Tag)
                {
                    if (ctrl.Location.X < 0 - ctrl.Width)
                    {
                        ctrl.Hide();
                    }
                    else
                    {
                        ctrl.Location = new Point(ctrl.Location.X - (2 * gamespeed), ctrl.Location.Y);
                    }
                    if (ctrl.Left >= player.Left && ctrl.Left <= player.Right)
                    {
                        if(ctrl.Top >= player.Top && ctrl.Bottom <= player.Bottom)
                        {
                            status = GameStatus.GameOver;
                        }
                    }
                }
            }

            switch(status)
            {
                case GameStatus.Playing:
                    codepointsearned += gamespeed;
                    btnplay.Hide();
                    lbstatus.Text = "Codepoints: " + codepointsearned.ToString();
                    break;
                case GameStatus.GameOver:
                    tmrscreenupdate.Stop();
                    API.CreateInfoboxSession("You hit an obstacle.", "You have run into an obstacle. You have earned " + codepointsearned.ToString() + " Codepoints.", infobox.InfoboxMode.Info);
                    API.AddCodepoints(codepointsearned);
                    codepointsearned = 0;
                    if(API.Upgrades["multitasking"] == true)
                    {
                        this.Close(); //Close if multitasking is true.
                    }
                    break;
            }
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            if(this.status == GameStatus.Idle)
            {
                this.status = GameStatus.Playing;
                this.Focus();
                this.KeyDown += (object s, KeyEventArgs a) =>
                {
                    if (a.KeyCode == Keys.Space)
                    {
                        if (JumpingStage == 0)
                        {
                            JumpingStage = 1;
                            lbstatus2.Text = "Jumping...";
                        }
                        a.SuppressKeyPress = true;
                    }
                };
                tmrscreenupdate.Start();
            }
        }
    }
}
