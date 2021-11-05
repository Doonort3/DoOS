// Reboot (перезагрузка)

using DoonortOS.Core;
using DoonortOS.Types;

namespace DoonortOS.Core
{
    public class CLI_REBOOT_LITE : CLICommand
    {
        public CLI_REBOOT_LITE()
        {
            names = new string[2]
            {
                "restart", "reboot"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Reboot();

            base.Execute(args);
        }
    }
}