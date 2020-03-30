using Moq;
using Xunit;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.UnitTests.ScoreManagers
{
    public class UpperScoreManagerTests
    {
        [Fact]
        public void Test1()
        {
            Mock<IScoreCategoryCalculator> mockCalculator = new Mock<IScoreCategoryCalculator>();
            mockCalculator.Setup(c => c.Calculate(It.IsAny<DiceSet>()))
                .Returns(100);

            Mock<IScoreCategoryCalculatorResolver> mockResolver = new Mock<IScoreCategoryCalculatorResolver>();
            mockResolver.Setup(r => r.Resolve(It.IsAny<ScoreCategories>()))
                .Returns(mockCalculator.Object);

            var manager = new ScoreManager.UpperScoreManager.UpperScoreManager(mockResolver.Object);
            manager.AddScoring(ScoreCategories.Aces, DiceSet.Create(new int[] { 1, 1, 1, 1, 1 }));

            Assert.Equal(100, manager.Score);
        }
    }
}
