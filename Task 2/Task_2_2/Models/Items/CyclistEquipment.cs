using System.Drawing;

namespace Task_2_2.Models.Items
{
    public class CyclistEquipment : Item
    {
        public CyclistEquipment(Point location) : 
            base("Экипировка велосипедиста", location, 'С', new Characteristics(armor: 30)) { }
    }
}
