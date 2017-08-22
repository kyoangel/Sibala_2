using System.Collections.Generic;

namespace Sibala_2
{
    public enum DiceType
    {
        Same = 10,
        Points = 1,
        NoPoint = 0
    }

    public class DiceComparer : Comparer<Dice>
    {
        public override int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type == dice2.Type)
            {
                IComparer<Dice> comparer;
                if (dice1.Type == DiceType.Same)
                {
                    comparer = new SameResultComparer();
                }
                else if (dice1.Type == DiceType.Points)
                {
                    comparer = new PointsResultComparer();
                }
                else
                {
                    comparer = new NoPointResultComparer();
                }

                return comparer.Compare(dice1, dice2);
            }
            else
            {
                return (int)dice1.Type - (int)dice2.Type;
            }
        }
    }
}