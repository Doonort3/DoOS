// Help 2 (справка, страница 2)

namespace Doos_cli.Core
{
    public class CLI_HELP_2 : CLICommand
    {
        public CLI_HELP_2()
        {
            names = new string[1]
            {
                "help-2"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Help_page_2();

            base.Execute(args);
        }
    }
}