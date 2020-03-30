using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.CategoryValidators
{
    public class ThreeOfAKindValidator : IScoreCategoryValidator
    {
        public ScoreCategories Type { get; private set; }
        public ThreeOfAKindValidator()
        {
            Type = ScoreCategories.ThreeOfAKind;
        }


        public bool MeetsRequirements(DiceSet diceSet)
        {
            return diceSet.Values
                .GroupBy(v => v)
                .Select(group => new { group.Key, Count = group.Count() })
                .Any(group => group.Count >= 3);
        }
    }
}
