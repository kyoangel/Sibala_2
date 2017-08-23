namespace Sibala_2
{
    public enum DiceType
    {
        Same = 10,
        Points = 1,
        NoPoint = 0
    }

    public class DiceResult
    {
        public int Points { get; set; }
        public DiceType Type { get; set; }
        public int MaxPoint { get; set; }
    }
}
