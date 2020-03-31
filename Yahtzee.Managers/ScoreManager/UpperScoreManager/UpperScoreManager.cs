using System;
using System.Linq;
using System.Collections.Generic;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.ScoreManager.UpperScoreManager
{
    public class UpperScoreManager : IUpperScoreManager
    {
        private int _score;
        public int CurrentScore => IsBonusEligable ? (_score + 35) : _score;
        public bool IsBonusEligable { get => _score >= 63; }

        public UpperScoreManager()
        {
            _score = 0;
        }

        public void AddToScore(int score)
        {
            _score += score;
        }
    }
}
