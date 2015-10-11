using BullsAndCows.Functionalities.ScoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.GameEngine
{
    public class EngineMethods : IEngine
    {
        private const int NUMBER_LENGTH = 4;

        public void DisplayStartGameIntroText()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\r\n");
            Console.WriteLine("Use 'score' to view the top scoreboard, 'restart' to start a new game and 'help' " +
                              "to cheat and 'exit' to quit the game.");
            Console.WriteLine("You have 20 credits.Each guess will cost you 1 credit.Enjoy!\r\n");
        }

        public void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows,
            int timesUsedHelp)
        {
            var bullIndexes = new List<int>();
            var cowIndexes = new List<int>();

            for (var i = 0; i < secretNumber.Length; i++)
            {
                if (guessNumber[i].Equals(secretNumber[i]))
                {
                    bullIndexes.Add(i);
                    bulls++;
                }
            }

            if (bulls == NUMBER_LENGTH && timesUsedHelp == 0)
            {
                //Player.Instance.DeterminatePlayerFinalResult();
                Engine.Instance.GameOn();
            }

            for (var i = 0; i < guessNumber.Length; i++)
            {
                for (var index = 0; index < secretNumber.Length; index++)
                {
                    var isStartDigitBull = bullIndexes.Contains(index);
                    var isCurrentDigitBull = bullIndexes.Contains(i);
                    var isDigitBull = isStartDigitBull || isCurrentDigitBull;
                    var isAlreadyAProcessedCow = cowIndexes.Contains(index);
                    var canBeACow = (i != index) && !isDigitBull && !isAlreadyAProcessedCow;
                    if (canBeACow)
                    {
                        var isACow = guessNumber[i].Equals(secretNumber[index]);
                        if (isACow)
                        {
                            cowIndexes.Add(index);
                            cows++;
                            break;
                        }
                    }
                }
            }
        }

        public string GenerateRandomSecretNumber()
        {
            var resultNumber = new StringBuilder();
            var random = new Random();
            while (resultNumber.Length != NUMBER_LENGTH)
            {
                var number = random.Next(0, 10);
                resultNumber.Append(number.ToString());
            }

            return resultNumber.ToString();
        }

        public char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
        {
            while (true)
            {
                var rand = new Random();
                var index = rand.Next(0, NUMBER_LENGTH);
                if (cheatNumber[index] == 'X')
                {
                    cheatNumber[index] = secretnumber[index];
                    return cheatNumber;
                }
            }
        }
    }
}