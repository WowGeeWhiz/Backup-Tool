namespace BackupToolWF
{
    partial class movingFiles
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
            this.workingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workingLabel
            // 
            this.workingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingLabel.Location = new System.Drawing.Point(0, 0);
            this.workingLabel.Name = "workingLabel";
            this.workingLabel.Size = new System.Drawing.Size(384, 161);
            this.workingLabel.TabIndex = 0;
            this.workingLabel.Text = "Working...";
            this.workingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movingFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.workingLabel);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "movingFiles";
            this.Text = "Backup Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private Label workingLabel;
    }
}