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
            //DiceResult result1 = dice1.GetResult();
            //DiceResult result2 = dice2.GetResult();



            if (dice1.Type == dice2.Type)
            {
                if (dice1.Type == DiceType.Same)
                {
                    var weightOfDice1 = weightLookup[dice1.Points];
                    var weightOfDice2 = weightLookup[dice2.Points];

                    return weightOfDice1 - weightOfDice2;
                }
                else if (dice1.Type == DiceType.Points)
                {
                    if (dice1.Points == dice2.Points)
                    {
                        return dice1.MaxPoint - dice2.MaxPoint;
                    }
                    else
                    {
                        return dice1.Points - dice2.Points;
                    }
                }
                else
                {
                    return 0;
                }
                
            }
            return dice1.Type - dice2.Type;
        }
    }
}