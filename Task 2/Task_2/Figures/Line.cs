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

        public double Length => First.GetLength(Second);

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
