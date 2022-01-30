namespace UltimateEscanor.Collections
{
    public sealed class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        private class CycledDynamicEnumerator : DynamicEnumerator
        {
            public CycledDynamicEnumerator(T[] array, int length) : base(array, length) { }

            public override bool MoveNext()
            {
                if (_position == -1)
                    throw new InvalidOperationException();

                if (_position >= _length - 1)
                    Reset();

                _position++;

                return true;
            }
        }
    }
}
