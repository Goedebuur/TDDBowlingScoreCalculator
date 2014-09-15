using System.Collections.Generic;

namespace TDDBowlingGameKata
{
    public class BowlingGame
    {
        #region Member fields

        private readonly Frame[] _frames = new Frame[10];

        private int _currentFrame;
        private int _currentRoll;
        private int _score;

        #endregion

        public BowlingGame ()
        {
            for (int i = 0;
                i < _frames.Length;
                i++)
            {
                _frames[i] = new Frame();
            }

            _currentFrame = 0;
            _currentRoll = 0;
            _score = 0;
        }

        public static void Main(string[] args) {}

        public int CalculateScore()
        {
            for (int i = 0;
                i < _frames.Length;
                i++)
            {
                if (IsSpare(i))
                {
                    _score += _frames[i].Rolls[0] + _frames[i].Rolls[1] + _frames[i + 1].Rolls[0];
                }

                else
                {
                    _score += _frames[i].Rolls[0] + _frames[i].Rolls[1];
                }
            }

            return _score;
        }

        public void Roll(int i)
        {
            _frames[_currentFrame].Rolls[_currentRoll] = i;

            if (_currentRoll == 1)
            {
                _currentRoll = 0;
                _currentFrame++;
            }

            else
            {
                _currentRoll++;
            }
        }

        private bool IsSpare(int i)
        {
            return _frames[i].Rolls[0] + _frames[i].Rolls[1] == 10;
        }
    }
}