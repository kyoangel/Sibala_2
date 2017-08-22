using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Sibala_2
{
    [TestClass]
    public class SibalaDicesOrderTest
    {
        [TestMethod]
        public void OrderTest()
        {
            var input = new List<Dice>
            {
                new Dice(new[] {3, 5, 3, 1}),
                new Dice(new[] {1, 2, 3, 4}),
                new Dice(new[] {3, 3, 2, 4}),
                new Dice(new[] {1, 1, 1, 1}),
                new Dice(new[] {4, 4, 4, 4}),
            };
            var helper = new DiceCompare();
            input.Sort(helper);

            var expected = new List<Dice>
            {
                new Dice(new[] {1, 2, 3, 4}),
                new Dice(new[] {3, 3, 2, 4}),
                new Dice(new[] {3, 5, 3, 1}),
                new Dice(new[] {4, 4, 4, 4}),
                new Dice(new[] {1, 1, 1, 1}),
            };

            Assert.IsTrue(input[0].DiceList.SequenceEqual(expected[0].DiceList));
            Assert.IsTrue(input[1].DiceList.SequenceEqual(expected[1].DiceList));
            Assert.IsTrue(input[2].DiceList.SequenceEqual(expected[2].DiceList));
            Assert.IsTrue(input[3].DiceList.SequenceEqual(expected[3].DiceList));
            Assert.IsTrue(input[4].DiceList.SequenceEqual(expected[4].DiceList));
        }
    }
}