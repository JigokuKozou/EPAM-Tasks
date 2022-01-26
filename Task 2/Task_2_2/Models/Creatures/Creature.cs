using System;
using System.Drawing;
using Task_2_2.Interfaces;
using Task_2_2.Models.Items;

namespace Task_2_2.Models.Creatures
{
    public abstract class Creature : Entity, IMovable, IDamagable
    {
        protected Creature(string name, Point location, char icon, Characteristics characteristics) :
            base(name, location, icon) 
        { 
            Characteristics = characteristics;
        }

        public Characteristics Characteristics { get; protected set; }

        public bool IsAlive => Characteristics.Health > 0;

        public void Move(Point destination)
        {
            Location = destination;
        }

        public virtual int TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentException("Trying to heal by call TakeDamage()", nameof(damage));

            int realDamage = damage - Characteristics.Armor;
            Characteristics.Armor -= damage;
            if (realDamage < 0)
            {
                return 0;
            }
            else
            {
                Characteristics.Health -= realDamage;
            }

            return realDamage;
        }

        public virtual bool TryTake(Item item)
        {
            if (item is null) 
                return false;

            Take(item);

            return true;
        }

        protected void Take(Item item) => Characteristics.Add(item.Characteristics);
    }
}
