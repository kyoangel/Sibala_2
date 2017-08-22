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
        int points { get; set; }
        DiceType type { get; set; }

    }
}
