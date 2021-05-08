// Using
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using System;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace doonortOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            // Creating FS
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine(fs.GetVolumes().Count); 

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[ doonort os ] - ok\n");
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Write to output the commands: help\n");
        }

        protected override void Run()
        {
            var currentDirectory = Directory.GetCurrentDirectory(); // Getting the current directory
            var directoryList = VFSManager.GetDirectoryListing(currentDirectory); // Announcement of the main directory

            // Initial line
            char[] charsToTrim = {' '}; // Creating an array with a symbol to remove
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("0:/> "); // Main line
            var input = Console.ReadLine(); // Input
            var inputOk = input.Trim(charsToTrim); // Cleaning the input
            Console.WriteLine(); // Indent

            switch (inputOk == "help" | input == "Help") // The 'help' command
            {
                case true:
                    Console.WriteLine("   > help -- All commands.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("         \n# Information");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("     authors -- Project authors.");
                    Console.WriteLine("     about -- About the system.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("         \n# Basic Commands");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("     'clear' or 'cls' -- Clear the console.");
                    Console.WriteLine("     echo -- Outputs its arguments via the standard output channel.\n" +
                                      "     In other words, it outputs what you wanted.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("         \n# VGA");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("     VGAtest -- Test vga. After that, it will need to be restarted!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("         \n# Disk");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("     disk info -- Disk information.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nPage 1 of 3");
                    a: Console.WriteLine("Enter the` number of the page you want(write '0' to stop): ");
                    var pageNumber = Convert.ToInt32(Console.ReadLine());  // Converting input to int32
                    Console.ForegroundColor = ConsoleColor.Gray;
                    switch (pageNumber)
                    {
                        case 1: // If 'pageNumber' is 1
                            Console.WriteLine("   > help -- All commands.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n# Information");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     authors -- Project authors.");
                            Console.WriteLine("     about -- About the system.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n# Basic Commands");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     'clear' or 'cls' -- Clear the console.");
                            Console.WriteLine("     echo -- Outputs its arguments via the standard output channel.\n" +
                                              "     In other words, it outputs what you wanted.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n# VGA");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     VGAtest -- Test vga. After that, it will need to be restarted!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n# Disk");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     disk info -- Disk information.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nPage 1 of 3");
                            goto a; // Return to input
                        case 2: // If 'pageNumber' is 2
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n# File handling");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     pwd -- Show current location.");
                            Console.WriteLine("     ls -- Files in the directory.");
                            Console.WriteLine("     ls -a -- Full information about the files in the directory.");
                            Console.WriteLine("     mkdir -- Creating a directory.");
                            Console.WriteLine("     rm -- Deleting an empty directory.");
                            Console.WriteLine("     read file -- Read the contents of the file.");
                            Console.WriteLine("     edit file -- Edit the contents of the file,\n" +
                                              "     if you entered fewer characters than there are in the file now,\n" +
                                              "     the text will be written without clearing the old characters.");
                            Console.WriteLine("     create file -- Creating (so far) a txt file.");
                            Console.WriteLine("     clear file -- Clear the file created to fix the bug 'edit file'.");
                            Console.WriteLine("     delete file -- Deleting the file you selected in the main directory.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nPage 2 of 3");
                            goto a; // Return to input
                        case 3: // If 'pageNumber' is 3
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("         \n#Computer");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("     restart -- Restart os.");
                            Console.WriteLine("     shutdown -- Shutting down and shutting down.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nPage 3 of 3");
                            goto a; // Return to input
                    }

                    if (pageNumber == 0) // If 'pageNumber' is 0 (exit)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(); // pass
                    }
                    else // If nothing fits or the condition is violated
                    {   Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Page {pageNumber} does not exist");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    
                    /*Console.WriteLine("         \n# User information");
                    Console.WriteLine("     whoami -- User info.");*/
                    break;

                default:
                {
                    switch (inputOk)
                    {
                        // The 'authors' command
                        case "authors":
                            Console.WriteLine("doonort3\nvk.com/shirakibaka");
                            break;
                        case "echo": // The 'echo' command
                        {
                            Console.WriteLine("Args: ");
                            string echoArgs = Console.ReadLine(); // Entering an argument for 'echo'
                            Console.WriteLine(echoArgs);
                            break;
                        }
                        case "about":
                        {
                            Console.WriteLine("dooos ver. 1.1-b1");
                            break;
                        }
                            default:
                        {
                            if (inputOk == "cls" | input == "clear") // The 'clear' command
                            {
                                Console.Clear(); // Cleaning the Console with the Basic Method
                            }

                            else switch (inputOk)
                            {
                                case "VGAtest": // The 'VGAtest' command
                                {
                                    VGADriverII.Initialize(VGAMode.Pixel320x200DB); // Initializing the display 320 by 200 pixels
                                    VGAGraphics.Clear(VGAColor.Black); // Screen background color
                                    VGAGraphics.DrawString(0, 8, "Test passed.\n", VGAColor.Green, VGAFont.Font8x8);
                                    VGAGraphics.DrawString(0, 24, "Hello World!\nWrite 'restart' for reboot system\nor 'shutdown'",
                                        VGAColor.Orange, VGAFont.Font8x16); // 0, 24 - coordinates, after text, text color orange, font 8 by 16 pixels
                                    VGAGraphics.Display(); // Running the display

                                    string VGAreboot = Console.ReadLine(); // The way to reload
                                    if (VGAreboot == "restart") Sys.Power.Reboot(); // Restarting the computer
                                    else if (VGAreboot == "shutdown") Sys.Power.Shutdown(); // Shutting down the computer
                                    break;
                                }
                                case "disk info": // The 'disk info' command
                                {
                                    var availableSpace = VFSManager.GetAvailableFreeSpace("0:/"); // Getting free space in '0:/' in bytes
                                    Console.WriteLine("Available Free Space: " + availableSpace + "\n"); // Free space output
                                    var fsType = VFSManager.GetFileSystemType("0:/"); // Getting the file system '0:/'
                                    Console.WriteLine("File System Type: " + fsType); // File system type output
                                    break;
                                }
                                case "ls": // The 'ls' command
                                {
                                    foreach (var directoryEntry in directoryList)
                                        Console.WriteLine(directoryEntry.mName);
                                    break;
                                }
                                case "ls -a": // The 'ls -a' command
                                {
                                    foreach (var directoryEntry in directoryList) // Enumerating files from the directory specified in the 'directoryEntry' variable
                                    {
                                        var fileStream = directoryEntry.GetFileStream(); // Getting the file into the 'fileStream' variable
                                        var entryType = directoryEntry.mEntryType; 

                                        if (entryType == DirectoryEntryTypeEnum.File)
                                        {
                                            var content = new byte[fileStream.Length]; // Everything in the file is written to bytes
                                            fileStream.Read(content, 0, (int) fileStream.Length); // Getting the length of the text
                                            Console.WriteLine("File name: " + directoryEntry.mName); // File name output
                                            Console.WriteLine("File size: " + directoryEntry.mSize + " bit"); // File size output in bytes
                                            Console.WriteLine("Content: "); 
                                            foreach (var b in content) // Getting Content 
                                            {
                                                var ch = (char) b; 
                                                Console.Write(ch.ToString()); // Output one letter(char) at a time
                                            }
                                        }
                                        Console.WriteLine();
                                    }

                                    break;
                                }
                                case "read file": // The 'read file' command
                                {
                                    Console.WriteLine("Which file to read: ");
                                    string nameReadFile = Console.ReadLine();

                                    bool exist = File.Exists($@"0:\{nameReadFile}"); // Checking the existence of the input file
                                    if (exist == true) // If it exists
                                    {
                                        var helloFile = VFSManager.GetFile($@"0:\{nameReadFile}"); // Getting the file
                                        var helloFileStream = helloFile.GetFileStream();

                                        if (helloFileStream.CanRead) // If the file is read by the system
                                        {
                                            var textToRead = new byte[helloFileStream.Length]; // It was
                                            helloFileStream.Read(textToRead, 0, (int) helloFileStream.Length);
                                            Console.WriteLine(Encoding.Default.GetString(textToRead));
                                        }
                                    }
                                    else if (exist == false) // If it does not exist
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red; // Error color
                                        Console.WriteLine($"The file named '{nameReadFile}' does not exist!");
                                        Console.ForegroundColor = ConsoleColor.Gray; // Не нравится - пошёл нахуй
                                    }

                                    break;
                                }
                                case "edit file": // The 'edit file' command
                                {
                                    Console.WriteLine("Which file should I edit: ");
                                    string nameEditFile = Console.ReadLine();

                                    var exist = File.Exists($@"0:\{nameEditFile}"); // Does the file exist?
                                    if (exist == true) // If there is
                                    {
                                        Console.WriteLine("Entry text: ");
                                        string textEditFile = Console.ReadLine();

                                        var helloFile = VFSManager.GetFile($@"0:\{nameEditFile}"); // Getting the file
                                        var helloFileStream = helloFile.GetFileStream();

                                        if (helloFileStream.CanWrite) // If it records
                                        {
                                            var textToWrite = Encoding.ASCII.GetBytes(textEditFile); 
                                            helloFileStream.Write(textToWrite, 0, textToWrite.Length);
                                        }
                                    }
                                    else if (exist == false) // If there is no
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"The file named '{nameEditFile}' does not exist!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                                    break;
                                }
                                case "create file": // The 'create file' command
                                {
                                    Console.WriteLine("File name without an extension: ");
                                    string nameCreateFile = Console.ReadLine();
                                    VFSManager.CreateFile($@"0:\{nameCreateFile}.txt");

                                    var checkCreate = File.Exists($@"0:\{nameCreateFile}.txt");
                                    if (checkCreate == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("File created.");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    else if (checkCreate == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Unknown error\nFile '{nameCreateFile}' was not created");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                                    break;
                                }
                                case "clear file": // The 'clear file' command
                                {
                                    Console.WriteLine("Which file should I clear: ");
                                    string nameClearFile = Console.ReadLine();
                                    var exist = File.Exists($@"0:\{nameClearFile}");

                                    if (exist == true)
                                    {
                                        var helloFile = VFSManager.GetFile($@"0:\{nameClearFile}");
                                        var helloFileStream = helloFile.GetFileStream();

                                        if (helloFileStream.CanWrite)
                                        {
                                            var textToWrite = Encoding.ASCII.GetBytes(
                                                "                                                                                                                                                              ");
                                            helloFileStream.Write(textToWrite, 0, textToWrite.Length);
                                        }
                                    }
                                    else if (exist == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"The file named '{nameClearFile}' does not exist!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                                    break;
                                }
                                case "delete file": // The 'delete file' command
                                {
                                    Console.WriteLine("Which file should I delete: ");
                                    string nameDeleteFile = Console.ReadLine();
                                    var exist = File.Exists($@"0:\{nameDeleteFile}");
                                    if (exist == true)
                                    {
                                        File.Delete($@"0:\{nameDeleteFile}");

                                        var checkDelete = File.Exists($@"0:\{nameDeleteFile}");
                                        switch (checkDelete)
                                        {
                                            case false:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("File deleted");
                                                Console.ForegroundColor = ConsoleColor.Gray;

                                                break;

                                            case true:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"Unknown error\nfile '{nameDeleteFile}' is not deleted");
                                                Console.ForegroundColor = ConsoleColor.Gray;

                                                break;
                                        }
                                    }
                                    break;
                                }
                                case "pwd": // The 'pwd' command
                                {
                                    string path = Directory.GetCurrentDirectory();
                                    Console.WriteLine($"Current directory: {path}");

                                    break;
                                }
                                case "mkdir": // The 'mkdir' command
                                {
                                    Console.WriteLine("Enter the name of the directory to create: ");
                                    string nameCreateDir = Console.ReadLine();

                                    System.IO.Directory.CreateDirectory($@"0:\{nameCreateDir}");
                                    Console.WriteLine($"The directory was created successfully at 0:\\{nameCreateDir}");

                                    break;
                                }
                                case "rm": // The 'rm' command
                                {
                                    Console.WriteLine("Enter the name of the directory to delete: ");
                                    string nameDeleteDir = Console.ReadLine();
                                    System.IO.Directory.Delete($@"0:\{nameDeleteDir}");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"The directory {nameDeleteDir} was deleted successfully ");
                                    Console.ForegroundColor = ConsoleColor.Gray;

                                    break;
                                }

                                /*case "whoami": // The 'whoami' command
                                {
                                    Console.WriteLine("UserName: {0}", Environment.UserName);
                                    break;
                                }*/

                                case "restart": // The 'restart' command
                                    Sys.Power.Reboot();
                                    break;
                                case "shutdown": // The 'shutdown' command
                                    Sys.Power.Shutdown();
                                    break;
                                default: // If the command is not found
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Command '{inputOk}' not found!");
                                    Console.ForegroundColor = ConsoleColor.Gray;

                                    break;
                                }

                            break;
                        }
                    }

                    break;
                }
            }
            Console.WriteLine("");
        }
    }
}


