
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_EDIT_FILE : CLICommand
    {
        public CLI_EDIT_FILE()
        {
            names = new string[3]
            {
                "edit", "edit-text", "etext"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Edit_file();

            base.Execute(args);
        }
    }
}