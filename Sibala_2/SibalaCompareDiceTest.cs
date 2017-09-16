using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Sibala_2
{

    [TestClass]
    public class SibalaCompareDiceTest
    {
        [Test]
        public void Test_Same_1_BiggerThan_Same_4()
        {
            FirstBiggerThanSecond(new int[] { 1, 1, 1, 1 }, new int[] { 4, 4, 4, 4 });
        }

        [Test]
        public void Test_Same_24_equals_Same_24()
        {
            FirstEqualsToSecond(new int[] { 6, 6, 6, 6 }, new int[] { 6, 6, 6, 6 });
        }

        [Test]
        public void Test_Same_4_biggerthan_point_12()
        {
            FirstBiggerThanSecond(new int[] { 1, 1, 1, 1 }, new int[] { 5, 5, 6, 6 });
        }

        [Test]
        public void Test_point_10_equal_point_10()
        {
            FirstEqualsToSecond(new int[] { 1, 1, 5, 5 }, new int[] { 1, 1, 5, 5 });
        }

        [Test]
        public void Test_point_3_biggerthan_nopoint_0()
        {
            FirstBiggerThanSecond(new int[] { 3, 3, 1, 2 }, new int[] { 1, 2, 3, 4 });
        }


        [TestMethod]
        public void Test_same_1_biggerthan_same_4()
        {
            FirstBiggerThanSecond(new int[] { 1, 1, 1, 1 }, new int[] { 4, 4, 4, 4 });
        }

        [Test]
        public void Test_No_points_6_equals_No_points_6()
        {
            FirstEqualsToSecond(new int[] { 1, 1, 5, 1 }, new int[] { 4, 4, 4, 2 });
        }

        private void FirstBiggerThanSecond(int[] d1, int[] d2)
        {
            var helper = new DiceCompare();
            int result = helper.Compare(new Dice(d1), new Dice(d2));
            Assert.IsTrue(result>0);
        }

        private void FirstEqualsToSecond(int[] d1, int[] d2)
        {
            var helper = new DiceCompare();
            int result = helper.Compare(new Dice(d1), new Dice(d2));
            Assert.IsTrue(result == 0);
        }
    }
}