using PizzaTime;
using static PizzaTime.ConsoleUI;

Pizzeria dodoPizza = new Pizzeria();
dodoPizza.OnOrderAccepted += AddToTableOrderAcceptanceNotifice;
dodoPizza.OnOrderСompleted += AddToTableOrderReadinessNotification;

User user = new User(dodoPizza);

ActionType input = ActionType.None;
while (input is not ActionType.Exit)
{
    input = RequestInputActions();

    switch (input)
    {
        case ActionType.None:
            continue;
        case ActionType.AddPizza:
            user.AddPizzaToOrder(RequestInputPizzaType());
            break;
        case ActionType.ShowOrder:
            ShowPizzas(user.CurrentPizzaTypes);
            Console.ReadKey(true);
            break;
        case ActionType.RemovePizza:
            user.RemovePizzaFromOrder(RequestInputPizzaType());
            break;
        case ActionType.TransferOrder:
            user.TransferOrder();
            break;
        case ActionType.PickUpOrder:
            user.PickUpOrder();
            break;
        case ActionType.ShowInventory:
            ShowInventory(user.Inventory);
            Console.ReadKey(true);
            break;
        case ActionType.Exit:
            break;
        default:
            throw new NotImplementedException();
    }
}

dodoPizza.OnOrderAccepted -= AddToTableOrderAcceptanceNotifice;
dodoPizza.OnOrderСompleted -= AddToTableOrderReadinessNotification;