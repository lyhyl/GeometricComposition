using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class ModifierForm : DockingForm
    {
        public ModifierForm(ReportActionStateMediator ras)
            : base(ras)
        {
            InitializeComponent();
        }

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
        }
    }
}
