using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee.Core.Enums;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreCategoryValidatorResolver
    {
        IScoreCategoryValidator Resolve(ScoreCategories type);
    }
}
