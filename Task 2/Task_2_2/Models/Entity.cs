using System.Drawing;

namespace Task_2_2.Models
{
    public abstract class Entity
    {
        public string Name { get; }

        public Point Location { get; }

        public char Icon { get; }

        public Entity(string name, Point location, char icon)
        {
            Name = name;
            Location = location;
            Icon = icon;
        }

        public Entity(string name, int x, int y, char icon) : this(name, new Point(x, y), icon) { }

        public virtual void Collision(Entity other) { }
    }
}
