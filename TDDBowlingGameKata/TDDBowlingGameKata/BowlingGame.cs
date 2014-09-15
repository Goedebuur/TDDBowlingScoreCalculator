using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBowlingGameKata
{
    public class BowlingGame
    {
        private int _score;

        public static void Main(string[] args)
        {
            
        }

        public void Roll(int i)
        {
            _score += i;
        }

        public int CalculateScore()
        {
            return _score;
        }
    }
}
