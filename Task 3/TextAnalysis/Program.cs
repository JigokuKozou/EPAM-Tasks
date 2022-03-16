namespace TextAnalysis
{
    public class Program
    {
        private static TextAnalyzer _analyzer = new();

        public static void Main(string[] args)
        {
            Actions input = Actions.None;
            while (input is not Actions.Exit)
            {
                Console.Clear();
                input = GetInputAction();

                switch (input)
                {
                    case Actions.None:
                    case Actions.Exit:
                        break;
                    case Actions.AnalyzeText:
                        Console.Write("Введите текст: ");
                        _analyzer.Analyse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(_analyzer.Verdict);
                        PrintWordsStatistic();

                        Console.ReadKey();
                        break;
                    case Actions.ChangeMinimumWordLength:
                        TryChangeMinimumWordLength();
                        break;
                    case Actions.ChangeMinimumNumberRepetitions:
                        TryChangeMinimumNumberRepetitions();
                        break;
                    case Actions.ChangeMaximumNumberRepetitions:
                        TryChangeMaximumNumberRepetitions();
                        break;
                    default:
                        throw new NotImplementedException("Not supported Actions type: " + input);
                }
            }
        }

        private static void TryChangeMaximumNumberRepetitions()
        {
            Console.Write("Введите максимальное число повторений: ");
            if (TryInputNonNegativeInt("Максимальное число повторений успешно изменено",
                "Не удалось изменить максимальное число повторений", out int maximumNumberRepetitions))
            {
                _analyzer.MaximumNumberRepetitions = maximumNumberRepetitions;
            }
        }

        private static void TryChangeMinimumNumberRepetitions()
        {
            Console.Write("Введите минимальное число повторений: ");
            if (TryInputNonNegativeInt("Минимальное число повторений успешно изменено",
                "Не удалось изменить минимальное число повторений", out int minimumNumberRepetitions))
            {
                _analyzer.MinimumNumberRepetitions = minimumNumberRepetitions;
            }
        }

        private static void TryChangeMinimumWordLength()
        {
            Console.Write("Введите минимальную длинну слова: ");
            if (TryInputNonNegativeInt("Минимальная длинна слова успешно изменена",
                "Не удалось изменить минимальную длинну слова", out int minimumWordLength))
            {
                _analyzer.MinimumWordLength = minimumWordLength;
            }
        }

        private static bool TryInputNonNegativeInt(string successMessage, string failureMessage, out int result)
        {
            if (int.TryParse(Console.ReadLine(), out result) &&
                                        result >= 0)
            {
                Console.WriteLine(successMessage);
                return true;
            }
            else
            {
                Console.WriteLine(failureMessage);
                return false;
            }
        }

        public static Actions GetInputAction()
        {
            Actions result;
            do
            {
                PrintRequest();
            } while (!TryParse(Console.ReadLine(), out result));

            return result;
        }

        public static void PrintWordsStatistic()
        {
            Console.WriteLine("Статистика повторений по словам");
            foreach (var pair in _analyzer.GetWordsStatistic())
            {
                Console.WriteLine(string.Format("{0} - {1}", pair.Key, pair.Value));
            }
        }

        private static void PrintRequest()
        {
            string request =
                "Выберите действие:" + Environment.NewLine +
                "1. Анализировать текст" + Environment.NewLine +
                "2. Изменить минимальную длину слов" + Environment.NewLine +
                "3. Изменить минимальное число повторов" + Environment.NewLine +
                "4. Изменить максимальное число повторов" + Environment.NewLine +
                "5. Выход";

            Console.WriteLine(request);
        }

        public static bool TryParse(string? numberLine, out Actions result)
        {
            if (int.TryParse(numberLine, out int number))
                return TryParse(number - 1, out result);

            result = Actions.None;
            return false;
        }

        public static bool TryParse(int number, out Actions result)
        {
            if (Enum.IsDefined(typeof(Actions), number))
            {
                result = ToEnum(number);
                return true;
            }

            result = Actions.None;
            return false;
        }

        public static Actions ToEnum(int number)
        {
            var result = Enum.ToObject(typeof(Actions), number);
            if (result is not null)
                return (Actions)result;

            return Actions.None;
        }
    }
}



