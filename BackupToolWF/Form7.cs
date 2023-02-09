using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupToolWF
{
    public partial class makePresetScreen : Form
    {
        string[,] loadedPresets;
        Form mainMenu;
        bool nameEntered = false, inputEntered = false, outputEntered = false;
        string name, input, output;
        public makePresetScreen(Form main)
        {
            InitializeComponent();
            mainMenu = main;
            createNewPresetButton.Enabled = false;
            versionLabel.Text = Program.versionText;
            loadedPresets = Program.LoadPresets();
        }

        private void presetNameEntry_TextChanged_1(object sender, EventArgs e)
        {
            if (presetNameEntryBox.Text == "" || presetNameEntryBox.Text == null)
            {
                nameEntered = false;
            }
            else nameEntered = true;

            createNewPresetButton.Enabled = CheckForButtonEnabled();
        }

        private void presetInputEntry_TextChanged_1(object sender, EventArgs e)
        {
            if (presetInputEntryBox.Text == "" || presetInputEntryBox.Text == null)
            {
                inputEntered = false;
            }
            else inputEntered = true;

            createNewPresetButton.Enabled = CheckForButtonEnabled();
        }

        private void presetOutputEntry_TextChanged_1(object sender, EventArgs e)
        {
            if (presetOutputEntryBox.Text == "" || presetOutputEntryBox.Text == null)
            {
                outputEntered = false;
            }
            else outputEntered = true;

            createNewPresetButton.Enabled = CheckForButtonEnabled();
        }

        private void browseInput_Click(object sender, EventArgs e)
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

            presetInputEntryBox.Text = tempDir;

            if (tempDir != null && tempDir != "") inputEntered = true;
            else inputEntered = false;

            createNewPresetButton.Enabled = CheckForButtonEnabled();
        }

        private void browseOutput_Click(object sender, EventArgs e)
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

            presetOutputEntryBox.Text = tempDir;

            if (tempDir != null && tempDir != "") outputEntered = true;
            else inputEntered = false;

            createNewPresetButton.Enabled = CheckForButtonEnabled();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void createNewPreset_Click(object sender, EventArgs e)
        {
            int currentNum;
            if (loadedPresets == null) currentNum = 0;
            else currentNum = loadedPresets.GetLength(0);
            string name = presetNameEntryBox.Text;
            string input = presetInputEntryBox.Text;
            string output = presetOutputEntryBox.Text;
            for (int a = 0; a < loadedPresets.GetLength(0); a++)
            {
                if (loadedPresets[a, 0] == name)
                {
                    MessageBox.Show("There is already a preset with this name...");

                    return;
                }
            }

            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    MessageBox.Show("Preset names can only be composed of numbers and letters (no spaces)");
                    return;
                }
            }

            if (!Program.CheckValidDirectory(input))
            {
                MessageBox.Show("Invalid input directory...");
                return;
            }

            if (!Program.CheckValidDirectory(output))
            {
                MessageBox.Show("Invalid output directory...");
                return;
            }

            Program.MakePreset(name, input, output, loadedPresets);
            loadedPresets = Program.LoadPresets();
            if (loadedPresets.GetLength(0) > currentNum)
            {
                MessageBox.Show("Preset created successfully...");
                ResetForm();
            }
            return;
        }

        private bool CheckForButtonEnabled()
        {
            if (nameEntered && inputEntered && outputEntered)
            {
                if (Program.debug) MessageBox.Show("returning true in checkforbuttonenabled()");
                return true;
            }
            else
            {
                if (Program.debug) MessageBox.Show("returning true in checkforbuttonenabled()");
                return false;
            }
        }

        private void ResetForm()
        {
            name = input = output = null;
            nameEntered = inputEntered = outputEntered = false;
            presetNameEntryBox.Text = "";
            presetInputEntryBox.Text = "";
            presetOutputEntryBox.Text = "";
            createNewPresetButton.Enabled = false;
        }
    }
}
