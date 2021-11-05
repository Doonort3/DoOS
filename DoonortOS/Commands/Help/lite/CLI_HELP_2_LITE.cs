// Help 2 (справка, страница 2)

using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_HELP_2_LITE : CLICommand
    {
        public CLI_HELP_2_LITE()
        {
            names = new string[1]
            {
                "help-2"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Help_page_2();

            base.Execute(args);
        }
    }
}