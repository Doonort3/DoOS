using System;
using System.Collections.Generic;
using System.Text;

namespace doos_cli_re2.Core
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
