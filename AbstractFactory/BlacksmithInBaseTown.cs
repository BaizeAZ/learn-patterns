using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class BlacksmithInBaseTown : Creator
    {
        public override Shield CreatShield()
        {
            return new ShieldOfBlacksmithInBaseTown(30);
        }

        public override Sword CreatSword()
        {
            return new SwordOfBlacksmithInBaseTown(45);
        }
    }
}
