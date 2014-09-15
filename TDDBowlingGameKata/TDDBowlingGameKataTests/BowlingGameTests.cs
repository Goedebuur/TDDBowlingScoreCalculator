using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using TDDBowlingGameKata;

namespace TDDBowlingGameKataTests
{
    [TestFixture]
    public class BowlingGameTests
    {
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

        private BowlingGame CreateBowlingGame()
        {
            return new BowlingGame();
        }
    }
}
