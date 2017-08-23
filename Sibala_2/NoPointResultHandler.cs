namespace Sibala_2
{
    internal class NoPointResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.NoPoint;
        }
    }
}