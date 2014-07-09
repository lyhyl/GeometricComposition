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

        public virtual void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
        }
    }
}
