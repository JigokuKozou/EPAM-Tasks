using System.Drawing;

namespace Task_2_2.Models.Creatures
{
    public class Goblin : Enemy
    {
        public Goblin(Point location) : base("Гоблин", location, 'G', new(health: 100, damage: 10)) { }
    }
}
