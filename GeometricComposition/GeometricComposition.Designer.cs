namespace GeometricComposition
{
    partial class GeometricComposition
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mvc = new GCXNA.XNADisplayControl();
            this.SplitPlane = new System.Windows.Forms.SplitContainer();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.FacePointListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlane)).BeginInit();
            this.SplitPlane.Panel1.SuspendLayout();
            this.SplitPlane.Panel2.SuspendLayout();
            this.SplitPlane.SuspendLayout();
            this.SuspendLayout();
            // 
            // mvc
            // 
            this.mvc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mvc.Location = new System.Drawing.Point(0, 0);
            this.mvc.Model = null;
            this.mvc.Name = "mvc";
            this.mvc.Size = new System.Drawing.Size(450, 442);
            this.mvc.TabIndex = 0;
            this.mvc.Text = "modelViewerControl1";
            // 
            // SplitPlane
            // 
            this.SplitPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPlane.Location = new System.Drawing.Point(0, 0);
            this.SplitPlane.Name = "SplitPlane";
            // 
            // SplitPlane.Panel1
            // 
            this.SplitPlane.Panel1.Controls.Add(this.mvc);
            // 
            // SplitPlane.Panel2
            // 
            this.SplitPlane.Panel2.Controls.Add(this.FacePointListBox);
            this.SplitPlane.Panel2.Controls.Add(this.GenerateBtn);
            this.SplitPlane.Size = new System.Drawing.Size(624, 442);
            this.SplitPlane.SplitterDistance = 450;
            this.SplitPlane.TabIndex = 1;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GenerateBtn.Location = new System.Drawing.Point(0, 0);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(170, 23);
            this.GenerateBtn.TabIndex = 0;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // FacePointListBox
            // 
            this.FacePointListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacePointListBox.FormattingEnabled = true;
            this.FacePointListBox.ItemHeight = 12;
            this.FacePointListBox.Location = new System.Drawing.Point(0, 23);
            this.FacePointListBox.Name = "FacePointListBox";
            this.FacePointListBox.Size = new System.Drawing.Size(170, 419);
            this.FacePointListBox.TabIndex = 1;
            this.FacePointListBox.SelectedIndexChanged += new System.EventHandler(this.FacePointListBox_SelectedIndexChanged);
            // 
            // GeometricComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.SplitPlane);
            this.Name = "GeometricComposition";
            this.Text = "Geometric Composition";
            this.SplitPlane.Panel1.ResumeLayout(false);
            this.SplitPlane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlane)).EndInit();
            this.SplitPlane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GCXNA.XNADisplayControl mvc;
        private System.Windows.Forms.SplitContainer SplitPlane;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.ListBox FacePointListBox;
    }
}

