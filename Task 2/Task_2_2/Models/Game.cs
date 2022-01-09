using System;

namespace Task_2_2.Models
{
    public class Game
    {
        private GameField _field;

        private Player _player;

        public Game() : this(5, 5) { }

        public Game(int height, int width)
        {
            _field = new GameField(height, width);
        }

        public void Start()
        {
            ArrangeObjectsOnField();
            Actions input = Actions.None;
            while (input is not Actions.Exit)
            {
                ShowField();

                input = GetRequestActionInput();
                switch (input)
                {
                    case Actions.None:
                    case Actions.Exit:
                        break;
                    case Actions.MoveUp:
                        break;
                    case Actions.MoveDown:
                        break;
                    case Actions.MoveLeft:
                        break;
                    case Actions.MoveRight:
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void ShowField() =>
            Console.WriteLine(_field);

        private Actions GetRequestActionInput() =>
            Console.ReadKey(intercept: true).Key switch
            {
                ConsoleKey.W or ConsoleKey.UpArrow => Actions.MoveUp,
                ConsoleKey.S or ConsoleKey.DownArrow => Actions.MoveDown,
                ConsoleKey.A or ConsoleKey.LeftArrow => Actions.MoveLeft,
                ConsoleKey.D or ConsoleKey.RightArrow => Actions.MoveRight,
                ConsoleKey.Escape => Actions.Exit,
                _ => Actions.None,
            };

        private void ArrangeObjectsOnField()
        {
            _player = new Player(_field.Height / 2, _field.Width / 2);
            _field[_player.Location.X, _player.Location.X].Creature = _player;
        }
    }
}
