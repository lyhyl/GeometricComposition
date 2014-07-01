namespace GeometricComposition.GCForm
{
    partial class ToolForm
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
            this.AsyncWorker = new System.ComponentModel.BackgroundWorker();
            this.FacePointListBox = new System.Windows.Forms.ListBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AsyncWorker
            // 
            this.AsyncWorker.WorkerReportsProgress = true;
            this.AsyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.AsyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.AsyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // FacePointListBox
            // 
            this.FacePointListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacePointListBox.FormattingEnabled = true;
            this.FacePointListBox.ItemHeight = 12;
            this.FacePointListBox.Location = new System.Drawing.Point(0, 23);
            this.FacePointListBox.Name = "FacePointListBox";
            this.FacePointListBox.Size = new System.Drawing.Size(284, 239);
            this.FacePointListBox.TabIndex = 3;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GenerateBtn.Location = new System.Drawing.Point(0, 0);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(284, 23);
            this.GenerateBtn.TabIndex = 2;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.FacePointListBox);
            this.Controls.Add(this.GenerateBtn);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ToolForm";
            this.Text = "ToolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker AsyncWorker;
        private System.Windows.Forms.ListBox FacePointListBox;
        private System.Windows.Forms.Button GenerateBtn;
    }
}