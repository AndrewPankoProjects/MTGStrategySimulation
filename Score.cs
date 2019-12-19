using System;
using System.Collections.Generic;
using System.Text;

namespace MonoRedProwessProject
{
    public class Score
    {
        public int Strategy;
        public int TurnOfWin;
        public int GameNumber;
        public Score(int strategy, int turnOfWin, int gameNumber)
        {
            Strategy = strategy;
            TurnOfWin = turnOfWin;
            GameNumber = gameNumber;
        }

    }
}
