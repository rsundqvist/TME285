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

        private void NoLoop(double d, int shakes)
        {
            for (int i = 0; i < shakes; i++)
            {
                for (j = 0; j < )
            }
        }
    }
}
