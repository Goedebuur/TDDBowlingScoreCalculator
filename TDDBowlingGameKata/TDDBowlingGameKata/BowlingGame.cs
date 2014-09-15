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
            _score = 0;
        }

        public static void Main(string[] args) {}

        public int CalculateScore()
        {
            for (int i = 0;
                i < _frames.Length;
                i++)
            {
                Frame currentFrame = _frames[i];

                if (IsStrike(currentFrame))
                {
                    _score += currentFrame.SumRolls() + CalculateBonus(currentFrame, i);
                }

                else if (IsSpare(currentFrame))
                {
                    _score += currentFrame.SumRolls() + CalculateBonus(currentFrame, i);
                }

                else
                {
                    _score += currentFrame.SumRolls();
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
            if (IsStrike(frame))
            {
                return _frames[index + 1].Rolls[0] + _frames[index + 1].Rolls[1];
            }

            if (IsSpare(frame))
            {
                return _frames[index + 1].Rolls[0];
            }

            return 0;
        }

        private bool IsSpare(Frame frame)
        {
            return frame.Rolls[0] + frame.Rolls[1] == 10;
        }

        private bool IsStrike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }
    }
}