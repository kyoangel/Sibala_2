using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sibala_2
{
    [TestFixture]
    public class SibalaTests
    {
        [Test]
        [TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = "NoPoint")]
        public string BasicTest(int[] dices)
        {
            var dice = new Dice(dices);

            var actualResult = dice.calculat();

            return actualResult;
        }
    }
}