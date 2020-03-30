using System;
using System.Linq;
using System.Collections.Generic;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager
{
    public class UpperScoreManager : IUpperScoreManager
    {
        private int _score;
        public int Score
        {
            get => IsBonusEligable ? (_score + 35) : _score;
            private set => _score = value;
        }
        private List<ScoreCategories> _scoredCategories { get; set; }
        private IScoreCategoryCalculatorResolver _scoreCalculatorResolver { get; set; }
        public bool IsBonusEligable { get => Score > 63; }

        public UpperScoreManager(IScoreCategoryCalculatorResolver scoreCalculatorResolver)
        {
            Score = 0;
            _scoredCategories = new List<ScoreCategories>();
            _scoreCalculatorResolver = scoreCalculatorResolver;
        }

        public void AddScoring(ScoreCategories category, DiceSet diceSet)
        {
            IScoreCategoryCalculator scoreCalculator = _scoreCalculatorResolver.Resolve(category);
            Score += scoreCalculator.Calculate(diceSet);
            _scoredCategories.Add(category);
        }

        public IEnumerable<ScoreCategories> GetUnscoredCategories()
        {
            return Enum.GetValues(typeof(ScoreCategories))
                .Cast<ScoreCategories>()
                .AsEnumerable()
                .Where(t => !_scoredCategories.Contains(t));
        }
    }
}
