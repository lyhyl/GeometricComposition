using GeometricComposition.XNALibrary;
using System;
using System.Collections.Generic;

namespace GeometricComposition.GCForm
{
    public partial class ModifierForm : DockingForm
    {
        public ModifierForm(FormInteractor ras)
            : base(ras)
        {
            InitializeComponent();

            ModifierComboBox.Text = "Scale";
        }

        private List<ModelModifier> Modifiers = new List<ModelModifier>();
        public ModelModifier[] ModifiersArray { get { return Modifiers.ToArray(); } }

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
            Modifiers.Clear();
            ModifierListBox.Items.Clear();
            if (e.File == null)
                return;
            Modifiers.AddRange(e.File.Model.Modifiers);
            ModifierListBox.Items.AddRange(e.File.Model.Modifiers.ToArray());
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
                default: break;
            }
            Modifiers.Add(mm);
            ModifierListBox.Items.Add(mm);
            if (Interactor.CurrentFile != null)
                Interactor.CurrentFile.Model.Modifiers = Modifiers;
        }

        private void Removebtn_Click(object sender, EventArgs e)
        {
            if (Modifiers.Count == 0)
                return;
            int index = Math.Max(ModifierListBox.SelectedIndex, 0);
            Modifiers.RemoveAt(index);
            ModifierListBox.Items.RemoveAt(index);
        }
    }
}
