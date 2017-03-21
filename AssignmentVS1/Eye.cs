using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using ThreeDimensionalVisualizationLibrary.Objects;

namespace VS1
{
    class Eye : Object3D
    {
        private const double AnimationStepLength = 0.1;
        private const int SleepDuration = 20;

        private readonly Sphere3D _eyeball, _iris, _pupil;
        private readonly SphereSegment3D _lid;
        private readonly TorusSector3D _eyeBrow;

        public Eye(string name, int sgn)
        {
            Object3DList = new List<Object3D>();

            //Body
            _eyeball = new Sphere3D { Object3DList = new List<Object3D>() };
            _eyeball.Generate(new List<double> { 0.105, 32, 32 });
            _eyeball.AmbientColor = Color.FromArgb(255, 255, 255);
            _eyeball.DiffuseColor = Color.FromArgb(255, 255, 255);
            _eyeball.SpecularColor = Color.White;
            _eyeball.Shininess = 20;
            _eyeball.Name = name;
            _eyeball.Move(sgn * 0.20, 0.4, 0.7);

            //Iris
            _iris = new Sphere3D { Object3DList = new List<Object3D>() };
            _iris.Generate(new List<double> { 0.06, 32, 32 });
            _iris.AmbientColor = Color.FromArgb(0, 0, 255);
            _iris.DiffuseColor = Color.FromArgb(0, 0, 255);
            _iris.SpecularColor = Color.Blue;
            _iris.Move(0, 0.05, 0);

            //Pupil
            _pupil = new Sphere3D();
            _pupil.Generate(new List<double> { .03, 32, 32 });
            _pupil.AmbientColor = Color.FromArgb(0, 0, 0);
            _pupil.DiffuseColor = Color.FromArgb(0, 0, 0);
            _pupil.SpecularColor = Color.Black;
            _pupil.Move(0, 0.035, 0);
            _pupil.Shininess = 20;

            //Eyelid
            _lid = new SphereSegment3D();
            _lid.Generate(new List<double> { 0.108, 32, 32, .01 });
            _lid.AmbientColor = Color.DarkSalmon;
            _lid.DiffuseColor = Color.Black;
            _lid.SpecularColor = Color.DarkSalmon;
            _lid.Move(sgn * 0.20, 0.4, 0.7); //Same as eyeball
            _lid.Move(sgn * 0.01, 0.016, 0);
            _lid.RotateX(40);
            _lid.RotateZ(-sgn * 25);

            //Eyebrow - not part of eyeball
            _eyeBrow = new TorusSector3D();
            _eyeBrow.Generate(new List<double>() { 0.15, 0.02, 32, 32, 0, Math.PI });
            _eyeBrow.AmbientColor = Color.DeepPink;
            _eyeBrow.DiffuseColor = Color.DeepPink;
            _eyeBrow.SpecularColor = Color.DeepPink;
            _eyeBrow.Move(sgn*0.2, 0.3, 0.8);
            _eyeBrow.RotateY(-sgn*25);
            _eyeBrow.RotateX(15);

            //Setup
            Object3DList.Add(_eyeball);
            Object3DList.Add(_lid);
            Object3DList.Add(_eyeBrow);
            _eyeball.Object3DList.Add(_iris);
            _iris.Object3DList.Add(_pupil);
        }

        public void Blink(double t)
        {
            int n = (int)(0.5 * t / AnimationStepLength + 0.5);
            double dx = 130.0 / n;
            //Close
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i);
                _lid.RotateX(-dx);
                Thread.Sleep(SleepDuration);
            }

            //Open
            for (int i = 0; i < n; i++)
            {
                _lid.RotateX(dx);
                Thread.Sleep(SleepDuration);
            }
        }

        public TorusSector3D GetEyebrow()
        {
            return _eyeBrow;
        }

        public void Look(double d, int sgn)
        {
            int n = (int)(0.5 * d / AnimationStepLength + 0.5);
            double dz = 45.0 / n;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i);
                _eyeball.RotateZ(sgn*dz);
                Thread.Sleep(SleepDuration);
            }

            Thread.Sleep(SleepDuration*100);
            for (int i = 0; i < n; i++)
            {
                _eyeball.RotateZ(-sgn*dz);
                Thread.Sleep(SleepDuration);
            }
        }
    }
}
