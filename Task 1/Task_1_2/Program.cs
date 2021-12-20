using System.Text;

namespace Task_1_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nВыберите номер задания 1 - 4: ");
            int selectedNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nTask 1.2.{selectedNumber} :");
            switch (selectedNumber)
            {
                case 1:
                    RunTask1();
                    break;
                case 2:
                    RunTask2();
                    break;
                case 3:
                    RunTask3();
                    break;
                case 4:
                    RunTask4();
                    break;
                default:
                    return;
            }
        }

        public static void RunTask1()
        {
            Console.Write("ВВОД: ");
            string text = DeletePunctuation(Console.ReadLine());

            long sumOfWordLengths = 0L;
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                sumOfWordLengths += word.Length;
            }

            double averageLength = Math.Round(sumOfWordLengths / (double)words.Length, 1);

            Console.WriteLine("ВЫВОД: " + averageLength);
        }

        private static string DeletePunctuation(string text)
        {
            var builder = new StringBuilder(text);

            for (int i = 0; i < builder.Length; i++)
            {
                if (char.IsPunctuation(builder[i]))
                {
                    builder.Remove(i, 1);
                    i++;
                }
            }

            return builder.ToString();
        }

        public static void RunTask2()
        {
            Console.Write("ВВОД 1: ");
            string text = Console.ReadLine();

            Console.Write("ВВОД 2: ");
            var symbols = Console.ReadLine().ToArray();

            var builder = new StringBuilder(text);
            for (int i = 0; i < builder.Length; i++)
            {
                if (symbols.Contains(builder[i]))
                {
                    builder.Insert(i, builder[i]);
                    i++;
                }
            }

            text = builder.ToString();
            Console.WriteLine("ВЫВОД: " + text);
        }

        public static void RunTask3()
        {
            Console.Write("ВВОД: ");
            string text = DeletePunctuation(Console.ReadLine());

            int wordLowerCase = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Count(word => char.IsLower(word[0]));

            Console.WriteLine("ВЫВОД: " + wordLowerCase);
        }

        public static void RunTask4()
        {
            
            Console.Write("ВВОД: ");
            string text = Console.ReadLine();

            text = CapitalLettersToUpper(text);

            Console.WriteLine("ВЫВОД: " + text);
        }

        private static string CapitalLettersToUpper(string text)
        {
            var punctuationSentenceEndings = new char[] { '.', '?', '!' };
            var builder = new StringBuilder(text);

            if (builder.Length > 0 && char.IsLower(builder[0]))
                builder[0] = char.ToUpper(builder[0]);

            for (int i = 1; i < builder.Length; i++)
            {   
                if (punctuationSentenceEndings.Contains(builder[i]))
                {
                    while (!char.IsLetter(builder[i]))
                    {
                        if (++i == builder.Length)
                            return builder.ToString();
                    }

                    builder[i] = char.ToUpper(builder[i]);
                }
            }

            return builder.ToString();
        }
    }
}