using System;
using System.Drawing;
using Task_2_2.Interfaces;
using Task_2_2.Models.Creatures;
using Task_2_2.Models.Enums;

namespace Task_2_2.Models
{
    public class EnemyAI
    {
        private GameField _field;

        public Entity Target { get; set; }

        public EnemyAI(GameField field)
        {
            _field = field;
        }

        public void MakeMoveEnemies()
        {
            if (Target is null) return;

            var enemies = _field.GetEnemies();
            if (enemies is null) return;

            foreach (var enemy in enemies)
            {
                if (!TryChaseTarget(enemy))
                {
                    if (Target is IDamagable victim)
                    {
                        enemy.Attack(victim);
                    }
                }
            }
        }

        public bool TryChaseTarget(Enemy enemy)
        {
            Size coordinateDifference = new Size(Target.Location.X - enemy.Location.X, Target.Location.Y - enemy.Location.Y);

            if (coordinateDifference.Width == 0 && Math.Abs(coordinateDifference.Height) == 1 ||
                Math.Abs(coordinateDifference.Width) == 1 && coordinateDifference.Height == 0)
                return false;

            if (Math.Abs(coordinateDifference.Height) >= Math.Abs(coordinateDifference.Width))
            {
                if (!TryMoveTo(enemy, coordinateDifference.Height > 0 ? Direction.Up : Direction.Down))
                {
                    if (!TryMoveTo(enemy, coordinateDifference.Width > 0 ? Direction.Right : Direction.Left))
                    {
                        if (!TryMoveTo(enemy, coordinateDifference.Width > 0 ? Direction.Left : Direction.Right))
                        {
                            TryMoveTo(enemy, coordinateDifference.Height > 0 ? Direction.Down : Direction.Up);
                        }
                    } 
                }
            }
            else
            {
                if (!TryMoveTo(enemy, coordinateDifference.Width > 0 ? Direction.Right : Direction.Left))
                {
                    if (!TryMoveTo(enemy, coordinateDifference.Height > 0 ? Direction.Up : Direction.Down))
                    {
                        if (!TryMoveTo(enemy, coordinateDifference.Height > 0 ? Direction.Down : Direction.Up))
                        {
                            TryMoveTo(enemy, coordinateDifference.Width > 0 ? Direction.Left : Direction.Right);
                        }
                    }
                }
            }

            return true;
        }

        private bool TryMoveTo(Enemy enemy, Direction direction)
        {
            Size offset = Game.DirectionToSize(direction);

            return _field.TryMoveTo(enemy, enemy.Location + offset);
        }
    }
}
