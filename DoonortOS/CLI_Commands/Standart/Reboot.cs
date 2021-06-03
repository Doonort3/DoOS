// Reboot (перезагрузка)

namespace Doos_cli.Core
{
    public class CLI_REBOOT : CLICommand
    {
        public CLI_REBOOT()
        {
            names = new string[2]
            {
                "restart", "reboot"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI.Reboot();

            base.Execute(args);
        }
    }
}