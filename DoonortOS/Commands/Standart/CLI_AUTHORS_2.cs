
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_AUTHORS_2 : CLICommand
    {
        public CLI_AUTHORS_2()
        {
            names = new string[2]
            {
                "creators-2", "authors-2"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Authors_2();

            base.Execute(args);
        }
    }
}