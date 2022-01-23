using System;
using System.Drawing;

namespace Task_2_2.Models.Items
{
    public class CyclistEquipment : Item
    {
        public CyclistEquipment(Point location) : 
            base("Экипировка велосипедиста", location, 'В', new Characteristics(armor: 30)) { }

        public CyclistEquipment(int x, int y) :
            this(new Point(x, y)) { }
    }
}
