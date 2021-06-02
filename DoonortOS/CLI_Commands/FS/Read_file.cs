

namespace doos_cli_re2.Core
{
    public class CLI_READ_FILE : CLICommand
    {
        public CLI_READ_FILE()
        {
            names = new string[3]
            {
                "read-file", "cat", "rf"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Read_file();

            base.Execute(args);
        }
    }
}