using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class ToolForm : DockingForm
    {
        public DisplayForm dForm = null;

        public ToolForm(ReportActionStateMediator ras)
            : base(ras)
        {
            //File = fs;
            InitializeComponent();
        }

        private const string GenerateActionName = "Generate distance";
        private string CurrentActionName = "";

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            CurrentActionName = GenerateActionName;

            if (!AsyncWorker.IsBusy)
            {
                ActionReporter.StartAction(CurrentActionName);
                AsyncWork = delegate(BackgroundWorker bw)
                {
                    ReadVertices();
                    bw.ReportProgress(50);
                    GenerateFacePointPairs();
                    bw.ReportProgress(100);
                    DisplayPairs();
                };
                AsyncWorker.RunWorkerAsync();
            }
            else
                MessageBox.Show("Application is busy.\nPlease wait for a while.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private delegate void AsyncWorkCall(BackgroundWorker bw);
        private AsyncWorkCall AsyncWork = null;
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AsyncWork(sender as BackgroundWorker);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ActionReporter.ReportActionProgress(CurrentActionName, e.ProgressPercentage);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ActionReporter.CompleteAction(CurrentActionName);
            CurrentActionName = "";
            AsyncWork = null;
        }

        private void FacePointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                throw new Exception("-NOT-ListBox_SelectedIndexChanged");
            FPP fpp = lb.SelectedItem as FPP;
            if (fpp == null)
                throw new Exception("ListBox_SelectedItem-NOT-FPP");
            DisplayFPP(fpp);
        }

        private void DisplayFPP(FPP fpp)
        {
        }
    }
}
