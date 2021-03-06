using System.Collections.Generic;

namespace Sibala_2.Comparers
{
    public class PointComparer : IComparer<Dice>
    {
        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Points == dice2.Points)
            {
                return dice1.MaxPoint - dice2.MaxPoint;
            }
            else
            {
                return dice1.Points - dice2.Points;
            }
        }
    }
}