using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricComposition.XNALibrary
{
    public static class GCMath
    {
        public static void Clamp(ref float v, float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min should less than max");
            v = Math.Max(v, min);
            v = Math.Min(v, max);
        }

        public static float Clamp(float v, float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min should less than max");
            float _v = Math.Max(v, min);
            _v = Math.Min(_v, max);
            return _v;
        }

        public static float InnerProduct(Vector3 v, float[] f)
        {
            /*if (f.Length < 3)
                throw new ArgumentException("float array should has at less 3 element");*/
            return v.X * f[0] + v.Y * f[1] + v.Z * f[2];
        }

        public static float InnerProduct(float[] a, float[] b, int dim)
        {
            /*if (a.Length < 3 || b.Length < 3)
                throw new ArgumentException("float array should has at less 3 element");*/
            float res = 0;
            for (int i = 0; i < dim; i++)
                res += a[i] * b[i];
            return res;
        }
    }
}
