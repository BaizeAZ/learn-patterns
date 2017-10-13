using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat();
            Mouse mouse1 = new Mouse("mouse1", myCat);
            myCat.Cry();
            Console.ReadKey();
        }
    }
}
