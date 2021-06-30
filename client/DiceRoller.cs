using Dorc.Dice;
using System.Collections.Generic;

namespace Dorc.Client
{

    public class DiceRoller {
        public int RollD20()
        {
            return Dice.Dice.roll(20);
        }

        public IEnumerable<int> RollDice(int count, int sides)
        {
            return Dice.Dice.rollMultiple(count, sides);
        }

        public IEnumerable<int> RollFudge() => Dice.Dice.rollFudge();
    }

}