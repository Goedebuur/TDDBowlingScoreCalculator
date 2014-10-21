using System;

namespace TDDBowlingGameKata
{
    public class BowlingGame
    {
        #region Member fields

        private readonly Frame[] _frames = new Frame[12];

        private int _currentFrame;
        private int _currentRoll;
        private readonly ScoreKeeper _scoreKeeper;

        #endregion

        public BowlingGame()
        {
            for (int i = 0;
                i < _frames.Length;
                i++)
            {
                _frames[i] = new Frame();
            }

            _currentFrame = 0;
            _currentRoll = 0;

            _scoreKeeper = new ScoreKeeper();
        }

        public static void Main(string[] args) {}

        public void CalculateScore()
        {
            int score = 0;

            for (int i = 0;
                i < 10;
                i++)
            {
                Frame currentFrame = _frames[i];

                if (currentFrame.IsStrike())
                {
                    score += currentFrame.SumRolls() + CalculateBonus(currentFrame, i);
                }

                else if (currentFrame.IsSpare())
                {
                    score += currentFrame.SumRolls() + CalculateBonus(currentFrame, i);
                }

                else
                {
                    score += currentFrame.SumRolls();
                }
            }

            _scoreKeeper.UpdateScore(score);
        }

        public void Roll(int i)
        {
            if (i < 0
                || i > 10)
            {
                throw new ArgumentException();
            }

            _frames[_currentFrame].Rolls[_currentRoll] = i;

            if (_currentRoll == 1)
            {
                _currentRoll = 0;
                _currentFrame++;
            }

            else
            {
                if (i == 10)
                {
                    _currentFrame++;
                }

                else
                {
                    _currentRoll++;
                }
            }
        }

        private int CalculateBonus(Frame frame, int index)
        {
            if (frame.IsStrike())
            {
                return _frames[index + 1].Rolls[0] + (_frames[index + 1].IsStrike()
                    ? _frames[index + 2].Rolls[0]
                    : _frames[index + 1].Rolls[1]);
            }

            if (frame.IsSpare())
            {
                return _frames[index + 1].Rolls[0];
            }

            return 0;
        }
    }
}