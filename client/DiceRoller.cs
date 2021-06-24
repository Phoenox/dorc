using DiceSharp;

namespace Dorc.Client
{

    public class DiceRoller {
        public int RollDie()
        {
            return Dice.roll(12);  // Chosen by fair dice roll
        }
    }

}