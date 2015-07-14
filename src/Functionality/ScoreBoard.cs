namespace BullsAndCows.Components
{
    using System;
    using System.Collections.Generic;

    internal class ScoreBoard
    {
        internal static readonly Dictionary<string, int> TopScoreBoard = new Dictionary<string, int>();

        private static readonly List<KeyValuePair<string, int>> ListDict = new List<KeyValuePair<string, int>>();

        private static int lastPlayerScore = int.MinValue;

        internal static void SortScoreBoard()
        {
            foreach (var pair in TopScoreBoard)
            {
                ListDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            ListDict.Sort(SortDictionary);
            Console.WriteLine("Scoreboard: ");
        }

        internal static void PrintScoreBoard()
        {
            var counter = 0;
            foreach (var player in ListDict)
            {
                counter++;
                Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
            }

            ListDict.Clear();
        }

        internal static void AddPlayerToScoreBoard(int score)
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

            SortScoreBoard();
        }

        private static int SortDictionary(KeyValuePair<string, int> left, KeyValuePair<string, int> right)
        {
            return left.Value.CompareTo(right.Value);
        }
    }
}