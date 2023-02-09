namespace BackupToolWF
{
    partial class duplicateDirectoryScreen
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
            this.directoryToDuplicateGroup = new System.Windows.Forms.GroupBox();
            this.browseInput = new System.Windows.Forms.Button();
            this.loadSavedPathList = new System.Windows.Forms.ListBox();
            this.loadNewPathEntry = new System.Windows.Forms.TextBox();
            this.loadNewPathOption = new System.Windows.Forms.RadioButton();
            this.loadSavedPathOption = new System.Windows.Forms.RadioButton();
            this.duplicatingDirectoryLabel = new System.Windows.Forms.Label();
            this.duplicateToGroup = new System.Windows.Forms.GroupBox();
            this.browseOutput = new System.Windows.Forms.Button();
            this.duplicateToSavedPathList = new System.Windows.Forms.ListBox();
            this.duplicateToNewPathEntry = new System.Windows.Forms.TextBox();
            this.duplicateToSavedPathOption = new System.Windows.Forms.RadioButton();
            this.duplicateToNewPathOption = new System.Windows.Forms.RadioButton();
            this.makePresetOption = new System.Windows.Forms.CheckBox();
            this.makePresetNameEntry = new System.Windows.Forms.TextBox();
            this.saveNewLoadPathOption = new System.Windows.Forms.CheckBox();
            this.saveNewSavePathOption = new System.Windows.Forms.CheckBox();
            this.duplicateButton = new System.Windows.Forms.Button();
            this.newSaveInputLabel = new System.Windows.Forms.Label();
            this.newSaveOutputLabel = new System.Windows.Forms.Label();
            this.duplicatePresetNameText = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.directoryToDuplicateGroup.SuspendLayout();
            this.duplicateToGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 715);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(119, 20);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Version text here";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(349, 697);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(154, 33);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // directoryToDuplicateGroup
            // 
            this.directoryToDuplicateGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.directoryToDuplicateGroup.AutoSize = true;
            this.directoryToDuplicateGroup.Controls.Add(this.browseInput);
            this.directoryToDuplicateGroup.Controls.Add(this.loadSavedPathList);
            this.directoryToDuplicateGroup.Controls.Add(this.loadNewPathEntry);
            this.directoryToDuplicateGroup.Controls.Add(this.loadNewPathOption);
            this.directoryToDuplicateGroup.Controls.Add(this.loadSavedPathOption);
            this.directoryToDuplicateGroup.Location = new System.Drawing.Point(15, 37);
            this.directoryToDuplicateGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.directoryToDuplicateGroup.Name = "directoryToDuplicateGroup";
            this.directoryToDuplicateGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.directoryToDuplicateGroup.Size = new System.Drawing.Size(645, 241);
            this.directoryToDuplicateGroup.TabIndex = 3;
            this.directoryToDuplicateGroup.TabStop = false;
            this.directoryToDuplicateGroup.Text = "Directory to duplicate";
            // 
            // browseInput
            // 
            this.browseInput.Location = new System.Drawing.Point(545, 25);
            this.browseInput.Name = "browseInput";
            this.browseInput.Size = new System.Drawing.Size(94, 29);
            this.browseInput.TabIndex = 4;
            this.browseInput.Text = "Browse";
            this.browseInput.UseVisualStyleBackColor = true;
            this.browseInput.Click += new System.EventHandler(this.browseInput_Click);
            // 
            // loadSavedPathList
            // 
            this.loadSavedPathList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadSavedPathList.FormattingEnabled = true;
            this.loadSavedPathList.ItemHeight = 20;
            this.loadSavedPathList.Location = new System.Drawing.Point(7, 84);
            this.loadSavedPathList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadSavedPathList.Name = "loadSavedPathList";
            this.loadSavedPathList.Size = new System.Drawing.Size(630, 124);
            this.loadSavedPathList.TabIndex = 3;
            this.loadSavedPathList.SelectedIndexChanged += new System.EventHandler(this.loadSavedPathList_SelectedIndexChanged);
            // 
            // loadNewPathEntry
            // 
            this.loadNewPathEntry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadNewPathEntry.Enabled = false;
            this.loadNewPathEntry.Location = new System.Drawing.Point(309, 25);
            this.loadNewPathEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadNewPathEntry.Name = "loadNewPathEntry";
            this.loadNewPathEntry.PlaceholderText = "New Input Directory";
            this.loadNewPathEntry.Size = new System.Drawing.Size(230, 27);
            this.loadNewPathEntry.TabIndex = 2;
            this.loadNewPathEntry.TextChanged += new System.EventHandler(this.loadNewPathEntry_TextChanged);
            // 
            // loadNewPathOption
            // 
            this.loadNewPathOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadNewPathOption.Location = new System.Drawing.Point(165, 31);
            this.loadNewPathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadNewPathOption.Name = "loadNewPathOption";
            this.loadNewPathOption.Size = new System.Drawing.Size(137, 25);
            this.loadNewPathOption.TabIndex = 1;
            this.loadNewPathOption.TabStop = true;
            this.loadNewPathOption.Text = "Use a new path:";
            this.loadNewPathOption.UseVisualStyleBackColor = true;
            this.loadNewPathOption.CheckedChanged += new System.EventHandler(this.loadNewPathOption_CheckedChanged);
            // 
            // loadSavedPathOption
            // 
            this.loadSavedPathOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadSavedPathOption.Location = new System.Drawing.Point(7, 31);
            this.loadSavedPathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadSavedPathOption.Name = "loadSavedPathOption";
            this.loadSavedPathOption.Size = new System.Drawing.Size(151, 25);
            this.loadSavedPathOption.TabIndex = 0;
            this.loadSavedPathOption.TabStop = true;
            this.loadSavedPathOption.Text = "Use a saved path";
            this.loadSavedPathOption.UseVisualStyleBackColor = true;
            this.loadSavedPathOption.CheckedChanged += new System.EventHandler(this.loadSavedPathOption_CheckedChanged);
            // 
            // duplicatingDirectoryLabel
            // 
            this.duplicatingDirectoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicatingDirectoryLabel.AutoSize = true;
            this.duplicatingDirectoryLabel.Location = new System.Drawing.Point(263, 13);
            this.duplicatingDirectoryLabel.Name = "duplicatingDirectoryLabel";
            this.duplicatingDirectoryLabel.Size = new System.Drawing.Size(161, 20);
            this.duplicatingDirectoryLabel.TabIndex = 4;
            this.duplicatingDirectoryLabel.Text = "Duplicating a directory";
            // 
            // duplicateToGroup
            // 
            this.duplicateToGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateToGroup.Controls.Add(this.browseOutput);
            this.duplicateToGroup.Controls.Add(this.duplicateToSavedPathList);
            this.duplicateToGroup.Controls.Add(this.duplicateToNewPathEntry);
            this.duplicateToGroup.Controls.Add(this.duplicateToSavedPathOption);
            this.duplicateToGroup.Controls.Add(this.duplicateToNewPathOption);
            this.duplicateToGroup.Location = new System.Drawing.Point(15, 287);
            this.duplicateToGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToGroup.Name = "duplicateToGroup";
            this.duplicateToGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToGroup.Size = new System.Drawing.Size(645, 241);
            this.duplicateToGroup.TabIndex = 5;
            this.duplicateToGroup.TabStop = false;
            this.duplicateToGroup.Text = "Duplicating to";
            // 
            // browseOutput
            // 
            this.browseOutput.Location = new System.Drawing.Point(545, 23);
            this.browseOutput.Name = "browseOutput";
            this.browseOutput.Size = new System.Drawing.Size(94, 29);
            this.browseOutput.TabIndex = 5;
            this.browseOutput.Text = "Browse";
            this.browseOutput.UseVisualStyleBackColor = true;
            this.browseOutput.Click += new System.EventHandler(this.browseOutput_Click);
            // 
            // duplicateToSavedPathList
            // 
            this.duplicateToSavedPathList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateToSavedPathList.FormattingEnabled = true;
            this.duplicateToSavedPathList.ItemHeight = 20;
            this.duplicateToSavedPathList.Location = new System.Drawing.Point(7, 85);
            this.duplicateToSavedPathList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToSavedPathList.Name = "duplicateToSavedPathList";
            this.duplicateToSavedPathList.Size = new System.Drawing.Size(630, 124);
            this.duplicateToSavedPathList.TabIndex = 7;
            this.duplicateToSavedPathList.SelectedIndexChanged += new System.EventHandler(this.duplicateToSavedPathList_SelectedIndexChanged);
            // 
            // duplicateToNewPathEntry
            // 
            this.duplicateToNewPathEntry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateToNewPathEntry.Enabled = false;
            this.duplicateToNewPathEntry.Location = new System.Drawing.Point(309, 21);
            this.duplicateToNewPathEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToNewPathEntry.Name = "duplicateToNewPathEntry";
            this.duplicateToNewPathEntry.PlaceholderText = "New Output Directory";
            this.duplicateToNewPathEntry.Size = new System.Drawing.Size(230, 27);
            this.duplicateToNewPathEntry.TabIndex = 6;
            this.duplicateToNewPathEntry.TextChanged += new System.EventHandler(this.duplicateToNewPathEntry_TextChanged);
            // 
            // duplicateToSavedPathOption
            // 
            this.duplicateToSavedPathOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateToSavedPathOption.Location = new System.Drawing.Point(7, 27);
            this.duplicateToSavedPathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToSavedPathOption.Name = "duplicateToSavedPathOption";
            this.duplicateToSavedPathOption.Size = new System.Drawing.Size(151, 25);
            this.duplicateToSavedPathOption.TabIndex = 4;
            this.duplicateToSavedPathOption.TabStop = true;
            this.duplicateToSavedPathOption.Text = "Use a saved path";
            this.duplicateToSavedPathOption.UseVisualStyleBackColor = true;
            this.duplicateToSavedPathOption.CheckedChanged += new System.EventHandler(this.duplicateToSavedPathOption_CheckedChanged);
            // 
            // duplicateToNewPathOption
            // 
            this.duplicateToNewPathOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duplicateToNewPathOption.Location = new System.Drawing.Point(165, 27);
            this.duplicateToNewPathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateToNewPathOption.Name = "duplicateToNewPathOption";
            this.duplicateToNewPathOption.Size = new System.Drawing.Size(137, 25);
            this.duplicateToNewPathOption.TabIndex = 5;
            this.duplicateToNewPathOption.TabStop = true;
            this.duplicateToNewPathOption.Text = "Use a new path:";
            this.duplicateToNewPathOption.UseVisualStyleBackColor = true;
            this.duplicateToNewPathOption.CheckedChanged += new System.EventHandler(this.duplicateToNewPathOption_CheckedChanged);
            // 
            // makePresetOption
            // 
            this.makePresetOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.makePresetOption.Location = new System.Drawing.Point(15, 541);
            this.makePresetOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.makePresetOption.Name = "makePresetOption";
            this.makePresetOption.Size = new System.Drawing.Size(173, 25);
            this.makePresetOption.TabIndex = 6;
            this.makePresetOption.Text = "Make this a preset";
            this.makePresetOption.UseVisualStyleBackColor = true;
            this.makePresetOption.CheckedChanged += new System.EventHandler(this.makePresetOption_CheckedChanged);
            // 
            // makePresetNameEntry
            // 
            this.makePresetNameEntry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.makePresetNameEntry.Location = new System.Drawing.Point(194, 541);
            this.makePresetNameEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.makePresetNameEntry.Name = "makePresetNameEntry";
            this.makePresetNameEntry.PlaceholderText = "Enter the name for the preset (no spaces/special characters)";
            this.makePresetNameEntry.Size = new System.Drawing.Size(458, 27);
            this.makePresetNameEntry.TabIndex = 7;
            this.makePresetNameEntry.TextChanged += new System.EventHandler(this.makePresetNameEntry_TextChanged);
            // 
            // saveNewLoadPathOption
            // 
            this.saveNewLoadPathOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveNewLoadPathOption.Location = new System.Drawing.Point(15, 575);
            this.saveNewLoadPathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveNewLoadPathOption.Name = "saveNewLoadPathOption";
            this.saveNewLoadPathOption.Size = new System.Drawing.Size(173, 25);
            this.saveNewLoadPathOption.TabIndex = 8;
            this.saveNewLoadPathOption.Text = "Save this input path";
            this.saveNewLoadPathOption.UseVisualStyleBackColor = true;
            this.saveNewLoadPathOption.CheckedChanged += new System.EventHandler(this.saveNewLoadPathOption_CheckedChanged);
            // 
            // saveNewSavePathOption
            // 
            this.saveNewSavePathOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveNewSavePathOption.Location = new System.Drawing.Point(15, 608);
            this.saveNewSavePathOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveNewSavePathOption.Name = "saveNewSavePathOption";
            this.saveNewSavePathOption.Size = new System.Drawing.Size(173, 25);
            this.saveNewSavePathOption.TabIndex = 9;
            this.saveNewSavePathOption.Text = "Save this output path";
            this.saveNewSavePathOption.UseVisualStyleBackColor = true;
            this.saveNewSavePathOption.CheckedChanged += new System.EventHandler(this.saveNewSavePathOption_CheckedChanged);
            // 
            // duplicateButton
            // 
            this.duplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateButton.Location = new System.Drawing.Point(510, 697);
            this.duplicateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(154, 33);
            this.duplicateButton.TabIndex = 10;
            this.duplicateButton.Text = "Duplicate directory";
            this.duplicateButton.UseVisualStyleBackColor = true;
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // newSaveInputLabel
            // 
            this.newSaveInputLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newSaveInputLabel.Location = new System.Drawing.Point(194, 576);
            this.newSaveInputLabel.Name = "newSaveInputLabel";
            this.newSaveInputLabel.Size = new System.Drawing.Size(458, 31);
            this.newSaveInputLabel.TabIndex = 11;
            this.newSaveInputLabel.Text = "new input goes here";
            // 
            // newSaveOutputLabel
            // 
            this.newSaveOutputLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newSaveOutputLabel.Location = new System.Drawing.Point(194, 609);
            this.newSaveOutputLabel.Name = "newSaveOutputLabel";
            this.newSaveOutputLabel.Size = new System.Drawing.Size(458, 31);
            this.newSaveOutputLabel.TabIndex = 12;
            this.newSaveOutputLabel.Text = "new output goes here";
            // 
            // duplicatePresetNameText
            // 
            this.duplicatePresetNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicatePresetNameText.AutoSize = true;
            this.duplicatePresetNameText.Location = new System.Drawing.Point(419, 673);
            this.duplicatePresetNameText.Name = "duplicatePresetNameText";
            this.duplicatePresetNameText.Size = new System.Drawing.Size(257, 20);
            this.duplicatePresetNameText.TabIndex = 13;
            this.duplicatePresetNameText.Text = "A preset with this name already exists";
            // 
            // duplicateDirectoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 748);
            this.Controls.Add(this.duplicatePresetNameText);
            this.Controls.Add(this.newSaveOutputLabel);
            this.Controls.Add(this.newSaveInputLabel);
            this.Controls.Add(this.duplicateButton);
            this.Controls.Add(this.saveNewSavePathOption);
            this.Controls.Add(this.saveNewLoadPathOption);
            this.Controls.Add(this.makePresetNameEntry);
            this.Controls.Add(this.makePresetOption);
            this.Controls.Add(this.duplicateToGroup);
            this.Controls.Add(this.duplicatingDirectoryLabel);
            this.Controls.Add(this.directoryToDuplicateGroup);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.versionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(340, 515);
            this.Name = "duplicateDirectoryScreen";
            this.Padding = new System.Windows.Forms.Padding(0, 13, 0, 13);
            this.Text = "Backup Tool";
            this.directoryToDuplicateGroup.ResumeLayout(false);
            this.directoryToDuplicateGroup.PerformLayout();
            this.duplicateToGroup.ResumeLayout(false);
            this.duplicateToGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label versionLabel;
        private Button backButton;
        private GroupBox directoryToDuplicateGroup;
        private Label duplicatingDirectoryLabel;
        private GroupBox duplicateToGroup;
        private RadioButton loadNewPathOption;
        private RadioButton loadSavedPathOption;
        private ListBox loadSavedPathList;
        private ListBox duplicateToSavedPathList;
        private TextBox duplicateToNewPathEntry;
        private RadioButton duplicateToSavedPathOption;
        private RadioButton duplicateToNewPathOption;
        private CheckBox makePresetOption;
        private TextBox makePresetNameEntry;
        private CheckBox saveNewLoadPathOption;
        private CheckBox saveNewSavePathOption;
        private Button duplicateButton;
        private Label newSaveInputLabel;
        private Label newSaveOutputLabel;
        private Label duplicatePresetNameText;
        private Button browseInput;
        private Button browseOutput;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox loadNewPathEntry;
    }
}