using System.Drawing;

namespace Task_2_2.Models.Items
{
    public class PotionStrength : Item
    {
        public PotionStrength(Point location) : 
            base("Potion of Strength", location, 'S', new(health: 20, damage: 15)) { }
    }
}
    