using Yahtzee.Core.Exceptions;

namespace Yahtzee.Core.ValueObjects
{
    public class DiceSet
    {
        public int[] Values { get; private set; }
        private DiceSet(int[] values)
        {
            Values = values;
        }
        public static DiceSet Create(int[] values)
        {
            if (values.Length != 5)
            {
                throw new NumberOfDiceException(values.Length);
            }
            return new DiceSet(values);
        }
    }
}
