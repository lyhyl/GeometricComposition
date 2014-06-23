using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using Point = Microsoft.Xna.Framework.Vector3;
using Face = System.Tuple<Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3>;

namespace GeometricComposition
{
    public partial class GeometricComposition : Form
    {
        public GeometricComposition()
        {
            InitializeComponent();
        }

        private void FacePointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            ReadVertices();
            GeneratePairs();
            DisplayPairs();
        }

        private void DisplayPairs()
        {
            FacePointListBox.Items.AddRange(face_point_pairs.ToArray());
        }

        List<Point> points = new List<Point>();
        List<Face> faces = new List<Face>();
        List<Tuple<Face, Point>> face_point_pairs = new List<Tuple<Face, Point>>();

        private void ReadVertices()
        {
            points.Clear();
            List<Point> tmppts = null;
            foreach (ModelMesh mm in mvc.Model.Meshes)
                foreach (ModelMeshPart mmp in mm.MeshParts)
                {
                    long psize = mmp.VertexBuffer.VertexDeclaration.VertexStride / sizeof(float);
                    float[] pcs = new float[mmp.VertexBuffer.VertexCount * psize];
                    mmp.VertexBuffer.GetData(pcs);
                    GetPositions(ref pcs, mmp.VertexBuffer.VertexDeclaration, out tmppts);
                }
            if (tmppts != null)
            {
                points.AddRange(tmppts.Distinct());
                tmppts = null;
            }
        }

        private void GetPositions(ref float[] pcs, VertexDeclaration vd, out List<Point> tmp)
        {
            tmp = new List<Point>();
            int psize = vd.VertexStride / sizeof(float);
            int offset = 0;

            foreach (VertexElement ve in vd.GetVertexElements())
                if (ve.VertexElementUsage == VertexElementUsage.Position)
                {
                    offset = ve.Offset;
                    break;
                }

            for (long i = 0; i < pcs.LongLength; i += psize)
                tmp.Add(new Point(pcs[i + offset], pcs[i + offset + 1], pcs[i + offset + 2]));
        }

        private void GeneratePairs()
        {
            faces.Clear();
            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                    for (int k = j + 1; k < points.Count; k++)
                        faces.Add(new Face(points[i], points[j], points[k]));
            face_point_pairs.Clear();
            foreach (var f in faces)
                foreach (Point p in points)
                    if (f.Item1 != p && f.Item2 != p && f.Item3 != p)
                        face_point_pairs.Add(new Tuple<Face, Point>(f, p));
        }
    }
}
