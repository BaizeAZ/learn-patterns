using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Proxy2 : Subject
    {
        private RealSubject _realSubject;
        public override void Request()
        {
            //use lazy initialization
            if (_realSubject==null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }
    
}
