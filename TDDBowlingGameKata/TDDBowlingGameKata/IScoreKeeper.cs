namespace TDDBowlingGameKata
{
    public interface IScoreKeeper
    {
        int HighScore { get; }
        int LastScore { get; }
        void UpdateScore(int score);
    }
}