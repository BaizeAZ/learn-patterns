using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Sword
    {
        protected int attack;

        public Sword(int _attack)
        {
            attack = _attack;
        }
        
        public abstract void PrintInfo();
    }
}
