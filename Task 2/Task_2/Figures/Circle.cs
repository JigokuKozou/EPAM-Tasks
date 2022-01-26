using System;
using System.Drawing;
using System.Text;

namespace Task_1.Figures
{
    public class Circle : Figure
    {
        public Point Center { get; }

        public double Radius { get; }

        public Circle(Point center, double radius)
        {
            Center = center;

            Radius = radius;
        }

        public Circle(int x, int y, double radius): this(new Point(x, y), radius) { }

        public override double Length => Math.PI * Radius * 2.0;

        public override double Area => Radius * Radius * Math.PI;

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Центр в точке: {Center}");
            builder.AppendLine($"Радиус: {Radius}");
            return builder.ToString();
        }

        public override string ToString() => "Круг";
    }
}
