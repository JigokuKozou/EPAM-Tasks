using System.Text;

namespace Task_1.Figures
{
    public class Rectangle : СlosedFigure
    {
        public Point Center { get; }

        public double Width { get; }

        public double Height { get; }

        public Rectangle(Point center, double width, double height)
        {
            Center = center;
            Width = width;
            Height = height;
        }

        public override double Area => Width * Height;

        public override double Perimeter => 2.0 * (Width + Height);

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Точка центра: {Center}");
            builder.AppendLine($"Ширина: {Width}");
            builder.AppendLine($"Высота: {Height}");
            return builder.ToString();
        }

        public override string ToString() => "Прямоугольник";
    }
}
