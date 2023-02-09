namespace BackupToolWF
{
    partial class presetMenu
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
            this.backButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.duplicatingPresetLabel = new System.Windows.Forms.Label();
            this.presetList = new System.Windows.Forms.ListBox();
            this.duplicateButton = new System.Windows.Forms.Button();
            this.presetNameLabel = new System.Windows.Forms.Label();
            this.presetInputLabel = new System.Windows.Forms.Label();
            this.presetOutputLabel = new System.Windows.Forms.Label();
            this.presetNameDisplay = new System.Windows.Forms.Label();
            this.presetInputDisplay = new System.Windows.Forms.Label();
            this.presetOutputDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(349, 697);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(154, 33);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 728);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(119, 20);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version text here";
            // 
            // duplicatingPresetLabel
            // 
            this.duplicatingPresetLabel.AutoSize = true;
            this.duplicatingPresetLabel.Location = new System.Drawing.Point(296, 12);
            this.duplicatingPresetLabel.Name = "duplicatingPresetLabel";
            this.duplicatingPresetLabel.Size = new System.Drawing.Size(105, 20);
            this.duplicatingPresetLabel.TabIndex = 5;
            this.duplicatingPresetLabel.Text = "Select a Preset";
            // 
            // presetList
            // 
            this.presetList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.presetList.FormattingEnabled = true;
            this.presetList.ItemHeight = 20;
            this.presetList.Location = new System.Drawing.Point(14, 36);
            this.presetList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.presetList.Name = "presetList";
            this.presetList.Size = new System.Drawing.Size(639, 484);
            this.presetList.TabIndex = 6;
            this.presetList.SelectedIndexChanged += new System.EventHandler(this.presetList_SelectedIndexChanged);
            // 
            // duplicateButton
            // 
            this.duplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateButton.Location = new System.Drawing.Point(510, 697);
            this.duplicateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(154, 33);
            this.duplicateButton.TabIndex = 11;
            this.duplicateButton.Text = "Run Preset";
            this.duplicateButton.UseVisualStyleBackColor = true;
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // presetNameLabel
            // 
            this.presetNameLabel.Location = new System.Drawing.Point(14, 563);
            this.presetNameLabel.Name = "presetNameLabel";
            this.presetNameLabel.Size = new System.Drawing.Size(114, 31);
            this.presetNameLabel.TabIndex = 12;
            this.presetNameLabel.Text = "Preset name:";
            // 
            // presetInputLabel
            // 
            this.presetInputLabel.Location = new System.Drawing.Point(15, 595);
            this.presetInputLabel.Name = "presetInputLabel";
            this.presetInputLabel.Size = new System.Drawing.Size(114, 31);
            this.presetInputLabel.TabIndex = 13;
            this.presetInputLabel.Text = "Preset input:";
            // 
            // presetOutputLabel
            // 
            this.presetOutputLabel.Location = new System.Drawing.Point(15, 627);
            this.presetOutputLabel.Name = "presetOutputLabel";
            this.presetOutputLabel.Size = new System.Drawing.Size(114, 31);
            this.presetOutputLabel.TabIndex = 14;
            this.presetOutputLabel.Text = "Preset output:";
            // 
            // presetNameDisplay
            // 
            this.presetNameDisplay.Location = new System.Drawing.Point(136, 563);
            this.presetNameDisplay.Name = "presetNameDisplay";
            this.presetNameDisplay.Size = new System.Drawing.Size(518, 31);
            this.presetNameDisplay.TabIndex = 15;
            this.presetNameDisplay.Text = "preset name goes here";
            // 
            // presetInputDisplay
            // 
            this.presetInputDisplay.Location = new System.Drawing.Point(136, 593);
            this.presetInputDisplay.Name = "presetInputDisplay";
            this.presetInputDisplay.Size = new System.Drawing.Size(519, 31);
            this.presetInputDisplay.TabIndex = 16;
            this.presetInputDisplay.Text = "preset input goes here";
            // 
            // presetOutputDisplay
            // 
            this.presetOutputDisplay.Location = new System.Drawing.Point(136, 624);
            this.presetOutputDisplay.Name = "presetOutputDisplay";
            this.presetOutputDisplay.Size = new System.Drawing.Size(518, 31);
            this.presetOutputDisplay.TabIndex = 17;
            this.presetOutputDisplay.Text = "preset output goes here";
            // 
            // presetMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 748);
            this.Controls.Add(this.presetOutputDisplay);
            this.Controls.Add(this.presetInputDisplay);
            this.Controls.Add(this.presetNameDisplay);
            this.Controls.Add(this.presetOutputLabel);
            this.Controls.Add(this.presetInputLabel);
            this.Controls.Add(this.presetNameLabel);
            this.Controls.Add(this.duplicateButton);
            this.Controls.Add(this.presetList);
            this.Controls.Add(this.duplicatingPresetLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.backButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "presetMenu";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button backButton;
        private Label versionLabel;
        private Label duplicatingPresetLabel;
        private ListBox presetList;
        private Button duplicateButton;
        private Label presetNameLabel;
        private Label presetInputLabel;
        private Label presetOutputLabel;
        private Label presetNameDisplay;
        private Label presetInputDisplay;
        private Label presetOutputDisplay;
    }
}