using System.Collections.Generic;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        public int Points { get; set; }
        public DiceType Type { get; set; }
        public int MaxPoint { get; set; }
        public string Output { get; set; }

        public List<int> DiceList;

        public Dice(int[] inputString)
        {
            DiceList = inputString.ToList();
            Calculate();
        }

        private void Calculate()
        {
            SetResult();
            SetOutput();
        }

        private void SetOutput()
        {
            if (this.Type == DiceType.Points)
            {
                if (this.Points == 12) this.Output = "18La";
                else if (this.Points == 3) this.Output = "BG";
                else
                {
                    this.Output = this.Points + "Point";
                }
            }
            else
            {
                this.Output = this.Type.ToString();
            }
        }

        internal void SetResult()
        {
            var diceCount = DiceList.GroupBy(x => x).Count();
            switch (diceCount)
            {
                case 1:
                    Type = DiceType.Same;
                    Points = DiceList.Sum();
                    MaxPoint = DiceList.Sum() / 4;
                    break;

                case 2:
                    if (DiceList.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        Type = DiceType.NoPoint;
                        Points = 0;
                    }
                    else
                    {
                        Type = DiceType.Points;
                        Points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2;
                        MaxPoint = DiceList.Max();
                    }
                    break;

                case 3:

                    Type = DiceType.Points;
                    Points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    MaxPoint = DiceList.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key);
                    break;

                default:
                    Type = DiceType.NoPoint;
                    Points = 0;
                    break;

            }
        }
    }
}