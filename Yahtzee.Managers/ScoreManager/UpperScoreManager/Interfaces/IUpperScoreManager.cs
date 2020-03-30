using Yahtzee.Core.Interfaces;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces
{
    public interface IUpperScoreManager : IScoreSectionManager
    {
        bool IsBonusEligable { get; }
    }
}
