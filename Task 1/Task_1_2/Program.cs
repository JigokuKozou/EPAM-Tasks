using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nВыберите номер задания 1 - 10: ");
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
            throw new NotImplementedException();
        }

        public static void RunTask3()
        {
            throw new NotImplementedException();
        }

        public static void RunTask4()
        {
            throw new NotImplementedException();
        }

        public static void RunTask5()
        {
            throw new NotImplementedException();
        }

        public static void RunTask6()
        {
            throw new NotImplementedException();
        }

        public static void RunTask7()
        {
            throw new NotImplementedException();
        }

        public static void RunTask8()
        {
            throw new NotImplementedException();
        }

        public static void RunTask9()
        {
            throw new NotImplementedException();
        }

        public static void RunTask10()
        {
            throw new NotImplementedException();
        }
    }
}