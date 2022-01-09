using System.Text;

namespace Task_2_2.Models
{
    public class GameField
    {
        public int Width { get; }

        public int Height { get; }

        private Room[,] _rooms;

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;

            _rooms = new Room[Width, Height];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    _rooms[x, y] = new Room();
        }

        public Room this[int x, int y]
        {
            get => _rooms[x, y];
            set => _rooms[x, y] = value;
        }



        public override string ToString()
        {
            StringBuilder builder = new();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    builder.Append(_rooms[x, y]);
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
