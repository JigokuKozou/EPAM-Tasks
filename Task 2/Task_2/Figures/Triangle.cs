﻿using System;
using System.Text;

namespace Task_1.Figures
{
    public class Triangle : СlosedFigure
    {
        public Point First { get; }

        public Point Second { get; }

        public Point Third { get; }

        public Triangle(Point first, Point second, Point third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public override double Perimeter =>
            First.GetLength(Second) + Second.GetLength(Third) + Third.GetLength(First);

        public override double Area => 
            Math.Abs((Second.X - First.X)*(Third.Y - First.Y) - (Third.X - First.X)*(Second.Y - First.Y)) / 2.0;

        public override string GetInfo()
        {
            StringBuilder builder = new(base.GetInfo());
            builder.AppendLine($"Первая точка: {First}");
            builder.AppendLine($"Вторая точка: {Second}");
            builder.AppendLine($"Третья точка: {Third}");
            return builder.ToString();
        }

        public override string ToString() => "Треугольник";
    }
}
