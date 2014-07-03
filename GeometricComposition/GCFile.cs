using GeometricComposition.XNAContent;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Windows.Forms;

namespace GeometricComposition
{
    public class GCFile
    {
        public static string RootDirectory { set; get; }

        public string FilePath { private set; get; }
        public Model Model { private set; get; }

        private ContentBuilder contentBuilder = new ContentBuilder();
        private ContentManager contentManager = null;

        private string modelPath;

        public GCFile(string path, IServiceProvider service)
        {
            Initialize(service);

            FilePath = path;
            using (FileStream fs = File.OpenRead(path))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    modelPath = br.ReadString();
                }
            }
            LoadModel();
        }

        public GCFile(IServiceProvider service) { Initialize(service); }

        private void Initialize(IServiceProvider service)
        {
            FilePath = "";
            modelPath = "";
            contentManager = new ContentManager(service, contentBuilder.OutputDirectory);
        }

        public void Save()
        {
            FileStream fs = null;
            if (FilePath == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Geometric Composition Project File|*.gc|All files|*.*";
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
                fs = File.Create(dialog.FileName);
            }
            else
                fs = File.OpenWrite(FilePath);

            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(modelPath == "" ? "default" : modelPath);
            }

            fs.Close();
        }

        void LoadModel()
        {
            contentManager.Unload();

            contentBuilder.Clear();
            string path = modelPath;
            if (path == "default")
                path = Path.Combine(RootDirectory, "GCDefaultContent\\HexagonalPrism.FBX");
            contentBuilder.Add(path, "Model", null, "ModelProcessor");

            string buildError = contentBuilder.Build();

            if (string.IsNullOrEmpty(buildError))
                Model = contentManager.Load<Model>("Model");
            else
                MessageBox.Show(buildError, "Error");
        }
    }
}
