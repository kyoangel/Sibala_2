using System.Collections.Generic;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        private List<int> DiceList;

        public Dice(int[] inputString)
        {
            DiceList = inputString.ToList();
        }

        internal string calculat()
        {
            var diceCount = DiceList.GroupBy(x => x).Count();
            var points = 0;
            switch (diceCount)
            {
                case 1:
                    return "Same";

                case 2:
                    points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2;
                    return points.ToString() + "Point";

                case 3:
                    points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    return points.ToString() + "Point";

                case 4:
                    return "NoPoint";

                default:
                    return "NoPoint";
            }
        }

        internal DiceResult GetResult()
        {
            return new DiceResult();
        }
    }
}