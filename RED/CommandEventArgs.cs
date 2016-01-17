using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RED
{
    public class CommandEventArgs : EventArgs
    {
        public string Command { get; set; }
        public List<string> Arguments { get; set; }

        public bool CommandProcessed {get;set;}

        public CommandEventArgs(string command, string[] arguments)
        {
            this.Command = command;
            this.Arguments = arguments.ToList();
            this.CommandProcessed = false;
        }
    }
}
