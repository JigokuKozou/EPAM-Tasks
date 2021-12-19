using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunTask7();
        }

        #region Task1
        private static void RunTask1()
        {
            Console.WriteLine("Введите стороны прямоугольника");

            Console.Write("a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("b: ");
            int b = int.Parse(Console.ReadLine());

            if (a > 0 && b > 0)
            {
                Console.WriteLine($"Площадь: {CalculateArea(a, b)}");
            }
            else
            {
                Console.WriteLine("Ошибка: стороны треугольника должны быть положительными!");
            }
        }

        private static double CalculateArea(double a, double b) => a * b;
        #endregion

        private static void RunTask2()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', i + 1));
            }
        }

        #region Task3
        private static void RunTask3()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            ShowTriangle(n);
        }

        private static void ShowTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                int numberWhiteSpace = height - i - 1;
                int numberStars = 1 + i * 2;
                string whiteSpaces = new(' ', numberWhiteSpace);
                Console.WriteLine(whiteSpaces + new string('*', numberStars) + whiteSpaces);
            }
        }
        #endregion

        #region Task4
        private static void RunTask4()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            ShowChristmasTree(n);
        }

        private static void ShowChristmasTree(int numberTriangles)
        {
            numberTriangles++; // i = 1 is new year's star

            for (int i = 1; i <= numberTriangles; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int numberWhiteSpaces = numberTriangles - j - 1;
                    int numberStars = 1 + j * 2;
                    string whiteSpaces = new(' ', numberWhiteSpaces);
                    Console.WriteLine(whiteSpaces + new string('*', numberStars) + whiteSpaces);
                }
            }
        }
        #endregion

        #region Task5
        private static void RunTask5()
        {
            int sumForThree = 3 * SumFromOneTo(999 / 3);       // 3 * (1 + 2 + ... + 333)
            int sumForFive= 5 * SumFromOneTo(999 / 5);         // 5 * (1 + 2 + ... + 199)
            // содержат сумму значений кратных 5 и 3 одновременно

            int sumForFifteen = 15 * SumFromOneTo(999 / 15);   // 15 * (1 + 2 + ... + 66)

            int sum = sumForThree + sumForFive - sumForFifteen;

            Console.WriteLine(sum);
        }

        private static int SumFromOneTo(int n)
        {
            int sum = 0;

            for (int i = 1; i < n; i++)
                sum += i;

            return sum;
        }
        #endregion

        #region Task6
        private static void RunTask6()
        {
            string bold = "Bold";
            string italic = "Italic";
            string underline = "Underline";
            var parameters = new Dictionary<string, bool>(3)
            {
                { bold, false },
                { italic, false },
                { underline, false }
            };

            while (true)
            {
                ShowInfo(parameters);
                char inputKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (inputKey)
                {
                    case '1':
                        SwitchValueInKey(parameters, bold);
                        break;
                    case '2':
                        SwitchValueInKey(parameters, italic);
                        break;
                    case '3':
                        SwitchValueInKey(parameters, underline);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowInfo(Dictionary<string, bool> parameters)
        {

            IEnumerable<string> activeParameters = parameters.Where(pair => pair.Value).Select(pair => pair.Key);

            string parametersLine = activeParameters.FirstOrDefault() == null ? "None" : string.Join(", ", activeParameters);

            Console.WriteLine("Параметры надписи: " + parametersLine);
            Console.WriteLine("Введите:");
            Console.WriteLine("\t1: bold");
            Console.WriteLine("\t2: italic");
            Console.WriteLine("\t3: underline");
        }

        private static void SwitchValueInKey(Dictionary<string, bool> parameters, string key)
        {
            parameters[key] = !parameters[key];
        }
        #endregion

        #region Task7
        private static void RunTask7()
        {
            var array = new int[10];
            Randomize(array);
            Show(array);
            Console.WriteLine();
            Sort(array);
            Show(array);
        }

        #region GetRandom
        private static int[] Randomize(int[] array)
        {
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        private static byte[] Randomize(byte[] array)
        {
            new Random().NextBytes(array);

            return array;
        }

        private static short[] Randomize(short[] array)
        {
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (short)random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        private static long[] Randomize(long[] array)
        {
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextInt64(long.MinValue, long.MaxValue);
            }

            return array;
        }

        private static float[] Randomize(float[] array)
        {
            var random = new Random();
            int sign;
            float range = 10000F;
            for (int i = 0; i < array.Length; i++)
            {
                sign = random.Next(2) == 0 ? -1 : 1;
                array[i] = random.NextSingle() * range * sign;
            }

            return array;
        }

        private static double[] Randomize(double[] array)
        {
            var random = new Random();
            int sign;
            double range = 10000.0;
            for (int i = 0; i < array.Length; i++)
            {
                sign = random.Next(2) == 0 ? -1 : 1;
                array[i] = random.NextDouble() * range * sign;
            }

            return array;
        }

        private static decimal[] Randomize(decimal[] array)
        {
            var random = new Random();
            int sign;
            double range = 10000.0;
            for (int i = 0; i < array.Length; i++)
            {
                sign = random.Next(2) == 0 ? -1 : 1;
                array[i] = (decimal)(random.NextDouble() * range * sign);
            }

            return array;
        }
        #endregion

        public static void Sort<T>(T[] items) where T : IComparable
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private static void QuickSort<T>(T[] items, int left, int right) where T : IComparable
        {
            int i, j;
            i = left; j = right;
            IComparable pivot = items[left];

            while (i <= j)
            {
                while (items[i].CompareTo(pivot) < 0 && i.CompareTo(right) < 0)
                {
                    i++;
                }
                while (items[j].CompareTo(pivot) > 0 && j.CompareTo(left) > 0)
                {
                    j--;
                }

                if (i <= j)
                    Swap(ref items[i++], ref items[j--]);

            }

            if (left < j) QuickSort(items, left, j);
            if (i < right) QuickSort(items, i, right);
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        private static void Show<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item + " ");
            }
        }
        #endregion
    }
}