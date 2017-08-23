using System.Collections.Generic;

namespace Sibala_2
{
    public class DiceCompare : IComparer<Dice>
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
            DiceResult result1 = dice1.GetResult();
            DiceResult result2 = dice2.GetResult();

            if (result1.Type == result2.Type)
            {
                if (result1.Type == DiceType.Same)
                {
                    var weightOfDice1 = weightLookup[result1.Points];
                    var weightOfDice2 = weightLookup[result2.Points];

                    return weightOfDice1 - weightOfDice2;
                }
                else if (result1.Type == DiceType.Points)
                {
                    if (result1.Points == result2.Points)
                    {
                        return result1.MaxPoint - result2.MaxPoint;
                    }
                    else
                    {
                        return result1.Points - result2.Points;
                    }
                }
                else
                {
                    return 0;
                }
                
            }
            return result1.Type - result2.Type;
        }
    }
}