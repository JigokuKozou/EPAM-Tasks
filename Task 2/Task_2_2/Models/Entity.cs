using System.Drawing;

namespace Task_2_2.Models
{
    public abstract class Entity
    {
        public string Name { get; }

        public Point Location { get; }

        public char Icon { get; }

        public Characteristics Characteristics { get; protected set; }

        public Entity(string name, Point location, char icon, Characteristics characteristics)
        {
            Name = name;
            Location = location;
            Icon = icon;
            Characteristics = characteristics;
        }

        public Entity(string name, int x, int y, char icon, Characteristics characteristics) : 
            this(name, new Point(x, y), icon, characteristics) { }

        public abstract void Collision(Entity other);
    }
}
