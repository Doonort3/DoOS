

namespace Doos_cli.Core
{
    public class CLI_DISK_INFO : CLICommand
    {
        public CLI_DISK_INFO()
        {
            names = new string[3]
            {
                "dinfo", "disk-info", "di"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Disk_info();

            base.Execute(args);
        }
    }
}