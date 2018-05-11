using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class SwordOfBlacksmithInForest : Sword
    {
        public SwordOfBlacksmithInForest(int _attack) : base(_attack)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("{0}  Attack:{1}", this.GetType(), attack);
        }
    }
}
