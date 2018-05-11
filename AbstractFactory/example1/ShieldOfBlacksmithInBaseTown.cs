﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class ShieldOfBlacksmithInBaseTown : Shield
    {
        public ShieldOfBlacksmithInBaseTown(int _defence) : base(_defence)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("{0}  Defence:{1}", this.GetType(), defence);
        }
    }
}
