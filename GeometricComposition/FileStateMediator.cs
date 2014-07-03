using GeometricComposition.GCForm;
using Microsoft.Xna.Framework.Graphics;

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

        public Model Model { get { return dForm.File.Model; } }
    }
}
