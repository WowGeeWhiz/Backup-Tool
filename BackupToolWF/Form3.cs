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
    public partial class presetMenu : Form
    {
        Form mainMenu;
        string[,] loadedPresets;
        public presetMenu(Form main)
        {
            InitializeComponent();
            mainMenu = main;
            versionLabel.Text = Program.versionText;
            loadedPresets = Program.LoadPresets();
            if (loadedPresets.GetLength(0) == 0) presetList.Enabled = false;
            duplicateButton.Enabled = false;
            presetNameDisplay.Text = "";
            presetInputDisplay.Text = "";
            presetOutputDisplay.Text = "";

            for (int a = 0; a < loadedPresets.GetLength(0); a++)
            {
                presetList.Items.Add(loadedPresets[a, 0]);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void duplicateButton_Click(object sender, EventArgs e)
        {
            string input = loadedPresets[presetList.SelectedIndex, 1];
            string output = loadedPresets[presetList.SelectedIndex, 2];

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
            string dateTime = DateTime.Now.ToString("MM.dd.yy-hh.mm.ss");
            string finalOutput = output += '\\' + dateTime;
            try
            {
                if (!Directory.Exists(input))
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

            Program.DuplicateFiles(input, finalOutput);

            Program.ReturnToForm(this, mainMenu);
        }

        private void presetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.debug) MessageBox.Show("selected index: " + presetList.SelectedIndex);
            if (presetList.SelectedIndex == -1) return;
            if (presetList.SelectedIndex > loadedPresets.GetLength(0) - 1)
            {
                duplicateButton.Enabled = false;
                presetNameDisplay.Text = presetInputDisplay.Text = presetOutputDisplay.Text = "";
                return;
            }
            duplicateButton.Enabled = true;
            int index = presetList.SelectedIndex;
            presetNameDisplay.Text = loadedPresets[index, 0];
            presetInputDisplay.Text = loadedPresets[index, 1];
            presetOutputDisplay.Text = loadedPresets[index, 2];
        }
    }
}
