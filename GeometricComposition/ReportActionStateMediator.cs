using System.Windows.Forms;

namespace GeometricComposition
{
    public class ReportActionStateMediator
    {
        GeometricComposition gcForm = null;

        public ReportActionStateMediator(GeometricComposition gc)
        {
            gcForm = gc;
        }

        public void StartAction(string name)
        {
            ToolStripLabel label = new ToolStripLabel();
            label.Name = "L_" + name;
            label.Text = name + " : ";
            ToolStripProgressBar pbar = new ToolStripProgressBar();
            pbar.Name = "PB_" + name;

            gcForm.StatusBar.Items.Add(label);
            gcForm.StatusBar.Items.Add(pbar);
        }

        public void ReportActionProgress(string name, int percentage)
        {
            ToolStripItem[] objs = gcForm.StatusBar.Items.Find("PB_" + name, false);
            if (objs.Length > 0)
            {
                ToolStripProgressBar pbar = objs[0] as ToolStripProgressBar;
                if (pbar != null)
                    pbar.Value = percentage;
            }
        }

        public void CompleteAction(string name)
        {
            ToolStripItem[] objs;
            objs = gcForm.StatusBar.Items.Find("PB_" + name, false);
            if (objs.Length > 0)
                gcForm.StatusBar.Items.Remove(objs[0]);
            objs = gcForm.StatusBar.Items.Find("L_" + name, false);
            if (objs.Length > 0)
                gcForm.StatusBar.Items.Remove(objs[0]);
        }
    }
}
