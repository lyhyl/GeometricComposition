using System.Windows.Forms;

namespace GeometricComposition
{
    public class ReportActionStateMediator
    {
        private GeometricComposition gcForm = null;

        // TODO
        public GCFile File { get { return gcForm.selectedFile; } }

        public ReportActionStateMediator(GeometricComposition gc)
        {
            gcForm = gc;
        }

        public void StartAction(string name)
        {
            ToolStripLabel label = new ToolStripLabel();
            label.Name = GetLabelName(name);
            label.Text = name + " : ";
            ToolStripProgressBar pbar = new ToolStripProgressBar();
            pbar.Name = GetProgressBarName(name);

            gcForm.StatusBar.Items.Add(label);
            gcForm.StatusBar.Items.Add(pbar);
        }

        public void ReportActionProgress(string name, int percentage)
        {
            ToolStripItem[] objs = gcForm.StatusBar.Items.Find(GetProgressBarName(name), false);
            if (objs.Length <= 0) return;
            ToolStripProgressBar pbar = objs[0] as ToolStripProgressBar;
            if (pbar == null) return;
            pbar.Value = percentage;
        }

        public void CompleteAction(string name)
        {
            ToolStripItem[] objs;
            objs = gcForm.StatusBar.Items.Find(GetProgressBarName(name), false);
            if (objs.Length > 0) gcForm.StatusBar.Items.Remove(objs[0]);
            objs = gcForm.StatusBar.Items.Find(GetLabelName(name), false);
            if (objs.Length > 0) gcForm.StatusBar.Items.Remove(objs[0]);
        }

        private static string GetProgressBarName(string name)
        { return "PB_" + name; }
        private static string GetLabelName(string name)
        { return "L_" + name; }
    }
}
