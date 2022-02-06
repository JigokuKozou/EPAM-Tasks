namespace PizzaTime
{
    public sealed class UserUI
    {
        private List<string> _messages = new();

        public void AddLine(string message) => _messages.Add(message);

        public void Clear() => _messages.Clear();

        public void PrintMessages() => Console.WriteLine(GetMessages());

        public string GetMessages() => string.Join(Environment.NewLine, _messages);
    }
}
