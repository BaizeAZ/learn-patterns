using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public abstract class ModelBase
    {
        public ModelBase() { }

        public delegate void SubEventHandle();
        public event SubEventHandle SubEvent;

        protected void Notify()
        {
            if (SubEvent!=null)
            {
                this.SubEvent();
            }
        }
    }
}
