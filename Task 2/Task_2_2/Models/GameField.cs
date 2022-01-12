using System;
using System.Text;

namespace Task_2_2.Models
{
    public class GameField
    {
        private Room[,] _rooms;

        private string _horizontalLine;

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;

            InitializeRooms();
            InitializeHorizontalLine();
        }

        public int Width { get; }

        public int Height { get; }

        public Room this[int x, int y]
        {
            get => _rooms[x, y];
            set => _rooms[x, y] = value;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine(_horizontalLine);
            for (int y = 0; y < Height; y++)
            {
                builder.Append("| ");
                for (int x = 0; x < Width; x++)
                {
                    builder.Append(_rooms[x, y]);
                    builder.Append(" | ");
                }
                builder.AppendLine(Environment.NewLine + _horizontalLine);
            }
            return builder.ToString();
        }

        private void InitializeRooms()
        {
            _rooms = new Room[Width, Height];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    _rooms[x, y] = new Room();
        }

        private void InitializeHorizontalLine()
        {
            StringBuilder builder = new();
            builder.Append('+');
            for (int i = 0; i < Width; i++)
            {
                builder.Append("---+");
            }
            _horizontalLine = builder.ToString();
        }
    }
}
