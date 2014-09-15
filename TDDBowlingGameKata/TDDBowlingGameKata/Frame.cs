using System.Linq;

namespace TDDBowlingGameKata
{
    public class Frame
    {
        #region Member fields

        public int[] Rolls = new int[2];

        #endregion

        public bool IsSpare()
        {
            return Rolls[0] != 10 && SumRolls() == 10;
        }

        public bool IsStrike()
        {
            return Rolls[0] == 10;
        }

        public int SumRolls()
        {
            return Rolls.Sum();
        }
    }
}