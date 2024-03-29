﻿using System;
using Task_2_2.Models.Creatures;

namespace Task_2_2.Models
{
    public class ConsoleUI
    {
        private GameField _field;

        private Player _player;

        public ConsoleUI(GameField field, Player player)
        {
            _field = field;
            _player = player;
        }

        public void PrintUI()
        {
            Console.WriteLine(_field);
            PrintPlayerHUD();
            Console.WriteLine();
            PrintRules();
        }

        public void PrintPlayerHUD()
        {
            int widthLine = 10;
            Characteristics charateristics = _player.Characteristics;

            Console.WriteLine(GetCharacteristic("Health", charateristics.Health, charateristics.MaxHealth, widthLine));
            Console.WriteLine();
            Console.WriteLine(GetCharacteristic("Armor", charateristics.Armor, charateristics.MaxArmor, widthLine));
            Console.WriteLine();
            Console.WriteLine($"Damage: {charateristics.Damage}");
        }

        public void PrintRules()
        {
            Console.WriteLine(
                $"{_player.Icon} - it is you" + Environment.NewLine +
                "WASD - Move" + Environment.NewLine +
                "Arrows - Attack" + Environment.NewLine +
                "Enemies:" + Environment.NewLine +
                "Z - Zombie (15 damage)" + Environment.NewLine +
                "G - Goblin (10 damage)" + Environment.NewLine +
                "Obstacles:" + Environment.NewLine +
                "T - Tree (60 health)" + Environment.NewLine +
                "# - Stone (100 health, 50 armor)" + Environment.NewLine +
                "Bonuses:" + Environment.NewLine +
                "C - Cyclist Equipment (30 armor)" + Environment.NewLine +
                "S - Potion of Strength (10 health, 15 damage)");
        }

        private static string GetCharacteristic(string name, int current, int maximum, int widthLine)
        {
            int currentWidth = current / (maximum / widthLine);

            return name + Environment.NewLine + GetLine(currentWidth < 0 ? 0 : currentWidth, widthLine) + $" {current}/{maximum}";
        }

        private static string GetLine(int current, int maximum)
        {
            if (current > maximum)
                throw new ArgumentOutOfRangeException(nameof(current), "current is greater maximum");

            return $"[{new string('#', current)}{new string('-', maximum - current)}]";
        }
    }
}
