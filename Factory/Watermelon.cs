using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Watermelon:Fruit
    {        
        public Watermelon() { }
        public Watermelon(Watermelon wm)
        {
            Amount = wm.Amount;
            ID = wm.ID;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("create " + this.GetType().Name);
        }
    }
}
