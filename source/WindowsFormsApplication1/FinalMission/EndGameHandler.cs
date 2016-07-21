using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftOS.FinalMission
{
    public enum Choice
    {
        SideWithDevX,
        StopDevX,
        EndAll
    }


    public class EndGameHandler
    {
        
        #region Properties

        public static Choice CurrentChoice
        {
            get { return currentChoice; }
        }

        public static Dictionary<string, bool> ThingsToDo
        {
            get
            {
                return thingsToDo;
            }
        }

        public static bool C2_ShellShockBreachCommand { get; set; }

        public static string CurrentObjective
        {
            get
            {
                try
                {
                    return thingsToDo.Keys.ElementAt<string>(currentObjective);
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string CurrentObjectivePrompt
        {
            get { return objPrompt; }
        }

        public static MissionGuide MissionGuide
        {
            get { return mguide; }
        }

        public static bool GodModeInstallEnabled { get; set; }

        #endregion

        public static FakeChatClient FakeHoloChatRoom
        {
            get
            {
                if (currentObjective == 0)
                {
                    var room = new FakeChatClient();
                    room.Name = "The Hacker Alliance";
                    room.OtherCharacters = new List<string>();
                    switch (currentChoice)
                    {
                        case Choice.EndAll:
                            room.Topic = "Oh no. | The ShiftOS Hacker Alliance: We don't mess around.";
                            room.OtherCharacters.Add("???");
                            room.OtherCharacters.Add("Hacker101");
                            room.Messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Resources.Choice3);
                            break;
                        case Choice.StopDevX:
                            room.Topic = "The ShiftOS Hacker Alliance: We don't mess around.";
                            room.OtherCharacters.Add("???");
                            room.Messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Resources.Choice2);
                            break;
                        case Choice.SideWithDevX:
                            room.Topic = "Chat seized by DevX";
                            room.OtherCharacters.Add("DevX");
                            room.Messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Resources.Choice1);
                            break;

                    }
                    return room;
                }
                else
                {
                    return null;
                }
            }
        }

        #region Events

        public static event EventHandler ObjectiveCompleted;
        public static event EventHandler MissionComplete;

        #endregion

        #region Variables
        private static Choice currentChoice = Choice.EndAll;
        private static Dictionary<string, bool> thingsToDo = new Dictionary<string, bool>();
        private static int currentObjective = 0;
        private static string objPrompt;
        private static MissionGuide mguide;
        
        #endregion

        #region Methods

        public static void Initiate(int choice)
        {
            mguide = new MissionGuide();
            mguide.Show();
            switch (choice)
            {
                case 1:
                    currentChoice = Choice.SideWithDevX;
                    currentObjective = 0;
                    thingsToDo.Add("Chat with DevX on HoloChat", false);
                    thingsToDo.Add("Install DevX's packages", false);
                    mguide.ShowButton = false;
                    objPrompt = "Go chat with DevX on HoloChat.";
                    break;
                case 2:
                    currentChoice = Choice.StopDevX;
                    thingsToDo.Add("Chat with the Other Player on HoloChat", false);
                    thingsToDo.Add("Hack through DevX's firewall", false);
                    thingsToDo.Add("Take down DevX's primary server", false);
                    thingsToDo.Add("Take down DevX's secondary server", false);
                    thingsToDo.Add("Forkbomb DevX's storage and telemetry server", false);
                    thingsToDo.Add("One last battle...", false);
                    thingsToDo.Add("Uninstall ShiftOS", false);
                    mguide.ShowButton = false;
                    objPrompt = "It's time to destroy DevX. Head to the Hacker Alliance HoloChat room to begin.";
                    break;
                case 3:
                    currentChoice = Choice.EndAll;
                    thingsToDo.Add("Trouble in the Hacker Alliance...", false);
                    mguide.ShowButton = false;
                    objPrompt = "Something's wrong in the Hacker Alliance chatroom... They need you.";
                    break;
            }
            API.CurrentSession.EndGame_AttachEvents();

        }

        public static void GoToNextObjective()
        {
            var h = ObjectiveCompleted;
            if (h != null)
            {
                h(CurrentObjective, new EventArgs());
            }
            currentObjective += 1;
            SetupGUIforCurrent();
        }

        public static void SetupGUIforCurrent()
        {
            GodModeInstallEnabled = false;
            C2_ShellShockBreachCommand = false;
            switch(currentChoice)
            {
                case Choice.SideWithDevX:
                    switch(currentObjective)
                    {
                        case 1:
                            mguide.ShowButton = false;
                            objPrompt = "Go open your Terminal and install the 'god_utils' package.";
                            GodModeInstallEnabled = true;
                            break;
                        case 2:
                            var h = MissionComplete;
                            h?.Invoke(CurrentObjective, new EventArgs());
                            break;
                    }
                    break;
                case Choice.EndAll:
                    switch(currentObjective)
                    {
                        case 1:
                            var h = MissionComplete;
                            h?.Invoke(CurrentObjective, new EventArgs());
                            break;
                    }
                    break;
                case Choice.StopDevX:
                    switch(currentObjective)
                    {
                        case 1:
                            mguide.ShowButton = true;
                            mguide.OnButtonClick = new Action(() =>
                            {
                                var enemy = JsonConvert.DeserializeObject<EnemyHacker>(Properties.Resources.DevX_Firewall);
                                var hui = new HackUI(enemy);
                                hui.Show();
                                hui.OnWin += (object s, EventArgs a) =>
                                {
                                    GoToNextObjective();
                                };
                            });
                            objPrompt = "Before we can do anything major, we need to bust through DevX's firewall. It should be easy, but beware. It's just a firewall. The real stuff's coming soon.";
                            break;
                        case 2:
                            mguide.OnButtonClick = new Action(() =>
                            {
                                var enemy = JsonConvert.DeserializeObject<EnemyHacker>(Properties.Resources.DevX_PrimaryNet);
                                var hui = new HackUI(enemy);
                                hui.Show();
                                hui.OnWin += (object s, EventArgs a) =>
                                {
                                    GoToNextObjective();
                                };
                            });
                            objPrompt = "Alright, we're through. Next on the list is DevX's primary server. Take this down and we can get further into the network without him finding out.";
                            break;
                        case 3:
                            mguide.OnButtonClick = new Action(() =>
                            {
                                var enemy = JsonConvert.DeserializeObject<EnemyHacker>(Properties.Resources.DevX_Secondary);
                                var hui = new HackUI(enemy);
                                hui.Show();
                                hui.OnWin += (object s, EventArgs a) =>
                                {
                                    GoToNextObjective();
                                };
                            });
                            objPrompt = "Primary server's D to the O to the W to the N. DOWN. Next we gotta take down his secondary server. Once it goes down, he's finished.";
                            break;
                        case 4:
                            mguide.ButtonText = "Begin attack in Terminal";
                            mguide.OnButtonClick = new Action(() =>
                            {
                                var t = new Terminal();
                                API.CreateForm(t, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
                                t.StartShellShock();
                            });
                            objPrompt = "Bye, have a great time, DevX! Arighty, DevX has one last server running that needs to go before we do anything more. This one sits on shiftnet://devx/tracker and is the server DevX uses to track other ShiftOS users. Take it down and he can't see any of this.";
                            break;
                        case 5:
                            mguide.ShowButton = false;
                            objPrompt = "THAT did it. I'd keep that terminal open until connection to the server drops. Once it's done, I'll close it and tell you what to do next.";
                            mguide.ButtonText = "Connect to server";
                            break;
                        case 6:
                            mguide.ShowButton = true;
                            mguide.ButtonText = "End DevX";
                            mguide.OnButtonClick = new Action(() =>
                            {
                                StartGoodEnding();
                            });
                            objPrompt = "Firewall, check. Primary server, check. Secondary server, CHECK. Telemetry server, CHECK. Now it's time to disable DevX himself. After all, he IS just code.";
                            break;
                        case 7:
                            var h = MissionComplete;
                            h?.Invoke(CurrentObjective, new EventArgs());
                            break;
                    }
                    break;
            }
        }
        #endregion

        public static void StartGoodEnding()
        {
            var room = new FakeChatClient();
            room.OtherCharacters = new List<string>();
            room.OtherCharacters.Add("TheHiddenHacker");
            room.Messages.Add("TheHiddenHacker", "After All This Time...");
        }
    }
}