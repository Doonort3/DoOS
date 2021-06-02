
// About (о системе)

namespace doos_cli_re2.Core
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
