namespace GeometricComposition.GCForm
{
    partial class DataForm
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
            this.FacePointTreeView = new System.Windows.Forms.TreeView();
            this.DataToolGroupBox = new System.Windows.Forms.GroupBox();
            this.SortFPPComboBoxB = new System.Windows.Forms.ComboBox();
            this.SortFPPLabelB = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SortFPPLabelA = new System.Windows.Forms.Label();
            this.SortFPPComboBoxA = new System.Windows.Forms.ComboBox();
            this.DataToolGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FacePointTreeView
            // 
            this.FacePointTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacePointTreeView.Location = new System.Drawing.Point(0, 66);
            this.FacePointTreeView.Name = "FacePointTreeView";
            this.FacePointTreeView.Size = new System.Drawing.Size(299, 196);
            this.FacePointTreeView.TabIndex = 4;
            this.FacePointTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FacePointTreeView_AfterSelect);
            // 
            // DataToolGroupBox
            // 
            this.DataToolGroupBox.Controls.Add(this.SortFPPComboBoxB);
            this.DataToolGroupBox.Controls.Add(this.SortFPPLabelB);
            this.DataToolGroupBox.Controls.Add(this.RefreshBtn);
            this.DataToolGroupBox.Controls.Add(this.SortFPPLabelA);
            this.DataToolGroupBox.Controls.Add(this.SortFPPComboBoxA);
            this.DataToolGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataToolGroupBox.Location = new System.Drawing.Point(0, 0);
            this.DataToolGroupBox.Name = "DataToolGroupBox";
            this.DataToolGroupBox.Size = new System.Drawing.Size(299, 66);
            this.DataToolGroupBox.TabIndex = 5;
            this.DataToolGroupBox.TabStop = false;
            this.DataToolGroupBox.Text = "Options";
            // 
            // SortFPPComboBoxB
            // 
            this.SortFPPComboBoxB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortFPPComboBoxB.FormattingEnabled = true;
            this.SortFPPComboBoxB.Items.AddRange(new object[] {
            "Point Pitch",
            "Distance"});
            this.SortFPPComboBoxB.Location = new System.Drawing.Point(89, 40);
            this.SortFPPComboBoxB.Name = "SortFPPComboBoxB";
            this.SortFPPComboBoxB.Size = new System.Drawing.Size(121, 20);
            this.SortFPPComboBoxB.TabIndex = 4;
            // 
            // SortFPPLabelB
            // 
            this.SortFPPLabelB.AutoSize = true;
            this.SortFPPLabelB.Location = new System.Drawing.Point(12, 43);
            this.SortFPPLabelB.Name = "SortFPPLabelB";
            this.SortFPPLabelB.Size = new System.Drawing.Size(71, 12);
            this.SortFPPLabelB.TabIndex = 3;
            this.SortFPPLabelB.Text = "Sort By(B):";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(216, 14);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 2;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // SortFPPLabelA
            // 
            this.SortFPPLabelA.AutoSize = true;
            this.SortFPPLabelA.Location = new System.Drawing.Point(12, 17);
            this.SortFPPLabelA.Name = "SortFPPLabelA";
            this.SortFPPLabelA.Size = new System.Drawing.Size(71, 12);
            this.SortFPPLabelA.TabIndex = 1;
            this.SortFPPLabelA.Text = "Sort By(A):";
            // 
            // SortFPPComboBoxA
            // 
            this.SortFPPComboBoxA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortFPPComboBoxA.FormattingEnabled = true;
            this.SortFPPComboBoxA.Items.AddRange(new object[] {
            "Point Pitch",
            "Distance"});
            this.SortFPPComboBoxA.Location = new System.Drawing.Point(89, 14);
            this.SortFPPComboBoxA.Name = "SortFPPComboBoxA";
            this.SortFPPComboBoxA.Size = new System.Drawing.Size(121, 20);
            this.SortFPPComboBoxA.TabIndex = 0;
            this.SortFPPComboBoxA.SelectedIndexChanged += new System.EventHandler(this.SortFPPComboBoxA_SelectedIndexChanged);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 262);
            this.Controls.Add(this.FacePointTreeView);
            this.Controls.Add(this.DataToolGroupBox);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "DataForm";
            this.Text = "Data";
            this.DataToolGroupBox.ResumeLayout(false);
            this.DataToolGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FacePointTreeView;
        private System.Windows.Forms.GroupBox DataToolGroupBox;
        private System.Windows.Forms.Label SortFPPLabelA;
        private System.Windows.Forms.ComboBox SortFPPComboBoxA;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.ComboBox SortFPPComboBoxB;
        private System.Windows.Forms.Label SortFPPLabelB;
    }
}