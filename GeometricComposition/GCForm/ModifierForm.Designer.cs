namespace GeometricComposition.GCForm
{
    partial class ModifierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ModifierListBox = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ToolGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.ModifierComboBox = new System.Windows.Forms.ComboBox();
            this.ModifierListPropertySplitContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ToolGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifierListPropertySplitContainer)).BeginInit();
            this.ModifierListPropertySplitContainer.Panel1.SuspendLayout();
            this.ModifierListPropertySplitContainer.Panel2.SuspendLayout();
            this.ModifierListPropertySplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModifierListBox
            // 
            this.ModifierListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifierListBox.FormattingEnabled = true;
            this.ModifierListBox.ItemHeight = 12;
            this.ModifierListBox.Location = new System.Drawing.Point(0, 0);
            this.ModifierListBox.Name = "ModifierListBox";
            this.ModifierListBox.Size = new System.Drawing.Size(284, 137);
            this.ModifierListBox.TabIndex = 0;
            this.ModifierListBox.SelectedIndexChanged += new System.EventHandler(this.ModifierListBox_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(139, 20);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(23, 23);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ToolGroupBox
            // 
            this.ToolGroupBox.Controls.Add(this.RemoveBtn);
            this.ToolGroupBox.Controls.Add(this.ModifierComboBox);
            this.ToolGroupBox.Controls.Add(this.AddBtn);
            this.ToolGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ToolGroupBox.Name = "ToolGroupBox";
            this.ToolGroupBox.Size = new System.Drawing.Size(284, 53);
            this.ToolGroupBox.TabIndex = 2;
            this.ToolGroupBox.TabStop = false;
            this.ToolGroupBox.Text = "Add/Remove";
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Enabled = false;
            this.RemoveBtn.Location = new System.Drawing.Point(168, 20);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveBtn.TabIndex = 3;
            this.RemoveBtn.Text = "-";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // ModifierComboBox
            // 
            this.ModifierComboBox.FormattingEnabled = true;
            this.ModifierComboBox.Items.AddRange(new object[] {
            "Scale",
            "Twist"});
            this.ModifierComboBox.Location = new System.Drawing.Point(12, 20);
            this.ModifierComboBox.Name = "ModifierComboBox";
            this.ModifierComboBox.Size = new System.Drawing.Size(121, 20);
            this.ModifierComboBox.TabIndex = 2;
            // 
            // ModifierListPropertySplitContainer
            // 
            this.ModifierListPropertySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifierListPropertySplitContainer.Location = new System.Drawing.Point(0, 53);
            this.ModifierListPropertySplitContainer.Name = "ModifierListPropertySplitContainer";
            this.ModifierListPropertySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ModifierListPropertySplitContainer.Panel1
            // 
            this.ModifierListPropertySplitContainer.Panel1.Controls.Add(this.ModifierListBox);
            // 
            // ModifierListPropertySplitContainer.Panel2
            // 
            this.ModifierListPropertySplitContainer.Panel2.Controls.Add(this.flowLayoutPanel);
            this.ModifierListPropertySplitContainer.Size = new System.Drawing.Size(284, 209);
            this.ModifierListPropertySplitContainer.SplitterDistance = 137;
            this.ModifierListPropertySplitContainer.TabIndex = 3;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(284, 68);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // ModifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ModifierListPropertySplitContainer);
            this.Controls.Add(this.ToolGroupBox);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "ModifierForm";
            this.Text = "Modifier";
            this.ToolGroupBox.ResumeLayout(false);
            this.ModifierListPropertySplitContainer.Panel1.ResumeLayout(false);
            this.ModifierListPropertySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifierListPropertySplitContainer)).EndInit();
            this.ModifierListPropertySplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ModifierListBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.GroupBox ToolGroupBox;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.ComboBox ModifierComboBox;
        private System.Windows.Forms.SplitContainer ModifierListPropertySplitContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}