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
                    this.Type = DiceType.Same;
                    this.Points = this._dices.Sum();
                    this.MaxPoint = this._dices.First();
                    break;

                case 2:
                    this.Type = DiceType.Points;
                    if (diceGrouping.Count() == 2)
                    {
                        this.Points = this._dices.Max() * 2;
                        this.MaxPoint = this._dices.Max();
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
            //switch (diceGrouping.Count())
            //{
            //    case 1:
            //        this.Type = DiceType.Same;
            //        this.Points = _dices.Sum();
            //        this.MaxPoint = _dices.First();
            //        break;

            //    case 2:
            //        if (diceGrouping.Max(x => x.Count()) == 3)
            //        {
            //            this.Type = DiceType.NoPoint;
            //        }
            //        else
            //        {
            //            this.Type = DiceType.Points;
            //            this.Points = diceGrouping.Max(s => s.Key) * 2;
            //            this.MaxPoint = _dices.Max();
            //        }

            //        break;

            //    case 3:
            //        this.Type = DiceType.Points;
            //        this.Points = diceGrouping.Where(g => g.Count() < 2).Sum(s => s.Key);
            //        this.MaxPoint = diceGrouping.Where(g => g.Count() == 1).Max(s => s.Key);
            //        break;

            //    default:
            //        this.Type = DiceType.NoPoint;
            //        break;
            //}
        }
    }
}