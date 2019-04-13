using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creator BlacksmithInBaseTown = new BlacksmithInBaseTown();
            //Creator BlacksmithInForest = new BlacksmithInForest();
            //Sword SwordOfBlacksmithInBaseTown = BlacksmithInBaseTown.CreatSword();
            //Shield ShieldOfBlacksmithInBaseTown = BlacksmithInBaseTown.CreatShield();
            //Sword SwordOfBlacksmithInForest = BlacksmithInForest.CreatSword();
            //Shield ShieldOfBlacksmithInForest = BlacksmithInForest.CreatShield();

            //Sword SwordOfMaster = BlacksmithInForest.CreatSword();

            //SwordOfBlacksmithInBaseTown.PrintInfo();
            //SwordOfBlacksmithInForest.PrintInfo();
            //ShieldOfBlacksmithInBaseTown.PrintInfo();
            //ShieldOfBlacksmithInForest.PrintInfo();
            AbstractFactoryExample2 exp2 = new AbstractFactoryExample2();
            exp2.RunExample2();
            
            Console.Read();

        }
    }
}
