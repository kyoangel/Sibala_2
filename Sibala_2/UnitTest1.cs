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
            DiceResult DiceResult1 = new DiceResult
            {
                points = 24,
                type = DiceType.Same
            };

            DiceResult DiceResult2 = new DiceResult
            {
                points = 20,
                type = DiceType.Same
            };
            DiceResult diceResult = new DiceResult();

            int result = diceResult.Compare(DiceResult1, DiceResult2);
            Assert.AreEqual(1, result);
            //var diceResult = [6, 6, 6, 6];
        }
        
    }
}
