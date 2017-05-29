namespace FancyInternetDataAcquisition
{
    partial class IDA1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDA1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.newsTab = new System.Windows.Forms.TabPage();
            this.refreshButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.setupTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.keywordsTextbox = new System.Windows.Forms.TextBox();
            this.rssTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.speechStatusBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.newsTab.SuspendLayout();
            this.setupTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.newsTab);
            this.tabControl.Controls.Add(this.setupTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(509, 287);
            this.tabControl.TabIndex = 0;
            this.tabControl.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabDeselect);
            // 
            // newsTab
            // 
            this.newsTab.Controls.Add(this.refreshButton);
            this.newsTab.Controls.Add(this.listBox);
            this.newsTab.Location = new System.Drawing.Point(4, 29);
            this.newsTab.Margin = new System.Windows.Forms.Padding(2);
            this.newsTab.Name = "newsTab";
            this.newsTab.Padding = new System.Windows.Forms.Padding(2);
            this.newsTab.Size = new System.Drawing.Size(501, 254);
            this.newsTab.TabIndex = 0;
            this.newsTab.Text = "News";
            this.newsTab.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(387, 4);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(111, 29);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh Now";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(2, 2);
            this.listBox.Margin = new System.Windows.Forms.Padding(2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(497, 250);
            this.listBox.TabIndex = 0;
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.viewFullStory);
            // 
            // setupTab
            // 
            this.setupTab.Controls.Add(this.splitContainer1);
            this.setupTab.Controls.Add(this.panel1);
            this.setupTab.Location = new System.Drawing.Point(4, 29);
            this.setupTab.Margin = new System.Windows.Forms.Padding(2);
            this.setupTab.Name = "setupTab";
            this.setupTab.Padding = new System.Windows.Forms.Padding(2);
            this.setupTab.Size = new System.Drawing.Size(501, 254);
            this.setupTab.TabIndex = 1;
            this.setupTab.Text = "Setup";
            this.setupTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 34);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.keywordsTextbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rssTextbox);
            this.splitContainer1.Size = new System.Drawing.Size(497, 218);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // keywordsTextbox
            // 
            this.keywordsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordsTextbox.Location = new System.Drawing.Point(0, 0);
            this.keywordsTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.keywordsTextbox.Multiline = true;
            this.keywordsTextbox.Name = "keywordsTextbox";
            this.keywordsTextbox.Size = new System.Drawing.Size(165, 218);
            this.keywordsTextbox.TabIndex = 0;
            this.keywordsTextbox.Text = "Stefan\r\nLöfven\r\nDonald\r\nTrump";
            // 
            // rssTextbox
            // 
            this.rssTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rssTextbox.Location = new System.Drawing.Point(0, 0);
            this.rssTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.rssTextbox.Multiline = true;
            this.rssTextbox.Name = "rssTextbox";
            this.rssTextbox.Size = new System.Drawing.Size(329, 218);
            this.rssTextbox.TabIndex = 0;
            this.rssTextbox.Text = resources.GetString("rssTextbox.Text");
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.speechStatusBox);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 32);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 32);
            this.panel1.TabIndex = 4;
            // 
            // speechStatusBox
            // 
            this.speechStatusBox.Location = new System.Drawing.Point(282, 1);
            this.speechStatusBox.Name = "speechStatusBox";
            this.speechStatusBox.ReadOnly = true;
            this.speechStatusBox.Size = new System.Drawing.Size(221, 26);
            this.speechStatusBox.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBox1.Location = new System.Drawing.Point(86, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Ignore Keywords";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keywords";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5896, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "RSS feeds";
            // 
            // IDA1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 287);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IDA1";
            this.Text = "Fancy Internet Data Acquisition";
            this.tabControl.ResumeLayout(false);
            this.newsTab.ResumeLayout(false);
            this.setupTab.ResumeLayout(false);
            this.setupTab.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage newsTab;
        private System.Windows.Forms.TabPage setupTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox keywordsTextbox;
        private System.Windows.Forms.TextBox rssTextbox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox speechStatusBox;
    }
}

