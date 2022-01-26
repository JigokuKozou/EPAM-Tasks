using System;
using System.Collections.Generic;

namespace Task_1
{
    public enum Actions
    {
        None,
        AddFigure,
        ShowFigures,
        ClearFigures,
        ChangeUser,
        Exit,
    }

    public class GraphicEditor
    {
        private User _current;

        private FigureBuilder _figureBuilder = new();

        private Dictionary<string, User> users = new();

        public void Start()
        {
            Actions input = Actions.None;
            while (input is not Actions.Exit)
            {
                Login();
                input = Actions.None;
                while (input is not (Actions.Exit or Actions.ChangeUser))
                {
                    input = GetRequestActionInput();
                    Console.WriteLine();

                    switch (input)
                    {
                        case Actions.None:
                        case Actions.Exit:
                        case Actions.ChangeUser:
                            break;
                        case Actions.AddFigure:
                            AddFigure();
                            break;
                        case Actions.ShowFigures:
                            ShowAllFigures();
                            break;
                        case Actions.ClearFigures:
                            ClearFigures();
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }

        private void Login()
        {
            string name = GetInputNameRequest();
            if (users.ContainsKey(name))
            {
                _current = users[name];
            }
            else
            {
                _current = new User(name);
                users.Add(name, _current);
            }
        }

        private Actions GetRequestActionInput()
        {
            Actions input;
            do
            {
                Console.WriteLine($"{_current.Name}, выберите действие");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Вывести фигуры");
                Console.WriteLine("3. Очистить холст");
                Console.WriteLine("4. Сменить пользователя");
                Console.WriteLine("5. Выход");
            } while (!TryParseActions(Console.ReadLine(), out input));

            return input;
        }

        private void AddFigure()
        {
            FiguresType type = GetRequestFigureInput();
            Console.WriteLine();

            var figure = _figureBuilder.BuildFigure(type);
            Console.WriteLine($"Фигура {figure} создана!" + Environment.NewLine);

            _current.AddFigure(figure);
        }

        private FiguresType GetRequestFigureInput()
        {
            FiguresType input;
            do
            {
                Console.WriteLine($"{_current.Name}, выберите фигуру");
                Console.WriteLine("1. Круг");
                Console.WriteLine("2. Кольцо");
                Console.WriteLine("3. Прямоугольник");
                Console.WriteLine("4. Квадрат");
                Console.WriteLine("5. Треугольник");
                Console.WriteLine("6. Линия");
            } while (!TryParseFiguresType(Console.ReadLine(), out input));

            return input;
        }

        private bool TryParseActions(string s, out Actions result)
        {
            int number;
            if (int.TryParse(s, out number))
            {
                return TryParseActions(number, out result);
            }

            result = Actions.None;
            return false;
        }

        private bool TryParseActions(int number, out Actions result)
        {
            result = number switch
            {
                1 => Actions.AddFigure,
                2 => Actions.ShowFigures,
                3 => Actions.ClearFigures,
                4 => Actions.ChangeUser,
                5 => Actions.Exit,
                _ => Actions.None
            };
            
            return result != Actions.None;
        }

        private bool TryParseFiguresType(string s, out FiguresType result)
        {
            int number;
            if (int.TryParse(s, out number))
            {
                return TryParseFiguresType(number, out result);
            }

            result = FiguresType.None;
            return false;
        }

        private bool TryParseFiguresType(int number, out FiguresType result)
        {
            result = number switch
            {
                1 => FiguresType.Circle,
                2 => FiguresType.Ring,
                3 => FiguresType.Rectangle,
                4 => FiguresType.Square,
                5 => FiguresType.Triangle,
                6 => FiguresType.Line,
                _ => FiguresType.None
            };

            return result != FiguresType.None;
        }

        private string GetInputNameRequest()
        {
            Console.Write("Введите имя пользователя: ");
            return Console.ReadLine().Trim();
        }

        public void SwitchUser(User user)
        {
            if (_current.Equals(user))
                throw new ArgumentException(nameof(user));

            _current = user;
        }

        public void ClearFigures() => _current.ClearFigures();

        public void ShowAllFigures()
        {
            foreach (var figure in _current.Figures)
            {
                Console.WriteLine(figure.GetInfo());
            }
        }
    }
}
