using System.Collections.Generic;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        public List<int> DiceList;

        public Dice(int[] inputString)
        {
            DiceList = inputString.ToList();
        }

        internal string Calculate()
        {
            var result = GetResult();

            var diceCount = DiceList.GroupBy(x => x).Count();

            if (result.type == DiceType.Points)
            {
                if (result.points == 12) return "18La";
                if (result.points == 3) return "BG";
                return result.points + "Point";
            }
            return result.type.ToString();
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
                        points = DiceList.Sum(),
                        maxPoint = DiceList.Sum() / 4
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
                        points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2,
                        maxPoint = DiceList.Max()
                    };

                case 3:
                    points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    return new DiceResult
                    {
                        type = DiceType.Points,
                        points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key),
                        maxPoint = DiceList.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key)
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