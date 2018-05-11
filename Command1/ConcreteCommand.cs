using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command1
{
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Reciever _reciever) : base(_reciever)
        {

        }

        public override void Action()
        {
            reciever.Run1000Meter();
        }
    }
       
    
}
