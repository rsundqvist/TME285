using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AgentLibrary;
using AgentLibrary.BrainProcesses;
using AgentLibrary.BrainProcesses.DialogueActions;
using AgentLibrary.BrainProcesses.DialogueItems;
using AgentLibrary.Memories;
using AuxiliaryLibrary;
using CommunicationLibrary;
using CustomUserControlsLibrary;
using ObjectSerializerLibrary;


namespace AgentApplication
{
    public partial class AgentMainForm : Form
    {
        #region Constants
        private const string DATETIME_FORMAT = "yyyyMMdd HH:mm:ss";
        #endregion

        #region Fields
        private Agent agent;
        private static object communicationLogLockObject = new object();
        //   private static object dialogueLockObject = new object();
        #endregion

        #region Constructors
        public AgentMainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Protected methods
        // To prevent flickering when resizing
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion

        #region Agent definitions
        private void GenerateChristmasAgent()
        {
            //SetUpAgent();
            agent = new ChristmasAgent();

            agent.Server.Progress += new EventHandler<CommunicationProgressEventArgs>(HandleAgentServerProgress);
            agent.IPAddress = "127.0.0.1";  // (Not really needed (default value))
            agent.CommunicationPort = 7;    // (Not really needed (default value))

            // Define client processes:
            agent.ClientProcessRelativeFilePathList = new List<string>();
            agent.ClientProcessRelativeFilePathList.Add("..\\..\\..\\ListenerApplication\\bin\\Debug\\ListenerApplication.exe");
            agent.ClientProcessRelativeFilePathList.Add("..\\..\\..\\SpeechApplication\\bin\\Debug\\SpeechApplication.exe");

            FinalizeSetup();
        }

        private void GenerateTestAgent1()
        {
            SetUpAgent();
            DialogueProcess dialogue1 = new DialogueProcess();
            dialogue1.Name = "Dialogue1";
            agent.BrainProcessList.Add(dialogue1);
            dialogue1.ActiveOnStartup = true;
            InteractionItem dialogueItem1 = new InteractionItem();
            dialogueItem1.Name = "Item1";
            dialogueItem1.MaximumRepetitionCount = 2;
            ResponseAction action1 = new ResponseAction();
            action1.InputList.Add("Hello");
            action1.InputList.Add("Hi");
            action1.TargetDialogueItemName = "Item2";
            action1.OutputList.Add("Hello user");
            dialogueItem1.ActionList.Add(action1);
            dialogue1.ItemList.Add(dialogueItem1);
            InteractionItem dialogueItem2 = new InteractionItem();
            dialogueItem2.MillisecondDelay = 500;
            dialogueItem2.Name = "Item2";
            OutputAction action2 = new OutputAction();
            action2.OutputList.Add("How can I be of service?");
            action2.BrainProcessToDeactivate = dialogue1.Name;
            dialogueItem2.ActionList.Add(action2);
            dialogue1.ItemList.Add(dialogueItem2);

            FinalizeSetup();
        }

