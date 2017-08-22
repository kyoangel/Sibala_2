namespace Sibala_2
{
    public class PointsResultComparer
    {
        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Points == dice2.Points)
            {
                return dice1.MaxPoint - dice2.MaxPoint;
            }

            return dice1.Points - dice2.Points;
        }
    }
}