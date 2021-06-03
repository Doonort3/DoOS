
// About (о системе)

namespace Doos_cli.Core
{
    public class CLI_ABOUT_LITE : CLICommand
    {
        public CLI_ABOUT_LITE()
        {
            names = new string[3]
            {
                "about", "info", "ver"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.About();

            base.Execute(args);
        }
    }
}
