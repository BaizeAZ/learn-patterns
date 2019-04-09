using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy1 p1 = new Proxy1();
            Console.WriteLine("4 + 2 = " + p1.Add(4, 2));
            Console.WriteLine("4 - 2 = " + p1.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + p1.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + p1.Div(4, 2));

            Proxy2 p2 = new Proxy2();
            p2.Request();
            Console.ReadKey();
        }
    }
        
}
