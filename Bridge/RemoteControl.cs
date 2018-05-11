using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// 抽象化角色（Abstraction）
    /// 主要包括抽象化的内容和保存一个实现化的引用（Implementor）
    /// </summary>
    class RemoteControl
    {
        private TV implementor;

        public TV Implementor
        {
            //get { return implementor; }
            set { implementor = value; }
        }

        //比实现化角色更高一层的操作
        public virtual void TurnOn()
        {
            implementor.TurnOn();
        }
        public virtual void TurnOff()
        {
            implementor.TurnOff();
        }
        public virtual void SetChannel()
        {
            implementor.TuneChannel();
        }
    }
}
