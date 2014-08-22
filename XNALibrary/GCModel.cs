using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GeometricComposition.XNALibrary
{
    public class GCModel
    {
        private Vector3[] vertices = null;
        private Vector3[] modifiedVertices = null;
        public IEnumerable<Vector3> DistinctVertices
        {
            get
            {
                ModifyVertices();
                return modifiedVertices.Distinct();
            }
        }

        private VertexPositionNormalColor[] renderVertices = null;
        private Int16[] indices = null;

        private int primitiveCount = 0;
        private VertexBuffer vertexBuffer = null;
        private IndexBuffer indexBuffer = null;

        private GraphicsDevice device = null;
        public GCEffect Effect = null;

        private bool ModifiedModifiers = false;
        private List<ModelModifier> _modifiers = null;
        public List<ModelModifier> Modifiers
        {
            set { _modifiers = value; ModifiedModifiers = true; }
            get { return _modifiers; }
        }

        // only the first Mesh's first MeshPart will be used
        public GCModel(Model m)
        {
            if (m.Meshes.Count == 0 ||
                m.Meshes[0].MeshParts.Count == 0 ||
                m.Meshes[0].MeshParts[0].VertexBuffer == null)
                throw new ArgumentException("invalid model");
            ModelMeshPart mmp = m.Meshes[0].MeshParts[0];
            VertexBuffer vb = mmp.VertexBuffer;
            IndexBuffer ib = mmp.IndexBuffer;

            device = vb.GraphicsDevice;
            Vector3[] vers = new Vector3[vb.VertexCount];
            int offsetInBytes = 0;
            foreach (VertexElement ve in vb.VertexDeclaration.GetVertexElements())
                if (ve.VertexElementUsage == VertexElementUsage.Position)
                {
                    offsetInBytes = ve.Offset;
                    break;
                }
            vb.GetData(offsetInBytes, vers, 0, vb.VertexCount, vb.VertexDeclaration.VertexStride);
            vertices = vers;
            modifiedVertices = new Vector3[vers.Length];
            Int16[] inds = new Int16[ib.IndexCount];
            ib.GetData(inds);
            indices = inds;
            InitializeColorVertices(vers.Length);
            primitiveCount = mmp.PrimitiveCount;
            Effect = new GCEffect(device);
            vertexBuffer = new VertexBuffer(device, VertexPositionNormalColor.VertexDeclaration, vb.VertexCount, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, ib.IndexCount, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);

            Modifiers = new List<ModelModifier>();
        }

        public GCModel(GraphicsDevice gd, Vector3[] vers, Int16[] inds)
        {
            device = gd;
            vertices = vers;
            modifiedVertices = new Vector3[vers.Length];
            indices = inds;
            InitializeColorVertices(vers.Length);
            primitiveCount = inds.Length / 3;
            Effect = new GCEffect(gd);
            vertexBuffer = new VertexBuffer(gd, VertexPositionNormalColor.VertexDeclaration, vers.Length, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(gd, IndexElementSize.SixteenBits, inds.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);

            Modifiers = new List<ModelModifier>();
        }

        private void InitializeColorVertices(int len)
        {
            renderVertices = new VertexPositionNormalColor[len];
            for (int i = 0; i < len; i++)
                renderVertices[i] = new VertexPositionNormalColor(Vector3.Zero, Vector3.One, Color.White);
        }

        public void Draw()
        {
            ModifyVertices();
            ComputeNormal();

            vertexBuffer.SetData(renderVertices);
            device.SetVertexBuffer(vertexBuffer);
            device.Indices = indexBuffer;

            foreach (EffectPass pass in Effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                // TODO : TriangleList or TriangleStrip ?
                device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, renderVertices.Length, 0, primitiveCount);
            }
            device.SetVertexBuffer(null);
            device.Indices = null;
        }

        private void ComputeNormal()
        {
            for (int i = 0; i < modifiedVertices.Length; i++)
                renderVertices[i].Position = modifiedVertices[i];

            for (int i = 0; i < indices.Length / 3; i++)
            {
                Vector3 edgea = renderVertices[indices[i * 3 + 1]].Position - renderVertices[indices[i * 3]].Position;
                Vector3 edgeb = renderVertices[indices[i * 3]].Position - renderVertices[indices[i * 3 + 2]].Position;
                Vector3 normal = Vector3.Cross(edgea, edgeb);
                normal.Normalize();
                renderVertices[indices[i * 3]].Normal += normal;
                renderVertices[indices[i * 3 + 1]].Normal += normal;
                renderVertices[indices[i * 3 + 2]].Normal += normal;
            }

            for (int i = 0; i < renderVertices.Length; i++)
                renderVertices[i].Normal.Normalize();
        }

        private void ModifyVertices()
        {
            vertices.CopyTo(modifiedVertices, 0);
            bool notUpdated = ModifiedModifiers;
            foreach (ModelModifier mm in Modifiers)
            {
                notUpdated |= mm.NotUpdated;
                if (notUpdated)
                {
                    foreach (ModelModifier modifier in Modifiers)
                        modifiedVertices = modifier.Modify(modifiedVertices, 0.5f);
                    break;
                }
            }
        }
    }
}
