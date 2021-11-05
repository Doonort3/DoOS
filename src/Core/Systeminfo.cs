using System;
using Cosmos.System.FileSystem.VFS;

namespace DoonortOS.Core
{
    public static class SystemInfo
    {
        public static string OS_NAME_CLI = "DOOS CLI";
        public static string OS_VER = "1.5-b1";
        public static string KERNEL_VER = "devkit_20200708";

        /*
        public static string KERNEL_INFO = "Some DOS I created on Cosmos OS" +
                                           "\nDoOS is built on Cosmos OS, uses .net, X#, IL2CPU. Created similar to SHELL";
        */

        public static object CURRENT_TIME = DateTime.Now;
        public static string LATEST_UPDATE = "25.05.2021";

        // RAM
        public static uint TotalRAM { get { return Cosmos.Core.CPU.GetAmountOfRAM(); } }
        public static void ShowRAM() { Console.Write(TotalRAM + "MB RAM\n"); }

        // FS
        public static object AVIABLE_SPACE = VFSManager.GetAvailableFreeSpace("0:/");

        // COUNTERS
        public static float cpuUsage = 0;
    }
}
