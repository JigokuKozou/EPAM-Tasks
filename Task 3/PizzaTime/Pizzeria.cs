namespace PizzaTime
{
    public enum PizzaType
    {
        None,
        Pepperoni,
        Mozzarella,
        Hawaiian,
    }

    public class Pizzeria
    {
        private Dictionary<Order, IEnumerable<Pizza>> _pizzaForIssue = new();

        private List<int> _completedOrders = new();

        public Action<int> OnOrderAccepted = delegate { };

        public Action<int> OnOrderСompleted = delegate { };

        public IEnumerable<int> CompletedOrders => _completedOrders;

        public async Task TakeOrder(Order order)
        {
            OnOrderAccepted(order.ID);
            
            var pizzas = new List<Pizza>();
            foreach (var pizzaType in order.PizzaTypes)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
                pizzas.Add(MakePizza(pizzaType));
            }

            _pizzaForIssue.Add(order, pizzas);
            _completedOrders.Add(order.ID);
            OnOrderСompleted(order.ID);
        }

        public bool TryGetPizza(in Order order, out IEnumerable<Pizza> pizzas)
        {
            bool result = _pizzaForIssue.ContainsKey(order);
            if (result)
            {
                pizzas = _pizzaForIssue[order];
                _pizzaForIssue.Remove(order);
                _completedOrders.Remove(order.ID);
            }
            else
            {
                pizzas = Array.Empty<Pizza>();
            }

            return result;
        }

        private static Pizza MakePizza(PizzaType type) => type switch
        {
            PizzaType.Pepperoni => new Pizza(PizzaTypeToString(type), 90),
            PizzaType.Mozzarella => new Pizza(PizzaTypeToString(type), 60),
            PizzaType.Hawaiian => new Pizza(PizzaTypeToString(type), 30),
            _ => throw new NotImplementedException(),
        };

        public static string PizzaTypeToString(PizzaType type) => type switch
        {
            PizzaType.Pepperoni => "Пепперони",
            PizzaType.Hawaiian => "Гавайская",
            PizzaType.Mozzarella => "Моцарелла",
            PizzaType.None => "Нет",
            _ => throw new ArgumentOutOfRangeException(nameof(type)),
        };
    }
}
