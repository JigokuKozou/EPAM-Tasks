using System;
using String;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int input;
                do
                {
                    Console.WriteLine("Выберите задание для 2.1");
                    Console.WriteLine("1. Custom string");
                    Console.WriteLine("2. Custom paint");
                } while (!int.TryParse(Console.ReadLine(), out input));
                
                Console.Clear();
                Console.WriteLine($"Task 2.1.{input}");
                if (input is 1)
                {
                    RunTask1();
                }
                else if (input is 2)
                {
                    RunTask2();
                }
                Console.Clear();
            } while (true);
        }

        private static void RunTask1() // Демонстрация работы CharacterString
        {
            CharacterString abc = new("ABC");
            CharacterString hello = new("Hello");
            CharacterString world = new(" World!");

            Console.WriteLine($"\"{abc}\" > \"{hello}\": {abc > hello}"); // Сравнение

            Console.WriteLine($"\"{hello}\" + \"{world}\": \"{hello + world}\""); // Конкатенация

            Console.Write($"Input search char in \"{hello}\": ");
            char search = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine($"Index '{search}' in \"{hello}\": {hello.FindFirst(search)}"); // Поиск по символу

            Console.Write("Input any string: ");
            char[] symbols = Console.ReadLine().ToCharArray();
            CharacterString symbolsString = CharacterString.ToCharacterString(symbols); // Конверцтация в/из массива символов
            Console.WriteLine($"CharacterString: {symbolsString}");
            Console.WriteLine($"Back: {symbolsString.ToCharArray()}");
            Console.ReadLine();
        }

        private static void RunTask2() 
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.Start();
        }
    }
}
