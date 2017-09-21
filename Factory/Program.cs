using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitFactory fac = new FruitFactory();
            Banana b = fac.SimpleCreator(FruitType.Banana) as Banana;
            Watermelon w = fac.SimpleCreator(FruitType.Watermelon) as Watermelon;
            b.Amount = 6;
            b.ID = "1212";
            b.print();
            Console.ReadKey();
        }
    }
}
