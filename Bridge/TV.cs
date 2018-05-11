using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// 实现化角色（Implementor）
    /// 给出实现化角色的接口，但不给出具体实现
    /// 重点：这个接口和实现化接口不一定相同，实际上，这两类接口可以非常不一样。
    ///       实现化接口应当只给出底层操作，而抽象化角色应当只给出基于底层操作的更高一层的操作
    /// </summary>
    public abstract class TV
    {
        public abstract void TurnOn();


        public abstract void TurnOff();


        public abstract void TuneChannel();
      
    }
}
