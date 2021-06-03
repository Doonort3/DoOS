// Clear (очистить консоль)

namespace Doos_cli.Core
{
    public class CLI_CLEAR_LITE : CLICommand
    {
        public CLI_CLEAR_LITE()
        {
            names = new string[3]
            {
                "clear", "cls", "clr"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Clear();

            base.Execute(args);
        }
    }
}
