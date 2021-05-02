using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.System.Graphics;

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
            // Initial line
            char[] charsToTrim = { ' ' };
            Console.Write("$ ");
            var input = Console.ReadLine();
            input = input.Trim(charsToTrim);

            // The help command
            if (input == "help" | input == "Help")
            {
                Console.WriteLine("     help -- All comands,");
                Console.WriteLine("     authors -- Project authors,");
                Console.WriteLine("     echo -- outputs its arguments via the standard output channel.\n     In other words, it outputs what you wanted,");
                Console.WriteLine("     'clear' or 'cls' -- clear the console,");
                Console.WriteLine("     VGAtest -- test vga. After that, it will need to be restarted!");
                Console.WriteLine("     restart -- restart os,");
                Console.WriteLine("     shutdown -- Shutting down and shutting down.");
            }

            // The authors command
            if (input == "authors")
            {
                Console.WriteLine("\ndoonort3\nvk.com/shirakibaka");
            }
            // The echo command
            if (input == "echo")
            {
                Console.WriteLine("Args: ");
                var echo_args = Console.ReadLine();
                Console.WriteLine(echo_args);
            }

            // The VGAtest command
            if (input == "VGAtest")
            {
                VGADriverII.Initialize(VGAMode.Pixel320x200DB);
                VGAGraphics.Clear(VGAColor.Black);
                VGAGraphics.DrawString(0, 8, "Test passed.\n", VGAColor.Green, VGAFont.Font8x8);
                VGAGraphics.DrawString(0, 24, "Hello World!\nWrite 'restart' for reboot system\nor 'shutdown'", VGAColor.Orange, VGAFont.Font8x16);
                VGAGraphics.Display();
                a:  var VGAreboot = Console.ReadLine();
                if (VGAreboot == "restart")
                {
                    Cosmos.System.Power.Reboot();
                }
                if (VGAreboot == "shutdown")
                {
                    Cosmos.System.Power.Shutdown();
                }
            }

            // The restart command
            if (input == "restart")
            {
                Cosmos.System.Power.Reboot();
            }

            // The shutdown command
            if (input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }



            Console.WriteLine("");
        }
    }
}

