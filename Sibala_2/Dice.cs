using System.Collections.Generic;
using System.Linq;

namespace Sibala_2
{
    public class Dice
    {
        private readonly List<int> _dices;

        public Dice(int[] inputString)
        {
            _dices = inputString.ToList();
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
            if (this.Type == DiceType.Points)
            {
                if (this._outputLookup.ContainsKey(this.Points))
                {
                    this.Output = this._outputLookup[this.Points];
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

        private void SetResult()
        {
            var diceCount = _dices.GroupBy(x => x).Count();
            switch (diceCount)
            {
                case 1:
                    this.Type = DiceType.Same;
                    this.Points = _dices.Sum();
                    this.MaxPoint = _dices.First();
                    break;

                case 2:
                    if (_dices.GroupBy(x => x).Max(x => x.Count()) == 3)
                    {
                        this.Type = DiceType.NoPoint;
                    }
                    else
                    {
                        this.Type = DiceType.Points;
                        this.Points = _dices.GroupBy(x => x).Max(s => s.Key) * 2;
                        this.MaxPoint = _dices.Max();
                    }

                    break;

                case 3:
                    this.Type = DiceType.Points;
                    this.Points = _dices.GroupBy(x => x).Where(g => g.Count() < 2).Sum(s => s.Key);
                    this.MaxPoint = _dices.GroupBy(x => x).Where(g => g.Count() == 1).Max(s => s.Key);
                    break;

                default:
                    this.Type = DiceType.NoPoint;
                    break;
            }
        }
    }
}