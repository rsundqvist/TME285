namespace AgentApplication
{
    partial class DI1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DI1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacationAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.communicationLogTabPage = new System.Windows.Forms.TabPage();
            this.communicationLogColorListBox = new CustomUserControlsLibrary.ColorListBox();
            this.workingMemoryTabPage = new System.Windows.Forms.TabPage();
            this.actionToolStrip = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.memoryViewer = new AgentLibrary.Visualization.MemoryViewer();
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
            this.menuStrip1.Size = new System.Drawing.Size(733, 35);
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
            this.vacationAgentToolStripMenuItem});
            this.newAgentToolStripMenuItem.Name = "newAgentToolStripMenuItem";
            this.newAgentToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.newAgentToolStripMenuItem.Text = "New agent";
            // 
            // vacationAgentToolStripMenuItem
            // 
            this.vacationAgentToolStripMenuItem.Name = "vacationAgentToolStripMenuItem";
            this.vacationAgentToolStripMenuItem.Size = new System.Drawing.Size(212, 30);
            this.vacationAgentToolStripMenuItem.Text = "ChristmasAgent";
            this.vacationAgentToolStripMenuItem.Click += new System.EventHandler(this.vacationAgentToolStripMenuItem_Click);
            // 
            // loadAgentToolStripMenuItem
            // 
            this.loadAgentToolStripMenuItem.Name = "loadAgentToolStripMenuItem";
            this.loadAgentToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.loadAgentToolStripMenuItem.Text = "Load agent";
            this.loadAgentToolStripMenuItem.Click += new System.EventHandler(this.loadAgentToolStripMenuItem_Click);
            // 
            // saveAgentToolStripMenuItem
            // 
            this.saveAgentToolStripMenuItem.Name = "saveAgentToolStripMenuItem";
            this.saveAgentToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.saveAgentToolStripMenuItem.Text = "Save agent";
            this.saveAgentToolStripMenuItem.Click += new System.EventHandler(this.saveAgentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 821);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(733, 22);
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
            this.mainTabControl.Size = new System.Drawing.Size(733, 776);
            this.mainTabControl.TabIndex = 6;
            // 
            // communicationLogTabPage
            // 
            this.communicationLogTabPage.Controls.Add(this.communicationLogColorListBox);
            this.communicationLogTabPage.Location = new System.Drawing.Point(4, 29);
            this.communicationLogTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.communicationLogTabPage.Name = "communicationLogTabPage";
            this.communicationLogTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.communicationLogTabPage.Size = new System.Drawing.Size(725, 743);
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
            this.communicationLogColorListBox.Size = new System.Drawing.Size(717, 733);
            this.communicationLogColorListBox.TabIndex = 0;
            // 
            // workingMemoryTabPage
            // 
            this.workingMemoryTabPage.Controls.Add(this.memoryViewer);
            this.workingMemoryTabPage.Location = new System.Drawing.Point(4, 29);
            this.workingMemoryTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workingMemoryTabPage.Name = "workingMemoryTabPage";
            this.workingMemoryTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workingMemoryTabPage.Size = new System.Drawing.Size(725, 743);
            this.workingMemoryTabPage.TabIndex = 3;
            this.workingMemoryTabPage.Text = "Working memory";
            this.workingMemoryTabPage.UseVisualStyleBackColor = true;
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
            this.actionToolStrip.Size = new System.Drawing.Size(733, 32);
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
            // memoryViewer
            // 
            this.memoryViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoryViewer.InvocationListVisible = false;
            this.memoryViewer.Location = new System.Drawing.Point(4, 5);
            this.memoryViewer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.memoryViewer.Name = "memoryViewer";
            this.memoryViewer.Size = new System.Drawing.Size(717, 733);
            this.memoryViewer.TabIndex = 0;
            // 
            // DI1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 843);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.actionToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DI1";
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
        private CustomUserControlsLibrary.ColorListBox communicationLogColorListBox;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripMenuItem vacationAgentToolStripMenuItem;
    }
}

