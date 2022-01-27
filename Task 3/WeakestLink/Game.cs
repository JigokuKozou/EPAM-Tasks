namespace WeakestLink
{
    public class Game
    {
        private List<People> _peoples;

        private int _offset;

        public Game(int peopleAmount, int offset)
        {
            _peoples = new(peopleAmount);
            for (int i = 0; i < peopleAmount; i++)
            {
                _peoples.Add(new People(i + 1));
            }

            _offset = offset;
        }

        public Action<int> OnRoundEnd = delegate { };

        public Action OnGameEnd = delegate { };

        public int PeoplesCount => _peoples.Count;

        public void Start()
        {
            int removingIndex = _offset - 1;
            for (int round = 1; _offset <= _peoples.Count; round++)
            {
                _peoples.Remove(_peoples[removingIndex]);
                removingIndex += _offset - 1;
                removingIndex %= _peoples.Count;

                OnRoundEnd(round);
            }

            OnGameEnd();
        }
    }
}
