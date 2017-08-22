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
        [TestCase("1,2,3,4", ExpectedResult = "NoPoint")]
        public string BasicTest(string inputString)
        {
            var dice = new Dice(inputString);

            var actualResult = dice.calculat();

            return actualResult;
        }
    }
}