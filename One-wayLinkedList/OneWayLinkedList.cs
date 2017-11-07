using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_wayLinkedList
{
    class OneWayLinkedList<T>:IMyList<T>
    {
        public Node<T> Head { get; set; }
        private int count;
        public OneWayLinkedList()
        {
            count = 0;
            Head = null;
        }

        public int GetLength()
        {
            return count;            
        }

        public void Clear()
        {
            Head = null;
            count = 0;
        }

        public void Insert(T item, int idx)
        {
            Node<T> p = new Node<T>();
            p = Head;
            int i = 0;            
            while (p != null&&i<idx)
            {
                i++;
                p = p.NextNode;
            }
            if (p==null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node<T> nP = new Node<T>(item);
                Node<T> temp = p.NextNode;
                p.NextNode = nP;
                nP.NextNode = temp;
                count++;
            }
            
            
        }

        public bool isEmpty()
        {
            return count == 0 ? true : false;            
        }

        public void Append(T item)
        {
            Node<T> p = new Node<T>();
            Node<T> np = new Node<T>(item);
            if (Head == null)
            {
                Head = np;
            }
            p = Head;
            while (null!=p.NextNode)
            {
                p = p.NextNode;
            }
            p.NextNode = np;
            count++;
        }

        public int Locate(T value)
        {
            if (isEmpty())
                return -1;
            int i = 0;
            Node<T> p = new Node<T>();
            p = Head;
            while (p!=null&&!p.Data.Equals(value))
            {
                i++;
                p = p.NextNode; 
            }
            if (p == null)
            {
                Console.WriteLine("无此值");
                return -1;
            }
            else//p.Data.Equals(value)
            {
                return i;
            }
            throw new NotImplementedException();
        }

        public T Delete(int i)
        {
            Node<T> p = new Node<T>();
            p = Head;
            while (p.NextNode!=null&&!p.NextNode.Data.Equals(GetElem(i)))
            {
                p = p.NextNode;
            }
            if (p.NextNode==null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                count--;
                if (p.NextNode.NextNode!=null)
                {
                    p.NextNode = p.NextNode.NextNode;
                }
                else
                {
                    p.NextNode = null;
                }
                return p.NextNode.Data;
            }                                    
        }
        /// <summary>
        /// 获得链表第i个元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElem(int i)
        {
            Node<T> p = new Node<T>();
            int j = 0;
            p = Head;
            while (p!=null&&j!=i)
            {
                j++;
                p = p.NextNode;
            }
            if (p==null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return p.Data;
            }
        }
    }
}
