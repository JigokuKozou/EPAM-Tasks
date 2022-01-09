using System.Drawing;

namespace Task_2_2.Models.Items
{
    public abstract class Item : Entity
    {
        public Item(string name, Point location, char icon) : base(name, location, icon) { }

        public Item(string name, int x, int y, char icon) : base(name, x, y, icon) { }

        public override void Collision(Entity other) { }
    }
}
