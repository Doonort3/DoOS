
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_CREATE_FILE : CLICommand
    {
        public CLI_CREATE_FILE()
        {
            names = new string[3]
            {
                "touch", "crf", "create-file"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Create_file();

            base.Execute(args);
        }
    }
}