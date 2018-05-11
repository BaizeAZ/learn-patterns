using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class ConcreteControl:RemoteControl
    {
        
        public override void SetChannel()
        {
            Console.WriteLine("-------------------");
            base.SetChannel();
            Console.WriteLine("-------------------");
        }
    }
}
