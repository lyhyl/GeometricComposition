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
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.TB_StopOrPlayToolBtn = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.WorkDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.myVS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TB_StopOrPlayToolBtn});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(284, 25);
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
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 240);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(284, 22);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.Text = "statusStrip1";
            // 
            // WorkDockPanel
            // 
            this.WorkDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkDockPanel.Location = new System.Drawing.Point(0, 25);
            this.WorkDockPanel.Name = "WorkDockPanel";
            this.WorkDockPanel.Size = new System.Drawing.Size(284, 215);
            this.WorkDockPanel.TabIndex = 4;
            this.WorkDockPanel.Theme = this.myVS2012LightTheme;
            // 
            // GeometricComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.WorkDockPanel);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.IsMdiContainer = true;
            this.Name = "GeometricComposition";
            this.Text = "Geometric Composition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton TB_StopOrPlayToolBtn;
        private WeifenLuo.WinFormsUI.Docking.DockPanel WorkDockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme myVS2012LightTheme;
        public System.Windows.Forms.StatusStrip StatusBar;
    }
}

