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
    public partial class TextPad : Form
    {
        private bool codepointscooldown = false;
        private int codepointsearned = 0;
        private bool needtosave = false;
                
        public TextPad()
        {
            InitializeComponent();
        }

        private void TextPad_Load(object sender, EventArgs e)
        {
            txtuserinput.Size = new Size(txtuserinput.Size.Width, txtuserinput.Size.Height + pnloptions.Height);
            setupoptions();
        }

        // ERROR: Handles clauses are not supported in C#
        private void pnlbreak_MouseEnter(object sender, EventArgs e)
        {
            if (pnloptions.Visible == false)
            {
                pnlbreak.BackgroundImage = Properties.Resources.downarrow;
                pnloptions.Show();
                txtuserinput.Size = new Size(txtuserinput.Size.Width, txtuserinput.Size.Height - pnloptions.Height);
            }
            else {
                pnlbreak.BackgroundImage = Properties.Resources.uparrow;
                pnloptions.Hide();
                txtuserinput.Size = new Size(txtuserinput.Size.Width, txtuserinput.Size.Height + pnloptions.Height);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnnew_Click(object sender, EventArgs e)
        {
            if (needtosave == true)
            {
                API.CreateInfoboxSession("Textpad - Save?", "It appears that your text document currently contains unsaved changes." + Environment.NewLine + Environment.NewLine + "Are you sure you want to start a new document without saving the changes?", infobox.InfoboxMode.YesNo);
                API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                {
                    string result = API.GetInfoboxResult();
                    switch(result)
                    {
                        case "Yes":
                            codepointsearned = 0;
                            this.txtuserinput.Text = "";
                            break;
                        case "No":
                            SaveFile();
                            break;
                    }
                };
            }
            else {
                makenewdoc();
            }
        }

        private void SaveFile()
        {
            if (API.Upgrades["trmfiles"] == true)
            {
                API.CreateFileSkimmerSession(".txt;.trm", File_Skimmer.FileSkimmerMode.Save);

            }
            else
            {
                API.CreateFileSkimmerSession(".txt", File_Skimmer.FileSkimmerMode.Save);
            }
            API.FileSkimmerSession.FormClosing += (object se, FormClosingEventArgs ea) =>
            {
                string res = API.GetFSResult();
                if (res != "fail")
                {
                    File.WriteAllText(res, txtuserinput.Text);
                }
            };
        }

        private void SaveFile(string text)
        {
            if (API.Upgrades["trmfiles"] == true)
            {
                API.CreateFileSkimmerSession(".txt;.trm", File_Skimmer.FileSkimmerMode.Save);

            }
            else
            {
                API.CreateFileSkimmerSession(".txt", File_Skimmer.FileSkimmerMode.Save);
            }
            API.FileSkimmerSession.FormClosing += (object se, FormClosingEventArgs ea) =>
            {
                string res = API.GetFSResult();
                if (res != "fail")
                {
                    File.WriteAllText(res, text);
                }
            };
        }

        public void makenewdoc()
        {
            txtuserinput.Text = "";
            needtosave = false;
            codepointsearned = 0;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnopen_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".txt", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                if (needtosave == true)
                {
                    API.CreateInfoboxSession("Textpad - Save?", "It appears that your text document currently contains unsaved changes." + Environment.NewLine + Environment.NewLine + "Are you sure you want to start a new document without saving the changes?", infobox.InfoboxMode.YesNo);
                    API.InfoboxSession.FormClosing += (object se, FormClosingEventArgs ea) =>
                    {
                        string result = API.GetInfoboxResult();
                        switch (result)
                        {
                            case "Yes":
                                codepointsearned = 0;
                                string res = API.GetFSResult();
                                if (res != "fail")
                                {
                                    string fContents = File.ReadAllText(res);

                                    txtuserinput.Text = fContents;
                                }
                                break;
                            case "No":
                                string fcontents = txtuserinput.Text;
                                SaveFile(fcontents);
                                string res2 = API.GetFSResult();
                                if (res2 != "fail")
                                {
                                    string fContents = File.ReadAllText(res2);
                                    
                                    txtuserinput.Text = fContents;
                                }
                                break;
                        }
                    };
                }
                else {
                    string res = API.GetFSResult();
                    if (res != "fail")
                    {
                        try {
                            string fContents = File.ReadAllText(res);

                            txtuserinput.Text = fContents;
                        }
                        catch(Exception ex)
                        {
                            txtuserinput.Text = ex.Message;
                        }
                    }
                }
            };
        }

        public void setupoptions()
        {
            if (API.Upgrades["textpadnew"] == true)
                btnnew.Show();
            else
                btnnew.Hide();
            if (API.Upgrades["textpadopen"] == true)
                btnopen.Show();
            else
                btnopen.Hide();
            if (API.Upgrades["textpadsave"] == true)
                btnsave.Show();
            else
                btnsave.Hide();
            if (API.Upgrades["textpadnew"] == false && API.Upgrades["textpadsave"] == false && API.Upgrades["textpadopen"] == false)
                pnlbreak.Hide();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtuserinput_TextChanged(object sender, EventArgs e)
        {
            needtosave = true;
            if (codepointscooldown == true)
            {
            }
            else {
                codepointsearned = codepointsearned + 1;
                codepointscooldown = true;
                tmrcodepointcooldown.Start();
            }
            if (Viruses.InfectedWith("keyboardfucker"))
            {
                var rnd = new Random();
                if (rnd.Next(0, 20) == 10)
                {
                    txtuserinput.Text += Viruses.KeyboardInceptor.Intercept();
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrcodepointcooldown_Tick(object sender, EventArgs e)
        {
            codepointscooldown = false;
            tmrcodepointcooldown.Stop();
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrshowearnedcodepoints_Tick(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("TextPad", "You have earned " + codepointsearned.ToString() + " Codepoints from typing up and saving that document!", infobox.InfoboxMode.Info);
            API.AddCodepoints(codepointsearned);
            tmrshowearnedcodepoints.Stop();
        }
    }
}
