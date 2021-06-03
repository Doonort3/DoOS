
// About (о системе)

namespace Doos_cli.Core
{
    public class CLI_ABOUT : CLICommand
    {
        public CLI_ABOUT()
        {
            names = new string[3]
            {
                "about", "info", "ver"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.About();

            base.Execute(args);
        }
    }
}
