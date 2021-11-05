
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_CLEAR_FILE : CLICommand
    {
        public CLI_CLEAR_FILE()
        {
            names = new string[3]
            {
                "clf", "cl-file", "cf"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Clear_file();

            base.Execute(args);
        }
    }
}