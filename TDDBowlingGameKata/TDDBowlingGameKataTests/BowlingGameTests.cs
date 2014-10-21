using System;

using NUnit.Framework;

using TDDBowlingGameKata;

namespace TDDBowlingGameKataTests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private BowlingGame CreateBowlingGame()
        {
            return new BowlingGame();
        }

        private void RollMany(int pins, int times, BowlingGame game)
        {
            for (int i = 0;
                i < times;
                i++)
            {
                game.Roll(pins);
            }
        }

        private static void RollSpare(BowlingGame game)
        {
            game.Roll(2);
            game.Roll(8);
        }

        [Test]
        public void CalculateScore_AllOnes_Returns20()
        {
            BowlingGame game = CreateBowlingGame();
            RollMany(1, 20, game);

            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_DoubleStrike_CorrectlyIncludesBonus()
        {
            BowlingGame game = CreateBowlingGame();

            game.Roll(10); // Strike for total 22
            game.Roll(10); // Strike for total 15
            game.Roll(2);
            game.Roll(3);
            RollMany(0, 14, game);

            Assert.AreEqual(42, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_GutterGame_ReturnsZero()
        {
            BowlingGame game = CreateBowlingGame();
            RollMany(0, 20, game);

            Assert.AreEqual(0, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_NoRolls_ReturnsZero()
        {
            BowlingGame game = CreateBowlingGame();
            RollMany(1, 0, game);

            Assert.AreEqual(0, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_OneSpare_CorrectlyIncludesBonus()
        {
            BowlingGame game = CreateBowlingGame();

            RollSpare(game);
            game.Roll(4); //Bonus roll
            RollMany(0, 17, game);

            Assert.AreEqual(18, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_OneStrike_CorrectlyIncludesBonus()
        {
            BowlingGame game = CreateBowlingGame();

            game.Roll(10); // Strike
            game.Roll(2); // 2 bonus rolls
            game.Roll(3);
            RollMany(0, 16, game);

            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_PerfectGame_Returns300()
        {
            BowlingGame game = CreateBowlingGame();
            RollMany(10, 12, game);

            Assert.AreEqual(300, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_Roll21Ones_Returns20()
        {
            BowlingGame game = CreateBowlingGame();
            RollMany(1, 21, game);

            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CalculateScore_RollTooFewPins_ThrowsException()
        {
            BowlingGame game = CreateBowlingGame();
            const int tooFewPins = -1;

            RollMany(tooFewPins, 1, game);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CalculateScore_RollTooManyPins_ThrowsException()
        {
            BowlingGame game = CreateBowlingGame();
            const int tooManyPins = 99;

            RollMany(tooManyPins, 1, game);
        }

        [Test]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void CalculateScore_TooManyFrames_ThrowsException()
        {
            BowlingGame game = CreateBowlingGame();
            const int tooManyFrames = 100;

            RollMany(1, tooManyFrames, game);

            game.CalculateScore();
        }


    }
}