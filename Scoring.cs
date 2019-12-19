using System;
using System.Collections.Generic;
using System.Text;

namespace MonoRedProwessProject
{
    public class Scoring
    {
        List<Score> gravyWins = new List<Score>();

        List<Score> meatWins = new List<Score>();

        List<Score> bothWins = new List<Score>();

        public int averageTurnWinPecentage;
        public int longestGame = 0;
        public int quickestGame = 100;
        public int longgameNumber = 0;
        public int quickgameNumber = 0;

        //Add win to list of wins
        public void ScoreEachStrategy(int strategy, int turn, int gameNumber)
        {
            if (strategy == 1)
            {
                gravyWins.Add(new Score(strategy, turn, gameNumber));
            }
            else if (strategy == 2)
            {
                meatWins.Add(new Score(strategy, turn, gameNumber));
            }
            else if (strategy == 3)
            {
                bothWins.Add(new Score(strategy, turn, gameNumber));
            }
        }

        //Calculate the average of turns it takes to win for each strategy
        public double CalculateScore(int strategy)
        {
            if (strategy == 1 && gravyWins.Count > 0)
            {
                averageTurnWinPecentage = 0;
                longestGame = 0;
                quickestGame = 100;
                longgameNumber = 0;
                quickgameNumber = 0;
                foreach (var win in gravyWins)
                {
                    if (win.TurnOfWin > longestGame)
                    {
                        longestGame = win.TurnOfWin;
                        longgameNumber = win.GameNumber-1;
                    }
                    else if (win.TurnOfWin < quickestGame)
                    {
                        quickestGame = win.TurnOfWin;
                        quickgameNumber = win.GameNumber;
                    }
                    averageTurnWinPecentage += win.TurnOfWin;
                }
                Console.WriteLine("The longest game for Gravy strategy: " + longestGame.ToString() + " At Game: " + longgameNumber);
                Console.WriteLine("The shortest game for Gravy strategy: " + quickestGame.ToString() + " At Game: " + quickgameNumber);
                //Console.WriteLine(gravyWins.Count.ToString());
                //Console.WriteLine(averageTurnWinPecentage.ToString());
                return averageTurnWinPecentage = averageTurnWinPecentage / gravyWins.Count;
            }
            else if (strategy == 2 && meatWins.Count > 0)
            {
                averageTurnWinPecentage = 0;
                longestGame = 0;
                quickestGame = 100;
                longgameNumber = 0;
                quickgameNumber = 0;
                foreach (var win in meatWins)
                {
                    if (win.TurnOfWin > longestGame)
                    {
                        longestGame = win.TurnOfWin;
                        longgameNumber = win.GameNumber-1;
                    }
                    else if (win.TurnOfWin < quickestGame)
                    {
                        quickestGame = win.TurnOfWin;
                        quickgameNumber = win.GameNumber;
                    }
                    averageTurnWinPecentage += win.TurnOfWin;
                }
                Console.WriteLine("The longest game for Meat strategy: " + longestGame.ToString() + " At Game: " + longgameNumber);
                Console.WriteLine("The shortest game for Meat strategy: " + quickestGame.ToString() + " At Game: " + quickgameNumber);
                //Console.WriteLine(meatWins.Count.ToString());
                //Console.WriteLine(averageTurnWinPecentage.ToString());
                return averageTurnWinPecentage = averageTurnWinPecentage / meatWins.Count;
            }
            else if (strategy == 3 && bothWins.Count > 0)
            {
                averageTurnWinPecentage = 0;
                longestGame = 0;
                quickestGame = 100;
                longgameNumber = 0;
                quickgameNumber = 0;
                foreach (var win in bothWins)
                {
                    if (win.TurnOfWin > longestGame)
                    {
                        longestGame = win.TurnOfWin;
                        longgameNumber = win.GameNumber-1;
                    }
                    else if(win.TurnOfWin < quickestGame)
                    {
                        quickestGame = win.TurnOfWin;
                        quickgameNumber = win.GameNumber;
                    }
                    averageTurnWinPecentage += win.TurnOfWin;
                }
                Console.WriteLine("The longest game for Both strategy: " + longestGame.ToString() + " At Game: " + longgameNumber);
                Console.WriteLine("The shortest game for Both strategy: " + quickestGame.ToString() + " At Game: " + quickgameNumber);
                //Console.WriteLine(bothWins.Count.ToString());
                //Console.WriteLine(averageTurnWinPecentage.ToString());
                return averageTurnWinPecentage = averageTurnWinPecentage / bothWins.Count;
            }
            else
            {
                return -1;
            }
        }

        public int GetGames(int strategy)
        {
            if (strategy == 1)
            {
                return gravyWins.Count;
            }
            else if (strategy == 2)
            {
                return meatWins.Count;
            }
            else if (strategy == 3)
            {
                return bothWins.Count;
            }
            else
            {
                return -1;
            }
        }
    }
}
