using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.Interfaces;

namespace Yahtzee.Managers.ScoreManager.LowerScoreManager
{
    public class LowerScoreManager : ILowerScoreManager
    {
        public int CurrentScore => 0;

        public int NumberOfYahtzees => throw new NotImplementedException();

        public void AddToScore(int score)
        {
            throw new NotImplementedException();
        }

        public void AddYahtzee()
        {
            throw new NotImplementedException();
        }
    }
}
