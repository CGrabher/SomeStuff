using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class MyLinkedList<T>
    {
        private Node<T>? _start = null;

        public MyLinkedList() { }  

        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            if(_start is null) 
            {
                //list is empty - save new node in _start
                _start = newNode;
             
            }
            else
            {
                //list is not empty, save new node in last node's next variable
                Node<T> current = _start;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                //current is now the last node!
                current.Next = newNode;
            }
        }

        public override String ToString()
        {
            var text = "_start";
            var n = _start;
            while (n != null)
            {
                text += "-->(" + n.Value + ")";
                n = n.Next;
            } 
            return text;

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            int count = 0;
            var n = _start;



            while (n != null)
            {
                n = n.Next;
                count++;
            }
            return count;
        }

        private Node<T> GetNodeAt(int index)
        {

            var n = _start;

            for (int i = 0; i < index; i++)
            {
                n = n.Next;
            }
            return n;
        }

        public T Get(int index)
        {
            return GetNodeAt(index).Value;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Swap(int indexA, int indexB)
        {
            Node<T> a = GetNodeAt(indexA);
            Node<T> b = GetNodeAt(indexB);   

            (a.Value, b.Value) = (b.Value, a.Value);
        }
    }
}
