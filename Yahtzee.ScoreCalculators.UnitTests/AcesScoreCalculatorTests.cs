using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.ScoreCalculators;

namespace Yahtzee.ScoreCalculators.UnitTests
{
    public class AcesScoreCalculatorTests
    {
        [Fact]
        public void AcesCalculator_GivenDiceSetWithAces_CalculatsCorrectScore()
        {
            IScoreCategoryCalculator calculator = new AcesScoreCalculator();
            DiceSet diceSet = DiceSet.Create(new int[] { 1, 1, 2, 3, 4 });
            var expected = 2;

            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AcesCalculator_GivenDiceSetWithNoAces_ReturnsZero()
        {
            IScoreCategoryCalculator calculator = new AcesScoreCalculator();
            DiceSet diceSet = DiceSet.Create(new int[] { 6, 3, 2, 3, 4 });
            var expected = 0;

            var result = calculator.Calculate(diceSet);

            Assert.Equal(expected, result);
        }
    }
}
