using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition.GCForm
{
    public partial class DockingForm : DockContent
    {
        protected ReportActionStateMediator ActionReporter = null;

        public DockingForm() { }
        public DockingForm(ReportActionStateMediator ras)
        {
            InitializeComponent();

            ActionReporter = ras;
        }
    }
}
