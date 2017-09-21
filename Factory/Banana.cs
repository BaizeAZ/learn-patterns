using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Banana:Fruit
    {        
        public Banana() { }
        public Banana(Banana b)
        {
            Amount = b.Amount;
            ID = b.ID;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("create "+this.GetType().Name);
        }
    }
}
