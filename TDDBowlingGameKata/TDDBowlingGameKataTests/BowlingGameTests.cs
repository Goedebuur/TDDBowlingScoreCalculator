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
            game.Roll(2);
            game.Roll(8);
            game.Roll(4);
            RollMany(0, 17, game);

            //Assert
            Assert.AreEqual(18, game.CalculateScore());
        }
    }
}