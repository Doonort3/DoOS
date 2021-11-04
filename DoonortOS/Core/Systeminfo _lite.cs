using System;
using Cosmos.Core;

namespace Doos_cli.Core
{
    public static class SystemInfo_lite
    {
        public static string OS_NAME_CLI_LITE = "DOOS CLI LITE";
        public static string OS_VER_LITE = "1.0";
        public static string KERNEL_VER_LITE = "userkit_20200708";

        public static string KERNEL_INFO_LITE = "Some DOS I created on Cosmos OS" +
                                                "\nDoOS is built on Cosmos OS, uses .net, X#, IL2CPU. Created similar to SHELL";

        public static object CURRENT_TIME_LITE = DateTime.Now;
        public static string LATEST_UPDATE_LITE = "03.06.2021";

        // RAM
        public static uint TotalRAM_LITE => CPU.GetAmountOfRAM();

        public static void ShowRAM()
        {
            Console.Write(TotalRAM_LITE + "MB RAM\n");
        }

        // COUNTERS
        public static float cpuUsage = 0;
    }
}