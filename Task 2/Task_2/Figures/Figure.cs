using System.Text;

namespace Task_1.Figures
{
    public abstract class Figure
    {
        public virtual double Length => 0;

        public virtual double Area => 0;

        public virtual string GetInfo()
        {
            StringBuilder builder = new();
            builder.AppendLine(ToString());
            builder.AppendLine($"Длина: {Length}");
            builder.AppendLine($"Площадь: {Area}");
            return builder.ToString();
        }
    }
}
