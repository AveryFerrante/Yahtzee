using Moq;
using Xunit;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.ScoreCalculators;

namespace Yahtzee.ScoreCalculators.UnitTests
{
    public class FullHouseScoreCalculatorTests
    {
        [Fact]
        public void FullHouseScoreCalculator_GivenFullHouse_ReturnsCorrectScore()
        {
            var diceSet = DiceSet.Create(new int[] { 2, 2, 3, 3, 3 });
            var mockResolver = GetMockResolverWithValidatorThatReturns(true);
            var expected = 13;
            

            var calculator = new FullHouseScoreCalculator(mockResolver.Object);
            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FullHouseScoreCalculator_NotGivenFullHouse_ReturnsZero()
        {
            var diceSet = DiceSet.Create(new int[] { 2, 2, 3, 3, 3 });
            var mockResolver = GetMockResolverWithValidatorThatReturns(false);
            var expected = 0;

            var calculator = new FullHouseScoreCalculator(mockResolver.Object);
            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        private static Mock<IScoreCategoryValidatorResolver> GetMockResolverWithValidatorThatReturns(bool returnValue)
        {
            Mock<IScoreCategoryValidator> mockValidator = new Mock<IScoreCategoryValidator>();
            mockValidator.Setup(v => v.MeetsRequirements(It.IsAny<DiceSet>()))
                .Returns(returnValue);

            Mock<IScoreCategoryValidatorResolver> mockResolver = new Mock<IScoreCategoryValidatorResolver>();
            mockResolver.Setup(r => r.Resolve(It.IsAny<ScoreCategories>()))
                .Returns(mockValidator.Object);
            return mockResolver;
        }
    }
}
