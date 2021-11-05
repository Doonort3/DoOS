
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_DELETE_DIRECTORY : CLICommand
    {
        public CLI_DELETE_DIRECTORY()
        {
            names = new string[3]
            {
                "rmd", "remove-directory", "rd"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Delete_directory();

            base.Execute(args);
        }
    }
}