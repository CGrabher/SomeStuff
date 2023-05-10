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
            if (_start is null)
            {
                //list is empty - save new node in _start
                _start = newNode;
            }
            else
            {
                //list is not empty, save new node in last node's next variable
                Node<T> current = _start;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                //current is now the last node!
                current.Next = newNode;
            }
        }

        public override string ToString()
        {            

            //var a = "Bob";
            //var b = "Sieger";

            //var c = a + " " + b;
            //c = string.Format("{0} {1}", a, b);
            //c = $"{a} {b}";


            var sb = new StringBuilder();
            sb.Append("|");
                       
            var n = _start;
            while (n != null)
            {
                sb.Append("-->(" + n.Value + ")");
                n = n.Next;
            }
            
            return sb.ToString();           
        }

        public void Clear()
        {
           _start = null;
        }

        public bool Contains(T item)
        {
            var n = _start;
            

            while (n != null)
            {
                if (n.Value is null)
                {
                    if (item is null)
                        return true;
                }
                else if (n.Value.Equals(item))
                {
                    return true;
                }
                n = n.Next;
            }
            return false;
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
        public T GetElementAt(int index)
        {
            EnsureIndexInRange(index);
            var node = GetNodeAt(index);
            return node.Value;
        }

        public T Get(int index) => this[index];
        public T this[int index]
        {
            get
            {
                EnsureIndexInRange(index); 
                var node = GetNodeAt(index);
                return node.Value;
            }
            set
            {
                EnsureIndexInRange(index);
                var node = GetNodeAt(index);
                node.Value = value;
            }
        }
        public void Insert(int index, T item)
        {
            EnsureIndexInRange(index);
            var newNode = new Node<T>(item);
            if (index == 0)
            {
                //insert at beginning
                newNode.Next = _start;
                _start = newNode;
            }
            else
            {
                //insert after specified index
                var previousNode = GetNodeAt(index - 1);
                newNode.Next = previousNode.Next;
                previousNode.Next = newNode;
            }
        }

        public void Remove(T item)
        {
            // Fall 1 Element  -  testcase anfang ende

            if (_start is null)
            { 
                return; 
            }
            //start cant be null here

           
            if (_start.Value!.Equals(item))
            {
                //_start = null;

                _start = _start.Next;
                return;
            }
            //we did not find the item in start


            var n = _start;
            while (n.Next != null)
            {
                if (n.Next.Value!.Equals(item))
                {
                    n.Next = n.Next.Next;
                    return;
                }
                n = n.Next;
            }
            
            
        }
        public void RemoveAt(int index)
        {
            //if index 0 extend
            Node<T> n = GetNodeAt(index);
            if(index == 0)
            { 
                _start = n.Next;
                return;
            }
            //we already handled the -1 case "start"

            EnsureIndexInRange(index);
            n = GetNodeAt(index - 1);
            n.Next = n.Next!.Next;
            
        }

        public void Swap(int indexA, int indexB)
        {
            EnsureIndexInRange(indexA);
            EnsureIndexInRange(indexB);

            Node<T> a = GetNodeAt(indexA);
            Node<T> b = GetNodeAt(indexB);

            (a.Value, b.Value) = (b.Value, a.Value);
        }

        //private void EnsureIndexInRange(int index)
        //{
        //    if (index < 0 || index >= Count())
        //        throw new ArgumentOutOfRangeException();
        //}
        private void EnsureIndexInRange(int index)
        {
            int count = Count();
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Index '{index}' is out of range. Must be between 0 and {count - 1}.");
        }


    }
}
