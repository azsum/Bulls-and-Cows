namespace BullsAndCows.Engine
{
    using System;
    using System.Text;
    using Components;

    internal class GameOn
    {
        internal static void Game()
        {
            GameEngine.StartGame();

            var randomNumber = RandomGenerator.GenerateRandomSecretNumber();
            string command = null;
            var countRevealingDigits = 0;

            var attemptsCount = 0;
            var usingHelpCount = 0;

            char[] cheatNumber = { 'X', 'X', 'X', 'X' };

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                command = Console.ReadLine();

                if (command == "help")
                {
                    var revealedDigits = RandomGenerator.RevealNumberAtRandomPosition(randomNumber, cheatNumber);
                    var revealedNumber = new StringBuilder();

                    for (var i = 0; i < 4; i++)
                    {
                        revealedNumber.Append(revealedDigits[i]);
                    }

                    countRevealingDigits++;
                    if (countRevealingDigits == 4)
                    {
                        Console.WriteLine("The secret number is {0}", revealedNumber);
                        Console.WriteLine();
                        GameOn.Game();
                        //// to exit the game after exiting the upper game
                        break;  
                    }
                    
                    Console.WriteLine("The number looks like {0}", revealedNumber);

                    usingHelpCount++;
                    continue;
                }

                if (command == "restart")
                {
                    Console.WriteLine();
                    GameEngine.StartGame();
                    attemptsCount = 0;
                    randomNumber = RandomGenerator.GenerateRandomSecretNumber();
                    continue;
                }

                if (command == "top")
                {
                    if (ScoreBoard.TopScoreBoard.Count == 0)
                    {
                        Console.WriteLine("Top scoreboard is empty.");
                    }
                    else
                    {
                        ScoreBoard.SortScoreBoard();
                        ScoreBoard.PrintScoreBoard();
                    }

                    continue;
                }

                if (command == "exit")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }

                if (command.Length != 4 || GameEngine.ValidateDigits(command) == false)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                attemptsCount++;
                var bulls = 0;
                var cows = 0;
                GameEngine.CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows);
                if (command == randomNumber)
                {
                    if (usingHelpCount > 0)
                    {
                        Console.WriteLine(BullsAndCowsTexts.CongratulationMessageWithCheating, attemptsCount, usingHelpCount);
                        Console.WriteLine();
                        GameEngine.StartGame();
                        attemptsCount = 0;
                        usingHelpCount = 0;
                        randomNumber = RandomGenerator.GenerateRandomSecretNumber();
                    }
                    else
                    {
                        Console.WriteLine(BullsAndCowsTexts.CongratulationMessageWithoutCheating, attemptsCount);
                        ScoreBoard.AddPlayerToScoreBoard(attemptsCount);
                        attemptsCount = 0;
                        Console.WriteLine();
                        GameEngine.StartGame();
                        randomNumber = RandomGenerator.GenerateRandomSecretNumber();
                    }

                    continue;
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}