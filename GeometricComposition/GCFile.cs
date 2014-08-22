using GeometricComposition.GCForm;
using GeometricComposition.XNALibrary;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Windows.Forms;

namespace GeometricComposition
{
    public class GCFile
    {
        public DisplayForm DisplayForm = null;
        public string FilePath { private set; get; }

        private GCModel model = null;
        public GCModel Model
        {
            private set { model = value; }
            get
            {
                if (model == null)
                    if (modelPath == "default")
                        model = contentLoader.DefaultModel;
                // TODO
                    /*else if (modelPath != "")
                        model = contentLoader.Load<Model>(modelPath);*/
                return model;
            }
        }

        public const int PitchCount = 12;
        public int[] PitchMap { set; get; }

        private GCContentManager contentLoader = null;
        public FPPCache FPPCache { set; get; }

        //
        private string modelPath = "";

        public GCFile(GCContentManager loader)
        {
            contentLoader = loader;

            PitchMap = new int[PitchCount];
            RandomPitchMap();

            FilePath = "";
            modelPath = "default";
        }

        private void RandomPitchMap()
        {
            for (int i = 0; i < PitchCount; i++)
                PitchMap[i] = i;
        }

        public GCFile(string path, GCContentManager loader)
        {
            contentLoader = loader;

            PitchMap = new int[PitchCount];

            FilePath = path;
            using (FileStream fs = File.OpenRead(path))
            using (BinaryReader br = new BinaryReader(fs))
                try
                { ReadFile(br); }
                catch (Exception e)
                { throw new InvalidDataException("Bad GC file", e); }
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
    }
}
