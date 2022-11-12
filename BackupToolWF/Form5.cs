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
    public partial class manageSavesForm : Form
    {
        Form mainMenu;
        public manageSavesForm(Form main)
        {
            InitializeComponent();
            versionLabel.Text = Program.versionText;
            mainMenu = main;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.ReturnToForm(this, mainMenu);
        }

        private void managePresets_Click(object sender, EventArgs e)
        {
            Form managePresets = new managePresetsScreen(this);
            Program.StartNewForm(this, managePresets);
        }

        private void managePaths_Click(object sender, EventArgs e)
        {
            Form managePathsForm = new managePathsScreen(this);
            Program.StartNewForm(this, managePathsForm);
        }
    }
}
