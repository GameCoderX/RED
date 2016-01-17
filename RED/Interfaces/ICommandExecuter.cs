using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RED.Interfaces
{
    public interface ICommandExecuter
    {
        void OnCommandEntered(object sender, EventArgs e);
    }
}
