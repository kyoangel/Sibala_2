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

            if (result.Type == DiceType.Points)
            {
                if (result.Points == 12) return "18La";
                if (result.Points == 3) return "BG";
                return result.Points + "Point";
            }
            return result.Type.ToString();
        }

        internal DiceResult GetResult()
        {
            var diceCount = DiceList.GroupBy(x => x).Count();
            switch (diceCount)
            {
                case 1:
                    return new DiceResult
                    {
                        Type = DiceType.Same,
                        Points = DiceList.Sum(),
                        MaxPoint = DiceList.Sum() / 4
                    };

                case 2:
                    if (DiceList.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        return new DiceResult
                        {
                            Type = DiceType.NoPoint,
                            Points = 0
                        };
                    }
                    return new DiceResult
                    {
                        Type = DiceType.Points,
                        Points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2,
                        MaxPoint = DiceList.Max()
                    };

                case 3:
                    return new DiceResult
                    {
                        Type = DiceType.Points,
                        Points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key),
                        MaxPoint = DiceList.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key)
                    };

                default:
                    return new DiceResult
                    {
                        Type = DiceType.NoPoint,
                        Points = 0
                    };
            }
        }
    }
}