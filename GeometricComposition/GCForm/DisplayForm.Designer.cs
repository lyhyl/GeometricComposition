namespace GeometricComposition.GCForm
{
    partial class DisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayForm));
            this.ModelViewer = new GeometricComposition.DisplayControl.GCModelDisplayer();
            this.SuspendLayout();
            // 
            // ModelViewer
            // 
            this.ModelViewer.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ModelViewer.Camera = null;
            this.ModelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModelViewer.Location = new System.Drawing.Point(0, 0);
            this.ModelViewer.Model = null;
            this.ModelViewer.Name = "ModelViewer";
            this.ModelViewer.Size = new System.Drawing.Size(284, 262);
            this.ModelViewer.TabIndex = 1;
            this.ModelViewer.Text = "modelViewerControl1";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ModelViewer);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private GeometricComposition.DisplayControl.GCModelDisplayer ModelViewer;


    }
}