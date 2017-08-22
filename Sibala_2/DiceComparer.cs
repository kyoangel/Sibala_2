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
        private Dictionary<int, int> SamePointWeight = new Dictionary<int, int>
        {
            { 4,6},
            { 16,5},
            { 24,4},
            { 20,3},
            { 12,2},
            { 8,1}
        };

        public override int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type == dice2.Type)
            {
                if (dice1.Type == DiceType.Same)
                {
                    return SameResultCompare(dice1, dice2);
                }
                else if (dice1.Type == DiceType.Points)
                {
                    return PointsResultCompare(dice1, dice2);
                }
                else
                {
                    return NoPointResultCompare();
                }
            }
            else
            {
                return (int)dice1.Type - (int)dice2.Type;
            }
        }

        private int NoPointResultCompare()
        {
            return 0;
        }

        private int PointsResultCompare(Dice dice1, Dice dice2)
        {
            if (dice1.Points == dice2.Points)
            {
                return dice1.MaxPoint - dice2.MaxPoint;
            }

            return dice1.Points - dice2.Points;
        }

        private int SameResultCompare(Dice dice1, Dice dice2)
        {
            var weightOfDice1 = SamePointWeight[dice1.Points];
            var weightOfDice2 = SamePointWeight[dice2.Points];

            return weightOfDice1 - weightOfDice2;
        }
    }
}