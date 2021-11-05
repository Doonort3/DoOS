using System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using DoonortOS.Hardware;
using Console = System.Console;
using Sys = Cosmos.System;

namespace DoonortOS.Core
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            PMFAT.Initialize();
        }

        protected override void Run()
        {
            CheckingDiskFunctionality();
            if (!CheckingDiskFunctionality()) CLI_lite.InitializeLite();
                else if (CheckingDiskFunctionality()) CLI.Initialize();
        }
        public static bool CheckingDiskFunctionality()
        {
            try
            {
                VFSManager.CreateFile(@"0:\loadData.txt");
                File.Delete(@"0:\loadData.txt");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
