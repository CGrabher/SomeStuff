namespace ArrayList;

public class MyArrayList<T>
{
    private T[] _data = new T[1000];
    private int _count = 0;

    public void Add(T element)
    {

        if (_count >= _data.Length)
        {
            var dataTwo = new T[_data.Length * 2];
            _data.CopyTo(dataTwo, 0);
            _data = dataTwo;
        }
        _data[_count] = element;
        _count++;
    }

    //public int Count => _count;

   public int Count 
    { 
        get { return _count; }
    }

    public void RemoveAt(int indx)
    {
        EnsureIndexInRange(indx);
        for (int i = indx; i < _count; i++)
        {
            _data[i] = _data[i + 1];
        }
        _count--;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_data[i], element))
            {
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        _data = new T[1000];
        _count = 0;
    }

    public void Insert(int indx, T element)
    {
        EnsureIndexInRange(indx);
        for (int i = _count - 1; i >= indx; i--)
        {
            _data[i + 1] = _data[i];
        }
        _data[indx] = element;
        _count++;
    }

    public void Remove(T element)
    {
        var dataTwo = new T[_data.Length - 1];
        int dataIndex = 0;
        for (int i = 0; i < _count; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(_data[i], element))
            {
                dataTwo[dataIndex] = _data[i];
                dataIndex++;
            }
        }
        _data = dataTwo;
        _count--;
    }

    public void Swap(int indexA, int indexB)
    {
        EnsureIndexInRange(indexA);
        EnsureIndexInRange(indexB);
        (_data[indexA], _data[indexB]) = (_data[indexB], _data[indexA]);
    }

    public T Get(int indx) => this[indx];

    public T this[int index]
    {
        get
        {
            EnsureIndexInRange(index);
            return _data[index];
        }
        set
        {
            EnsureIndexInRange(index);
            _data[index] = value;
        }
    }

    private void EnsureIndexInRange(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException();
    }
}
