using GeometricComposition.GCForm;
using GeometricComposition.GCMath;
using GeometricComposition.XNALibrary.Music;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace GeometricComposition
{
    public class Commander
    {
        private MainForm mainForm = null;

        public GCFile CurrentFile { get { return mainForm.SelectedFile; } }
        public GCContentManager ContentManager { get { return mainForm.ContentManager; } }

        public Commander(MainForm mf)
        {
            mainForm = mf;
        }

        NotificationForm notificationForm = new NotificationForm();
        public void StartAction(string name)
        {
            notificationForm.Show("waiting for current task : " + name);

            /*ToolStripLabel label = new ToolStripLabel();
            label.Name = GetLabelName(name);
            label.Text = name + " : ";
            ToolStripProgressBar pbar = new ToolStripProgressBar();
            pbar.Name = GetProgressBarName(name);

            gcForm.StatusBar.Items.Add(label);
            gcForm.StatusBar.Items.Add(pbar);*/
        }

        public void ReportActionProgress(string name, int percentage)
        {
            notificationForm.Progress = percentage;
            Application.DoEvents();
            /*ToolStripItem[] objs = gcForm.StatusBar.Items.Find(GetProgressBarName(name), false);
            if (objs.Length <= 0) return;
            ToolStripProgressBar pbar = objs[0] as ToolStripProgressBar;
            if (pbar == null) return;
            pbar.Value = percentage;*/
        }

        public void CompleteAction(string name)
        {
            notificationForm.Hide();

            /*ToolStripItem[] objs;
            objs = gcForm.StatusBar.Items.Find(GetProgressBarName(name), false);
            if (objs.Length > 0) gcForm.StatusBar.Items.Remove(objs[0]);
            objs = gcForm.StatusBar.Items.Find(GetLabelName(name), false);
            if (objs.Length > 0) gcForm.StatusBar.Items.Remove(objs[0]);*/
        }

        /*private static string GetProgressBarName(string name)
        { return "PB_" + name; }
        private static string GetLabelName(string name)
        { return "L_" + name; }*/

        public void DisplayExtraPoints(GCPoint p1, GCPoint p2, GCPoint p3, GCPoint p4)
        {
            mainForm.SelectedFile.DisplayForm.ExtraPoints = new Vector3[] { p1.Position, p2.Position, p3.Position, p4.Position };
        }
        public void DisplayExtraPointsPitch(GCPitch p1, GCPitch p2, GCPitch p3, GCPitch p4)
        {
            mainForm.SelectedFile.DisplayForm.ExtraPointsPitch = new GCPitch[] { p1, p2, p3, p4 };
        }
    }
}
