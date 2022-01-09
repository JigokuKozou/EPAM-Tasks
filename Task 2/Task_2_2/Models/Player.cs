using System.Drawing;

namespace Task_2_2.Models
{
    public class Player : Entity
    {
        public int Shield { get; private set; }

        public Player(Point location) : base("Игрок", location, 'P') { }

        public Player(int x, int y) : this(new Point(x, y)) { }

        public override void Collision(Entity other)
        {
            if (other is null)
                return;

            
        }
    }
}
