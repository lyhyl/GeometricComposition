using GeometricComposition.XNALibrary.Control;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricComposition.XNALibrary.Modifier
{
    public abstract class ModelModifier
    {
        public ModelModifier()
        {
            Controls = new List<ModelModifierControl>();
            NotUpdated = true;
        }

        public List<ModelModifierControl> Controls { protected set; get; }
        public bool NotUpdated { get; protected set; }

        public abstract Vector3[] Modify(Vector3[] vs);
    }
}
