namespace BackupToolWF
{
    partial class managePresetsScreen
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
            this.presetList = new System.Windows.Forms.ListBox();
            this.presetScreenLabel = new System.Windows.Forms.Label();
            this.presetInfo = new System.Windows.Forms.GroupBox();
            this.applyChangesButton = new System.Windows.Forms.Button();
            this.presetOutputEdit = new System.Windows.Forms.TextBox();
            this.presetInputEdit = new System.Windows.Forms.TextBox();
            this.presetNameEdit = new System.Windows.Forms.TextBox();
            this.presetOutputLabel = new System.Windows.Forms.Label();
            this.presetInputLabel = new System.Windows.Forms.Label();
            this.presetNameLabel = new System.Windows.Forms.Label();
            this.createNewPreset = new System.Windows.Forms.Button();
            this.deletePresetGroup = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deletePresetEntry = new System.Windows.Forms.TextBox();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.presetInfo.SuspendLayout();
            this.deletePresetGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 728);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(119, 20);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Version text here";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(349, 697);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(154, 33);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // presetList
            // 
            this.presetList.FormattingEnabled = true;
            this.presetList.ItemHeight = 20;
            this.presetList.Location = new System.Drawing.Point(14, 56);
            this.presetList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetList.Name = "presetList";
            this.presetList.Size = new System.Drawing.Size(639, 304);
            this.presetList.TabIndex = 9;
            this.presetList.SelectedIndexChanged += new System.EventHandler(this.presetList_SelectedIndexChanged);
            // 
            // presetScreenLabel
            // 
            this.presetScreenLabel.Location = new System.Drawing.Point(286, 21);
            this.presetScreenLabel.Name = "presetScreenLabel";
            this.presetScreenLabel.Size = new System.Drawing.Size(114, 31);
            this.presetScreenLabel.TabIndex = 10;
            this.presetScreenLabel.Text = "Choose a Preset";
            this.presetScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // presetInfo
            // 
            this.presetInfo.Controls.Add(this.applyChangesButton);
            this.presetInfo.Controls.Add(this.presetOutputEdit);
            this.presetInfo.Controls.Add(this.presetInputEdit);
            this.presetInfo.Controls.Add(this.presetNameEdit);
            this.presetInfo.Controls.Add(this.presetOutputLabel);
            this.presetInfo.Controls.Add(this.presetInputLabel);
            this.presetInfo.Controls.Add(this.presetNameLabel);
            this.presetInfo.Location = new System.Drawing.Point(14, 369);
            this.presetInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetInfo.Name = "presetInfo";
            this.presetInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetInfo.Size = new System.Drawing.Size(640, 183);
            this.presetInfo.TabIndex = 11;
            this.presetInfo.TabStop = false;
            this.presetInfo.Text = "Preset Information";
            // 
            // applyChangesButton
            // 
            this.applyChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyChangesButton.Location = new System.Drawing.Point(479, 133);
            this.applyChangesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.applyChangesButton.Name = "applyChangesButton";
            this.applyChangesButton.Size = new System.Drawing.Size(154, 33);
            this.applyChangesButton.TabIndex = 12;
            this.applyChangesButton.Text = "Apply Changes";
            this.applyChangesButton.UseVisualStyleBackColor = true;
            this.applyChangesButton.Click += new System.EventHandler(this.applyChangesButton_Click);
            // 
            // presetOutputEdit
            // 
            this.presetOutputEdit.Location = new System.Drawing.Point(128, 95);
            this.presetOutputEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetOutputEdit.Name = "presetOutputEdit";
            this.presetOutputEdit.PlaceholderText = "C:\\Users";
            this.presetOutputEdit.Size = new System.Drawing.Size(505, 27);
            this.presetOutputEdit.TabIndex = 5;
            this.presetOutputEdit.TextChanged += new System.EventHandler(this.presetOutputEdit_TextChanged);
            // 
            // presetInputEdit
            // 
            this.presetInputEdit.Location = new System.Drawing.Point(128, 56);
            this.presetInputEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetInputEdit.Name = "presetInputEdit";
            this.presetInputEdit.PlaceholderText = "C:\\Users";
            this.presetInputEdit.Size = new System.Drawing.Size(505, 27);
            this.presetInputEdit.TabIndex = 4;
            this.presetInputEdit.TextChanged += new System.EventHandler(this.presetInputEdit_TextChanged);
            // 
            // presetNameEdit
            // 
            this.presetNameEdit.Location = new System.Drawing.Point(128, 21);
            this.presetNameEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetNameEdit.Name = "presetNameEdit";
            this.presetNameEdit.PlaceholderText = "Preset 1";
            this.presetNameEdit.Size = new System.Drawing.Size(505, 27);
            this.presetNameEdit.TabIndex = 3;
            this.presetNameEdit.TextChanged += new System.EventHandler(this.presetNameEdit_TextChanged);
            // 
            // presetOutputLabel
            // 
            this.presetOutputLabel.Location = new System.Drawing.Point(7, 99);
            this.presetOutputLabel.Name = "presetOutputLabel";
            this.presetOutputLabel.Size = new System.Drawing.Size(114, 31);
            this.presetOutputLabel.TabIndex = 2;
            this.presetOutputLabel.Text = "Preset output:";
            // 
            // presetInputLabel
            // 
            this.presetInputLabel.Location = new System.Drawing.Point(7, 64);
            this.presetInputLabel.Name = "presetInputLabel";
            this.presetInputLabel.Size = new System.Drawing.Size(114, 31);
            this.presetInputLabel.TabIndex = 1;
            this.presetInputLabel.Text = "Preset input:";
            // 
            // presetNameLabel
            // 
            this.presetNameLabel.Location = new System.Drawing.Point(7, 33);
            this.presetNameLabel.Name = "presetNameLabel";
            this.presetNameLabel.Size = new System.Drawing.Size(114, 31);
            this.presetNameLabel.TabIndex = 0;
            this.presetNameLabel.Text = "Preset name:";
            // 
            // createNewPreset
            // 
            this.createNewPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createNewPreset.Location = new System.Drawing.Point(510, 699);
            this.createNewPreset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createNewPreset.Name = "createNewPreset";
            this.createNewPreset.Size = new System.Drawing.Size(154, 33);
            this.createNewPreset.TabIndex = 13;
            this.createNewPreset.Text = "Create new Preset";
            this.createNewPreset.UseVisualStyleBackColor = true;
            this.createNewPreset.Click += new System.EventHandler(this.createNewPreset_Click);
            // 
            // deletePresetGroup
            // 
            this.deletePresetGroup.Controls.Add(this.deleteButton);
            this.deletePresetGroup.Controls.Add(this.deletePresetEntry);
            this.deletePresetGroup.Controls.Add(this.deleteLabel);
            this.deletePresetGroup.Location = new System.Drawing.Point(14, 560);
            this.deletePresetGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deletePresetGroup.Name = "deletePresetGroup";
            this.deletePresetGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deletePresetGroup.Size = new System.Drawing.Size(640, 115);
            this.deletePresetGroup.TabIndex = 14;
            this.deletePresetGroup.TabStop = false;
            this.deletePresetGroup.Text = "Delete Preset";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(479, 57);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(154, 33);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deletePresetEntry
            // 
            this.deletePresetEntry.Location = new System.Drawing.Point(11, 60);
            this.deletePresetEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deletePresetEntry.Name = "deletePresetEntry";
            this.deletePresetEntry.PlaceholderText = "Preset 1";
            this.deletePresetEntry.Size = new System.Drawing.Size(460, 27);
            this.deletePresetEntry.TabIndex = 1;
            this.deletePresetEntry.TextChanged += new System.EventHandler(this.deletePresetEntry_TextChanged);
            // 
            // deleteLabel
            // 
            this.deleteLabel.Location = new System.Drawing.Point(7, 25);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(626, 31);
            this.deleteLabel.TabIndex = 0;
            this.deleteLabel.Text = "Enter the name of the selected preset and press \'Delete\' to remove this preset";
            // 
            // managePresetsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 748);
            this.Controls.Add(this.deletePresetGroup);
            this.Controls.Add(this.createNewPreset);
            this.Controls.Add(this.presetInfo);
            this.Controls.Add(this.presetScreenLabel);
            this.Controls.Add(this.presetList);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.versionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "managePresetsScreen";
            this.Text = "Form6";
            this.presetInfo.ResumeLayout(false);
            this.presetInfo.PerformLayout();
            this.deletePresetGroup.ResumeLayout(false);
            this.deletePresetGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label versionLabel;
        private Button backButton;
        private ListBox presetList;
        private Label presetScreenLabel;
        private GroupBox presetInfo;
        private Label presetOutputLabel;
        private Label presetInputLabel;
        private Label presetNameLabel;
        private Button applyChangesButton;
        private TextBox presetOutputEdit;
        private TextBox presetInputEdit;
        private TextBox presetNameEdit;
        private Button createNewPreset;
        private GroupBox deletePresetGroup;
        private Button deleteButton;
        private TextBox deletePresetEntry;
        private Label deleteLabel;
    }
}