using System.Collections.Generic;
using System.Linq;

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
            if (DiceList.GroupBy(x => x).Count() == 1)
            {
                return "Same";
            }

            return "NoPoint";
        }

        internal DiceResult GetResult()
        {
            return new DiceResult();
        }
    }
}