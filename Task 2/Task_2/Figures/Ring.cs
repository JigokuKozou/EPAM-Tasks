using System;
using System.Drawing;
using System.Text;

namespace Task_1.Figures
{
    public class Ring : Figure
    {
        private Circle _external;
        private Circle _internal;

        public Ring(Point center, double externalRadius, double internalRadius)
        {
            _external = new Circle(center, externalRadius);
            _internal = new Circle(center, internalRadius);
        }

        public Ring(int x, int y, double externalRadius, double internalRadius) : 
            this(new Point(x, y), externalRadius, internalRadius) { }

        public override double Length => _external.Length + _internal.Length;

        public override double Area => Math.PI * (_external.Radius - _internal.Radius);

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Центр в точке {_internal.Center}");
            builder.AppendLine($"Внешний радиус: {_internal.Radius}");
            builder.AppendLine($"Внутрений радиус: {_external.Radius}");
            return builder.ToString();
        }

        public override string ToString() => "Кольцо";
    }
}
