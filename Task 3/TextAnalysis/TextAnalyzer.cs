using System.Text;

namespace TextAnalysis
{
    internal class TextAnalyzer
    {
        private Dictionary<string, int> _wordsRepeatPair = new();

        public int MaximumNumberRepetitions { get; set; } = 20;

        public int MinimumNumberRepetitions { get; set; } = 2;

        public int MinimumWordLength { get; set; } = 2;

        public string Verdict { get; private set; } = "None";

        public void Analyse(string text)
        {
            _wordsRepeatPair.Clear();

            var words = RemovePunctuationMarks(text.ToLower())
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (_wordsRepeatPair.ContainsKey(word))
                {
                    _wordsRepeatPair[word]++;
                }
                else
                {
                    _wordsRepeatPair.Add(word, 1);
                }
            }

            if (GetWordsStatistic()?.MaxBy(pair => pair.Value).Value >= MaximumNumberRepetitions)
            {
                Verdict = $"В тексте есть слово, которое повторяется {MaximumNumberRepetitions} или более раз";
            }
            else
            {
                Verdict = $"В тексте нет слова, которое повторяется {MaximumNumberRepetitions} или более раз";
            }
        }

        public IEnumerable<KeyValuePair<string, int>> GetWordsStatistic()
        {
            foreach (var pair in _wordsRepeatPair
                .Where(pair => pair.Value > MinimumNumberRepetitions)
                .Where(pair => pair.Key.Length > MinimumWordLength)
                .OrderByDescending(pair => pair.Value))
            {
                yield return pair;
            }
        }

        private string RemovePunctuationMarks(string text)
        {
            StringBuilder builder = new StringBuilder(text);
            for (int i = 0; i < builder.Length; i++)
            {
                if (Char.IsPunctuation(builder[i]))
                {
                    builder.Remove(i, 1);
                    i--;
                }
            }

            return builder.ToString();
        }
    }
}
