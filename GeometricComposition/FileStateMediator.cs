using GeometricComposition.GCForm;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricComposition
{
    public class FileStateMediator
    {
        GeometricComposition gcForm = null;
        DisplayForm dForm = null;

        public FileStateMediator(GeometricComposition gc, DisplayForm df)
        {
            gcForm = gc;
            dForm = df;
        }

        public Model Model { get { return dForm.ModelViewer.Model; } }
    }
}
