using GeometricComposition.GCMusic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public DisplayForm(FormInteractor fi)
            : base(fi)
        {
            InitializeComponent();
            Text = "Untitled";
            File = new GCFile(fi.ContentManager);
            File.DisplayForm = this;
            ModelViewer.Model = File.Model;
            ModelViewer.VertexModel = Interactor.ContentManager.DefaultPointModel;
            ModelViewer.spriteFont = Interactor.ContentManager.DefaultFont;
        }

        public DisplayForm(FormInteractor fi, string filepath)
            : base(fi)
        {
            InitializeComponent();
            Text = Path.GetFileNameWithoutExtension(filepath);
            File = new GCFile(filepath, fi.ContentManager);
            File.DisplayForm = this;
            ModelViewer.Model = File.Model;
            ModelViewer.VertexModel = Interactor.ContentManager.DefaultPointModel;
            ModelViewer.spriteFont = Interactor.ContentManager.DefaultFont;
        }

        protected override void OnShown(System.EventArgs e)
        {
            // TODO
            Interactor.StartAction("Opening file");
            Interactor.ReportActionProgress("Opening file", 99);
            base.OnShown(e);
            Interactor.CompleteAction("Opening file");
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