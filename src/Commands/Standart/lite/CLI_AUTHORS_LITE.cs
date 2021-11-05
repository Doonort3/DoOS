

using DoonortOS.Core;
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_AUTHORS_LITE : CLICommand
    {
        public CLI_AUTHORS_LITE()
        {
            names = new string[2]
            {
                "creator", "authors"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Authors();

            base.Execute(args);
        }
    }
}