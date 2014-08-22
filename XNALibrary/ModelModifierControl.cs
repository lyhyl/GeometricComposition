using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricComposition.XNALibrary
{
    public class ModelModifierControl
    {
        public ModelModifierControlType Type { private set; get; }

        public ModelModifierControl(ModelModifierControlType t)
        {
            Type = t;
        }
    }

    public enum ModelModifierControlType
    {
        Text
    }
}
