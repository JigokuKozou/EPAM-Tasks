using System.Text.RegularExpressions;

namespace SuperString
{
    public static class SuperStringExtensions
    {
        public enum Language
        {
            Mixed,
            Russian,
            English,
            Number,
        }

        public static Language GetLanguage(this string text)
        {
            if (text.ContainsNumbers())
            {
                return text.ContainsNonNumbers() ? Language.Mixed : Language.Number;
            }
            else if (text.ContainsRussian())
            {
                return text.ContainsNonRussian() ? Language.Mixed : Language.Russian;
            }
            else if (text.ContainsEnglish())
            {
                return text.ContainsNonEnglish() ? Language.Mixed : Language.English;
            }
            else return Language.Mixed;
        }

        private static bool ContainsRussian(this string text)
        {
            Regex regex = new Regex("[ЁёА-я]");

            return regex.IsMatch(text);
        }

        private static bool ContainsEnglish(this string text)
        {
            Regex regex = new Regex("[A-Za-z]");

            return regex.IsMatch(text);
        }

        private static bool ContainsNumbers(this string text)
        {
            Regex regex = new Regex("[0-9]");

            return regex.IsMatch(text);
        }

        private static bool ContainsNonRussian(this string text)
        {
            Regex regex = new Regex("[^ЁёА-я]");

            return regex.IsMatch(text);
        }

        private static bool ContainsNonEnglish(this string text)
        {
            Regex regex = new Regex("[^A-Za-z]");

            return regex.IsMatch(text);
        }

        private static bool ContainsNonNumbers(this string text)
        {
            Regex regex = new Regex("[^0-9]");

            return regex.IsMatch(text);
        }
    }
}
