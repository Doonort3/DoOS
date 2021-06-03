using System;
using Doos_cli.Core;
using Doos_cli.Hardware;
using Sys = Cosmos.System;

namespace Doos_cli
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            CLI.Initialize();
            
            
        }

        protected override void Run()
        {
            
        }
        public static void INIT()
        {
            if (!PMFAT.Initialize()) { CLI_lite.InitializeLite(); }
        }
    }
}
