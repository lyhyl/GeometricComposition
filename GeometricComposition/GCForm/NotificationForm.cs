using System.ComponentModel;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            base.Hide();
        }

        public new void Hide()
        {
            base.Hide();
        }

        public void Show(string message)
        {
            MessageLabel.Text = message;
            Show();
        }

        public string Message
        {
            set { MessageLabel.Text = value; }
            get { return MessageLabel.Text; }
        }

        public int Progress
        {
            set { ProgressBar.Value = value; }
            get { return ProgressBar.Value; }
        }
    }
}
