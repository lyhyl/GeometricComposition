using GeometricComposition.XNALibrary;
using GeometricComposition.XNALibrary.Control;
using GeometricComposition.XNALibrary.Modifier;
using System;
using System.Collections.Generic;

namespace GeometricComposition.GCForm
{
    public partial class ModifierForm : DockingForm
    {
        public ModifierForm(Commander com)
            : base(com)
        {
            InitializeComponent();

            ModifierComboBox.Text = "---None---";
        }

        private List<ModelModifier> Modifiers = null;

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
            ModifierListBox.Items.Clear();
            ModelModifiersPanel.Controls.Clear();
            if (e.File == null)
            {
                AddBtn.Enabled = false;
                RemoveBtn.Enabled = false;
                return;
            }
            AddBtn.Enabled = true;
            RemoveBtn.Enabled = true;

            Modifiers =  e.File.Model.Modifiers;
            ModifierListBox.Items.AddRange(Modifiers.ToArray());
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ModelModifier mm = null;
            switch (ModifierComboBox.SelectedIndex)
            {
                case 0:
                    mm = new ScaleModifier(); break;
                case 1:
                    mm = new TwistModifier(); break;
                default: return;
            }
            Modifiers.Add(mm);
            ModifierListBox.Items.Add(mm);
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (Modifiers.Count == 0)
                return;
            int index = Math.Max(ModifierListBox.SelectedIndex, 0);
            Modifiers.RemoveAt(index);
            ModifierListBox.Items.RemoveAt(index);
            ModelModifiersPanel.Controls.Clear();
        }

        private void ModifierListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ModifierListBox.SelectedIndex;
            if (index == -1) return;
            ModelModifier modifier = Modifiers[index];
            ModelModifiersPanel.Controls.Clear();
            ModelModifiersPanel.Controls.AddRange(modifier.Controls.ToArray());
        }
    }
}
