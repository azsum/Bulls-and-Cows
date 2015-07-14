namespace BullsAndCows.Engine
{
    using System;
    using System.Text;
    using AbstractClasses;
    using Validations;
    using Interfaces;

    internal class GameOn : AbstractScoreboard, IRandomGenerator

    {
        public static void RunTheGame()
        {
            GameOn instance = new GameOn();
            instance.Game();
        }

        public string GenerateRandomSecretNumber()
        {
            var secretNumber = new StringBuilder();
            var random = new Random();
            while (secretNumber.Length != 4)
            {
                var number = random.Next(0, 10);
                secretNumber.Append(number.ToString());
            }

            return secretNumber.ToString();
        }

        public char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
        {
            while (true)
            {
                var rand = new Random();
                var index = rand.Next(0, 4);
                if (cheatNumber[index] == 'X')
                {
                    cheatNumber[index] = secretnumber[index];
                    return cheatNumber;
                }
            }
        }

        protected void Game()
        {
            EngineMethods.StartGame();
            var randomNumber = GenerateRandomSecretNumber();
            var countRevealingDigits = 0;
            var attemptsCount = 0;
            var usingHelpCount = 0;
            char[] cheatNumber = { 'X', 'X', 'X', 'X' };
            while (true)
            {
                Console.Write("Enter your guess or command: ");
                var command = Console.ReadLine();
                if (command == "help")
                {
                    var revealedDigits = RevealNumberAtRandomPosition(randomNumber, cheatNumber);
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
                        Game();
                        // to exit the game after exiting the upper game
                        break;
                    }

                    Console.WriteLine("The number looks like {0}", revealedNumber);

                    usingHelpCount++;
                    continue;
                }

                if (command == "restart")
                {
                    Console.WriteLine();
                    EngineMethods.StartGame();
                    attemptsCount = 0;
                    randomNumber = GenerateRandomSecretNumber();
                    continue;
                }

                if (command == "top")
                {
                    if (TopScoreBoard.Count == 0)
                    {
                        Console.WriteLine("Top scoreboard is empty.");
                    }
                    else
                    {
                        SortScoreBoard();
                        PrintScoreBoard();
                    }

                    continue;
                }

                if (command == "exit")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }

                if (command.Length != 4 || Validators.ValidateDigits(command) == false)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                attemptsCount++;
                var bulls = 0;
                var cows = 0;
                EngineMethods.CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows);
                if (command == randomNumber)
                {
                    if (usingHelpCount > 0)
                    {
                        Console.WriteLine(
                            "Congratulations! You guessed the secret number in {0} attempts and {1} cheats.",
                            attemptsCount, usingHelpCount);
                        //Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        //ScoreBoard.SortScoreBoard();
                        //ScoreBoard.PrintScoreBoard();
                        Console.WriteLine();
                        EngineMethods.StartGame();
                        attemptsCount = 0;
                        usingHelpCount = 0;
                        randomNumber = GenerateRandomSecretNumber();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attemptsCount);
                        AddPlayerToScoreBoard(attemptsCount);
                        attemptsCount = 0;
                        Console.WriteLine();
                        EngineMethods.StartGame();
                        randomNumber = GenerateRandomSecretNumber();
                    }

                    continue;
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}