using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yahtzee.Core.Entities;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.Interfaces;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.UnitTests.ScoreManagers
{
    public class ScoreManagerTests
    {
        [Fact]
        public void ScoreManager_GivenUpperSectionScore_AddsScoreToUpperScoreManager()
        {
            Mock<IUpperScoreManager> mockUpperScoreManager = new Mock<IUpperScoreManager>();
            Mock<ILowerScoreManager> mockLowerScoreManager = new Mock<ILowerScoreManager>();
            Mock<IScoreCategoryCalculatorResolver> mockCaluclatorResolver = new Mock<IScoreCategoryCalculatorResolver>();
            mockCaluclatorResolver.Setup(r => r.Resolve(It.IsAny<ScoreCategories>()))
                .Returns<IScoreCategoryCalculator>(_ =>
                {
                    var mockCaluclator = new Mock<IScoreCategoryCalculator>();
                    mockCaluclator.Setup(c => c.Calculate(It.IsAny<DiceSet>()))
                        .Returns(30);
                    return mockCaluclator.Object;
                });
            IScoreManager manager = new ScoreManager.ScoreManager(
                mockUpperScoreManager.Object,
                mockLowerScoreManager.Object,
                mockCaluclatorResolver.Object);

            var scoreSection = new ScoreCategoryMetadata { Type = ScoreCategories.Aces, Section = ScoreSections.Upper };
            var diceSet = DiceSet.Create(new int[] { 1, 2, 3, 4, 5 });
            manager.AddScoring(new AddScoringRequest { CategoryMetadata = scoreSection, diceSet = diceSet });

            mockUpperScoreManager.Verify(m => m.AddToScore(30), Times.Once);
        }
    }
}
