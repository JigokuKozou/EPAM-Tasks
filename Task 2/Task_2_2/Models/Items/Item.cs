using System.Drawing;

namespace Task_2_2.Models.Items
{
    public abstract class Item : Entity
    {
        protected Item(string name, Point location, char icon, Characteristics characteristics) :
            base(name, location, icon)
        {
            Characteristics = characteristics;
        }

        public Characteristics Characteristics { get; }
    }
}
