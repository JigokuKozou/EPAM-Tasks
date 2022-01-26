using System.Collections.Generic;
using Task_1.Figures;

namespace Task_1
{
    public struct User
    {
        public string Name { get; }

        private List<Figure> _figures;
        public IEnumerable<Figure> Figures => _figures;

        public User(string name)
        {
            Name = name;

            _figures = new();
        }

        public void AddFigure(Figure figure) => _figures.Add(figure);

        public void ClearFigures() => _figures.Clear();
    }
}