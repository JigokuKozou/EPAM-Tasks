using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nВыберите номер задания 1 - 10: ");
            int selectedNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nTask 1.1.{selectedNumber} :");
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
                case 5:
                    RunTask5();
                    break;
                case 6:
                    RunTask6();
                    break;
                case 7:
                    RunTask7();
                    break;
                case 8:
                    RunTask8();
                    break;
                case 9:
                    RunTask9();
                    break;
                case 10:
                    RunTask10();
                    break;
                default:
                    return;
            }
        }

        #region Task1

        public static void RunTask1()
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

        public static void RunTask2()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', i + 1));
            }
        }

        #region Task3

        public static void RunTask3()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        private static void PrintTriangle(int height)
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

        public static void RunTask4()
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            PrintChristmasTree(n);
        }

        private static void PrintChristmasTree(int numberTriangles)
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

        public static void RunTask5()
        {
            int sumForThree = 3 * SumFromOneTo(999 / 3);       // 3 * (1 + 2 + ... + 333)
            int sumForFive = 5 * SumFromOneTo(999 / 5);         // 5 * (1 + 2 + ... + 199)
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

        public static void RunTask6()
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
                PrintInfo(parameters);
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

        private static void PrintInfo(Dictionary<string, bool> parameters)
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

        public static void RunTask7()
        {
            var array = new int[10];
            Randomize(array);
            Console.WriteLine("Сгенерированный массив:");
            PrintInColumn(array);
            Console.WriteLine("\nОтсортированный массив:");
            Sort(array);
            PrintInColumn(array);
        }

        private static int[] Randomize(int[] array)
        {
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

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

        private static void PrintInColumn<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        #region Task8

        public static void RunTask8()
        {
            int[,,] array = new int[3, 3, 2]
            {
                { { -1, 1 }, { 2, -2 }, { 3, -3 } },
                { { 4, -4 }, { -5, 5 }, { 6, -6 } },
                { { 7, -7 }, { 8, -8 }, { -9, 9 } },
            };

            Print3DArray(array);

            SwitchPositiveToZero(array);

            Console.WriteLine("");
            Print3DArray(array);
        }

        private static void SwitchPositiveToZero(int[,,] array)
        {
            Random random = new Random();
            for (int z = 0; z < array.GetLength(2); z++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    for (int x = 0; x < array.GetLength(0); x++)
                    {
                        array[y, x, z] = array[x, y, z] > 0 ? 0 : array[x, y, z];
                    }
                }
            }
        }

        private static void Print3DArray(int[,,] array)
        {
            for (int z = 0; z < array.GetLength(2); z++)
            {
                Console.WriteLine($"Z: {z + 1}");
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    for (int x = 0; x < array.GetLength(0); x++)
                    {
                        Console.Write(array[y, x, z] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine('\n');
            }
        }

        #endregion

        #region Task9

        public static void RunTask9()
        {
            int[] array = new[] { 1, -2, -3, 4, 5, -6, 7, 8, -9 };
            Console.WriteLine("Массив:");
            PrintLine(array);
            Console.WriteLine($"Сумма не отрицательных элементов: {SumNonNegative(array)}");
        }

        private static int SumNonNegative(IEnumerable<int> collection)
        {
            int result = 0;
            foreach (var item in collection)
            {
                if (item > 0)
                    result += item;
            }
            return result;
        }

        private static void PrintLine<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        #endregion

        #region Task10

        public static void RunTask10()
        {
            int[,] array = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Print(array);

            int sum = StaggeredSummation(array);

            Console.WriteLine($"Сумма чётных элементов: {sum}");
        }

        private static int StaggeredSummation(int[,] array)
        {
            int result = 0;
            int offset = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0 + offset; j < array.GetLength(1); j += 2)
                {
                    result += array[i, j];
                }
                offset = (i + 1) % 2;
            }

            return result;
        }

        private static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}