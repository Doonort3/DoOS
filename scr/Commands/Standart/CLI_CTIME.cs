// Time (дата и время)

using DoonortOS.Core;
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_CTIME : CLICommand
    {
        public CLI_CTIME()
        {
            names = new string[2]
            {
                "time", "date"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.CTime();

            base.Execute(args);
        }
    }
}