        private void GenerateTestAgent2()
        {
            SetUpAgent();
            // Define brain processes
            DialogueProcess dialogue1 = new DialogueProcess();
            dialogue1.Name = "Dialogue1";
            dialogue1.ProcessActivatedOnFailure = dialogue1.Name;
            agent.BrainProcessList.Add(dialogue1);
            dialogue1.ActiveOnStartup = true;
            startButton.Enabled = true;
            InteractionItem dialogueItem1 = new InteractionItem();
            dialogueItem1.Name = "Item1";
            ResponseAction action1 = new ResponseAction();
            action1.InputList.Add("Hello");
            action1.TargetDialogueItemName = "Item2";
            action1.OutputList.Add("Hello user");
            dialogueItem1.ActionList.Add(action1);
            dialogue1.ItemList.Add(dialogueItem1);
            InteractionItem dialogueItem2 = new InteractionItem();
            dialogueItem2.MillisecondDelay = 1000;
            dialogueItem2.Name = "Item2";
            ResponseAction action2 = new ResponseAction();
            action2.TargetDialogueItemName = "Item3";
            action2.OutputList.Add("How are you today?");
            dialogueItem2.ActionList.Add(action2);
            dialogue1.ItemList.Add(dialogueItem2);
            InteractionItem dialogueItem3 = new InteractionItem();
            dialogueItem3.Name = "Item3";
            ResponseAction action31 = new ResponseAction();
            action31.InputList.Add("Not so good");
            action31.OutputList.Add("I'm sorry to hear that");
            action31.TargetDialogueItemName = "NegativeItem1";
            dialogueItem3.ActionList.Add(action31);
            ResponseAction action32 = new ResponseAction();
            action32.InputList.Add("Fine");
            action32.OutputList.Add("I'm happy to hear that");
            action32.TargetDialogueItemName = "PositiveItem1";
            dialogueItem3.ActionList.Add(action32);
            dialogue1.ItemList.Add(dialogueItem3);
            // Negative path:
            InteractionItem negativeItem1 = new InteractionItem();
            negativeItem1.MillisecondDelay = 1000;
            negativeItem1.Name = "NegativeItem1";
            OutputAction actionN1 = new OutputAction();
            actionN1.OutputList.Add("Can I help?");
            actionN1.TargetDialogueItemName = "NegativeItem2";
            negativeItem1.ActionList.Add(actionN1);
            dialogue1.ItemList.Add(negativeItem1);
            InteractionItem negativeItem2 = new InteractionItem();
            negativeItem2.Name = "NegativeItem2";
            ResponseAction actionN2 = new ResponseAction();
            actionN2.SetNegativeInput();
            actionN2.OutputList.Add("I see.");
            negativeItem2.ActionList.Add(actionN2);
            ResponseAction actionN3 = new ResponseAction();
            actionN3.SetAffirmativeInput();
            actionN3.OutputList.Add("What do you want me to do?");
            negativeItem2.ActionList.Add(actionN3);
            dialogue1.ItemList.Add(negativeItem2);
            // Positive path:
            InteractionItem positiveItem1 = new InteractionItem();
            positiveItem1.MillisecondDelay = 1000;
            positiveItem1.Name = "PositiveItem1";
            ResponseAction actionP1 = new ResponseAction();
            actionP1.OutputList.Add("Would you like to play a game?");
            actionP1.BrainProcessToDeactivate = dialogue1.Name;
            positiveItem1.ActionList.Add(actionP1);
            dialogue1.ItemList.Add(positiveItem1);
            FinalizeSetup();
        }

        private void GenerateTestAgent3()
        {
            SetUpAgent();
            // Define brain processes
            DialogueProcess greetingDialogue = new DialogueProcess();
            greetingDialogue.Name = "GreetingDialogue";
            agent.BrainProcessList.Add(greetingDialogue);
            greetingDialogue.ActiveOnStartup = true;
            startButton.Enabled = true;
            InteractionItem dialogueItem1 = new InteractionItem();
            dialogueItem1.Name = "Item1";
            ResponseAction action1 = new ResponseAction();
            action1.InputList.Add("Hello");
            action1.TargetDialogueItemName = "Item2";
            action1.OutputList.Add("Hello user");
            dialogueItem1.ActionList.Add(action1);
            greetingDialogue.ItemList.Add(dialogueItem1);
            InteractionItem dialogueItem2 = new InteractionItem();
            dialogueItem2.MillisecondDelay = 1000;
            dialogueItem2.Name = "Item2";
            OutputAction action2 = new OutputAction();
            action2.TargetDialogueItemName = "Item3";
            action2.OutputList.Add("How are you today?");
            dialogueItem2.ActionList.Add(action2);
            greetingDialogue.ItemList.Add(dialogueItem2);
            InteractionItem dialogueItem3 = new InteractionItem();
            dialogueItem3.Name = "Item3";
            ResponseAction action31 = new ResponseAction();
            action31.InputList.Add("Not so good");
            action31.OutputList.Add("I'm sorry to hear that");
            action31.BrainProcessToDeactivate = "GreetingDialogue";
            action31.BrainProcessToActivate = "NegativeHealthDialogue";
            action31.TargetDialogueItemName = "NegativeItem1";
            dialogueItem3.ActionList.Add(action31);
            ResponseAction action32 = new ResponseAction();
            action32.InputList.Add("Fine");
            action32.OutputList.Add("I'm happy to hear that");
            action32.BrainProcessToDeactivate = "GreetingDialogue";
            action32.BrainProcessToActivate = "PositiveHealthDialogue";
            dialogueItem3.ActionList.Add(action32);
            greetingDialogue.ItemList.Add(dialogueItem3);

            // Negative health dialogue
            DialogueProcess negativeHealthDialogue = new DialogueProcess();
            negativeHealthDialogue.ProcessActivatedOnFailure = greetingDialogue.Name;
            negativeHealthDialogue.Name = "NegativeHealthDialogue";
            agent.BrainProcessList.Add(negativeHealthDialogue);
            negativeHealthDialogue.ActiveOnStartup = false;
            InteractionItem dialogueItemN1 = new InteractionItem();
            dialogueItemN1.Name = "Item1";
            dialogueItemN1.MillisecondDelay = 200;
            OutputAction actionN1 = new OutputAction();
            actionN1.OutputList.Add("Can I help?");
            actionN1.TargetDialogueItemName = "Item2";
            dialogueItemN1.ActionList.Add(actionN1);
            negativeHealthDialogue.ItemList.Add(dialogueItemN1);
            InteractionItem dialogueItemN2 = new InteractionItem();
            dialogueItemN2.Name = "Item2";
            ResponseAction actionN2 = new ResponseAction();
            actionN2.SetNegativeInput();
            actionN2.OutputList.Add("I see.");
            dialogueItemN2.ActionList.Add(actionN2);
            ResponseAction actionN3 = new ResponseAction();
            actionN3.SetAffirmativeInput();
            actionN3.OutputList.Add("What do you want me to do?");
            dialogueItemN2.ActionList.Add(actionN3);
            negativeHealthDialogue.ItemList.Add(dialogueItemN2);

            // Positive health dialogue
            DialogueProcess positiveHealthDialogue = new DialogueProcess();
            positiveHealthDialogue.ProcessActivatedOnFailure = greetingDialogue.Name;
            positiveHealthDialogue.Name = "PositiveHealthDialogue";
            agent.BrainProcessList.Add(positiveHealthDialogue);
            positiveHealthDialogue.ActiveOnStartup = false;
            InteractionItem dialogueItemP1 = new InteractionItem();
            dialogueItemP1.Name = "Item1";
            dialogueItemP1.MillisecondDelay = 200;
            ResponseAction actionP1 = new ResponseAction();
            actionP1.OutputList.Add("Would you like to play a game?");
            dialogueItemP1.ActionList.Add(actionP1);
            positiveHealthDialogue.ItemList.Add(dialogueItemP1);
            FinalizeSetup();
        }

