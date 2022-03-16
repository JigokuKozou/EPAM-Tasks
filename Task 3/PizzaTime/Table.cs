namespace PizzaTime
{
    public sealed class Table
    {
        private List<(string, ConsoleColor)> _messages = new();

        public void Add(string message, ConsoleColor color = ConsoleColor.White)
        {
            _messages.Add((message, color));
            OnMessageAdd();
        }

        public Action OnMessageAdd = delegate { };

        public string Name { get; set; } = "Table";

        public int MarginsEdges { get; set; } = 2;

        public int DisplayedMessages { get; set; } = 5;

        public void PrintTable()
        {
            if (!_messages.Any())
                return;

            var last = _messages.TakeLast(DisplayedMessages);

            int maxLength = last.MaxBy(message => message.Item1.Length).Item1.Length;
            
            string horizontal = "+" + new string('-', maxLength + MarginsEdges) + "+";
            string format = $"{{0, -{maxLength}}}";
            int offsetName = ((maxLength / 2) + MarginsEdges) - Name.Length / 2;

            var previous = Console.ForegroundColor;
            Console.WriteLine(new string(' ', offsetName) + Name);
            Console.WriteLine(horizontal);
            foreach (var message in last)
            {
                Console.Write("| ");

                Console.ForegroundColor = message.Item2;
                Console.Write(format, message.Item1);

                Console.ForegroundColor = previous;
                Console.WriteLine(" |");
            }
            Console.WriteLine(horizontal);
        }
    }
}
