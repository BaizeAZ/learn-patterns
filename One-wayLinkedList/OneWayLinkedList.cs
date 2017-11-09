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
        
        public OneWayLinkedList()
        {            
            Head = null;
        }
               
        public void Clear()
        {
            Head = null;            
        }

        public void Insert(T item, int idx)
        {
            if (isEmpty())
            {
                Console.WriteLine("链表内数据为空");
                return;
            }
            Node<T> p = new Node<T>();
            Node<T> np = new Node<T>(item);
            p = Head;
            int i = 0;            
            while (p.NextNode != null&&i<idx)
            {
                i++;
                p = p.NextNode;
            }
            if (i == idx)
            {                
                Node<T> temp = p.NextNode;
                p.NextNode = np;
                np.NextNode = temp;
            }
            else
            {
                Console.WriteLine("超出范围");
            }                                                
        }

        public int GetLength()
        {
            Node<T> p = Head;
            int i = 0;
            while (p!=null)
            {
                i++;
                p = p.NextNode;
            }
            return i;
        }

        public bool isEmpty()
        {
            return GetLength() == 0 ? true:false;            
        }

        public void Append(T item)
        {
            Node<T> p = new Node<T>();
            Node<T> np = new Node<T>(item);
            if (Head == null)
            {
                Head = np;                
                return;
            }
            p = Head;
            while (null!=p.NextNode)
            {
                p = p.NextNode;
            }
            p.NextNode = np;            
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
            if (p.Data.Equals(GetElem(i)))
            {
                Head = p.NextNode;     
                return p.Data;
            }
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
            if (isEmpty())
            {
                Console.WriteLine("链表内没有存储数据");
                return default(T);
            }
            Node<T> p = new Node<T>();
            int j = 0;
            p = Head;
            while (p.NextNode!=null&&j<i)
            {
                j++;                                                                  
                p = p.NextNode;
            }
            if (i == j)
            {
                return p.Data;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }
    }
}
