using Xunit;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.CategoryValidators;

namespace Yahtzee.ScoreValidators.UnitTests
{
    public class FullHouseValidatorTests
    {
        [Fact]
        public void FullHouseValidator_GivenFullHouse_ReturnsTrue()
        {
            DiceSet diceSet = DiceSet.Create(new int[] { 2, 2, 6, 6, 6 });
            IScoreCategoryValidator fullHouseValidator = new FullHouseValidator();

            var result = fullHouseValidator.MeetsRequirements(diceSet);

            Assert.True(result);
        }

        [Fact]
        public void FullHouseValidator_NotGivenFullHouse_ReturnsFalse()
        {
            DiceSet diceSet = DiceSet.Create(new int[] { 2, 2, 6, 5, 6 });
            IScoreCategoryValidator fullHouseValidator = new FullHouseValidator();

            var result = fullHouseValidator.MeetsRequirements(diceSet);

            Assert.False(result);
        }
    }
}
