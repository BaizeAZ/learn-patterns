using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command1
{
    sealed class Invoker
    {
        private Command command;
        
        public Invoker(Command _command)
        {
            command = _command;
        } 

        public void ExecuteCommand()
        {
            command.Action();
        }
    }
}
