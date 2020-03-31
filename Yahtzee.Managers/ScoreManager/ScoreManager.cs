using System.Collections.Generic;
using System.Linq;
using Yahtzee.Core.Entities;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.Interfaces;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.ScoreManager
{
    public class ScoreManager : IScoreManager
    {
        public int CurrentScore => _upperScoreManager.CurrentScore + _lowerScoreManager.CurrentScore;

        private ILowerScoreManager _lowerScoreManager;
        private IUpperScoreManager _upperScoreManager;
        private IScoreCategoryCalculatorResolver _calculatorResolver;
        private List<ScoreCategoryMetadata> _scoredCategories;

        public ScoreManager(IUpperScoreManager upperScoreManager,
                            ILowerScoreManager lowerScoreManager,
                            IScoreCategoryCalculatorResolver calculatorResolver)
        {
            _upperScoreManager = upperScoreManager;
            _lowerScoreManager = lowerScoreManager;
            _calculatorResolver = calculatorResolver;
            _scoredCategories = new List<ScoreCategoryMetadata>();
        }

        public void AddScoring(AddScoringRequest scoringRequest)
        {
            var caluclator = _calculatorResolver.Resolve(scoringRequest.CategoryMetadata.Type);
            AddScoreToSection(scoringRequest, caluclator);
            _scoredCategories.Add(scoringRequest.CategoryMetadata);
        }

        private void AddScoreToSection(AddScoringRequest scoringRequest, IScoreCategoryCalculator caluclator)
        {
            if (scoringRequest.CategoryMetadata.Section == ScoreSections.Upper)
            {
                _upperScoreManager.AddToScore(caluclator.Calculate(scoringRequest.diceSet));
            }
            else
            {
                _lowerScoreManager.AddToScore(caluclator.Calculate(scoringRequest.diceSet));
            }
        }

        public IEnumerable<ScoreCategoryMetadata> GetUnscoredCategories()
        {
            var scoredCategoryTypes = _scoredCategories.Select(sc => sc.Type);
            return ScoreCategoryDefaults.AllCategories.Where(c => !scoredCategoryTypes.Contains(c.Type));
        }

        public IEnumerable<ScoreCategoryMetadata> GetScoredCategories()
        {
            var scoredCategoryTypes = _scoredCategories.Select(sc => sc.Type);
            return ScoreCategoryDefaults.AllCategories.Where(c => scoredCategoryTypes.Contains(c.Type));
        }
    }
}
