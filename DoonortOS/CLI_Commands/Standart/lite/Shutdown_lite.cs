// Shut down (выключение)

namespace Doos_cli.Core
{
    public class CLI_SHUTDOWN_LITE : CLICommand
    {
        public CLI_SHUTDOWN_LITE()
        {
            names = new string[2]
            {
                "power-off", "shutdown"
            };
            completed = false;
        }

        public override void Execute(string[] args)
        {
            CLI_lite.Shutdown();

            base.Execute(args);
        }
    }
}