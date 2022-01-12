using System;

namespace Task_2_2.Models
{
    public class Characteristics
    {
        public Characteristics(int health, int damage, int armor, ConsoleColor color = ConsoleColor.White)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
            Color = color;
        }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }

        public ConsoleColor Color { get; set; }

        public void Add(Characteristics other)
        {
            Health += other.Health;
            Damage += other.Damage;
            Armor += other.Armor;
            Color = other.Color;
        }
    }
}
