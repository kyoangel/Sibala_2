using System.Collections.Generic;

namespace Sibala_2
{
    public class SameComparer : IComparer<Dice>
    {
        private Dictionary<int, int> weightLookup = new Dictionary<int, int>
        {
            {4, 6},
            {16, 5},
            {24, 4},
            {20, 3},
            {12, 2},
            {8, 1}
        };

        public int Compare(Dice dice1, Dice dice2)
        {
            var weightOfDice1 = weightLookup[dice1.Points];
            var weightOfDice2 = weightLookup[dice2.Points];

            return weightOfDice1 - weightOfDice2;
        }
    }
}