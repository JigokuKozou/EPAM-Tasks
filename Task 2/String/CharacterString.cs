using System;
using System.Globalization;

namespace String
{
    public class CharacterString : IComparable<CharacterString>, IEquatable<CharacterString>
    {
        private char[] _symbols;

        private static CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;

        public int Length => _symbols.Length;

        public char this[int index] => _symbols[index];

        public CharacterString(string symbolsString)
        {
            _symbols = symbolsString.ToCharArray();
        }

        public CharacterString(char symbol, int count)
        {
            _symbols = new char[count];
            for (int i = 0; i < count; i++)
                _symbols[i] = symbol;
        }

        public CharacterString(char[] symbols)
        {
            _symbols = new char[symbols.Length];
            for (int i = 0; i < symbols.Length; i++)
                _symbols[i] = symbols[i];
        }

        public CharacterString Concat(CharacterString other)
        {
            if (other is null)
                return this;

            var symbols = new char[other._symbols.Length + Length];
            for (int i = 0; i < Length; i++)
            {
                symbols[i] = _symbols[i];
            }
            for (int i = 0; i < other.Length; i++)
            {
                symbols[Length + i] = other._symbols[i];
            }

            return new CharacterString(symbols);
        }

        public static CharacterString ToCharacterString(char[] symbols) => new CharacterString(symbols);

        public char[] ToCharArray() => (char[])_symbols.Clone();

        public bool Contains(char value) => FindFirst(value) >= 0;

        /// <summary>
        /// Looks for the index of the value, if no value was found, it will return -1
        /// </summary>
        /// <param name="value">Search value</param>
        /// <returns>Index of value</returns>
        public int FindFirst(char value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_symbols[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public int CompareTo(CharacterString other) => compareInfo.Compare(_symbols, other._symbols, CompareOptions.StringSort);

        public override bool Equals(object obj) => Equals(obj as CharacterString);

        public bool Equals(CharacterString other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(other, this))
                return true;

            if (Length == other.Length)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_symbols[i] != other._symbols[i])
                        return false;
                }
                return true;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 14 + Length.GetHashCode(); 
            foreach (var symbol in _symbols)
            {
                hash = hash * 14 * symbol.GetHashCode();
            }

            return hash;
        }

        public override string ToString() => new string(_symbols);

        public static bool operator ==(CharacterString left, CharacterString right) => left.Equals(right);

        public static bool operator !=(CharacterString left, CharacterString right) => !(left == right);

        public static bool operator >(CharacterString left, CharacterString right) => left.CompareTo(right) == 1;

        public static bool operator <(CharacterString left, CharacterString right) => left.CompareTo(right) == -1;

        public static bool operator >=(CharacterString left, CharacterString right) => left.Equals(right) || left > right;

        public static bool operator <=(CharacterString left, CharacterString right) => left.Equals(right) || left < right;

        public static CharacterString operator +(CharacterString left, CharacterString right) => left.Concat(right);
    }
}
