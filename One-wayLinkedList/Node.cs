using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_wayLinkedList
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }

        public Node()
        {
            Data = default(T);
            NextNode = null;
        }
        public Node(T data)
        {
            Data = data;
            NextNode = null;
        }
    }
}
