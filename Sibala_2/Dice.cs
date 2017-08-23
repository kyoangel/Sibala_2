using System.Collections.Generic;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        public List<int> dices;

        public Dice(int[] dices)
        {
            this.dices = dices.ToList();
            Calculate();
        }

        public int MaxPoint { get; set; }
        public string Output { get; set; }
        public int Points { get; set; }
        public DiceType Type { get; set; }

        internal void SetResult()
        {
            var sameDiceMaxCount = dices.GroupBy(x => x).Max(g => g.Count());
            var handler = GetDiceResultHandler(sameDiceMaxCount);
            handler.Handle(this);
        }

        private static IDiceResultHandler GetDiceResultHandler(int sameDiceMaxCount)
        {
            var handlers = new Dictionary<int, IDiceResultHandler>()
            {
                {4, new SamePointResultHandler() },
                {2, new PointsResultHandler() },
                {3, new NoPointResultHandler() },
                {1, new NoPointResultHandler() },
            };
            return handlers[sameDiceMaxCount];
        }

        private void Calculate()
        {
            SetResult();
            SetOutput();
        }

        private string GetNormalPoint(Dictionary<int, string> specialOutput)
        {
            return specialOutput.ContainsKey(this.Points)
                ? specialOutput[this.Points]
                : this.Points + "Point";
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
    }
}