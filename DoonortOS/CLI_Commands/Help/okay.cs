// Help 3 (справка, страница 3)

namespace doos_cli_re2.Core
{
    public class OKAY : CLICommand
    {
        public OKAY()
        {
            names = new string[3]
            {
                "hack", "nice", "okay"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Okay();

            base.Execute(args);
        }
    }
}