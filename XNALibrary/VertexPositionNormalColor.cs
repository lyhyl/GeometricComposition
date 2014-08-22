using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricComposition.XNALibrary
{
    public struct VertexPositionNormalColor
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector4 Color;
        public VertexPositionNormalColor(Vector3 pos, Vector3 nor, Vector4 col)
        {
            Position = pos;
            Normal = nor;
            Color = col;
        }
        public VertexPositionNormalColor(Vector3 pos, Vector3 nor, Color col)
        {
            Position = pos;
            Normal = nor;
            Color = col.ToVector4();
        }
        public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(
                    new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                    new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
                    new VertexElement(24, VertexElementFormat.Vector4, VertexElementUsage.Color, 0));
    }
}
