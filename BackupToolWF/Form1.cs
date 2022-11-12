

namespace BackupToolWF
{
    public partial class mainMenu : Form
    {
        public mainMenu() //default constructor
        {
            InitializeComponent();
            versionLabel.Text = Program.versionText; //grab version text
            ControlBox = false; //remove controlbox to prevent closing on a different form and leaving hidden forms running
        }

        private void contactButton_Click(object sender, EventArgs e) //button to "Contact the Developer"
        {
            string url = "https://www.twitter.com/WowGeeWhiz"; //my twitter profile page
            var processStartInfo = new System.Diagnostics.ProcessStartInfo();
            processStartInfo.UseShellExecute = true; 
            processStartInfo.FileName = url;
            System.Diagnostics.Process.Start(processStartInfo); //launch default browser to the given url
        }

        private void exitButton_Click(object sender, EventArgs e) //close button
        {
            Application.Exit();
        }

        private void duplicateDirectoryButton_Click(object sender, EventArgs e) //open new form for running a single duplication
        {
            Form duplicateScreen = new duplicateDirectoryScreen(this);
            Program.StartNewForm(this, duplicateScreen);
        }

        private void presetDuplicateButton_Click(object sender, EventArgs e) //open new form for running a preset
        {
            Form presetScreen = new presetMenu(this);
            Program.StartNewForm(this, presetScreen);
        }

        private void manageSavedInfoButton_Click(object sender, EventArgs e) //open new form for managing presets or paths
        {
            Form manageSavesScreen = new manageSavesForm(this);
            Program.StartNewForm(this, manageSavesScreen);
        }

        private void enableDebug_Click(object sender, EventArgs e) //enable debug (this will cause lots of popups, clicking this button is not recommended unless you want to close a ton of popups sometimes
        {
            if (Program.debug) //if debug enabled, disable
            {
                Program.debug = false;
                enableDebug.Text = "Enable Debug";
                Program.versionText = Program.defaultVersionText;
                versionLabel.Text = Program.versionText;
            }
            else //if debug disabled, enable
            {
                Program.debug = true;
                enableDebug.Text = "Disable Debug";
                Program.versionText = Program.defaultVersionText + Program.debugText;
                versionLabel.Text = Program.versionText;
            }

        }
    }
}