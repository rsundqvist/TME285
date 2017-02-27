using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AgentLibrary;
using AuxiliaryLibrary;
using CommunicationLibrary;
using CustomUserControlsLibrary;
using ObjectSerializerLibrary;


namespace AgentApplication
{
    public partial class DI1 : Form
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
        public DI1()
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
            Console.WriteLine("GenerateChristmasAgent");
            agent = new ChristmasAgent();
            SetUpAgent();
            FinalizeSetup();
        }
        #endregion

        #region GUI action methods

        private void AgentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            agent?.Stop();
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
            agent.SetWindowPositions();
            agent.ShowVisualizerOnly();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            agent?.Stop();
            TimerResolution.TimeEndPeriod(1); // See also the startButton_Click method.
            memoryViewer.Clear();
            communicationLogColorListBox.Items.Clear();
        }
        #endregion

        #region Private methods
        // Sets up and agent, defining everything EXCEPT the processes (e.g. its long-term memory)
        private void SetUpAgent()
        {
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

        private void vacationAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateChristmasAgent();
        }
    }
}
