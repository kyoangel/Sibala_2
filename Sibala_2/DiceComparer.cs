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
            return dice1.Type == dice2.Type
                ? SameTypeCompare(dice1, dice2)
                : DifferentTypeCompare(dice1, dice2);
        }

        private static int DifferentTypeCompare(Dice dice1, Dice dice2)
        {
            return (int)dice1.Type - (int)dice2.Type;
        }

        private static int SameTypeCompare(Dice dice1, Dice dice2)
        {
            return GetComparer(dice1).Compare(dice1, dice2);
        }

        private static readonly Dictionary<DiceType, IComparer<Dice>> diceSameTypeComparers = new Dictionary<DiceType, IComparer<Dice>>()
        {
            {DiceType.Same, new SameResultComparer() },
            {DiceType.Points, new PointsResultComparer() },
            {DiceType.NoPoint, new NoPointResultComparer() },
        };

        private static IComparer<Dice> GetComparer(Dice dice1)
        {
            return diceSameTypeComparers[dice1.Type];
        }
    }
}