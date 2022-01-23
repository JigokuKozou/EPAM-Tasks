using System.Drawing;
using Task_2_2.Interfaces;

namespace Task_2_2.Models.Creatures
{
    public class Player : Creature, IAttacker
    {
        public Player(Point location, Characteristics characteristics) : base("Игрок", location, '%', characteristics) { }

        public Player(int x, int y, Characteristics characteristics) : this(new Point(x, y), characteristics) { }

        public int Attack(IDamagable target) => target.TakeDamage(Characteristics.Damage);
    }
}
