using System;
using System.Drawing;
using Task_2_2.Interfaces;
using Task_2_2.Models.Creatures;
using Task_2_2.Models.Items;
using Task_2_2.Models.Obstacles;
using Task_2_2.Models.Enums;

namespace Task_2_2.Models
{
    public class Game
    {
        private readonly GameField _field;

        private Player _player;

        private ConsoleUI _UI;

        private EnemyAI _enemyAI;

        public Game() : this(5, 5) { }

        public Game(int height, int width)
        {
            _field = new GameField(height, width);
            _enemyAI = new EnemyAI(_field);
        }

        public void Start()
        {
            ArrangeObjectsOnField();
            _UI = new ConsoleUI(_field, _player);

            ActionType input = ActionType.None;
            while (input is not ActionType.Exit)
            {
                Update();
                input = GetRequestActionInput();
                switch (input)
                {
                    case ActionType.None:
                    case ActionType.Exit:
                        break;
                    case ActionType.MoveUp:
                        TryPlayerMove(Direction.Up);
                        break;
                    case ActionType.MoveDown:
                        TryPlayerMove(Direction.Down);
                        break;
                    case ActionType.MoveLeft:
                        TryPlayerMove(Direction.Left);
                        break;
                    case ActionType.MoveRight:
                        TryPlayerMove(Direction.Right);
                        break;
                    case ActionType.AttackUp:
                        TryPlayerAttack(Direction.Up);
                        break;
                    case ActionType.AttackDown:
                        TryPlayerAttack(Direction.Down);
                        break;
                    case ActionType.AttackLeft:
                        TryPlayerAttack(Direction.Left);
                        break;
                    case ActionType.AttackRight:
                        TryPlayerAttack(Direction.Right);
                        break;
                    default:
                        break;
                }
                _enemyAI.MakeMoveEnemies();
                if (!_player.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine("Вы проиграли(");
                    Console.ReadKey();
                    return;
                }
            }
        }

        public bool TryAdd(Entity gameObject)
        {
            if (_field.TryAddToField(gameObject))
            {
                if (_field[gameObject.Location].Item is not null && gameObject is Creature creature)
                    creature.TryTake(_field[gameObject.Location].Item);

                return true;
            }

            return false;
        }

        private bool TryPlayerMove(Direction direction)
        {
            Point newLocation = Point.Add(_player.Location, DirectionToSize(direction));

            return _field.TryMoveTo(_player, newLocation);
        }

        private bool TryPlayerAttack(Direction direction)
        {
            Point attackedLocation = Point.Add(_player.Location, DirectionToSize(direction));

            if (!_field.IsInRange(attackedLocation))
                return false;

            return _field.TryAttack(attacker: _player, target: _field[attackedLocation].GameObject);
        }

        public static Size DirectionToSize(Direction direction) => direction switch
        {
            Direction.Up => new Size(0, 1),
            Direction.Down => new Size(0, -1),
            Direction.Left => new Size(-1, 0),
            Direction.Right => new Size(1, 0),
            _ => Size.Empty,
        };

        private void Update()
        {
            Console.Clear();
            _UI.PrintUI();
        }

        private static ActionType GetRequestActionInput() =>
            Console.ReadKey(intercept: true).Key switch
            {
                ConsoleKey.W => ActionType.MoveUp,
                ConsoleKey.S => ActionType.MoveDown,
                ConsoleKey.A => ActionType.MoveLeft,
                ConsoleKey.D => ActionType.MoveRight,
                ConsoleKey.UpArrow => ActionType.AttackUp,
                ConsoleKey.DownArrow => ActionType.AttackDown,
                ConsoleKey.LeftArrow => ActionType.AttackLeft,
                ConsoleKey.RightArrow => ActionType.AttackRight,
                ConsoleKey.Escape => ActionType.Exit,
                _ => ActionType.None,
            };

        private void ArrangeObjectsOnField()
        {
            ArrangeObstaclesOnField();

            ArrangeItemsOnField();

            ArrangeCreatureOnField();
        }

        private void ArrangeObstaclesOnField()
        {
            TryAdd(new Tree(_field.GetRandomFreePointForGameObject()));
            TryAdd(new Tree(_field.GetRandomFreePointForGameObject()));
            TryAdd(new Tree(_field.GetRandomFreePointForGameObject()));
        }

        private void ArrangeItemsOnField()
        {
            TryAdd(new CyclistEquipment(_field.GetRandomFreePointForItem()));
            TryAdd(new PotionStrength(_field.GetRandomFreePointForItem()));
            TryAdd(new CyclistEquipment(_field.GetRandomFreePointForItem()));
        }

        private void ArrangeCreatureOnField()
        {
            _player = new Player(_field.GetRandomFreePointForGameObject(), Characteristics.PlayerDefault);
            TryAdd(_player);
            _enemyAI.Target = _player;

            TryAdd(new Zombie(_field.GetRandomFreePointForGameObject()));
            TryAdd(new Goblin(_field.GetRandomFreePointForGameObject()));
        }
    }
}
