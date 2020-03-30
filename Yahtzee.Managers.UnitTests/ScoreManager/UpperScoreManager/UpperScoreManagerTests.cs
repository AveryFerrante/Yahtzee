using Moq;
using Xunit;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.UnitTests.ScoreManager.UpperScoreManager
{
    public class UpperScoreManagerTests
    {
        [Fact]
        public void UpperScoreManager_AddScoring_UpdatesScoreCorrectly()
        {
            var expectedScore = 10;
            var manager = CreateMockUpperScoreManager(expectedScore);

            manager.AddScoring(ScoreCategories.Aces, DiceSet.Create(new int[] { 1, 2, 3, 4, 5 }));

            Assert.Equal(expectedScore, manager.Score);
        }

        private IUpperScoreManager CreateMockUpperScoreManager(int mockedScoreReturn)
        {
            var mockResolver = new Mock<IScoreCategoryCalculatorResolver>();
            mockResolver.Setup(r => r.Resolve(It.IsAny<ScoreCategories>()))
                .Returns<IScoreCategoryCalculator>(_ =>
                {
                    var mockCaluclator = new Mock<IScoreCategoryCalculator>();
                    mockCaluclator.Setup(c => c.CalculateScore(It.IsAny<DiceSet>()))
                        .Returns(mockedScoreReturn);
                    return mockCaluclator.Object;
                });

            return new Managers.ScoreManager.UpperScoreManager.UpperScoreManager(mockResolver.Object);
        }
    }
}
