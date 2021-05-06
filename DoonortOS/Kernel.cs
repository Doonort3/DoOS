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
            var fs = new CosmosVFS();
            VFSManager.RegisterVFS(fs);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[ doonort os ] - ok\n");
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Write to output the commands: help\n");
        }

        protected override void Run()
        {
            var directoryList = VFSManager.GetDirectoryListing("0:/");

            // Initial line
            char[] charsToTrim = {' '};
            Console.Write("0:/> ");
            var input = Console.ReadLine();
            var inputOk = input.Trim(charsToTrim);
            Console.WriteLine();

            switch (inputOk == "help" | input == "Help")
            {
                case true:
                    Console.WriteLine("     help -- All commands,");
                    Console.WriteLine("     authors -- Project authors,");
                    Console.WriteLine("     echo -- outputs its arguments via the standard output channel.\n" +
                                      "     In other words, it outputs what you wanted,");
                    Console.WriteLine("     'clear' or 'cls' -- clear the console,");
                    Console.WriteLine("     VGAtest -- test vga. After that, it will need to be restarted!");
                    Console.WriteLine("     disk info -- disk information,");
                    Console.WriteLine("     ls -- files in the directory,");
                    Console.WriteLine("     ls -a -- full information about the files in the directory,");
                    Console.WriteLine("     read file -- read the contents of the file,");
                    Console.WriteLine("     edit file -- edit the contents of the file,\n" +
                                      "     if you entered fewer characters than there are in the file now,\n" +
                                      "     the text will be written without clearing the old characters,");
                    Console.WriteLine("     create file -- creating (so far) a txt file,");
                    Console.WriteLine("     clear file -- clear the file created to fix the bug 'edit file'");
                    Console.WriteLine("     delete file -- deleting the file you selected in the main directory");
                    Console.WriteLine("     restart -- restart os,");
                    Console.WriteLine("     shutdown -- Shutting down and shutting down.");
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
                            var echoArgs = Console.ReadLine();
                            Console.WriteLine(echoArgs);
                            break;
                        }
                        default:
                        {
                            if (inputOk == "cls" | input == "clear") // The 'clear' command
                            {
                                Console.Clear();
                            }

                            else switch (inputOk)
                            {
                                case "VGAtest": // The 'VGAtest' command
                                {
                                    VGADriverII.Initialize(VGAMode.Pixel320x200DB);
                                    VGAGraphics.Clear(VGAColor.Black);
                                    VGAGraphics.DrawString(0, 8, "Test passed.\n", VGAColor.Green, VGAFont.Font8x8);
                                    VGAGraphics.DrawString(0, 24, "Hello World!\nWrite 'restart' for reboot system\nor 'shutdown'",
                                        VGAColor.Orange, VGAFont.Font8x16);
                                    VGAGraphics.Display();

                                    var VGAreboot = Console.ReadLine();
                                    if (VGAreboot == "restart")
                                        Sys.Power.Reboot();
                                    else if (VGAreboot == "shutdown") Sys.Power.Shutdown();
                                    break;
                                }
                                case "disk info": // The 'disk info' command
                                {
                                    var availableSpace = VFSManager.GetAvailableFreeSpace("0:/");
                                    Console.WriteLine("Available Free Space: " + availableSpace + "\n");
                                    var fsType = VFSManager.GetFileSystemType("0:/");
                                    Console.WriteLine("File System Type: " + fsType);
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
                                    foreach (var directoryEntry in directoryList)
                                    {
                                        var fileStream = directoryEntry.GetFileStream();
                                        var entryType = directoryEntry.mEntryType;

                                        if (entryType == DirectoryEntryTypeEnum.File)
                                        {
                                            var content = new byte[fileStream.Length];
                                            fileStream.Read(content, 0, (int) fileStream.Length);
                                            Console.WriteLine("File name: " + directoryEntry.mName);
                                            Console.WriteLine("File size: " + directoryEntry.mSize + " bit");
                                            Console.WriteLine("Content: ");
                                            foreach (var b in content)
                                            {
                                                var ch = (char) b;
                                                Console.Write(ch.ToString());
                                            }
                                        }
                                        Console.WriteLine();
                                    }

                                    break;
                                }
                                case "read file": // The 'read file' command
                                {
                                    Console.WriteLine("Which file to read: ");
                                    var nameReadFile = Console.ReadLine();

                                    var exist = File.Exists($@"0:\{nameReadFile}");
                                    if (exist == true)
                                    {
                                        var helloFile = VFSManager.GetFile($@"0:\{nameReadFile}");
                                        var helloFileStream = helloFile.GetFileStream();

                                        if (helloFileStream.CanRead)
                                        {
                                            var textToRead = new byte[helloFileStream.Length];
                                            helloFileStream.Read(textToRead, 0, (int) helloFileStream.Length);
                                            Console.WriteLine(Encoding.Default.GetString(textToRead));
                                        }
                                    }
                                    else if (exist == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"The file named '{nameReadFile}' does not exist!");
                                        Console.ResetColor(); // Не нравится - пошёл нахуй
                                    }

                                    break;
                                }
                                case "edit file": // The 'edit file' command
                                {
                                    Console.WriteLine("Which file should I edit: ");
                                    var nameEditFile = Console.ReadLine();

                                    var exist = File.Exists($@"0:\{nameEditFile}");
                                    if (exist == true)
                                    {
                                        Console.WriteLine("Entry text: ");
                                        var textEditFile = Console.ReadLine();

                                        var helloFile = VFSManager.GetFile($@"0:\{nameEditFile}");
                                        var helloFileStream = helloFile.GetFileStream();

                                        if (helloFileStream.CanWrite)
                                        {
                                            var textToWrite = Encoding.ASCII.GetBytes(textEditFile);
                                            helloFileStream.Write(textToWrite, 0, textToWrite.Length);
                                        }
                                    }
                                    else if (exist == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"The file named '{nameEditFile}' does not exist!");
                                        Console.ResetColor();
                                    }

                                    break;
                                }
                                case "create file": // The 'create file' command
                                {
                                    Console.WriteLine("File name without an extension: ");
                                    var nameCreateFile = Console.ReadLine();
                                    VFSManager.CreateFile($@"0:\{nameCreateFile}.txt");

                                    var checkCreate = File.Exists($@"0:\{nameCreateFile}.txt");
                                    if (checkCreate == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("File created.");
                                        Console.ResetColor();
                                    }
                                    else if (checkCreate == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Unknown error\nFile '{nameCreateFile}' was not created");
                                        Console.ResetColor();
                                    }

                                    break;
                                }
                                case "clear file": // The 'clear file' command
                                {
                                    Console.WriteLine("Which file should I clear: ");
                                    var nameClearFile = Console.ReadLine();
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
                                        Console.ResetColor();
                                    }

                                    break;
                                }
                                case "delete file": // The 'delete file' command
                                {
                                    Console.WriteLine("Which file should I delete: ");
                                    var nameDeleteFile = Console.ReadLine();
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
                                                Console.ResetColor();
                                                break;
                                            case true:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"Unknown error\nfile '{nameDeleteFile}' is not deleted");
                                                Console.ResetColor();
                                                break;
                                        }
                                    }

                                    break;
                                }
                                case "restart": // The 'restart' command
                                    Sys.Power.Reboot();
                                    break;
                                case "shutdown": // The 'shutdown' command
                                    Sys.Power.Shutdown();
                                    break;
                                default: // If the command is not found
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Command '{inputOk}' not found!");
                                    Console.ResetColor();
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


