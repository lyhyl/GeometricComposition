using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GeometricComposition.GCForm
{
    public partial class ProjectSettingForm : DockingForm
    {
        private const int PitchCount = 12;

        public ProjectSettingForm()
        {
            InitializeComponent();
        }

        private List<MaskedTextBox> pitchMapIDBoxs = new List<MaskedTextBox>();
        public ProjectSettingForm(Commander com)
            : base(com)
        {
            InitializeComponent();

            SetFixedFloatWindowSetting();

            pitchMapIDBoxs.AddRange(new MaskedTextBox[] {
                pitchMapIDBox0, pitchMapIDBox1, pitchMapIDBox2,
                pitchMapIDBox3, pitchMapIDBox4, pitchMapIDBox5,
                pitchMapIDBox6, pitchMapIDBox7, pitchMapIDBox8,
                pitchMapIDBox9, pitchMapIDBox10, pitchMapIDBox11
            });
        }

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
            RandomizePitchMapBtn.Enabled = e.File != null;
            if (e.File != null)
                FillForm();
            else
                ClearForm();
            base.HandleSelectedFileChanged(sender, e);
        }

        protected override void OnShown(EventArgs e)
        {
            if (Commander.CurrentFile != null)
                FillForm();
            base.OnShown(e);
        }

        private void ClearForm()
        {
            for (int i = 0; i < PitchCount; i++)
                pitchMapIDBoxs[i].Text = "";
        }

        private void FillForm()
        {
            for (int i = 0; i < PitchCount; i++)
                pitchMapIDBoxs[i].Text = Commander.CurrentFile.PitchMap[i].ToString();
        }

        private void RandomizePitchMapBtn_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>(PitchCount);
            Random rand = new Random();
            for (int i = 0; i < PitchCount; i++)
                ids.Add(i);
            for (int i = 0; i < PitchCount; i++)
            {
                int ind = rand.Next(ids.Count);
                Commander.CurrentFile.PitchMap[i] = ids[ind];
                ids.RemoveAt(ind);
            }
            FillForm();
        }
    }
}
