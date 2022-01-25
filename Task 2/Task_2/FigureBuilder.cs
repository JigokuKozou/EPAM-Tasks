using System;
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
            Point center = GetInputPoint("Введите координаты центра");
            double radius = GetInputDouble("Введите радиус: ");

            return new Circle(center, radius);
        }

        private Ring CreateRing()
        {
            Console.WriteLine("Введите параметры фигуры Кольцо");
            Point center = GetInputPoint("Введите координаты центра");
            double externalRadius = GetInputDouble("Введите внешний радиус: ");
            double internalRadius = GetInputDouble("Введите внутрений радиус: ");

            return new Ring(center, externalRadius, internalRadius);
        }

        private Rectangle CreateRectangle()
        {
            Point location = GetInputPoint("Введите координаты центра");
            double width = GetInputDouble("Введите ширину: ");
            double height = GetInputDouble("Введите высоту: ");

            return new Figures.Rectangle(location, width, height);
        }

        private Square CreateSquare()
        {
            Point location = GetInputPoint("Введите координаты центра");
            double sideLength = GetInputDouble("Введите длину стороны: ");

            return new Square(location, sideLength);
        }

        private Triangle CreateTriangle()
        {
            Point first = GetInputPoint("Введите координаты первой точки");
            Point second = GetInputPoint("Введите координаты второй точки");
            Point third = GetInputPoint("Введите координаты третьей точки");

            return new Triangle(first, second, third);
        }

        private Line CreateLine()
        {
            Point first = GetInputPoint("Введите координаты первой точки");
            Point second = GetInputPoint("Введите координаты второй точки");

            return new Line(first, second);
        }

        public static Point GetInputPoint(string message)
        {
            Console.WriteLine(message);
            int x = GetInputInt("X: ");
            int y = GetInputInt("Y: ");
            return new Point(x, y);
        }

        public static int GetInputInt(string message)
        {
            int x;
            do
            {
                Console.Write(message);
            }
            while (!int.TryParse(Console.ReadLine(), out x));
            return x;
        }

        public static double GetInputDouble(string message)
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
