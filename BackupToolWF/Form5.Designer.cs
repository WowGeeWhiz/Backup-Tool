namespace BackupToolWF
{
    partial class manageSavesForm
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
            this.versionLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.managePresets = new System.Windows.Forms.Button();
            this.manageScreenLabel = new System.Windows.Forms.Label();
            this.managePaths = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 546);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(94, 15);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "Version text here";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(225, 434);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(150, 25);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // managePresets
            // 
            this.managePresets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.managePresets.Location = new System.Drawing.Point(225, 103);
            this.managePresets.Name = "managePresets";
            this.managePresets.Size = new System.Drawing.Size(150, 25);
            this.managePresets.TabIndex = 12;
            this.managePresets.Text = "Manage Presets";
            this.managePresets.UseVisualStyleBackColor = true;
            this.managePresets.Click += new System.EventHandler(this.managePresets_Click);
            // 
            // manageScreenLabel
            // 
            this.manageScreenLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.manageScreenLabel.AutoSize = true;
            this.manageScreenLabel.Location = new System.Drawing.Point(225, 75);
            this.manageScreenLabel.Name = "manageScreenLabel";
            this.manageScreenLabel.Size = new System.Drawing.Size(150, 15);
            this.manageScreenLabel.TabIndex = 13;
            this.manageScreenLabel.Text = "Manage Saved Information";
            this.manageScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // managePaths
            // 
            this.managePaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.managePaths.Location = new System.Drawing.Point(225, 134);
            this.managePaths.Name = "managePaths";
            this.managePaths.Size = new System.Drawing.Size(150, 25);
            this.managePaths.TabIndex = 14;
            this.managePaths.Text = "Manage Paths";
            this.managePaths.UseVisualStyleBackColor = true;
            this.managePaths.Click += new System.EventHandler(this.managePaths_Click);
            // 
            // manageSavesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.managePaths);
            this.Controls.Add(this.manageScreenLabel);
            this.Controls.Add(this.managePresets);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.backButton);
            this.Name = "manageSavesForm";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label versionLabel;
        private Button backButton;
        private Button managePresets;
        private Label manageScreenLabel;
        private Button managePaths;
    }
}