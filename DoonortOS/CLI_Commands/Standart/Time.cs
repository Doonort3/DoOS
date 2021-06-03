// Time (дата и время)

namespace Doos_cli.Core
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