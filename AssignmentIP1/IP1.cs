using ImageProcessingLibrary;
using ImageProcessingLibrary.Cameras;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FaceRecognitionApplication
{

    public partial class IP1 : Form
    {
        private const int DEFAULT_EXPOSURE = -4;
        #region constants
        private const int DEFAULT_WIDTH = 640;
        private const int DEFAULT_HEIGHT = 480;
        private const int DEFAULT_FRAME_RATE = 25;
        #endregion

        #region fields
        private readonly Camera camera;
        private int width = DEFAULT_WIDTH;
        private int height = DEFAULT_HEIGHT;
        private int frameRate = DEFAULT_FRAME_RATE;
        #endregion

        public IP1()
        {
            InitializeComponent();
            camera = new Camera();
            LoadDeviceName(camera);
            camera.ImageWidth = width;
            camera.ImageHeight = height;
            camera.FrameRate = frameRate;
            //Default to exposure value which happens to work well for my laptop in good lightning conditions.
            camera.Start();
            camera.CaptureDevice.SetCameraControlProperty(DirectShowLib.CameraControlProperty.Exposure, DEFAULT_EXPOSURE);

            cameraViewControl.SetCamera(camera);
            cameraViewControl.Start();

            cameraSetupControl.SetCamera(camera);
        }

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            Bitmap cameraBitmap = camera.GetBitmap();
            Bitmap processedBitmap = Foo(cameraBitmap);
            imagePlot.SetImage(processedBitmap);
            tabControl.SelectTab(1);
        }

        private void toTab0Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
        }

        private Bitmap Foo(Bitmap bitmap)
        {
            AugmentedImageProcessor ip = new AugmentedImageProcessor(bitmap);
            ip.FindHairPixelsChenLin();
            ip.Release();
            return ip.Bitmap;
        }


        private static void LoadDeviceName(Camera camera)
        {
            try
            {
                camera.DeviceName = CaptureDevice.GetDeviceNames()[0];
            }
            catch (IndexOutOfRangeException)
            {
                System.Console.WriteLine("Exiting: No camera found.");
                Environment.Exit(-1);
            }
        }
        #region empty methods
        private void Form1_Load(object sender, EventArgs e)
        {
            // Nothing here.
        }
        private void cameraViewControl_Load(object sender, EventArgs e)
        {
            // Nothing here.
        }

        private void cameraSetupControl_Load(object sender, EventArgs e)
        {
            // Nothing here.
        }
        #endregion
    }
}
