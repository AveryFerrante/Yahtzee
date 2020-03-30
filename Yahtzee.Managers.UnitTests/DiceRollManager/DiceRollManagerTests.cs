using Moq;
using System.Linq;
using Xunit;
using Yahtzee.Core.Interfaces;

namespace Yahtzee.Managers.UnitTests.DiceRollManager
{
    public class DiceRollManagerTests
    {
        [Fact]
        public void DiceRollManager_KeepingDiceDuringReroll_MaintainsSameValue()
        {
            var diceRollManager = GetDiceRollManager();
            var dieValueToKeep = diceRollManager.RollAll().Values.First();
            var rerollDieValues = diceRollManager.RollAllButKeep(new int[] { dieValueToKeep });

            Assert.Single(rerollDieValues.Values, dieValueToKeep);
        }

        [Fact]
        public void DiceRollManager_RollingAll_GetsAllNewValues()
        {
            var diceRollManager = GetDiceRollManager();
            var firstRoll = diceRollManager.RollAll();
            var secondRoll = diceRollManager.RollAll();

            var overlap = firstRoll.Values.Where(v => secondRoll.Values.Contains(v));
            Assert.Empty(overlap);
        }

        private IRollManager GetDiceRollManager()
        {
            Mock<INumberGenerator> mockedNumberGenerator = new Mock<INumberGenerator>();
            mockedNumberGenerator.SetupSequence(n => n.Next())
                .Returns(1).Returns(1).Returns(1).Returns(1).Returns(1)
                .Returns(2).Returns(2).Returns(2).Returns(2).Returns(2);

            return new Managers.DiceRollManager.DiceRollManager(mockedNumberGenerator.Object);
        }
    }


}
