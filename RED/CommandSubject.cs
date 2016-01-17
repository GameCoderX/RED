using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RED.Interfaces;

namespace RED
{
    public class CommandSubject : ISubject
    {
        List<ICommandExecuter> observers;

        public CommandSubject()
        {
            this.observers = new List<ICommandExecuter>(5);
        }

        public void Notify(object sender, EventArgs e)
        {
            foreach (ICommandExecuter observer in observers)
            {
                observer.OnCommandEntered(sender,e);
                if ((e as CommandEventArgs).CommandProcessed)
                    break;
            }
        }

        public void AddObserver(ICommandExecuter observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(ICommandExecuter observer)
        {
            this.observers.Remove(observer);
        }
    }
}
