

namespace doos_cli_re2.Core
{
    public class CLI_AUTHORS : CLICommand
    {
        public CLI_AUTHORS()
        {
            names = new string[2]
            {
                "creator", "authors"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Authors();

            base.Execute(args);
        }
    }
}