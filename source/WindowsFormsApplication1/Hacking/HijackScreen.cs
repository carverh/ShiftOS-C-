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
    public partial class HijackScreen : Form
    {
        public HijackScreen()
        {
            InitializeComponent();
        }


        string rtext;
        string gtexttotype;
        int charcount;
        int currentletter;
        int slashcount;
        int conversationcount = 0;
        Label textgeninput;
        bool needtoclose = false;
        public bool upgraded = false;
        FileStream fs;
        int hackeffect;
        int percentcount;

        // ERROR: Handles clauses are not supported in C#
        private void HijackScreen_Load(object sender, EventArgs e)
        {
            hackeffecttimer.Tick += new EventHandler(hackeffecttimer_Tick);
            conversationtimer.Tick += new EventHandler(conversationtimer_Tick);
            textgen.Tick += new EventHandler(textgen_Tick);

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            BackgroundWorker1.RunWorkerAsync();
            conversationtimer.Start();
            hackeffecttimer.Start();
        }

        private void TextType(string texttotype)
        {
            conversationtimer.Stop();
            charcount = texttotype.Length;
            gtexttotype = texttotype;
            currentletter = 0;
            slashcount = 1;
            textgen.Start();
        }


        // ERROR: Handles clauses are not supported in C#
        private void textgen_Tick(object sender, EventArgs e)
        {
            switch (slashcount)
            {
                case 1:
                    if (currentletter < gtexttotype.Length)
                    {
                        textgeninput.Text = rtext + "\\";
                    }

                    break;
                case 2:
                    if (currentletter < gtexttotype.Length)
                    {
                        textgeninput.Text = rtext + "|";
                    }

                    break;
                case 3:
                    if (currentletter < gtexttotype.Length)
                    {
                        textgeninput.Text = rtext + "/";
                    }

                    break;
                case 4:
                    if (currentletter < gtexttotype.Length)
                    {
                        rtext = rtext + gtexttotype.Substring(currentletter, 1);
                        currentletter = currentletter + 1;
                        textgeninput.Text = rtext;
                        API.PlaySound(Properties.Resources.typesound);
                    }
                    break;
            }

            slashcount = slashcount + 1;

            if (slashcount == 5)
                slashcount = 1;
            if (currentletter == gtexttotype.Length)
            {
                gtexttotype = "";
                conversationtimer.Start();
                textgen.Stop();
            }


        }

        // ERROR: Handles clauses are not supported in C#
        private void conversationtimer_Tick(object sender, EventArgs e)
        {
            switch (conversationcount)
            {
                case 0:
                    if (needtoclose == true)
                        this.Close();
                    break;
                case 1:

                    textgeninput = lblHijack;
                    TextType("Your computer is now being Hijacked");
                    conversationtimer.Interval = 1000;

                    break;
                case 3:
                    textgeninput = lblhackwords;
                    textgen.Interval = 10;
                    rtext = "";
                    btnskip.Show();
                    TextType("Congratulations, you have been involuntarily selected to be an Alpha Tester for ShiftOS." + Environment.NewLine + Environment.NewLine);
                    break;
                case 4:
                    TextType("At this current point in time I do not wish to reveal my identity or future intentions." + Environment.NewLine + Environment.NewLine);
                    break;
                case 5:
                    TextType("I just need to use you and your computer as an external test bed to evolve my experimental operating system." + Environment.NewLine + Environment.NewLine);
                    break;
                case 6:
                    TextType("Right now ShiftOS is practically non-existent but I’ll work on coding it remotely as you use it." + Environment.NewLine + Environment.NewLine);
                    break;
                case 7:
                    TextType("Your hard drive will now be formatted in preparation for the installation of ShiftOS" + Environment.NewLine + Environment.NewLine);
                    break;
                case 8:
                    TextType("Starting Format.");
                    conversationtimer.Interval = 500;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    TextType(".");
                    break;
                case 19:
                    rtext = "";
                    break;
                case 20:
                    TextType("Scanning System Drive...");
                    break;
                case 21:
                    TextType(Environment.NewLine + Environment.NewLine + "Current OS: " + OSInfo.GetPlatformID().Replace("microsoft", "Windows"));
                    break;
                case 22:
                    if(OSInfo.GetPlatformID() == "microsoft")
                    {
                        var dinf = new DriveInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows).Substring(0, 3));
                        TextType(Environment.NewLine + $"Mountpoint and File System: {dinf.Name} ({dinf.DriveFormat})");
                    }
                    break;
                case 23:
                    if (OSInfo.GetPlatformID() == "microsoft")
                    {
                        var dinf = new DriveInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows).Substring(0, 3));
                        TextType(Environment.NewLine + $"Size: {dinf.TotalFreeSpace} free,  {dinf.TotalSize} total");
                    }
                    break;
                case 24:
                    TextType(Environment.NewLine + "New File System: ShiftFS");
                    break;
                case 25:
                    TextType(Environment.NewLine + Environment.NewLine + "Formatting system drive - ");
                    conversationtimer.Interval = 100;
                    break;
                case 26:
                case 28:
                case 30:
                case 32:
                case 36:
                case 38:
                case 40:
                case 42:
                case 44:
                case 46:
                case 48:
                case 50:
                case 52:
                case 54:
                case 56:
                case 58:
                case 60:
                case 62:
                case 64:
                case 66:
                case 68:
                case 70:
                case 72:
                case 74:
                case 76:
                case 78:
                case 80:
                case 82:
                case 84:
                case 86:
                case 88:
                case 90:
                case 92:
                case 94:
                case 96:
                case 98:
                case 100:
                case 102:
                case 104:
                case 106:
                case 108:
                case 110:
                case 112:
                case 114:
                case 116:
                case 118:
                case 120:
                case 122:
                case 124:
                case 126:
                    textgeninput.Text = rtext + percentcount + "%";
                    if (percentcount < 101)
                    {
                        percentcount += 2;
                        API.PlaySound(Properties.Resources.writesound);
                    }
                    break;
                case 127:
                    rtext = rtext + "100%";
                    conversationtimer.Interval = 1000;
                    break;
                case 128:
                    TextType(Environment.NewLine + "Format Complete");
                    break;
                case 129:
                    rtext = "";
                    percentcount = 0;
                    TextType("Installing ShiftOS Alpha 0.0.1 - ");
                    conversationtimer.Interval = 200;
                    break;
                case 130:
                case 131:
                case 132:
                case 133:
                case 134:
                case 135:
                case 136:
                case 137:
                case 138:
                case 139:
                case 140:
                case 141:
                case 142:
                case 143:
                case 144:
                case 145:
                case 146:
                case 147:
                case 148:
                case 149:
                case 150:
                case 151:
                case 152:
                case 153:
                case 154:
                case 155:
                case 156:
                case 157:
                case 158:
                case 159:
                case 160:
                case 161:
                case 162:
                case 163:
                case 164:
                case 165:
                case 166:
                case 167:
                case 168:
                case 169:
                case 170:
                case 171:
                case 172:
                case 173:
                case 174:
                case 175:
                case 176:
                case 177:
                case 178:
                case 179:
                case 180:
                case 181:
                case 182:
                case 183:
                case 184:
                case 185:
                case 186:
                case 187:
                case 188:
                case 189:
                case 190:
                case 191:
                case 192:
                case 193:
                case 194:
                case 195:
                case 196:
                case 197:
                case 198:
                case 199:
                case 200:
                case 201:
                case 202:
                case 203:
                case 204:
                case 205:
                case 206:
                case 207:
                case 208:
                case 209:
                case 210:
                case 211:
                case 212:
                case 213:
                case 214:
                case 215:
                case 216:
                case 217:
                case 218:
                case 219:
                case 220:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 226:
                case 227:
                case 228:
                case 229:
                case 230:

                    textgeninput.Text = rtext + percentcount + "%" + Environment.NewLine + Environment.NewLine;
                    if (percentcount < 101)
                    {
                        percentcount = percentcount + 1;
                        API.PlaySound(Properties.Resources.writesound);
                    }
                    switch (percentcount)
                    {
                        case 1:
                        case 2:
                            textgeninput.Text = textgeninput.Text + "/Home";
                            if ((!System.IO.Directory.Exists(Paths.Home)))
                                System.IO.Directory.CreateDirectory(Paths.Home);
                            break;
                        case 3:
                        case 4:
                            textgeninput.Text = textgeninput.Text + "/Home/Documents";
                            if ((!System.IO.Directory.Exists(Paths.Documents)))
                                System.IO.Directory.CreateDirectory(Paths.Documents);
                            break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            textgeninput.Text = textgeninput.Text + "/Home/Music";
                            if ((!System.IO.Directory.Exists(Paths.Music)))
                                System.IO.Directory.CreateDirectory(Paths.Music);
                            break;
                        case 13:
                        case 14:
                        case 15:
                            textgeninput.Text = textgeninput.Text + "/Home/Pictures";
                            if ((!System.IO.Directory.Exists(Paths.Pictures)))
                                System.IO.Directory.CreateDirectory(Paths.Pictures);
                            break;
                        case 16:
                        case 17:
                        case 18:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42";
                            if ((!System.IO.Directory.Exists(Paths.SystemDir)))
                                System.IO.Directory.CreateDirectory(Paths.SystemDir);
                            break;
                        case 19:
                        case 20:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers";
                            if ((!System.IO.Directory.Exists(Paths.Drivers)))
                                System.IO.Directory.CreateDirectory(Paths.Drivers);
                            break;
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers/HDD.dri";
                            break;
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers/Keyboard.dri";
                            fs = File.Create(Paths.Drivers + "Keyboard.dri");
                            fs.Close();
                            break;
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers/Monitor.dri";
                            fs = File.Create(Paths.Drivers + "Monitor.dri");
                            fs.Close();
                            break;
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers/Mouse.dri";
                            fs = File.Create(Paths.Drivers + "Mouse.dri");
                            fs.Close();
                            break;
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58:
                        case 59:
                        case 60:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Drivers/Printer.dri";
                            fs = File.Create(Paths.Drivers + "Printer.dri");
                            fs.Close();
                            break;
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                        case 67:
                        case 68:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Languages/";
                            if ((!System.IO.Directory.Exists(Paths.SystemDir + "Languages")))
                                System.IO.Directory.CreateDirectory(Paths.SystemDir + "Languages");
                            break;
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 73:
                        case 74:
                        case 75:
                        case 76:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/Languages/Current.lang";
                            fs = File.Create(Paths.SystemDir + "Languages/Current.lang");
                            fs.Close();
                            break;
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/HDAccess.sft";
                            break;
                        case 85:
                        case 86:
                        case 87:
                        case 88:
                        case 89:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/ShiftGUI.sft";
                            fs = File.Create(Paths.SystemDir + "ShiftGUI.sft");
                            fs.Close();
                            break;
                        case 90:
                        case 91:
                        case 92:
                        case 93:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/SKernal.sft";
                            fs = File.Create(Paths.SystemDir + "SKernal.sft");
                            fs.Close();
                            break;
                        case 94:
                        case 95:
                        case 96:
                        case 97:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/SRead.sft";
                            fs = File.Create(Paths.SystemDir + "SRead.sft");
                            fs.Close();
                            break;
                        case 98:
                        case 99:
                        case 100:
                        case 101:
                            textgeninput.Text = textgeninput.Text + "/Shiftum42/SWrite.sft";
                            fs = File.Create(Paths.SystemDir + "SWrite.sft");
                            fs.Close();
                            break;
                    }

                    break;

                case 231:
                    textgeninput.Text = rtext + "100%" + Environment.NewLine + Environment.NewLine + "/Shiftum42/SWrite.sft";
                    conversationtimer.Interval = 1000;
                    API.PlaySound(Properties.Resources.writesound);
                    break;
                case 232:
                    textgeninput.Text = rtext + "100%" + Environment.NewLine + Environment.NewLine + "ShiftOS Installation Complete!";
                    API.PlaySound(Properties.Resources.typesound);
                    if ((!System.IO.Directory.Exists(Paths.SoftwareData)))
                        System.IO.Directory.CreateDirectory(Paths.SoftwareData);
                    if ((!System.IO.Directory.Exists(Paths.KnowledgeInput)))
                        System.IO.Directory.CreateDirectory(Paths.KnowledgeInput);
                    break;
                case 234:
                    SaveSystem.Utilities.LoadedSave.newgame = false;
                    API.CurrentSession.Opacity = 100;
                    Terminal term = new Terminal();
                    term.Show();
                    term.tmrfirstrun.Start();
                    this.Close();

                    break;
            }
            conversationcount = conversationcount + 1;
        }

        // ERROR: Handles clauses are not supported in C#
        private void hackeffecttimer_Tick(object sender, EventArgs e)
        {
            if (hackeffect < 101)
            {
                switch (hackeffect)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                    case 11:
                    case 13:
                    case 15:
                    case 17:
                    case 19:
                    case 21:
                    case 23:
                    case 25:
                    case 27:
                    case 29:
                    case 31:
                    case 33:
                    case 35:
                    case 37:
                    case 39:
                    case 41:
                    case 43:
                    case 45:
                    case 47:
                    case 49:
                    case 51:
                    case 53:
                    case 55:
                    case 57:
                    case 59:
                    case 61:
                    case 63:
                    case 65:
                    case 67:
                    case 69:
                    case 71:
                    case 73:
                    case 75:
                    case 77:
                    case 79:
                    case 81:
                    case 83:
                    case 85:
                    case 87:
                    case 89:
                    case 91:
                    case 93:
                    case 95:
                        this.BackColor = Color.Magenta;
                        this.TransparencyKey = Color.Magenta;
                        API.PlaySound(Properties.Resources.writesound);
                        this.TopMost = true;
                        break;
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                    case 10:
                    case 12:
                    case 14:
                    case 16:
                    case 18:
                    case 20:
                    case 22:
                    case 24:
                    case 26:
                    case 28:
                        this.BackColor = Color.Magenta;
                        API.PlaySound(Properties.Resources.typesound);
                        break;
                    case 30:
                    case 32:
                    case 34:
                    case 36:
                    case 38:
                    case 40:
                    case 42:
                    case 44:
                    case 46:
                    case 48:
                    case 50:
                        this.BackColor = Color.Magenta;
                        API.PlaySound(Properties.Resources.typesound);
                        break;
                    case 52:
                    case 54:
                    case 56:
                    case 58:
                    case 60:
                    case 62:
                    case 64:
                    case 66:
                    case 68:
                    case 70:
                    case 72:
                    case 74:
                    case 76:
                        this.BackColor = Color.Magenta;
                        API.PlaySound(Properties.Resources.typesound);
                       
                        break;
                    case 78:
                    case 80:
                    case 82:
                    case 84:
                    case 86:
                    case 88:
                    case 90:
                    case 92:
                    case 94:
                        this.BackColor = Color.DimGray;
                        API.PlaySound(Properties.Resources.typesound);
                        
                        break;
                    case 96:
                        lblHijack.BackColor = Color.LightGray;
                        break;
                    case 97:
                        lblHijack.BackColor = Color.DarkGray;
                        break;
                    case 98:
                        lblHijack.BackColor = Color.DimGray;
                        break;
                    case 99:
                        this.BackColor = Color.Black;
                        lblHijack.BackColor = Color.Black;
                        lblHijack.ForeColor = Color.DimGray;
                        break;
                    case 100:
                        lblHijack.Hide();
                        break;
                }
            }
            else {
                hackeffecttimer.Stop();
            }
            hackeffect = hackeffect + 1;
        }

        private void btnskip_Click(object sender, EventArgs e)
        {
            conversationcount = 19;
            btnskip.Hide();
        }
    }
}
