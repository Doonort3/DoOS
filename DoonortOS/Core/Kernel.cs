using System;
using System.Collections.Generic;
using System.Text;
using doos_cli_re2.Core;
using doos_cli_re2.Hardware;
using Sys = Cosmos.System;

namespace doos_cli_re2
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            PMFAT.Initialize();
            CLI.Initialize();
        }

        protected override void Run()
        {
            
        }
    }
}
