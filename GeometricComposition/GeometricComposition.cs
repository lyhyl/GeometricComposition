using GeometricComposition.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GeometricComposition
{
    public partial class GeometricComposition : Form
    {
        public GeometricComposition()
        {
            InitializeComponent();
            mvc.AnimationChange += mvc_AnimationChange;
        }

        private string currentWork;
        private string CurrentWork
        {
            set
            {
                currentWork = value;
                SB_WorkLabel.Text = "Current Work : " + currentWork;
            }
            get { return currentWork; }
        }

        private void TB_StopOrPlayToolBtn_Click(object sender, EventArgs e)
        {
            mvc.Animation = !mvc.Animation;
        }

        void mvc_AnimationChange(object sender, GCXNA.XNADisplayControl.AnimationEventArgs e)
        {
            TB_StopOrPlayToolBtn.Image = mvc.Animation ? Resources.stop_icon : Resources.play_icon;
        }

        private void FacePointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            CurrentWork = "Generate";
            AsyncWork = delegate(BackgroundWorker bw)
            {
                ReadVertices();
                bw.ReportProgress(100/3);
                GenerateFacePointPairs();
                bw.ReportProgress(100/3*2);
                DisplayPairs();
                bw.ReportProgress(100);
            };
            if (!AsyncWorker.IsBusy)
                AsyncWorker.RunWorkerAsync();
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
            SB_WorkProgressBar.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AsyncWork = null;
            SB_WorkProgressBar.Value = 0;
            CurrentWork = "";
        }
    }
}
