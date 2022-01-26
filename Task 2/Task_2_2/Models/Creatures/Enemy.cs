using System.Drawing;
using Task_2_2.Interfaces;
using Task_2_2.Models.Items;

namespace Task_2_2.Models.Creatures
{
    public abstract class Enemy : Creature, IAttacker
    {
        public Enemy(string name, Point location, char icon, Characteristics characteristics) : 
            base(name, location, icon, characteristics) { }

        public int Attack(IDamagable target)
            => target.TakeDamage(Characteristics.Damage);

        public override bool TryTake(Item item) => false;
    }
}
