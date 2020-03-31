using Xunit;
using Yahtzee.Managers.ScoreManager.UpperScoreManager;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.UnitTests.ScoreManagers
{
    public class UpperScoreManagerTests
    {
        [Fact]
        public void UpperScoreManager_WithScoreLessThanBonusRequirements_ReturnsScoreWithoutBonusPoints()
        {
            IUpperScoreManager manager = new UpperScoreManager();
            var expected = 45;

            manager.AddToScore(expected);

            Assert.Equal(expected, manager.CurrentScore);
        }

        [Fact]
        public void UpperScoreManager_WithScoreOverBonusRequirements_ReturnsTrueForBonusEligible()
        {
            IUpperScoreManager manager = new UpperScoreManager();
            var score = 70;

            manager.AddToScore(score);

            Assert.True(manager.IsBonusEligable);
        }

        [Fact]
        public void UpperScoreManager_WithScoreOverBonusRequirements_ReturnsScoreWithBonusPoints()
        {
            IUpperScoreManager manager = new UpperScoreManager();
            var score = 70;
            var expected = 70 + 35;

            manager.AddToScore(score);

            Assert.Equal(expected, manager.CurrentScore);
        }
    }
}
