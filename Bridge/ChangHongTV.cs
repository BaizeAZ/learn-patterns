using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class ChangHongTV:TV
    {
        public override void TurnOn()
        {
            Console.WriteLine("长虹电视打开了");
        }
        public override void TurnOff()
        {
            Console.WriteLine("长虹电视关闭了");
        }
        public override void TuneChannel()
        {
            Console.WriteLine("长虹电视换频道了");
        }
    }
}
