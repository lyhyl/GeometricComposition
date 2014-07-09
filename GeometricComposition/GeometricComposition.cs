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
        public event SelectedFileChangedEventHandler SelectedFileChanged;

        private List<DisplayForm> gcUnions = new List<DisplayForm>();
        private List<DockingForm> toolForms = new List<DockingForm>();

        public GCFile selectedFile = null;

        private DataForm dataForm = null;
        private ModifierForm modifierForm = null;
        private ReportActionStateMediator rasm = null;

        public GeometricComposition()
        {
            InitializeComponent();
            InitializeSubForm();
        }

        private void InitializeSubForm()
        {
            GCFile.RootDirectory = Application.StartupPath;
            rasm = new ReportActionStateMediator(this);
            InitializeToolForms();
        }

        private void InitializeToolForms()
        {
            // data form
            dataForm = new DataForm(rasm);
            dataForm.Show(WorkDockPanel, DockState.DockLeft);
            SelectedFileChanged += dataForm.HandleSelectedFileChanged;
            toolForms.Add(dataForm);

            // modifier form
            modifierForm = new ModifierForm(rasm);
            modifierForm.Show(WorkDockPanel, DockState.DockRight);
            SelectedFileChanged += modifierForm.HandleSelectedFileChanged;
            toolForms.Add(modifierForm);
        }

        void WorkDockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            DisplayForm dForm = WorkDockPanel.ActiveContent as DisplayForm;
            if (dForm != null)
            {
                selectedFile = dForm.File;
                OnSelectedFileChanged();
            }
        }

        private void OnSelectedFileChanged()
        {
            if (SelectedFileChanged != null)
            {
                SelectedFileChangedEventArg e = new SelectedFileChangedEventArg(selectedFile);
                SelectedFileChanged(this, e);
            }
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
            dForm.FormClosed += delegate(object sender, FormClosedEventArgs ea)
            {
                DisplayForm df = sender as DisplayForm;
                gcUnions.Remove(df);
                if (selectedFile == df.File)
                {
                    selectedFile = null;
                    OnSelectedFileChanged();
                }
            };
            gcUnions.Add(dForm);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedFile != null)
                selectedFile.Save();
        }

        //TB_StopOrPlayToolBtn.Image = e ? Resources.stop_icon : Resources.play_icon;

        private void dataFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataForm.Visible)
                dataForm.Hide();
            else
                dataForm.Show();
            dataFormToolStripMenuItem.Checked = dataForm.Visible;
        }

        private void modifierFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifierForm.Visible)
                modifierForm.Hide();
            else
                modifierForm.Show();
            modifierFormToolStripMenuItem.Checked = modifierForm.Visible;
        }
    }
}
