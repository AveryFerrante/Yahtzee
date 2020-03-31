namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.Interfaces
{
    public interface ILowerScoreManager
    {
        int CurrentScore { get; }
        int NumberOfYahtzees { get; }
        void AddToScore(int score);
        void AddYahtzee();
    }
}
