using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager.ScoreCalculators
{
    public class TwosScoreCalculator : IScoreCategoryCalculator
    {
        public ScoreCategories Type { get; private set; }

        public TwosScoreCalculator()
        {
            Type = ScoreCategories.Twos;
        }

        public int CalculateScore(DiceSet diceSet)
        {
            return diceSet.Values.Where(v => v == 2).Sum();
        }
    }
}
