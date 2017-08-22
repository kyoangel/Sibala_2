using NUnit.Framework;

namespace Sibala_2
{
    [TestFixture]
    public class SibalaTests
    {
        [TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = "NoPoint")]
        [TestCase(new[] { 1, 1, 1, 1 }, ExpectedResult = "Same")]
        [TestCase(new[] { 2, 2, 3, 4 }, ExpectedResult = "7Point")]
        [TestCase(new[] { 2, 2, 1, 1 }, ExpectedResult = "4Point")]
        [TestCase(new[] { 1, 1, 1, 2 }, ExpectedResult = "NoPoint")]
        [TestCase(new[] { 1, 1, 6, 6 }, ExpectedResult = "18La")]
        [TestCase(new[] { 3, 3, 1, 2 }, ExpectedResult = "BG")]
        public string BasicTest(int[] dices)
        {
            var dice = new Dice(dices);

            var actualResult = dice.Calculate();

            return actualResult;
        }

        [TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = 0)]
        [TestCase(new[] { 1, 1, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 2, 2, 3, 4 }, ExpectedResult = 4)]
        [TestCase(new[] { 2, 2, 1, 1 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 1, 1, 2 }, ExpectedResult = 0)]
        [TestCase(new[] { 1, 1, 6, 6 }, ExpectedResult = 6)]
        [TestCase(new[] { 3, 3, 1, 2 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 1, 3, 4 }, ExpectedResult = 4)]
        [TestCase(new[] { 1, 1, 5, 1 }, ExpectedResult = 0)]
        public int MaxPointTest(int[] dices)
        {
            var dice = new Dice(dices);

            var actualResult = dice.GetResult();

            return actualResult.maxPoint;
        }
    }
}