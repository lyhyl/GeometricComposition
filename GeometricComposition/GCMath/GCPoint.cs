using GeometricComposition.XNALibrary.Music;
using Microsoft.Xna.Framework;

namespace GeometricComposition.GCMath
{
    public struct GCPoint
    {
        public GCPoint(int id, Vector3 pos)
        {
            ID = (GCPitch)id;
            Position = pos;
        }
        public static bool operator ==(GCPoint a, GCPoint b)
        { return a.ID == b.ID && a.Position == b.Position; }
        public static bool operator !=(GCPoint a, GCPoint b)
        { return !(a == b); }
        public override bool Equals(object obj)
        { return base.Equals(obj); }
        public override int GetHashCode()
        { return base.GetHashCode(); }
        public GCPitch ID;
        public Vector3 Position;
        public string ToString(string i)
        {
            switch (i)
            {
                case "t":
                case "T":
                    return ID.ToString();
                case "p":
                case "P":
                    return Position.ToString();
                default:
                    return ToString();
            }
        }
    }
}
