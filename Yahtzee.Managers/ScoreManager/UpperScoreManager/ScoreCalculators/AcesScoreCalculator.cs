using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager.ScoreCalculators
{
    public class AcesScoreCalculator : IScoreCategoryCalculator
    {
        public ScoreCategories Type { get; private set; }

        public AcesScoreCalculator()
        {
            Type = ScoreCategories.Aces;
        }

        public int CalculateScore(DiceSet diceSet)
        {
            return diceSet.Values.Where(v => v == 1).Sum();
        }
    }
}
