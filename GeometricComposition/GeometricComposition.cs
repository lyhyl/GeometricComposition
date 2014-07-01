using GCXNA;
using GeometricComposition.GCForm;
using GeometricComposition.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition
{
    public partial class GeometricComposition : Form
    {
        ToolForm toolForm = null;
        DisplayForm displayForm = null;

        public GeometricComposition()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            ReportActionStateMediator rasm = new ReportActionStateMediator(this);

            displayForm = new DisplayForm(rasm);
            displayForm.Show(WorkDockPanel, DockState.Document);

            FileStateMediator fsm = new FileStateMediator(this, displayForm);

            toolForm = new ToolForm(rasm, fsm);
            toolForm.Show(WorkDockPanel, DockState.Float);

            displayForm.ModelViewer.AnimationChange += ModelViewer_AnimationChange;
        }

        void ModelViewer_AnimationChange(object sender, XNADisplayControl.AnimationEventArgs e)
        {
            TB_StopOrPlayToolBtn.Image = e.Animation ? Resources.stop_icon : Resources.play_icon;
        }

        private void TB_StopOrPlayToolBtn_Click(object sender, EventArgs e)
        {
            displayForm.ModelViewer.Animation = !displayForm.ModelViewer.Animation;
        }
    }
}
