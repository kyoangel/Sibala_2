using NUnit.Framework;

namespace Sibala_2
{
    [TestFixture]
    public class SibalaCompareDiceTest
    {
        [Test]
        public void Test_Same_24_BiggerThan_Same_20()
        {
            FirstDiceShouldBiggerThanSecond(new Dice(new[] { 6, 6, 6, 6 }), new Dice(new[] { 5, 5, 5, 5 }));
        }

        [Test]
        public void Test_Same_24_equals_Same_24()
        {
            FirstDiceShouldEqualSecond(new Dice(new[] { 6, 6, 6, 6 }), new Dice(new[] { 6, 6, 6, 6 }));
        }

        [Test]
        public void Test_Same_4_biggerthan_point_12()
        {
            FirstDiceShouldBiggerThanSecond(new Dice(new[] { 1, 1, 1, 1 }), new Dice(new[] { 5, 5, 6, 6 }));
        }

        [Test]
        public void Test_point_10_equal_point_10()
        {
            FirstDiceShouldEqualSecond(new Dice(new[] { 1, 1, 5, 5 }), new Dice(new[] { 2, 2, 5, 5 }));
        }

        [Test]
        public void Test_point_3_biggerthan_nopoint_0()
        {
            FirstDiceShouldBiggerThanSecond(new Dice(new[] { 3, 3, 1, 2 }), new Dice(new[] { 1, 2, 3, 4 }));
        }

        private void FirstDiceShouldBiggerThanSecond(Dice dice1, Dice dice2)
        {
            var helper = new DiceCompare();
            int result = helper.Compare(dice1, dice2);
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void Test_same_1_biggerthan_same_4()
        {
            FirstDiceShouldBiggerThanSecond(new Dice(new[] { 1, 1, 1, 1 }), new Dice(new[] { 4, 4, 4, 4 }));
        }

        [Test]
        public void Test_1151_points_equal_4442_points()
        {
            FirstDiceShouldEqualSecond(new Dice(new[] { 1, 1, 5, 1 }), new Dice(new[] { 4, 4, 4, 2 }));
        }

        private void FirstDiceShouldEqualSecond(Dice dice1, Dice dice2)
        {
            var result = new DiceCompare().Compare(dice1, dice2);
            Assert.IsTrue(result == 0);
        }

        private void CompareDice(int[] d1, int[] d2, int expect)
        {
            var helper = new DiceCompare();
            int result = helper.Compare(new Dice(d1), new Dice(d2));
            Assert.AreEqual(expect, result);
        }
    }
}