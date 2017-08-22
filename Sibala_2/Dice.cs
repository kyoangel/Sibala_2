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

        internal string Calculate()
        {
            var result = GetResult();

            var diceCount = DiceList.GroupBy(x => x).Count();
            var points = 0;
            switch (diceCount)
            {
                case 1:
                    return "Same";

                case 2:
                    if (DiceList.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        return "NoPoint";
                    }
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
            var diceCount = DiceList.GroupBy(x => x).Count();
            var points = 0;
            switch (diceCount)
            {
                case 1:
                    return new DiceResult
                    {
                        type = DiceType.Same,
                        points = DiceList.Sum()
                    };

                case 2:
                    if (DiceList.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        return new DiceResult
                        {
                            type = DiceType.NoPoint,
                            points = 0
                        };
                    }
                    points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2;
                    return new DiceResult
                    {
                        type = DiceType.Points,
                        points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2
                    };

                case 3:
                    points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    return new DiceResult
                    {
                        type = DiceType.Points,
                        points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key)
                    };

                case 4:
                    return new DiceResult
                    {
                        type = DiceType.NoPoint,
                        points = 0
                    };

                default:
                    return new DiceResult
                    {
                        type = DiceType.NoPoint,
                        points = 0
                    };
            }
        }
    }
}