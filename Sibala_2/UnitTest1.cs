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
            DiceResult DiceResult = new DiceResult();
            int[] same6 = new int[4] { 6,6,6,6};
            int[] same5 = new int[4] { 5, 5, 5, 5 };
            Dice d1 = new Dice(same6);
            Dice d2 = new Dice(same5);
            int result =DiceResult.Compare(d1,d2);
            Assert.AreEqual(1, result);
            //var diceResult = [6, 6, 6, 6];
        }
        
    }
}
