using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Creator
    {
        public abstract Sword CreatSword();
        public abstract Shield CreatShield();
        
    }
}
