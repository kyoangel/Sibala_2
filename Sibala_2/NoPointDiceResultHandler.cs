namespace Sibala_2
{
    internal class NoPointDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.NoPoint;
        }
    }
}