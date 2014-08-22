using GeometricComposition.GCMath;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DataForm : DockingForm
    {
        private const string GenerateActionName = "Generate data";
        private const string RefreshActionName = "Refresh data";

        private const string SortFPPPointPitchName = "Point Pitch";
        private const string SortFPPFaceName = "Face";
        private const string SortFPPDistanceName = "Distance";

        private string CurrentActionName = "";

        private SortFPPOptions SortFPPTypeA = SortFPPOptions.PointID;
        private SortFPPOptions SortFPPTypeB = SortFPPOptions.Distance;

        public DataForm(FormInteractor ras)
            : base(ras)
        {
            InitializeComponent();

            SortFPPComboBoxA.Text = SortFPPPointPitchName;
            SortFPPComboBoxB.Text = SortFPPDistanceName;
        }

        private void GenerateData(GCFile file)
        {
            // TODO
            if (AsyncWorker.IsBusy)
                return;
            while (AsyncWorker.IsBusy)
                MessageBox.Show("Application is busy.\nPlease wait for a while.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Interactor.StartAction(CurrentActionName);
            AsyncWork = delegate(BackgroundWorker bw)
            {
                ReadVertices(file);
                bw.ReportProgress(20);
                GenerateFaces();
                bw.ReportProgress(40);
                GenerateFacePointPairs();
                bw.ReportProgress(60);
                SortFacePointPairs(SortFPPTypeA);
                bw.ReportProgress(80);
                DisplayPairsTreeInvoke();
                bw.ReportProgress(100);
                WriteCache(file);
            };
            AsyncWorker.RunWorkerAsync();
        }

        private void WriteCache(GCFile file)
        {
            file.FPPCache = new FPPCache(fpps);
        }

        private delegate void AsyncWorkCall(BackgroundWorker bw);
        private AsyncWorkCall AsyncWork = null;

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { AsyncWork(sender as BackgroundWorker); }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { Interactor.ReportActionProgress(CurrentActionName, e.ProgressPercentage); }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Interactor.CompleteAction(CurrentActionName);
            CurrentActionName = "";
            AsyncWork = null;
        }

        private void FacePointTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GCFacePointPair fpp = e.Node.Tag as GCFacePointPair;
            if (fpp != null)
                DisplayFPP(fpp);
        }

        private void DisplayFPP(GCFacePointPair fpp)
        {
            Interactor.DisplayExtraPoints(fpp.Point, fpp.Face.PointA, fpp.Face.PointB, fpp.Face.PointC);
            Interactor.DisplayExtraPointsPitch(fpp.Point.ID, fpp.Face.PointA.ID, fpp.Face.PointB.ID, fpp.Face.PointC.ID);
        }

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
            // TODO
            if (AsyncWorker.IsBusy)
                return;

            ClearData();
            if (e.File == null)
                return;
            if (e.File.FPPCache != null)
                DisplayPairsTree(e.File.FPPCache);
            else
            {
                CurrentActionName = GenerateActionName;
                GenerateData(e.File);
            }
        }

        private void SortFPPComboBoxA_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortFPPComboBoxB.Items.Clear();
            switch (SortFPPComboBoxA.Text)
            {
                case SortFPPPointPitchName:
                    SortFPPTypeA = SortFPPOptions.PointID;
                    SortFPPComboBoxB.Items.Add(SortFPPDistanceName);
                    SortFPPComboBoxB.Text = SortFPPDistanceName;
                    SortFPPTypeB = SortFPPOptions.Distance;
                    break;
                case SortFPPDistanceName: 
                    SortFPPTypeA = SortFPPOptions.Distance;
                    SortFPPComboBoxB.Items.Add(SortFPPPointPitchName);
                    SortFPPComboBoxB.Text = SortFPPPointPitchName;
                    SortFPPTypeB = SortFPPOptions.PointID;
                    break;
            }
        }

        private void SortFPPComboBoxB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SortFPPComboBoxB.Text)
            {
                case SortFPPPointPitchName: SortFPPTypeB = SortFPPOptions.PointID; break;
                case SortFPPDistanceName: SortFPPTypeB = SortFPPOptions.Distance; break;
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            CurrentActionName = RefreshActionName;
            if (Interactor.CurrentFile == null)
                return;
            Interactor.CurrentFile.FPPCache = null;
            ClearData();
            GenerateData(Interactor.CurrentFile);
        }
    }
}
