using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition.GCForm
{
    public partial class DockingForm : DockContent
    {
        protected FormInteractor Interactor = null;

        public DockingForm() { }
        public DockingForm(FormInteractor fi)
        {
            InitializeComponent();

            Interactor = fi;
        }

        public virtual void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
        }
    }
}
