using System.Collections.Generic;

namespace Sibala_2
{
    public class DiceCompare : IComparer<Dice>
    {
        public Dictionary<int, int> PointConvert = new Dictionary<int, int>
        {
            {1, 6},
            {4, 5},
            {6, 4},
            {5, 3},
            {3, 2},
            {2, 1}
        };

        public int Compare(Dice dice1, Dice dice2)
        {
            DiceResult result1 = dice1.GetResult();
            DiceResult result2 = dice2.GetResult();

            if (result1.type == result2.type)
            {
                if (result1.type == DiceType.Same)
                {
                    var temp1 = PointConvert[result1.points / 4];
                    var temp2 = PointConvert[result2.points / 4];

                    return temp1 - temp2;
                }
                else if (result1.type == DiceType.Points)
                {
                    if (result1.points == result2.points)
                    {
                        return result1.maxPoint - result2.maxPoint;
                    }
                    else
                    {
                        return result1.points - result2.points;
                    }
                }
                else
                {// no point
                    return 0;
                }
            }
            else if (result1.type > result2.type)
            {
                return 1;
            }
            else
            {// type1 < type2
                return -1;
            }

        }
    }
}
