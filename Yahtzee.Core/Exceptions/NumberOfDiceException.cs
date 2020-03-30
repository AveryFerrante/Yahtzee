using System;

namespace Yahtzee.Core.Exceptions
{
    public class NumberOfDiceException : Exception
    {
        public NumberOfDiceException(int diceNumber) : base($"Total dice must be 5. Attempted to create {diceNumber} die/dice")
        { }
    }
}
