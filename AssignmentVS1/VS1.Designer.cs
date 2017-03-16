namespace VS1
{
    partial class Vs1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vs1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sadButton = new System.Windows.Forms.Button();
            this.happyButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.blinkButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.viewer = new ThreeDimensionalVisualizationLibrary.Viewer3D();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sadButton);
            this.panel1.Controls.Add(this.happyButton);
            this.panel1.Controls.Add(this.rightButton);
            this.panel1.Controls.Add(this.noButton);
            this.panel1.Controls.Add(this.leftButton);
            this.panel1.Controls.Add(this.blinkButton);
            this.panel1.Controls.Add(this.yesButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(489, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 476);
            this.panel1.TabIndex = 0;
            // 
            // sadButton
            // 
            this.sadButton.Location = new System.Drawing.Point(20, 275);
            this.sadButton.Name = "sadButton";
            this.sadButton.Size = new System.Drawing.Size(120, 30);
            this.sadButton.TabIndex = 7;
            this.sadButton.Text = "Sad";
            this.sadButton.UseVisualStyleBackColor = true;
            this.sadButton.Click += new System.EventHandler(this.sadButton_Click);
            // 
            // happyButton
            // 
            this.happyButton.Location = new System.Drawing.Point(20, 239);
            this.happyButton.Name = "happyButton";
            this.happyButton.Size = new System.Drawing.Size(120, 30);
            this.happyButton.TabIndex = 6;
            this.happyButton.Text = "Happy";
            this.happyButton.UseVisualStyleBackColor = true;
            this.happyButton.Click += new System.EventHandler(this.happyButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(20, 156);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(120, 30);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "Look Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(20, 84);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(120, 30);
            this.noButton.TabIndex = 4;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(20, 120);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(120, 30);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "Look Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // blinkButton
            // 
            this.blinkButton.Location = new System.Drawing.Point(20, 12);
            this.blinkButton.Name = "blinkButton";
            this.blinkButton.Size = new System.Drawing.Size(120, 30);
            this.blinkButton.TabIndex = 2;
            this.blinkButton.Text = "Blink";
            this.blinkButton.UseVisualStyleBackColor = true;
            this.blinkButton.Click += new System.EventHandler(this.blinkButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(20, 48);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(120, 30);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // viewer
            // 
            this.viewer.BackColor = System.Drawing.Color.Black;
            this.viewer.CameraDistance = 4D;
            this.viewer.CameraLatitude = 0.39269908169872414D;
            this.viewer.CameraLongitude = 0.78539816339744828D;
            this.viewer.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("viewer.CameraTarget")));
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Scene = null;
            this.viewer.ShowSurfaces = true;
            this.viewer.ShowVertices = false;
            this.viewer.ShowWireframe = false;
            this.viewer.ShowWorldAxes = false;
            this.viewer.Size = new System.Drawing.Size(489, 476);
            this.viewer.TabIndex = 1;
            this.viewer.UseSmoothShading = false;
            this.viewer.VSync = false;
            // 
            // VS1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 476);
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.panel1);
            this.Name = "VS1";
            this.Text = "VS1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button sadButton;
        private System.Windows.Forms.Button happyButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button blinkButton;
        private System.Windows.Forms.Button yesButton;
        private ThreeDimensionalVisualizationLibrary.Viewer3D viewer;
    }
}

