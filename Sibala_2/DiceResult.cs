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
        public int Points { get; set; }

        public DiceType Type { get; set; }

        public int MaxPoint { get; set; }

        private Dictionary<int, int> SamePointWeight = new Dictionary<int, int>
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

            if (result1.Type == result2.Type)
            {
                if (result1.Type == DiceType.Same)
                {
                    var weightOfDice1 = SamePointWeight[result1.Points];
                    var weightOfDice2 = SamePointWeight[result2.Points];

                    return weightOfDice1 - weightOfDice2;
                }
                else if (result1.Type == DiceType.Points)
                {
                    if (result1.Points == result2.Points)
                    {
                        return result1.MaxPoint - result2.MaxPoint;
                    }

                    return result1.Points - result2.Points;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return (int)result1.Type - (int)result2.Type;
            }
        }
    }
}