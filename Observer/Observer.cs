using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public abstract class Observer
    {
        public Observer(ModelBase childModel)
        {
            childModel.SubEvent += new ModelBase.SubEventHandle(Response1);
            childModel.SubEvent += new ModelBase.SubEventHandle(Response2);
        }
        public abstract void Response1();
        public abstract void Response2();
    }
}
