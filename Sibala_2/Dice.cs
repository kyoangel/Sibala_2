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

        public List<int> dices;

        public Dice(int[] dices)
        {
            this.dices = dices.ToList();
            Calculate();
        }

        private void Calculate()
        {
            SetResult();
            SetOutput();
        }

        private void SetOutput()
        {
            var specialOutput = new Dictionary<int, string>()
            {
                { 12,"18La"},
                { 3,"BG"}
            };

            this.Output = this.Type == DiceType.Points
                ? GetNormalPoint(specialOutput)
                : this.Type.ToString();
        }

        private string GetNormalPoint(Dictionary<int, string> specialOutput)
        {
            return specialOutput.ContainsKey(this.Points)
                ? specialOutput[this.Points]
                : this.Points + "Point";
        }

        internal void SetResult()
        {
            var diceCount = dices.GroupBy(x => x).Count();
            switch (diceCount)
            {
                case 1:
                    Type = DiceType.Same;
                    Points = dices.Sum();
                    MaxPoint = dices.First();
                    break;

                case 2:
                    if (dices.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        Type = DiceType.NoPoint;
                        Points = 0;
                    }
                    else
                    {
                        Type = DiceType.Points;
                        Points = dices.GroupBy(x => x).Max(s => s.Key) * 2;
                        MaxPoint = dices.Max();
                    }
                    break;

                case 3:

                    Type = DiceType.Points;
                    Points = dices.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    MaxPoint = dices.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key);
                    break;

                default:
                    Type = DiceType.NoPoint;
                    Points = 0;
                    break;
            }
        }
    }
}