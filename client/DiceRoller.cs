using DiceSharp;
using System.Collections.Generic;

namespace Dorc.Client
{

    public class DiceRoller {
        public int RollDie()
        {
            return Dice.roll(12);  // Chosen by fair dice roll
        }

        public IEnumerable<int> RollDice(int count, int sides)
        {
            return Dice.rollMultiple(count, sides);
        }
    }

}