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
            this.takePictureButton = new System.Windows.Forms.Button();
            this.cameraViewControl = new ImageProcessingLibrary.Cameras.CameraViewControl();
            this.pictureTab = new System.Windows.Forms.TabPage();
            this.imagePlot = new ImageProcessingLibrary.Visualization.ImagePlot();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cameraSetupControl = new ImageProcessingLibrary.Cameras.CameraSetupControl();
            this.toTab0Button = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.cameraTab.SuspendLayout();
            this.pictureTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.cameraTab);
            this.tabControl.Controls.Add(this.pictureTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1003, 482);
            this.tabControl.TabIndex = 0;
            // 
            // cameraTab
            // 
            this.cameraTab.Controls.Add(this.takePictureButton);
            this.cameraTab.Controls.Add(this.cameraViewControl);
            this.cameraTab.Location = new System.Drawing.Point(4, 29);
            this.cameraTab.Name = "cameraTab";
            this.cameraTab.Padding = new System.Windows.Forms.Padding(3);
            this.cameraTab.Size = new System.Drawing.Size(995, 449);
            this.cameraTab.TabIndex = 0;
            this.cameraTab.Text = "Camera";
            this.cameraTab.UseVisualStyleBackColor = true;
            // 
            // takePictureButton
            // 
            this.takePictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.takePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.takePictureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.takePictureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takePictureButton.Location = new System.Drawing.Point(852, 356);
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
            this.cameraViewControl.Size = new System.Drawing.Size(989, 443);
            this.cameraViewControl.TabIndex = 0;
            this.cameraViewControl.Load += new System.EventHandler(this.cameraViewControl_Load);
            // 
            // pictureTab
            // 
            this.pictureTab.Controls.Add(this.toTab0Button);
            this.pictureTab.Controls.Add(this.imagePlot);
            this.pictureTab.Location = new System.Drawing.Point(4, 29);
            this.pictureTab.Name = "pictureTab";
            this.pictureTab.Padding = new System.Windows.Forms.Padding(3);
            this.pictureTab.Size = new System.Drawing.Size(995, 449);
            this.pictureTab.TabIndex = 1;
            this.pictureTab.Text = "Picture";
            this.pictureTab.UseVisualStyleBackColor = true;
            // 
            // imagePlot
            // 
            this.imagePlot.BackColor = System.Drawing.Color.Black;
            this.imagePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePlot.Location = new System.Drawing.Point(3, 3);
            this.imagePlot.Name = "imagePlot";
            this.imagePlot.Size = new System.Drawing.Size(989, 443);
            this.imagePlot.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cameraSetupControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 449);
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
            this.cameraSetupControl.Size = new System.Drawing.Size(989, 443);
            this.cameraSetupControl.TabIndex = 0;
            // 
            // toTab0Button
            // 
            this.toTab0Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toTab0Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toTab0Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toTab0Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTab0Button.Location = new System.Drawing.Point(852, 356);
            this.toTab0Button.Name = "toTab0Button";
            this.toTab0Button.Size = new System.Drawing.Size(140, 90);
            this.toTab0Button.TabIndex = 3;
            this.toTab0Button.Text = "Back To Camera";
            this.toTab0Button.UseVisualStyleBackColor = true;
            this.toTab0Button.Click += new System.EventHandler(this.toTab0Button_Click);
            // 
            // FaceRecognitionMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 482);
            this.Controls.Add(this.tabControl);
            this.Name = "FaceRecognitionMainForm";
            this.Text = "Face Recognition Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.cameraTab.ResumeLayout(false);
            this.pictureTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage cameraTab;
        private System.Windows.Forms.TabPage pictureTab;
        private ImageProcessingLibrary.Cameras.CameraViewControl cameraViewControl;
        private ImageProcessingLibrary.Visualization.ImagePlot imagePlot;
        private System.Windows.Forms.Button takePictureButton;
        private System.Windows.Forms.TabPage tabPage1;
        private ImageProcessingLibrary.Cameras.CameraSetupControl cameraSetupControl;
        private System.Windows.Forms.Button toTab0Button;
    }
}

