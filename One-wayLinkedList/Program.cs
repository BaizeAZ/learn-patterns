using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_wayLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            OneWayLinkedList<int> LL1 = new OneWayLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                LL1.Append(i);
                Console.Write(LL1.GetElem(i) + "\t");
            }
            Console.WriteLine(LL1.GetLength());
            LL1.Insert(11, 10);
            Console.WriteLine(LL1.GetLength());
            if (LL1.GetLength()==11)
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(LL1.GetElem(i));
                }
            }

            Console.ReadKey();
            
        }
    }    
            
}
