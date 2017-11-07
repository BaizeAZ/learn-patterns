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
                Console.Write(LL1.GetElem(i)+"\t");

            }
            Console.ReadKey();
            
        }
    }    
            
}
