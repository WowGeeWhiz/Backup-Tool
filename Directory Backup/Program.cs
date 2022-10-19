using System.ComponentModel.Design;
using System.Data.Common;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Runtime.Serialization;

namespace Directory_Backup
{
    class Program
    {
        static string versionNum = "2.0", loadDir = "none", saveDir = "none", appDir;
        static string[,] paths, presets;
        static int numPathsSaved, numPresetsSaved;
        static bool debug = false, duping = false; //set debug to true for more information whenever something is attempted


        static bool displayMovedFiles = true; //set to false to hide file transfer confirmations


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
                    case 0: //error in menu
                        Console.WriteLine("\tError in menu function...\n\tProcess canceled. Press ENTER to continue...");
                        Console.ReadLine();
                        return;
                    case 1: //load path to load from
                        loadDir = LoadPath("load from");
                        break;
                    case 2: //create path to load from
                        loadDir = CreatePath("load from");
                        break;
                    case 3: //load path to save to
                        saveDir = LoadPath("save to");
                        break;
                    case 4: //create path to save to
                        saveDir = CreatePath("save to");
                        break;
                    case 5: //actively duplicating
                        AttemptDupe();
                        break;
                    case 6: //reset the active directories (loadDir & saveDir)
                        ResetDirs();
                        break;
                    case 7: //delete a saved directory
                        DeleteSavedDir();
                        break;
                    case 8: //add a new directory
                        AddSavedDir();
                        break;
                    case 9: //view saved directories
                        ViewAllDirs();
                        break;
                    case 10: //stop program
                        stop = true;
                        break;
                    case 11: //run a preset backup
                        PresetBackup();
                        break;
                    case 12: //view preset backups
                        UpdatePresets();
                        if (numPresetsSaved != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\tThere are " + numPresetsSaved + " saved presets...");
                            DisplaySavedPresets();
                            Wait();
                        }
                        break;
                    case 13: //create preset backups
                        string tempLoad = LoadOrCreate("load from");
                        if (tempLoad == "none") break;
                        string tempSave = LoadOrCreate("save to");
                        if (tempSave == "none") break;
                        CreatePreset(tempLoad, tempSave);
                        break;
                    case 14: //delete preset backup
                        RemovePreset();
                        Wait();
                        break;
                }
            } while (!stop);

            Console.Clear();
            Console.WriteLine("\tThanks for using!");
            Wait();
        } //initializes and handles the response for the program loop

        static void RemovePreset()
        {
            if (debug)
            {
                Console.WriteLine("Starting RemovePreset()");
                Wait();
            }
            UpdatePresets();
            bool stop = false;
            do
            {
                Console.Clear();

                bool stopSelecting = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\tAll saved presets are:");
                    DisplaySavedPresets();
                    Console.WriteLine("\tEnter the number you would like to remove");
                    Console.WriteLine("\t(enter 'cancel' to return)");
                    string selectResponse = Console.ReadLine().ToLower();
                    if (selectResponse == "cancel")
                    {
                        stopSelecting = true;
                        break;
                    }
                    else
                    {
                        bool validString = true;
                        foreach (char c in selectResponse)
                        {
                            if (!Char.IsDigit(c))
                            {
                                validString = false;
                                break;
                            }

                            if (!validString || selectResponse == "")
                            {
                                Console.WriteLine("\tInvalid response...");
                                Wait();
                            }
                            else
                            {
                                int index = Convert.ToInt32(selectResponse);
                                if (index >= numPresetsSaved)
                                {
                                    Console.WriteLine("\tThat preset does not exist...");
                                }
                                bool stopDeleting = false;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("\tYou have selected preset " + index + " - " + presets[index, 0]);
                                    Console.WriteLine("\tThis preset copies " + presets[index, 1]);
                                    Console.WriteLine("\tto " + presets[index, 2]);
                                    Console.WriteLine("\tWould you like to delete this preset? (y/n)");
                                    string yN = Console.ReadLine().ToLower();
                                    if (yN == "n")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\tPreset not removed...");
                                        Wait();
                                        return;
                                    }
                                    else if (yN == "y")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\tRemoving preset...");

                                        string[] lines = new string[numPresetsSaved - 1];
                                        for (int a = 0; a < numPresetsSaved; a++)
                                        {
                                            if (a > index)
                                            {
                                                lines[a - 1] = presets[a, 0] + "|" + presets[a,1] + "|" + presets[a,2];
                                                if (debug) Console.WriteLine("added {a}minus1 - {lines[a]}");
                                            }
                                            else if (a < index)
                                            {
                                                lines[a] = presets[a, 0] + "|" + presets[a, 1] + "|" + presets[a, 2];
                                                if (debug) Console.WriteLine("added {a} - {lines[a]}");
                                            }
                                            else if (a == index && debug) Console.WriteLine($"skipping {a} - {presets[a, 0]} - {presets[a, 1]} - {presets[a, 2]}"); 
                                        }

                                        try
                                        {
                                            if (!File.Exists(appDir + "\\savedPresets.txt")) File.Create(appDir + "\\savedPresets.txt");

                                            File.WriteAllLines(appDir + "\\savedPresets.txt", lines);

                                            Console.WriteLine("\tPresets updated...");
                                            Wait();
                                            return;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Error, updating unsuccessful");
                                            Console.WriteLine(ex.Message);
                                            Wait();
                                        }
                                    }
                                } while (!stopDeleting);
                            }
                        }
                    }

                } while (!stopSelecting);





            } while (!stop);
        } //finds and removes a preset from the file

        static string LoadOrCreate(string selectingFor)
        {
            if (debug)
            {
                Console.WriteLine("Starting LoadOrCreate()");
                Wait();
            }
            bool stop = false;
            string temp = "none";
            do
            {
                Console.Clear();
                Console.WriteLine("\tYou are creating a preset backup...");
                Console.WriteLine("\tWould you like the preset to " + selectingFor + " a saved directory? (y/n)");
                Console.WriteLine("\t(enter 'cancel' to return)");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "cancel":
                        return response;
                    case "y":
                        temp = LoadPath(selectingFor, true);
                        if (temp != "none") return temp;
                        break;
                    case "n":
                        temp = CreatePath(selectingFor, true);
                        if (temp != "none") return temp;
                        break;
                        
                }

            } while (!stop);

            return temp;
        } //handle getting load and save directories for preset

        static void CreatePreset(string load, string save)
        {
            if (debug)
            {
                Console.WriteLine($"Starting CreatePreset() with {load} and {save}");
            }
            if (load == "none" || save == "none") //check for empty inputs
            {
                Console.WriteLine("\tInvalid inputs...\n" +
                    "\tPreset not created...");
                Wait();
                return;
            }
            bool stop = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\tThis preset will load from " + load);
                Console.WriteLine("\tto " + save);
                Console.WriteLine("\tIs this correct? (y/n)"); //confirm creation of preset
                string yN = Console.ReadLine().ToLower();
                if (yN == "y")
                {
                    SavePreset(load, save);
                    return;
                }
                else if (yN == "n") //cancel preset
                {
                    Console.Clear();
                    Console.WriteLine("\tCreating preset canceled...");
                    Wait();
                    return;
                }
            } while (!stop);
        } //assemble the preset information

        static void SavePreset(string load, string save)
        {
            if (debug)
            {
                Console.WriteLine("Starting SavePreset()");
            }
            UpdatePresets();
            bool nameChosen = false;
            string name = "none";
            do
            {
                Console.Clear();
                Console.WriteLine("\tEnter the name for the preset..."); //get name for preset
                Console.WriteLine("\t(names are case sensitive)");
                name = @Console.ReadLine();
                if (name != null && name != " " && !name.Contains('|')) nameChosen = true; //check for empty name
                else
                {
                    Console.WriteLine("\tName cannot be empty or contain '|'...");
                    Wait();
                }
            } while (!nameChosen);

            Console.Clear();
            Console.WriteLine("\tCreating preset " + name);
            try
            {
                if (!File.Exists(appDir + "\\savedPresets.txt"))
                {
                    if (debug)
                    {
                        Console.WriteLine("File does not exist, creating file...");
                        Wait();
                    }
                    File.Create(appDir + "\\savedPresets.txt");
                }

                
                int tempNumPresetsSaved = numPresetsSaved + 1; 
                if (debug)
                {
                    Console.WriteLine("Number of presets saved: " + numPresetsSaved);
                    Console.WriteLine("TempNumber of presets saved: " + tempNumPresetsSaved);
                    Wait();
                }
                string[] lines = new string[tempNumPresetsSaved];
                for (int a = 0; a < numPresetsSaved; a++)
                {
                    lines[a] = presets[a, 0] + "|" + presets[a, 1] + "|" + presets[a, 2];
                    if (debug)
                    {
                        Console.WriteLine($"Line {a} is {lines[a]}");
                        Wait();
                    }
                }
                lines[numPresetsSaved] = name + "|" + load + "|" + save;
                if (debug)
                {
                    Console.WriteLine("New line is " + lines[numPresetsSaved]);
                    Wait();
                }
                if (debug)
                {
                    Console.WriteLine("Attempting to write lines to file... Press ENTER to continue...");
                    Console.ReadLine();
                }
                File.WriteAllLines(appDir + "\\savedPresets.txt", lines);

                Console.WriteLine("\tPresets saved...");
                Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine("\tError...\n" +
                    "\tPreset save incomplete...\n" +
                    "\tError message: " + ex.Message);
            }

        } //adds a new preset to the file

        static void PresetBackup()
        {
            if (debug)
            {
                Console.WriteLine("\tStarting PresetBackup()...");
                Wait();
            }
            UpdatePresets();
            if (numPresetsSaved == 0) //if no existing presets
            {
                Console.WriteLine("\tPlease create a preset first...");
                Wait();
                return;
            }

            bool stop = false;
            do
            {
                string answer;
                bool stopSelect = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\tEnter the number beside the preset...");
                    Console.WriteLine("\t(enter 'cancel' to go back)");
                    DisplaySavedPresets();
                    answer = Console.ReadLine();

                    if (answer == "cancel") stopSelect = true;
                    else
                    {
                        bool isValid = true;
                        foreach (char c in answer)
                        {
                            if (!Char.IsDigit(c))
                            {
                                isValid = false;
                                break;
                            }
                        } //check for all digits
                        if (!isValid || answer == null)
                        {
                            if (!isValid && debug)
                            {
                                Console.WriteLine("Not all digits... Press ENTER to continue...");
                                Console.ReadLine();
                            }
                            if (answer == null && debug)
                            {
                                Console.WriteLine("Null response... Press ENTER to continue...");
                                Console.ReadLine();
                            }
                            Console.WriteLine("\n\tInvalid response...");
                            Wait();
                        } //check for invalid
                        else
                        {
                            int index = Convert.ToInt32(answer); //convert to int

                            if (index <= numPresetsSaved - 1 && index >= 0) //if within index
                            {
                                bool stopAsk = false;

                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("\tYou selected preset " + index);
                                    Console.WriteLine("\tThis preset is: " + @presets[index, 0]);
                                    Console.WriteLine("\tThis will copy " + @presets[index, 1]);
                                    Console.WriteLine("\tTo " + @presets[index, 2]);
                                    Console.WriteLine("\tWould you like to run this preset? (y/n)");
                                    string yN = Console.ReadLine().ToLower();
                                    if (yN == "y")
                                    {
                                        loadDir = @presets[index, 1];
                                        saveDir = @presets[index, 2];
                                        AttemptDupe(true);
                                        return;
                                    }
                                    else if (yN == "n") stopAsk = true;

                                } while (!stopAsk);
                            }
                            else
                            {
                                if (!isValid && debug)
                                {
                                    Console.WriteLine("Outside index...");
                                    Wait();
                                }
                                Console.WriteLine("\n\tInvalid response...\n\tPress ENTER to continue...");
                                Console.ReadLine();
                            }
                        }
                    }

                } while (!stopSelect);
                break;


            } while (!stop);
        } //user selects preset and runs AttemptDupe() with given values
            
        static void DisplaySavedPresets()
        {
            if (debug)
            {
                Console.WriteLine("Displaying all saved presets...");
                Wait();
            }
            for (int a = 0; a < numPresetsSaved; a++)
            {
                Console.WriteLine($"\t\t{a} - {presets[a, 0]}\n" +
                    $"\t\t\tCopy {presets[a, 1]}\n" +
                    $"\t\t\tTo {presets[a, 2]}");
            }
        } //List all saved presets

        static void UpdatePresets()
        {
            if (debug)
            {
                Console.WriteLine("Starting UpdatePresets()...");
                Wait();
            }

            Console.WriteLine("\tScanning for saved presets...");
            appDir = Directory.GetCurrentDirectory(); //get current application directory

            try //attempt loading paths file
            {
                if (debug)
                {
                    Console.WriteLine("Attempting to read Presets file... Press ENTER to continue...");
                    Console.ReadLine();
                }

                File.SetAttributes(appDir + @"\savedPresets.txt", FileAttributes.Normal); //ensure not readonly
                string[] lines = File.ReadAllLines(appDir + @"\savedPresets.txt"); //read all saved paths
                if (debug)
                {
                    Console.WriteLine("lines[] size is " + lines.Length + "... Press ENTER to continue...");
                    Console.ReadLine();
                }
                numPresetsSaved = lines.Length;
                if (debug)
                {
                    Console.WriteLine("numPresetsSaved is " + numPresetsSaved + "... Press ENTER to continue...");
                    Console.ReadLine();
                }
                presets = new string[numPresetsSaved, 3]; //create array of saved values

                if (numPresetsSaved == 0)
                {
                    Console.WriteLine("\tNo saved presets found...");
                    return;
                } //if no presets
                else
                {
                    Console.WriteLine("\t" + numPresetsSaved + " saved presets");
                    Wait();
                } //otherwise display number of presets

                for (int a = 0; a < numPresetsSaved; a++) //foreach saved string
                {
                    if (debug)
                    {
                        Console.WriteLine("Attempting to write line " + a);
                    }
                    string[] temp = lines[a].Split('|'); //split into name and paths
                    if (debug)
                    {
                        Console.WriteLine($"line {a} is {temp[0]} + {temp[1]} + {temp[2]}");
                    }
                    presets[a, 0] = temp[0]; //assign values
                    if (debug) Console.WriteLine("a,0 complete");
                    presets[a, 1] = temp[1];
                    if (debug) Console.WriteLine("a,1 complete");
                    presets[a, 2] = temp[2];
                    if (debug) Console.WriteLine("a,2 complete");
                }
            }
            catch (FileNotFoundException)
            {
                if (debug)
                {
                    Console.WriteLine("Presets file not found... Press ENTER to continue...");
                    Console.ReadLine();
                }
                Console.WriteLine("\tNo Presets file found. Creating Presets file..."); //create if no file found
                File.Create(appDir + @"\savedPresets.txt");
                Console.WriteLine("\tPresets file created...");
                Wait();
            }
            catch (Exception ex)
            {
                if (debug)
                {
                    Console.WriteLine("Unhandled Exception in UpdatePresets()...");
                    Wait();
                }
                Console.WriteLine("\tError: " + ex.Message + "\n\tCould not load saved presets..."); //break on other exception
                Wait();

                return;
            }
        } //read in all saved presets and assign them to variables for reference

        static void AddSavedDir()
        {
            CreatePath("add to list");
        } //create a new saved directory by calling the CreatePath() function

        static void DeleteSavedDir()
        {
            if (debug)
            {
                Console.WriteLine("Starting DeleteSavedDir()...");
                Wait();
            }
            bool stopSearch = false;
            do
            {
                if (debug) 
                { 
                    Console.WriteLine("Asking for response...");
                    Wait(); 
                }
                Console.Clear();
                DisplaySavedDirs();
                Console.WriteLine("\tEnter the number of the path you would like to remove...\n" +
                    "\t(enter 'cancel' to return)");
                string response = Console.ReadLine().ToLower();
                if (response == "cancel") return;
                else
                {
                    bool isValid = true;
                    if (response == null || response == " ")
                    {
                        if (debug) Console.WriteLine("Null response...");
                        isValid = false;
                    }
                    foreach (char c in response)
                    {
                        if (!Char.IsDigit(c))
                        {
                            if (debug) Console.WriteLine("Not all digits...");
                            isValid = false;
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("\tInvalid response...");
                        Wait();
                    }
                    else
                    {
                        int index = Convert.ToInt32(response);
                        if (index > numPathsSaved - 1)
                        {
                            if (debug) Console.WriteLine("Out of index bounds");
                            Console.WriteLine("\tInvalid response...");
                            Wait();
                        }
                        else
                        {
                            bool stopDelete = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"\tPath {index} is {paths[index, 0]} - {paths[index, 1]}");
                                Console.WriteLine("\tWould you like to delete this path? (y/n)");
                                string yN = Console.ReadLine().ToLower();
                                if (yN == "n") return;
                                else if (yN == "y")
                                {
                                    if (debug) Console.WriteLine("Beginning removal process");
                                    Console.WriteLine("\tRemoving saved path...");
                                    string[] tempPaths = new string[numPathsSaved - 1];
                                    for (int a = 0; a < numPathsSaved; a++)
                                    {
                                        if (a < index)
                                        {
                                            tempPaths[a] = paths[a, 0] + "|" + paths[a, 1];
                                            if (debug) Console.WriteLine($"Index {a} added, {tempPaths[a]}");
                                        }
                                        else if (a > index)
                                        {
                                            tempPaths[a - 1] = paths[a, 0] + "|" + paths[a, 1];
                                            if (debug) Console.WriteLine($"Index {a} added, {tempPaths[a - 1]}");
                                        }
                                        else if (debug) Console.WriteLine($"Index {a} skipped, {paths[a, 0]}|{paths[a, 1]}");
                                    }
                                    if (debug)
                                    {
                                        Console.WriteLine("New array created...");
                                        Wait();
                                    }

                                    try
                                    {
                                        if (debug)
                                        {
                                            Console.WriteLine("Starting file writing");
                                            Wait();
                                        }
                                        if (!File.Exists(appDir + "\\savedPaths.txt")) File.Create(appDir + "\\savedPaths.txt");

                                        File.WriteAllLines(appDir + "\\savedPaths.txt", tempPaths);
                                        Console.WriteLine("\tSaved paths updated succesfully...");
                                        Wait();
                                        return;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("\tError - Update unsuccessful...");
                                        Console.WriteLine(ex.Message);
                                        Wait();
                                        return;
                                    }
                                }
                            } while (!stopDelete);
                        }
                    }
                }
            } while (!stopSearch);
        } //Remove a saved directory

        static bool WritePaths()
        {

            UpdateSaves();
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
            {
                if (displayMovedFiles) Console.WriteLine("\tTransferring " + file.Name + "...");
                file.CopyTo(Path.Combine(target.FullName, file.Name));
                if (displayMovedFiles)Console.WriteLine("\t" + file.Name + " transfered...");
            }
        } //Copy each file and folder in the given directory to the second directory

        static void AttemptDupe(bool preset = false)
        {
            string dateTime = "if you see this, there was an error LOL";
            if (!preset)
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
            }
            else
            {
                dateTime = DateTime.Now.ToString("MM.dd.yy-hh.mm.ss");
                if (debug)
                {
                    Console.WriteLine("temp datetime is " + dateTime);
                    Wait();
                }
                saveDir += '\\' + dateTime;
            } //if preset use date&time as folder name

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
                if (preset) Console.WriteLine("\tFolder name is " + dateTime);
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

        static string LoadPath(string currentProcess, bool isPreset = false)
        {

            UpdateSaves();


            bool stopSelect = false;
            do
            {
                Console.Clear();
                DisplaySavedDirs();
                if (!isPreset) Console.WriteLine($"\tEnter the number of the path you would like to {currentProcess}...");
                else Console.WriteLine($"\tEnter the number of the path you would like the preset to {currentProcess}...");
                    Console.WriteLine("\t(enter 'cancel' to go back)");
                string temp = Console.ReadLine();
                if (temp == "cancel") stopSelect = true;
                else
                {
                    bool isValid = true;
                    if (temp == null || temp == " ")
                    {
                        if (debug) Console.WriteLine("Null response...");
                        isValid = false;
                    }
                    foreach (char c in temp)
                    {
                        if (!Char.IsDigit(c))
                        {
                            if (debug) Console.WriteLine("not all digits...");
                            isValid = false;
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("\tInvalid response...");
                        Wait();
                    }
                    else
                    {

                        int index = Convert.ToInt32(temp);

                        if (index > numPathsSaved - 1)
                        {
                            if (debug) Console.WriteLine("Outside of index...");
                            Console.WriteLine("\tInvalid response...");
                            Wait();
                        }
                        else
                        { 
                            bool stopConfirm = false;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\nPath '" + temp + "' is: " + paths[index, 0] + "|" + paths[index, 1]);
                                if (!isPreset) Console.WriteLine("\nWould you like to " + currentProcess + " this directory? (y/n)");
                                else Console.WriteLine("\nWould you like the preset to " + currentProcess + " this directory? (y/n)");
                                string response = Console.ReadLine().ToLower();
                                switch (response)
                                {
                                    case "y":
                                        return paths[index , 1];
                                    case "n":
                                        stopConfirm = true;
                                        break;
                                }
                            } while (!stopConfirm);
                        }
                    }
                }
            } while (!stopSelect);


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

                File.SetAttributes(appDir + @"\savedPaths.txt", FileAttributes.Normal); //ensure not readonly
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
                    Console.WriteLine("Save file not found... Press ENTER to continue...");
                    Console.ReadLine();
                }
                Console.WriteLine("\tNo save file found. Creating save file..."); //create if no file found
                File.Create(appDir + @"\savedPaths.txt");
                Console.WriteLine("\tSave file created...");
                numPathsSaved = 0;
                Wait();
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

        static string CreatePath(string currentProcess, bool isPreset = false)
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
                if (!isPreset) Console.WriteLine("\tEnter the directory you would like to " + currentProcess);
                else Console.WriteLine("\tEnter the directory you would like the preset to " + currentProcess);
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
                            else if (answer == "cancel")
                            {
                                duping = false;
                                return 6;
                            }
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
                            else if (answer == "cancel")
                            {
                                duping = false;
                                return 6;
                            }
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
                        "\t\t1 - Run a preset backup\n" +
                        "\t\t2 - View all saved paths\n" +
                        "\t\t3 - Remove a saved path\n" +
                        "\t\t4 - Save a new path\n" +
                        "\t\t5 - View all saved preset backups\n" +
                        "\t\t6 - Remove a saved preset backup\n" +
                        "\t\t7 - Save a new preset backup\n" +
                        "\t\t8 - Stop program");
                    string toDo = Console.ReadLine();

                    switch (toDo)
                    {
                        case "0": //dupilcate directory
                            duping = true;
                            break;
                        case "1": //run preset backup
                            return 11;
                        case "2": //view all saved directories
                            return 9;
                        case "3": //delete saved directory
                            return 7;
                        case "4": //save new directory
                            return 8;
                        case "5": //view preset backups
                            return 12;
                        case "6": //remove preset backup
                            return 14;
                        case "7": //create new preset backup
                            return 13;
                        case "8": //stop
                            return 10;
                    }
                }
            } while (!stop);

            return 0;
        } //Main menu for the program
    }
}