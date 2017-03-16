using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeDimensionalVisualizationLibrary;
using ThreeDimensionalVisualizationLibrary.Objects;
using OpenTK.Graphics.OpenGL;

namespace VS1
{
    public partial class Vs1 : Form
    {
        private readonly Head _head;
        public Vs1()
        {
            InitializeComponent();
            Scene3D scene = new Scene3D();
            scene.LightList.Add(Light());
            _head = new Head();
            scene.ObjectList.Add(_head);
            viewer.Scene = scene;
            viewer.StartAnimation();
        }

        private Light Light()
        {
            Light light = new Light
            {
                Position =
                {
                    [0] = 5,
                    [1] = 2,
                    [2] = 5
                },
                IsOn = true
            };
            return light;
        }

        // ---- ==== ---- ==== ---- ==== ---- ==== ---- ==== ---- //
        //                    Action Listeners                    //
        // ---- ==== ---- ==== ---- ==== ---- ==== ---- ==== ---- //

        // ====================================================== //
        // Direct Control                                         // 
        // ====================================================== //
        private void blinkButton_Click(object sender, EventArgs e)
        {
            Blink();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Yes();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            No();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            LookLeft();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            LookRight();
        }

        // ====================================================== //
        // Facial Expressions                                     //
        // ====================================================== //
        private void happyButton_Click(object sender, EventArgs e)
        {
            Happy();
        }

        private void sadButton_Click(object sender, EventArgs e)
        {
            Sad();
        }

        // ---- ==== ---- ==== ---- ==== ---- ==== ---- ==== ---- //
        //                        Animation                       //
        // ---- ==== ---- ==== ---- ==== ---- ==== ---- ==== ---- //

        private void Reset()
        {

        }

        // ====================================================== //
        // Direct Control                                         // 
        // ====================================================== //
        private void Blink()
        {
            Console.WriteLine("Blink");
            _head.Blink(5);
        }

        private void Yes()
        {
            Console.WriteLine("Yes");
        }

        private void No()
        {
            Console.WriteLine("No");
            _head.No(5, 3);
        }

        private void LookLeft()
        {
            Console.WriteLine("Look Left");
        }

        private void LookRight()
        {
            Console.WriteLine("Look Right");
        }

        // ====================================================== //
        // Facial Expressions                                     //
        // ====================================================== //

        private void Happy()
        {
            Console.WriteLine("Happy");

        }

        private void Sad()
        {
            Console.WriteLine("Happy");

        }
    }
}
