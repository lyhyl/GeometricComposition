using GeometricComposition.XNALibrary.Music;
using Microsoft.Xna.Framework;
using System.IO;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DisplayForm : DockingForm
    {
        public Vector3[] ExtraPoints
        {
            set { ModelViewer.AuxiliaryVertices = value; }
            get { return ModelViewer.AuxiliaryVertices; }
        }
        public GCPitch[] ExtraPointsPitch
        {
            set { ModelViewer.AuxiliaryVerticesPitch = value; }
            get { return ModelViewer.AuxiliaryVerticesPitch; }
        }
        public GCFile File { private set; get; }

        public DisplayForm(Commander com)
            : base(com)
        {
            InitializeComponent();
            Text = "Untitled";
            File = new GCFile(com.ContentManager);
            File.DisplayForm = this;
            ModelViewer.Model = File.Model;
            ModelViewer.VertexModel = Commander.ContentManager.DefaultPointModel;
            ModelViewer.spriteFont = Commander.ContentManager.DefaultFont;
        }

        public DisplayForm(Commander com, string filepath)
            : base(com)
        {
            InitializeComponent();
            Text = Path.GetFileNameWithoutExtension(filepath);
            File = new GCFile(filepath, com.ContentManager);
            File.DisplayForm = this;
            ModelViewer.Model = File.Model;
            ModelViewer.VertexModel = Commander.ContentManager.DefaultPointModel;
            ModelViewer.spriteFont = Commander.ContentManager.DefaultFont;
        }

        protected override void OnShown(System.EventArgs e)
        {
            // TODO
            Commander.StartAction("Opening file");
            Commander.ReportActionProgress("Opening file", 99);
            base.OnShown(e);
            Commander.CompleteAction("Opening file");
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