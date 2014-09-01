using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeometricComposition.XNALibrary.Control
{
    public class LabelValueControl : ModelModifierControl
    {
        private Label label = new Label();
        private NumericUpDown numeric = new NumericUpDown();

        public LabelValueControl() : this("property", 0.1m, decimal.MinValue, decimal.MaxValue) { }
        public LabelValueControl(string lab) : this(lab, 0.1m, decimal.MinValue, decimal.MaxValue) { }
        public LabelValueControl(string lab, decimal inc) : this(lab, inc, decimal.MinValue, decimal.MaxValue) { }
        public LabelValueControl(string lab, decimal min, decimal max) : this(lab, 0.1m, decimal.MinValue, decimal.MaxValue) { }
        public LabelValueControl(string lab, decimal inc, decimal min, decimal max)
        {
            label.AutoSize = true;
            label.Text = lab + " : ";

            // force to auto size label
            Controls.Add(label);

            numeric.DecimalPlaces = 2;
            numeric.Increment = inc;
            numeric.Minimum = min;
            numeric.Maximum = max;
            numeric.Value = 0;

            Controls.Add(numeric);

            label.Location = new Point(label.Margin.Left, label.Margin.Top);
            numeric.Location = new Point(label.Margin.Left + label.Width + label.Margin.Right + numeric.Margin.Left, 0);

            Width = label.Margin.Left + label.Width + label.Margin.Right +
                numeric.Margin.Left + numeric.Width + numeric.Margin.Right;
            Height = Math.Max(label.Height, numeric.Height);
        }

        public string Label
        {
            set
            {
                label.Text = value;
                numeric.Location = new Point(label.Margin.Left + label.Width + label.Margin.Right + numeric.Margin.Left, 0);
            }
            get { return label.Text; }
        }

        public override T GetValue<T>()
        {
            return (T)Convert.ChangeType(numeric.Value, typeof(T));
        }

        public override void SetValue<T>(T v)
        {
            numeric.Value = Convert.ToDecimal(v);
        }
    }
}
