// Clear (очистить консоль)

namespace doos_cli_re2.Core
{
    public class CLI_CLEAR : CLICommand
    {
        public CLI_CLEAR()
        {
            names = new string[3]
            {
                "clear", "cls", "clr"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Clear();

            base.Execute(args);
        }
    }
}
