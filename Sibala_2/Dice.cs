using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibala_2
{
    public class Dice
    {
        private List<int> DiceList;

        public Dice(int[] inputString)
        {
            DiceList = inputString.ToList();
        }

        internal string calculat()
        {
            return "NoPoint";
        }

        internal DiceResult GetResult()
        {
            return new DiceResult();
        }
    }
}