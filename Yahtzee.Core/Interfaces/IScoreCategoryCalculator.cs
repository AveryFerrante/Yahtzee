using Yahtzee.Core.Enums;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreCategoryCalculator
    {
        ScoreCategories Type { get; }
        int Calculate(DiceSet diceSet);
    }
}
