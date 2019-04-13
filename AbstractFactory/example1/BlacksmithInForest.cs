using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class BlacksmithInForest : Creator,ICreatorMaster
    {
        public Shield CreatMasterShield()
        {
            return new ShieldOfMaster(200);
        }

        public Sword CreatMasterSword()
        {
            return new SwordOfMaster(250);
        }

        public override Shield CreatShield()
        {
            return new ShieldOfBlacksmithInForest(50);
        }

        public override Sword CreatSword()
        {
            return new SwordOfBlacksmithInForest(80);
        }
    }
}
