namespace GeometricComposition.GCMath
{
    public struct GCFace
    {
        public GCFace(int id, GCPoint a, GCPoint b, GCPoint c)
        {
            ID = id;
            PointA = a;
            PointB = b;
            PointC = c;
        }
        public static bool operator ==(GCFace a, GCFace b)
        {
            return a.ID == b.ID && a.PointA == b.PointA &&
              a.PointB == b.PointB && a.PointC == b.PointC;
        }
        public static bool operator !=(GCFace a, GCFace b)
        { return !(a == b); }
        public override bool Equals(object obj)
        { return base.Equals(obj); }
        public override int GetHashCode()
        { return base.GetHashCode(); }
        public int ID;
        public GCPoint PointA, PointB, PointC;
    }
}
