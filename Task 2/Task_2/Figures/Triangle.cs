using System;
using System.Drawing;
using System.Text;

namespace Task_1.Figures
{
    public class Triangle : Figure
    {
        public Point First { get; }

        public Point Second { get; }

        public Point Third { get; }

        public Triangle(Point first, Point second, Point third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public override double Length => 
            Line.GetLength(First, Second) + Line.GetLength(Second, Third) + Line.GetLength(Third, First);

        public override double Area => 
            Math.Abs((Second.X - First.X)*(Third.Y - First.Y) - (Third.X - First.X)*(Second.Y - First.Y)) / 2.0;

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Первая точка: {First}");
            builder.AppendLine($"Вторая точка: {Second}");
            builder.AppendLine($"Третья точка: {Third}");
            return builder.ToString();
        }

        public override string ToString() => "Треугольник";
    }
}
