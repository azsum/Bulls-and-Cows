namespace BullsAndCows.Commands
{
    using BullsAndCows.GameEngine;
    using System;
    using System.Text;

    public sealed class Command : EngineMethods, ICommand
    {
        private static readonly object SyncLock = new object();
        private static volatile Command commandInstance;

        private Command()
        {
        }

        ////singleton creation pattern
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

        public bool HelpCommand(string randomNumber, char[] cheatNumber, ref int countRevealingDigits,
            ref int usingHelpCount)
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
                Engine.Instance.GameOn();
                return true;
            }

            Console.WriteLine("The number looks like {0}", revealedNumber);
            usingHelpCount++;
            return true;
        }

        public void DisplayScoreboard()
        {
            PrintScoreboard();
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