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
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            RollMany(1, 20, game);

            //Assert
            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_DoubleStrike_CorrectlyIncludesBonus()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            game.Roll(10); // Strike for 22
            game.Roll(10); // Strike for 15
            game.Roll(2);
            game.Roll(3);
            RollMany(0, 14, game);

            //Assert
            Assert.AreEqual(42, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_GutterGame_ReturnsZero()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            RollMany(0, 20, game);

            //Assert
            Assert.AreEqual(0, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_OneSpare_CorrectlyIncludesBonus()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            RollSpare(game);
            game.Roll(4); //Bonus roll

            RollMany(0, 17, game);

            //Assert
            Assert.AreEqual(18, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_OneStrike_CorrectlyIncludesBonus()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            game.Roll(10); // Strike
            game.Roll(2); // 2 bonus rolls
            game.Roll(3);
            RollMany(0, 16, game);

            //Assert
            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_PerfectGame_Returns300()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            RollMany(10, 12, game);

            //Assert
            Assert.AreEqual(300, game.CalculateScore());
        }
    }
}