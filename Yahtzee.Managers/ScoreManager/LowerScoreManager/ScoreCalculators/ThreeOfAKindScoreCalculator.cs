using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager.ScoreCalculators
{
    public class ThreeOfAKindScoreCalculator : IScoreCategoryCalculator
    {
        public ScoreCategories Type { get; private set; }

        public ThreeOfAKindScoreCalculator()
        {
            Type = ScoreCategories.ThreeOfAKind;
        }

        public int Calculate(DiceSet diceSet)
        {
            return MeetsRequirements(diceSet)
                ? diceSet.Values.Sum()
                : 0;
        }

        private bool MeetsRequirements(DiceSet diceSet)
        {
            return diceSet.Values
                .GroupBy(v => v)
                .Select(group => new { group.Key, Count = group.Count() })
                .Any(group => group.Count >= 3);
        }
    }
}
