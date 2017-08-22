using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibala_2
{
    public enum DiceType {
        Same,
        Points,
        NoPoint
    }
    public class DiceResult
    {
        public int points { get; set; }
        public DiceType type { get; set; }


        public int Compare(DiceResult dice1, DiceResult dice2) {

            return 1;
        }
    }
}
