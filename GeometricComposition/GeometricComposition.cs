using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using Point = Microsoft.Xna.Framework.Vector3;
using Face = System.Tuple<Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3>;

using IDPoint = System.Tuple<int,Microsoft.Xna.Framework.Vector3>;
using IDFace = System.Tuple<int,System.Tuple<Microsoft.Xna.Framework.Vector3,
                                             Microsoft.Xna.Framework.Vector3,
                                             Microsoft.Xna.Framework.Vector3>>;

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
            GenerateFacePointPairs();
            DisplayPairs();
        }

        class FPP
        {
            public int PairID { set; get; }
            public IDFace Face { set; get; }
            public IDPoint Point { set; get; }
            public FPP(int pid, IDFace f, IDPoint p)
            {
                PairID = pid;
                Face = f;
                Point = p;
            }
            public override string ToString()
            {
                return "Pair" + PairID + ":{F:" + Face.Item1 + ",P:" + Point.Item1 + "}";
            }
        }
        private void DisplayPairs()
        {
            int pid = 0;
            foreach (Tuple<IDFace, IDPoint> fpp in face_point_pairs)
                FacePointListBox.Items.Add(new FPP(pid++, fpp.Item1, fpp.Item2));
        }

        List<IDPoint> id_points = new List<IDPoint>();
        List<IDFace> faces = new List<IDFace>();
        List<Tuple<IDFace, IDPoint>> face_point_pairs = new List<Tuple<IDFace, IDPoint>>();

        private void ReadVertices()
        {
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
                int id = 0;
                foreach (Point p in tmppts.Distinct())
                    id_points.Add(new IDPoint(id++, p));
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

        private void GenerateFacePointPairs()
        {
            int fid = 0;
            faces.Clear();
            for (int i = 0; i < id_points.Count; i++)
                for (int j = i + 1; j < id_points.Count; j++)
                    for (int k = j + 1; k < id_points.Count; k++)
                        faces.Add(new IDFace(fid++, new Face(id_points[i].Item2, id_points[j].Item2, id_points[k].Item2)));
            face_point_pairs.Clear();
            foreach (IDFace f in faces)
                foreach (IDPoint idp in id_points)
                    if (f.Item2.Item1 != idp.Item2 && f.Item2.Item2 != idp.Item2 && f.Item2.Item3 != idp.Item2)
                        face_point_pairs.Add(new Tuple<IDFace, IDPoint>(f, idp));
        }
    }
}
