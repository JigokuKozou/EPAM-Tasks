namespace UltimateEscanor.Collections
{
    public sealed class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicEnumerator(_array, Length);
        }

        private class CycledDynamicEnumerator : DynamicEnumerator
        {
            public CycledDynamicEnumerator(T[] array, int length) : base(array, length) { }

            public override bool MoveNext()
            {
                if (_position >= _length - 1)
                    Reset();

                _position++;

                return true;
            }
        }
    }
}
