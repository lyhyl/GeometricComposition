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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeometricComposition));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.TB_StopOrPlayToolBtn = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.WorkDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MyVS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBar.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TB_StopOrPlayToolBtn});
            this.ToolBar.Location = new System.Drawing.Point(0, 25);
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
            this.WorkDockPanel.Location = new System.Drawing.Point(0, 50);
            this.WorkDockPanel.Name = "WorkDockPanel";
            this.WorkDockPanel.Size = new System.Drawing.Size(284, 190);
            this.WorkDockPanel.TabIndex = 4;
            this.WorkDockPanel.Theme = this.MyVS2012LightTheme;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(284, 25);
            this.Menu.TabIndex = 7;
            this.Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFormToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.formToolStripMenuItem.Text = "&Form";
            // 
            // toolFormToolStripMenuItem
            // 
            this.toolFormToolStripMenuItem.Checked = true;
            this.toolFormToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolFormToolStripMenuItem.Name = "toolFormToolStripMenuItem";
            this.toolFormToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.toolFormToolStripMenuItem.Text = "&Tool Form";
            this.toolFormToolStripMenuItem.Click += new System.EventHandler(this.toolFormToolStripMenuItem_Click);
            // 
            // GeometricComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.WorkDockPanel);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "GeometricComposition";
            this.Text = "Geometric Composition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton TB_StopOrPlayToolBtn;
        private WeifenLuo.WinFormsUI.Docking.DockPanel WorkDockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme MyVS2012LightTheme;
        public System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

