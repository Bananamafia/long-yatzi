using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LongYatzi;
using System.Diagnostics;

namespace LongYatziUnitTests
{
    [TestClass]
    public class DiceUnitTest
    {
        #region pair unit tests
        [TestMethod]
        public void ValidatePair_2() //should return 2 as biggest possible pair is 2.
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(5);
            Assert.AreEqual(2, dice.ValidatePair());
        }
        [TestMethod]
        public void ValidatePair_6() //should return 2 as biggest possible pair is 6.
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(3);
            dice.AddDie(3);
            Assert.AreEqual(6, dice.ValidatePair());
        }
        [TestMethod]
        public void ValidatePair_0() //should return 0 as no pair is found
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            Assert.AreEqual(0, dice.ValidatePair());
        }
        #endregion
        #region two pairs unit tests
        [TestMethod]
        public void ValidateTwoPairs_6() //should return 0 as no pair was found
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(2);
            Assert.AreEqual(6, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_0_0() //should return 0 as no pair was found
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            Assert.AreEqual(0, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_0() //should return 0 as only one pair is found
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(5);
            dice.AddDie(5);
            Assert.AreEqual(0, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_10() //should return 10 (2*2 + 2*3)
        {
            Dice dice = new Dice();
            dice.AddDie(2);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(3);
            dice.AddDie(5);
            Assert.AreEqual(10, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_8() //should return 8 cause 4*2
        {
            Dice dice = new Dice();
            dice.AddDie(2);
            dice.AddDie(2);
            dice.AddDie(2);
            dice.AddDie(2);
            dice.AddDie(5);
            Assert.AreEqual(8, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_24() //should return 24 
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(24, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_8_2() //should return 8 
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(3);
            dice.AddDie(3);
            Assert.AreEqual(8, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_8_3() //should return 8 
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(3);
            Assert.AreEqual(8, dice.ValidateTwoPairs());
        }
        [TestMethod]
        public void ValidateTwoPairs_0_2() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(3);
            dice.AddDie(1);
            Assert.AreEqual(0, dice.ValidateTwoPairs());
        }
        //End Test Methods for Validating Two Pairs
        #endregion
        #region Yatzy unit tests
        [TestMethod]
        public void ValidateYatzy_50() //should return 50 as all are same
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            Assert.AreEqual(50, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_50_6() //should return 50 as all are same
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(50, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_0() //should return 0 as all are not same
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_0_2() //should return 0 as all are not same
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(1);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_0_3() //should return 0 as all are not same
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(1);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_0_4() //should return 0 as all are not same
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(1);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateYatzy());
        }
        [TestMethod]
        public void ValidateYatzy_0_5() //should return 0 as all are not same
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(1);
            Assert.AreEqual(0, dice.ValidateYatzy());
        }
        [TestMethod]
        #endregion
        #region small straight unit tests
        public void ValidateSmallStraight_0() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateSmallStraight());
        }
        [TestMethod]
        public void ValidateSmallStraight_15() //should return 15
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            Assert.AreEqual(15, dice.ValidateSmallStraight());
        }
        [TestMethod]
        public void ValidateSmallStraight_15_2() //should return 15
        {
            Dice dice = new Dice();
            dice.AddDie(2);
            dice.AddDie(1);
            dice.AddDie(3);
            dice.AddDie(5);
            dice.AddDie(4);
            Assert.AreEqual(15, dice.ValidateSmallStraight());
        }
        #endregion
        #region big straight unit tests
        [TestMethod]
        public void ValidateBigStraight_20() //should return 15
        {
            Dice dice = new Dice();
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            dice.AddDie(6);
            Assert.AreEqual(20, dice.ValidateBigStraight());
        }
        [TestMethod]
        public void ValidateBigStraight_20_2() //should return 15
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            dice.AddDie(2);
            Assert.AreEqual(20, dice.ValidateBigStraight());
        }
        #endregion
        #region four same unit tests
        [TestMethod]
        public void ValidateFourSame_16() //should return 16 
        {
            Dice dice = new Dice();
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(6);
            Assert.AreEqual(16, dice.ValidateFourSame());
        }
        [TestMethod]
        public void ValidateFourSame_16_2() //should return 16 
        {
            Dice dice = new Dice();
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            Assert.AreEqual(16, dice.ValidateFourSame());
        }
        [TestMethod]
        public void ValidateFourSame_0() //should return 16 
        {
            Dice dice = new Dice();
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(1);
            dice.AddDie(6);
            Assert.AreEqual(0, dice.ValidateFourSame());
        }
        [TestMethod]
        public void ValidateFourSame_24() //should return 24
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(24, dice.ValidateFourSame());
        }
        #endregion
        #region three same unit tests
        [TestMethod]
        public void ValidateThreeSame_0() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(3);
            dice.AddDie(2);
            Assert.AreEqual(0, dice.ValidateThreeSame());
        }
        [TestMethod]
        public void ValidateThreeSame_3() //should return 3
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(3);
            dice.AddDie(1);
            Assert.AreEqual(3, dice.ValidateThreeSame());
        }
        [TestMethod]
        public void ValidateThreeSame_18() //should return 18
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(3);
            dice.AddDie(6);
            Assert.AreEqual(18, dice.ValidateThreeSame());
        }
        [TestMethod]
        public void ValidateThreeSame_18_2() //should return 18
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(18, dice.ValidateThreeSame());
        }
        #endregion
        #region full house unit tests
        [TestMethod]
        public void ValidateFullHouse_20() //should return 20
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(1);
            dice.AddDie(6);
            dice.AddDie(1);
            Assert.AreEqual(20, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_24() //should return 24
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            Assert.AreEqual(24, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_5() //should return 5
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            dice.AddDie(1);
            Assert.AreEqual(5, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_30() //should return 30
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(6);
            Assert.AreEqual(30, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_0() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(6);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(3);
            Assert.AreEqual(0, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_0_2() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(4);
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(4);
            Assert.AreEqual(0, dice.ValidateFullHouse());
        }
        [TestMethod]
        public void ValidateFullHouse_0_3() //should return 0
        {
            Dice dice = new Dice();
            dice.AddDie(6);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            dice.AddDie(4);
            Assert.AreEqual(0, dice.ValidateFullHouse());
        }
        #endregion
        #region sum unit tests
        [TestMethod]
        public void ValidateSum() //should return 15
        {
            Dice dice = new Dice();
            dice.AddDie(1);
            dice.AddDie(2);
            dice.AddDie(3);
            dice.AddDie(4);
            dice.AddDie(5);
            Assert.AreEqual(15, dice.Sum());
        }
        #endregion
    }
}
