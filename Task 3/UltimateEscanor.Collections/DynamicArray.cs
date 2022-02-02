using System.Collections;

namespace UltimateEscanor.Collections
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        protected T[] _array;

        public DynamicArray() : this(8) { }

        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> elements)
        {
            _array = elements.ToArray();
            Length = _array.Length;
        }

        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) > Length)
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (index < 0)
                    return _array[Length + index];
                else
                    return _array[index];
            }

            set
            {
                if (!IsInRange(Math.Abs(index)))
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (index < 0)
                    _array[Length + index] = value;
                else
                    _array[index] = value;
            }
        }

        public int Capacity
        {
            get => _array.Length;
            set
            {
                if (value < Length)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Capacity cannot be less than Count");

                T[] newArray = new T[value];
                Array.Copy(_array, newArray, Length);
                _array = newArray;
            }
        }

        public int Length { get; private set; }

        public void Add(T item)
        {
            if (Capacity == Length)
                Capacity *= 2;

            _array[Length++] = item;
        }

        public void AddRange(IEnumerable<T> elements)
        {
            var newElements = elements.ToArray();
            if ((Length + newElements.Length) > Capacity)
            {
                Capacity = Length + newElements.Length;
            }

            Array.Copy(newElements, 0, _array, Length, newElements.Length);

            Length += newElements.Length;
        }

        public void Clear()
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = default;
            }
        }

        public bool Contains(T item) => _array.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_array, 0, array, arrayIndex, _array.Length);

        public int IndexOf(T item)
        {
            for (int i = 0; i < Length; i++)
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
                throw new ArgumentOutOfRangeException(nameof(index));

            if (Capacity == Length)
                Capacity *= 2;

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            Length++;
            _array[index] = item;
        }

        public bool Remove(T item)
        {
            bool result = Contains(item);
            if (result)
            {
                RemoveAt(IndexOf(item));
            }

            return result;
        }

        public void RemoveAt(int index)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index));

            Length--;
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        public T[] ToArray()
        {
            var result = new T[Length];
            Array.Copy(_array, 0, result, 0, Length);

            return result;
        }

        public virtual IEnumerator<T> GetEnumerator() => new DynamicEnumerator(_array, Length);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool IsInRange(int index) => 0 <= index && index < Length;

        public object Clone() => new DynamicArray<T>(ToArray());

        protected class DynamicEnumerator : IEnumerator<T>
        {
            protected readonly T[] _array;

            protected readonly int _length;

            protected int _position = -1;

            public DynamicEnumerator(T[] array, int length)
            {
                _array = array;
                _length = length;
            }

            public T Current
            {
                get
                {
                    if (_position < 0 || _position >= _length)
                        throw new InvalidOperationException();

                    return _array[_position];
                }
            }

            object? IEnumerator.Current => Current;

            public void Dispose() { }

            public virtual bool MoveNext()
            {
                bool result = _position < _length - 1;

                if (result)
                    _position++;

                return result;
            }

            public void Reset() => _position = -1;
        }
    }
}