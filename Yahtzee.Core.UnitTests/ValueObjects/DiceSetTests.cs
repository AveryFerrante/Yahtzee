using System.Collections.Generic;
using Xunit;
using Yahtzee.Core.Exceptions;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.UnitTests.ValueObjects
{
    public class DiceSetTests
    {
        [Theory]
        [MemberData(nameof(GetIncorrectNumberOfDiceKeys))]
        public void DiceState_InitializingWithWrongNumberOfDice_ThrowsException(int[] dieValues)
        {
            Assert.Throws<NumberOfDiceException>(() => DiceSet.Create(dieValues));
        }

        [Fact]
        public void DiceState_InitializingWithCorrectNumberOfDice_DoesNotThrowException()
        {
            var exception = Record.Exception(() => DiceSet.Create(new int[] { 1, 2, 3, 4, 5 }));
            Assert.Null(exception);
        }

        public static IEnumerable<object[]> GetIncorrectNumberOfDiceKeys() =>
            new List<object[]>
            {
                new object[] { new int[] { 1 } },
                new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7 } }
            };
    }
}
