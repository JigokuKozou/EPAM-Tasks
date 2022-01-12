using System;

namespace Task_2_2.Models
{
    public class Game
    {
        private readonly GameField _field;

        private readonly Player _player;

        public Game() : this(5, 5) { }

        public Game(int height, int width)
        {
            _field = new GameField(height, width);
        }

        public void Start()
        {
            ArrangeObjectsOnField();
            ActionType input = ActionType.None;
            while (input is not ActionType.Exit)
            {
                ShowField();

                input = GetRequestActionInput();
                switch (input)
                {
                    case ActionType.None:
                    case ActionType.Exit:
                        break;
                    case ActionType.MoveUp:
                        break;
                    case ActionType.MoveDown:
                        break;
                    case ActionType.MoveLeft:
                        break;
                    case ActionType.MoveRight:
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void ShowField()
        {
            Console.WriteLine(_field);
        }

        private ActionType GetRequestActionInput() =>
            Console.ReadKey(intercept: true).Key switch
            {
                ConsoleKey.W or ConsoleKey.UpArrow => ActionType.MoveUp,
                ConsoleKey.S or ConsoleKey.DownArrow => ActionType.MoveDown,
                ConsoleKey.A or ConsoleKey.LeftArrow => ActionType.MoveLeft,
                ConsoleKey.D or ConsoleKey.RightArrow => ActionType.MoveRight,
                ConsoleKey.Escape => ActionType.Exit,
                _ => ActionType.None,
            };

        private void ArrangeObjectsOnField()
        {
        }
    }
}
