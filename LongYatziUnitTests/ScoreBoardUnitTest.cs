using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LongYatzi;

namespace LongYatziUnitTests
{
    [TestClass]
    public class ScoreBoardUnitTest
    {
        #region UpperSectionTotal
        [TestMethod]
        public void UpperSectionTotal_5()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.upperSection = new int?[,] { { 1, 1,null,1,1,1}, { 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1 } };
            Assert.AreEqual(5,scoreBoard.UpperSectionTotal(0));
        }
        [TestMethod]
        public void UpperSectionTotal_10()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.upperSection = new int?[4, 6];
            scoreBoard.StoreScoreUp(4, 1, 3);
            scoreBoard.StoreScoreUp(4, 2, 7);
            Assert.AreEqual(10,scoreBoard.UpperSectionTotal(3));
        }
        [TestMethod]
        public void UpperSectionTotal_7()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.upperSection = new int?[4, 6];
            scoreBoard.StoreScoreUp(4, 1, 7);
            Assert.AreEqual(7, scoreBoard.UpperSectionTotal(3));
        }
        [TestMethod]
        public void UpperSectionTotal_6()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.upperSection = new int?[4, 6];
            scoreBoard.StoreScoreUp(4, 1, 1);
            scoreBoard.StoreScoreUp(4, 2, 1);
            scoreBoard.StoreScoreUp(4, 3, 1);
            scoreBoard.StoreScoreUp(4, 4, 1);
            scoreBoard.StoreScoreUp(4, 5, 1);
            scoreBoard.StoreScoreUp(4, 6, 1);
            Assert.AreEqual(6, scoreBoard.UpperSectionTotal(3));
        }
        #endregion
        [TestMethod]
        public void LowerSectionTotal_8()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.lowerSection = new int?[,] { { 1, 1, null, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
            Assert.AreEqual(8, scoreBoard.LowerSectionTotal(0));
        }
        [TestMethod]
        public void LowerSectionTotal_8_2()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StoreScoreUp(4, 1, 1);
            scoreBoard.StoreScoreUp(4, 2, 1);
            scoreBoard.StoreScoreUp(4, 3, 1);
            scoreBoard.StoreScoreUp(4, 4, 1);
            scoreBoard.StoreScoreUp(4, 5, 1);
            scoreBoard.StoreScoreUp(4, 6, 1);
            scoreBoard.StoreScoreDown(4, 0, 1);
            scoreBoard.StoreScoreDown(4, 1, 1);
            scoreBoard.StoreScoreDown(4, 2, 1);
            scoreBoard.StoreScoreDown(4, 3, 1);
            scoreBoard.StoreScoreDown(4, 4, 1);
            scoreBoard.StoreScoreDown(4, 5, 1);
            scoreBoard.StoreScoreDown(4, 6, 1);
            scoreBoard.StoreScoreDown(4, 7, 1);
            Assert.AreEqual(8, scoreBoard.LowerSectionTotal(3));
        }
    }
}
