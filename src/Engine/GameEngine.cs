namespace BullsAndCows.Engine
{
    using System;
    using System.Collections.Generic;

    internal class GameEngine
    {
        public static void StartGame()
        {
            Console.WriteLine(BullsAndCowsTexts.WelcomeMessage);
            Console.WriteLine();
        }

        internal static bool ValidateDigits(string num)
        {
            var count = 0;
            for (var i = 0; i < 4; i++)
            {
                if (char.IsDigit(num[i]))
                {
                    count++;
                }
            }

            if (count == 4)
            {
                return true;
            }

            return false;
        }

        internal static void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
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
                    if ((i != index) && !bullIndexes.Contains(index) && !cowIndexes.Contains(index) &&
                        !bullIndexes.Contains(i))
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
    }
}