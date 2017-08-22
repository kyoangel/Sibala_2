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
                if (dice1.Type == DiceType.Same)
                {
                    return new SameResultComparer().Compare(dice1, dice2);
                }
                else if (dice1.Type == DiceType.Points)
                {
                    return new PointsResultComparer().Compare(dice1, dice2);
                }
                else
                {
                    return new NoPointResultComparer().Compare(dice1, dice2);
                }
            }
            else
            {
                return (int)dice1.Type - (int)dice2.Type;
            }
        }
    }
}