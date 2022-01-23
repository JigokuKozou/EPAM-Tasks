using System.Drawing;

namespace Task_2_2.Models
{
    public abstract class Entity
    {
        protected Entity(string name, Point location, char icon)
        {
            Name = name;
            Location = location;
            Icon = icon;
        }

        private Point _location;

        public string Name { get; }

        public char Icon { get; }

        public Point Location
        {
            get => _location;
            protected set => _location = value;
        }
    }
}
