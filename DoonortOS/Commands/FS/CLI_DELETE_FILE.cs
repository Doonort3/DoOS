
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_DELETE_FILE : CLICommand
    {
        public CLI_DELETE_FILE()
        {
            names = new string[3]
            {
                "rmf", "delete-file", "df"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Delete_file();

            base.Execute(args);
        }
    }
}