        private void GenerateTestAgent4()
        {
            SetUpAgent();

            // Define brain processes

            // Ugly hard-coding of long-term memory (just a test ...)
            MemoryItem newsItem1 = new MemoryItem();
            newsItem1.CreationDateTime = DateTime.Now;
            newsItem1.Tag = "News";
            newsItem1.Content = "US Election";
            agent.WorkingMemory.InsertItem(newsItem1);
            Thread.Sleep(100); // Ugly! Only used in order to get a different time stamps for the two news items, for the purpose of demonstration.
            MemoryItem newsItem2 = new MemoryItem();
            newsItem2.CreationDateTime = DateTime.Now;
            newsItem2.Tag = "News";
            newsItem2.Content = "Earthquake in New Zealand";
            agent.WorkingMemory.InsertItem(newsItem2);

            DialogueProcess greetingDialogue = new DialogueProcess();
            greetingDialogue.Name = "GreetingDialogue";
            agent.BrainProcessList.Add(greetingDialogue);
            greetingDialogue.ActiveOnStartup = true;
            startButton.Enabled = true;

            /*  Uncomment the code below to send a facial expression command
               (OpenEyes) to the facial expression process  
            // Unconditional opening of the agent's eyes upon start-up:            
            InteractionItem openEyesDialogueItem = new InteractionItem();
            openEyesDialogueItem.Name = "OpenEyesItem";
            OutputAction openEyesAction = new OutputAction();
            openEyesAction.OutputList.Add("OpenEyes");
            openEyesAction.OutputTag = MemoryItemTags.FaceProcess;
            openEyesAction.TargetDialogueItemName = "Item1";
            openEyesDialogueItem.ActionList.Add(openEyesAction);
            greetingDialogue.ItemList.Add(openEyesDialogueItem);
            */

            InteractionItem dialogueItem1 = new InteractionItem();
            dialogueItem1.Name = "Item1";
            ResponseAction action1 = new ResponseAction();
            action1.InputList.Add("Read the news, please");
            action1.InputList.Add("News");
            action1.OutputList.Add("OK, just a moment");
            action1.TargetDialogueItemName = "FindNewsItem";
            dialogueItem1.ActionList.Add(action1);
            greetingDialogue.ItemList.Add(dialogueItem1);
            MemoryAccessItem dialogueItem2 = new MemoryAccessItem();
            dialogueItem2.Name = "FindNewsItem";
            FindAction findAction = new FindAction();
            findAction.Tag = "News";
            findAction.TargetDialogueItemName = "ReadItem";
            dialogueItem2.MillisecondDelay = 100;
            dialogueItem2.ActionList.Add(findAction);
            greetingDialogue.ItemList.Add(dialogueItem2);
            InteractionItem readItem = new InteractionItem();
            readItem.Name = "ReadItem";
            readItem.MillisecondDelay = 500;
            OutputAction readAction = new OutputAction();
            readAction.OutputList.Add("I will read the most recent one");
            readAction.TargetDialogueItemName = "ReadItem2";
            readItem.ActionList.Add(readAction);
            greetingDialogue.ItemList.Add(readItem);
            MemoryAccessItem readItem2 = new MemoryAccessItem();
            readItem2.Name = "ReadItem2";
            readItem2.MillisecondDelay = 1000;
            ReadByTagAction readAction2 = new ReadByTagAction();
            readAction2.Index = 0;
            readAction2.Tag = "News";
            readItem2.ActionList.Add(readAction2);
            greetingDialogue.ItemList.Add(readItem2);

            FinalizeSetup();
        }
        #endregion

