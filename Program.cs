using System;

namespace MonoRedProwessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGames = 1200;

            int numberOfGravyGames = 0;
            int numberOfMeatGames = 0;
            int numberOfBothGames = 0;

            bool gravyComplete = false;
            bool meatComplete = false;
            bool bothComplete = false;

            bool totalGamesComplete = false;

            Scoring ScoringEngine = new Scoring();
            Console.WriteLine("Total Amount of games played: " + numberOfGames.ToString());

            while (!totalGamesComplete)
            {
                MagicGameEngine gameInstance = new MagicGameEngine();

                //Play out first turn
                gameInstance.StartGame();

                int strategy = gameInstance.GetStrategy();

                //Games for each strategy start at 0
                numberOfGravyGames = ScoringEngine.GetGames(strategy);
                numberOfMeatGames = ScoringEngine.GetGames(strategy);
                numberOfBothGames = ScoringEngine.GetGames(strategy);

                //Gravy Strategy
                if (strategy == 1 && !gravyComplete)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Current Gravy Game ...." + numberOfGravyGames.ToString());
                    Console.WriteLine("Current Strategy is ...." + strategy.ToString());

                    gameInstance.MainPhase(strategy);

                    gameInstance.CombatPhase();

                    gameInstance.EndPhase();

                    Console.WriteLine(gameInstance.opponentLifeTotal);

                    //Start of second turn and continue till opponent health is 0
                    while (gameInstance.isOpponentAlive())
                    {
                        gameInstance.DrawPhase();

                        gameInstance.MainPhase(strategy);

                        gameInstance.CombatPhase();

                        gameInstance.EndPhase();

                        Console.WriteLine(gameInstance.opponentLifeTotal);
                    }

                    if (numberOfGravyGames != 399)
                    {
                        numberOfGravyGames++;
                    }
                    else
                    {
                        gravyComplete = true;
                    }

                    Console.WriteLine("Player won on turn " + gameInstance.turn);
                    ScoringEngine.ScoreEachStrategy(strategy, gameInstance.turn, numberOfGravyGames);
                }

                //Meat Strategy
                else if (strategy == 2 && !meatComplete)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Current Meat Game ...." + numberOfMeatGames.ToString());
                    Console.WriteLine("Current Strategy is ...." + strategy.ToString());

                    gameInstance.MainPhase(strategy);

                    gameInstance.CombatPhase();

                    gameInstance.EndPhase();

                    Console.WriteLine(gameInstance.opponentLifeTotal);

                    //Start of second turn and continue till opponent health is 0
                    while (gameInstance.isOpponentAlive())
                    {
                        gameInstance.DrawPhase();

                        gameInstance.MainPhase(strategy);

                        gameInstance.CombatPhase();

                        gameInstance.EndPhase();

                        Console.WriteLine(gameInstance.opponentLifeTotal);
                    }
                    if (numberOfMeatGames != 399)
                    {
                        numberOfMeatGames++;
                    }
                    else
                    {
                        meatComplete = true;
                    }

                    Console.WriteLine("Player won on turn " + gameInstance.turn);
                    ScoringEngine.ScoreEachStrategy(strategy, gameInstance.turn, numberOfMeatGames);
                }
                //Both Strategy
                else if (strategy == 3 && !bothComplete)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Current Both Game ...." + numberOfBothGames.ToString());
                    Console.WriteLine("Current Strategy is ...." + strategy.ToString());

                    gameInstance.MainPhase(strategy);

                    gameInstance.CombatPhase();

                    gameInstance.EndPhase();

                    Console.WriteLine(gameInstance.opponentLifeTotal);

                    //Start of second turn and continue till opponent health is 0
                    while (gameInstance.isOpponentAlive())
                    {
                        gameInstance.DrawPhase();

                        gameInstance.MainPhase(strategy);

                        gameInstance.CombatPhase();

                        gameInstance.EndPhase();

                        Console.WriteLine(gameInstance.opponentLifeTotal);
                    }
                    if (numberOfBothGames != 399)
                    {
                        numberOfBothGames++;
                    }
                    else
                    {
                        bothComplete = true;
                    }

                    Console.WriteLine("Player won on turn " + gameInstance.turn);
                    ScoringEngine.ScoreEachStrategy(strategy, gameInstance.turn, numberOfBothGames);
                }
                else
                {
                    if(bothComplete && meatComplete && gravyComplete)
                        totalGamesComplete = true;
                }

            }

            double gravyTurnAvg = ScoringEngine.CalculateScore(1);
            double meatTurnAvg = ScoringEngine.CalculateScore(2);           
            double bothTurnAvg = ScoringEngine.CalculateScore(3);

            Console.WriteLine("Number of Games: " + numberOfGames.ToString());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number of Gravy Games: " + numberOfGravyGames.ToString());
            Console.WriteLine("Average turn of winning with Gravy Strat: " + gravyTurnAvg.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Number of Meat Games: " + numberOfMeatGames.ToString());
            Console.WriteLine("Average turn of winning with Meat Strat: " + meatTurnAvg.ToString());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Number of Both Games: " + numberOfBothGames.ToString());
            Console.WriteLine("Average turn of winning with Both Strat: " + bothTurnAvg.ToString());

            Console.ReadKey();
        }
    }
}
