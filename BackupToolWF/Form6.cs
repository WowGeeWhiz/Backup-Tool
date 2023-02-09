using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BackupToolWF
{
    public partial class managePresetsScreen : Form
    {
        Form mainMenu;
        string[,] loadedPresets;
        string[] temp;
        bool differentName, differentInput, differentOutput;
        public managePresetsScreen(Form menu)
        {
            InitializeComponent();
            //Shown += managePresetsScreen_Shown;
            VisibleChanged += managePresetsScreen_VisibleChanged;
            versionLabel.Text = Program.versionText;
            mainMenu = menu;
        }
        private void managePresetsScreen_Shown(Object sender, EventArgs e)
        {
            if (Program.debug) MessageBox.Show("Form 6 shown");
            RestartForm();
        }
        
        /*
        protected override void OnActivated(EventArgs e)
        {
            if (Program.debug) MessageBox.Show("Form 6 shown");
            RestartForm();
        }
        */

        private void managePresetsScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (Program.debug) MessageBox.Show("Form 6 shown");
                RestartForm();
            }
            else
            {
                if (Program.debug) MessageBox.Show("Form 6 hidden");
            }


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void deletePresetEntry_TextChanged(object sender, EventArgs e)
        {
            if (deletePresetEntry.Text == null || deletePresetEntry.Text == "") return;
            if (deletePresetEntry.Text == "Delete") deleteButton.Enabled = true;
            else deleteButton.Enabled = false;
        }

        private void presetNameEdit_TextChanged(object sender, EventArgs e)
        {
            if (presetNameEdit.Text == null || presetNameEdit.Text == "" || presetNameEdit.Text == temp[0]) differentName = false;
            else differentName = true;

            applyChangesButton.Enabled = CheckApplyButtonEnabled();
        }

        private void presetInputEdit_TextChanged(object sender, EventArgs e)
        {
            if (!Program.CheckValidDirectory(presetInputEdit.Text) || presetInputEdit.Text == null|| presetInputEdit.Text == temp[1])
            {
                presetInputEdit.Text = "";
            }
            if (presetInputEdit.Text == "") differentInput = false;
            else differentInput = true;

            applyChangesButton.Enabled = CheckApplyButtonEnabled();
        }

        private void presetOutputEdit_TextChanged(object sender, EventArgs e)
        {
            if (!Program.CheckValidDirectory(presetOutputEdit.Text) || presetOutputEdit.Text == null || presetOutputEdit.Text == temp[2])
            {
                presetOutputEdit.Text = "";
            }
            if (presetOutputEdit.Text == "") differentOutput = false;
            else differentOutput = true;

            applyChangesButton.Enabled = CheckApplyButtonEnabled();
        }

        private void presetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;

            if (presetList.SelectedIndex > loadedPresets.GetLength(0) - 1) RestartForm();
            differentName = differentInput = differentOutput = false;
            int index = presetList.SelectedIndex;
            if (index == -1) return;
            if (Program.debug) MessageBox.Show("loadedPresets.GetLength(0) is " + loadedPresets.GetLength(0));
            temp = new string[] { loadedPresets[index, 0], loadedPresets[index, 1], loadedPresets[index, 2] };
            deletePresetGroup.Enabled = true;
            presetInfo.Enabled = true;

            presetNameEdit.Text = temp[0];
            presetNameEdit.PlaceholderText = temp[0];
            presetInputEdit.Text = temp[1];
            presetInputEdit.PlaceholderText = temp[1];
            presetOutputEdit.Text = temp[2];
            presetOutputEdit.PlaceholderText = temp[2];
            deletePresetEntry.Text = "";
            //deletePresetEntry.PlaceholderText = temp[0];
            applyChangesButton.Enabled = false;
        }

        private void applyChangesButton_Click(object sender, EventArgs e)
        {
            string newName, newInput, newOutput;
            if (differentName)
            {
                newName = presetNameEdit.Text;
                for (int a = 0; a < loadedPresets.GetLength(0); a++)
                {
                    if (loadedPresets[a, 0] == newName)
                    {
                        MessageBox.Show("There is already a preset with this name...");
                        return;
                    }
                }

                foreach (char c in newName)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        MessageBox.Show("Preset names can only be composed of numbers and letters (no spaces)");
                        return;
                    }
                }
            }
            else newName = temp[0];

            if (differentInput)
            {
                newInput = presetInputEdit.Text;
                if (!Program.CheckValidDirectory(newInput))
                {
                    MessageBox.Show("Invalid input directory...");
                    return;
                }
            }
            else newInput = temp[1];

            if (differentOutput)
            {
                newOutput = presetOutputEdit.Text;
                if (!Program.CheckValidDirectory(newOutput))
                {
                    MessageBox.Show("Invalid output directory...");
                    return;
                }
            }
            else newOutput = temp[2];

            if (Program.UpdatePreset(presetList.SelectedIndex, newName, newInput, newOutput, loadedPresets))
                MessageBox.Show("Preset updated successfully...");
            RestartForm();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int currentNumber = loadedPresets.GetLength(0);
            Program.DeletePreset(presetList.SelectedIndex, loadedPresets);
            loadedPresets = Program.LoadPresets();
            if (loadedPresets.GetLength(0) < currentNumber)
            {
                MessageBox.Show("Preset deleted successfully...");
                RestartForm();
            }
            return;
        }

        private void createNewPreset_Click(object sender, EventArgs e)
        {
            Form makePreset = new makePresetScreen(this);
            Program.StartNewForm(this, makePreset);
        }

        private void browseInputButton_Click(object sender, EventArgs e)
        {
            //temp string for reference
            string tempDir = "";

            //create a new folder browser window
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Select input folder";
            browser.UseDescriptionForTitle = true;

            //if valid result from the dialogue
            if (browser.ShowDialog() == DialogResult.OK)
            {
                //set the chosen directory to the temp value
                tempDir = browser.SelectedPath;
                if (Program.debug) MessageBox.Show("File dialogue returned " + tempDir);
            }

            presetInputEdit.Text = tempDir;
        }

        private void browseOutputButton_Click(object sender, EventArgs e)
        {

            //temp string for reference
            string tempDir = "";

            //create a new folder browser window
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Select output folder";
            browser.UseDescriptionForTitle = true;

            //if valid result from the dialogue
            if (browser.ShowDialog() == DialogResult.OK)
            {
                //set the chosen directory to the temp value
                tempDir = browser.SelectedPath;
                if (Program.debug) MessageBox.Show("File dialogue returned " + tempDir);
            }

            presetOutputEdit.Text = tempDir;
        }

        private bool CheckApplyButtonEnabled()
        {
            if (differentName || differentInput || differentOutput) return true;
            else return false;
        }

        private void RestartForm()
        {
            if (Program.debug) MessageBox.Show("Attempting to load presets again...");
            loadedPresets = Program.LoadPresets();
            if (Program.debug)
            {
                string displayText = "";
                for (int a = 0; a < loadedPresets.GetLength(0); a++) displayText += loadedPresets[a,0].ToString() + "\n";
                MessageBox.Show("LoadPresets() called, result is \n" + displayText);
            }
            presetList.ClearSelected();
            presetList.Items.Clear();
            if (loadedPresets.GetLength(0) == 0) presetList.Enabled = false;

            for (int a = 0; a < loadedPresets.GetLength(0); a++)
            {
                presetList.Items.Add(loadedPresets[a, 0]);
            }

            deletePresetGroup.Enabled = false;
            presetInfo.Enabled = false;

            presetNameEdit.Text = "";
            presetNameEdit.PlaceholderText = "";
            presetInputEdit.Text = "";
            presetInputEdit.PlaceholderText = "";
            presetOutputEdit.Text = "";
            presetOutputEdit.PlaceholderText = "";
            deletePresetEntry.Text = "";
            deletePresetEntry.PlaceholderText = "";
            deleteButton.Enabled = false;
        }
    }
}
