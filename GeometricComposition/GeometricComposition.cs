using GCXNA;
using GeometricComposition.GCForm;
using GeometricComposition.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition
{
    public partial class GeometricComposition : Form
    {
        ToolForm toolForm = null;
        List<DisplayForm> gcUnions = new List<DisplayForm>();
        DisplayForm selectedDisplayForm = null;
        ReportActionStateMediator rasm = null;

        public GeometricComposition()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            GCFile.RootDirectory = Application.StartupPath;

            rasm = new ReportActionStateMediator(this);

            toolForm = new ToolForm(rasm);
            toolForm.Show(WorkDockPanel, DockState.DockLeft);
        }

        void ModelViewer_AnimationChange(object sender, XNADisplayControl.AnimationEventArgs e)
        {
            TB_StopOrPlayToolBtn.Image = e.Animation ? Resources.stop_icon : Resources.play_icon;
        }

        private void TB_StopOrPlayToolBtn_Click(object sender, EventArgs e)
        {
            //displayForm.ModelViewer.Animation = !displayForm.ModelViewer.Animation;
        }

        private void toolFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolForm.Visible)
                toolForm.Hide();
            else
                toolForm.Show();
            toolFormToolStripMenuItem.Checked = toolForm.Visible;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm dForm = new DisplayForm(rasm);
            InitializeAddDisplayForm(dForm);
            dForm.Show(WorkDockPanel, DockState.Document);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Geometric Composition Project File|*.gc|All files|*.*";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            foreach (string filename in dialog.FileNames)
            {
                DisplayForm dForm = new DisplayForm(rasm, filename);
                InitializeAddDisplayForm(dForm);
                dForm.Show(WorkDockPanel, DockState.Document);
            }
        }

        private void InitializeAddDisplayForm(DisplayForm dForm)
        {
            dForm.Activated += delegate(object sender, EventArgs ea)
            {
                toolForm.dForm = selectedDisplayForm = sender as DisplayForm;
            };
            dForm.FormClosed += delegate(object sender, FormClosedEventArgs ea)
            {
                DisplayForm df = sender as DisplayForm;
                gcUnions.Remove(df);
                if (selectedDisplayForm == df) selectedDisplayForm = null;
            };
            gcUnions.Add(dForm);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedDisplayForm != null)
                selectedDisplayForm.SaveFile();
        }
    }
}
