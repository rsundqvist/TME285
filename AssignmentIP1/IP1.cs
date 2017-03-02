using ImageProcessingLibrary.Cameras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FaceRecognitionApplication
{

    public partial class IP1 : Form
    {
        #region constants
        //private const int DEFAULT_EXPOSURE = -4;
        private const int DefaultWidth = 640;
        private const int DefaultHeight = 480;
        private const int DefaultFrameRate = 25;
        #endregion

        #region fields
        private readonly Camera _camera;
        #endregion

        public IP1()
        {
            InitializeComponent();
            _camera = new Camera();
            LoadDeviceName(_camera);
            _camera.ImageWidth = DefaultWidth;
            _camera.ImageHeight = DefaultHeight;
            _camera.FrameRate = DefaultFrameRate;
            //Default to exposure value which happens to work well for my laptop in good lightning conditions.
            _camera.Start();
            //_camera.CaptureDevice.SetCameraControlProperty(DirectShowLib.CameraControlProperty.Exposure, DEFAULT_EXPOSURE);

            cameraViewControl.SetCamera(_camera);
            cameraViewControl.Start();

            cameraSetupControl.SetCamera(_camera);
        }

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = _camera.GetBitmap();
            ImageTaken(bitmap);
        }

        private void toTab0Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
        }

        private static void LoadDeviceName(Camera camera)
        {
            List<string> devices = CaptureDevice.GetDeviceNames();

            if (devices.Count > 0)
            {
                camera.DeviceName = CaptureDevice.GetDeviceNames()[0];
            }
            else
            {
                System.Console.WriteLine("Exiting: No camera found.");
                Environment.Exit(-1);
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
            }
            Image image = Image.FromFile(openFileDialog.FileName);
            ImageTaken(new Bitmap(image));
        }

        private void ImageTaken(Bitmap bitmap)
        {   
            //Process
            AugmentedImageProcessor ip = new AugmentedImageProcessor(bitmap);
            Tuple<int, int, int, int> bounds = ip.FindSkinPixelsChenLin();
            ip.Release();
            Bitmap processedBitmap = ip.Bitmap;
            imagePlot.SetImage(processedBitmap);

            //Orig + box
            AugmentedImageProcessor ipBox = new AugmentedImageProcessor(bitmap);
            ipBox.DrawRect(bounds, 20);
            ipBox.Release();
            imagePlotOrig.SetImage(ipBox.Bitmap);

            tabControl.SelectTab(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(2);
        }
    }
}
