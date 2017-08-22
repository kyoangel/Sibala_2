using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sibala_2.DiceResultHandlers;

namespace Sibala_2
{
    internal interface IDiceResultHandler
    {
        void Handle(Dice dice);
    }

    public class Dice
    {
        public readonly ReadOnlyCollection<int> _dices;

        private Dictionary<int, string> _outputLookup = new Dictionary<int, string>
        {
            {12, "18La" },
            {3,  "BG"}
        };

        private Dictionary<int, IDiceResultHandler> handlersLookup = new Dictionary<int, IDiceResultHandler>()
        {
            {4, new SameDiceResultHandler()},
            {2, new PointsDiceResultHandler()},
            {3, new NoPointDiceResultHandler()},
            {1, new NoPointDiceResultHandler()},
        };

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

        private string GetOutputWhenPoints()
        {
            var isSpecialOutput = this._outputLookup.ContainsKey(this.Points);
            return isSpecialOutput ? this._outputLookup[this.Points] : this.Points + "Point";
        }

        private void SetOutput()
        {
            var isTypePoints = this.Type == DiceType.Points;
            this.Output = isTypePoints ? GetOutputWhenPoints() : this.Type.ToString();
        }

        private void SetResult()
        {
            var maxCountOfSameDice = _dices.GroupBy(x => x).Max(x => x.Count());
            var handler = this.handlersLookup[maxCountOfSameDice];
            handler.Handle(this);
        }
    }
}