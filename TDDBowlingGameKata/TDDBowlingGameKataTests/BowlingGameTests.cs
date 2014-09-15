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

        [Test]
        public void CalculateScore_AllOnes_ScoreIs20()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            for (int i = 0;
                i < 20;
                i++)
            {
                game.Roll(1);
            }

            //Assert
            Assert.AreEqual(20, game.CalculateScore());
        }

        [Test]
        public void CalculateScore_GutterGame_ReturnsZero()
        {
            //Arrange
            BowlingGame game = CreateBowlingGame();

            //Act
            for (int i = 0;
                i < 20;
                i++)
            {
                game.Roll(0);
            }

            //Assert
            Assert.AreEqual(0, game.CalculateScore());
        }
    }
}