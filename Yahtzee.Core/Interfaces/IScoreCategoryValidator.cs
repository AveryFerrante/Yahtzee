using Yahtzee.Core.Enums;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreCategoryValidator
    {
        ScoreCategories Type { get; }
        bool MeetsRequirements(DiceSet diceSet);
    }
}
