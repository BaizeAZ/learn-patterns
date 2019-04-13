using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Shield
    {
        protected int defence;

        public Shield(int _defence)
        {
            defence = _defence;
        }

        public abstract void PrintInfo();
    }

}
