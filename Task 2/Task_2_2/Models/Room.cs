using Task_2_2.Models.Items;

namespace Task_2_2.Models
{
    public class Room
    {
        public Entity Creature { get; set; }

        public Item Item { get; set; }

        public override string ToString() => "[" + (Creature?.Icon ?? Item?.Icon ?? ' ') + "]";
    }
}
