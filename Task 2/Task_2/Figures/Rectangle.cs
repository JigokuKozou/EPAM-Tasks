using System.Text;

namespace Task_1.Figures
{
    public class Rectangle : Figure
    {
        public Point Location { get; }

        public double Width { get; }

        public double Height { get; }

        public Rectangle(Point location, double width, double height)
        {
            Location = location;
            Width = width;
            Height = height;
        }

        public override double Area => Width * Height;

        public override double Length => 2.0 * (Width + Height);

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Точка расположения: {Location}");
            builder.AppendLine($"Ширина: {Width}");
            builder.AppendLine($"Высота: {Height}");
            return builder.ToString();
        }

        public override string ToString() => "Прямоугольник";
    }
}
