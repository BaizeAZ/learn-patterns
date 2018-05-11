using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command1
{
    public abstract class Command
    {
        protected Reciever reciever;

        public Command(Reciever _reciever)
        {
            reciever = _reciever;
        }

        public abstract void Action();
        
    }
}
