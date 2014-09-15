using System.Linq;

namespace TDDBowlingGameKata
{
    public class Frame
    {
        #region Member fields

        public int[] Rolls = new int[2];

        #endregion

        public int SumRolls()
        {
            return Rolls.Sum();
        }
    }
}