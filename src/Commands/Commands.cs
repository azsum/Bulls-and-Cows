namespace BullsAndCows.Commands
{
    using System;
    using System.Text;
    using GameEngine;

    public sealed class Command : EngineMethods, ICommands
    {
        private static volatile Command commandInstance;
        public static object SyncLock { get; } = new object();

        private Command()
        {
        }

        //singelton creational pattern
        public static Command InstanceCommand
        {
            get
            {
                if (commandInstance == null)
                {
                    lock (SyncLock)
                    {
                        if (commandInstance == null)
                        {
                            commandInstance = new Command();
                        }
                    }
                }
                return commandInstance;
            }
        }

        public bool HelpCommand(string randomNumber, char[] cheatNumber, ref int countRevealingDigits, ref int usingHelpCount)
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
                Engine.InstanceEngine.GameOn();
                // to exit the game after exiting the upper game
                return true;
            }

            Console.WriteLine("The number looks like {0}", revealedNumber);
            usingHelpCount++;
            return true;
        }

        public int RandomNumberCommand(int usingHelpCount, ref int attemptsCount, ref string randomNumber)
        {
            if (usingHelpCount > 0)
            {
                Console.WriteLine(
                    "Congratulations! You guessed the secret number in {0} attempts and {1} cheats.",
                    attemptsCount, usingHelpCount);
                Console.WriteLine();
                StartGame();
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
                StartGame();
                randomNumber = GenerateRandomSecretNumber();
            }

            return usingHelpCount;
        }

        public void TopCommand()
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
        }

        public int RestartCommand(int attemptsCount, ref string randomNumber)
        {
            Console.WriteLine();
            StartGame();
            attemptsCount = 0;
            randomNumber = GenerateRandomSecretNumber();
            return attemptsCount;
        }
    }
}