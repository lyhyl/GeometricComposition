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
        private Model model = null;
        public Model Model
        {
            private set { model = value; }
            get
            {
                if (model == null && modelPath != "")
                    try { LoadModel(); }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException(
                              "Show the Service-Provider before access Model", e);
                    }
                return model;
            }
        }

        public const int PitchCount = 12;
        public int[] PitchMap { set; get; }

        public FPPCache FPPCache { set; get; }

        private ContentBuilder contentBuilder = new ContentBuilder();
        private ContentManager contentManager = null;

        private string modelPath = "";

        public GCFile(IServiceProvider service)
        {
            Initialize(service);

            RandomPitchMap();

            FilePath = "";
            modelPath = "default";
        }

        private void RandomPitchMap()
        {
            for (int i = 0; i < PitchCount; i++)
                PitchMap[i] = i;
        }

        public GCFile(string path, IServiceProvider service)
        {
            Initialize(service);

            FilePath = path;
            using (FileStream fs = File.OpenRead(path))
            using (BinaryReader br = new BinaryReader(fs))
                try
                { ReadFile(br); }
                catch (Exception e)
                { throw new InvalidDataException("Bad GC file", e); }
        }

        private void Initialize(IServiceProvider service)
        {
            contentManager = new ContentManager(service, contentBuilder.OutputDirectory);
            PitchMap = new int[PitchCount];
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
                WriteFile(bw);

            fs.Close();
        }

        private void ReadFile(BinaryReader br)
        {
            modelPath = br.ReadString();
            for (int i = 0; i < PitchCount; i++)
                PitchMap[i] = br.ReadInt32();
        }

        private void WriteFile(BinaryWriter bw)
        {
            bw.Write(modelPath);
            for (int i = 0; i < PitchCount; ++i)
                bw.Write((Int32)PitchMap[i]);
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
                try { Model = contentManager.Load<Model>("Model"); }
                catch { throw; }
            else
                throw new InvalidOperationException(buildError);
        }
    }
}
