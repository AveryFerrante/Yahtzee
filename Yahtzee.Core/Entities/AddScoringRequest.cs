using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Entities
{
    public class AddScoringRequest
    {
        public ScoreCategoryMetadata CategoryMetadata;
        public DiceSet diceSet;
    }
}
