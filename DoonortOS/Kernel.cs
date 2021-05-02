using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace doonortOS
{

    public class Kernel : Sys.Kernel

    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Cosmos booted successfully.");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("doonort os - ok\n"); Console.ResetColor();
            Console.WriteLine("Write to output the commands: help");
        }

        protected override void Run()
        {
            Console.Write("$ ");
            var input = Console.ReadLine();
            if (input == "help" | input == "Help")
            {
                Console.WriteLine("1) help\n All comands.");
                Console.WriteLine("2) authors\n Project authors.");
                Console.WriteLine("3) echo\n outputs its arguments via the standard output channel. In other words, it outputs what you wanted.");
            }
            if (input == "authors")
            {
                Console.WriteLine("\ndoonort3\nvk.com/shirakibaka");
            };

            if (input == "echo")
            {
                Console.WriteLine(Environment.CommandLine);
            }
            Console.WriteLine("");
        }
    }
}

