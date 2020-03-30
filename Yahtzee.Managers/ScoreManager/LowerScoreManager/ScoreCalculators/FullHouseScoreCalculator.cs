using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.ScoreCalculators
{
    public class FullHouseScoreCalculator : IScoreCategoryCalculator
    {
        private IScoreCategoryValidatorResolver _validatorResolver;
        public ScoreCategories Type { get; private set; }


        public FullHouseScoreCalculator(IScoreCategoryValidatorResolver validatorResolver)
        {
            Type = ScoreCategories.FullHouse;
            _validatorResolver = validatorResolver;
        }


        public int Calculate(DiceSet diceSet)
        {
            var validator = _validatorResolver.Resolve(Type);
            return validator.MeetsRequirements(diceSet)
                ? diceSet.Values.Sum()
                : 0;
        }
    }
}
