using System;

namespace Task_2_2.Models
{
    public class Characteristics
    {
        private int _health;

        private int _armor;

        private int _damage;

        public Characteristics(int health = 0, int armor = 0, int damage = 0, 
            int maxHealth = 100, int maxArmor = 100, int maxDamage = 100)
        {
            MaxHealth = maxHealth;
            MaxArmor = maxArmor;
            MaxDamage = maxDamage;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public int MaxHealth { get; set; }

        public int MaxArmor { get; set; }

        public int MaxDamage { get; set; }

        public int Health
        {
            get => _health;
            set
            {
                if (value > MaxHealth)
                    _health = MaxHealth;
                else _health = value;
            }
        }

        public int Armor
        {
            get => _armor;
            set
            {
                if (value > MaxArmor)
                    _armor = MaxArmor;
                else if (value < 0) _armor = 0;
                else _armor = value;
            }
        }

        public int Damage
        {
            get => _damage;
            set
            {
                if (value > MaxDamage)
                    _damage = MaxDamage;
                else if (value < 0) _damage = 0;
                else _damage = value;
            }
        }

        public static Characteristics PlayerDefault => new(health: 100, armor: 0, damage: 30);

        public void Add(Characteristics other)
        {
            Health += other.Health;
            Armor += other.Armor;
            Damage += other.Damage;
        }
    }
}
