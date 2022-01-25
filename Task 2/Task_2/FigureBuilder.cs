using System;
using System.Drawing;
using Task_1.Figures;

namespace Task_1
{
    public enum FiguresType
    {
        None,
        Circle,
        Ring,
        Rectangle,
        Square,
        Triangle,
        Line,
    }

    public class FigureBuilder
    {
        public Figure BuildFigure(FiguresType type) =>
            type switch
            {
                FiguresType.Circle => CreateCircle(),
                FiguresType.Ring => CreateRing(),
                FiguresType.Rectangle => CreateRectangle(),
                FiguresType.Square => CreateSquare(),
                FiguresType.Triangle => CreateTriangle(),
                FiguresType.Line => CreateLine(),
                _ => throw new ArgumentException("Unsupported shape type: " + type),
            };

        private Circle CreateCircle()
        {
            Console.WriteLine("Введите параметры фигуры Круг");
            Point center = InputPointRequestUntilItIsCorrect("Введите координаты центра");
            double radius = InputDoubleRequestUntilItIsCorrect("Введите радиус: ");

            return new Circle(center, radius);
        }

        private Ring CreateRing()
        {
            Console.WriteLine("Введите параметры фигуры Кольцо");
            Point center = InputPointRequestUntilItIsCorrect("Введите координаты центра");
            double externalRadius = InputDoubleRequestUntilItIsCorrect("Введите внешний радиус: ");
            double internalRadius = InputDoubleRequestUntilItIsCorrect("Введите внутрений радиус: ");

            return new Ring(center, externalRadius, internalRadius);
        }

        private Figures.Rectangle CreateRectangle()
        {
            Point location = InputPointRequestUntilItIsCorrect("Введите координаты центра");
            double width = InputDoubleRequestUntilItIsCorrect("Введите ширину: ");
            double height = InputDoubleRequestUntilItIsCorrect("Введите высоту: ");

            return new Figures.Rectangle(location, width, height);
        }

        private Square CreateSquare()
        {
            Point location = InputPointRequestUntilItIsCorrect("Введите координаты центра");
            double sideLength = InputDoubleRequestUntilItIsCorrect("Введите длину стороны: ");

            return new Square(location, sideLength);
        }

        private Triangle CreateTriangle()
        {
            Point first = InputPointRequestUntilItIsCorrect("Введите координаты первой точки");
            Point second = InputPointRequestUntilItIsCorrect("Введите координаты второй точки");
            Point third = InputPointRequestUntilItIsCorrect("Введите координаты третьей точки");

            return new Triangle(first, second, third);
        }

        private Line CreateLine()
        {
            Point first = InputPointRequestUntilItIsCorrect("Введите координаты первой точки");
            Point second = InputPointRequestUntilItIsCorrect("Введите координаты второй точки");

            return new Line(first, second);
        }

        public static Point InputPointRequestUntilItIsCorrect(string message)
        {
            Console.WriteLine(message);
            int x = InputIntRequestUntilItIsCorrect("X: ");
            int y = InputIntRequestUntilItIsCorrect("Y: ");
            return new Point(x, y);
        }

        public static int InputIntRequestUntilItIsCorrect(string message)
        {
            int x;
            do
            {
                Console.Write(message);
            }
            while (!int.TryParse(Console.ReadLine(), out x));
            return x;
        }

        public static double InputDoubleRequestUntilItIsCorrect(string message)
        {
            double x;
            do
            {
                Console.Write(message);
            }
            while (!double.TryParse(Console.ReadLine(), out x));
            return x;
        }
    }
}
