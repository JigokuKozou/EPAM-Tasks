using System;

namespace Task_1.Figures
{
    public abstract class СlosedFigure : Figure
    {
        public virtual double Perimeter => 0;

        public override string GetInfo() =>
            base.GetInfo() + "Периметр: " + Perimeter + Environment.NewLine;
    }
}
