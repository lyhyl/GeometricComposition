using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DisplayForm : DockingForm
    {
        public Vector3[] ExtraVertices { set; get; }
        public GCFile File { private set; get; }

        public DisplayForm(ReportActionStateMediator ras)
            : base(ras)
        {
            InitializeComponent();
            ExtraVertices = new Vector3[4];
            Text = "Untitled";
            File = new GCFile(ModelViewer.Services);
        }

        public DisplayForm(ReportActionStateMediator ras, string filepath)
            : base(ras)
        {
            InitializeComponent();
            ExtraVertices = new Vector3[4];
            Text = Path.GetFileNameWithoutExtension(filepath);
            File = new GCFile(filepath, ModelViewer.Services);
            ModelViewer.VisibleChanged += delegate
            {
                if (ModelViewer.Visible)
                    ModelViewer.Model = File.Model;
            };
        }

        protected override void OnShown(System.EventArgs e)
        {
            // TODO
            ActionReporter.StartAction("Opening file");
            ActionReporter.ReportActionProgress("Opening file", 99);
            base.OnShown(e);
            ActionReporter.CompleteAction("Opening file");
        }

        private void DisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File != null)
                if (MessageBox.Show("Do you want to save \"" + Text + "\" ?", "Notification",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    File.Save();
        }
    }
}
