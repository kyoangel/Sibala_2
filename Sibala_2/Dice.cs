using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        public readonly ReadOnlyCollection<int> _dices;

        public Dice(int[] inputString)
        {
            _dices = new ReadOnlyCollection<int>(inputString);
            this.Calculate();
        }

        public int MaxPoint { get; set; }

        public string Output { get; set; }

        public int Points { get; set; }

        public DiceType Type { get; set; }

        private void Calculate()
        {
            SetResult();

            SetOutput();
        }

        private Dictionary<int, string> _outputLookup = new Dictionary<int, string>
        {
            {12, "18La" },
            {3,  "BG"}
        };

        private void SetOutput()
        {
            var isTypePoints = this.Type == DiceType.Points;
            this.Output = isTypePoints ? GetOutputWhenPoints() : this.Type.ToString();
        }

        private string GetOutputWhenPoints()
        {
            var isSpecialOutput = this._outputLookup.ContainsKey(this.Points);
            return isSpecialOutput ? this._outputLookup[this.Points] : this.Points + "Point";
        }

        private void SetResult()
        {
            var diceGrouping = _dices.GroupBy(x => x);
            var maxCountOfSameDice = diceGrouping.Max(x => x.Count());
            switch (maxCountOfSameDice)
            {
                case 4:
                    var sameDiceResultHandler = new SameDiceResultHandler();
                    sameDiceResultHandler.Handle(this);

                    break;

                case 2:
                    this.Type = DiceType.Points;
                    if (diceGrouping.Count() == 2)
                    {
                        var maxPoint = this._dices.Max();
                        this.Points = maxPoint * 2;
                        this.MaxPoint = maxPoint;
                    }
                    else
                    {
                        var duplicatePoint = diceGrouping.First(x => x.Count() == 2).Key;
                        var dicesOfPoints = this._dices.Where(x => x != duplicatePoint);
                        this.Points = dicesOfPoints.Sum();
                        this.MaxPoint = dicesOfPoints.Max();
                    }

                    break;

                default:
                    this.Type = DiceType.NoPoint;
                    break;
            }
        }
    }

    internal class SameDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Same;
            dice.Points = dice._dices.Sum();
            dice.MaxPoint = dice._dices.First();
        }
    }
}