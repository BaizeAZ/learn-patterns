using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reciever reciever = new Reciever();
            Command concreteCommand = new ConcreteCommand(reciever);
            Invoker invoker = new Invoker(concreteCommand);

            invoker.ExecuteCommand();

            Console.ReadKey();
        }
    }
}
