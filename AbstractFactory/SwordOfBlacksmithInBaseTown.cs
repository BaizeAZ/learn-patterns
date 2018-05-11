using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class SwordOfBlacksmithInBaseTown : Sword
    {
        public SwordOfBlacksmithInBaseTown(int attack):base(attack)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("{0}  Attack:{1}", this.GetType(), attack);
        }
        
    }
}
