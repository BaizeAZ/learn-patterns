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
            //FruitFactory fac = new FruitFactory();
            Creator appleFac = new AppleFactory();
            Creator bananaFac = new BananaFactory();

            Fruit b = bananaFac.CreateFruitFactory();
            b.Amount = 9;
            b.ID = "1234";
            b.print();

            Console.ReadKey();
        }
    }
}
