using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricComposition
{
    public delegate void SelectedFileChangedEventHandler(object sender, SelectedFileChangedEventArg e);
    public class SelectedFileChangedEventArg
    {
        public GCFile File { private set; get; }
        public SelectedFileChangedEventArg(GCFile file)
        {
            File = file;
        }
    }
}
