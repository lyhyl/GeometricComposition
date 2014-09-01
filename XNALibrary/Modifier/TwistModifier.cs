using GeometricComposition.XNALibrary.Control;
using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary.Modifier
{
    public class TwistModifier : ModelModifier
    {
        public TwisterAxis Axis = TwisterAxis.Z;
        private LabelComboBoxControl _axis = null;
        private LabelValueControl _angle = null;

        public TwistModifier()
        {
            _axis = new LabelComboBoxControl("Axis", "X", "Y", "Z");
            _angle = new LabelValueControl("Angle", -180, +180);
            Controls.Add(_axis);
            Controls.Add(_angle);
            _axis.SetValue("Z");
        }

        public override Vector3[] Modify(Vector3[] vs)
        {
            float angle = (float)(_angle.GetValue<double>() / 180 * Math.PI);
            switch (_axis.GetValue<TwisterAxis>())
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
