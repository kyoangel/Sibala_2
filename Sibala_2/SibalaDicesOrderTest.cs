using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Sibala_2
{
    [TestFixture]
    public class SibalaDicesOrderTest
    {
        [Test]
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
            input.Reverse();

            var expected = new List<Dice>
            {
                new Dice(new[] {1, 1, 1, 1}),
                new Dice(new[] {4, 4, 4, 4}),
                new Dice(new[] {3, 5, 3, 1}),
                new Dice(new[] {3, 3, 2, 4}),
                new Dice(new[] {1, 2, 3, 4})
            };

            Assert.IsTrue(input[0].dices.SequenceEqual(expected[0].dices));
            Assert.IsTrue(input[1].dices.SequenceEqual(expected[1].dices));
            Assert.IsTrue(input[2].dices.SequenceEqual(expected[2].dices));
            Assert.IsTrue(input[3].dices.SequenceEqual(expected[3].dices));
            Assert.IsTrue(input[4].dices.SequenceEqual(expected[4].dices));
        }
    }
}