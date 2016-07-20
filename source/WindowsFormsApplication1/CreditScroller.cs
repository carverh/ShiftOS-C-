using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class CreditScroller : Form
    {
        public CreditScroller()
        {
            InitializeComponent();
        }

        #region pong visualizer variables


        bool pongVisible = false;
        Random rand = new Random();
        int xVel = 7;
        int yVel = 8;
        int computerspeed = 8;
        int level = 1;
        int secondsleft = 60;
        int casualposition;
        double xveldec = 3.0;
        double yveldec = 3.0;
        double incrementx = 0.4;
        double incrementy = 0.2;
        int levelxspeed = 3;
        int levelyspeed = 3;
        int beatairewardtotal;
        int beataireward = 1;
        int[] levelrewards = new int[50];
        int countdown = 3;

        #endregion

        int offset = 0;

        private void tmrredraw_Tick(object sender, EventArgs e)
        {
            pgcontents.Visible = pongVisible;
            lbcreditstext.Top = pnlscroll.Height - offset;
            if(pongVisible)
                lbcreditstext.Left = (pnlscroll.Width - lbcreditstext.Width);
            else
                lbcreditstext.Left = (pnlscroll.Width - lbcreditstext.Width) / 2;
            offset += 1;
        }

        private void CreditScroller_Load(object sender, EventArgs e)
        {
            Audio.Play("hackerbattle_ambient");
            tmrredraw.Interval = 50;
            lbcreditstext.Text = Properties.Resources.Credits.Replace("#VER#", Consts.Version);
            tmrredraw.Start();
            newgame();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pongGameTimer_Tick(object sender, EventArgs e)
        {
            //Move player according to ball
            if(ball.Left < 250 + xVel / 10 && xVel < 0)
            {
                if(ball.Top > paddleHuman.Top + 50)
                {
                    paddleHuman.Top += computerspeed * 2 + ((int)yveldec / 2);
                }
                else if(ball.Top < paddleHuman.Top + 50)
                {
                    paddleHuman.Top -= computerspeed * 2 + ((int)yveldec / 2);
                }
            }

            //Set the computer player to move according to the ball's position.
            if (ball.Location.X > 500 - xVel * 10 && xVel > 0)
            {
                if (ball.Location.Y > paddleComputer.Location.Y + 50)
                {
                    paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y + computerspeed * 2 + ((int)yveldec / 2));
                }
                if (ball.Location.Y < paddleComputer.Location.Y + 50)
                {
                    paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y - computerspeed * 2 + ((int)yveldec / 2));
                }
                casualposition = rand.Next(-150, 201);
            }
            
            //Set Xvel and Yvel speeds from decimal
            if (xVel > 0)
                xVel = (int)Math.Round(xveldec);
            if (xVel < 0)
                xVel = (int)-Math.Round(xveldec);
            if (yVel > 0)
                yVel = (int)Math.Round(yveldec);
            if (yVel < 0)
                yVel = (int)-Math.Round(yveldec);

            // Move the game ball.
            ball.Location = new Point(ball.Location.X + xVel, ball.Location.Y + yVel);

            // Check for top wall.
            if (ball.Location.Y < 0)
            {
                ball.Location = new Point(ball.Location.X, 0);
                yVel = -yVel;
            }

            // Check for bottom wall.
            if (ball.Location.Y > pgcontents.Height - ball.Height)
            {
                ball.Location = new Point(ball.Location.X, pgcontents.Height - ball.Size.Height);
                yVel = -yVel;
            }

            // Check for player paddle.
            if (ball.Bounds.IntersectsWith(paddleHuman.Bounds))
            {
                ball.Location = new Point(paddleHuman.Location.X + ball.Size.Width, ball.Location.Y);
                //randomly increase x or y speed of ball
                switch (rand.Next(1, 3))
                {
                    case 1:
                        xveldec = xveldec + incrementx;
                        break;
                    case 2:
                        if (yveldec > 0)
                            yveldec = yveldec + incrementy;
                        if (yveldec < 0)
                            yveldec = yveldec - incrementy;
                        break;
                }
                xVel = -xVel;
            }

            // Check for computer paddle.
            if (ball.Bounds.IntersectsWith(paddleComputer.Bounds))
            {
                ball.Location = new Point(paddleComputer.Location.X - paddleComputer.Size.Width + 1, ball.Location.Y);
                xveldec = xveldec + incrementx;
                xVel = -xVel;
            }

            // Check for left wall.
            if (ball.Location.X < -100)
            {
                ball.Location = new Point(pgcontents.Size.Width / 2 + 200, pgcontents.Size.Height / 2);
                paddleComputer.Location = new Point(paddleComputer.Location.X, ball.Location.Y);
                paddleHuman.Location = new Point(paddleHuman.Location.X, ball.Location.Y);

                if (xVel > 0)
                    xVel = -xVel;
                pongGameTimer.Stop();
                tmrcountdown.Start();
                counter.Stop();
            }

            // Check for right wall.
            if (ball.Location.X > pgcontents.Width - ball.Size.Width - paddleComputer.Width + 100)
            {
                ball.Location = new Point(pgcontents.Size.Width / 2 + 200, pgcontents.Size.Height / 2);
                paddleComputer.Location = new Point(paddleComputer.Location.X, ball.Location.Y);
                paddleHuman.Location = new Point(paddleHuman.Location.X, ball.Location.Y);

                if (xVel > 0)
                    xVel = -xVel;
                beatairewardtotal = beatairewardtotal + beataireward;
                tmrcountdown.Start();
                pongGameTimer.Stop();
                counter.Stop();
            }

            //lblstats.Text = "Xspeed: " & Math.Abs(xVel) & " Yspeed: " & Math.Abs(yVel) & " Human Location: " & paddleHuman.Location.ToString & " Computer Location: " & paddleComputer.Location.ToString & Environment.NewLine & " Ball Location: " & ball.Location.ToString & " Xdec: " & xveldec & " Ydec: " & yveldec & " Xinc: " & incrementx & " Yinc: " & incrementy
            lblstatsX.Text = "Xspeed: " + xveldec;
            lblstatsY.Text = "Yspeed: " + yveldec;
            
            lbllevelandtime.Text = "Level: " + level;

            if (xVel > 20 || xVel < -20)
            {
                paddleHuman.Width = Math.Abs(xVel);
                paddleComputer.Width = Math.Abs(xVel);
            }
            else
            {
                paddleHuman.Width = 20;
                paddleComputer.Width = 20;
            }

            computerspeed = Math.Abs(yVel);

            //  pgcontents.Refresh()
            // pgcontents.CreateGraphics.FillRectangle(Brushes.Black, ball.Location.X, ball.Location.Y, ball.Width, ball.Height)

        }

        private void counter_Tick(object sender, EventArgs e)
        {
            secondsleft = secondsleft - 1;
            if (secondsleft == -1)
            {
                secondsleft = 60;
                level = level + 1;


            }

        }

        private void tmrcountdown_Tick(object sender, EventArgs e)
        {
            switch (countdown)
            {
                case 0:
                    countdown = 3;
                    lblcountdown.Hide();
                    pongGameTimer.Start();
                    counter.Start();
                    tmrcountdown.Stop();
                    break;
                case 1:
                    lblcountdown.Text = "1";
                    countdown = countdown - 1;
                    break;
                case 2:
                    lblcountdown.Text = "2";
                    countdown = countdown - 1;
                    break;
                case 3:
                    lblcountdown.Text = "3";
                    countdown = countdown - 1;
                    lblcountdown.Show();
                    break;
            }
        }

        private void newgame()
        {
            level = 1;
            beataireward = 2;
            beatairewardtotal = 0;
            secondsleft = 60;
            //reset stats text
            lblstatsX.Text = "Xspeed: ";
            lblstatsY.Text = "Yspeed: ";

            levelxspeed = 3;
            levelyspeed = 3;

            incrementx = 0.4;
            incrementy = 0.2;

            xveldec = levelxspeed;
            yveldec = levelyspeed;

            tmrcountdown.Start();
            if (xVel < 0)
                xVel = Math.Abs(xVel);
            lbllevelandtime.Text = "Level: " + level + " - " + secondsleft + " Seconds Left";
        }
    }
}
