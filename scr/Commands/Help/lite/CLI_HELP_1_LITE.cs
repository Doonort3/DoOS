// Help 1 (справка, страница 1)

using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_HELP_1_LITE : CLICommand
    {
        public CLI_HELP_1_LITE()
        {
            names = new string[1]
            {
                "help-1"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Help_page_1();

            base.Execute(args);
        }
    }
}