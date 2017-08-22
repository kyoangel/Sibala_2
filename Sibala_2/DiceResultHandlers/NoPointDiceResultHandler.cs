namespace Sibala_2.DiceResultHandlers
{
    internal class NoPointDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.NoPoint;
        }
    }
}