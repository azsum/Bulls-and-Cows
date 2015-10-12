using BullsAndCows.Functionalities.ScoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.GameEngine
{
    public class EngineMethods : IEngine
    {
        private const int NUMBER_LENGTH = 4;
        private readonly string IntroMessage = "Welcome to “Bulls and Cows”. Please try to guess my secret 4-digit number. Use 'score' to view the top scoreboard, 'restart' to start a new game and 'help' to reveal one of the digits, and 'exit' to quit the game. You have 20 credits.Each guess will cost you 1 credit. Enjoy!\r\n";

        public void DisplayStartGameIntroText()
        {
            //Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\r\n");
            //Console.WriteLine("Use 'score' to view the top scoreboard, 'restart' to start a new game and 'help' " +
            //                  "to cheat and 'exit' to quit the game.");
            //Console.WriteLine("You have 20 credits.Each guess will cost you 1 credit.Enjoy!\r\n");
            Console.WriteLine(this.IntroMessage);
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
                for (var j = 0; j < secretNumber.Length; j++)
                {
                    var isStartDigitBull = bullIndexes.Contains(j);
                    var isCurrentDigitBull = bullIndexes.Contains(i);
                    var isDigitBull = isStartDigitBull || isCurrentDigitBull;
                    var isAlreadyAProcessedCow = cowIndexes.Contains(j);
                    var canBeACow = (i != j) && !isDigitBull && !isAlreadyAProcessedCow;
                    if (canBeACow)
                    {
                        var isACow = guessNumber[i].Equals(secretNumber[j]);
                        if (isACow)
                        {
                            cowIndexes.Add(j);
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