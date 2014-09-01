using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeometricComposition.XNALibrary.Control
{
    public class LabelComboBoxControl : ModelModifierControl
    {
        private Label label = new Label();
        private ComboBox combo = new ComboBox();

        public LabelComboBoxControl() : this("property", new object { }) { }
        public LabelComboBoxControl(string lab, params object[] items)
        {
            label.AutoSize = true;
            label.Text = lab + " : ";

            // force to auto size label
            Controls.Add(label);

            if (items.Length == 0)
                throw new ArgumentException("Should have more than one item");
            combo.Items.AddRange(items);
            combo.SelectedIndex = 0;

            Controls.Add(combo);

            label.Location = new Point(label.Margin.Left, label.Margin.Top);
            combo.Location = new Point(label.Margin.Left + label.Width + label.Margin.Right + combo.Margin.Left, 0);

            Width = label.Margin.Left + label.Width + label.Margin.Right +
                combo.Margin.Left + combo.Width + combo.Margin.Right;
            Height = Math.Max(label.Height, combo.Height);
        }

        public override T GetValue<T>()
        {
            Type type = typeof(T);
            if (type.IsEnum)
                return (T)Enum.ToObject(type, combo.SelectedIndex);
            else if (type == typeof(string))
                return (T)Convert.ChangeType(combo.SelectedText, type);
            return (T)Convert.ChangeType(combo.SelectedItem, type);
        }

        public override void SetValue<T>(T v)
        {
            Type type = typeof(T);
            if (type == typeof(string))// TODO if go here , fucking result
                combo.Text = (string)Convert.ChangeType(v, type);
            else
                combo.SelectedIndex = (int)Convert.ChangeType(v, typeof(int));
        }
    }
}
