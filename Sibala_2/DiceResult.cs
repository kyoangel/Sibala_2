using System.Collections.Generic;

namespace Sibala_2
{
    public enum DiceType
    {
        Same = 10,
        Points = 1,
        NoPoint = 0
    }

    public class DiceResult
    {
        public int points { get; set; }
        public DiceType type { get; set; }
        public int maxPoint { get; set; }

        public Dictionary<int, int> SamePointWeight = new Dictionary<int, int>
        {
            { 4,6},
            { 16,5},
            { 24,4},
            { 20,3},
            { 12,2},
            { 8,1}
        };

        public int Compare(Dice dice1, Dice dice2)
        {
            DiceResult result1 = dice1.GetResult();
            DiceResult result2 = dice2.GetResult();

            if (result1.type == result2.type)
            {
                if (result1.type == DiceType.Same)
                {
                    var weightOfDice1 = SamePointWeight[result1.points];
                    var weightOfDice2 = SamePointWeight[result2.points];

                    return weightOfDice1 - weightOfDice2;
                }

                if (result1.points > result2.points)
                    return 1;
                else if (result1.points == result2.points)
                {
                    return result1.maxPoint > result2.maxPoint ? 1 : result1.maxPoint == result2.maxPoint ? 0 : -1;
                }
                else
                    return -1;
            }
            else
            {
                if ((int)result1.type > (int)result2.type)
                {
                    return 1;
                }
                else
                    return -1;
            }
        }
    }
}