using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 桥接模式的目的是将 抽象化 与 实现化 解耦
/// 一般的抽象和实现往往是 继承关系（强关联）
/// 桥接模式把这种关系变为 聚合/包含关系（弱关联）
/// </summary>
namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new ConcreteControl();

            remoteControl.Implementor = new ChangHongTV();

            remoteControl.TurnOn();
            remoteControl.TurnOff();
            remoteControl.SetChannel();

            remoteControl.Implementor = new SumsangTV();

            remoteControl.TurnOn();
            remoteControl.TurnOff();
            remoteControl.SetChannel();

            Console.Read();
        }
    }
}
