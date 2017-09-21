using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Apple:Fruit
    {       
        public Apple() { }
        public Apple(Apple a)
        {
            Amount = a.Amount;
            ID = a.ID;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("create " + this.GetType().Name);
        }
    }
}
