using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Fruit
    {
        private int amount;
        private string id;        
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public virtual void print()
        {
            Console.WriteLine("ID:"+ID);
            Console.WriteLine("Amount:"+Amount);
        }
    }
}
