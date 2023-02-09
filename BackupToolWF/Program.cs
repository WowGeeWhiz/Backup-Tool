using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace BackupToolWF
{
    internal static class Program
    {
        public static string versionText = "", defaultVersionText = "Ethan Johnson - v3.0", debugText = " - DEBUG ENABLED";
        public static string applicationPath = Directory.GetCurrentDirectory();
        public static bool debug = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            versionText = defaultVersionText;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new mainMenu());
        }

        public static void StartNewForm(Form currentForm, Form newForm)
        {
            newForm.Size = currentForm.Size;
            newForm.MinimumSize = currentForm.MinimumSize;
            newForm.MaximumSize = currentForm.MaximumSize;
            newForm.MaximizeBox = currentForm.MaximizeBox;
            newForm.ControlBox = currentForm.ControlBox;
            newForm.Text = currentForm.Text;
            newForm.Show();
            currentForm.Hide();
        }

        public static void ReturnToForm(Form currentForm, Form existingForm)
        {
            existingForm.Size = currentForm.Size;
            existingForm.Location = currentForm.Location;
            existingForm.Show();
            currentForm.Close();
        }

        public static void SavePaths(List<string> newPaths, string[] currentPaths)
        {
            string[] temp = new string[newPaths.Count + currentPaths.Length];
            for (int a = 0; a < currentPaths.Length; a++)
            {
                temp[a] = currentPaths[a];
            }
            int listIndex = 0;
            for (int a = currentPaths.Length; a < temp.Length; a++)
            {
                temp[a] = newPaths[listIndex];
                listIndex++;
            }

            try
            {
                if (!File.Exists(applicationPath + "\\savedPaths.txt")) File.Create(applicationPath + "\\savedPaths.txt");
                File.WriteAllLines(applicationPath + "\\savedPaths.txt", temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return;
            }


            return;
        }

        public static void DeletePath(int index, string[] paths)
        {
            string[] temp = new string[paths.Length - 1];
            for (int a = 0; a < paths.Length; a++)
            {
                if (a < index) temp[a] = paths[a];
                else if (a > index) temp[a - 1] = paths[a];
            }

            try
            {
                if (!File.Exists(applicationPath + "\\savedPaths.txt")) File.Create(applicationPath + "\\savedPaths.txt");
                File.WriteAllLines(applicationPath + "\\savedPaths.txt", temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return;
            }

            return;
        }
        
        public static bool CheckValidDirectory(string dir)//check for invalid characters in a directory
        {
            foreach (char c in dir)
            {
                if (c == '\'' || c == '|' || c == '?' || c == '*' || c == '<' || c == '>' || c == '"') return false;
            }
            return true;
        }

        static public bool AccessibleDirectory(string dir)
        {
            //return value starts as true
            bool temp = true;

            //try-catch for exception handling
            try
            {
                //if directory does not exist, create directory
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                //write a test file to check for access
                File.WriteAllLines(dir + "\\test.txt", new string[] { "test file" });
            }
            //catch program cannot access dir
            catch (UnauthorizedAccessException)
            {
                //display message, mark as invalid
                MessageBox.Show("The program cannot access that directory.\nTry running the program as an administrator, or changing the security of the directory");
                temp = false;
            }
            //generic exception
            catch (Exception ex)
            {
                //dispaly message, mark as invalid
                MessageBox.Show("Error: " + ex.Message);
                temp = false;
            }
            finally
            {
                //delete temp file, return validit
                if (File.Exists(dir + "\\test.txt")) File.Delete(dir + "\\test.txt");
            }
            return temp;
        }

        public static string[] LoadPaths()
        {
            try
            {
                File.SetAttributes(applicationPath + @"\savedPaths.txt", FileAttributes.Normal); //ensure not readonly
                string[] lines = File.ReadAllLines(applicationPath + @"\savedPaths.txt"); //read all saved paths
                return lines;
            }
            catch (FileNotFoundException)
            {
                File.Create(applicationPath + @"\savedPaths.txt");
                return new string[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("\tError: " + ex.Message + "\n\tCould not load saved paths..."); //break on other exception
                return new string[0];
            }
        }

        public static string[,] LoadPresets()
        {
            try
            {
                File.SetAttributes(applicationPath + @"\savedPresets.txt", FileAttributes.Normal); //ensure not readonly
                string[] lines = File.ReadAllLines(applicationPath + @"\savedPresets.txt"); //read all saved paths
                string[,] parsed = new string[lines.Length, 3];

                for (int a = 0; a < lines.Length; a++)
                {
                    string[] temp = lines[a].Split('|', 3);
                    parsed[a, 0] = temp[0];
                    parsed[a, 1] = temp[1];
                    parsed[a, 2] = temp[2];
                }
                return parsed;
            }
            catch (FileNotFoundException)
            {
                File.Create(applicationPath + @"\savedPresets.txt");
                return new string[0,0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("\tError: " + ex.Message + "\n\tCould not load saved presets..."); //break on other exception
                return new string[0,0];
            }
        }

        public static void MakePreset(string name, string input, string output, string[,] presets)
        {
            string[] temp = new string[presets.GetLength(0) + 1];
            for (int a = 0; a < presets.GetLength(0); a++)
            {
                temp[a] = presets[a, 0] + '|' + presets[a, 1] + '|' + presets[a, 2];
            }
            temp[presets.GetLength(0)] = name + '|' + input + '|' + output;

            try
            {
                if (!File.Exists(applicationPath + "\\savedPresets.txt")) File.Create(applicationPath + "\\savedPresets.txt");
                File.WriteAllLines(applicationPath + "\\savedPresets.txt", temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return;
            }

            return;
        }

        public static void UpdatePreset(int index, string name, string input, string output, string[,] presets)
        {
            string[] temp = new string[presets.GetLength(0)];
            for(int a = 0; a < presets.GetLength(0); a++)
            {
                if (a == index)
                {
                    temp[a] = name + '|' + input + '|' + output;
                }
                else
                {
                    temp[a] = presets[a, 0] + '|' + presets[a, 1] + '|' + presets[a, 2];
                }
            }

            try
            {
                if (!File.Exists(applicationPath + "\\savedPresets.txt")) File.Create(applicationPath + "\\savedPresets.txt");
                File.WriteAllLines(applicationPath + "\\savedPresets.txt", temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return;
            }

            return;
        }

        public static void DeletePreset(int index, string[,] presets)
        {
            string[] temp = new string[presets.GetLength(0) - 1];
            for (int a = 0; a < presets.GetLength(0); a++)
            {
                if (a < index) temp[a] = presets[a, 0] + '|' + presets[a, 1] + '|' + presets[a, 2];
                else if (a > index) temp[a - 1] = presets[a, 0] + '|' + presets[a, 1] + '|' + presets[a, 2];
            }

            try
            {
                if (!File.Exists(applicationPath + "\\savedPresets.txt")) File.Create(applicationPath + "\\savedPresets.txt");
                File.WriteAllLines(applicationPath + "\\savedPresets.txt", temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return;
            }

            return;
        }

        public static bool DuplicateFiles(string input, string output)
        {
            Form working = new movingFiles();
            working.Show();
            try
            {
                CopyFilesRecursively(new DirectoryInfo(input), new DirectoryInfo(output));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                working.Close();
                return false;
            }

            MessageBox.Show("Files moved successfully from: " + input + "\nto: " + output);
            working.Close();
            return true;

        }

        static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories()) CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name));
            }
        } //Copy each file and folder in the given directory to the second directory

    }
}