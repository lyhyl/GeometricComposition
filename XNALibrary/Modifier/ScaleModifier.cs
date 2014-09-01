using GeometricComposition.XNALibrary.Control;
using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary.Modifier
{
    public class ScaleModifier : ModelModifier
    {
        private LabelValueControl _factor = null;

        public ScaleModifier()
        {
            _factor = new LabelValueControl("factor");
            Controls.Add(_factor);
        }

        public override Vector3[] Modify(Vector3[] vs)
        {
            float s = _factor.GetValue<float>();
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
