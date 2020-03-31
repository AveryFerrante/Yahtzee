using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yahtzee.Managers.ScoreManager.LowerScoreManager.Interfaces;
using Yahtzee.Managers.ScoreManager.UpperScoreManager;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.Interfaces;

namespace Yahtzee.Managers.IntegrationTests.ScoreManager
{
    public class ScoreManagerTests
    { 
        [Fact]
        public void a()
        {
            IUpperScoreManager upperScoreManager = new UpperScoreManager();
        }
    }
}
