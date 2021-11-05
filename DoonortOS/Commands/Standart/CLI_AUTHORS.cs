
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_AUTHORS : CLICommand
    {
        public CLI_AUTHORS()
        {
            names = new string[2]
            {
                "creators", "authors"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Authors();

            base.Execute(args);
        }
    }
}