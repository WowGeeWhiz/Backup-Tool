using System.ComponentModel.Design;
using System.Data.Common;
using System.Diagnostics.SymbolStore;
using System.IO;

namespace Directory_Backup
{
    class Program
    {
        static string versionNum = "1.0", loadDir = "none", saveDir = "none", appDir;
        static string[,] paths;
        static int numPathsSaved;
        static bool debug = false, duping = false; //set debug to true for more information whenever something is attempted

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n~~~~~~~~~~ DIRECTORY BACKUP V" + versionNum + " ~~~~~~~~~~\n\tWritten by Ethan Johnson\n\n\tPress ENTER to continue...");
            Console.ReadLine();

            bool stop = false;
            do
            {
                int runMethod = Menu();

                switch (runMethod)
                {
                    default:
                    case 0:
                        Console.WriteLine("\tError in menu function...\n\tProcess canceled. Press ENTER to continue...");
                        Console.ReadLine();
                        return;
                    case 1:
                        loadDir = LoadPath("load from");
                        break;
                    case 2:
                        loadDir = CreatePath("load from");
                        break;
                    case 3:
                        saveDir = LoadPath("save to");
                        break;
                    case 4:
                        saveDir = CreatePath("save to");
                        break;
                    case 5:
                        AttemptDupe();
                        break;
                    case 6:
                        ResetDirs();
                        break;
                    case 7:
                        DeleteSavedDir();
                        break;
                    case 8:
                        AddSavedDir();
                        break;
                    case 9:
                        ViewAllDirs();
                        break;
                    case 10:
                        stop = true;
                        break;
                }
            } while (!stop);

            Console.Clear();
            Console.WriteLine("\tThanks for using!");
            Wait();
        } //initializes and handles the response for the program loop

        static void AddSavedDir()
        {
            CreatePath("add to list");
        } //create a new saved directory by calling the CreatePath() function

