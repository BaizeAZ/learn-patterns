using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.BadExample
{
    public abstract class RemoteControlExample
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void TuneChannel();
    }
}
