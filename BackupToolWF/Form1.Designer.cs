namespace BackupToolWF
{
    partial class mainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.versionLabel = new System.Windows.Forms.Label();
            this.duplicateDirectoryButton = new System.Windows.Forms.Button();
            this.mainMenuLabel = new System.Windows.Forms.Label();
            this.presetDuplicateButton = new System.Windows.Forms.Button();
            this.manageSavedInfoButton = new System.Windows.Forms.Button();
            this.contactButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.enableDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 534);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(94, 15);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version text here";
            // 
            // duplicateDirectoryButton
            // 
            this.duplicateDirectoryButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateDirectoryButton.Location = new System.Drawing.Point(225, 103);
            this.duplicateDirectoryButton.Name = "duplicateDirectoryButton";
            this.duplicateDirectoryButton.Size = new System.Drawing.Size(150, 25);
            this.duplicateDirectoryButton.TabIndex = 1;
            this.duplicateDirectoryButton.Text = "Duplicate a Directory";
            this.duplicateDirectoryButton.UseVisualStyleBackColor = true;
            this.duplicateDirectoryButton.Click += new System.EventHandler(this.duplicateDirectoryButton_Click);
            // 
            // mainMenuLabel
            // 
            this.mainMenuLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mainMenuLabel.AutoSize = true;
            this.mainMenuLabel.Location = new System.Drawing.Point(266, 75);
            this.mainMenuLabel.Name = "mainMenuLabel";
            this.mainMenuLabel.Size = new System.Drawing.Size(68, 15);
            this.mainMenuLabel.TabIndex = 2;
            this.mainMenuLabel.Text = "Main Menu";
            // 
            // presetDuplicateButton
            // 
            this.presetDuplicateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.presetDuplicateButton.Location = new System.Drawing.Point(225, 134);
            this.presetDuplicateButton.Name = "presetDuplicateButton";
            this.presetDuplicateButton.Size = new System.Drawing.Size(150, 25);
            this.presetDuplicateButton.TabIndex = 3;
            this.presetDuplicateButton.Text = "Run a Preset";
            this.presetDuplicateButton.UseVisualStyleBackColor = true;
            this.presetDuplicateButton.Click += new System.EventHandler(this.presetDuplicateButton_Click);
            // 
            // manageSavedInfoButton
            // 
            this.manageSavedInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.manageSavedInfoButton.Location = new System.Drawing.Point(225, 165);
            this.manageSavedInfoButton.Name = "manageSavedInfoButton";
            this.manageSavedInfoButton.Size = new System.Drawing.Size(150, 23);
            this.manageSavedInfoButton.TabIndex = 4;
            this.manageSavedInfoButton.Text = "Manage Presets/Paths\r\n";
            this.manageSavedInfoButton.UseVisualStyleBackColor = true;
            this.manageSavedInfoButton.Click += new System.EventHandler(this.manageSavedInfoButton_Click);
            // 
            // contactButton
            // 
            this.contactButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.contactButton.Location = new System.Drawing.Point(225, 463);
            this.contactButton.Name = "contactButton";
            this.contactButton.Size = new System.Drawing.Size(150, 25);
            this.contactButton.TabIndex = 5;
            this.contactButton.Text = "Contact the Developer";
            this.contactButton.UseVisualStyleBackColor = true;
            this.contactButton.Click += new System.EventHandler(this.contactButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitButton.Location = new System.Drawing.Point(225, 434);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // enableDebug
            // 
            this.enableDebug.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.enableDebug.Location = new System.Drawing.Point(225, 494);
            this.enableDebug.Name = "enableDebug";
            this.enableDebug.Size = new System.Drawing.Size(150, 23);
            this.enableDebug.TabIndex = 7;
            this.enableDebug.Text = "Enable Debug";
            this.enableDebug.UseVisualStyleBackColor = true;
            this.enableDebug.Click += new System.EventHandler(this.enableDebug_Click);
            // 
            // mainMenu
            // 
            this.AcceptButton = this.duplicateDirectoryButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(584, 559);
            this.Controls.Add(this.enableDebug);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.contactButton);
            this.Controls.Add(this.manageSavedInfoButton);
            this.Controls.Add(this.presetDuplicateButton);
            this.Controls.Add(this.mainMenuLabel);
            this.Controls.Add(this.duplicateDirectoryButton);
            this.Controls.Add(this.versionLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 598);
            this.MinimumSize = new System.Drawing.Size(600, 598);
            this.Name = "mainMenu";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Text = "Backup Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label versionLabel;
        private Button duplicateDirectoryButton;
        private Label mainMenuLabel;
        private Button presetDuplicateButton;
        private Button manageSavedInfoButton;
        private Button contactButton;
        private Button exitButton;
        private Button enableDebug;
    }
}