namespace BackupToolWF
{
    partial class makePresetScreen
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
            this.createNewPresetButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.presetNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.presetNameEntryBox = new System.Windows.Forms.TextBox();
            this.presetInputEntryBox = new System.Windows.Forms.TextBox();
            this.presetOutputEntryBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createNewPresetButton
            // 
            this.createNewPresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createNewPresetButton.Location = new System.Drawing.Point(446, 524);
            this.createNewPresetButton.Name = "createNewPresetButton";
            this.createNewPresetButton.Size = new System.Drawing.Size(135, 25);
            this.createNewPresetButton.TabIndex = 15;
            this.createNewPresetButton.Text = "Create This Preset";
            this.createNewPresetButton.UseVisualStyleBackColor = true;
            this.createNewPresetButton.Click += new System.EventHandler(this.createNewPreset_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(305, 523);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(135, 25);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(250, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Create a Preset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // presetNameLabel
            // 
            this.presetNameLabel.Location = new System.Drawing.Point(12, 100);
            this.presetNameLabel.Name = "presetNameLabel";
            this.presetNameLabel.Size = new System.Drawing.Size(100, 23);
            this.presetNameLabel.TabIndex = 17;
            this.presetNameLabel.Text = "Preset name:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Preset input:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Preset output:";
            // 
            // presetNameEntryBox
            // 
            this.presetNameEntryBox.Location = new System.Drawing.Point(118, 97);
            this.presetNameEntryBox.Name = "presetNameEntryBox";
            this.presetNameEntryBox.PlaceholderText = "Enter the preset name (numbers and letters only, no spaces)";
            this.presetNameEntryBox.Size = new System.Drawing.Size(454, 23);
            this.presetNameEntryBox.TabIndex = 20;
            this.presetNameEntryBox.TextChanged += new System.EventHandler(this.presetNameEntry_TextChanged_1);
            // 
            // presetInputEntryBox
            // 
            this.presetInputEntryBox.Location = new System.Drawing.Point(118, 147);
            this.presetInputEntryBox.Name = "presetInputEntryBox";
            this.presetInputEntryBox.PlaceholderText = "C:\\";
            this.presetInputEntryBox.Size = new System.Drawing.Size(454, 23);
            this.presetInputEntryBox.TabIndex = 21;
            this.presetInputEntryBox.TextChanged += new System.EventHandler(this.presetInputEntry_TextChanged_1);
            // 
            // presetOutputEntryBox
            // 
            this.presetOutputEntryBox.Location = new System.Drawing.Point(118, 197);
            this.presetOutputEntryBox.Name = "presetOutputEntryBox";
            this.presetOutputEntryBox.PlaceholderText = "C:\\";
            this.presetOutputEntryBox.Size = new System.Drawing.Size(454, 23);
            this.presetOutputEntryBox.TabIndex = 22;
            this.presetOutputEntryBox.TextChanged += new System.EventHandler(this.presetOutputEntry_TextChanged_1);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 546);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(94, 15);
            this.versionLabel.TabIndex = 23;
            this.versionLabel.Text = "Version text here";
            // 
            // makePresetScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.presetOutputEntryBox);
            this.Controls.Add(this.presetInputEntryBox);
            this.Controls.Add(this.presetNameEntryBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.presetNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createNewPresetButton);
            this.Controls.Add(this.backButton);
            this.Name = "makePresetScreen";
            this.Text = "Form7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button createNewPresetButton;
        private Button backButton;
        private Label label1;
        private Label presetNameLabel;
        private Label label2;
        private Label label3;
        private TextBox presetNameEntryBox;
        private TextBox presetInputEntryBox;
        private TextBox presetOutputEntryBox;
        private Label versionLabel;
    }
}