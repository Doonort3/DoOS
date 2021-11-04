using System;
using System.Collections.Generic;
using Cosmos.System;
using Console = System.Console;

namespace Doos_cli.Core
{
    public static class CLI_lite
    {
        public static ConsoleColor BackColor = ConsoleColor.Black;
        public static ConsoleColor ForeColor = ConsoleColor.White;

        public static List<CLICommand> Commands = new List<CLICommand>(); // Создание листа с командами

        public static void InitializeLite()
        {
            try
            {
                WriteLine("Initializing command library...", ConsoleColor.Green); // Инициализация команд!!!!
                Commands.Add(new CLI_CLEAR_LITE());
                Commands.Add(new CLI_ABOUT_LITE());
                Commands.Add(new CLI_SHUTDOWN_LITE());
                Commands.Add(new CLI_REBOOT_LITE());
                Commands.Add(new CLI_HELP_1_LITE());
                Commands.Add(new CLI_HELP_2_LITE());
                Commands.Add(new CLI_AUTHORS_LITE());
                Commands.Add(new CLI_CTIME_LITE());
                Console.Clear();
                WriteLine("Welcome to doos CLI LITE!", ConsoleColor.Green);
                WriteLine("Enter 'help-1' to display the first page of commands.");
                WriteLine("This version of doos is abbreviated because no FAT file system disk was found.",
                    ConsoleColor.Yellow);
                WriteLine("Also, cut out commands that require an initialized file system.", ConsoleColor.Yellow);
                GetInput();
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
                Power.Reboot();
                throw;
            }
        }

        private static void GetInput() // Получение ввода
        {
            Write("lite", ConsoleColor.Green);
            Write("@", ConsoleColor.DarkGray);
            Write("cli> ", ConsoleColor.White);

            var input = Console.ReadLine();
            var pos = input.Split(' '); // Обработка ввода
            var exec = false;

            for (var i = 0; i < Commands.Count; i++)
            for (var j = 0; j < Commands[i].names.Length; j++)
                if (pos[0].ToLower() == Commands[i].names[j])
                {
                    Commands[i].Execute(pos);
                    exec = true;
                }

            if (!exec) // Если команды не существует
                WriteLine("Incorrect command!", ConsoleColor.Red);

            GetInput(); // Повторный вызов GetInput
        }

        public static void Clear() // Команда Clear
        {
            Console.Clear();
        }

        public static void About() // Команда About
        {
            WriteLine(
                "     _                           _   _     _   _   _" +
                "\r\n  __| |  ___   ___   ___    __  | | (_)   | | (_) | |_   ___ " +
                "\r\n / _` | / _ \\ / _ \\ (_-<   / _| | | | |   | | | | |  _| / -_)" +
                "\r\n \\__,_| \\___/ \\___/ /__/   \\__| |_| |_|   |_| |_|  \\__| \\___|\r\n", ConsoleColor.Green);
            WriteLine($"{SystemInfo_lite.OS_NAME_CLI_LITE} lite ver. {SystemInfo_lite.OS_VER_LITE}" +
                      $"\nCurrent time: {SystemInfo_lite.CURRENT_TIME_LITE}" + "\nCreated at: 06.05.2021" +
                      $"\nLatest update: {SystemInfo_lite.LATEST_UPDATE_LITE}" +
                      $"\nKernel version: {SystemInfo_lite.KERNEL_VER_LITE}" + "\n\nRAM capacity: ");
            SystemInfo_lite.ShowRAM();
        }

        public static void Help_page_1()
        {
            Console.WriteLine("         \n# Information");
            Console.WriteLine("     'authors, creator' -- Project authors.");
            Console.WriteLine("     'about, info, ver' -- About the system.");
            Console.WriteLine("     'time, date' -- Current time and date.");
            Console.WriteLine("         \n# Basic Commands");
            Console.WriteLine("     'clear, cls, clr' -- Clear the console.");
            Console.WriteLine("\nTo go to another page, type: 'help-2'");
            Console.WriteLine("\nPage 1 of 2");
        }

        public static void Help_page_2()
        {
            Console.WriteLine("         \n#Computer");
            Console.WriteLine("     restart, reboot -- Restart os.");
            Console.WriteLine("     shutdown, power-off -- Shutting down and shutting down.");
            Console.WriteLine("\nPage 2 of 2");
        }

        public static void Authors()
        {
            WriteLine("\n     Doonort3",
                ConsoleColor.Green);
            Console.WriteLine("=======================================");
            Console.WriteLine("     VK:" +
                              "\n     vk.com/shirakibaka\n");
            Console.WriteLine("     VK public:" +
                              "\n     vk.com/doodeb\n");
            Console.WriteLine("     Telegram channel:" +
                              "\n     t.me/doonort_ch\n");
            Console.WriteLine("     Telegram profile:" +
                              "\n     t.me/doonort3");
            Console.WriteLine("=======================================");
        }

        public static void CTime()
        {
            Console.WriteLine("Current time: {0}",
                DateTime.Now);
        }

        public static void Reboot() // Команда Reboot
        {
            WriteLine("Reboot the system?: Y/n", ConsoleColor.Yellow);
            var confirmReboot = Console.ReadLine();
            switch (confirmReboot)
            {
                case "y":
                    Power.Reboot();
                    break;
                case "n":
                    WriteLine("Ok", ConsoleColor.Green);
                    break;
                default:
                    Power.Reboot();
                    break;
            }
        }

        public static void Shutdown() // Команда Shutdown
        {
            WriteLine("Finishing the job?: Y/n", ConsoleColor.Yellow);
            var confirmShutdown = Console.ReadLine();
            switch (confirmShutdown)
            {
                case "y":
                    Power.Shutdown();
                    break;
                case "n":
                    WriteLine("Ok", ConsoleColor.Green);
                    break;
                default:
                    Power.Shutdown();
                    break;
            }
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
        private static void WriteLine(string txt) // Сокращение команды Console.WriteLine(); до WriteLine();
        {
            Console.WriteLine(txt);
        }

        private static void Write(string txt, ConsoleColor fg)
        {
            Console.ForegroundColor = fg;
            Console.Write(txt);
            Console.ForegroundColor = ForeColor;
        }

        private static void WriteLine(string txt,
            ConsoleColor fg)
        {
            Console.ForegroundColor = fg;
            Console.WriteLine(txt);
            Console.ForegroundColor = ForeColor;
        }

        private static void Write(string txt) // Сокращение команды Console.Write(); до Write();
        {
            Console.Write(txt);
        }
    }
}