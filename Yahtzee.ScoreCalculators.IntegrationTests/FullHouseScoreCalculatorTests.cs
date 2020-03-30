using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.CategoryValidators;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.ScoreCalculators;

namespace Yahtzee.ScoreCalculators.IntegrationTests
{
    public class FullHouseScoreCalculatorTests
    {
        [Fact]
        public void FullHouseCalculator_GivenFullHouse_PassesValidationAndReturnsCorrectScore()
        {
            IScoreCategoryCalculator fullHouseScoreCalculator = GetFullHouseCalculator();
            var diceSet = DiceSet.Create(new int[] { 3, 3, 1, 1, 1 });
            var expected = 9;

            var result = fullHouseScoreCalculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FullHouseCalculator_NotGivenFullHouse_FailsValidationAndReturnsZero()
        {
            IScoreCategoryCalculator fullHouseScoreCalculator = GetFullHouseCalculator();
            var diceSet = DiceSet.Create(new int[] { 3, 3, 1, 1, 2 });
            var expected = 0;

            var result = fullHouseScoreCalculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        private static IScoreCategoryCalculator GetFullHouseCalculator()
        {
            IScoreCategoryValidator fullHouseValidator = new FullHouseValidator();
            IScoreCategoryValidatorResolver resolver = new ScoreCategoryValidatorResolver(new List<IScoreCategoryValidator> { fullHouseValidator });
            IScoreCategoryCalculator fullHouseScoreCalculator = new FullHouseScoreCalculator(resolver);
            return fullHouseScoreCalculator;
        }
    }
}
