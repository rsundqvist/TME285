namespace AgentApplication
{
    partial class AgentMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAgent1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAgent2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAgent3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAgent4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.communicationLogTabPage = new System.Windows.Forms.TabPage();
            this.communicationLogColorListBox = new CustomUserControlsLibrary.ColorListBox();
            this.workingMemoryTabPage = new System.Windows.Forms.TabPage();
            this.memoryViewer = new AgentLibrary.Visualization.MemoryViewer();
            this.actionToolStrip = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.vacationAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.communicationLogTabPage.SuspendLayout();
            this.workingMemoryTabPage.SuspendLayout();
            this.actionToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1194, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAgentToolStripMenuItem,
            this.loadAgentToolStripMenuItem,
            this.saveAgentToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newAgentToolStripMenuItem
            // 
            this.newAgentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testAgent1ToolStripMenuItem,
            this.testAgent2ToolStripMenuItem,
            this.testAgent3ToolStripMenuItem,
            this.testAgent4ToolStripMenuItem,
            this.vacationAgentToolStripMenuItem});
            this.newAgentToolStripMenuItem.Name = "newAgentToolStripMenuItem";
            this.newAgentToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.newAgentToolStripMenuItem.Text = "New agent";
            // 
            // testAgent1ToolStripMenuItem
            // 
            this.testAgent1ToolStripMenuItem.Name = "testAgent1ToolStripMenuItem";
            this.testAgent1ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.testAgent1ToolStripMenuItem.Text = "Test agent 1";
            this.testAgent1ToolStripMenuItem.Click += new System.EventHandler(this.testAgent1ToolStripMenuItem_Click);
            // 
            // testAgent2ToolStripMenuItem
            // 
            this.testAgent2ToolStripMenuItem.Name = "testAgent2ToolStripMenuItem";
            this.testAgent2ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.testAgent2ToolStripMenuItem.Text = "Test agent 2";
            this.testAgent2ToolStripMenuItem.Click += new System.EventHandler(this.testAgent2ToolStripMenuItem_Click);
            // 
            // testAgent3ToolStripMenuItem
            // 
            this.testAgent3ToolStripMenuItem.Name = "testAgent3ToolStripMenuItem";
            this.testAgent3ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.testAgent3ToolStripMenuItem.Text = "Test agent 3";
            this.testAgent3ToolStripMenuItem.Click += new System.EventHandler(this.testAgent3ToolStripMenuItem_Click);
            // 
            // testAgent4ToolStripMenuItem
            // 
            this.testAgent4ToolStripMenuItem.Name = "testAgent4ToolStripMenuItem";
            this.testAgent4ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.testAgent4ToolStripMenuItem.Text = "Test agent 4";
            this.testAgent4ToolStripMenuItem.Click += new System.EventHandler(this.testAgent4ToolStripMenuItem_Click);
            // 
            // loadAgentToolStripMenuItem
            // 
            this.loadAgentToolStripMenuItem.Name = "loadAgentToolStripMenuItem";
            this.loadAgentToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.loadAgentToolStripMenuItem.Text = "Load agent";
            this.loadAgentToolStripMenuItem.Click += new System.EventHandler(this.loadAgentToolStripMenuItem_Click);
            // 
            // saveAgentToolStripMenuItem
            // 
            this.saveAgentToolStripMenuItem.Name = "saveAgentToolStripMenuItem";
            this.saveAgentToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.saveAgentToolStripMenuItem.Text = "Save agent";
            this.saveAgentToolStripMenuItem.Click += new System.EventHandler(this.saveAgentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 821);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1194, 22);
            this.mainStatusStrip.TabIndex = 7;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.communicationLogTabPage);
            this.mainTabControl.Controls.Add(this.workingMemoryTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 67);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1194, 776);
            this.mainTabControl.TabIndex = 6;
            // 
            // communicationLogTabPage
            // 
            this.communicationLogTabPage.Controls.Add(this.communicationLogColorListBox);
            this.communicationLogTabPage.Location = new System.Drawing.Point(4, 29);
            this.communicationLogTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.communicationLogTabPage.Name = "communicationLogTabPage";
            this.communicationLogTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.communicationLogTabPage.Size = new System.Drawing.Size(1186, 743);
            this.communicationLogTabPage.TabIndex = 1;
            this.communicationLogTabPage.Text = "Communication log";
            this.communicationLogTabPage.UseVisualStyleBackColor = true;
            // 
            // communicationLogColorListBox
            // 
            this.communicationLogColorListBox.BackColor = System.Drawing.Color.Black;
            this.communicationLogColorListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.communicationLogColorListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.communicationLogColorListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.communicationLogColorListBox.ForeColor = System.Drawing.Color.Lime;
            this.communicationLogColorListBox.FormattingEnabled = true;
            this.communicationLogColorListBox.Location = new System.Drawing.Point(4, 5);
            this.communicationLogColorListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.communicationLogColorListBox.Name = "communicationLogColorListBox";
            this.communicationLogColorListBox.SelectedItemBackColor = System.Drawing.Color.Empty;
            this.communicationLogColorListBox.SelectedItemForeColor = System.Drawing.Color.Empty;
            this.communicationLogColorListBox.Size = new System.Drawing.Size(1178, 733);
            this.communicationLogColorListBox.TabIndex = 0;
            this.communicationLogColorListBox.SelectedIndexChanged += new System.EventHandler(this.communicationLogColorListBox_SelectedIndexChanged);
            // 
            // workingMemoryTabPage
            // 
            this.workingMemoryTabPage.Controls.Add(this.memoryViewer);
            this.workingMemoryTabPage.Location = new System.Drawing.Point(4, 29);
            this.workingMemoryTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workingMemoryTabPage.Name = "workingMemoryTabPage";
            this.workingMemoryTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workingMemoryTabPage.Size = new System.Drawing.Size(1186, 735);
            this.workingMemoryTabPage.TabIndex = 3;
            this.workingMemoryTabPage.Text = "Working memory";
            this.workingMemoryTabPage.UseVisualStyleBackColor = true;
            // 
            // memoryViewer
            // 
            this.memoryViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoryViewer.InvocationListVisible = false;
            this.memoryViewer.Location = new System.Drawing.Point(4, 5);
            this.memoryViewer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.memoryViewer.Name = "memoryViewer";
            this.memoryViewer.Size = new System.Drawing.Size(1178, 725);
            this.memoryViewer.TabIndex = 0;
            // 
            // actionToolStrip
            // 
            this.actionToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.actionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.stopButton});
            this.actionToolStrip.Location = new System.Drawing.Point(0, 35);
            this.actionToolStrip.Name = "actionToolStrip";
            this.actionToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.actionToolStrip.Size = new System.Drawing.Size(1194, 32);
            this.actionToolStrip.TabIndex = 5;
            this.actionToolStrip.Text = "toolStrip1";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startButton.Enabled = false;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(52, 29);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopButton.Enabled = false;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(53, 29);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // vacationAgentToolStripMenuItem
            // 
            this.vacationAgentToolStripMenuItem.Name = "vacationAgentToolStripMenuItem";
            this.vacationAgentToolStripMenuItem.Size = new System.Drawing.Size(212, 30);
            this.vacationAgentToolStripMenuItem.Text = "VacationAgent";
            this.vacationAgentToolStripMenuItem.Click += new System.EventHandler(this.vacationAgentToolStripMenuItem_Click);
            // 
            // AgentMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 843);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.actionToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AgentMainForm";
            this.Text = "Agent (demonstration)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgentMainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.communicationLogTabPage.ResumeLayout(false);
            this.workingMemoryTabPage.ResumeLayout(false);
            this.actionToolStrip.ResumeLayout(false);
            this.actionToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAgentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAgent1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAgentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAgentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage communicationLogTabPage;
        private System.Windows.Forms.ToolStrip actionToolStrip;
        private System.Windows.Forms.TabPage workingMemoryTabPage;
        private System.Windows.Forms.ToolStripButton startButton;
        private AgentLibrary.Visualization.MemoryViewer memoryViewer;
        private System.Windows.Forms.ToolStripMenuItem testAgent2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAgent3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAgent4ToolStripMenuItem;
        private CustomUserControlsLibrary.ColorListBox communicationLogColorListBox;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripMenuItem vacationAgentToolStripMenuItem;
    }
}

