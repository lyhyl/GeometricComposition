using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class ToolForm : DockingForm
    {
        FileStateMediator File = null;

        public ToolForm(ReportActionStateMediator ras, FileStateMediator fs)
            : base(ras)
        {
            File = fs;
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
    }
}
