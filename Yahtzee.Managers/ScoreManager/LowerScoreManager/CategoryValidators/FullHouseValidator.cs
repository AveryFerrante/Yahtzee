using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.CategoryValidators
{
    public class FullHouseValidator : IScoreCategoryValidator
    {
        public ScoreCategories Type { get; private set; }
        public FullHouseValidator()
        {
            Type = ScoreCategories.FullHouse;
        }


        public bool MeetsRequirements(DiceSet diceSet)
        {
            var groupedResults = diceSet.Values
                .GroupBy(v => v)
                .Select(group => new { group.Key, Count = group.Count() });

            return groupedResults.Count() == 2
                && groupedResults.Any(g => g.Count == 3)
                && groupedResults.Any(g => g.Count == 2);
        }
    }
}
