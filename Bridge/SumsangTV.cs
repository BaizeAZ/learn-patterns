using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class SumsangTV:TV
    {
        public override void TurnOn()
        {
            Console.WriteLine("三星电视打开了");
        }
        public override void TurnOff()
        {
            Console.WriteLine("三星电视关闭了");
        }
        public override void TuneChannel()
        {
            Console.WriteLine("三星电视换频道了");
        }
    }
}
