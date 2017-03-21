using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectSerializerLibrary;
using ThreeDimensionalVisualizationLibrary.Faces;
using ThreeDimensionalVisualizationLibrary.Objects;

namespace VS1
{
    class Head : Object3D
    {
        private readonly Eye _leftEye, _rightEye;
        private const double AnimationStepLength = 0.1;
        private const int SleepDuration = 20;

        public Head()
        {
            Object3DList = new List<Object3D>();

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "..\\..\\..\\head.xml";
            Face face = (Face)ObjectXmlSerializer.ObtainSerializedObject(path, typeof(Face));
            face.Name = "face";
            face.Generate(new List<double> { 512 });
            face.ShowWireFrame = false;
            face.ShowSurfaces = true;
            face.Visible = true;
            face.SpecularColor = System.Drawing.Color.Bisque;
            face.Object3DList = new List<Object3D>();

            _leftEye = new Eye("leftEye", 1);
            _rightEye = new Eye("rightEye", -1);

            Object3DList.Add(face);
            Object3DList.Add(_leftEye);
            Object3DList.Add(_rightEye);
        }

        public void Blink(double d)
        {
            Thread t1 = new Thread(() => _leftEye.Blink(d));
            Thread t2 = new Thread(() => _rightEye.Blink(d));
            t1.Start();
            t2.Start();
        }

        public void No(double d, int shakes)
        {
            Thread t = new Thread(() => NoLoop(d, shakes));
            t.Start();
        }

        public void LookLeft(double d)
        {
            Thread t1 = new Thread(() => _leftEye.Look(d, 1));
            Thread t2 = new Thread(() => _rightEye.Look(d, 1));
            t1.Start();
            t2.Start();
        }

        public void LookRight(double d)
        {
            Thread t1 = new Thread(() => _leftEye.Look(d, -1));
            Thread t2 = new Thread(() => _rightEye.Look(d, -1));
            t1.Start();
            t2.Start();
        }

        private void NoLoop(double t, int shakes)
        {
            int n = (int)(0.5 * t / AnimationStepLength + 0.5);
            double dz = 90.0 / n;

            for (int i = 0; i < shakes; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    RotateZ(dz);
                    Thread.Sleep(SleepDuration);
                }
                for (int j = -n; j < n; j++)
                {
                    RotateZ(-dz);
                    Thread.Sleep(SleepDuration);
                }
                for (int j = 0; j < n; j++)
                {
                    RotateZ(dz);
                    Thread.Sleep(SleepDuration);
                }
            }
        }

        public void Yes(double d, int shakes)
        {
            Thread t = new Thread(() => YesLoop(d, shakes));
            t.Start();
        }

        private void YesLoop(double t, int shakes)
        {
            int n = (int)(0.5 * t / AnimationStepLength + 0.5);
            int nUp = (int)(n * 1.3 + 0.5);
            double dx = 45.0 / n;

            for (int i = 0; i < shakes; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    RotateX(-dx);
                    Thread.Sleep(SleepDuration);
                }
                for (int j = 0; j < nUp; j++)
                {
                    RotateX(dx);
                    Thread.Sleep(SleepDuration);
                }

                for (int j = 0; j < nUp - n; j++)
                {
                    RotateX(-dx);
                    Thread.Sleep(SleepDuration);
                }
            }
        }

        internal void Sad()
        {
            Yes(15, 1);
            Blink(15);
            TorusSector3D leftBrow = _leftEye.GetEyebrow();
            TorusSector3D rightBrow = _rightEye.GetEyebrow();

            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    leftBrow.RotateY(-0.25);
                    rightBrow.RotateY(0.25);
                    leftBrow.Move(-0.001, 0, 0);
                    rightBrow.Move(0.001, 0, 0);
                    Thread.Sleep(10);
                }
                Thread.Sleep(1000);
                for (int i = 0; i < 100; i++)
                {
                    leftBrow.RotateY(0.25);
                    rightBrow.RotateY(-0.25);
                    leftBrow.Move(0.001, 0, 0);
                    rightBrow.Move(-0.001, 0, 0);
                    Thread.Sleep(10);
                }
            });
            t.Start();
        }
    }
}
