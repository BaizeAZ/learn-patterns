using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Mouse : Observer
    {
        public string name;

        public Mouse(string _name,ModelBase childModel) : base(childModel)
        {
            this.name = _name;
        }

        public override void Response1()
        {
            Console.WriteLine("Mouse1 run ...");
        }

        public override void Response2()
        {
            Console.WriteLine("Mouse2 run ...");
        }
    }
}
