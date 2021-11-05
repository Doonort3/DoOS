// Clear (очистить консоль)

using DoonortOS.Core;
using DoonortOS.Types;

namespace DoonortOS.Core
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
