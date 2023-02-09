using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupToolWF
{
    public partial class duplicateDirectoryScreen : Form
    {
        bool inputFromSave, outputToSave, makePreset = false, validPresetNameEntered = false, saveInputPath = false, saveOutputPath = false, hasNewInput = false, hasNewOutput = false, inputSaveSelected = false, outputSaveSelected = false;
        Form mainMenu;
        string[] loadedPaths;
        string[,] loadedPresets;
        public duplicateDirectoryScreen(Form main)//constructer
        {
            InitializeComponent(); 
            //grab parent form and relevant values
            mainMenu = main;
            versionLabel.Text = Program.versionText;

            ResetForm();
        }

        private void ResetForm()
        {
            loadedPaths = Program.LoadPaths(); //load saved paths
            loadedPresets = Program.LoadPresets(); //loads current preset names


            if (loadedPaths.Length == 0) //if no loaded paths exist
            {
                //set accessibility for input directory options
                loadNewPathOption.Checked = true;
                browseInput.Enabled = true;
                loadSavedPathOption.Checked = false;
                loadSavedPathOption.Enabled = false;
                loadSavedPathList.Enabled = false;
                inputFromSave = false;

                //set accessibility for output directory options
                duplicateToNewPathOption.Checked = true;
                browseOutput.Enabled = true;
                duplicateToSavedPathOption.Checked = false;
                duplicateToSavedPathOption.Enabled = false;
                duplicateToSavedPathList.Enabled = false;
                outputToSave = false;
            }
            else //if loaded paths do exist
            {
                //set accessibility for input directory options
                loadSavedPathOption.Checked = true;
                loadSavedPathList.Enabled = true;
                loadNewPathOption.Checked = false;
                browseInput.Enabled = false;
                inputFromSave = true;

                //set accessibility for output directory options
                duplicateToSavedPathOption.Checked = true;
                duplicateToSavedPathList.Enabled = true;
                duplicateToNewPathOption.Checked = false;
                browseOutput.Enabled = false;
                outputToSave = true;

                for (int a = 0; a < loadedPaths.Length; a++)
                {
                    duplicateToSavedPathList.Items.Add(loadedPaths[a]);
                    loadSavedPathList.Items.Add(loadedPaths[a]);
                }
            }

            //set enabled state of buttons on startup
            newSaveInputLabel.Text = newSaveOutputLabel.Text = "";
            saveNewLoadPathOption.Enabled = false;
            saveNewSavePathOption.Enabled = false;
            makePresetNameEntry.Enabled = false;
            duplicateButton.Enabled = false;
            duplicatePresetNameText.Visible = false;
        }

        private void duplicateToNewPathEntry_TextChanged(object sender, EventArgs e) //when new input path string is edited
        {
            /*
            if (duplicateToNewPathEntry.Text != null && duplicateToNewPathEntry.Text != "") //check for empty string
            {
                hasNewOutput = true;
                saveNewSavePathOption.Enabled = true;
            }
            else //if not empty string set enabled state of relevant buttons
            {
                hasNewOutput = false;
                saveNewSavePathOption.Checked = false;
                saveNewSavePathOption.Enabled = false;
            }
            newSaveOutputLabel.Text = duplicateToNewPathEntry.Text;
            duplicateButton.Enabled = CheckForValidDupe(); //check if the duplicate button is now enabled
            */
        }

        private void duplicateToSavedPathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (duplicateToSavedPathOption.Checked) //if this is now checked
            {
                duplicateToSavedPathList.Enabled = true; //enable related option and uncheck the other option
                duplicateToNewPathOption.Checked = false;
                outputToSave = true;
                saveNewSavePathOption.Checked = false;
                saveNewSavePathOption.Enabled = false;
            }
            else
            {
                duplicateToSavedPathList.Enabled = false; //if no longer checked disable related option
                outputToSave = false;
            }
            duplicateButton.Enabled = CheckForValidDupe(); //check for duplicate button enabled
        }

        private void loadSavedPathList_SelectedIndexChanged(object sender, EventArgs e) //when new input path is selected from list
        {
            if (loadSavedPathList.SelectedIndex > loadedPaths.Length - 1) //if out of bounds 
            {
                loadSavedPathList.SelectedIndex = 0; //set to first index
            }
            inputSaveSelected = true;
            duplicateButton.Enabled = CheckForValidDupe(); //check for duplicate button enabled
        }

        private void duplicateToSavedPathList_SelectedIndexChanged(object sender, EventArgs e) //when new output path is selected from list
        {
            if (duplicateToSavedPathList.SelectedIndex > loadedPaths.Length - 1) //if out of bounds
            {
                duplicateToSavedPathList.SelectedIndex = 0; //set to first index
            }
            outputSaveSelected = true;
            duplicateButton.Enabled = CheckForValidDupe(); //check for duplicate button enabled
        }

        private void makePresetNameEntry_TextChanged(object sender, EventArgs e) //if preset name is changed
        {
            validPresetNameEntered = ValidPresetName(); //check for valid name
            duplicateButton.Enabled = CheckForValidDupe(); //check for duplicate button enabled
        }

        private void duplicateButton_Click(object sender, EventArgs e) //when duplicate button is clicked
        {
            //grab input path
            string inputPath;
            if (inputFromSave) inputPath = loadedPaths[loadSavedPathList.SelectedIndex];
            else inputPath = loadNewPathEntry.Text;

            //check for valid input path
            if (!Program.CheckValidDirectory(inputPath))
            {
                MessageBox.Show("Invalid input directory...");
                return;
            }

            //grab output path
            string outputPath;
            if (outputToSave) outputPath = loadedPaths[duplicateToSavedPathList.SelectedIndex];
            else outputPath = duplicateToNewPathEntry.Text;

            //check for valid output path
            if (!Program.CheckValidDirectory(outputPath))
            {
                MessageBox.Show("Invalid output directory...");
                return;
            }

            //check for saving new paths
            List<string> newPaths = new List<string>();
            if (saveInputPath) newPaths.Add(inputPath);
            if (saveOutputPath) newPaths.Add(outputPath);
            if (newPaths.Count != 0) Program.SavePaths(newPaths, loadedPaths);

            //get time and date for folder name
            string dateTime = DateTime.Now.ToString("MM.dd.yy-HH.mm.ss");
            string finalOutput = outputPath + '\\' + dateTime;

            //test for existing input directory, and if it exists create new output directory (if necessary)
            try
            {
                if (!Directory.Exists(inputPath))
                {
                    MessageBox.Show("Input directory does not exist...");
                    return;
                }
                if (!Directory.Exists(finalOutput)) Directory.CreateDirectory(finalOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //if making a preset, make the preset
            if (makePreset) Program.MakePreset(makePresetNameEntry.Text, inputPath, outputPath, loadedPresets);

            //run the duplication method
            Program.DuplicateFiles(inputPath, finalOutput);

            //return to the parent form upon completion
            Program.ReturnToForm(this, mainMenu);
        }

        private void saveNewSavePathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (saveNewSavePathOption.Checked) saveOutputPath = true;
            else saveOutputPath = false;
            duplicateButton.Enabled = CheckForValidDupe();
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

            loadNewPathEntry.Text = newSaveInputLabel.Text = tempDir;

            if (tempDir != null && tempDir != "") saveNewLoadPathOption.Enabled = true;
            else saveNewLoadPathOption.Enabled = false;

            duplicateButton.Enabled = CheckForValidDupe();
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

            //Check for progrem access to directory
            //if program has access, set the new directory to the value of the textbox
            if (Program.AccessibleDirectory(tempDir)) duplicateToNewPathEntry.Text = newSaveOutputLabel.Text = tempDir;
            //message appears during call to Preferences.AccessibleDirectory if the directory is inaccessible

            if (tempDir != null && tempDir != "") saveNewSavePathOption.Enabled = true;
            else saveNewSavePathOption.Enabled = false;

            duplicateButton.Enabled = CheckForValidDupe();
        }

        private void duplicateToNewPathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (duplicateToNewPathOption.Checked) //if this is now checked
            {
                browseOutput.Enabled = true; //enable related option and uncheck the other option
                duplicateToSavedPathOption.Checked = false;
                outputToSave = false;
            }
            else
            {
                browseOutput.Enabled = false; //if no longer checked disable related option
                outputToSave = true;
            }

            duplicateButton.Enabled = CheckForValidDupe();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void loadNewPathEntry_TextChanged(object sender, EventArgs e)
        {
            /*
            if (loadNewPathEntry.Text != null && loadNewPathEntry.Text != "")
            {
                hasNewInput = true;
                saveNewLoadPathOption.Enabled = true;
            }
            else
            {
                hasNewInput = false;
                saveNewLoadPathOption.Checked = false;
                saveNewLoadPathOption.Enabled = false;
            }
            newSaveInputLabel.Text = loadNewPathEntry.Text;
            duplicateButton.Enabled = CheckForValidDupe();
            */
        }

        private void loadSavedPathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (loadSavedPathOption.Checked) //if this is now checked
            {
                loadSavedPathList.Enabled = true; //enable related option and uncheck the other option
                loadNewPathOption.Checked = false;
                inputFromSave = true;
                saveNewLoadPathOption.Checked = false;
                saveNewLoadPathOption.Enabled = false;
            }
            else
            {
                loadSavedPathList.Enabled = false; //if no longer checked disable related option
                inputFromSave = false;
            }
            duplicateButton.Enabled = CheckForValidDupe();
        }

        private void saveNewLoadPathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (saveNewLoadPathOption.Checked) saveInputPath = true;
            else saveInputPath = false;
            duplicateButton.Enabled = CheckForValidDupe();
        }

        private void makePresetOption_CheckedChanged(object sender, EventArgs e)
        {
            if (makePresetOption.Checked) //if this is now checked
            {
                makePreset = true; //mark as creating preset and enable related option
                makePresetNameEntry.Enabled = true;
            }
            else
            {
                makePreset = false; //else mark as not creating preset and disable related option
                makePresetNameEntry.Enabled = false;
            }
            duplicateButton.Enabled = CheckForValidDupe();
        }

        private void loadNewPathOption_CheckedChanged(object sender, EventArgs e)
        {
            if (loadNewPathOption.Checked) //if this is now checked
            {
                browseInput.Enabled = true; //enable related option and uncheck the other option
                loadSavedPathOption.Checked = false;
                inputFromSave = false;
            }
            else
            {
                browseInput.Enabled = false; //if no longer checked disable related option
                inputFromSave = true;
            }

            duplicateButton.Enabled = CheckForValidDupe();
        }

        private bool CheckForValidDupe() //check for a valid combination of needed inputs
        {
            if ((inputFromSave && inputSaveSelected) || hasNewInput)
            {
                if ((outputToSave && outputSaveSelected) || hasNewOutput)
                {
                    if (makePreset && !validPresetNameEntered) return false;
                    else return true;
                }
            }

            return false;
        }

        private bool ValidPresetName() //check for empty preset name, special characters, or duplicate name
        {
            duplicatePresetNameText.Visible = true;
            string newName = makePresetNameEntry.Text;
            if (newName == null || newName == "") return false;

            foreach (char c in newName)
            {
                if (!char.IsLetterOrDigit(c)) return false;
            }

            bool showWarning = false;
            for (int a = 0; a < loadedPresets.GetLength(0); a++)
            {
                if (newName == loadedPresets[a, 0])
                {
                    showWarning = true;
                    break;
                }
            }
            if (showWarning)
            {
                duplicatePresetNameText.Visible = true;
                return false;
            }
            else duplicatePresetNameText.Visible = false;

            return true;
        }
    }
}
