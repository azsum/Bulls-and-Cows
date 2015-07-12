namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class RefactoredCode
    {
        private static readonly char[] CheatNumber = { 'X', 'X', 'X', 'X' };
        private static readonly Dictionary<string, int> TopScoreBoard = new Dictionary<string, int>();
        private static readonly List<KeyValuePair<string, int>> ListDict = new List<KeyValuePair<string, int>>();
        private static int lastPlayerScore = int.MinValue;

        private static int SortDictionary(KeyValuePair<string, int> left, KeyValuePair<string, int> right)
        {
            return left.Value.CompareTo(right.Value);
        }

        private static void StartGame()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' " +
                              "to cheat and 'exit' to quit the game.");
        }

        private static bool Validation(string num)
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

        private static string GenerateRandomSecretNumber()
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

        private static void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
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

        private static char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
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

        private static void EnterScoreBoard(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            var name = Console.ReadLine();
            TopScoreBoard.Add(name, score);

            if (score > lastPlayerScore)
            {
                lastPlayerScore = score;
            }

            if (TopScoreBoard.Count > 5)
            {
                foreach (var player in TopScoreBoard)
                {
                    if (player.Value == lastPlayerScore)
                    {
                        TopScoreBoard.Remove(player.Key);
                        break;
                    }
                }
            }

            SortAndPrintScoreBoard();
        }

        private static void SortAndPrintScoreBoard()
        {
            foreach (var pair in TopScoreBoard)
            {
                ListDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            ListDict.Sort(SortDictionary);
            Console.WriteLine("Scoreboard: ");
            var counter = 0;
            foreach (var player in ListDict)
            {
                counter++;
                Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
            }

            ListDict.Clear();
        }

        private static void Main()
        {
            StartGame();

            var randomNumber = GenerateRandomSecretNumber();
            string option = null;
            var count1 = 0;
            var count2 = 0;

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                option = Console.ReadLine();

                if (option == "help")
                {
                    var revealedDigits = RevealNumberAtRandomPosition(randomNumber, CheatNumber);
                    var revealedNumber = new StringBuilder();
                    for (var i = 0; i < 4; i++)
                    {
                        revealedNumber.Append(revealedDigits[i]);
                    }

                    Console.WriteLine("The number looks like {0}", revealedNumber);
                    count2++;
                    continue;
                }

                if (option == "restart")
                {
                    Console.WriteLine();
                    StartGame();
                    count1 = 0;
                    randomNumber = GenerateRandomSecretNumber();
                    continue;
                }

                if (option == "top")
                {
                    if (TopScoreBoard.Count == 0)
                    {
                        Console.WriteLine("Top scoreboard is empty.");
                    }
                    else
                    {
                        SortAndPrintScoreBoard();
                    }

                    continue;
                }

                if (option == "exit")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }

                if (option.Length != 4 || Validation(option) == false)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                count1++;
                var bulls = 0;
                var cows = 0;
                CalculateBullsAndCows(randomNumber, option, ref bulls, ref cows);
                if (option == randomNumber)
                {
                    if (count2 > 0)
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", count1, count2);
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        SortAndPrintScoreBoard();
                        Console.WriteLine();
                        StartGame();
                        count1 = 0;
                        count2 = 0;
                        randomNumber = GenerateRandomSecretNumber();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", count1);
                        EnterScoreBoard(count1);
                        count1 = 0;
                        Console.WriteLine();
                        StartGame();
                        randomNumber = GenerateRandomSecretNumber();
                    }

                    continue;
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}