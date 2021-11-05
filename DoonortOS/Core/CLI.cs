using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.FileSystem.VFS;
using DoonortOS.Types;
using Console = System.Console;
using Sys = Cosmos.System;

namespace DoonortOS.Core
{
    public static class CLI
        {
            public static ConsoleColor BackColor = ConsoleColor.Black;
            public static ConsoleColor ForeColor = ConsoleColor.White;

            public static string loginAndPass = File.ReadAllText("0:\\SYSTEM\\login.txt"); // Read saved Login and Password from file 
            public static List<CLICommand> Commands = new List<CLICommand>(); // Создание листа с командами
            public static void Initialize()
            {
                try
                {
                    check: 
                    if (File.Exists(@"0:\SYSTEM\login.txt"))
                    {
                        
                        Clear();
                        string loginAndPass = File.ReadAllText(@"0:\SYSTEM\login.txt"); // Read saved Login and Password from file 
                        string[] lp = loginAndPass.Split(' '); // Converting one string with content "login password" to lp
                        login: 
                        WriteLine("Username: ");
                        string loginInput = Console.ReadLine(); // User Input
                        WriteLine($"Password for {loginInput}: ");
                        string passInput = Console.ReadLine(); // User Input

                        if (loginInput == lp[0] && passInput == lp[1]) // If password and login from input is same like in file
                        {
                            Console.WriteLine("YES");
                            WriteLine("Initializing command library...",
                            ConsoleColor.Green); // Инициализация команд!!!!

                            Commands.Add(new CLI_CLEAR());
                            Commands.Add(new CLI_ABOUT());
                            Commands.Add(new CLI_SHUTDOWN());
                            Commands.Add(new CLI_REBOOT());
                            Commands.Add(new CLI_HELP_1());
                            Commands.Add(new CLI_HELP_2());
                            Commands.Add(new CLI_HELP_3());
                            Commands.Add(new CLI_AUTHORS());
                            Commands.Add(new CLI_AUTHORS_2());
                            Commands.Add(new CLI_CTIME());
                            Commands.Add(new CLI_DISK_INFO());
                            Commands.Add(new CLI_LS());
                            Commands.Add(new CLI_LS_A());
                            Commands.Add(new CLI_READ_FILE());
                            Commands.Add(new CLI_EDIT_FILE());
                            Commands.Add(new CLI_CREATE_FILE());
                            Commands.Add(new CLI_CLEAR_FILE());
                            Commands.Add(new CLI_DELETE_FILE());
                            Commands.Add(new CLI_PWD());
                            Commands.Add(new CLI_DELETE_DIRECTORY());
                            Commands.Add(new OKAY());
                            Console.Clear();

                            // if (!PMFAT.Initialize()) { Console.WriteLine("[FATAL ERROR] could not initialize fat driver!"); CLI_lite.InitializeLite(); }
                            Console.Beep(); // Beeeeep
                            WriteLine($"Welcome to DoOS CLI!", ConsoleColor.Blue);
                            WriteLine("Enter 'help-1' to display the first page of commands.");
                            GetInput();
                            // pass
                        }
                        else // If password or login isnt correct
                        {
                            WriteLine("NO\nLet's try again: ", ConsoleColor.Red);
                            goto login;
                        }
                    }
                    else
                    {
                        File.Create(@"0:\SYSTEM\login.txt");
                        WriteLine("Create a user, enter a name and password,\n using the pattern 'Username password', like 'Luftkatze 12345'", ConsoleColor.Yellow);
                        String newLogin = Console.ReadLine();
                        File.WriteAllText(@"0:\SYSTEM\login.txt", newLogin);
                        if (string.IsNullOrEmpty(loginAndPass))
                        {
                            WriteLine("Saved!", ConsoleColor.Green);
                            goto check;
                        }
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
            }

            public static void GetInput() // Получение ввода
            {
                Write("root", ConsoleColor.Blue);
                Write("@", ConsoleColor.DarkGray);
                Write("cli> ", ConsoleColor.White);

                var input = Console.ReadLine();
                var pos = input.Split(' '); // Обработка ввода
                var exec = false;

                for (var i = 0;
                    i < Commands.Count;
                    i++)
                for (var j = 0;
                    j <
                    Commands[i]
                        .names.Length;
                    j++)
                    if (pos[0]
                            .ToLower() ==
                        Commands[i]
                            .names[j])
                    {
                        Commands[i]
                            .Execute(pos);
                        exec = true;
                    }

                if (!exec) // Если команды не существует
                    WriteLine("Incorrect command!",
                        ConsoleColor.Red);

                GetInput(); // Повторный вызов GetInput
            }

        public static void WriteLine(string txt) // Сокращение команды Console.WriteLine(); до WriteLine();
            {
                Console.WriteLine(txt);
            }

            public static void Write(string txt, ConsoleColor fg)
            {
                Console.ForegroundColor = (ConsoleColor)fg;
                Console.Write(txt);
                Console.ForegroundColor = (ConsoleColor)ForeColor;
            }

            public static void WriteLine(string txt,
                ConsoleColor fg)
            {
                Console.ForegroundColor = fg;
                Console.WriteLine(txt);
                Console.ForegroundColor = ForeColor;
            }

            public static void Write(string txt) // Сокращение команды Console.Write(); до Write();
            {
                Console.Write(txt);
            }
        public static void Clear() // Команда Clear
        {
            Console.Clear();
        }

        public static void About() // Команда About
        {
            WriteLine("     _                                _      " +
                      "\r\n    ( )                              (_ )  _ " +
                      "\r\n   _| |   _      _     ___       ___  | | (_)" +
                      "\r\n /'_` | /'_`\\  /'_`\\ /',__)    /'___) | | | |" +
                      "\r\n( (_| |( (_) )( (_) )\\__, \\   ( (___  | | | |" +
                      "\r\n`\\__,_)`\\___/'`\\___/'(____/   `\\____)(___)(_)\n",
                ConsoleColor.Blue);

            Console.WriteLine($"{SystemInfo.OS_NAME_CLI} ver. {SystemInfo.OS_VER}" +
                              $"\nFree Space: {SystemInfo.AVIABLE_SPACE} bytes" +
                              $"\nCurrent time: {SystemInfo.CURRENT_TIME}" +
                              $"\nCreated at: 06.05.2021" +
                              $"\nLatest update: {SystemInfo.LATEST_UPDATE}" +
                              $"\nKernel version: {SystemInfo.KERNEL_VER}" +
                              $"\n\nRAM capacity: ");
            SystemInfo.ShowRAM();
        }

        public static void Shutdown() // Команда Shutdown
        {
            WriteLine("Finishing the job?: Y/n",
                ConsoleColor.Yellow);
            var confirmShutdown = Console.ReadLine();

            switch (confirmShutdown)
            {
                case "y":
                    Console.Beep();
                    Sys.Power.Shutdown();
                    break;
                case "n":
                    WriteLine("Ok",
                        ConsoleColor.Green);
                    break;
                default:
                    Console.Beep();
                    Sys.Power.Shutdown();
                    break;
            }

        }

        public static void Reboot() // Команда Reboot
        {
            WriteLine("Reboot the system?: Y/n",
                ConsoleColor.Yellow);
            var confirmReboot = Console.ReadLine();

            switch (confirmReboot)
            {
                case "y":
                    Console.Beep();
                    Sys.Power.Reboot();
                    break;
                case "n":
                    WriteLine("Ok",
                        ConsoleColor.Green);
                    break;
                default:
                    Console.Beep();
                    Sys.Power.Reboot();
                    break;
            }
        }

        public static void Help_page_1()
        {
            Console.WriteLine("         \n# Information");
            Console.WriteLine("     'authors, creator' -- Project authors.");
            Console.WriteLine("     'about, info, ver' -- About the system.");
            Console.WriteLine("     'time, date' -- Current time and date.");
            Console.WriteLine("         \n# Basic Commands");
            Console.WriteLine("     'clear, cls, clr' -- Clear the console.");
            Console.WriteLine("         \n# Disk");
            Console.WriteLine("     'disk-info, dinfo, di' -- Disk information.");
            Console.WriteLine("\nTo go to another page, type: 'help-2' or 'help3'");
            Console.WriteLine("\nPage 1 of 3");

        }

        public static void Help_page_2()
        {
            Console.WriteLine("         \n# File handling");
            Console.WriteLine("     pwd -- Show current location.");
            Console.WriteLine("     ls -- Files in the directory.");
            Console.WriteLine("     'ls-a, ls-all' -- Full information about the files in the directory.");
            Console.WriteLine("     'remove-directory, rmd, rd' -- Deleting an empty directory.");
            Console.WriteLine("     'read-file, cat, rf' -- Read the contents of the file.");
            Console.WriteLine("     'edit-text, edit, etext' -- Edit the contents of the file,\n" +
                              "     if you entered fewer characters than there are in the file now,\n" +
                              "     the text will be written without clearing the old characters.");
            Console.WriteLine("     'create-file, crf, touch' -- Creating (so far) a txt file.");
            Console.WriteLine("     'cl-file, clf, cf' -- Clear the file created to fix the bug 'edit file'.");
            Console.WriteLine(
                "     'delete-file, rmf, df' -- Deleting the file you selected in the main directory.");
            Console.WriteLine("\nPage 2 of 3");

        }

        public static void Help_page_3()
        {
            Console.WriteLine("         \n#Computer");
            Console.WriteLine("     restart, reboot -- Restart os.");
            Console.WriteLine("     shutdown, power-off -- Shutting down and shutting down.");
            Console.WriteLine("\nPage 3 of 3");
        }

        public static void Authors()
        {
            WriteLine("\n1.   Doonort3 - main coder",
                ConsoleColor.Green);
            Console.WriteLine("=======================================");
            Console.WriteLine("     VK:" +
                              "\n     vk.com/shirakibaka\n");
            Console.WriteLine("     Telegram channel:" +
                              "\n     t.me/doonort_ch\n"); ;
            Console.WriteLine("     GitHub Profile:" +
                              "\n     github.com/Doonort3\n");
            Console.WriteLine("     Discord:" +
                              "\n     doonort#3847\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("\nTo go to another page, type: 'authors-2' or 'creators-2'");
            Console.WriteLine("\nPage 1 of 2");

        }

        public static void Authors_2()
        {
            WriteLine("\n2.   Luftkatze - helper (login)",
                ConsoleColor.Green);
            Console.WriteLine("=======================================");
            Console.WriteLine("     Discord:" +
                              "\n     Luftkatze#2137\n");
            Console.WriteLine("     GitHub Profile:" +
                              "\n     github.com/LuftkatzeBASIC\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("\nTo go to another page, type: 'authors' or 'creators'");
            Console.WriteLine("\nPage 2 of 2");
        }

        public static void CTime()
        {
            Console.WriteLine("Current time: {0}", // github.com/Doonort3
                DateTime.Now);
        }

        // ------------------------------------------------------

        public static void Disk_info()
        {
            var availableSpace = VFSManager.GetAvailableFreeSpace("0:/"); 

            Console.WriteLine("Available Free Space: " + availableSpace + "\n"); // Free space output
            var fsType = VFSManager.GetFileSystemType("0:/"); // Getting the file system '0:/'
            Console.WriteLine("File System Type: " + fsType); // File system type output
        }

        public static void Ls()
        {
            var currentDirectory = Directory.GetCurrentDirectory(); // Getting the current directory
            var directoryList =
                VFSManager.GetDirectoryListing(currentDirectory); // Announcement of the main directory

            foreach (var directoryEntry in directoryList)
                Console.WriteLine(directoryEntry.mName);
        }

        public static void Ls_a()
        {

            var currentDirectory = Directory.GetCurrentDirectory(); // Getting the current directory
            var directoryList =
                VFSManager.GetDirectoryListing(currentDirectory); // Announcement of the main directory (Вторая инициализация - костыль)

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
                    fileStream.Read(content,
                        0,
                        (int)fileStream.Length); // Getting the length of the text
                    Console.WriteLine("File name: " + directoryEntry.mName); // File name output
                    Console.WriteLine("File size: " +
                                      directoryEntry.mSize +
                                      " bit"); // File size output in bytes
                    Console.WriteLine("Content: ");
                    foreach (var b in content) // Getting Content 
                    {
                        var ch = (char)b;
                        Console.Write(ch.ToString()); // Output one letter(char) at a time
                    }
                }

                Console.WriteLine();
            }
        }

        public static void Read_file()
        {
            Console.WriteLine("Which file to read: ");
            var nameReadFile = Console.ReadLine();

            var exist = File.Exists($@"0:\{nameReadFile}"); // Checking the existence of the input file
            if (exist) // If it exists
            {
                var helloFile = VFSManager.GetFile($@"0:\{nameReadFile}"); // Getting the file
                var helloFileStream = helloFile.GetFileStream();

                if (helloFileStream.CanRead) // If the file is read by the system
                {
                    var textToRead = new byte[helloFileStream.Length]; // It was
                    helloFileStream.Read(textToRead,
                        0,
                        (int)helloFileStream.Length);
                    Console.WriteLine(Encoding.Default.GetString(textToRead));
                }
            }
            else if (!exist) // If it does not exist
            {
                WriteLine($"The file named '{nameReadFile}' does not exist!",
                    ConsoleColor.Red);
            }
        }

        public static void Edit_file()
        {
            Console.WriteLine("Which file should I edit: ");
            var nameEditFile = Console.ReadLine();

            var exist = File.Exists($@"0:\{nameEditFile}"); // Does the file exist?
            if (exist) // If there is
            {
                Console.WriteLine("Entry text: ");
                var textEditFile = Console.ReadLine();

                var helloFile = VFSManager.GetFile($@"0:\{nameEditFile}"); // Getting the file
                var helloFileStream = helloFile.GetFileStream();

                if (helloFileStream.CanWrite) // If it records
                {
                    var textToWrite = Encoding.ASCII.GetBytes(textEditFile);
                    helloFileStream.Write(textToWrite,
                        0,
                        textToWrite.Length);
                }
            }
            else if (!exist) // If there is no
            {

                Console.WriteLine($"The file named '{nameEditFile}' does not exist!",
                    ConsoleColor.Red);
            }
        }

        public static void Create_file()
        {
            Console.WriteLine("File name without an extension: ");
            var nameCreateFile = Console.ReadLine();
            VFSManager.CreateFile($@"0:\{nameCreateFile}.txt");

            var checkCreate = File.Exists($@"0:\{nameCreateFile}.txt");
            if (checkCreate)
                WriteLine("File created.",
                    ConsoleColor.DarkGreen);
            else if (!checkCreate)
                WriteLine($"Unknown error\nFile '{nameCreateFile}' was not created",
                    ConsoleColor.Red);
        }

        public static void Clear_file()
        {
            Console.WriteLine("Which file should I clear: ");
            var nameClearFile = Console.ReadLine();
            var exist = File.Exists($@"0:\{nameClearFile}");

            if (exist)
            {
                var helloFile = VFSManager.GetFile($@"0:\{nameClearFile}");
                var helloFileStream = helloFile.GetFileStream();

                if (helloFileStream.CanWrite)
                {
                    var textToWrite = Encoding.ASCII.GetBytes(
                        "                                                                                                                                                              ");
                    helloFileStream.Write(textToWrite,
                        0,
                        textToWrite.Length);
                }
            }
            else if (!exist)
            {
                WriteLine($"The file named '{nameClearFile}' does not exist!",
                    ConsoleColor.Red);
            }
        }

        public static void Delete_file()
        {
            Console.WriteLine("Which file should I delete: ");
            var nameDeleteFile = Console.ReadLine();
            var exist = File.Exists($@"0:\{nameDeleteFile}");
            if (exist)
            {
                File.Delete($@"0:\{nameDeleteFile}");

                var checkDelete = File.Exists($@"0:\{nameDeleteFile}");
                if (!checkDelete)
                    WriteLine("File deleted",
                        ConsoleColor.Green);
                else if (checkDelete)
                    WriteLine($"Unknown error\nfile '{nameDeleteFile}' is not deleted",
                        ConsoleColor.Red);
            }
        }

        public static void Pwd()
        {
            var path = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current directory: {path}");
        }

        public static void Delete_directory()
        {
            Console.WriteLine("Enter the name of the directory to delete: ");
            var nameDeleteDir = Console.ReadLine();
            Directory.Delete($@"0:\{nameDeleteDir}");

            WriteLine($"The directory {nameDeleteDir} was deleted successfully",
                ConsoleColor.Green);
        }

        public static void Okay()
        {
            WriteLine("Ty nashyol paskhalkiu! Sejchas u menya tvoritsya pizdec v zhizni, \nnastupilo leto, no vsyo ravno nel'zya raslabit'sya :(\n no ya derzhus', spasibo tebe za to, chto obratil dolzhnoe vnimanie na moj proekt :3 \n*chmok*", ConsoleColor.Yellow);
        }

        /*public static void Change_directory(string line, string[] args)
        {
            if (args.Length == 1) { PMFAT.CurrentDirectory = @"0:\"; }
            else
            {
                if (line.Length > 3)
                {
                    string path = line.Substring(3, line.Length - 3).ToLower();
                    if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                    path += "\\";

                    if (PMFAT.FolderExists(path))
                    {
                        if (path.StartsWith(PMFAT.CurrentDirectory)) { PMFAT.CurrentDirectory = path; }
                        else if (path.StartsWith(@"0:\")) { PMFAT.CurrentDirectory = path; }
                        else if (!path.StartsWith(PMFAT.CurrentDirectory) && !path.StartsWith(@"0:\"))
                        {
                            if (PMFAT.FolderExists(PMFAT.CurrentDirectory + path)) { PMFAT.CurrentDirectory = PMFAT.CurrentDirectory + path; }
                            else { CLI.WriteLine("Could not locate directory \"" + path + "\"", ConsoleColor.Red); }
                        }
                    }
                    else { CLI.WriteLine("Could not locate directory!", ConsoleColor.Red); }
                }
                else { CLI.WriteLine("Invalid argument! Path expected.", ConsoleColor.Red); }
            }
        }*/
        }
}
