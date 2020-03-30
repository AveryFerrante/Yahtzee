using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.ScoreCalculators
{
    public class ThreeOfAKindScoreCalculator : IScoreCategoryCalculator
    {
        public ScoreCategories Type { get; private set; }
        private IScoreCategoryValidatorResolver _validatorResolver { get; set; }

        public ThreeOfAKindScoreCalculator(IScoreCategoryValidatorResolver resolver)
        {
            Type = ScoreCategories.ThreeOfAKind;
            _validatorResolver = resolver;
        }

        public int CalculateScore(DiceSet diceSet)
        {
            var validator = _validatorResolver.Resolve(Type);
            return validator.MeetsRequirements(diceSet)
                ? diceSet.Values.Sum()
                : 0;
        }
    }
}
