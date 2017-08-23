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
            var diceGroups = dices.GroupBy(x => x);
            var sameDiceMaxCount = diceGroups.Max(g => g.Count());
            switch (sameDiceMaxCount)
            {
                case 4:
                    Type = DiceType.Same;
                    Points = dices.Sum();
                    MaxPoint = dices.First();
                    break;
                case 2:
                    Type = DiceType.Points;
                    if (diceGroups.Count() == 2)
                    {
                        Points = diceGroups.Max(s => s.Key) * 2;
                        MaxPoint = dices.Max();
                    }
                    else
                    {
                        var duplicateNumber = diceGroups.First(x => x.Count() == 2).Key;
                        var dicesOfPoints = this.dices.Where(x => x != duplicateNumber);

                        Points = dicesOfPoints.Sum();
                        MaxPoint = dicesOfPoints.Max();
                    }
                    break;
                default:
                    Type = DiceType.NoPoint;
                    break;
            }
        }
    }
}