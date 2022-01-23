using System.Drawing;

namespace Task_2_2.Models.Obstacles
{
    public class Tree : Obstacle
    {
        public Tree(Point location) : base("Дерево", location, 'Д', new(health: 60)) { }
    }
}
