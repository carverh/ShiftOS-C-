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
    public partial class KnowledgeInput : Form
    {
        public KnowledgeInput()
        {
            InitializeComponent();
        }

        public int rolldownsize;
        public int oldbordersize;
        public int oldtitlebarheight;
        public bool justopened = false;
        public bool needtorollback = false;
        public int minimumsizewidth = 0;
        public int minimumsizeheight = 0;

        bool guessalreadydone;
        bool guesscorrect;
        bool levelup;
        int rewardbase;

        string[] savecontent;
        int totalguessed;
        int level;

        int tillnextlevel;
        string[] animalslist = new string[227];
        string[] fruitslist = new string[76];
        string[] countrieslist = new string[205];
        string[] carbrandslist = new string[329];
        string[] gameconsoleslist = new string[125];

        string[] elementslist = new string[118];

        // ERROR: Handles clauses are not supported in C#
        private void Template_Load(object sender, EventArgs e)
        {
            justopened = true;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            pnlintro.Show();
            pnlintro.BringToFront();
            pnlcategorydisplay.Hide();
            makeanimallist();
            makecarbrandslist();
            makecountrieslist();
            makeelementslist();
            makefruitlist();
            makegameconsoleslist();
            setupcategories();
            if(!Directory.Exists(Paths.KnowledgeInput))
            {
                Directory.CreateDirectory(Paths.KnowledgeInput);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            using (SolidBrush b = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items[e.Index]), e.Font, b, e.Bounds, sf);
            }
            e.DrawFocusRectangle();
        }

        // ERROR: Handles clauses are not supported in C#
        private void listblistedstuff_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }

            using (SolidBrush b = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(listblistedstuff.GetItemText(listblistedstuff.Items[e.Index]), e.Font, b, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void setupcategories()
        {
            ListBox1.Items.Clear();
            ListBox1.Items.Add("Animals");
            ListBox1.Items.Add("Fruits");
            ListBox1.Items.Add("Countries");
            if(API.Upgrades["kielements"])
            {
                ListBox1.Items.Add("Elements");
            }
            if (API.Upgrades["kicarbrands"])
            {
                ListBox1.Items.Add("Car Brands");
            }
            if (API.Upgrades["kigameconsoles"])
            {
                ListBox1.Items.Add("Game Consoles");
            }

        }

        // ERROR: Handles clauses are not supported in C#
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            pnlcategorydisplay.Show();
            //Remember to create the files for each category in the hijack screen and add the category in the design view and make the countries list in this load event
            switch (ListBox1.SelectedItem.ToString())
            {
                case "Animals":
                    loadsavepoint("Animals", 10, Paths.KnowledgeInput + "Animals.lst", "There are many animals out there! Can you list them all?" + Environment.NewLine + "Note that you get points for listing animals... not animal breeds!", animalslist);

                    break;
                case "Fruits":
                    loadsavepoint("Fruits", 10, Paths.KnowledgeInput + "Fruits.lst", "Do you get your daily serving of fruit each day?" + Environment.NewLine + "Really...? See if you can list them then ;)", fruitslist);

                    break;
                case "Countries":
                    loadsavepoint("Countries", 10, Paths.KnowledgeInput + "Countries.lst", "Ever wanted to travel the entire world?" + Environment.NewLine + "Well before you do see if you can list every country in the world!", countrieslist);

                    break;
                case "Car Brands":
                    loadsavepoint("Car Brands", 10, Paths.KnowledgeInput + "Car Brands.lst", "Can you list every single car brand?" + Environment.NewLine + "Don't use words like automobiles, motors or cars!", carbrandslist);

                    break;
                case "Game Consoles":
                    loadsavepoint("Game Consoles", 10, Paths.KnowledgeInput + "Game Consoles.lst", "Do you call yourself a gamer?" + Environment.NewLine + "Earn that title by listing non-handheld game consoles!", gameconsoleslist);

                    break;
                case "Elements":
                    loadsavepoint("Elements", 10, Paths.KnowledgeInput + "Elements.lst", "Have you memorized the periodic table of elements?" + Environment.NewLine + "No? Well don't even attempt trying to guess them all here!", elementslist);
                    break;
            }

        }


        private void handleword()
        {
            switch (ListBox1.SelectedItem.ToString())
            {
                case "Animals":
                    handlewordtype(animalslist, Paths.KnowledgeInput + "Animals.lst");
                    break;
                case "Fruits":
                    handlewordtype(fruitslist, Paths.KnowledgeInput + "Fruits.lst");
                    break;
                case "Countries":
                    handlewordtype(countrieslist, Paths.KnowledgeInput + "Countries.lst");
                    break;
                case "Car Brands":
                    handlewordtype(carbrandslist, Paths.KnowledgeInput + "Car Brands.lst");
                    break;
                case "Game Consoles":
                    handlewordtype(gameconsoleslist, Paths.KnowledgeInput + "Game Consoles.lst");
                    break;
                case "Elements":
                    handlewordtype(elementslist, Paths.KnowledgeInput + "Elements.lst");
                    break;
            }

            guessbox.Text = "";
            listblistedstuff.TopIndex = listblistedstuff.Items.Count - 1;
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnstart_Click(object sender, EventArgs e)
        {
            handleword();
        }

        // ERROR: Handles clauses are not supported in C#
        private void guessbox_click(object sender, EventArgs e)
        {
            guessbox.Text = "";
        }

        // ERROR: Handles clauses are not supported in C#
        private void guessbox_keydown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                handleword();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void decider_Tick(object sender, EventArgs e)
        {
            lblcurrentlevel.Text = "Current Level: " + level;
            lblnextreward.Text = "Reward for completing level " + level + " : " + rewardbase * level + "CP";
            guessalreadydone = false;
            guesscorrect = false;
            levelup = false;
            decider.Interval = 500;
            decider.Stop();
        }

        private void loadsavepoint(string title, int reward, string loadpath, string info, string[] listtype)
        {
            lblcategory.Text = title;
            rewardbase = reward;
            listblistedstuff.Items.Clear();
            if (File.Exists(loadpath))
            {
                listblistedstuff.Items.AddRange(File.ReadAllLines(loadpath));
            }
            totalguessed = listblistedstuff.Items.Count;
            level = (int)Math.Ceiling((double)(totalguessed / 10));
            tillnextlevel = Math.Abs(totalguessed - (level * 10));

            if (tillnextlevel == 0)
            {
                level = level + 1;
                tillnextlevel = 10;
            }

            lblcatedescription.Text = info;
            pnlcategorydisplay.Show();
            lbltillnextlevel.Text = "Words Until Next Level: " + tillnextlevel;
            lblcurrentlevel.Text = "Current Level: " + level;
            lbltotal.Text = "Guessed: " + totalguessed + "/" + listtype.Length;
            lblnextreward.Text = "Reward for completing level " + level + " : " + rewardbase * level + "CP";
        }


        private void handlewordtype(string[] listtype, string savepath)
        {
            string userguess = guessbox.Text;
            userguess = userguess.ToLower();
            foreach (string Str in listtype)
            {
                if (Str == userguess)
                {
                    if (listblistedstuff.Items.Contains(userguess))
                    {
                        guessalreadydone = true;
                    }
                    else {
                        guesscorrect = true;
                        listblistedstuff.Items.Add(userguess);
                        tillnextlevel = tillnextlevel - 1;
                        totalguessed = totalguessed + 1;
                        File.WriteAllLines(savepath, listblistedstuff.Items.Cast<string>().ToArray());

                        if (tillnextlevel == 0)
                        {
                            levelup = true;
                            tillnextlevel = 10;
                            API.AddCodepoints(rewardbase * level);
                            level = level + 1;
                        }
                    }
                }
            }
            lbltillnextlevel.Text = "Words Until Next Level: " + tillnextlevel;
            lblcurrentlevel.Text = "Current Level: " + level;
            lbltotal.Text = "Guessed: " + totalguessed + "/" + listtype.Length;
            lblnextreward.Text = "Reward for completing level " + level + " : " + rewardbase * level + "CP";

            if (levelup == true)
            {
                decider.Interval = 2000;
                lblcurrentlevel.Text = "Level Up!";
                lblnextreward.Text = "You have earned " + rewardbase * (level - 1) + " Code Points!";
                decider.Start();
            }
            else {
                if (guessalreadydone == true)
                {
                    lblcurrentlevel.Text = "Already Guessed";
                    decider.Start();
                }
                else {
                    if (guesscorrect == true)
                    {
                        lblcurrentlevel.Text = "Correct :)";
                        decider.Start();
                    }
                    else {
                        lblcurrentlevel.Text = "Wrong :(";
                        decider.Start();
                    }
                }
            }
        }

        int chance = 101;
        // ERROR: Handles clauses are not supported in C#
        
        // ERROR: Handles clauses are not supported in C#
        private void me_closing()
        {
            tmrstoryline.Stop();
        }

        private void makeanimallist()
        {
            animalslist[0] = "aardvark";
            animalslist[1] = "albatross";
            animalslist[2] = "alligator";
            animalslist[3] = "alpaca";
            animalslist[4] = "ant";
            animalslist[5] = "anteater";
            animalslist[6] = "antelope";
            animalslist[7] = "ape";
            animalslist[8] = "armadillo";
            animalslist[9] = "ass";
            animalslist[10] = "baboon";
            animalslist[11] = "badger";
            animalslist[12] = "barracuda";
            animalslist[13] = "bat";
            animalslist[14] = "bear";
            animalslist[15] = "beaver";
            animalslist[16] = "bee";
            animalslist[17] = "bison";
            animalslist[18] = "boar";
            animalslist[19] = "buffalo";
            animalslist[20] = "butterfly";
            animalslist[21] = "camel";
            animalslist[22] = "caribou";
            animalslist[23] = "cat";
            animalslist[24] = "caterpillar";
            animalslist[25] = "cow";
            animalslist[26] = "chamois";
            animalslist[27] = "cheetah";
            animalslist[28] = "chicken";
            animalslist[29] = "chimpanzee";
            animalslist[30] = "chinchilla";
            animalslist[31] = "chough";
            animalslist[32] = "clam";
            animalslist[33] = "cobra";
            animalslist[34] = "cockroach";
            animalslist[35] = "cod";
            animalslist[36] = "cormorant";
            animalslist[37] = "coyote";
            animalslist[38] = "crab";
            animalslist[39] = "crane";
            animalslist[40] = "crocodile";
            animalslist[41] = "crow";
            animalslist[42] = "curlew";
            animalslist[43] = "deer";
            animalslist[44] = "dinosaur";
            animalslist[45] = "dog";
            animalslist[46] = "dogfish";
            animalslist[47] = "dolphin";
            animalslist[48] = "donkey";
            animalslist[49] = "dotterel";
            animalslist[50] = "dove";
            animalslist[51] = "dragonfly";
            animalslist[52] = "duck";
            animalslist[53] = "dugong";
            animalslist[54] = "dunlin";
            animalslist[55] = "eagle";
            animalslist[56] = "echidna";
            animalslist[57] = "eel";
            animalslist[58] = "eland";
            animalslist[59] = "elephant";
            animalslist[60] = "elephant seal";
            animalslist[61] = "elk";
            animalslist[62] = "emu";
            animalslist[63] = "falcon";
            animalslist[64] = "ferret";
            animalslist[65] = "finch";
            animalslist[66] = "fish";
            animalslist[67] = "flamingo";
            animalslist[68] = "fly";
            animalslist[69] = "fox";
            animalslist[70] = "frog";
            animalslist[71] = "galago";
            animalslist[72] = "gaur";
            animalslist[73] = "gazelle";
            animalslist[74] = "gerbil";
            animalslist[75] = "giant panda";
            animalslist[76] = "giraffe";
            animalslist[77] = "gnat";
            animalslist[78] = "gnu";
            animalslist[79] = "goat";
            animalslist[80] = "goldfinch";
            animalslist[81] = "goldfish";
            animalslist[82] = "goose";
            animalslist[83] = "gorilla";
            animalslist[84] = "goshawk";
            animalslist[85] = "grasshopper";
            animalslist[86] = "grouse";
            animalslist[87] = "guanaco";
            animalslist[88] = "guineafowl";
            animalslist[89] = "guinea pig";
            animalslist[90] = "gull";
            animalslist[91] = "hamster";
            animalslist[92] = "hare";
            animalslist[93] = "hawk";
            animalslist[94] = "hedgehog";
            animalslist[95] = "heron";
            animalslist[96] = "herring";
            animalslist[97] = "hippopotamus";
            animalslist[98] = "hornet";
            animalslist[99] = "horse";
            animalslist[100] = "human";
            animalslist[101] = "humming bird";
            animalslist[102] = "hyena";
            animalslist[103] = "jackal";
            animalslist[104] = "jaguar";
            animalslist[105] = "jay";
            animalslist[106] = "jellyfish";
            animalslist[107] = "kangaroo";
            animalslist[108] = "koala";
            animalslist[109] = "komodo dragon";
            animalslist[110] = "kouprey";
            animalslist[111] = "kudu";
            animalslist[112] = "lizard";
            animalslist[113] = "lark";
            animalslist[114] = "lemur";
            animalslist[115] = "leopard";
            animalslist[116] = "lion";
            animalslist[117] = "llama";
            animalslist[118] = "lobster";
            animalslist[119] = "locust";
            animalslist[120] = "loris";
            animalslist[121] = "louse";
            animalslist[122] = "lyrebird";
            animalslist[123] = "magpie";
            animalslist[124] = "mallard";
            animalslist[125] = "manatee";
            animalslist[126] = "marten";
            animalslist[127] = "meerkat";
            animalslist[128] = "mink";
            animalslist[129] = "mole";
            animalslist[130] = "monkey";
            animalslist[131] = "moose";
            animalslist[132] = "mosquito";
            animalslist[133] = "mouse";
            animalslist[134] = "mule";
            animalslist[135] = "narwhal";
            animalslist[136] = "newt";
            animalslist[137] = "nightingale";
            animalslist[138] = "octopus";
            animalslist[139] = "okapi";
            animalslist[140] = "opossum";
            animalslist[141] = "oryx";
            animalslist[142] = "ostrich";
            animalslist[143] = "otter";
            animalslist[144] = "owl";
            animalslist[145] = "ox";
            animalslist[146] = "oyster";
            animalslist[147] = "panther";
            animalslist[148] = "parrot";
            animalslist[149] = "partridge";
            animalslist[150] = "peafowl";
            animalslist[151] = "pelican";
            animalslist[152] = "penguin";
            animalslist[153] = "pheasant";
            animalslist[154] = "pig";
            animalslist[155] = "pigeon";
            animalslist[156] = "pony";
            animalslist[157] = "porcupine";
            animalslist[158] = "porpoise";
            animalslist[159] = "prairie dog";
            animalslist[160] = "quail";
            animalslist[161] = "quelea";
            animalslist[162] = "rabbit";
            animalslist[163] = "raccoon";
            animalslist[164] = "rail";
            animalslist[165] = "ram";
            animalslist[166] = "rat";
            animalslist[167] = "raven";
            animalslist[168] = "red deer";
            animalslist[169] = "red panda";
            animalslist[170] = "reindeer";
            animalslist[171] = "rhinoceros";
            animalslist[172] = "rook";
            animalslist[173] = "ruff";
            animalslist[174] = "salamander";
            animalslist[175] = "salmon";
            animalslist[176] = "sand dollar";
            animalslist[177] = "sandpiper";
            animalslist[178] = "sardine";
            animalslist[179] = "scorpion";
            animalslist[180] = "sea lion";
            animalslist[181] = "sea urchin";
            animalslist[182] = "seahorse";
            animalslist[183] = "seal";
            animalslist[184] = "shark";
            animalslist[185] = "sheep";
            animalslist[186] = "shrew";
            animalslist[187] = "shrimp";
            animalslist[188] = "skunk";
            animalslist[189] = "snail";
            animalslist[190] = "snake";
            animalslist[191] = "spider";
            animalslist[192] = "squid";
            animalslist[193] = "squirrel";
            animalslist[194] = "starling";
            animalslist[195] = "stingray";
            animalslist[196] = "stink bug";
            animalslist[197] = "stork";
            animalslist[198] = "swallow";
            animalslist[199] = "swan";
            animalslist[200] = "tapir";
            animalslist[201] = "tarsier";
            animalslist[202] = "termite";
            animalslist[203] = "tiger";
            animalslist[204] = "toad";
            animalslist[205] = "trout";
            animalslist[206] = "turkey";
            animalslist[207] = "turtle";
            animalslist[208] = "vicuña";
            animalslist[209] = "viper";
            animalslist[210] = "vulture";
            animalslist[211] = "wallaby";
            animalslist[212] = "walrus";
            animalslist[213] = "wasp";
            animalslist[214] = "water buffalo";
            animalslist[215] = "weasel";
            animalslist[216] = "whale";
            animalslist[217] = "wolf";
            animalslist[218] = "wolverine";
            animalslist[219] = "wombat";
            animalslist[220] = "woodcock";
            animalslist[221] = "woodpecker";
            animalslist[222] = "worm";
            animalslist[223] = "wren";
            animalslist[224] = "yak";
            animalslist[225] = "zebra";
            animalslist[226] = "bird";
        }

        private void makefruitlist()
        {
            fruitslist[0] = "apple";
            fruitslist[1] = "apricot";
            fruitslist[2] = "avocado";
            fruitslist[3] = "banana";
            fruitslist[4] = "breadfruit";
            fruitslist[5] = "bilberry";
            fruitslist[6] = "blackberry";
            fruitslist[7] = "blackcurrant";
            fruitslist[8] = "blueberry";
            fruitslist[9] = "boysenberry";
            fruitslist[10] = "cantaloupe";
            fruitslist[11] = "currant";
            fruitslist[12] = "cherry";
            fruitslist[13] = "cherimoya";
            fruitslist[14] = "chili";
            fruitslist[15] = "cloudberry";
            fruitslist[16] = "coconut";
            fruitslist[17] = "damson";
            fruitslist[18] = "date";
            fruitslist[19] = "dragonfruit";
            fruitslist[20] = "durian";
            fruitslist[21] = "elderberry";
            fruitslist[22] = "feijoa";
            fruitslist[23] = "fig";
            fruitslist[24] = "gooseberry";
            fruitslist[25] = "grape";
            fruitslist[26] = "grapefruit";
            fruitslist[27] = "guava";
            fruitslist[28] = "huckleberry";
            fruitslist[29] = "honeydew";
            fruitslist[30] = "jackfruit";
            fruitslist[31] = "jambul";
            fruitslist[32] = "jujube";
            fruitslist[33] = "kiwi fruit";
            fruitslist[34] = "kumquat";
            fruitslist[35] = "legume";
            fruitslist[36] = "lemon";
            fruitslist[37] = "lime";
            fruitslist[38] = "loquat";
            fruitslist[39] = "lychee";
            fruitslist[40] = "mango";
            fruitslist[41] = "melon";
            fruitslist[42] = "canary melon";
            fruitslist[43] = "cantaloupe";
            fruitslist[44] = "honeydew";
            fruitslist[45] = "watermelon";
            fruitslist[46] = "rock melon";
            fruitslist[47] = "nectarine";
            fruitslist[48] = "nut";
            fruitslist[49] = "orange";
            fruitslist[50] = "clementine";
            fruitslist[51] = "mandarine";
            fruitslist[52] = "tangerine";
            fruitslist[53] = "papaya";
            fruitslist[54] = "passionfruit";
            fruitslist[55] = "peach";
            fruitslist[56] = "bell pepper";
            fruitslist[57] = "pear";
            fruitslist[58] = "persimmon";
            fruitslist[59] = "physalis";
            fruitslist[60] = "plum";
            fruitslist[61] = "pineapple";
            fruitslist[62] = "pomegranate";
            fruitslist[63] = "pomelo";
            fruitslist[64] = "purple mangosteen";
            fruitslist[65] = "quince";
            fruitslist[66] = "raspberry";
            fruitslist[67] = "rambutan";
            fruitslist[68] = "redcurrant";
            fruitslist[69] = "salal berry";
            fruitslist[70] = "satsuma";
            fruitslist[71] = "star fruit";
            fruitslist[72] = "strawberry";
            fruitslist[73] = "tamarillo";
            fruitslist[74] = "tomato";
            fruitslist[75] = "ugli fruit";
        }

        //Based off United Nations member list with additions such as Vatican City - see this video about what a coutry is: https://www.youtube.com/watch?v=4AivEQmfPpk
        private void makecountrieslist()
        {
            countrieslist[0] = "afghanistan";
            countrieslist[1] = "albania";
            countrieslist[2] = "algeria";
            countrieslist[3] = "antigua and barbuda";
            countrieslist[4] = "andorra";
            countrieslist[5] = "angola";
            countrieslist[8] = "argentina";
            countrieslist[9] = "armenia";
            countrieslist[10] = "australia";
            countrieslist[12] = "austria";
            countrieslist[14] = "azerbaijan";
            countrieslist[15] = "bahamas";
            countrieslist[16] = "bahrain";
            countrieslist[17] = "bangladesh";
            countrieslist[18] = "barbados";
            countrieslist[19] = "belarus";
            countrieslist[20] = "belgium";
            countrieslist[21] = "belize";
            countrieslist[22] = "benin";
            countrieslist[23] = "bhutan";
            countrieslist[24] = "bolivia";
            countrieslist[25] = "bosnia";
            countrieslist[26] = "botswana";
            countrieslist[27] = "brunei darussalam";
            countrieslist[28] = "brazil";
            countrieslist[29] = "cabo verde";
            countrieslist[30] = "bulgaria";
            countrieslist[31] = "burkina faso";
            countrieslist[32] = "burundi";
            countrieslist[33] = "cambodia";
            countrieslist[34] = "cameroon";
            countrieslist[35] = "canada";
            countrieslist[36] = "central african republic";
            countrieslist[37] = "chad";
            countrieslist[38] = "chile";
            countrieslist[39] = "china";
            countrieslist[40] = "democratic people's republic of korea";
            countrieslist[41] = "colombia";
            countrieslist[42] = "comoros";
            countrieslist[43] = "congo";
            countrieslist[44] = "côte d'ivoire";
            countrieslist[45] = "cook islands";
            countrieslist[46] = "costa rica";
            countrieslist[47] = "croatia";
            countrieslist[48] = "cuba";
            countrieslist[49] = "cyprus";
            countrieslist[50] = "czech republic";
            countrieslist[51] = "denmark";
            countrieslist[52] = "djibouti";
            countrieslist[53] = "dominica";
            countrieslist[54] = "dominican republic";
            countrieslist[55] = "ecuador";
            countrieslist[56] = "egypt";
            countrieslist[57] = "el salvador";
            countrieslist[58] = "equatorial guinea";
            countrieslist[59] = "eritrea";
            countrieslist[60] = "estonia";
            countrieslist[62] = "ethiopia";
            countrieslist[63] = "fiji";
            countrieslist[64] = "finland";
            countrieslist[65] = "france";
            countrieslist[66] = "gabon";
            countrieslist[67] = "gambia";
            countrieslist[68] = "georgia";
            countrieslist[69] = "germany";
            countrieslist[70] = "ghana";
            countrieslist[71] = "greece";
            countrieslist[72] = "greenland";
            countrieslist[73] = "grenada";
            countrieslist[74] = "guatemala";
            countrieslist[75] = "guinea";
            countrieslist[76] = "guinea bissau";
            countrieslist[77] = "guyana";
            countrieslist[78] = "haiti";
            countrieslist[79] = "vatican city";
            countrieslist[80] = "honduras";
            countrieslist[81] = "hungary";
            countrieslist[82] = "iceland";
            countrieslist[83] = "india";
            countrieslist[84] = "indonesia";
            countrieslist[85] = "iran";
            countrieslist[86] = "iraq";
            countrieslist[87] = "ireland";
            countrieslist[88] = "israel";
            countrieslist[89] = "italy";
            countrieslist[90] = "jamaica";
            countrieslist[91] = "japan";
            countrieslist[92] = "jordan";
            countrieslist[93] = "kazakhstan";
            countrieslist[94] = "kenya";
            countrieslist[95] = "kiribati";
            countrieslist[96] = "kuwait";
            countrieslist[97] = "kyrgyzstan";
            countrieslist[98] = "lao people's democratic republic";
            countrieslist[99] = "latvia";
            countrieslist[100] = "lebanon";
            countrieslist[101] = "lesotho";
            countrieslist[102] = "liberia";
            countrieslist[103] = "libya";
            countrieslist[104] = "liechtenstein";
            countrieslist[105] = "lithuania";
            countrieslist[106] = "luxembourg";
            countrieslist[107] = "madagascar";
            countrieslist[108] = "malawi";
            countrieslist[109] = "malaysia";
            countrieslist[110] = "maldives";
            countrieslist[111] = "mali";
            countrieslist[112] = "malta";
            countrieslist[113] = "marshall islands";
            countrieslist[114] = "mauritania";
            countrieslist[115] = "mauritius";
            countrieslist[116] = "mexico";
            countrieslist[117] = "micronesia";
            countrieslist[118] = "monaco";
            countrieslist[119] = "mongolia";
            countrieslist[120] = "montenegro";
            countrieslist[121] = "morocco";
            countrieslist[122] = "mozambique";
            countrieslist[123] = "myanmar";
            countrieslist[124] = "namibia";
            countrieslist[125] = "nauru";
            countrieslist[126] = "nepal";
            countrieslist[127] = "netherlands";
            countrieslist[128] = "new zealand";
            countrieslist[129] = "nicaragua";
            countrieslist[130] = "niger";
            countrieslist[131] = "nigeria";
            countrieslist[132] = "north korea";
            countrieslist[133] = "norway";
            countrieslist[134] = "oman";
            countrieslist[135] = "pakistan";
            countrieslist[136] = "palau";
            countrieslist[137] = "panama";
            countrieslist[138] = "papua new guinea";
            countrieslist[139] = "paraguay";
            countrieslist[140] = "peru";
            countrieslist[141] = "philippines";
            countrieslist[142] = "republic of moldova";
            countrieslist[143] = "poland";
            countrieslist[144] = "polynesia";
            countrieslist[145] = "portugal";
            countrieslist[146] = "republic of korea";
            countrieslist[147] = "romania";
            countrieslist[148] = "russia";
            countrieslist[149] = "rwanda";
            countrieslist[150] = "saint kitts and nevis";
            countrieslist[151] = "saint lucia";
            countrieslist[152] = "saint pierre and miquelon";
            countrieslist[153] = "saint vincent and grenadines";
            countrieslist[154] = "samoa";
            countrieslist[155] = "san marino";
            countrieslist[156] = "sao tome and principe";
            countrieslist[157] = "saudi arabia";
            countrieslist[158] = "senegal";
            countrieslist[159] = "serbia";
            countrieslist[160] = "seychelles";
            countrieslist[161] = "sierra leone";
            countrieslist[162] = "singapore";
            countrieslist[163] = "slovakia";
            countrieslist[164] = "slovenia";
            countrieslist[165] = "solomon islands";
            countrieslist[166] = "somalia";
            countrieslist[167] = "south africa";
            countrieslist[168] = "south korea";
            countrieslist[169] = "south sudan";
            countrieslist[170] = "spain";
            countrieslist[171] = "sri lanka";
            countrieslist[172] = "sudan";
            countrieslist[173] = "suriname";
            countrieslist[174] = "syrian arab republic";
            countrieslist[175] = "swaziland";
            countrieslist[176] = "sweden";
            countrieslist[177] = "switzerland";
            countrieslist[178] = "syria";
            countrieslist[179] = "taiwan";
            countrieslist[180] = "tajikistan";
            countrieslist[181] = "thailand";
            countrieslist[182] = "east timor";
            countrieslist[183] = "togo";
            countrieslist[184] = "tonga";
            countrieslist[185] = "trinidad and tobago";
            countrieslist[186] = "tunisia";
            countrieslist[187] = "turkey";
            countrieslist[188] = "turkmenistan";
            countrieslist[189] = "united republic of tanzania";
            countrieslist[190] = "tuvalu";
            countrieslist[191] = "uganda";
            countrieslist[192] = "ukraine";
            countrieslist[193] = "united arab emirates";
            countrieslist[194] = "united kingdom";
            //(of Great Britian and Northern Ireland)
            countrieslist[195] = "united states";
            countrieslist[196] = "uruguay";
            countrieslist[197] = "uzbekistan";
            countrieslist[198] = "vanuatu";
            countrieslist[199] = "venezuela";
            countrieslist[200] = "vietnam";
            countrieslist[201] = "palestine";
            countrieslist[202] = "yemen";
            countrieslist[203] = "zambia";
            countrieslist[204] = "zimbabwe";
        }

        public void makecarbrandslist()
        {
            carbrandslist[0] = "8 chinkara";
            carbrandslist[1] = "aba";
            carbrandslist[2] = "abarth";
            carbrandslist[3] = "ac";
            carbrandslist[4] = "ac schnitzer";
            carbrandslist[5] = "acura";
            carbrandslist[6] = "adam";
            carbrandslist[7] = "adams-farwell";
            carbrandslist[8] = "adler";
            carbrandslist[9] = "aero";
            carbrandslist[10] = "aga";
            carbrandslist[11] = "agrale";
            carbrandslist[12] = "aixam";
            carbrandslist[13] = "alfa romeo";
            carbrandslist[14] = "allard";
            carbrandslist[15] = "alpine";
            carbrandslist[16] = "alvis";
            carbrandslist[17] = "anadol";
            carbrandslist[18] = "anasagasti";
            carbrandslist[19] = "angkor";
            carbrandslist[20] = "apollo";
            carbrandslist[21] = "armstrong siddeley";
            carbrandslist[22] = "aro";
            carbrandslist[23] = "ascari";
            carbrandslist[24] = "ashok leyland";
            carbrandslist[25] = "aston martin";
            carbrandslist[26] = "auburn";
            carbrandslist[27] = "audi";
            carbrandslist[28] = "austin";
            carbrandslist[29] = "austin-healey";
            carbrandslist[30] = "auto-mixte";
            carbrandslist[31] = "autobianchi";
            carbrandslist[32] = "automobile dacia";
            carbrandslist[33] = "avia";
            carbrandslist[34] = "avtoframos";
            carbrandslist[35] = "awz";
            carbrandslist[36] = "bahman";
            carbrandslist[37] = "bajaj";
            carbrandslist[38] = "barkas";
            carbrandslist[39] = "bate";
            carbrandslist[40] = "bentley";
            carbrandslist[41] = "bharath benz";
            carbrandslist[42] = "bitter";
            carbrandslist[43] = "bmc";
            carbrandslist[44] = "bmw";
            carbrandslist[45] = "bollore";
            carbrandslist[46] = "borgward";
            carbrandslist[47] = "bricklin";
            carbrandslist[48] = "bristol";
            carbrandslist[49] = "british leyland";
            carbrandslist[50] = "bufori";
            carbrandslist[51] = "bugatti";
            carbrandslist[52] = "buick";
            carbrandslist[53] = "bussing";
            carbrandslist[54] = "c-fee";
            carbrandslist[55] = "cadillac";
            carbrandslist[56] = "callaway";
            carbrandslist[57] = "caterham";
            carbrandslist[58] = "cherdchai";
            carbrandslist[59] = "chevrolet";
            carbrandslist[60] = "chrysler";
            carbrandslist[61] = "citroen";
            carbrandslist[62] = "cizeta";
            carbrandslist[63] = "coda";
            carbrandslist[64] = "cord";
            carbrandslist[65] = "crespi";
            carbrandslist[66] = "crobus";
            carbrandslist[67] = "daf";
            carbrandslist[68] = "daihatsu";
            carbrandslist[69] = "daimler";
            carbrandslist[70] = "datsun";
            carbrandslist[71] = "davis";
            carbrandslist[72] = "dc design";
            carbrandslist[73] = "de tomaso";
            carbrandslist[74] = "delorean";
            carbrandslist[75] = "derby";
            carbrandslist[76] = "dina";
            carbrandslist[77] = "dkw";
            carbrandslist[78] = "knowledgeinput";
            carbrandslist[79] = "dok-ing";
            carbrandslist[80] = "dok-ing xd";
            carbrandslist[81] = "dome";
            carbrandslist[82] = "donkervoort";
            carbrandslist[83] = "dr";
            carbrandslist[84] = "duesenberg";
            carbrandslist[85] = "e-z-go";
            carbrandslist[86] = "eagle";
            carbrandslist[87] = "edsel";
            carbrandslist[88] = "eicher";
            carbrandslist[89] = "elfin";
            carbrandslist[90] = "elva";
            carbrandslist[91] = "enzmann";
            carbrandslist[92] = "essex";
            carbrandslist[93] = "esther";
            carbrandslist[94] = "exagon";
            carbrandslist[95] = "falcon";
            carbrandslist[96] = "fap";
            carbrandslist[97] = "ferrari";
            carbrandslist[98] = "fiat";
            carbrandslist[99] = "fisker";
            carbrandslist[100] = "force";
            carbrandslist[101] = "ford";
            carbrandslist[102] = "fpv";
            carbrandslist[103] = "gaz";
            carbrandslist[104] = "gengatharan";
            carbrandslist[105] = "geo";
            carbrandslist[106] = "ghandhara";
            carbrandslist[107] = "ghandhara nissan";
            carbrandslist[108] = "gillet";
            carbrandslist[109] = "ginetta";
            carbrandslist[110] = "gkd";
            carbrandslist[111] = "glas";
            carbrandslist[112] = "global electric";
            carbrandslist[113] = "gm daewoo";
            carbrandslist[114] = "gm uzbekistan";
            carbrandslist[115] = "gmc";
            carbrandslist[116] = "goliath";
            carbrandslist[117] = "gordon keeble";
            carbrandslist[118] = "graham-paige";
            carbrandslist[119] = "guleryuz karoseri";
            carbrandslist[120] = "gumpert";
            carbrandslist[121] = "gurgel";
            carbrandslist[122] = "hansa";
            carbrandslist[123] = "hattat";
            carbrandslist[124] = "heinkel";
            carbrandslist[125] = "hennessey";
            carbrandslist[126] = "hero";
            carbrandslist[127] = "hillman";
            carbrandslist[128] = "hindustan";
            carbrandslist[129] = "hino";
            carbrandslist[130] = "hinopak";
            carbrandslist[131] = "hispano-argentina";
            carbrandslist[132] = "holden";
            carbrandslist[133] = "hommell";
            carbrandslist[134] = "honda";
            carbrandslist[135] = "honda atlas";
            carbrandslist[136] = "horch";
            carbrandslist[137] = "hsv";
            carbrandslist[138] = "huet brothers";
            carbrandslist[139] = "humber";
            carbrandslist[140] = "hummer";
            carbrandslist[141] = "hupmobile";
            carbrandslist[142] = "hyundai";
            carbrandslist[143] = "iame";
            carbrandslist[144] = "icml";
            carbrandslist[145] = "ida-opel";
            carbrandslist[146] = "ika";
            carbrandslist[147] = "ikarbus";
            carbrandslist[148] = "ikco";
            carbrandslist[149] = "indus";
            carbrandslist[150] = "infiniti";
            carbrandslist[151] = "inokom";
            carbrandslist[152] = "intermeccanica";
            carbrandslist[153] = "international harvester";
            carbrandslist[154] = "isuzu";
            carbrandslist[155] = "isuzu anadolu";
            carbrandslist[156] = "italika";
            carbrandslist[157] = "izh";
            carbrandslist[158] = "jaguar cars";
            carbrandslist[159] = "jeep";
            carbrandslist[160] = "jensen";
            carbrandslist[161] = "josse";
            carbrandslist[162] = "jowett";
            carbrandslist[163] = "jv man";
            carbrandslist[164] = "kaipan";
            carbrandslist[165] = "kaiser";
            carbrandslist[166] = "karsan";
            carbrandslist[167] = "kerman";
            carbrandslist[168] = "kia";
            carbrandslist[169] = "kia";
            carbrandslist[170] = "kish khodro";
            carbrandslist[171] = "kissel";
            carbrandslist[172] = "koenigsegg";
            carbrandslist[173] = "lada";
            carbrandslist[174] = "laforza";
            carbrandslist[175] = "lamborghini";
            carbrandslist[176] = "lanchester";
            carbrandslist[177] = "lancia";
            carbrandslist[178] = "land rover";
            carbrandslist[179] = "lasalle";
            carbrandslist[180] = "lexus";
            carbrandslist[181] = "ligier";
            carbrandslist[182] = "lincoln";
            carbrandslist[183] = "lister";
            carbrandslist[184] = "lloyd";
            carbrandslist[185] = "lobini";
            carbrandslist[186] = "locomobile";
            carbrandslist[187] = "lotus";
            carbrandslist[188] = "mahindra";
            carbrandslist[189] = "man";
            carbrandslist[190] = "mansory";
            carbrandslist[191] = "marcos";
            carbrandslist[192] = "marmon";
            carbrandslist[193] = "marussia";
            carbrandslist[194] = "maruti suzuki";
            carbrandslist[195] = "maserati";
            carbrandslist[196] = "master";
            carbrandslist[197] = "mastretta";
            carbrandslist[198] = "matra";
            carbrandslist[199] = "maybach";
            carbrandslist[200] = "mazda";
            carbrandslist[201] = "mclaren";
            carbrandslist[202] = "mdi";
            carbrandslist[203] = "mercedes";
            carbrandslist[204] = "mercury";
            carbrandslist[205] = "micro";
            carbrandslist[206] = "microcar";
            carbrandslist[207] = "mini";
            carbrandslist[208] = "mini cooper";
            carbrandslist[209] = "mitsubishi";
            carbrandslist[210] = "mitsuoka";
            carbrandslist[211] = "morgan";
            carbrandslist[212] = "morris";
            carbrandslist[213] = "moskvitch";
            carbrandslist[214] = "mosler";
            carbrandslist[215] = "multicar";
            carbrandslist[216] = "mvm";
            carbrandslist[217] = "nag";
            carbrandslist[218] = "nagant";
            carbrandslist[219] = "nash";
            carbrandslist[220] = "navistar";
            carbrandslist[221] = "naza";
            carbrandslist[222] = "neobus";
            carbrandslist[223] = "neoplan";
            carbrandslist[224] = "nissan";
            carbrandslist[225] = "noble";
            carbrandslist[226] = "nsu";
            carbrandslist[227] = "oldsmobile";
            carbrandslist[228] = "oltcit";
            carbrandslist[229] = "opel";
            carbrandslist[230] = "orient";
            carbrandslist[231] = "otokar";
            carbrandslist[232] = "otosan";
            carbrandslist[233] = "oyak";
            carbrandslist[234] = "p.a.r.s moto";
            carbrandslist[235] = "packard";
            carbrandslist[236] = "pagani";
            carbrandslist[237] = "pak suzuki";
            carbrandslist[238] = "panoz";
            carbrandslist[239] = "pars khodro";
            carbrandslist[240] = "perodua";
            carbrandslist[241] = "peugeot";
            carbrandslist[242] = "pgo";
            carbrandslist[243] = "pieper";
            carbrandslist[244] = "pierce-arrow";
            carbrandslist[245] = "plymouth";
            carbrandslist[246] = "pontiac";
            carbrandslist[247] = "porsche";
            carbrandslist[248] = "praga";
            carbrandslist[249] = "premier";
            carbrandslist[250] = "proto";
            carbrandslist[251] = "proton";
            carbrandslist[252] = "puma";
            carbrandslist[253] = "ram";
            carbrandslist[254] = "ramirez";
            carbrandslist[255] = "regal";
            carbrandslist[256] = "renault";
            carbrandslist[257] = "renault samsung";
            carbrandslist[258] = "reo";
            carbrandslist[259] = "riley";
            carbrandslist[260] = "rimac";
            carbrandslist[261] = "robur";
            carbrandslist[262] = "rolls royce";
            carbrandslist[263] = "rover";
            carbrandslist[264] = "ruf";
            carbrandslist[265] = "russo-balt";
            carbrandslist[266] = "saab";
            carbrandslist[267] = "saipa";
            carbrandslist[268] = "saleen";
            carbrandslist[269] = "samavto";
            carbrandslist[270] = "saturn";
            carbrandslist[271] = "sbarro";
            carbrandslist[272] = "scania";
            carbrandslist[273] = "scion";
            carbrandslist[274] = "shane moto";
            carbrandslist[275] = "siam v.m.c.";
            carbrandslist[276] = "siata";
            carbrandslist[277] = "simson";
            carbrandslist[278] = "singer";
            carbrandslist[279] = "skoda";
            carbrandslist[280] = "sound";
            carbrandslist[281] = "spyker";
            carbrandslist[282] = "ssangyong";
            carbrandslist[283] = "standard";
            carbrandslist[284] = "stealth";
            carbrandslist[285] = "sterling";
            carbrandslist[286] = "studebaker";
            carbrandslist[287] = "subaru";
            carbrandslist[288] = "sunbeam";
            carbrandslist[289] = "suzuki";
            carbrandslist[290] = "tac";
            carbrandslist[291] = "tafe";
            carbrandslist[292] = "tata";
            carbrandslist[293] = "tatra";
            carbrandslist[294] = "td2000";
            carbrandslist[295] = "temsa";
            carbrandslist[296] = "tesla";
            carbrandslist[297] = "th!nk";
            carbrandslist[298] = "thai rung";
            carbrandslist[299] = "the jamie stahley car";
            carbrandslist[300] = "tickford";
            carbrandslist[301] = "toyota";
            carbrandslist[302] = "trabant";
            carbrandslist[303] = "tranvias-cimex";
            carbrandslist[304] = "triumph";
            carbrandslist[305] = "trojan";
            carbrandslist[306] = "troller";
            carbrandslist[307] = "tucker";
            carbrandslist[308] = "turk traktor";
            carbrandslist[309] = "tvr";
            carbrandslist[310] = "tvs";
            carbrandslist[311] = "uaz";
            carbrandslist[312] = "vam sa";
            carbrandslist[313] = "vauxhall";
            carbrandslist[314] = "venturi";
            carbrandslist[315] = "vignale";
            carbrandslist[316] = "volkswagen";
            carbrandslist[317] = "volvo";
            carbrandslist[318] = "wanderer";
            carbrandslist[319] = "wartburg";
            carbrandslist[320] = "wiesmann";
            carbrandslist[321] = "willys";
            carbrandslist[322] = "wolseley";
            carbrandslist[323] = "yamaha";
            carbrandslist[324] = "yo-mobile";
            carbrandslist[325] = "zastava";
            carbrandslist[326] = "zenvo";
            carbrandslist[327] = "zil";
            carbrandslist[328] = "zoragy";
        }

        public void makegameconsoleslist()
        {
            gameconsoleslist[0] = "magnavox odyssey";
            gameconsoleslist[1] = "ping-o-tronic";
            gameconsoleslist[2] = "telstar";
            gameconsoleslist[3] = "apf tv fun";
            gameconsoleslist[4] = "philips odyssey";
            gameconsoleslist[5] = "radio shack tv scoreboard";
            gameconsoleslist[6] = "binatone tv master mk iv";
            gameconsoleslist[7] = "color tv game 6";
            gameconsoleslist[8] = "color tv game 15";
            gameconsoleslist[9] = "color tv racing 112";
            gameconsoleslist[10] = "color tv game block breaker";
            gameconsoleslist[11] = "computer tv game";
            gameconsoleslist[12] = "bss 01";
            gameconsoleslist[13] = "fairchild channel f";
            gameconsoleslist[14] = "fairchild channel f system ii";
            gameconsoleslist[15] = "rca studio ii";
            gameconsoleslist[16] = "atari 2600";
            gameconsoleslist[17] = "atari 2600 jr";
            gameconsoleslist[18] = "atari 2800";
            gameconsoleslist[19] = "coleco gemini";
            gameconsoleslist[20] = "bally astrocade";
            gameconsoleslist[21] = "vc 4000";
            gameconsoleslist[22] = "magnavox odyssey 2";
            gameconsoleslist[23] = "apf imagination machine";
            gameconsoleslist[24] = "intellivision";
            gameconsoleslist[25] = "playcable";
            gameconsoleslist[26] = "bandai super vision 8000";
            gameconsoleslist[27] = "intellivision ii";
            gameconsoleslist[28] = "vtech creativision";
            gameconsoleslist[29] = "epoch cassette vision";
            gameconsoleslist[30] = "super cassette vision";
            gameconsoleslist[31] = "arcadia 2001";
            gameconsoleslist[32] = "atari 5200";
            gameconsoleslist[33] = "atari 5100";
            gameconsoleslist[34] = "colecovision";
            gameconsoleslist[35] = "entex adventure vision";
            gameconsoleslist[36] = "vectrex";
            gameconsoleslist[37] = "rdi halcyon";
            gameconsoleslist[38] = "pv-1000";
            gameconsoleslist[39] = "commodore 64 games system";
            gameconsoleslist[40] = "amstrad gx4000";
            gameconsoleslist[41] = "atari 7800";
            gameconsoleslist[42] = "atari xegs";
            gameconsoleslist[43] = "sega sg-1000";
            gameconsoleslist[44] = "sega master system";
            gameconsoleslist[45] = "nintendo entertainment system";
            gameconsoleslist[46] = "sharp nintendo television";
            gameconsoleslist[47] = "nes-101";
            gameconsoleslist[48] = "family computer disk system";
            gameconsoleslist[49] = "zemmix";
            gameconsoleslist[50] = "action max";
            gameconsoleslist[51] = "sega genesis";
            gameconsoleslist[52] = "sega pico";
            gameconsoleslist[53] = "pc engine";
            gameconsoleslist[54] = "konix multisystem";
            gameconsoleslist[55] = "neo-geo";
            gameconsoleslist[56] = "neo-geo cd";
            gameconsoleslist[57] = "neo-geo cdz";
            gameconsoleslist[58] = "commodore cdtv";
            gameconsoleslist[59] = "memorex vis";
            gameconsoleslist[60] = "super nintendo entertainment system";
            gameconsoleslist[61] = "sf-1 snes tv";
            gameconsoleslist[62] = "snes 2";
            gameconsoleslist[63] = "snes-cd";
            gameconsoleslist[64] = "satellaview";
            gameconsoleslist[65] = "cd-i";
            gameconsoleslist[66] = "turboduo";
            gameconsoleslist[67] = "super a'can";
            gameconsoleslist[68] = "pioneer laseractive";
            gameconsoleslist[69] = "fm towns marty";
            gameconsoleslist[70] = "apple bandai pippin";
            gameconsoleslist[71] = "pc-fx";
            gameconsoleslist[72] = "atari panther";
            gameconsoleslist[73] = "atari jaguar";
            gameconsoleslist[74] = "atari jaguar cd";
            gameconsoleslist[75] = "playstation";
            gameconsoleslist[76] = "net yaroze";
            gameconsoleslist[77] = "sega saturn";
            gameconsoleslist[78] = "3do interactive multiplayer";
            gameconsoleslist[79] = "amiga cd32";
            gameconsoleslist[80] = "casio loopy";
            gameconsoleslist[81] = "playdia";
            gameconsoleslist[82] = "nintendo 64";
            gameconsoleslist[83] = "nintendo 64dd";
            gameconsoleslist[84] = "sega neptune";
            gameconsoleslist[85] = "apextreme";
            gameconsoleslist[86] = "atari flashback";
            gameconsoleslist[87] = "atari jaguar ii";
            gameconsoleslist[88] = "dreamcast";
            gameconsoleslist[89] = "l600";
            gameconsoleslist[90] = "gamecube";
            gameconsoleslist[91] = "nuon";
            gameconsoleslist[92] = "ique player";
            gameconsoleslist[93] = "panasonic m2";
            gameconsoleslist[94] = "panasonic q";
            gameconsoleslist[95] = "playstation 2";
            gameconsoleslist[96] = "psx";
            gameconsoleslist[97] = "v.smile";
            gameconsoleslist[98] = "xavixport gaming console";
            gameconsoleslist[99] = "xbox";
            gameconsoleslist[100] = "atari flashback 2";
            gameconsoleslist[101] = "atari flashback 3";
            gameconsoleslist[102] = "atari flashback 4";
            gameconsoleslist[103] = "evo smart console";
            gameconsoleslist[104] = "retro duo";
            gameconsoleslist[105] = "game wave";
            gameconsoleslist[106] = "mattel hyperscan";
            gameconsoleslist[107] = "onlive";
            gameconsoleslist[108] = "phantom";
            gameconsoleslist[109] = "playstation 3";
            gameconsoleslist[110] = "wii";
            gameconsoleslist[111] = "xbox 360";
            gameconsoleslist[112] = "sega firecore";
            gameconsoleslist[113] = "zeebo";
            gameconsoleslist[114] = "sega zone";
            gameconsoleslist[115] = "eedoo ct510";
            gameconsoleslist[116] = "wii u";
            gameconsoleslist[117] = "ouya";
            gameconsoleslist[118] = "gamestick";
            gameconsoleslist[119] = "mojo";
            gameconsoleslist[120] = "gamepop";
            gameconsoleslist[121] = "playstation 4";
            gameconsoleslist[122] = "steam machine";
            gameconsoleslist[123] = "xbox one";
            gameconsoleslist[124] = "xi3 piston";

        }

        public void makeelementslist()
        {
            elementslist[0] = "hydrogen";
            elementslist[1] = "helium";
            elementslist[2] = "lithium";
            elementslist[3] = "beryllium";
            elementslist[4] = "boron";
            elementslist[5] = "carbon";
            elementslist[6] = "nitrogen";
            elementslist[7] = "oxygen";
            elementslist[8] = "fluorine";
            elementslist[9] = "neon";
            elementslist[10] = "sodium";
            elementslist[11] = "magnesium";
            elementslist[12] = "aluminium";
            elementslist[13] = "silicon";
            elementslist[14] = "phosphorus";
            elementslist[15] = "sulfur";
            elementslist[16] = "chlorine";
            elementslist[17] = "argon";
            elementslist[18] = "potassium";
            elementslist[19] = "calcium";
            elementslist[20] = "scandium";
            elementslist[21] = "titanium";
            elementslist[22] = "vanadium";
            elementslist[23] = "chromium";
            elementslist[24] = "manganese";
            elementslist[25] = "iron";
            elementslist[26] = "cobalt";
            elementslist[27] = "nickel";
            elementslist[28] = "copper";
            elementslist[29] = "zinc";
            elementslist[30] = "gallium";
            elementslist[31] = "germanium";
            elementslist[32] = "arsenic";
            elementslist[33] = "selenium";
            elementslist[34] = "bromine";
            elementslist[35] = "krypton";
            elementslist[36] = "rubidium";
            elementslist[37] = "strontium";
            elementslist[38] = "yttrium";
            elementslist[39] = "zirconium";
            elementslist[40] = "niobium";
            elementslist[41] = "molybdenum";
            elementslist[42] = "technetium";
            elementslist[43] = "ruthenium";
            elementslist[44] = "rhodium";
            elementslist[45] = "palladium";
            elementslist[46] = "silver";
            elementslist[47] = "cadmium";
            elementslist[48] = "indium";
            elementslist[49] = "tin";
            elementslist[50] = "antimony";
            elementslist[51] = "tellurium";
            elementslist[52] = "iodine";
            elementslist[53] = "xenon";
            elementslist[54] = "caesium";
            elementslist[55] = "barium";
            elementslist[56] = "lanthanum";
            elementslist[57] = "cerium";
            elementslist[58] = "praseodymium";
            elementslist[59] = "neodymium";
            elementslist[60] = "promethium";
            elementslist[61] = "samarium";
            elementslist[62] = "europium";
            elementslist[63] = "gadolinium";
            elementslist[64] = "terbium";
            elementslist[65] = "dysprosium";
            elementslist[66] = "holmium";
            elementslist[67] = "erbium";
            elementslist[68] = "thulium";
            elementslist[69] = "ytterbium";
            elementslist[70] = "lutetium";
            elementslist[71] = "hafnium";
            elementslist[72] = "tantalum";
            elementslist[73] = "tungsten";
            elementslist[74] = "rhenium";
            elementslist[75] = "osmium";
            elementslist[76] = "iridium";
            elementslist[77] = "platinum";
            elementslist[78] = "gold";
            elementslist[79] = "mercury";
            elementslist[80] = "thallium";
            elementslist[81] = "lead";
            elementslist[82] = "bismuth";
            elementslist[83] = "polonium";
            elementslist[84] = "astatine";
            elementslist[85] = "radon";
            elementslist[86] = "francium";
            elementslist[87] = "radium";
            elementslist[88] = "actinium";
            elementslist[89] = "thorium";
            elementslist[90] = "protactinium";
            elementslist[91] = "uranium";
            elementslist[92] = "neptunium";
            elementslist[93] = "plutonium";
            elementslist[94] = "americium";
            elementslist[95] = "curium";
            elementslist[96] = "berkelium";
            elementslist[97] = "californium";
            elementslist[98] = "einsteinium";
            elementslist[99] = "fermium";
            elementslist[100] = "mendelevium";
            elementslist[101] = "nobelium";
            elementslist[102] = "lawrencium";
            elementslist[103] = "rutherfordium";
            elementslist[104] = "dubnium";
            elementslist[105] = "seaborgium";
            elementslist[106] = "bohrium";
            elementslist[107] = "hassium";
            elementslist[108] = "meitnerium";
            elementslist[109] = "darmstadtium";
            elementslist[110] = "roentgenium";
            elementslist[111] = "copernicium";
            elementslist[112] = "ununtrium";
            elementslist[113] = "flerovium";
            elementslist[114] = "ununpentium";
            elementslist[115] = "livermorium";
            elementslist[116] = "ununseptium";
            elementslist[117] = "ununoctium";
        }
    }
}
