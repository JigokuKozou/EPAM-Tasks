using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Task_2_2.Interfaces;
using Task_2_2.Models.Creatures;
using Task_2_2.Models.Items;
using Task_2_2.Models.Obstacles;

namespace Task_2_2.Models
{
    public class GameField
    {
        private Room[,] _rooms;

        private string _horizontalLine;

        private readonly Random _random = new();

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;

            InitializeRooms();
            InitializeHorizontalLine();
        }

        public int Width { get; }

        public int Height { get; }

        public Room this[Point location]
        {
            get => _rooms[location.X, location.Y];
            set => _rooms[location.X, location.Y] = value;
        }

        public Room this[int x, int y]
        {
            get => _rooms[x, y];
            set => _rooms[x, y] = value;
        }

        public List<Enemy> GetEnemies()
        {
            List<Enemy> result = new();
            foreach (var room in _rooms)
            {
                if (room.GameObject is Enemy enemy)
                {
                    result.Add(enemy);
                }
            }
            return result;
        }

        public bool IsInRange(Point point)
            => (point.X >= 0 && point.X < Width) && (point.Y >= 0 && point.Y < Height);

        public bool IsWalkable(Point point) => IsInRange(point) && this[point].GameObject is null;

        public bool TryAddToField(Entity gameObject)
        {
            Point location = gameObject.Location;

            if (!IsInRange(location)) 
                return false;

            if (gameObject is Item item)
            {
                if (this[location].Item is not null ||
                    this[location].GameObject is Obstacle)
                    return false;

                this[location].Item = item;
            }
            else 
            {
                if (this[location].GameObject is not null)
                    return false;

                if (gameObject is Creature creature)
                    MoveTo(creature, location);
                else if (gameObject is Obstacle obstacle)
                    this[location].GameObject = obstacle;
            }

            return true;
        }

        public bool TryMoveTo(Creature creature, Point destination)
        {
            if (!IsWalkable(destination))
                return false;

            MoveTo(creature, destination);

            return true;
        }

        public bool TryAttack(IAttacker attacker, Entity target)
        {
            if (target is null || !IsInRange(target.Location))
                return false;

            if (target is IDamagable victim)
            {
                attacker.Attack(victim);

                if (!victim.IsAlive)
                    this[target.Location].GameObject = null;

                return true;
            }
            else return false;
        }

        public Point GetRandomFreePointForItem()
        {
            Point generated;

            do
            {
                generated = new Point(_random.Next(0, Width), _random.Next(0, Height));
            } while (!(this[generated].Item is null && this[generated].GameObject is not Obstacle));

            return generated;
        }

        public Point GetRandomFreePointForGameObject()
        {
            Point generated;

            do
            {
                generated = new Point(_random.Next(0, Width), _random.Next(0, Height));
            } while (this[generated].GameObject is not null);

            return generated;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine(_horizontalLine);
            for (int y = Height - 1; y >= 0; y--)
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

        private void MoveTo(Creature creature, Point destination)
        {
            Point currentLocation = creature.Location;
            this[currentLocation].GameObject = null;
            this[destination].GameObject = creature;

            creature.Move(destination);

            if (creature.TryTake(this[destination].Item))
            {
                this[destination].Item = null;
            }
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
