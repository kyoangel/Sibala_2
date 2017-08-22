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
            this.Calculate();
        }

        public int MaxPoint { get; set; }

        public int Points { get; set; }

        public DiceType Type { get; set; }

        private void Calculate()
        {
            SetResult();

            var diceCount = DiceList.GroupBy(x => x).Count();

            if (this.Type == DiceType.Points)
            {
                if (this.Points == 12)
                {
                    this.Output = "18La";
                }
                else if (this.Points == 3)
                {
                    this.Output = "BG";
                }
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

        public string Output { get; set; }

        internal void SetResult()
        {
            var diceCount = DiceList.GroupBy(x => x).Count();
            switch (diceCount)
            {
                case 1:
                    this.Type = DiceType.Same;
                    this.Points = DiceList.Sum();
                    this.MaxPoint = DiceList.Sum() / 4;
                    break;

                case 2:
                    if (DiceList.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        this.Type = DiceType.NoPoint;
                        this.Points = 0;
                    }
                    else
                    {
                        this.Type = DiceType.Points;
                        this.Points = DiceList.GroupBy(x => x).Max(s => s.Key) * 2;
                        MaxPoint = DiceList.Max();
                    }

                    break;

                case 3:
                    this.Type = DiceType.Points;
                    this.Points = DiceList.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    this.MaxPoint = DiceList.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key);
                    break;

                default:
                    this.Type = DiceType.NoPoint;
                    Points = 0;
                    break;
            }
        }
    }
}