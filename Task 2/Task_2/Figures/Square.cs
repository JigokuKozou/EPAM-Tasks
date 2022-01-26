using System.Text;

namespace Task_1.Figures
{
    public class Square : СlosedFigure
    {
        public Square(Point center, double sideLength)
        {
            Center = center;
            SideLength = sideLength;
        }

        public Point Center { get; }

        public double SideLength { get; }

        public override double Area => SideLength * SideLength;

        public override double Perimeter => SideLength * 4;

        public override string ToString() => "Квадрат";

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Центр в точке: {Center}");
            builder.AppendLine($"Длинна стороны: {SideLength}");
            return builder.ToString();
        }
    }
}
