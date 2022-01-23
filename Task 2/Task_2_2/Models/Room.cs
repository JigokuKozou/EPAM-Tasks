using Task_2_2.Models.Items;

namespace Task_2_2.Models
{
    public class Room
    {
        public Entity GameObject { get; set; }

        public Item Item { get; set; }

        public Entity GetEntity() => GameObject ?? Item;

        public override string ToString() => (GetEntity()?.Icon ?? ' ').ToString();
    }
}
