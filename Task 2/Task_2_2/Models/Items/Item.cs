using System.Drawing;
using Task_2_2.Interfaces;

namespace Task_2_2.Models.Items
{
    public abstract class Item : Entity, IBonus
    {
        protected Item(string name, Point location, char icon, Characteristics characteristics) :
            base(name, location, icon)
        {
            Characteristics = characteristics;
        }

        public Characteristics Characteristics { get; }
    }
}
