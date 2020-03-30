using System;
using System.Collections.Generic;
using Yahtzee.Core.Enums;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreSectionManager
    {
        int Score { get; }
        void AddScoring(ScoreCategories category, DiceSet diceSet);
        IEnumerable<ScoreCategories> GetUnscoredCategories();
    }
}
