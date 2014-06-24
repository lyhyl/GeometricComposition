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
            this.SplitPlane = new System.Windows.Forms.SplitContainer();
            this.mvc = new GCXNA.XNADisplayControl();
            this.FacePointListBox = new System.Windows.Forms.ListBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.TB_StopOrPlayToolBtn = new System.Windows.Forms.ToolStripButton();
            this.AsyncWorker = new System.ComponentModel.BackgroundWorker();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.SB_WorkLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SB_WorkProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlane)).BeginInit();
            this.SplitPlane.Panel1.SuspendLayout();
            this.SplitPlane.Panel2.SuspendLayout();
            this.SplitPlane.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitPlane
            // 
            this.SplitPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPlane.Location = new System.Drawing.Point(0, 25);
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
            this.SplitPlane.Size = new System.Drawing.Size(624, 395);
            this.SplitPlane.SplitterDistance = 450;
            this.SplitPlane.TabIndex = 1;
            // 
            // mvc
            // 
            this.mvc.Animation = true;
            this.mvc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mvc.Location = new System.Drawing.Point(0, 0);
            this.mvc.Model = null;
            this.mvc.Name = "mvc";
            this.mvc.Size = new System.Drawing.Size(450, 395);
            this.mvc.TabIndex = 0;
            this.mvc.Text = "modelViewerControl1";
            // 
            // FacePointListBox
            // 
            this.FacePointListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacePointListBox.FormattingEnabled = true;
            this.FacePointListBox.ItemHeight = 12;
            this.FacePointListBox.Location = new System.Drawing.Point(0, 23);
            this.FacePointListBox.Name = "FacePointListBox";
            this.FacePointListBox.Size = new System.Drawing.Size(170, 372);
            this.FacePointListBox.TabIndex = 1;
            this.FacePointListBox.SelectedIndexChanged += new System.EventHandler(this.FacePointListBox_SelectedIndexChanged);
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
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TB_StopOrPlayToolBtn});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(624, 25);
            this.ToolBar.TabIndex = 2;
            // 
            // TB_StopOrPlayToolBtn
            // 
            this.TB_StopOrPlayToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TB_StopOrPlayToolBtn.Image = global::GeometricComposition.Properties.Resources.stop_icon;
            this.TB_StopOrPlayToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TB_StopOrPlayToolBtn.Name = "TB_StopOrPlayToolBtn";
            this.TB_StopOrPlayToolBtn.Size = new System.Drawing.Size(23, 22);
            this.TB_StopOrPlayToolBtn.Text = "Animation";
            this.TB_StopOrPlayToolBtn.Click += new System.EventHandler(this.TB_StopOrPlayToolBtn_Click);
            // 
            // AsyncWorker
            // 
            this.AsyncWorker.WorkerReportsProgress = true;
            this.AsyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.AsyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.AsyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SB_WorkLabel,
            this.SB_WorkProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 420);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(624, 22);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.Text = "statusStrip1";
            // 
            // SB_WorkLabel
            // 
            this.SB_WorkLabel.Name = "SB_WorkLabel";
            this.SB_WorkLabel.Size = new System.Drawing.Size(98, 17);
            this.SB_WorkLabel.Text = "Current Work : ";
            // 
            // SB_WorkProgressBar
            // 
            this.SB_WorkProgressBar.Name = "SB_WorkProgressBar";
            this.SB_WorkProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // GeometricComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.SplitPlane);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Name = "GeometricComposition";
            this.Text = "Geometric Composition";
            this.SplitPlane.Panel1.ResumeLayout(false);
            this.SplitPlane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlane)).EndInit();
            this.SplitPlane.ResumeLayout(false);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GCXNA.XNADisplayControl mvc;
        private System.Windows.Forms.SplitContainer SplitPlane;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.ListBox FacePointListBox;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton TB_StopOrPlayToolBtn;
        private System.ComponentModel.BackgroundWorker AsyncWorker;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripProgressBar SB_WorkProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel SB_WorkLabel;
    }
}

