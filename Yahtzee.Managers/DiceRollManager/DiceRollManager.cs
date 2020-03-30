using System.Collections.Generic;
using System.Linq;
using Yahtzee.Core.Interfaces;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Managers.DiceRollManager
{
    public class DiceRollManager : IRollManager
    { 
        private INumberGenerator _generator { get; set; }
        public DiceRollManager(INumberGenerator generator)
        {
            _generator = generator;
        }

        public DiceSet RollAll()
        {
            return DiceSet.Create(GenerateNewDiceValues(5));
        }

        public DiceSet RollAllButKeep(IEnumerable<int> valuesToKeep)
        {
            var newValues = GenerateNewDiceValues(5 - valuesToKeep.Count());
            return DiceSet.Create(valuesToKeep.Concat(newValues).ToArray());
        }

        private int[] GenerateNewDiceValues(int numberOfValues)
        {
            return Enumerable.Range(1, numberOfValues).Select(_ => _generator.Next()).ToArray();
        }
    }
}
