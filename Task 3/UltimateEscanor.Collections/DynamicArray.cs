using System.Collections;

namespace UltimateEscanor.Collections
{
    public sealed class DynamicArray<T> : IList<T>
    {
        private T[] _array;

        public DynamicArray() : this(8) { }

        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> elements)
        {
            _array = elements.ToArray();
        }

        public T this[int index]
        {
            get
            {
                if (!IsInRange(Math.Abs(index)))
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (index < 0)
                    return _array[Count + index];
                else
                    return _array[index];
            }

            set
            {
                if (!IsInRange(Math.Abs(index)))
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (index < 0)
                    _array[Count + index] = value;
                else
                    _array[index] = value;
            }
        }

        public int Capacity
        {
            get => _array.Length;
            set
            {
                if (value < Count)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Capacity cannot be less than Count");

                T[] newArray = new T[value];
                Array.Copy(_array, newArray, Count);
                _array = newArray;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (Capacity == Count)
                Capacity *= 2;

            _array[Count++] = item;
        }

        public void AddRange(IEnumerable<T> elements)
        {
            var newElements = elements.ToArray();
            if ((Count + newElements.Length) > Capacity)
            {
                Capacity = Count + newElements.Length;
            }

            Array.Copy(newElements, 0, _array, Count, newElements.Length);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _array[i] = default;
            }
        }

        public bool Contains(T item) => _array.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_array, 0, array, arrayIndex, _array.Length);

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i]?.Equals(item) ?? false)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index), index, "index can't be less than Count");

            if (Capacity == Count)
                Capacity *= 2;

            for (int i = index; i < Count; i++)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = item;
        }

        public bool Remove(T item)
        {
            bool result = Contains(item);
            if (result)
            {
                Count--;
                for (int i = IndexOf(item); i < Count; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }

            return result;
        }

        public void RemoveAt(int index)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index), index, "index can't be less than Count");

            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private bool IsInRange(int index) => 0 <= index && index < Count;
    }
}