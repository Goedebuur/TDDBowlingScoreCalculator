using System.Linq;

namespace TDDBowlingGameKata
{
    public class ScoreKeeper
    {
        #region Member fields

        private int _highScore;

        private int _lastScore;

        #endregion

        public int HighScore
        {
            get { return _highScore; }
        }

        public int LastScore
        {
            get { return _lastScore; }
        }

        public void UpdateScore(int score)
        {
            _lastScore = score;

            if (_highScore < score)
            {
                _highScore = score;
            }
        }
    }
}