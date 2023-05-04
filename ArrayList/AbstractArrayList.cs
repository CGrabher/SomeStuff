using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public abstract class AbstractArrayList<T>
    {
        public abstract void Add(T item);
        public abstract int Count();
        public abstract T Get(int index);
        public abstract void RemoveAt(int index);
        public abstract bool Contains(T item);
        public abstract void Clear();
        public abstract void Insert(int index, T item);
        public abstract void Remove(T item); 
        public abstract void Swap(int indexA, int indexB);
    }
}
