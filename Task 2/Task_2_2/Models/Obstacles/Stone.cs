using System.Drawing;

namespace Task_2_2.Models.Obstacles
{
    public class Stone : Obstacle
    {
        public Stone(Point location) : base("Камень", location, '#', new(health: 100, armor: 50)) { }
    }
}
