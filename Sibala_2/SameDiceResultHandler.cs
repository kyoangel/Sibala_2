using System.Linq;

namespace Sibala_2
{
    internal class SameDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Same;
            dice.Points = dice._dices.Sum();
            dice.MaxPoint = dice._dices.First();
        }
    }
}