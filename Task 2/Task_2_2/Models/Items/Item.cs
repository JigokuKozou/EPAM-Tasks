using System.Drawing;

namespace Task_2_2.Models.Items
{
    public abstract class Item : Entity
    {
        public Item(string name, Point location, char icon, Characteristics characteristics) : 
            base(name, location, icon, characteristics) { }

        public Item(string name, int x, int y, char icon, Characteristics characteristics) : 
            base(name, x, y, icon, characteristics) { }

        public override void Collision(Entity other) { return; }
    }
}
