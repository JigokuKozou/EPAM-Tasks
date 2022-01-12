using Task_2_2.Models.Items;

namespace Task_2_2.Models
{
    public class Room
    {
        public Entity Creature { get; set; }

        public Item Item { get; set; }

        public Entity GetEntity() => Creature ?? Item;

        public override string ToString() => (GetEntity()?.Icon ?? ' ').ToString();
    }
}
