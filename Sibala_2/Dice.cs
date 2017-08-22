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
            IDiceResultHandler handler;
            switch (maxCountOfSameDice)
            {
                case 4:
                    handler = new SameDiceResultHandler();
                    break;

                case 2:
                    handler = new PointsDiceResultHandler();
                    break;

                default:
                    handler = new NoPointDiceResultHandler();
                    break;
            }

            handler.Handle(this);
        }
    }

    internal class NoPointDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.NoPoint;
        }
    }

    internal class PointsDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Points;
            var diceGrouping = dice._dices.GroupBy(x => x);
            if (diceGrouping.Count() == 2)
            {
                var maxPoint = dice._dices.Max();
                dice.Points = maxPoint * 2;
                dice.MaxPoint = maxPoint;
            }
            else
            {
                var duplicatePoint = diceGrouping.First(x => x.Count() == 2).Key;
                var dicesOfPoints = dice._dices.Where(x => x != duplicatePoint);
                dice.Points = dicesOfPoints.Sum();
                dice.MaxPoint = dicesOfPoints.Max();
            }
        }
    }

    internal interface IDiceResultHandler
    {
        void Handle(Dice dice);
    }

    internal class SameDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Same;
            dice.Points = dice._dices.Sum();
            dice.MaxPoint = dice._dices.First();
        }
    }
}