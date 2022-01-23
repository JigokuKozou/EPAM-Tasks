using System.Drawing;

namespace Task_2_2.Models.Creatures
{
    public class Zombie : Enemy
    {
        public Zombie(Point location) : base("Зомби", location, 'Z', new(health: 100, damage: 20)) { }
    }
}
