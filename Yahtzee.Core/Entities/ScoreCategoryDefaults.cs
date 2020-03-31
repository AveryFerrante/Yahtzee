using System.Collections.Generic;
using Yahtzee.Core.Enums;

namespace Yahtzee.Core.Entities
{
    public static class ScoreCategoryDefaults
    {
        public static List<ScoreCategoryMetadata> AllCategories = new List<ScoreCategoryMetadata>
        {
            new ScoreCategoryMetadata { Type = ScoreCategories.Twos, Section = ScoreSections.Upper }
        };

    }
}
