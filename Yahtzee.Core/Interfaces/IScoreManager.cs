using System;
using System.Collections.Generic;
using Yahtzee.Core.Entities;
using Yahtzee.Core.Enums;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IScoreManager
    {
        int CurrentScore { get; }
        void AddScoring(AddScoringRequest scoringRequest);
        IEnumerable<ScoreCategoryMetadata> GetUnscoredCategories();
        IEnumerable<ScoreCategoryMetadata> GetScoredCategories();

    }
}
