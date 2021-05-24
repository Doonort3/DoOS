// Using
using Cosmos.HAL;
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
            try
            {
                var availableSpace = VFSManager.GetAvailableFreeSpace("0:/");
                var currentDirectory = Directory.GetCurrentDirectory(); // Getting the current directory
                var directoryList =
                    VFSManager.GetDirectoryListing(currentDirectory); // Announcement of the main directory

                // Initial line
                char[] charsToTrim = {' '}; // Creating an array with a symbol to remove
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("0:/> "); // Main line
                var input = Console.ReadLine(); // Input
                var inputOk = input.Trim(charsToTrim); // Cleaning the input
                Console.WriteLine(); // Indent

                if (inputOk.StartsWith("help"))
                {
                    if (inputOk == "help")
                    {
                        Console.WriteLine("   > help -- All commands.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("         \n# Information");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("     authors -- Project authors.");
                        Console.WriteLine("     about -- About the system.");
                        Console.WriteLine("     time -- Current time and date.");
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
                        Console.WriteLine("Use 'help' and page number(1,2,3) e.g. 'help 2'.");
                    }
                    else if (inputOk == "help 1")
                    {
                        Console.WriteLine("   > help -- All commands.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("         \n# Information");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("     authors -- Project authors.");
                        Console.WriteLine("     about -- About the system.");
                        Console.WriteLine("     time -- Current time and date.");
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
                        Console.WriteLine("Use 'help' and page number(1,2,3) e.g. 'help 2'.");
                    }
                    else if (inputOk == "help 2")
                    {
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
                        Console.WriteLine(
                            "     delete file -- Deleting the file you selected in the main directory.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nPage 2 of 3");
                    }
                    else if (inputOk == "help 3")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("         \n#Computer");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("     restart -- Restart os.");
                        Console.WriteLine("     shutdown -- Shutting down and shutting down.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nPage 3 of 3");
                    }
                    else if (inputOk == "")
                    {
                        Console.WriteLine("The line is empty");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Page number {inputOk.Remove(0, 5)} not found!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }

                if (inputOk == "clear" || inputOk == "cls")
                {
                    Console.Clear();
                }
                else if (inputOk == "authors")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("     doonort3");
                    Console.WriteLine("=======================================");
                    Console.WriteLine("     VK:\nvk.com/shirakibaka\n");
                    Console.WriteLine("     Telegram channel:\nt.me/doonort_ch\n");
                    Console.WriteLine("     Telegram profile:\nt.me/doonxrt");
                    Console.WriteLine("=======================================");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (inputOk == "about")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(
                        "     _                    \r\n    | |                          dooos ver. 1.3-b2\r\n  __| |  ___    ___   ___     Current time {0}",
                        DateTime.Now);
                    Console.Write(
                        $"     \r\n / _` | / _ \\  / _ \\ / __|    Free Space: {availableSpace} bytes\r\n| (_| || (_) || (_) |\\__ \\    Created at: 06.05.2021\r\n \\__,_| \\___/  \\___/ |___/    Latest update: 08.05.2021\r\n                          \r\n                          ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (inputOk == "time")
                {
                    Console.WriteLine("Current time: {0}", DateTime.Now);
                }
                else if (inputOk == "VGAtest")
                {
                    VGADriverII.Initialize(VGAMode
                        .Pixel320x200DB); // Initializing the display 320 by 200 pixels
                    VGAGraphics.Clear(VGAColor.Black); // Screen background color
                    VGAGraphics.DrawString(0, 8, "Test passed.\n", VGAColor.Green, VGAFont.Font8x8);
                    VGAGraphics.DrawString(0, 24,
                        "Hello World!\nWrite 'restart' for reboot system\nor 'shutdown'", VGAColor.Orange,
                        VGAFont
                            .Font8x16); // 0, 24 - coordinates, after text, text color orange, font 8 by 16 pixels
                    VGAGraphics.Display(); // Running the display

                    string VGAreboot = Console.ReadLine(); // The way to reload
                    if (VGAreboot == "restart")
                        Sys.Power.Reboot(); // Restarting the computer
                    else if (VGAreboot == "shutdown") Sys.Power.Shutdown(); // Shutting down the computer
                }
                else if (inputOk == "disk info")
                {
                    // Getting free space in '0:/' in bytes
                    Console.WriteLine("Available Free Space: " + availableSpace + "\n"); // Free space output
                    var fsType = VFSManager.GetFileSystemType("0:/"); // Getting the file system '0:/'
                    Console.WriteLine("File System Type: " + fsType); // File system type output
                }
                else if (inputOk == "ls")
                {
                    foreach (var directoryEntry in directoryList) Console.WriteLine(directoryEntry.mName);
                }
                else if (inputOk == "ls -a")
                {
                    foreach (var directoryEntry in
                        directoryList) // Enumerating files from the directory specified in the 'directoryEntry' variable
                    {
                        var fileStream =
                            directoryEntry.GetFileStream(); // Getting the file into the 'fileStream' variable
                        var entryType = directoryEntry.mEntryType;

                        if (entryType == DirectoryEntryTypeEnum.File)
                        {
                            var content =
                                new byte[fileStream.Length]; // Everything in the file is written to bytes
                            fileStream.Read(content, 0,
                                (int) fileStream.Length); // Getting the length of the text
                            Console.WriteLine("File name: " + directoryEntry.mName); // File name output
                            Console.WriteLine("File size: " + directoryEntry.mSize +
                                              " bit"); // File size output in bytes
                            Console.WriteLine("Content: ");
                            foreach (var b in content) // Getting Content 
                            {
                                var ch = (char) b;
                                Console.Write(ch.ToString()); // Output one letter(char) at a time
                            }
                        }

                        Console.WriteLine();
                    }
                }
                else if (inputOk == "read file")
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
                }
                else if (inputOk == "edit file")
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
                }
                else if (inputOk == "create file")
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
                }
                else if (inputOk == "clear file")
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
                }
                else if (inputOk == "delete file")
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
                }
                else if (inputOk == "pwd")
                {
                    string path = Directory.GetCurrentDirectory();
                    Console.WriteLine($"Current directory: {path}");
                }
                else if (inputOk == "mkdir")
                {
                    Console.WriteLine("Enter the name of the directory to create: ");
                    string nameCreateDir = Console.ReadLine();

                    System.IO.Directory.CreateDirectory($@"0:\{nameCreateDir}");
                    Console.WriteLine($"The directory was created successfully at 0:\\{nameCreateDir}");
                }
                else if (inputOk == "rm")
                {
                    Console.WriteLine("Enter the name of the directory to delete: ");
                    string nameDeleteDir = Console.ReadLine();
                    System.IO.Directory.Delete($@"0:\{nameDeleteDir}");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The directory {nameDeleteDir} was deleted successfully ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (inputOk == "restart")
                {
                    Sys.Power.Reboot();
                }
                else if (inputOk == "shutdown")
                {
                    Sys.Power.Shutdown();
                }
                else
                {
                    if (inputOk == Convert.ToString(inputOk.StartsWith("help")))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Command '{inputOk}' not found!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }

                if (inputOk == "echo")
                {
                    Console.WriteLine("Use: 'echo text' e.g 'echo Hello, World!'");
                }

                else if (inputOk.StartsWith("echo "))
                {
                    Console.WriteLine(inputOk.Remove(0, 5));
                }
            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("\n========================================================================");
                Console.WriteLine("\nStatus: Kernel panic!                       ");
                Console.WriteLine("\n================================         ");
                Console.WriteLine("  Possible causes:                       ");
                Console.WriteLine("  - An Kernel Error in Doos              ");
                Console.WriteLine("  - FileSystem Error                     ");
                Console.WriteLine("  - Unknown Error                        ");
                Console.WriteLine("================================       ");
                Console.WriteLine($"\nInfo: {e}");
                Console.WriteLine("\n========================================================================");
                Console.WriteLine("\n    Press any key to restart and attempts to correct the error...");
                Console.ReadKey(true);
                Console.WriteLine("\nRestarting...");
                Cosmos.System.Power.Reboot();
                throw;
            }

            Console.WriteLine("");
        }
    }
}



