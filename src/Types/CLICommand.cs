
namespace DoonortOS.Types
{
    public abstract class CLICommand
    {
        public string[] names;
        public bool completed;

        public virtual void Execute(string[] args)
        {
            completed = true;
        }
    }
}
