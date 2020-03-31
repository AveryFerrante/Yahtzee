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
            var expected = 13;
            

            var calculator = new FullHouseScoreCalculator();
            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FullHouseScoreCalculator_NotGivenFullHouse_ReturnsZero()
        {
            var diceSet = DiceSet.Create(new int[] { 5, 1, 3, 3, 3 });
            var expected = 0;

            var calculator = new FullHouseScoreCalculator();
            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }
    }
}
