// Time (дата и время)

using DoonortOS.Core;
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_CTIME_LITE : CLICommand
    {
        public CLI_CTIME_LITE()
        {
            names = new string[2]
            {
                "time", "date"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.CTime();

            base.Execute(args);
        }
    }
}