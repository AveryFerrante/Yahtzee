using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee.Core.Enums;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreCategoryCalculatorResolver
    {
        IScoreCategoryCalculator Resolve(ScoreCategories scoreCategory);
    }
}
