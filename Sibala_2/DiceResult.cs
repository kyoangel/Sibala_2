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
        public int points { get; set; }
        public DiceType type { get; set; }
        public int maxPoint { get; set; }
    }
}
