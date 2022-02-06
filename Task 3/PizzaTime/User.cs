namespace PizzaTime
{
    public class User
    {
        private List<Pizza> _inventory = new();

        private Pizzeria _pizzeria;

        private List<Order> _transferedOrders = new();

        private List<PizzaType> _pizzaTypes = new();

        public User(Pizzeria pizzeria)
        {
            _pizzeria = pizzeria;
        }

        public IEnumerable<Order> TransferedOrders => _transferedOrders;

        public IEnumerable<PizzaType> CurrentPizzaTypes => _pizzaTypes;

        public IEnumerable<Pizza> Inventory => _inventory;

        public void AddPizzaToOrder(PizzaType pizzaType) => _pizzaTypes.Add(pizzaType);

        public bool RemovePizzaFromOrder(PizzaType pizzaType) => _pizzaTypes.Remove(pizzaType);

        public void TransferOrder()
        {
            if (_pizzaTypes.Count == 0)
                return;

            var order = new Order(_pizzaTypes);
            _pizzaTypes.Clear();

            _pizzeria.TakeOrder(order);
            _transferedOrders.Add(order);
        }

        public void PickUpOrder()
        {
            foreach (var order in _transferedOrders)
            {
                if (_pizzeria.CompletedOrders.Contains(order.ID))
                {
                    _pizzeria.TryGetPizza(order, out IEnumerable<Pizza> receivedPizza);
                    _inventory.AddRange(receivedPizza);
                    return;
                }
            }
        }
    }
}
