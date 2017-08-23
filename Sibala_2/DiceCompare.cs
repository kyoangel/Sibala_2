using System.Collections.Generic;
using Sibala_2.Comparers;

namespace Sibala_2
{
    //public class DiceCompare : IComparer<Dice>
    public class DiceCompare : Comparer<Dice>
    {
        public override int Compare(Dice dice1, Dice dice2)
        {
            return dice1.Type == dice2.Type 
                ? GetComparer(dice1).Compare(dice1, dice2) 
                : dice1.Type - dice2.Type;
        }

        private static IComparer<Dice> GetComparer(Dice dice1)
        {
            var comparersLookup = new Dictionary<DiceType, IComparer<Dice>>()
            {
                {DiceType.NoPoint, new NoPointComparer()},
                {DiceType.Same, new SameComparer()},
                {DiceType.Points, new PointComparer()},
            };
           
            return comparersLookup[dice1.Type];
        }
    }
}