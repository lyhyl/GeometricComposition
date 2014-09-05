using System;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition.GCForm
{
    public partial class DockingForm : DockContent
    {
        protected Commander Commander = null;

        public DockingForm() { }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode && Commander == null)
                throw new InvalidOperationException("should invoke a proper constructor to initialize Commander");
            base.OnHandleCreated(e);
        }

        public DockingForm(Commander com)
        {
            InitializeComponent();

            Commander = com;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        public virtual void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
        }
    }
}
