namespace BackupToolWF
{
    partial class managePathsScreen
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
            this.managePathLabel = new System.Windows.Forms.Label();
            this.pathList = new System.Windows.Forms.ListBox();
            this.deletePathGroup = new System.Windows.Forms.GroupBox();
            this.deletePathButton = new System.Windows.Forms.Button();
            this.deletePathEntry = new System.Windows.Forms.TextBox();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.addPathGroup = new System.Windows.Forms.GroupBox();
            this.addPathButton = new System.Windows.Forms.Button();
            this.addPathEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.deletePathGroup.SuspendLayout();
            this.addPathGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // managePathLabel
            // 
            this.managePathLabel.Location = new System.Drawing.Point(250, 12);
            this.managePathLabel.Name = "managePathLabel";
            this.managePathLabel.Size = new System.Drawing.Size(100, 23);
            this.managePathLabel.TabIndex = 0;
            this.managePathLabel.Text = "Choose a Path";
            this.managePathLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pathList
            // 
            this.pathList.FormattingEnabled = true;
            this.pathList.ItemHeight = 15;
            this.pathList.Location = new System.Drawing.Point(12, 38);
            this.pathList.Name = "pathList";
            this.pathList.Size = new System.Drawing.Size(560, 289);
            this.pathList.TabIndex = 1;
            this.pathList.SelectedIndexChanged += new System.EventHandler(this.pathList_SelectedIndexChanged);
            // 
            // deletePathGroup
            // 
            this.deletePathGroup.Controls.Add(this.deletePathButton);
            this.deletePathGroup.Controls.Add(this.deletePathEntry);
            this.deletePathGroup.Controls.Add(this.deleteLabel);
            this.deletePathGroup.Location = new System.Drawing.Point(12, 333);
            this.deletePathGroup.Name = "deletePathGroup";
            this.deletePathGroup.Size = new System.Drawing.Size(560, 86);
            this.deletePathGroup.TabIndex = 15;
            this.deletePathGroup.TabStop = false;
            this.deletePathGroup.Text = "Delete Path";
            // 
            // deletePathButton
            // 
            this.deletePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deletePathButton.Location = new System.Drawing.Point(419, 43);
            this.deletePathButton.Name = "deletePathButton";
            this.deletePathButton.Size = new System.Drawing.Size(135, 25);
            this.deletePathButton.TabIndex = 14;
            this.deletePathButton.Text = "Delete";
            this.deletePathButton.UseVisualStyleBackColor = true;
            this.deletePathButton.Click += new System.EventHandler(this.deletePathButton_Click);
            // 
            // deletePathEntry
            // 
            this.deletePathEntry.Location = new System.Drawing.Point(10, 45);
            this.deletePathEntry.Name = "deletePathEntry";
            this.deletePathEntry.PlaceholderText = "Path 1";
            this.deletePathEntry.Size = new System.Drawing.Size(403, 23);
            this.deletePathEntry.TabIndex = 1;
            this.deletePathEntry.TextChanged += new System.EventHandler(this.deletePathEntry_TextChanged);
            // 
            // deleteLabel
            // 
            this.deleteLabel.Location = new System.Drawing.Point(6, 19);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(548, 23);
            this.deleteLabel.TabIndex = 0;
            this.deleteLabel.Text = "Enter the selected path and press \'Delete\' to remove this path";
            // 
            // addPathGroup
            // 
            this.addPathGroup.Controls.Add(this.addPathButton);
            this.addPathGroup.Controls.Add(this.addPathEntry);
            this.addPathGroup.Controls.Add(this.label1);
            this.addPathGroup.Location = new System.Drawing.Point(12, 425);
            this.addPathGroup.Name = "addPathGroup";
            this.addPathGroup.Size = new System.Drawing.Size(560, 86);
            this.addPathGroup.TabIndex = 16;
            this.addPathGroup.TabStop = false;
            this.addPathGroup.Text = "Add Path";
            // 
            // addPathButton
            // 
            this.addPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPathButton.Location = new System.Drawing.Point(419, 45);
            this.addPathButton.Name = "addPathButton";
            this.addPathButton.Size = new System.Drawing.Size(135, 25);
            this.addPathButton.TabIndex = 15;
            this.addPathButton.Text = "Add";
            this.addPathButton.UseVisualStyleBackColor = true;
            this.addPathButton.Click += new System.EventHandler(this.addPathButton_Click);
            // 
            // addPathEntry
            // 
            this.addPathEntry.Location = new System.Drawing.Point(10, 45);
            this.addPathEntry.Name = "addPathEntry";
            this.addPathEntry.PlaceholderText = "C:\\";
            this.addPathEntry.Size = new System.Drawing.Size(403, 23);
            this.addPathEntry.TabIndex = 1;
            this.addPathEntry.TextChanged += new System.EventHandler(this.addPathEntry_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the new path and press \'Add\'";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(305, 524);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(135, 25);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionLabel.Location = new System.Drawing.Point(0, 546);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(94, 15);
            this.versionLabel.TabIndex = 24;
            this.versionLabel.Text = "Version text here";
            // 
            // managePathsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.addPathGroup);
            this.Controls.Add(this.deletePathGroup);
            this.Controls.Add(this.pathList);
            this.Controls.Add(this.managePathLabel);
            this.Name = "managePathsScreen";
            this.Text = "Form8";
            this.deletePathGroup.ResumeLayout(false);
            this.deletePathGroup.PerformLayout();
            this.addPathGroup.ResumeLayout(false);
            this.addPathGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label managePathLabel;
        private ListBox pathList;
        private GroupBox deletePathGroup;
        private TextBox deletePathEntry;
        private Label deleteLabel;
        private Button deletePathButton;
        private GroupBox addPathGroup;
        private Button addPathButton;
        private TextBox addPathEntry;
        private Label label1;
        private Button backButton;
        private Label versionLabel;
    }
}