using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using Face = System.Tuple<Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3,
                          Microsoft.Xna.Framework.Vector3>;
using IDFace = System.Tuple<int, System.Tuple<Microsoft.Xna.Framework.Vector3,
                                             Microsoft.Xna.Framework.Vector3,
                                             Microsoft.Xna.Framework.Vector3>>;
using IDPoint = System.Tuple<int, Microsoft.Xna.Framework.Vector3>;
using Point = Microsoft.Xna.Framework.Vector3;

namespace GeometricComposition.GCForm
{
    public partial class ToolForm
    {
        List<IDPoint> id_points = new List<IDPoint>();
        List<IDFace> id_faces = new List<IDFace>();
        List<Tuple<IDFace, IDPoint>> face_point_pairs = new List<Tuple<IDFace, IDPoint>>();

        private void ReadVertices()
        {
            ClearData();

            List<Point> tmppts = null;
            foreach (ModelMesh mm in File.Model.Meshes)
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

        private void ClearData()
        {
            id_points.Clear();
            id_faces.Clear();
            face_point_pairs.Clear();
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
            for (int i = 0; i < id_points.Count; i++)
                for (int j = i + 1; j < id_points.Count; j++)
                    for (int k = j + 1; k < id_points.Count; k++)
                        id_faces.Add(new IDFace(fid++, new Face(id_points[i].Item2, id_points[j].Item2, id_points[k].Item2)));
            foreach (IDFace f in id_faces)
                foreach (IDPoint idp in id_points)
                    if (f.Item2.Item1 != idp.Item2 && f.Item2.Item2 != idp.Item2 && f.Item2.Item3 != idp.Item2)
                        face_point_pairs.Add(new Tuple<IDFace, IDPoint>(f, idp));
        }

        delegate void ClearCall();
        delegate int AddFPPCall(FPP fpp);
        private void DisplayPairs()
        {
            if (FacePointListBox.InvokeRequired)
                FacePointListBox.Invoke(new ClearCall(FacePointListBox.Items.Clear));
            else
                FacePointListBox.Items.Clear();

            int pid = 0;

            foreach (Tuple<IDFace, IDPoint> fpp in face_point_pairs)
                if (FacePointListBox.InvokeRequired)
                    FacePointListBox.Invoke(new AddFPPCall(FacePointListBox.Items.Add),
                        new object[] { new FPP(pid++, fpp.Item1, fpp.Item2) });
                else
                    FacePointListBox.Items.Add(new FPP(pid++, fpp.Item1, fpp.Item2));
        }
    }

    class FPP
    {
        public float DistanceThreshold { set; get; }
        public int PairID { set; get; }
        public IDFace Face { set; get; }
        public IDPoint Point { set; get; }
        public float Distance
        {
            get
            {
                Vector3 n = Vector3.Cross(Face.Item2.Item1 - Face.Item2.Item2,
                    Face.Item2.Item2 - Face.Item2.Item3);
                Vector3 l = Point.Item2 - Face.Item2.Item1;
                float d = Math.Abs(Vector3.Dot(n, l)) / n.Length();
                return d < DistanceThreshold ? 0f : d;
            }
        }

        public FPP(int pid, IDFace f, IDPoint p)
        {
            PairID = pid;
            Face = f;
            Point = p;
            DistanceThreshold = 1e-5f;
        }
        public override string ToString()
        {
            return "Pair" + PairID + ":{F:" + Face.Item1 + ",P:" + Point.Item1 + "} Dist:" + Distance;
        }
    }
}