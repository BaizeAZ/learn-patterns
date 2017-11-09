using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_wayLinkedList
{
    interface IMyList<T>
    {        
        void Clear();
        void Insert(T item,int idx);
        bool isEmpty();
        void Append(T item);
        int Locate(T value);
        T Delete(int i);
        T GetElem(int i);//取表元
    }
}
