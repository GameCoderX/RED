using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RED.Interfaces
{
    public interface ISubject
    {
        void Notify(object sender, EventArgs e);

        void AddObserver(ICommandExecuter observer);
        void RemoveObserver(ICommandExecuter observer);
    }
}
