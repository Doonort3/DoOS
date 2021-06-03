// Help 1 (справка, страница 1)

namespace Doos_cli.Core
{
    public class CLI_HELP_1 : CLICommand
    {
        public CLI_HELP_1()
        {
            names = new string[1]
            {
                "help-1"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Help_page_1();

            base.Execute(args);
        }
    }
}