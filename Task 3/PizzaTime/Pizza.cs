namespace PizzaTime
{
    public class Pizza
    {
        public Pizza(string name, int satiety)
        {
            Name = name;
            Satiety = satiety;
        }

        public string Name { get; init; }

        public int Satiety { get; init; }
    }
}
