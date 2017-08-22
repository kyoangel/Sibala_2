using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sibala_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Same_24_BiggerThan_Same_20()
        {
            Dice d1 = new Dice(new int[] { 6, 6, 6, 6 });
            Dice d2 = new Dice(new int[] { 5, 5, 5, 5 });

            DiceResult diceResult = new DiceResult();

            int result = diceResult.Compare(d1, d2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_Same_24_equals_Same_24()
        {
            Dice d1 = new Dice(new int[] { 6, 6, 6, 6 });
            Dice d2 = new Dice(new int[] { 6, 6, 6, 6 });
            DiceResult diceResult = new DiceResult();
        
            int result = diceResult.Compare(d1, d2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Same_4_biggerthan_point_12()
        {
            Dice d1 = new Dice(new int[] { 1, 1, 1, 1 });
            Dice d2 = new Dice(new int[] { 5, 5, 6, 6 });
            DiceResult diceResult = new DiceResult();

            int result = diceResult.Compare(d1, d2);
            Assert.AreEqual(1, result);
        }

    }
}
