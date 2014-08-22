using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary
{
    public class TwistModifier : ModelModifier
    {
        public TwisterAxis Axis = TwisterAxis.Z;

        public override Vector3[] Modify(Vector3[] vs, params float[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("expect a float as angle");
            float angle = args[0];
            switch (Axis)
            {
                case TwisterAxis.X:
                    for (int i = 0; i < vs.Length; i++)
                        vs[i] = Vector3.Transform(vs[i], Matrix.CreateRotationX(angle * vs[i].X));
                    break;
                case TwisterAxis.Y:
                    for (int i = 0; i < vs.Length; i++)
                        vs[i] = Vector3.Transform(vs[i], Matrix.CreateRotationY(angle * vs[i].Y));
                    break;
                case TwisterAxis.Z:
                    for (int i = 0; i < vs.Length; i++)
                        vs[i] = Vector3.Transform(vs[i], Matrix.CreateRotationZ(angle * vs[i].Z));
                    break;
            }
            NotUpdated = false;
            return vs;
        }

        public override string ToString()
        {
            return "Twister";
        }
    }
    public enum TwisterAxis { X, Y, Z }
}
