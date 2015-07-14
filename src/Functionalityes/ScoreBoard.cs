
namespace BullsAndCows.Functionalityes
{
    using System;
    using System.Collections.Generic;
    using AbstractClasses;

    public class ScoreBoard : AbstractScoreboard
    {
        public override void SortScoreBoard()
        {
            foreach (var pair in TopScoreBoard)
            {
                ListDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            ListDict.Sort(SortDictionary);
            Console.WriteLine("Scoreboard: ");
        }

        public override void PrintScoreBoard()
        {
            var counter = 0;
            foreach (var player in ListDict)
            {
                counter++;
                Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
            }

            ListDict.Clear();
        }

        public override void AddPlayerToScoreBoard(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            var name = Console.ReadLine();
            TopScoreBoard.Add(name, score);

            if (score > LastPlayerScore)
            {
                LastPlayerScore = score;
            }

            if (TopScoreBoard.Count > 5)
            {
                foreach (var player in TopScoreBoard)
                {
                    if (player.Value == LastPlayerScore)
                    {
                        TopScoreBoard.Remove(player.Key);
                        break;
                    }
                }
            }
            SortScoreBoard();
        }
    }
}