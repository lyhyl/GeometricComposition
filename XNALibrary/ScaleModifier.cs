using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary
{
    public class ScaleModifier : ModelModifier
    {
        public ScaleModifier()
        {
            Controls.Add(new ModelModifierControl(ModelModifierControlType.Text));
        }

        public override Vector3[] Modify(Vector3[] vs, params float[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("expect a float as scale factor");
            float s = args[0];
            for (int i = 0; i < vs.Length; i++)
                vs[i] *= s;
            NotUpdated = false;
            return vs;
            //return Array.ConvertAll(vs, (Vector3 e) => { return e * s; });
        }

        public override string ToString()
        {
            return "Scaler";
        }
    }
}