        static void DeleteSavedDir()
        {
            UpdateSaves();
            DisplaySavedDirs();
            bool stop = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\tThere are " + numPathsSaved + " saved paths...\n" +
                    "\tWould you like to remove from a list or search for a directory? (search/select)\n" +
                    "\t(enter 'cancel' to go back)");
                string answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "search":
                        bool stopSearch = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tEnter the name the path is saved under...\n" +
                                "\t(path names are case sensitive. enter 'cancel' to go back)");
                            string temp = Console.ReadLine();
                            if (temp == "cancel") stopSearch = true;
                            else
                            {
                                bool pathFound = false;
                                string tempDir = "none";
                                int index = -1;
                                for (int a = 0; a < numPathsSaved; a++)
                                {
                                    if (temp == paths[a, 0])
                                    {
                                        pathFound = true;
                                        tempDir = paths[a, 1];
                                        index = a;
                                        break;
                                    }
                                }

                                if (!pathFound)
                                {
                                    Console.WriteLine("\tPath not found...");
                                    Wait();
                                }
                                else
                                {
                                    bool askDelete = true;

                                    do
                                    {
                                        Console.WriteLine("\nPath '" + temp + "' is: " + @tempDir);
                                        Console.WriteLine("\nWould you like to delete this directory? (y/n)");
                                        string response = Console.ReadLine().ToLower();
                                        switch (response)
                                        {
                                            case "y":
                                                Console.WriteLine("\tRemoving saved path. Please wait...");
                                                string[,] tempPaths = new string[numPathsSaved - 1, 2];
                                                for (int a = 0; a < numPathsSaved - 1; a++)
                                                {
                                                    if (a >= index)
                                                    {
                                                        tempPaths[a, 0] = paths[a + 1, 0];
                                                        tempPaths[a, 1] = paths[a + 1, 1];
                                                    }
                                                    else
                                                    {
                                                        tempPaths[a, 0] = paths[a, 0];
                                                        tempPaths[a, 1] = paths[a, 1];
                                                    }
                                                }
                                                paths = tempPaths;
                                                if (WritePaths()) Console.WriteLine("\tSaved path removed...");
                                                Wait();
                                                return;
                                            case "n":
                                                askDelete = false;
                                                break;
                                        }

                                    } while (askDelete);

                                }
                            }
                        } while (!stopSearch);
                        break;
                    case "select":
                        bool stopSelect = false;
                        do
                        {
                            Console.Clear();

                            DisplaySavedDirs();
                            Console.WriteLine("\n\tEnter the number beside the path to delete that directory\n\tEnter 'cancel' to go back...");

                            string response = Console.ReadLine();

                            if (response == "cancel")
                            {
                                stopSelect = true;
                                break;
                            }
                            else
                            {

                                bool isValid = true;
                                foreach (char c in response)
                                {
                                    if (!Char.IsDigit(c))
                                    {
                                        isValid = false;
                                        break;
                                    }
                                }
                                if (!isValid || response == null || response == "")
                                {
                                    if (!isValid && debug)
                                    {
                                        Console.WriteLine("Not all digits... Press ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                    if (response == null && debug)
                                    {
                                        Console.WriteLine("Null response... Press ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                    Console.WriteLine("\n\tInvalid response...");
                                    Wait();
                                }
                                else
                                {
                                    int index = Convert.ToInt32(response);

                                    if (index <= numPathsSaved - 1 && index >= 0)
                                    {

                                        bool askDelete = true;

                                        do
                                        {
                                            Console.WriteLine("\nPath '" + index + "' is: " + paths[index,1]);
                                            Console.WriteLine("\nWould you like to delete this directory? (y/n)");
                                            string ans = Console.ReadLine().ToLower();
                                            switch (ans)
                                            {
                                                case "y":
                                                    Console.WriteLine("\tRemoving saved path. Please wait...");
                                                    string[,] tempPaths = new string[numPathsSaved - 1, 2];
                                                    for (int a = 0; a < numPathsSaved - 1; a++)
                                                    {
                                                        if (a >= index)
                                                        {
                                                            tempPaths[a, 0] = paths[a + 1, 0];
                                                            tempPaths[a, 1] = paths[a + 1, 1];
                                                        }
                                                        else
                                                        {
                                                            tempPaths[a, 0] = paths[a, 0];
                                                            tempPaths[a, 1] = paths[a, 1];
                                                        }
                                                    }
                                                    paths = new string[tempPaths.Length, 2];
                                                    paths = tempPaths;
                                                    if (WritePaths()) Console.WriteLine("\tSaved path removed...");
                                                    Wait();
                                                    return;
                                                case "n":
                                                    askDelete = false;
                                                    break;
                                            }

                                        } while (askDelete);
                                    }
                                    else
                                    {
                                        if (!isValid && debug)
                                        {
                                            Console.WriteLine("Outside index... Press ENTER to continue...");
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\n\tInvalid response...\n\tPress ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                }
                            }


                        } while (!stopSelect);
                        break;
                    case "cancel":
                        stop = true;
                        break;
                }
            } while (!stop);
        } //Remove a saved directory

        static bool WritePaths()
        {

            string[] tempPaths = new string[paths.GetLength(0)];
            for (int a = 0; a < paths.GetLength(0); a++)
            {
                if (debug)
                {
                    Console.WriteLine("Index is at " + a + ". Max index is " + paths.GetLength(0) + " other dimension is " + paths.GetLength(1));
                    Wait();
                }
                tempPaths[a] = paths[a, 0];
                tempPaths[a] += '|';
                tempPaths[a] += paths[a, 1];
            }


            bool error = false;
            try
            {

                if (debug)
                {
                    Console.WriteLine("Attempting to write lines to file... Press ENTER to continue...");
                    Console.ReadLine();
                }
                File.WriteAllLines(appDir + "\\savedPaths.txt", tempPaths);
            }
            catch (Exception ex)
            {
                if (debug)
                {
                    Console.WriteLine("Should print failed save error message now... Press ENTER to continue...");
                    Console.ReadLine();
                }
                error = true;
                Console.WriteLine("\tSave unsuccessful...\n" + ex.Message);
            }

            if (debug && error == false)
            {
                Console.WriteLine("Save successfull... Press ENTER to continue...");
                Console.ReadLine();
            }
            return error;
        } //Write all paths stored in memory to the file (used mainly by DeleteSavedDir())

        static void ViewAllDirs()
        {
            DisplaySavedDirs();
            Wait();
        } //Look at all directories without doing anything

        static void DisplaySavedDirs()
        {
            UpdateSaves();
            Console.Clear();
            Console.WriteLine("\tHere are all saved paths:");
            for (int a = 0; a < numPathsSaved; a++)
            {
                Console.WriteLine("\t\t" + a + " - " + paths[a, 0] + " - " + paths[a, 1]);
            }
        } //Text display all directories

        static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        } //Copy each file and folder in the given directory to the second directory

        static void AttemptDupe()
        {
            bool goodFolder = false;
            string folder;
            do
            {
                Console.WriteLine("\tEnter the folder name for the duplication...");
                folder = Console.ReadLine();
                bool validFolder = true;
                foreach (char c in folder)
                {
                    if (c == '/' || c == '|' || c == ':' || c == '?' || c == '*' || c == '<' || c == '>' || c == '"' || c == '\\')
                    {
                        validFolder = false;
                        break;
                    }
                }
                if (validFolder)
                {
                    goodFolder = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid folder name. Folder names cannot contain the following: / | : ? * < > \"");
                    Wait();
                }


            } while (!goodFolder);

            saveDir += '\\' + folder;

            bool failed = false;
            try
            {
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                Console.WriteLine("\tDuplicating files. Please wait...");
                CopyFilesRecursively(new DirectoryInfo(loadDir), new DirectoryInfo(saveDir));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
                Console.WriteLine("\tDuplication unsuccesful...");

                Console.WriteLine("\tPress ENTER to try again...\n\tEnter 'cancel' to resest the directories...");
                string response = Console.ReadLine();
                if (response == "cancel") ResetDirs();
            }
            if (!failed)
            {
                Console.WriteLine("\tDuplication seccesful...");
                ResetDirs();
                Wait();
                duping = false;
                
            }
        } //Attempt to copy the files

        static void Wait()
        {
            Console.WriteLine("\tPress ENTER to continue...");
            Console.ReadLine();
        } //Pause program until user presses ENTER

        static void ResetDirs()
        {
            Console.WriteLine("\tResetting directories...");
            loadDir = "none";
            saveDir = "none";
            Console.WriteLine("\tDirectories reset...");
        } //Reset the active directories to "none"

        static string LoadPath(string currentProcess)
        {

            UpdateSaves();
            bool stop = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\tThere are " + numPathsSaved + " saved paths...\n" +
                    "\tWould you like to select from a list or search for a directory? (search/select)\n" +
                    "\t(enter 'cancel' to go back)");
                string answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "search":
                        bool stopSearch = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tEnter the name the path is saved under...\n" +
                                "\t(path names are case sensitive. enter 'cancel' to go back)");
                            string temp = Console.ReadLine();
                            if (temp == "cancel") stopSearch = true;
                            else
                            {
                                bool pathFound = false;
                                string tempDir = "none";
                                for (int a = 0; a < numPathsSaved; a++)
                                {
                                    if (temp == paths[a, 0])
                                    {
                                        pathFound = true;
                                        tempDir = paths[a, 1];
                                        break;
                                    }
                                }

                                if (!pathFound)
                                {
                                    Console.WriteLine("\tPath not found...");
                                    Wait();
                                }
                                else
                                {
                                    bool askLoad = true;

                                    do
                                    {
                                        Console.WriteLine("\nPath '" + temp + "' is: " + @tempDir);
                                        Console.WriteLine("\nWould you like to " + currentProcess + " this directory? (y/n)");
                                        string response = Console.ReadLine().ToLower();
                                        switch (response)
                                        {
                                            case "y":
                                                return tempDir;
                                            case "n":
                                                tempDir = "none";
                                                askLoad = false;
                                                break;
                                        }

                                    } while (askLoad);

                                }
                            }
                        } while (!stopSearch);
                        break;
                    case "select":
                        bool stopSelect = false;
                        do
                        {
                            Console.Clear();

                            DisplaySavedDirs();
                            Console.WriteLine("\n\tEnter the number beside the path to " + currentProcess + " that directory\n\tEnter 'cancel' to go back...");

                            string response = Console.ReadLine();

                            if (response == "cancel")
                            {
                                stopSelect = true;
                                break;
                            }
                            else
                            {

                                bool isValid = true;
                                foreach (char c in response)
                                {
                                    if (!Char.IsDigit(c))
                                    {
                                        isValid = false;
                                        break;
                                    }
                                }
                                if (!isValid || response == null)
                                {
                                    if (!isValid && debug)
                                    {
                                        Console.WriteLine("Not all digits... Press ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                    if (response==null && debug)
                                    {
                                        Console.WriteLine("Null response... Press ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                    Console.WriteLine("\n\tInvalid response...");
                                    Wait();
                                }
                                else
                                {
                                    int index = Convert.ToInt32(response);

                                    if (index <= numPathsSaved -1 && index >= 0)
                                    {
                                        bool stopAsk = false;

                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\tYou selected path " + index);
                                            Console.WriteLine("\tThis path is: " + @paths[index, 1]);
                                            Console.WriteLine("\tWould you like to " + currentProcess + " this directory? (y/n)");
                                            string yN = Console.ReadLine().ToLower();
                                            if (yN == "y") return @paths[index, 1];
                                            else if (yN == "n") stopAsk = true;

                                        } while (!stopAsk);
                                    }
                                    else
                                    {
                                        if (!isValid && debug)
                                        {
                                            Console.WriteLine("Outside index... Press ENTER to continue...");
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\n\tInvalid response...\n\tPress ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                }
                            }


                        } while (!stopSelect);
                        break;
                    case "cancel":
                        stop = true;
                        break;
                }
            } while (!stop);

            return "none";

        } //Find the path to load from

        static void UpdateSaves()
        {
            if (debug)
            {
                Console.WriteLine("Starting UpdateSaves function... Press ENTER to continue...");
                Console.ReadLine();
            }
            Console.WriteLine("\tScanning for saved data paths...");
            appDir = Directory.GetCurrentDirectory(); //get application directory

            try //attempt loading saved paths
            {

                if (debug)
                {
                    Console.WriteLine("Attempting to read Save file... Press ENTER to continue...");
                    Console.ReadLine();
                }

                File.SetAttributes(appDir + @"\savedPaths.txt", FileAttributes.Normal);
                string[] lines = File.ReadAllLines(appDir + @"\savedPaths.txt"); //read all saved paths
                if (debug)
                {
                    Console.WriteLine("lines[] size is " + lines.Length + "... Press ENTER to continue...");
                    Console.ReadLine();
                }
                numPathsSaved = lines.Length;
                if (debug)
                {
                    Console.WriteLine("numPathsSaved is " +numPathsSaved + "... Press ENTER to continue...");
                    Console.ReadLine();
                }
                paths = new string[numPathsSaved, 2]; //create array of saved values

                if (numPathsSaved == 0)
                {
                    Console.WriteLine("\tNo saved paths found...");
                    Wait();
                }
                else
                {
                    Console.WriteLine("\t" + numPathsSaved + " saved paths");
                    Wait();
                }

                for (int a = 0; a < lines.Length; a++) //foreach saved string
                {
                    string[] temp = lines[a].Split('|'); //split into name and path
                    paths[a, 0] = temp[0]; //assign values
                    paths[a, 1] = temp[1];
                }
            }
            catch (FileNotFoundException)
            {

                if (debug)
                {
                    Console.WriteLine("File not found... Press ENTER to continue...");
                    Console.ReadLine();
                }
                Console.WriteLine("\tNo save file found. Creating save file..."); //create if no file found
                File.Create(appDir + @"\savedPaths.txt");
                Console.WriteLine("\tSave file created...");
                Console.WriteLine("\tPress ENTER to continue...");
                Console.ReadLine();
                UpdateSaves();
            }
            catch (Exception ex)
            {
                if (debug)
                {
                    Console.WriteLine("Unhandled Exception in UpdateSaves... Press ENTER to continue...");
                    Console.ReadLine();
                }
                Console.WriteLine("\tError: " + ex.Message + "\n\tCould not load saved paths..."); //break on other exception
                Wait();

                return;
            }
        } //Update the save file of paths

        static string CreatePath(string currentProcess)
        {

            if (debug)
            {
                Console.WriteLine("Creating path... Press ENTER to continue...");
                Console.ReadLine();
            }
            bool stop = false;
            string tempDir;
            do
            {


                if (debug)
                {
                    Console.WriteLine("Asking for directory... Press ENTER to continue...");
                    Console.ReadLine();
                }

                bool validDir = true;
                Console.Clear();
                Console.WriteLine("\tEnter the directory you would like to " + currentProcess);
                tempDir = @Console.ReadLine();

                foreach (char c in tempDir)
                {
                    if (c == '/' || c == '|' || c == '?' || c == '*' || c == '<' || c == '>' || c == '"')
                    {
                        if (debug) Console.WriteLine("Invalid directory found");
                        validDir = false;
                        break;
                    }
                }

                if (!validDir)
                {
                    Console.WriteLine("\tInvalid directory entered..." +
                        "\t" + @"Directories cannot contain any of the following characters: / | ? * < > """);
                    Wait();
                }
                else
                {


                    if (debug)
                    {
                        Console.WriteLine("Directory is valid... Press ENTER to continue...");
                        Console.ReadLine();
                    }

                    if (currentProcess == "load from")
                    {


                        if (debug)
                        {
                            Console.WriteLine("Checking for existing loading directory... Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        if (Directory.Exists(tempDir))
                        {


                            if (debug)
                            {
                                Console.WriteLine("Directory exists... Press ENTER to continue...");
                                Console.ReadLine();
                            }
                            bool askSave = true;

                            do
                            {
                                if (debug)
                                {
                                    Console.WriteLine("Asking to save... Press ENTER to continue...");
                                    Console.ReadLine();
                                }

                                Console.WriteLine("\tYou entered: " + @tempDir);
                                Console.WriteLine("\tWould you like to save this directory? (y/n)");
                                string aS = Console.ReadLine().ToLower();
                                if (aS == "y")
                                {

                                    if (debug)
                                    {
                                        Console.WriteLine("Trying to save... Press ENTER to continue...");
                                        Console.ReadLine();
                                    }
                                    if (!SaveDirectory(tempDir))
                                    {

                                        if (debug)
                                        {
                                            Console.WriteLine("Directory saved successfully... Press ENTER to continue...");
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\tDirectory saved...\n\tPress ENTER to continue...");
                                        Console.ReadLine();
                                        askSave = false;
                                    }
                                    else
                                    {

                                        Console.WriteLine("\tDirectory failed to save...\n\tPress Enter to continue...");
                                        Console.ReadLine();
                                    }
                                }
                                else if (aS == "n") askSave = false;

                            } while (askSave);

                            return tempDir;
                        }
                        else
                        {


                            if (debug)
                            {
                                Console.WriteLine("Directory does not exist... Press ENTER to continue...");
                                Console.ReadLine();
                            }
                            Console.WriteLine("\tDirectory does not exist...\n\tCannot duplicate nonexistant directory...");
                            Wait();
                        }
                    }
                    else
                    {
                        bool askSave = true;

                        do
                        {
                            if (debug)
                            {
                                Console.WriteLine("Asking to save directory (currently using savedirectory) Press ENTER to continue...");
                                Console.ReadLine();
                            }
                            Console.WriteLine("\tYou entered: " + @tempDir);
                            Console.WriteLine("\tWould you like to save this directory? (y/n)");
                            string aS = Console.ReadLine().ToLower();
                            if (aS == "y")
                            {
                                if (debug)
                                {
                                    Console.WriteLine("Attempting to save directory... Press ENTER to continue...");
                                    Console.ReadLine();
                                }
                                if (!SaveDirectory(tempDir))
                                {
                                    Console.WriteLine("\tDirectory saved...\n\tPress ENTER to continue...");
                                    Console.ReadLine();
                                    askSave = false;
                                }
                                else
                                {
                                    Console.WriteLine("\tDirectory failed to save...\n\tPress Enter to continue...");
                                    Console.ReadLine();
                                }
                            }
                            else if (aS == "n") askSave = false;

                        } while (askSave);

                        return tempDir;
                    }

                    if (debug)
                    {
                        Console.WriteLine("Restarting loop... Press ENTER to continue...");
                        Console.ReadLine();
                    }
                }
                


            } while (!stop);
            if (debug)
            {
                Console.WriteLine("Loop broken... Press ENTER to continue...");
                Console.ReadLine();
            }

            return "none";
        } //Find a path that is not saved

        static bool SaveDirectory(string tempDir)
        {

            if (debug)
            {
                Console.WriteLine("Starting SaveDirectory function... Press ENTER to continue...");
                Console.ReadLine();
            }
            UpdateSaves();

            string[] tempPaths = new string[numPathsSaved + 1];

            for (int a = 0; a < numPathsSaved; a++)
            {
                tempPaths[a] = paths[a, 0] + "|" + paths[a, 1];
            }


            bool validName = true;
            bool stopValidCheck = false;
            string name;
            do
            {
                Console.WriteLine("\n\n\tPlease enter the name for the path...");
                name = Console.ReadLine();

                if (name == null || name == " " || name == "") validName = false;
                else validName = true;

                if (!validName)
                {
                    Console.WriteLine("\tPath name cannot be left empty...");
                    Wait();
                }
                else
                {
                    stopValidCheck = true;
                }


            } while (!stopValidCheck);
            Console.WriteLine("\tSaving directory " + name + " - " + tempDir);

            tempPaths[numPathsSaved] = name + "|" + tempDir;
            bool error = false;
            try
            {

                if (debug)
                {
                    Console.WriteLine("Attempting to write lines to file... Press ENTER to continue...");
                    Console.ReadLine();
                }
                File.WriteAllLines(appDir + "\\savedPaths.txt", tempPaths);
            }
            catch (Exception ex)
            {
                if (debug)
                {
                    Console.WriteLine("Should print failed save error message now... Press ENTER to continue...");
                    Console.ReadLine();
                }
                error = true;
                Console.WriteLine(ex.Message);
            }

            if (debug && error == false)
            {
                Console.WriteLine("Save successfull... Press ENTER to continue...");
                Console.ReadLine();
            }
            return error;

        } //Saves a found path (from CreatePath) to the list

        static int Menu()
        {
            UpdateSaves();
            bool stop = false; //create stop condition

            do //loop
            {
                Console.Clear(); //clear console
                if (duping)
                {
                    if (loadDir == "none") //if not loaded yet
                    {
                        if (numPathsSaved != 0) //if paths loaded
                        {
                            Console.WriteLine("\tWould you like to backup from a saved directory? (y/n)"); //ask to load directory
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "y") return 1;
                            else if (answer == "n") return 2;
                        }
                        else return 2; //if no loaded paths return
                    }
                    else if (saveDir == "none") //if no save directory loaded
                    {
                        if (numPathsSaved != 0) //if paths loaded
                        {
                            Console.WriteLine("\tWould you like to backup to a saved directory? (y/n)"); //ask to load directory
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "y") return 3;
                            else if (answer == "n") return 4;
                        }

                    }
                    else if (saveDir != "none" && loadDir != "none")
                    {
                        bool cancel = false;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tYou have selected to copy directory:");
                            Console.WriteLine("\t\t" + loadDir);
                            Console.WriteLine("\tTo this directory:");
                            Console.WriteLine("\t\t" + saveDir);
                            Console.WriteLine("\n\tIs this correct? (y/n)");
                            string cancelString = Console.ReadLine().ToLower();
                            if (cancelString == "y") return 5;
                            else if (cancelString == "n") return 6;
                        } while (!cancel);
                    }
                }
                else
                {
                    Console.WriteLine("\tWhat would you like to do?\n" +
                        "\t\t0 - Duplicate a directory\n" +
                        "\t\t1 - View all saved paths\n" +
                        "\t\t2 - Remove a saved path\n" +
                        "\t\t3 - Save a new path\n" +
                        "\t\t4 - Stop program");
                    string toDo = Console.ReadLine();

                    switch (toDo)
                    {
                        case "0":
                            duping = true;
                            break;
                        case "1":
                            return 9;
                        case "2":
                            return 7;
                        case "3":
                            return 8;
                        case "4":
                            return 10;
                    }
                }
            } while (!stop);

            return 0;
        } //Main menu for the program
    }
}