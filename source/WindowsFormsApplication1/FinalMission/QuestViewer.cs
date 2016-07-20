using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS.FinalMission
{
    public partial class QuestViewer : Form
    {
        public QuestViewer()
        {
            InitializeComponent();
        }

        private void QuestViewer_Load(object sender, EventArgs e)
        {
            SetupList();
            StartQuestCheckThread();
            var tmr = new ShiftUI.Timer();
            tmr.Interval = 500;
            tmr.Tick += (object s, EventArgs a) =>
            {
                SetupList();
            };
            tmr.Start();
        }

        public void SetupList()
        {
            lbobjectives.Items.Clear();
            foreach(var itm in EndGameHandler.ThingsToDo)
            {
                lbobjectives.Items.Add(itm.Key);
            }
        }

        public void StartQuestCheckThread()
        {
            var t = new Thread(new ThreadStart(new Action(() => {
                //Start checkloop.
                while(true)
                {
                    CheckObjective(EndGameHandler.CurrentObjective);
                }
            })));
            t.Start();
        }

        public void CheckObjective(string obj)
        {
            if(EndGameHandler.ThingsToDo[obj] == true)
            {
                EndGameHandler.GoToNextObjective();
            }
        }
    }
}
