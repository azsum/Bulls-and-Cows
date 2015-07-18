namespace BullsAndCows.Functionalityes
{
    using System;
    using System.Collections.Generic;

    public abstract class Scoreboard:IScoreboard
    {
        private  int lastPlayerScore = Int32.MinValue;
        private  readonly List<KeyValuePair<string, int>> listDict = new List<KeyValuePair<string, int>>();
        internal  readonly Dictionary<string, int> TopScoreBoard = new Dictionary<string, int>();

        public  int SortedDictionary(KeyValuePair<string, int> left, KeyValuePair<string, int> right)
        {
            return left.Value.CompareTo(right.Value);
        }

        public  void SortScoreBoard()
        {
            foreach (var pair in TopScoreBoard)
            {
                listDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            listDict.Sort(SortedDictionary);
            Console.WriteLine("Scoreboard: ");
        }

        public  void PrintScoreBoard()
        {
            int counter = 0;
            foreach (KeyValuePair<string, int> player in listDict)
            {
                counter++;
                Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
            }
            listDict.Clear();
        }

        public  void AddPlayerToScoreBoard(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            if (name != null)
            {
                TopScoreBoard.Add(name, score);
            }

            if (score > lastPlayerScore)
            {
                lastPlayerScore = score;
            }

            if (TopScoreBoard.Count > 5)
            {
                foreach (KeyValuePair<string, int> player in TopScoreBoard)
                {
                    if (player.Value == lastPlayerScore)
                    {
                        TopScoreBoard.Remove(player.Key);
                        break;
                    }
                }
            }
            SortScoreBoard();
            PrintScoreBoard();
        }
    }
}