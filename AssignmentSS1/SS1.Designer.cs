namespace FormatSpeechDemo
{
    partial class Ss1
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
            this.wordBox = new System.Windows.Forms.ListBox();
            this.sentenceBox = new System.Windows.Forms.ListBox();
            this.speakSentenceButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.speakWordButton = new System.Windows.Forms.Button();
            this.numWordsTextbox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wordBox
            // 
            this.wordBox.FormattingEnabled = true;
            this.wordBox.Location = new System.Drawing.Point(5, 77);
            this.wordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(223, 225);
            this.wordBox.TabIndex = 1;
            this.wordBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AddSentenceWord);
            // 
            // sentenceBox
            // 
            this.sentenceBox.FormattingEnabled = true;
            this.sentenceBox.Location = new System.Drawing.Point(234, 77);
            this.sentenceBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentenceBox.Name = "sentenceBox";
            this.sentenceBox.Size = new System.Drawing.Size(223, 225);
            this.sentenceBox.TabIndex = 2;
            this.sentenceBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RemoveSentenceWord);
            // 
            // speakSentenceButton
            // 
            this.speakSentenceButton.Enabled = false;
            this.speakSentenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speakSentenceButton.Location = new System.Drawing.Point(234, 304);
            this.speakSentenceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.speakSentenceButton.Name = "speakSentenceButton";
            this.speakSentenceButton.Size = new System.Drawing.Size(222, 40);
            this.speakSentenceButton.TabIndex = 3;
            this.speakSentenceButton.Text = "Speak Sentence";
            this.speakSentenceButton.UseVisualStyleBackColor = true;
            this.speakSentenceButton.Click += new System.EventHandler(this.SpeakSentence);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 25);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(449, 31);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Click a word in the left box to add it to the sentence to be spoken. Click a word" +
    " in the right box to remove the word from the sentence.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Available words";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sentence";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // load
            // 
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(107, 22);
            this.load.Text = "Load Synthesizer";
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // speakWordButton
            // 
            this.speakWordButton.Enabled = false;
            this.speakWordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speakWordButton.Location = new System.Drawing.Point(8, 304);
            this.speakWordButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.speakWordButton.Name = "speakWordButton";
            this.speakWordButton.Size = new System.Drawing.Size(222, 40);
            this.speakWordButton.TabIndex = 10;
            this.speakWordButton.Text = "Speak Word";
            this.speakWordButton.UseVisualStyleBackColor = true;
            this.speakWordButton.Click += new System.EventHandler(this.SingleWord);
            // 
            // numWordsTextbox
            // 
            this.numWordsTextbox.Location = new System.Drawing.Point(157, 55);
            this.numWordsTextbox.Name = "numWordsTextbox";
            this.numWordsTextbox.ReadOnly = true;
            this.numWordsTextbox.Size = new System.Drawing.Size(71, 20);
            this.numWordsTextbox.TabIndex = 11;
            // 
            // Ss1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 352);
            this.Controls.Add(this.numWordsTextbox);
            this.Controls.Add(this.speakWordButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.speakSentenceButton);
            this.Controls.Add(this.sentenceBox);
            this.Controls.Add(this.wordBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Ss1";
            this.Text = "Format Speech Synthesis - DEMO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox wordBox;
        private System.Windows.Forms.ListBox sentenceBox;
        private System.Windows.Forms.Button speakSentenceButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.Button speakWordButton;
        private System.Windows.Forms.TextBox numWordsTextbox;
    }
}

