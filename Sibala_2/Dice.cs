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
            var handler = GetDiceResultHandler(sameDiceMaxCount);
            handler.Handle(this);
        }

        private static IDiceResultHandler GetDiceResultHandler(int sameDiceMaxCount)
        {
            switch (sameDiceMaxCount)
            {
                case 4:
                    return new SamePointResultHandler();

                case 2:
                    return new PointsResultHandler();

                default:
                    return new NoPointResultHandler();
            }
        }
    }

    internal class NoPointResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.NoPoint;
        }
    }

    internal class PointsResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Points;
            var diceGroups = dice.dices.GroupBy(x => x);
            if (diceGroups.Count() == 2)
            {
                dice.Points = diceGroups.Max(s => s.Key) * 2;
                dice.MaxPoint = dice.dices.Max();
            }
            else
            {
                var duplicateNumber = diceGroups.First(x => x.Count() == 2).Key;
                var dicesOfPoints = dice.dices.Where(x => x != duplicateNumber);

                dice.Points = dicesOfPoints.Sum();
                dice.MaxPoint = dicesOfPoints.Max();
            }
        }
    }

    internal interface IDiceResultHandler
    {
        void Handle(Dice dice);
    }

    internal class SamePointResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Same;
            dice.Points = dice.dices.Sum();
            dice.MaxPoint = dice.dices.First();
        }
    }
}