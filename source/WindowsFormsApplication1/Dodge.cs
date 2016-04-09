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
    public partial class Dodge : Form
    {
        /// <summary>
        /// C# port of Dodge made by william.1008 in ShiftOS 0.0.8.
        /// </summary>
        public Dodge()
        {
            InitializeComponent();
        }

        //the speed the game runs at
        decimal speed;
        //the score/code points the player gets
        int score;
        //user can use mouse or keyboard, mouse by default, chnages to true if key pressed
        bool usingkeys = false;
        //Records the time spent playing, used for codepoints formula
        decimal time = 0;
        //Number or bonus play collects
        int bonusesfound;
        //for smooth keyboard gameplay, 1=left, 2=right, 0=none
        int keyboardinput = 0;
        
        //When quit clicked
        // ERROR: Handles clauses are not supported in C#
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ERROR: Handles clauses are not supported in C#
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyboardinput = 0;
        }

        // ERROR: Handles clauses are not supported in C#
        private void Form1_Load(object sender, EventArgs e)
        {
            player.Visible = false;
            // hide player and score until game starts
            scorelabel.Visible = false;
            DescriptionLabel.Text = "Welcome to Dodge. Dodge is a simple arcade game with one objective: survive the falling objects! Use the arrow or mouse to move the player and avoid as many objects as you can. The longer you survive, the more code point you will be rewarded with. Beware, it gets harder...";
            // set the description text

            //to impliment skinning, simply set the picturebox to the new skinned image.
            //For example:
            //player.Image = Image.FromFile("PATH TO SKINNED IMAGE")
        }

        //When begin click
        // ERROR: Handles clauses are not supported in C#
        private void BeginButton_Click(object sender, EventArgs e)
        {

            //Hide buttons
            BeginButton.Visible = false;
            QuitButton.Visible = false;
            DescriptionLabel.Visible = false;

            player.Visible = true;
            // show the player
            speed = 2;
            // controls speed of game, will increase as game progresses
            scorelabel.Visible = true;
            // show score label
            bonusesfound = 0;

            //Make sure all objects are in the correct position
            object_small.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), 300);
            object_small2.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), 49);
            object_mid.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), 377);
            object_mid2.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), 140);
            object_large.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), 214);
            PicBonus.Location = new Point((int)(Math.Ceiling((decimal)(Rnd()))), -20);

            //Reset time
            time = 0;

            usingkeys = false;

            System.Threading.Thread.Sleep(100);
            // slight delay before game starts (in milliseconds)

            main();
            // start the main game sub

            //sig() 'infobox sigs - COMMENT THIS OUT
        }

        public decimal Rnd()
        {
            return new Random().Next(0, pgcontents.Width);
        }

        public void Form1_keydown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    // detect right key press
                    usingkeys = true;
                    // turn off mouse control
                    keyboardinput = 2;
                    break;
                case Keys.Left:
                    usingkeys = true;
                    keyboardinput = 1;
                    break;
            }

        }

        private bool BlindMode = false;

        private void main()
        {
            if(BlindMode == true)
            {
                object_large.Image = null;
                object_mid.Image = null;
                object_mid2.Image = null;
                object_small.Image = null;
                object_small2.Image = null;
                object_large.BackColor = Color.Black;
                object_mid.BackColor = Color.Black;
                object_mid2.BackColor = Color.Black;
                object_small.BackColor = Color.Black;
                object_small2.BackColor = Color.Black;
            }
            else
            {
                object_large.Image = Properties.Resources.object_large_Image;
                object_mid.Image = null;
                object_mid2.Image = null;
                object_small.Image = null;
                object_small2.Image = null;
                object_large.BackColor = Color.Black;
                object_mid.BackColor = Color.Black;
                object_mid2.BackColor = Color.Black;
                object_small.BackColor = Color.Black;
                object_small2.BackColor = Color.Black;
            }

            clock.Start();
            //the timer restart this sub every tick, making an endless loop between them.

            //score system
            scorelabel.Text = score.ToString();
            score = Convert.ToInt16((speed / 10) + (time / 20) + bonusesfound);

            //Speed increase
            speed = speed + (speed * (decimal)0.001);

            //increase time
            time = time + (decimal)0.05;
            //loops every 0.05 seconds so time increases by 1 every second (have I done the maths correctly?)

            //Make objects fall
            object_large.Location = new Point(object_large.Location.X, object_large.Location.Y + (int)speed);
            object_mid.Location = new Point(object_mid.Location.X, object_mid.Location.Y + (int)speed);
            object_mid2.Location = new Point(object_mid2.Location.X, object_mid2.Location.Y + (int)speed);
            object_small.Location = new Point(object_small.Location.X, object_small.Location.Y + (int)speed);
            object_small2.Location = new Point(object_small2.Location.X, object_small2.Location.Y + (int)speed);

            //mouse controls
            // tests if mouse control is enabled
            if (usingkeys == false)
            {
                player.Location = new Point(MousePosition.X - this.Location.X - (player.Size.Width / 2) - 5, player.Location.Y);
                //sets the x location to that of the mouse
            }

            //keyboard controls
            if (usingkeys == true)
            {
                if (keyboardinput == 1)
                {
                    player.Location = new Point(player.Location.X - ((int)speed * 4), player.Location.Y);
                }
                if (keyboardinput == 2)
                {
                    player.Location = new Point(player.Location.X + ((int)speed * 4), player.Location.Y);
                    // move right
                }
            }

            //move object back to the top of the screen
            if (object_small.Location.Y > 522)
            {
                object_small.Location = new Point((int)(Math.Ceiling((decimal)Rnd())), -20);
                //picks a random number between 0 and 453 (window width) and sets the x position to this value. uses -20 for y as it is above the top of window
            }
            if (object_small2.Location.Y > 522)
            {
                object_small2.Location = new Point((int)(Math.Ceiling((decimal)Rnd())), -20);
            }
            if (object_mid.Location.Y > 522)
            {
                object_mid.Location = new Point((int)(Math.Ceiling(Rnd())), -20);
            }
            if (object_mid2.Location.Y > 522)
            {
                object_mid2.Location = new Point((int)(Math.Ceiling(Rnd())), -20);
            }
            if (object_large.Location.Y > 522)
            {
                object_large.Location = new Point((int)(Math.Ceiling(Rnd())), -20);
            }

            //Makes sure the player is on the screen (Anti-cheating)
            if (player.Location.X > 375)
            {
                player.Location = new Point(385, player.Location.Y);
            }
            if (player.Location.X < 0)
            {
                player.Location = new Point(0, player.Location.Y);
            }

            //Bonus
            if (PicBonus.Visible == false)
            {
                int ran = (int)Math.Ceiling(Rnd() * 300);
                //random 1 in 500 chance
                if (ran == 1)
                {
                    PicBonus.Visible = true;
                }
            }
            else {
                PicBonus.Location = new Point(PicBonus.Location.X, PicBonus.Location.Y + (int)speed);
                if (PicBonus.Location.Y > 522)
                {
                    PicBonus.Location = new Point((int)Math.Ceiling(Rnd()), -20);
                    PicBonus.Visible = false;
                }
            }

            //check collisions
            if (player.Bounds.IntersectsWith(object_mid.Bounds) | player.Bounds.IntersectsWith(object_mid2.Bounds) | player.Bounds.IntersectsWith(object_large.Bounds) | player.Bounds.IntersectsWith(object_small.Bounds) | player.Bounds.IntersectsWith(object_small2.Bounds))
            {
                clock.Stop();
                //breaks loop
                System.Threading.Thread.Sleep(333);
                //delay for a third of a second
                player.Visible = false;
                //hide game
                DescriptionLabel.Text = "Sorry, you just lost the game, however, you earnt a total of " + score + " code points. To earn more code points, press the begin button now. To exit, press the quit button";
                // change the description to the die message
                API.AddCodepoints(score);
                DescriptionLabel.Visible = true;
                //show non-game elements
                BeginButton.Visible = true;
                QuitButton.Visible = true;
                scorelabel.Visible = false;
            }
            if (player.Bounds.IntersectsWith(PicBonus.Bounds))
            {
                PicBonus.Visible = false;
                bonusesfound = bonusesfound + 1;
                PicBonus.Location = new Point((int)(Math.Ceiling(Rnd())), -20);
            }

        }

        // ERROR: Handles clauses are not supported in C#
        private void clock_Tick(object sender, EventArgs e)
        {
            main();
            //repeat the main sub (endless loop)
        }

        private void sig()
        {
            API.CreateInfoboxSession("FLAG", "There is no foul on the play, the punt was blocked.", infobox.InfoboxMode.Info);
        }
    }
}
