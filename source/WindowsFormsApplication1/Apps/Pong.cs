using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class Pong : Form
    {
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
        int totalreward;
        int countdown = 3;
        
        public Pong()
        {
            InitializeComponent();
        }

        private void Pong_Load(object sender, EventArgs e)
        {
            setuplevelrewards();

            if(API.Upgrades["customgrayshades"] == true && API.Upgrades["multitasking"] == true)
            {
                if(API.Upgrades["shiftnet"] == false)
                {
                    tmrstoryline.Start();
                }
            }
        }

        // Move the paddle according to the mouse position.
        private void pongMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            paddleHuman.Location = new Point(paddleHuman.Location.X, (MousePosition.Y - this.Location.Y) - (paddleHuman.Height / 2));
        }


        // ERROR: Handles clauses are not supported in C#
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (this.Left < Screen.PrimaryScreen.Bounds.Width)
            {
                if (this.Height != API.CurrentSkin.titlebarheight)
                {
                    //Set the computer player to move according to the ball's position.
                    if (ball.Location.X > 500 - xVel * 10 && xVel > 0)
                    {
                        if (ball.Location.Y > paddleComputer.Location.Y + 50)
                        {
                            paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y + computerspeed);
                        }
                        if (ball.Location.Y < paddleComputer.Location.Y + 50)
                        {
                            paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y - computerspeed);
                        }
                        casualposition = rand.Next(-150, 201);
                    }
                    else {
                        //used to be me.location.y
                        if (paddleComputer.Location.Y > this.Size.Height / 2 - paddleComputer.Height + casualposition)
                        {
                            paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y - computerspeed);
                        }
                        //used to be me.location.y
                        if (paddleComputer.Location.Y < this.Size.Height / 2 - paddleComputer.Height + casualposition)
                        {
                            paddleComputer.Location = new Point(paddleComputer.Location.X, paddleComputer.Location.Y + computerspeed);
                        }
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
                        API.PlaySound(Properties.Resources.typesound);
                    }

                    // Check for computer paddle.
                    if (ball.Bounds.IntersectsWith(paddleComputer.Bounds))
                    {
                        ball.Location = new Point(paddleComputer.Location.X - paddleComputer.Size.Width + 1, ball.Location.Y);
                        xveldec = xveldec + incrementx;
                        xVel = -xVel;
                        API.PlaySound(Properties.Resources.typesound);
                    }

                    // Check for left wall.
                    if (ball.Location.X < -100)
                    {
                        ball.Location = new Point(this.Size.Width / 2 + 200, this.Size.Height / 2);
                        paddleComputer.Location = new Point(paddleComputer.Location.X, ball.Location.Y);
                        if (xVel > 0)
                            xVel = -xVel;
                        pnllose.Show();
                        gameTimer.Stop();
                        counter.Stop();
                        lblmissedout.Text = "You Missed Out On:" + Environment.NewLine + lblstatscodepoints.Text.Replace("Codepoints earned: ", "") + " Codepoints";
                    }

                    // Check for right wall.
                    if (ball.Location.X > this.Width - ball.Size.Width - paddleComputer.Width + 100)
                    {
                        ball.Location = new Point(this.Size.Width / 2 + 200, this.Size.Height / 2);
                        paddleComputer.Location = new Point(paddleComputer.Location.X, ball.Location.Y);
                        if (xVel > 0)
                            xVel = -xVel;
                        beatairewardtotal = beatairewardtotal + beataireward;
                        lblbeatai.Show();
                        lblbeatai.Text = "You got " + beataireward + " codepoints for beating the Computer!";
                        tmrcountdown.Start();
                        gameTimer.Stop();
                        counter.Stop();
                    }

                    //lblstats.Text = "Xspeed: " & Math.Abs(xVel) & " Yspeed: " & Math.Abs(yVel) & " Human Location: " & paddleHuman.Location.ToString & " Computer Location: " & paddleComputer.Location.ToString & Environment.NewLine & " Ball Location: " & ball.Location.ToString & " Xdec: " & xveldec & " Ydec: " & yveldec & " Xinc: " & incrementx & " Yinc: " & incrementy
                    lblstatsX.Text = "Xspeed: " + xveldec;
                    lblstatsY.Text = "Yspeed: " + yveldec;
                    lblstatscodepoints.Text = "Codepoints earned: " + (levelrewards[level - 1] + beatairewardtotal).ToString();

                    lbllevelandtime.Text = "Level: " + level + " - " + secondsleft + " Seconds Left";

                    if (xVel > 20 || xVel < -20)
                    {
                        paddleHuman.Width = Math.Abs(xVel);
                        paddleComputer.Width = Math.Abs(xVel);
                    }
                    else {
                        paddleHuman.Width = 20;
                        paddleComputer.Width = 20;
                    }

                    computerspeed = Math.Abs(yVel);

                    //  pgcontents.Refresh()
                    // pgcontents.CreateGraphics.FillRectangle(Brushes.Black, ball.Location.X, ball.Location.Y, ball.Width, ball.Height)
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void counter_Tick(object sender, EventArgs e)
        {
            if (this.Left < Screen.PrimaryScreen.Bounds.Width)
            {
                if (this.Height != API.CurrentSkin.titlebarheight)
                {
                    secondsleft = secondsleft - 1;
                    if (secondsleft == -1)
                    {
                        secondsleft = 60;
                        level = level + 1;
                        generatenextlevel();
                        pnlgamestats.Show();
                        pnlgamestats.BringToFront();
                        pnlgamestats.Location = new Point((pgcontents.Width / 2) - (pnlgamestats.Width / 2), (pgcontents.Height / 2) - (pnlgamestats.Height / 2));

                        counter.Stop();
                        gameTimer.Stop();
                    }
                    lblstatscodepoints.Text = "Codepoints earned: " + (levelrewards[level - 1] + beatairewardtotal).ToString();
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnplayon_Click(object sender, EventArgs e)
        {
            xveldec = levelxspeed;
            yveldec = levelyspeed;

            secondsleft = 60;

            tmrcountdown.Start();
            lblbeatai.Text = "Get " + beataireward + " codepoints for beating the Computer!";
            pnlgamestats.Hide();
            lblbeatai.Show();
            ball.Location = new Point(paddleHuman.Location.X + paddleHuman.Width + 50, paddleHuman.Location.Y + paddleHuman.Height / 2);
            if (xVel < 0)
                xVel = Math.Abs(xVel);
            lbllevelandtime.Text = "Level: " + level + " - " + secondsleft + " Seconds Left";
        }

        //Increase the ball speed stats for the next level
        private void generatenextlevel()
        {
            lbllevelreached.Text = "You Reached Level " + level + "!";

            lblpreviousstats.Text = "Initial Ball X Speed: " + levelxspeed + Environment.NewLine + "Initial Ball Y Speed: " + levelyspeed + Environment.NewLine + "Increment X Speed: " + incrementx + Environment.NewLine + "Increment Y Speed: " + incrementy;

            switch (rand.Next(1, 3))
            {
                case 1:
                    levelxspeed = levelxspeed + 1;
                    break;
                case 2:
                    levelxspeed = levelxspeed + 2;
                    break;
            }

            switch (rand.Next(1, 3))
            {
                case 1:
                    levelyspeed = levelyspeed + 1;
                    break;
                case 2:
                    levelyspeed = levelyspeed + 2;
                    break;
            }

            switch (rand.Next(1, 6))
            {
                case 1:
                    incrementx = incrementx + 0.1;
                    break;
                case 2:
                    incrementx = incrementx + 0.2;
                    break;
                case 3:
                    incrementy = incrementy + 0.1;
                    break;
                case 4:
                    incrementy = incrementy + 0.2;
                    break;
                case 5:
                    incrementy = incrementy + 0.3;
                    break;
            }

            lblnextstats.Text = "Initial Ball X Speed: " + levelxspeed + Environment.NewLine + "Initial Ball Y Speed: " + levelyspeed + Environment.NewLine + "Increment X Speed: " + incrementx + Environment.NewLine + "Increment Y Speed: " + incrementy;

            if (level < 15)
            {
                beataireward = level * 2;
            }
            else {
                double br = levelrewards[level - 1] / 10;
                beataireward = (int)Math.Round(br);
            }

            totalreward = levelrewards[level - 1] + beatairewardtotal;

            btncashout.Text = "Cash out with " + totalreward.ToString() + " codepoints!";
            btnplayon.Text = "Play on for " + (levelrewards[level] + beatairewardtotal).ToString() + " codepoints!";
        }

        private void setuplevelrewards()
        {
            levelrewards[0] = 0;
            levelrewards[1] = 1;
            levelrewards[2] = 3;
            levelrewards[3] = 7;
            levelrewards[4] = 13;
            levelrewards[5] = 20;
            levelrewards[6] = 30;
            levelrewards[7] = 45;
            levelrewards[8] = 60;
            levelrewards[9] = 80;
            levelrewards[10] = 100;
            levelrewards[11] = 125;
            levelrewards[12] = 150;
            levelrewards[13] = 200;
            levelrewards[14] = 250;
            levelrewards[15] = 300;
            levelrewards[16] = 400;
            levelrewards[17] = 500;
            levelrewards[18] = 650;
            levelrewards[19] = 800;
            levelrewards[20] = 1000;
            levelrewards[21] = 1250;
            levelrewards[22] = 1600;
            levelrewards[23] = 2000;
            levelrewards[24] = 2500;
            levelrewards[25] = 3000;
            levelrewards[26] = 3750;
            levelrewards[27] = 4500;
            levelrewards[28] = 5500;
            levelrewards[29] = 7000;
            levelrewards[30] = 9000;
            levelrewards[31] = 11000;
            levelrewards[32] = 13500;
            levelrewards[33] = 16000;
            levelrewards[34] = 20000;
            levelrewards[35] = 25000;
            levelrewards[36] = 32000;
            levelrewards[37] = 40000;
            levelrewards[38] = 50000;
            levelrewards[39] = 75000;
            levelrewards[40] = 100000;
        }

        // ERROR: Handles clauses are not supported in C#
        private void countdown_Tick(object sender, EventArgs e)
        {
            if (this.Left < Screen.PrimaryScreen.Bounds.Width)
            {
                if (this.Height != API.CurrentSkin.titlebarheight)
                {
                    switch (countdown)
                    {
                        case 0:
                            countdown = 3;
                            lblcountdown.Hide();
                            lblbeatai.Hide();
                            API.PlaySound(Properties.Resources.writesound);
                            gameTimer.Start();
                            counter.Start();
                            tmrcountdown.Stop();
                            break;
                        case 1:
                            lblcountdown.Text = "1";
                            countdown = countdown - 1;
                            API.PlaySound(Properties.Resources.writesound);
                            break;
                        case 2:
                            lblcountdown.Text = "2";
                            countdown = countdown - 1;
                            API.PlaySound(Properties.Resources.writesound);
                            break;
                        case 3:
                            lblcountdown.Text = "3";
                            countdown = countdown - 1;
                            API.PlaySound(Properties.Resources.writesound);
                            lblcountdown.Show();
                            break;
                    }
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btncashout_Click(object sender, EventArgs e)
        {
            pnlgamestats.Hide();
            pnlfinalstats.Show();
            lblfinalcodepointswithtext.Text = "You cashed out with " + totalreward + " codepoints!";
            lblfinallevelreached.Text = "Codepoints rewarded for reaching level " + (level - 1).ToString();
            lblfinallevelreward.Text = levelrewards[level - 1].ToString();
            lblfinalcomputerreward.Text = beatairewardtotal.ToString();
            lblfinalcodepoints.Text = totalreward + " CP";
            API.AddCodepoints(totalreward);
        }

        private void newgame()
        {
            pnlfinalstats.Hide();
            pnllose.Hide();
            pnlintro.Hide();

            level = 1;
            totalreward = 0;
            beataireward = 2;
            beatairewardtotal = 0;
            secondsleft = 60;
            lblstatscodepoints.Text = "Codepoints: ";
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
            lblbeatai.Text = "Get " + beataireward + " codepoints for beating the Computer!";
            pnlgamestats.Hide();
            lblbeatai.Show();
            ball.Location = new Point(paddleHuman.Location.X + paddleHuman.Width + 50, paddleHuman.Location.Y + paddleHuman.Height / 2);
            if (xVel < 0)
                xVel = Math.Abs(xVel);
            lbllevelandtime.Text = "Level: " + level + " - " + secondsleft + " Seconds Left";
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnplayagain_Click(object sender, EventArgs e)
        {
            newgame();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnlosetryagain_Click(object sender, EventArgs e)
        {
            newgame();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnstartgame_Click(object sender, EventArgs e)
        {
            newgame();
        }

        Random rand = new Random();
        // ERROR: Handles clauses are not supported in C#
        private void tmrstoryline_Tick(object sender, EventArgs e)
        {
            // Random chance of showing getshiftnet storyline
            int i = rand.Next(0, 100);

            if (i >= 25 && i <= 50)
            {
                Terminal term = new Terminal();
                API.CreateForm(term, "Terminal", Properties.Resources.iconTerminal);
                term.StartShiftnetStory();
                tmrstoryline.Stop();
            }
            
        }

        // ERROR: Handles clauses are not supported in C#
        private void me_closing(object sender, FormClosingEventArgs e)
        {
            tmrstoryline.Stop();
        }
    }
}