        #region GUI action methods
        private void testAgent1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTestAgent1();
        }

        private void testAgent2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTestAgent2();
        }

        private void testAgent3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTestAgent3();
        }

        private void testAgent4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTestAgent4();
        }

        private void AgentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (agent != null)
            {
                agent.Stop();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            TimerResolution.TimeBeginPeriod(1);  // Sets the timer resolution to 1 ms (default in Windows 7: 15.6 ms)
            startButton.Enabled = false;
            stopButton.Enabled = true;
            mainTabControl.SelectTab(workingMemoryTabPage);
            agent.Start();
            //agent.SetWindowPositions();
            agent.ShowVisualizerOnly();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            if (agent != null)
            {
                agent.Stop();
            }
            TimerResolution.TimeEndPeriod(1); // See also the startButton_Click method.
            memoryViewer.Clear();
            communicationLogColorListBox.Items.Clear();
        }
        #endregion

        #region Private methods
        // Sets up and agent, defining everything EXCEPT the processes (e.g. its long-term memory)
        private void SetUpAgent()
        {
            agent = new Agent();
            agent.Name = "TestAgent";

            // Define communication server
            // agent.Server.Name = "Agent";
            agent.Server.Progress += new EventHandler<CommunicationProgressEventArgs>(HandleAgentServerProgress);
            //    agent.Server.Received += new EventHandler<DataPacketEventArgs>(HandleAgentServerReceived);  // Not used
            agent.IPAddress = "127.0.0.1";  // (Not really needed (default value))
            agent.CommunicationPort = 7;    // (Not really needed (default value))

            // Define client processes:
            agent.ClientProcessRelativeFilePathList = new List<string>();
            agent.ClientProcessRelativeFilePathList.Add("..\\..\\..\\ListenerApplication\\bin\\Debug\\ListenerApplication.exe");
            agent.ClientProcessRelativeFilePathList.Add("..\\..\\..\\SpeechApplication\\bin\\Debug\\SpeechApplication.exe");
        }

        private void FinalizeSetup()
        {
            startButton.Enabled = true;
            memoryViewer.SetMemory(agent.WorkingMemory);
            memoryViewer.InvocationListVisible = true;
        }

        private void InsertLogMessage(CommunicationProgressEventArgs e)
        {
            Monitor.Enter(communicationLogLockObject);
            Color itemBackColor = communicationLogColorListBox.BackColor;
            Color ItemForeColor = communicationLogColorListBox.ForeColor;
            ColorListBoxItem item = new ColorListBoxItem(e.DateTime.ToString(DATETIME_FORMAT) + ": " + e.Message,
                itemBackColor, ItemForeColor);
            communicationLogColorListBox.Items.Insert(0, item);
            Monitor.Exit(communicationLogLockObject);
        }

        private void HandleAgentServerProgress(object sender, CommunicationProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => InsertLogMessage(e)));
            }
            else { InsertLogMessage(e); }
        }

        private void saveAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ObjectXmlSerializer.SerializeObject(saveFileDialog.FileName, agent);
                }
            }
        }

        private void loadAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    agent = (Agent)ObjectXmlSerializer.ObtainSerializedObject(openFileDialog.FileName, typeof(Agent));
                    agent.Initialize();
                    agent.Server.Name = "Agent";
                    agent.Server.Progress += new EventHandler<CommunicationProgressEventArgs>(HandleAgentServerProgress);
                    FinalizeSetup();
                }
            }
        }

        /*  private void InsertDialogueMessage(string dialogueMessage)
          {
              Monitor.Enter(dialogueLockObject);
              Color itemBackColor = communicationLogColorListBox.BackColor;
              Color ItemForeColor = communicationLogColorListBox.ForeColor;
              ColorListBoxItem item = new ColorListBoxItem(dialogueMessage, itemBackColor, Color.Lime);
              dialogueColorListBox.Items.Insert(0, item);
              Monitor.Exit(dialogueLockObject);
          }  */
        #endregion

        private void communicationLogColorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vacationAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateChristmasAgent();
        }
    }
}
