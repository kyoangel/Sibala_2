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
        [TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = "NoPoint")]
        [TestCase(new[] { 1, 1, 1, 1 }, ExpectedResult = "Same")]
        [TestCase(new[] { 2, 2, 3, 4 }, ExpectedResult = "7Point")]
        [TestCase(new[] { 2, 2, 1, 1 }, ExpectedResult = "4Point")]
        [TestCase(new[] { 1, 1, 1, 2 }, ExpectedResult = "NoPoint")]
        public string BasicTest(int[] dices)
        {
            var dice = new Dice(dices);

            var actualResult = dice.Calculate();

            return actualResult;
        }
    }
}