using System.Collections.Generic;
using Yahtzee.Core.ValueObjects;

namespace Yahtzee.Core.Interfaces
{
    public interface IRollManager
    {
        DiceSet RollAll();
        DiceSet RollAllButKeep(IEnumerable<int> valuesToKeep);
    }
}
