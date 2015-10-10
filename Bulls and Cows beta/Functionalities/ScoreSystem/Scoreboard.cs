using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class Scoreboard : IScoreboard
    {
        // should be set so filewriter and this point to one object and if one is changed in both places
        // it will be reflected
        public string Path
        {
            get { return @"../Save/Scoreboard.csv"; }
        }

        public string GetScoreboard()
        {
            return File.ReadAllText(Path);
        }

        public void PrintScoreboard()
        {
            var scoreboard = File.ReadAllText(Path);
            Console.WriteLine("---------Scoreboard----------");
            Console.WriteLine(scoreboard);
            Console.WriteLine("-----------------------------");
        }

        // breaks because it needs FileWriter
        public IList<Score> SortScoreboard(IList<Score> scores)
        {
            var sorted = new List<Score>();
            sorted = scores.OrderByDescending(x => x.PlayerScore).ToList();
            return sorted;
        }

        public List<Score> AddPlayerToScoreboard(Player player)
        {
            var highscores = GetScoreboard().Trim().Split('\n');
            var scores = new List<Score>();
            var pattern = @"(\d+)[^\d]*$";
            for (var i = 0; i < highscores.Length; i++)
            {
                var highscore = Regex.Split(highscores[i], pattern);
                scores.Add(new Score(highscore[0], int.Parse(highscore[1])));
            }

            scores.Add(new Score(player.Nickname, player.Points));
            return scores;
        }
    }
}