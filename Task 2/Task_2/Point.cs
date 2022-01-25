namespace Task_1
{
    public struct Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Zero => new Point(0, 0);

        public override string ToString() => $"{{ X = {X}, Y = {Y} }}";
    }
}
