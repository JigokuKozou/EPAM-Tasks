using System;
using System.Globalization;

namespace String
{
    public class CharacterString : IComparable<CharacterString>, IEquatable<CharacterString>
    {
        private char[] symbols;

        private static CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;

        public int Length => symbols.Length;

        public CharacterString(string symbolsString)
        {
            symbols = symbolsString.ToCharArray();
        }

        public CharacterString(char symbol, int count)
        {
            symbols = new char[count];
            for (int i = 0; i < count; i++)
                symbols[i] = symbol;
        }

        public int CompareTo(CharacterString other) => compareInfo.Compare(symbols, other.symbols);

        public override bool Equals(object obj) => Equals(obj as CharacterString);

        public bool Equals(CharacterString other)
        {
            if (other is null)
                return false;

            if (Length == other.Length)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (symbols[i] != other.symbols[i])
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
            foreach (var symbol in symbols)
            {
                hash = hash * 14 * symbol.GetHashCode();
            }

            return hash;
        }

        public static bool operator ==(CharacterString left, CharacterString right) => left.Equals(right);

        public static bool operator !=(CharacterString left, CharacterString right) => !(left == right);

        public static bool operator >(CharacterString left, CharacterString right) => left.CompareTo(right) == 1;

        public static bool operator <(CharacterString left, CharacterString right) => left.CompareTo(right) == -1;

        public static bool operator >=(CharacterString left, CharacterString right) => left.Equals(right) || left > right;

        public static bool operator <=(CharacterString left, CharacterString right) => left.Equals(right) || left < right;
    }
}
