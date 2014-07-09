using GeometricComposition.GCMath;
using GeometricComposition.GCMusic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DataForm
    {
        private List<GCPoint> points = new List<GCPoint>();
        private List<GCFace> faces = new List<GCFace>();
        private List<GCFacePointPair> fpps = new List<GCFacePointPair>();

        private void ClearData()
        {
            points.Clear();
            faces.Clear();
            fpps.Clear();
            ClearPairsTree();
        }

        private void ClearPairsTree()
        {
            if (FacePointTreeView.InvokeRequired)
                FacePointTreeView.Invoke((Action)(() => { FacePointTreeView.Nodes.Clear(); }));
            else
                FacePointTreeView.Nodes.Clear();
        }

        private void ReadVertices(GCFile file)
        {
            List<Vector3> tmppts = null;
            if (file.Model == null)
                return;
            foreach (ModelMesh mm in file.Model.Meshes)
                foreach (ModelMeshPart mmp in mm.MeshParts)
                {
                    long psize = mmp.VertexBuffer.VertexDeclaration.VertexStride / sizeof(float);
                    float[] pcs = new float[mmp.VertexBuffer.VertexCount * psize];
                    mmp.VertexBuffer.GetData(pcs);
                    GetPositions(pcs, mmp.VertexBuffer.VertexDeclaration, out tmppts);
                }
            int id = 0;
            foreach (Vector3 p in tmppts.Distinct())
                points.Add(new GCPoint(file.PitchMap[id++], p));
        }

        private void GetPositions(float[] pcs, VertexDeclaration vd, out List<Vector3> tmp)
        {
            tmp = new List<Vector3>();
            int psize = vd.VertexStride / sizeof(float);
            int offset = 0;

            foreach (VertexElement ve in vd.GetVertexElements())
                if (ve.VertexElementUsage == VertexElementUsage.Position)
                {
                    offset = ve.Offset;
                    break;
                }

            for (long i = 0; i < pcs.LongLength; i += psize)
                tmp.Add(new Vector3(pcs[i + offset], pcs[i + offset + 1], pcs[i + offset + 2]));
        }

        private void GenerateFaces()
        {
            int fid = 0;
            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                    for (int k = j + 1; k < points.Count; k++)
                        faces.Add(new GCFace(fid++, points[i], points[j], points[k]));
        }

        private void GenerateFacePointPairs()
        {
            foreach (GCFace f in faces)
                foreach (GCPoint p in points)
                    if (f.PointA != p && f.PointB != p && f.PointC != p)
                        fpps.Add(new GCFacePointPair(f, p));
        }

        private void SortFacePointPairs(SortFPPOptions t)
        {
            switch (t)
            {
                case SortFPPOptions.PointID:
                    fpps.Sort(ComparePairsPointID);
                    break;
                case SortFPPOptions.FaceID:
                    fpps.Sort(ComparePairsFaceID);
                    break;
                case SortFPPOptions.Distance:
                    fpps.Sort(ComparePairsDistance);
                    break;
                default:
                    throw new ArgumentException("Unknown SortFPPOptions Type");
            }
        }

        private void DisplayPairsTreeInvoke()
        {
            FacePointTreeView.Invoke((Action)SuspendLayout);
            switch (SortFPPTypeA)
            {
                case SortFPPOptions.PointID:
                    SortFacePointPairs(SortFPPOptions.PointID);
                    GenerateTreeNodes("P", "FD", GetChildNodesByPitch, ComparePairsDistance);
                    break;
                case SortFPPOptions.Distance:
                    SortFacePointPairs(SortFPPOptions.Distance);
                    GenerateTreeNodes("D", "PF", GetChildNodesByDistance, ComparePairsPointID);
                    break;
                case SortFPPOptions.FaceID: break;
                default: break;
            }
            FacePointTreeView.Invoke((Action)ResumeLayout);
        }

        private void GenerateTreeNodes(string rootFormat, string childFormat,
            FuncRef<int, string, List<TreeNode>> getChildNodes,
            Func<GCFacePointPair, GCFacePointPair, int> comparePairs)
        {
            int i = 0;
            while (i < fpps.Count)
            {
                TreeNode rootNode = new TreeNode(fpps[i].ToString(rootFormat));
                List<TreeNode> childNodes = getChildNodes(ref i, childFormat);
                childNodes.Sort((TreeNode a, TreeNode b) =>
                { return comparePairs((GCFacePointPair)a.Tag, (GCFacePointPair)b.Tag); });
                rootNode.Nodes.AddRange(childNodes.ToArray());
                FacePointTreeView.Invoke((Func<TreeNode, int>)(FacePointTreeView.Nodes.Add), 
                    new object[] { rootNode });
            }
        }

        private List<TreeNode> GetChildNodesByPitch(ref int index, string format)
        {
            List<TreeNode> childNodes = new List<TreeNode>();
            GCPitch curr = fpps[index].Point.ID;
            while (index < fpps.Count && fpps[index].Point.ID == curr)
            {
                TreeNode node = new TreeNode(fpps[index].ToString(format));
                node.Tag = fpps[index];
                childNodes.Add(node);
                index++;
            }
            return childNodes;
        }

        private List<TreeNode> GetChildNodesByDistance(ref int index, string format)
        {
            List<TreeNode> childNodes = new List<TreeNode>();
            float curr = fpps[index].Distance;
            while (index < fpps.Count && Math.Abs(fpps[index].Distance - curr) < 1e-6f)
            {
                TreeNode node = new TreeNode(fpps[index].ToString(format));
                node.Tag = fpps[index];
                childNodes.Add(node);
                index++;
            }
            return childNodes;
        }

        private void DisplayPairsTree()
        {
            throw new NotImplementedException();
        }

        private void DisplayPairsTree(FPPCache cache)
        {
            cache.CopyTo(fpps);
            DisplayPairsTreeInvoke();
        }

        private int ComparePairsPointID(GCFacePointPair a, GCFacePointPair b)
        { return (int)a.Point.ID - (int)b.Point.ID; }
        private int ComparePairsFaceID(GCFacePointPair a, GCFacePointPair b)
        { return (int)a.Face.ID - (int)b.Face.ID; }
        private int ComparePairsDistance(GCFacePointPair a, GCFacePointPair b)
        { return Math.Sign(a.Distance - b.Distance); }
    }

    public enum SortFPPOptions
    {
        PointID,
        FaceID,
        Distance
    }
}