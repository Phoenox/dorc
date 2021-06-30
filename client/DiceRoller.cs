using Dorc.Dice;
using System.Collections.Generic;

namespace Dorc.Client
{

    public class DiceRoller {
        public int RollDie()
        {
            return Dice.Dice.roll(12);  // Chosen by fair dice roll
        }

        public IEnumerable<int> RollDice(int count, int sides)
        {
            return Dice.Dice.rollMultiple(count, sides);
        }

        public IEnumerable<int> RollFudge() => Dice.Dice.rollFudge();
    }

}