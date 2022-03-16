namespace PizzaTime
{
    public static class ConsoleUI
    {
        private static ActionType[] _actionTypes;

        private static PizzaType[] _pizzaTypes;

        private static Table _table = new() { Name = "Pizzeria Table" };

        private static UserUI _userUI = new();

        static ConsoleUI()
        {
            _pizzaTypes = Enum.GetValues(typeof(PizzaType))
                .OfType<PizzaType>()
                .Skip(1)
                .ToArray();

            _actionTypes = Enum.GetValues(typeof(ActionType))
                .OfType<ActionType>()
                .Skip(1)
                .ToArray();

            OnUpdateConsole += Console.Clear;
            OnUpdateConsole += _table.PrintTable;
            OnUpdateConsole += _userUI.PrintMessages;
            _table.OnMessageAdd += OnUpdateConsole;
        }

        public static Action OnUpdateConsole = delegate { };

        public enum ActionType
        {
            None,
            AddPizza,
            ShowOrder,
            RemovePizza,
            TransferOrder,
            PickUpOrder,
            ShowInventory,
            Exit,
        }

        public static ActionType RequestInputActions()
        {
            AddRequestInputActions();
            ActionType input;
            do
            {
                OnUpdateConsole();
            } while (!TryParseActions(Console.ReadLine(), out input));
            
            return input;
        }

        public static PizzaType RequestInputPizzaType()
        {
            AddRequestInputPizzaType();
            var input = PizzaType.None;
            do
            {
                OnUpdateConsole();
            } while (!TryParsePizzaType(Console.ReadLine(), out input));

            return input;
        }

        public static void ShowPizzas(IEnumerable<PizzaType> pizzaTypes)
        {
            _userUI.Clear();
            _userUI.AddLine("Пиццы в заказе:");
            foreach (var pizzaType in pizzaTypes)
            {
                _userUI.AddLine(Pizzeria.PizzaTypeToString(pizzaType));
            }

            OnUpdateConsole();
        }

        public static void ShowInventory(IEnumerable<Pizza> pizzas)
        {
            _userUI.Clear();
            _userUI.AddLine("Инвентарь:");
            foreach (var pizza in pizzas)
            {
                _userUI.AddLine(pizza.Name);
            }

            OnUpdateConsole();
        }

        public static void AddToTableOrderReadinessNotification(int orderID)
        {
            _table.Add($"Заказ #{ orderID } готов к выдаче!", ConsoleColor.Green);
        }

        public static void AddToTableOrderAcceptanceNotifice(int orderID)
        {
            _table.Add($"Заказ #{ orderID } принят!", ConsoleColor.Yellow);
        }

        private static bool TryParseActions(string? input, out ActionType action)
        {
            int inputNumber;
            if (int.TryParse(input, out inputNumber))
            {
                return TryParseActions(inputNumber, out action);
            }
            else
            {
                action = ActionType.None;
                return false;
            }
        }

        private static bool TryParseActions(int input, out ActionType action)
        {
            try
            {
                action = ParseActions(input);
            }
            catch
            {
                action = ActionType.None;
                return false;
            }

            return true;
        }

        private static ActionType ParseActions(int input) => _actionTypes[input - 1];

        private static void AddRequestInputActions()
        {
            _userUI.Clear();
            _userUI.AddLine("Выберите действие:");

            for (int i = 0; i < _actionTypes.Length; i++)
            {
                _userUI.AddLine($"{ i + 1 }. { ActionTypeToString(_actionTypes[i]) }");
            }
        }

        private static void AddRequestInputPizzaType()
        {
            _userUI.Clear();
            _userUI.AddLine("Выберите тип пиццы:");

            for (int i = 0; i < _pizzaTypes.Length; i++)
            {
                _userUI.AddLine($"{ i + 1 }. { Pizzeria.PizzaTypeToString(_pizzaTypes[i]) }");
            }
        }

        private static bool TryParsePizzaType(string? input, out PizzaType type)
        {
            int inputNumber;
            if (int.TryParse(input, out inputNumber))
            {
                return TryParsePizzaType(inputNumber, out type);
            }
            else
            {
                type = PizzaType.None;
                return false;
            }
        }

        private static bool TryParsePizzaType(int input, out PizzaType type)
        {
            try
            {
                type = ParsePizzaType(input);
            }
            catch
            {
                type = PizzaType.None;
                return false;
            }

            return true;
        }

        private static PizzaType ParsePizzaType(int input) => _pizzaTypes[input - 1];

        private static string ActionTypeToString(ActionType action) => action switch
        {
            ActionType.AddPizza => "Добавить пиццу к заказу",
            ActionType.ShowOrder => "Показать заказанные пиццы",
            ActionType.RemovePizza => "Убрать пиццу из заказа",
            ActionType.TransferOrder => "Передать заказ",
            ActionType.PickUpOrder => "Забрать заказ",
            ActionType.ShowInventory => "Показать инвентарь",
            ActionType.Exit => "Выйти",
            _ => throw new ArgumentOutOfRangeException(nameof(action)),
        };
    }
}
