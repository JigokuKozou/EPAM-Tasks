using System;
using System.Drawing;
using Task_2_2.Interfaces;
using Task_2_2.Models.Items;

namespace Task_2_2.Models
{
    public class Player : Entity, IDamagable, IAttacker
    {
        public Player(Point location, Characteristics characteristics) : base("Игрок", location, 'P', characteristics) { }

        public Player(int x, int y, Characteristics characteristics) : this(new Point(x, y), characteristics) { }

        public bool IsAlive => Characteristics.Health > 0;

        public int Attack(IDamagable target) => target.TakeDamage(Characteristics.Damage);

        public override void Collision(Entity other)
        {
            if (other is Item)
            {
                Characteristics.Add(other.Characteristics);
            }
        }

        public int TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentException(nameof(damage));

            int realDamage = damage - Characteristics.Armor;

            if (realDamage < 0)
                return 0;
            else
            {
                Characteristics.Health -= realDamage;
            }
            return realDamage;
        }
    }
}
