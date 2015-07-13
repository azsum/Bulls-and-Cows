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
            var countRevealingDigits=0;

            var count1 = 0;
            var count2 = 0;


            char[] cheatNumber = { 'X', 'X', 'X', 'X' };

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                command = Console.ReadLine();

                if (command == "help")
                {
                    countRevealingDigits++;
                    if(countRevealingDigits==4)
                    {
                        break;
                    }
                    var revealedDigits = RandomGenerator.RevealNumberAtRandomPosition(randomNumber, cheatNumber);
                    var revealedNumber = new StringBuilder();

                    for (var i = 0; i < 4; i++)
                    {
                        revealedNumber.Append(revealedDigits[i]);
                    }
                    
                    Console.WriteLine("The number looks like {0}", revealedNumber);
                    count2++;
                    continue;
                }

                if (command == "restart")
                {
                    Console.WriteLine();
                    GameEngine.StartGame();
                    count1 = 0;
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

                count1++;
                var bulls = 0;
                var cows = 0;
                GameEngine.CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows);
                if (command == randomNumber)
                {
                    if (count2 > 0)
                    {
                        Console.WriteLine(
                            "Congratulations! You guessed the secret number in {0} attempts and {1} cheats.",
                            count1, count2);
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        ScoreBoard.SortScoreBoard();
                        ScoreBoard.PrintScoreBoard();
                        Console.WriteLine();
                        GameEngine.StartGame();
                        count1 = 0;
                        count2 = 0;
                        randomNumber = RandomGenerator.GenerateRandomSecretNumber();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", count1);
                        ScoreBoard.AddPlayerToScoreBoard(count1);
                        count1 = 0;
                        Console.WriteLine();
                        GameEngine.StartGame();
                        randomNumber = RandomGenerator.GenerateRandomSecretNumber();
                        continue;
                    }

                    Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                }
            }
        }
    }
}