using GeometricComposition.GCForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition
{
    public partial class MainForm : Form
    {
        public event SelectedFileChangedEventHandler SelectedFileChanged;

        private List<DisplayForm> displayForms = new List<DisplayForm>();
        private List<DockingForm> toolForms = new List<DockingForm>();

        public GCFile SelectedFile { private set; get; }
        public GCContentManager ContentManager { private set; get; }

        private DataForm dataForm = null;
        private ModifierForm modifierForm = null;
        private ProjectSettingForm projectSettingForm = null;

        private Commander commander = null;

        public MainForm()
        {
            InitializeComponent();

            WorkDockPanel.NTWidth = 200;

            ContentManager = new GCContentManager(Handle);
            commander = new Commander(this);

            InitializeToolForms();
        }

        private void InitializeToolForms()
        {
            // data form
            dataForm = new DataForm(commander);
            dataForm.VisibleChanged +=
                (object sender, EventArgs e) => { dataFormToolStripMenuItem.Checked = dataForm.Visible; };
            dataForm.Show(WorkDockPanel, DockState.DockLeft);
            SelectedFileChanged += dataForm.HandleSelectedFileChanged;
            toolForms.Add(dataForm);

            // modifier form
            modifierForm = new ModifierForm(commander);
            modifierForm.VisibleChanged +=
                (object sender, EventArgs e) => { modifierFormToolStripMenuItem.Checked = modifierForm.Visible; };
            modifierForm.Show(WorkDockPanel, DockState.DockRight);
            SelectedFileChanged += modifierForm.HandleSelectedFileChanged;
            toolForms.Add(modifierForm);

            // project setting form
            projectSettingForm = new ProjectSettingForm(commander);
            SelectedFileChanged += projectSettingForm.HandleSelectedFileChanged;
            toolForms.Add(projectSettingForm);
        }

        void WorkDockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            DisplayForm dForm = WorkDockPanel.ActiveContent as DisplayForm;
            if (dForm != null)
            {
                SelectedFile = dForm.File;
                OnSelectedFileChanged();
            }
        }

        private void OnSelectedFileChanged()
        {
            if (SelectedFileChanged != null)
            {
                SelectedFileChangedEventArg e = new SelectedFileChangedEventArg(SelectedFile);
                SelectedFileChanged(this, e);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm dForm = new DisplayForm(commander);
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
                DisplayForm dForm = new DisplayForm(commander, filename);
                InitializeAddDisplayForm(dForm);
                dForm.Show(WorkDockPanel, DockState.Document);
            }
        }

        private void InitializeAddDisplayForm(DisplayForm dForm)
        {
            dForm.FormClosed += delegate(object sender, FormClosedEventArgs e)
            {
                DisplayForm df = sender as DisplayForm;
                displayForms.Remove(df);
                if (SelectedFile == df.File)
                {
                    SelectedFile = null;
                    OnSelectedFileChanged();
                }
            };
            displayForms.Add(dForm);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedFile != null)
                SelectedFile.Save();
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

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //projectSettingForm.Show(WorkDockPanel, new Rectangle(projectSettingForm.Location, projectSettingForm.Size));
            projectSettingForm.Show(WorkDockPanel, DockState.Float);
        }
    }
}
