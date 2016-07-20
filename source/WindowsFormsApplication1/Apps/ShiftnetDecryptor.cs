using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class ShiftnetDecryptor : Form
    {
        public ShiftnetDecryptor()
        {
            InitializeComponent();
        }

        int i = 0;
        string currentaddress = null;
        string encrypted_contents = null;

        public void WriteLine(string line)
        {
            if(txtstatus.Text == "")
            {
                txtstatus.Text = line;
            }
            else
            {
                txtstatus.Text += Environment.NewLine + line;
            }
        }

        private void RecursiveWidgetSetup(Widget ctrl)
        {
            ctrl.Font = new Font(OSInfo.GetMonospaceFont(), ctrl.Font.Size);
            try
            {
                var pnl = (Panel)ctrl;
                foreach (Widget c in pnl.Widgets)
                {
                    RecursiveWidgetSetup(c);
                }
            }
            catch 
            {

            }
        }

        private void tmrdecrypt_Tick(object sender, EventArgs e)
        {
            switch (i)
            {
                case 0:
                    currentaddress = txtaddress.Text;
                    WriteLine("Checking URL...");
                    if(!currentaddress.StartsWith("shiftnet://"))
                    {
                        WriteLine(" *** ERROR: Invalid URL.");
                        tmrdecrypt.Stop();
                        btnstart.Enabled = true;
                        txtaddress.Enabled = true;
                    }
                    break;
                case 5:
                    WriteLine("Making connection to Shiftnet...");
                    currentaddress = currentaddress.Replace("shiftnet://", "http://playshiftos.ml/shiftnet/www/");
                    break;
                case 25:
                    WriteLine("Checking file...");
                    if(!currentaddress.EndsWith(".enc"))
                    {
                        WriteLine(" *** ERROR: File not valid, must be of type .enc (encrypted file)");
                        tmrdecrypt.Stop();
                        btnstart.Enabled = true;
                        txtaddress.Enabled = true;
                    }
                    break;
                case 27:
                    WriteLine("Downloading file contents...");
                    try
                    {
                        encrypted_contents = new WebClient().DownloadString(currentaddress);
                    }
                    catch
                    {
                        WriteLine(" *** ERROR: Remote file could not be accessed.");
                        tmrdecrypt.Stop();
                        btnstart.Enabled = true;
                        txtaddress.Enabled = true;
                    }
                    break;
                case 30:
                    WriteLine("Download successful. Determining encryption algorithm. This may take a bit...");
                    break;
                case 75:
                    int r = new Random().Next(0, 100);
                    if(r >= 25 && r <= 75)
                    {
                        WriteLine("Encryption algorithm determined, beginning decryption.");
                    }
                    else
                    {
                        WriteLine("Decryption failed.");
                        tmrdecrypt.Stop();
                        btnstart.Enabled = true;
                        txtaddress.Enabled = true;
                    }
                    break;
                case 95:
                    string decrypted = API.Encryption.Decrypt(encrypted_contents);
                    int lastslash = currentaddress.LastIndexOf("/");
                    int len = currentaddress.Length - lastslash;
                    string fname = currentaddress.Substring(lastslash, len).Replace(".enc", ".lua");
                    WriteLine("Decryption successful. Saving to /Home/Decryptions/" + fname + "...");
                    if(!Directory.Exists(Paths.Home + "Decryptions"))
                    {
                        Directory.CreateDirectory(Paths.Home + "Decryptions");
                    }
                    File.WriteAllText(Paths.Home + $"Decryptions{OSInfo.DirectorySeparator}{fname}", decrypted);
                    break;
                case 100:
                    WriteLine("Decryption successful.");
                    tmrdecrypt.Stop();
                    currentaddress = null;
                    i = 0;
                    encrypted_contents = null;
                    btnstart.Enabled = true;
                    txtaddress.Enabled = true;

                    break;
            }

            i += 1;
            pgstatus.Value = i;
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            i = 0;
            tmrdecrypt.Start();
            btnstart.Enabled = false;
            txtaddress.Enabled = false;
        }

        private void ShiftnetDecryptor_Load(object sender, EventArgs e)
        {
            RecursiveWidgetSetup(panel1);
        }
    }
}
