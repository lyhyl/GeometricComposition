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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
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
            this.WorkDockPanel.ActiveContentChanged += new System.EventHandler(this.WorkDockPanel_ActiveContentChanged);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(284, 25);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "menuStrip1";
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
            this.dataFormToolStripMenuItem,
            this.modifierFormToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.formToolStripMenuItem.Text = "&Form";
            // 
            // dataFormToolStripMenuItem
            // 
            this.dataFormToolStripMenuItem.Checked = true;
            this.dataFormToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dataFormToolStripMenuItem.Name = "dataFormToolStripMenuItem";
            this.dataFormToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dataFormToolStripMenuItem.Tag = "dataForm";
            this.dataFormToolStripMenuItem.Text = "&Data Form";
            this.dataFormToolStripMenuItem.Click += new System.EventHandler(this.dataFormToolStripMenuItem_Click);
            // 
            // modifierFormToolStripMenuItem
            // 
            this.modifierFormToolStripMenuItem.Checked = true;
            this.modifierFormToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.modifierFormToolStripMenuItem.Name = "modifierFormToolStripMenuItem";
            this.modifierFormToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.modifierFormToolStripMenuItem.Tag = "modifierForm";
            this.modifierFormToolStripMenuItem.Text = "&Modifier Form";
            this.modifierFormToolStripMenuItem.Click += new System.EventHandler(this.modifierFormToolStripMenuItem_Click);
            // 
            // GeometricComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.WorkDockPanel);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "GeometricComposition";
            this.Text = "Geometric Composition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private WeifenLuo.WinFormsUI.Docking.DockPanel WorkDockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme MyVS2012LightTheme;
        public System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TB_StopOrPlayToolBtn;
        private System.Windows.Forms.ToolStripMenuItem modifierFormToolStripMenuItem;
    }
}

