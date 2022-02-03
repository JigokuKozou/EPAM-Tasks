using System.Text;

namespace Task_1.Figures
{
    public abstract class Figure
    {
        public virtual double Area => 0;

        public virtual string GetInfo()
        {
            StringBuilder builder = new();
            builder.AppendLine(ToString());
            builder.AppendLine($"Площадь: {Area}");
            return builder.ToString();
        }
    }
}
