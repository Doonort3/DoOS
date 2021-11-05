
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class OKAY : CLICommand
    {
        public OKAY()
        {
            names = new string[3]
            {
                "hack", "nice", "okay"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Okay();

            base.Execute(args);
        }
    }
}