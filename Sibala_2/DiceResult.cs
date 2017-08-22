using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Dictionary<int, int> PointConvert = new Dictionary<int, int>
        {
            { 1,6},
            { 4,5},
            { 6,4},
            { 5,3},
            {3,2 },
            {2,1 }
        };

        public int Compare(Dice dice1, Dice dice2)
        {
            DiceResult result1 = dice1.GetResult();
            DiceResult result2 = dice2.GetResult();

            if (result1.type == result2.type)
            {
                if (result1.type == DiceType.Same)
                {
                    var tem1 = PointConvert[result1.points / 4];
                    var tem2 = PointConvert[result2.points / 4];

                    return tem1 > tem2 ? 1 : tem1 == tem2 ? 0 : -1;
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
            return -2;
        }


    }
}
