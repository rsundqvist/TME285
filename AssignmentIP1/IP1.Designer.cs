namespace FaceRecognitionApplication
{
    partial class IP1
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cameraTab = new System.Windows.Forms.TabPage();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.takePictureButton = new System.Windows.Forms.Button();
            this.cameraViewControl = new ImageProcessingLibrary.Cameras.CameraViewControl();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imagePlotOrig = new ImageProcessingLibrary.Visualization.ImagePlot();
            this.binaryImageTab = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.toTab0Button = new System.Windows.Forms.Button();
            this.imagePlot = new ImageProcessingLibrary.Visualization.ImagePlot();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cameraSetupControl = new ImageProcessingLibrary.Cameras.CameraSetupControl();
            this.tabControl.SuspendLayout();
            this.cameraTab.SuspendLayout();
            this.imageTab.SuspendLayout();
            this.binaryImageTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.cameraTab);
            this.tabControl.Controls.Add(this.imageTab);
            this.tabControl.Controls.Add(this.binaryImageTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1225, 640);
            this.tabControl.TabIndex = 0;
            // 
            // cameraTab
            // 
            this.cameraTab.Controls.Add(this.loadImageButton);
            this.cameraTab.Controls.Add(this.takePictureButton);
            this.cameraTab.Controls.Add(this.cameraViewControl);
            this.cameraTab.Location = new System.Drawing.Point(4, 29);
            this.cameraTab.Name = "cameraTab";
            this.cameraTab.Padding = new System.Windows.Forms.Padding(3);
            this.cameraTab.Size = new System.Drawing.Size(1217, 607);
            this.cameraTab.TabIndex = 0;
            this.cameraTab.Text = "Camera";
            this.cameraTab.UseVisualStyleBackColor = true;
            // 
            // loadImageButton
            // 
            this.loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadImageButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImageButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.loadImageButton.Location = new System.Drawing.Point(1081, 425);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(140, 90);
            this.loadImageButton.TabIndex = 3;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // takePictureButton
            // 
            this.takePictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.takePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.takePictureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.takePictureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takePictureButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.takePictureButton.Location = new System.Drawing.Point(1081, 521);
            this.takePictureButton.Name = "takePictureButton";
            this.takePictureButton.Size = new System.Drawing.Size(140, 90);
            this.takePictureButton.TabIndex = 2;
            this.takePictureButton.Text = "Take Picture";
            this.takePictureButton.UseVisualStyleBackColor = true;
            this.takePictureButton.Click += new System.EventHandler(this.takePictureButton_Click);
            // 
            // cameraViewControl
            // 
            this.cameraViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraViewControl.Location = new System.Drawing.Point(3, 3);
            this.cameraViewControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraViewControl.Name = "cameraViewControl";
            this.cameraViewControl.Size = new System.Drawing.Size(1211, 601);
            this.cameraViewControl.TabIndex = 0;
            // 
            // imageTab
            // 
            this.imageTab.Controls.Add(this.button2);
            this.imageTab.Controls.Add(this.button1);
            this.imageTab.Controls.Add(this.imagePlotOrig);
            this.imageTab.Location = new System.Drawing.Point(4, 29);
            this.imageTab.Name = "imageTab";
            this.imageTab.Padding = new System.Windows.Forms.Padding(3);
            this.imageTab.Size = new System.Drawing.Size(1217, 607);
            this.imageTab.TabIndex = 3;
            this.imageTab.Text = "Image";
            this.imageTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1081, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 90);
            this.button2.TabIndex = 5;
            this.button2.Text = "View Binary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1081, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 90);
            this.button1.TabIndex = 4;
            this.button1.Text = "Back To Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.toTab0Button_Click);
            // 
            // imagePlotOrig
            // 
            this.imagePlotOrig.BackColor = System.Drawing.Color.Black;
            this.imagePlotOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePlotOrig.Location = new System.Drawing.Point(3, 3);
            this.imagePlotOrig.Name = "imagePlotOrig";
            this.imagePlotOrig.Size = new System.Drawing.Size(1211, 601);
            this.imagePlotOrig.TabIndex = 0;
            // 
            // binaryImageTab
            // 
            this.binaryImageTab.Controls.Add(this.button3);
            this.binaryImageTab.Controls.Add(this.toTab0Button);
            this.binaryImageTab.Controls.Add(this.imagePlot);
            this.binaryImageTab.Location = new System.Drawing.Point(4, 29);
            this.binaryImageTab.Name = "binaryImageTab";
            this.binaryImageTab.Padding = new System.Windows.Forms.Padding(3);
            this.binaryImageTab.Size = new System.Drawing.Size(1217, 607);
            this.binaryImageTab.TabIndex = 1;
            this.binaryImageTab.Text = "Binary Image";
            this.binaryImageTab.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1081, 425);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 90);
            this.button3.TabIndex = 4;
            this.button3.Text = "View Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toTab0Button
            // 
            this.toTab0Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toTab0Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toTab0Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toTab0Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTab0Button.Location = new System.Drawing.Point(1081, 521);
            this.toTab0Button.Name = "toTab0Button";
            this.toTab0Button.Size = new System.Drawing.Size(140, 90);
            this.toTab0Button.TabIndex = 3;
            this.toTab0Button.Text = "Back To Camera";
            this.toTab0Button.UseVisualStyleBackColor = true;
            this.toTab0Button.Click += new System.EventHandler(this.toTab0Button_Click);
            // 
            // imagePlot
            // 
            this.imagePlot.BackColor = System.Drawing.Color.Black;
            this.imagePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePlot.Location = new System.Drawing.Point(3, 3);
            this.imagePlot.Name = "imagePlot";
            this.imagePlot.Size = new System.Drawing.Size(1211, 601);
            this.imagePlot.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cameraSetupControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1217, 607);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Camera Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cameraSetupControl
            // 
            this.cameraSetupControl.AutoSize = true;
            this.cameraSetupControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cameraSetupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraSetupControl.Location = new System.Drawing.Point(3, 3);
            this.cameraSetupControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cameraSetupControl.Name = "cameraSetupControl";
            this.cameraSetupControl.Size = new System.Drawing.Size(1211, 601);
            this.cameraSetupControl.TabIndex = 0;
            // 
            // IP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 640);
            this.Controls.Add(this.tabControl);
            this.Name = "IP1";
            this.Text = "Face Recognition Application";
            this.tabControl.ResumeLayout(false);
            this.cameraTab.ResumeLayout(false);
            this.imageTab.ResumeLayout(false);
            this.binaryImageTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage cameraTab;
        private System.Windows.Forms.TabPage binaryImageTab;
        private ImageProcessingLibrary.Cameras.CameraViewControl cameraViewControl;
        private ImageProcessingLibrary.Visualization.ImagePlot imagePlot;
        private System.Windows.Forms.Button takePictureButton;
        private System.Windows.Forms.TabPage tabPage1;
        private ImageProcessingLibrary.Cameras.CameraSetupControl cameraSetupControl;
        private System.Windows.Forms.Button toTab0Button;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.TabPage imageTab;
        private ImageProcessingLibrary.Visualization.ImagePlot imagePlotOrig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

