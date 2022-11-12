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
    public partial class managePathsScreen : Form
    {
        Form mainMenu;
        string[] loadedPaths;
        public managePathsScreen(Form menu)
        {
            InitializeComponent();
            mainMenu = menu;
            Shown += managePathsScreen_Shown;
            versionLabel.Text = Program.versionText;
        }

        private void managePathsScreen_Shown(Object sender, EventArgs e)
        {
            if (Program.debug) MessageBox.Show("Form 8 shown");
            ResetForm();
        }

        private void ResetForm()
        {
            pathList.ClearSelected();
            pathList.Items.Clear();
            loadedPaths = Program.LoadPaths();
            deletePathGroup.Enabled = false;
            deletePathEntry.Text = "";
            deletePathEntry.PlaceholderText = "";
            addPathEntry.Text = "";
            addPathButton.Enabled = false;
            
            foreach (string s in loadedPaths)
            {
                pathList.Items.Add(s);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void pathList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pathList.SelectedIndex > loadedPaths.Length - 1) ResetForm();
            if (pathList.SelectedIndex == -1) return;
            deletePathGroup.Enabled = true;
            deletePathButton.Enabled = false;
            deletePathEntry.Text = "";
            deletePathEntry.PlaceholderText = loadedPaths[pathList.SelectedIndex];
        }

        private void deletePathEntry_TextChanged(object sender, EventArgs e)
        {
            if (deletePathEntry.Text == "" || deletePathEntry.Text == null) return;
            if (deletePathEntry.Text == loadedPaths[pathList.SelectedIndex]) deletePathButton.Enabled = true;
            else deletePathButton.Enabled = false;
        }

        private void addPathEntry_TextChanged(object sender, EventArgs e)
        {
            if (addPathEntry.Text == "" || addPathEntry.Text == null) addPathButton.Enabled = false;
            else addPathButton.Enabled = true;
        }

        private void addPathButton_Click(object sender, EventArgs e)
        {
            if (!Program.CheckValidDirectory(addPathEntry.Text))
            {
                MessageBox.Show("Invalid directory...");
                return;
            }
            else
            {
                int currentNumber = loadedPaths.Length;
                List<string> temp = new List<string>();
                temp.Add(addPathEntry.Text);
                Program.SavePaths(temp, loadedPaths);
                loadedPaths = Program.LoadPaths();
                if (loadedPaths.Length > currentNumber)
                {
                    MessageBox.Show("Path saved successfully...");
                    ResetForm();
                }
                return;
            }
        }

        private void deletePathButton_Click(object sender, EventArgs e)
        {
            int currentNumber = loadedPaths.Length;
            Program.DeletePath(pathList.SelectedIndex, loadedPaths);
            loadedPaths = Program.LoadPaths();
            if (loadedPaths.Length < currentNumber)
            {
                MessageBox.Show("Path deleted successfully...");
                ResetForm();
            }
            return;
        }
    }
}
