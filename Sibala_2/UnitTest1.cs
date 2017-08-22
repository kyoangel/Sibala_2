﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sibala_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Same_24_BiggerThan_Same_20()
        {
            CompareDice(new int[] { 6, 6, 6, 6 }, new int[] { 5, 5, 5, 5 }, 1);
        }

        [TestMethod]
        public void Test_Same_24_equals_Same_24()
        {
            CompareDice(new int[] { 6, 6, 6, 6 }, new int[] { 6, 6, 6, 6 }, 0);
        }

        [TestMethod]
        public void Test_Same_4_biggerthan_point_12()
        {
            CompareDice(new int[] { 1, 1, 1, 1 }, new int[] { 5, 5, 6, 6 }, 1);
        }

        [TestMethod]
        public void Test_point_10_equal_point_10()
        {
            CompareDice(new int[] { 1, 1, 5, 5 }, new int[] { 1, 1, 5, 5 }, 0);
            
        }

        [TestMethod]
        public void Test_point_3_biggerthan_nopoint_0()
        {
            CompareDice(new int[] { 3, 3, 1, 2 }, new int[] { 1, 2, 3, 4 }, 1);

        }



        [TestMethod]
        public void Test_same_1_biggerthan_same_4()
        {
            CompareDice(new int[] { 1, 1, 1, 1 }, new int[] { 4, 4, 4, 4 }, 1);
        }

        [TestMethod]
        public void Test_points_6_biggerThan_points_6()
        {
            CompareDice(new int[] { 1, 1, 5, 1 }, new int[] {4,4,4,2 }, 1);
        }

        private void CompareDice(int[] d1, int[] d2, int expect)
        {
            DiceResult diceResult = new DiceResult();

            int result = diceResult.Compare(new Dice(d1), new Dice(d2));
            Assert.AreEqual(expect, result);
        }

    }
}
