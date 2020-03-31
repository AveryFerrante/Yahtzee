using System.Collections;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces
{
    public interface IUpperScoreManager
    {
        int CurrentScore { get; }
        bool IsBonusEligable { get; }
        void AddToScore(int score);
    }
}
