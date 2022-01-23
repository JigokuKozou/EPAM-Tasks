using System;
using System.Drawing;
using Task_2_2.Interfaces;

namespace Task_2_2.Models.Obstacles
{
    public class Obstacle : Entity, IAttacker, IDamagable
    {
        public Characteristics Characteristics { get; set; }

        public bool IsAlive => Characteristics.Health > 0;

        public Obstacle(string name, Point location, char icon, Characteristics characteristics) : 
            base(name, location, icon)
        { 
            Characteristics = characteristics; 
        }

        public int Attack(IDamagable target) => target.TakeDamage(Characteristics.Damage);

        public int TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentException("Trying to heal by call TakeDamage()", nameof(damage));

            Characteristics.Health -= damage;

            return damage;
        }
    }
}

