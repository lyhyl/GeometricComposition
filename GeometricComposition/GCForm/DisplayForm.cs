using System.IO;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DisplayForm : DockingForm
    {
        public GCFile File { private set; get; }

        public DisplayForm(ReportActionStateMediator ras)
            : base(ras)
        {
            InitializeComponent();
            Text = "Untitled";
            File = new GCFile(ModelViewer.Services);
        }

        public DisplayForm(ReportActionStateMediator ras, string filepath)
            : base(ras)
        {
            InitializeComponent();
            Text = Path.GetFileNameWithoutExtension(filepath);
            Shown += delegate
            {
                File = new GCFile(filepath, ModelViewer.Services);
                ModelViewer.Model = File.Model;
            };
        }

        public void SaveFile()
        {
            File.Save();
        }

        private void DisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File != null)
                if (MessageBox.Show("Do you want to save this(" + Text + ") project?", "Notification",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    File.Save();
        }
    }
}
