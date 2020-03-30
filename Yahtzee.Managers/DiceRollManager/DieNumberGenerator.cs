using System;
using Yahtzee.Core.Interfaces;

namespace Yahtzee.Managers.DiceRollManager
{
    public class DieNumberGenerator : INumberGenerator
    {
        public int Next()
        {
            return new Random().Next(1, 7);
        }
    }
}
