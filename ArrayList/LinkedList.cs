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
        private int _count = 0;

        public int Counter
        {
            get { return _count; }
        }

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
            _start = null;
        }

        public bool Contains(T item)
        {
            var n = _start;

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_start == null)
            {
                return false;
            }

            while (n != null)
            {
                if (n.Value.Equals(item))
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
            EnsureIndexInRange(index);
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
            EnsureIndexInRange(index);
            if (index == 0)
            {
                //insert at beginning
                var newNode = new Node<T>(item);
                newNode.Next = _start;
                _start = newNode;
            }
            else
            {
                //insert after specified index
                var previousNode = GetNodeAt(index - 1);
                var newNode = new Node<T>(item);
                newNode.Next = previousNode.Next;
                previousNode.Next = newNode;
            }
        }

        public void Remove(T item)
        {
            IsStartNull();
            var n = _start;
            while (n.Next != null)
            {
                n = n.Next;
                if(n.Value.Equals(item))
                {
                    n.Next = n.Next.Next;
                    return;
                }
               n = n.Next;
            }
        }

        public void RemoveAt(int index)
        {
           var n = GetNodeAt(index - 1);
            n.Next = n.Next.Next;
        }

        public void Swap(int indexA, int indexB)
        {
            EnsureIndexInRange(indexA);
            EnsureIndexInRange(indexB);

            Node<T> a = GetNodeAt(indexA);
            Node<T> b = GetNodeAt(indexB);

            (a.Value, b.Value) = (b.Value, a.Value);
        }

        private void EnsureIndexInRange(int index)
        {
            if (index < 0 || index >= Count())
                throw new ArgumentOutOfRangeException();
        }
        private void IsStartNull()
        {
            if(_start == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
