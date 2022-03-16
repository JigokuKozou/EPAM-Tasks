using WeakestLink;

int peopleAmount = InputInt("Введите количество человек: ");
int offset = InputInt("Введите, какой по счету человек будет вычеркнут каждый раунд: ");

Game game = new Game(peopleAmount, offset);

game.OnRoundEnd += (round) => Console.WriteLine(
    $"Раунд {round}. Вычеркнут человек. Людей осталось: {game.PeoplesCount}");

game.OnGameEnd += () => Console.WriteLine(
    "Игра окончена. Невозможно вычеркнуть больше людей.");

game.Start();

static int InputInt(string message)
{
    int result;
    do
    {
        Console.Write(message);
    } while (!int.TryParse(Console.ReadLine(), out result));
    return result;
}