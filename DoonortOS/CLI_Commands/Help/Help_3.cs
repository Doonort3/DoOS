// Help 3 (справка, страница 3)

namespace Doos_cli.Core
{
    public class CLI_HELP_3 : CLICommand
    {
        public CLI_HELP_3()
        {
            names = new string[1]
            {
                "help-3"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Help_page_3();

            base.Execute(args);
        }
    }
}