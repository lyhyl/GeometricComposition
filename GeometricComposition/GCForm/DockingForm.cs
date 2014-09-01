using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition.GCForm
{
    public partial class DockingForm : DockContent
    {
        protected Commander Commander = null;

        public DockingForm() { }
        public DockingForm(Commander com)
        {
            InitializeComponent();

            Commander = com;
        }

        public virtual void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
        }
    }
}
