using System.Linq;

namespace Sibala_2
{
    internal class PointsResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Points;
            var diceGroups = dice.dices.GroupBy(x => x);
            if (diceGroups.Count() == 2)
            {
                dice.Points = diceGroups.Max(s => s.Key) * 2;
                dice.MaxPoint = dice.dices.Max();
            }
            else
            {
                var duplicateNumber = diceGroups.First(x => x.Count() == 2).Key;
                var dicesOfPoints = dice.dices.Where(x => x != duplicateNumber);

                dice.Points = dicesOfPoints.Sum();
                dice.MaxPoint = dicesOfPoints.Max();
            }
        }
    }
}