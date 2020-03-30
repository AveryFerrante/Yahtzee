using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee.Core.Enums;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreCategoryCalculator
    {
        ScoreCategories Type { get; }
        int CalculateScore(DiceSet diceSet);
    }
}
