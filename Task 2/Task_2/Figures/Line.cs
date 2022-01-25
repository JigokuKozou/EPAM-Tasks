using System;
using System.Text;

namespace Task_1.Figures
{
    public class Line : Figure
    {
        public Point First { get; }
        public Point Second { get; }

        public Line(Point first, Point second)
        {
            First = first;
            Second = second;
        }

        public double Length => GetLength(First, Second);

        public static double GetLength(Point first, Point second) => 
            Math.Sqrt(Math.Pow(second.X - first.X, 2) - Math.Pow(second.Y - first.Y, 2));

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Длинна: {Length}");
            builder.AppendLine($"Первая точка: {First}");
            builder.AppendLine($"Вторая точка: {Second}");
            return builder.ToString();
        }

        public override string ToString() => "Линия";
    }
}
