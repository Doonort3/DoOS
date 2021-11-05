
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_LS_A : CLICommand
    {
        public CLI_LS_A()
        {
            names = new string[2]
            {
                "ls-a", "ls-all",
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Ls_a();

            base.Execute(args);
        }
    }
}