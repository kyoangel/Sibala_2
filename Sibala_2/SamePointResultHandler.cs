using System.Linq;

namespace Sibala_2
{
    internal class SamePointResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Same;
            dice.Points = dice.dices.Sum();
            dice.MaxPoint = dice.dices.First();
        }
    }
}