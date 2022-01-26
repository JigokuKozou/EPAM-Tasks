using System.Drawing;

namespace Task_1.Figures
{
    public class Square : Rectangle
    {
        public Square(Point location, double sideLength) : base(location, sideLength, sideLength) { }

        public override string ToString() => "Квадрат";
    }
}
