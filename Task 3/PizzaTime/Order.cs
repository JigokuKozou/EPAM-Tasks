namespace PizzaTime
{
    public struct Order
    {
        private static int _id = 0;

        public Order(IEnumerable<PizzaType> pizzaTypes)
        {
            ID = _id;
            PizzaTypes = pizzaTypes.ToArray();

            _id++;
        }

        public int ID { get; }

        public IEnumerable<PizzaType> PizzaTypes { get; init; }

        public DateTime Date { get; } = DateTime.Now;
    }
}
