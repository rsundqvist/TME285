using ObjectSerializerLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDimensionalVisualizationLibrary.Faces;
using ThreeDimensionalVisualizationLibrary.Objects;

namespace CartoonFaceApplication
{
    public class Head : Object3D
    {
        private const String HEAD_BASE_PATH = "";
        public Head()
        {
            Face head_base = (Face)ObjectXmlSerializer.ObtainSerializedObject(HEAD_BASE_PATH, typeof(Face));
            Eye leftEye = new Eye();
            Eye rightEye = new Eye();
            head_base.Object3DList.Add(leftEye);
            head_base.Object3DList.Add(rightEye);
        }
    }

    public class Eye : Sphere3D
    {
        public Eye()
        {
            Generate(new List<double>() { 2, 64, 64 });
            AmbientColor = Color.FromArgb(0, 255, 0);
            DiffuseColor = Color.FromArgb(0, 255, 0);
            SpecularColor = Color.White;
            Shininess = 20;
            ShowVertices = false;
            ShowWireFrame = false;
            ShowSurfaces = true;
            UseLight = true;
            //ShadingModel = ShadingModel.Smooth;
        }
    }
}
