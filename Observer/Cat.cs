using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Cat:ModelBase
    {
        public Cat() { }
        public void Cry()
        {
            Console.WriteLine("Cat cry...");
            this.Notify();
        }
    }
}
