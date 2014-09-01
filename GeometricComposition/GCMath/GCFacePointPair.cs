using GeometricComposition.XNALibrary.Music;
using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.GCMath
{
    public class GCFacePointPair
    {
        public float DistanceThreshold { set; get; }
        public GCFace Face { set; get; }
        public GCPoint Point { set; get; }
        public float Distance
        {
            get
            {
                Vector3 n = Vector3.Cross(Face.PointA.Position - Face.PointB.Position,
                    Face.PointB.Position - Face.PointC.Position);
                Vector3 l = Point.Position - Face.PointA.Position;
                float d = Math.Abs(Vector3.Dot(n, l)) / n.Length();

                if (float.IsNaN(d))
                {
                    n = Vector3.Cross(Face.PointB.Position - Face.PointC.Position,
                        Face.PointC.Position - Face.PointA.Position);
                    d = Math.Abs(Vector3.Dot(n, l)) / n.Length();
                }

                return d < DistanceThreshold ? 0f : d;
            }
        }

        public GCFacePointPair(GCFace f, GCPoint p)
        {
            Face = f;
            Point = p;
            DistanceThreshold = 1e-6f;
        }

        public string ToString(string format)
        {
            string result = "";
            int i=0;
            while(i<format.Length)
                switch (format[i++])
                {
                    case 'p':
                    case 'P':
                        result += GCPitchHelper.GetName(Point.ID);
                        break;
                    case 'f':
                    case 'F':
                        result += "<" + GCPitchHelper.GetName(Face.PointA.ID) + "," +
                            GCPitchHelper.GetName(Face.PointB.ID) + "," +
                            GCPitchHelper.GetName(Face.PointC.ID) + ">";
                        break;
                    case 'd':
                    case 'D':
                        result += "Dis.:" + Distance;
                        break;
                    default:
                        throw new ArgumentException("Bad format");
                }
            return result;
        }
         
        public override string ToString()
        {
            return GCPitchHelper.GetName(Point.ID) + "-<" +
               GCPitchHelper.GetName(Face.PointA.ID) + "," +
               GCPitchHelper.GetName(Face.PointB.ID) + "," +
               GCPitchHelper.GetName(Face.PointC.ID) + ">" +
               "\tDist:" + Distance;
        }
    }
}
