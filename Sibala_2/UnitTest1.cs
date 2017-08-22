using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Sibala_2
{
    [TestFixture()]
    public class UnitTest1
    {
        [Test]
        public void Test_Same_24_BiggerThan_Same_20()
        {
            FirstDiceShouldBeLarger(new Dice(new[] { 6, 6, 6, 6 }), new Dice(new[] { 5, 5, 5, 5 }));
        }

        [Test]
        public void Test_Same_24_equals_Same_24()
        {
            int[] d1 = new int[] { 6, 6, 6, 6 };
            int[] d2 = new int[] { 6, 6, 6, 6 };
            FirstDiceShouldEqualsSecondDice(new Dice(d1), new Dice(d2));
        }

        [Test]
        public void Test_Same_4_biggerthan_point_12()
        {
            FirstDiceShouldBeLarger(new Dice(new int[] { 1, 1, 1, 1 }), new Dice(new[] { 5, 5, 6, 6 }));
        }

        [Test]
        public void Test_point_10_equal_point_10()
        {
            int[] d1 = new int[] { 1, 1, 5, 5 };
            int[] d2 = new int[] { 1, 1, 5, 5 };
            FirstDiceShouldEqualsSecondDice(new Dice(d1), new Dice(d2));
        }

        [Test]
        public void Test_point_3_biggerthan_nopoint_0()
        {
            FirstDiceShouldBeLarger(new Dice(new[] { 3, 3, 1, 2 }), new Dice(new[] { 1, 2, 3, 4 }));
        }

        [Test]
        public void Test_same_1_biggerthan_same_4()
        {
            FirstDiceShouldBeLarger(new Dice(new[] { 1, 1, 1, 1 }), new Dice(new[] { 4, 4, 4, 4 }));
        }

        [Test]
        public void Test_points_6_biggerThan_points_6()
        {
            FirstDiceShouldBeLarger(new Dice(new int[] { 2, 2, 5, 1 }), new Dice(new int[] { 3, 3, 4, 2 }));
        }

        private void FirstDiceShouldBeLarger(Dice dice1, Dice dice2)
        {
            Assert.IsTrue(new DiceResult().Compare(dice1, dice2) > 0);
        }

        private void FirstDiceShouldEqualsSecondDice(Dice dice1, Dice dice2)
        {
            Assert.IsTrue(new DiceResult().Compare(dice1, dice2) == 0);
        }
    }
}