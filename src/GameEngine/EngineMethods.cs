﻿namespace BullsAndCows.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Functionalityes;

    public class EngineMethods : Scoreboard,IRandomMethods,IEngine
    {
        public  void StartGame()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\r\n");
            Console.WriteLine("Use 'scoreboard' to view the top scoreboard, 'restart' to start a new game and 'help' " +
                              "to cheat and 'exit' to quit the game.");
        }

        public  void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
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

            for (var i = 0; i < guessNumber.Length; i++)
            {
                for (var index = 0; index < secretNumber.Length; index++)
                {
                    var isCow = (i != index) && !bullIndexes.Contains(index) && !cowIndexes.Contains(index) &&
                                !bullIndexes.Contains(i);
                    if (isCow)
                    {
                        if (guessNumber[i].Equals(secretNumber[index]))
                        {
                            cowIndexes.Add(index);
                            cows++;
                            break;
                        }
                    }
                }
            }
        }

        public  string GenerateRandomSecretNumber()
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

        public  char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
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
    }
}