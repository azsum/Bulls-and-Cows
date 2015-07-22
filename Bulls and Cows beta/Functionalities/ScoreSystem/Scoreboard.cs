using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public abstract class Scoreboard
    {
        public string Path
        {
            get { return @".\..\..\Functionalities\ScoreSystem\Scoreboard.csv"; }
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

        public void SortScoreboard(List<Score> scores)
        {
            scores = scores.OrderByDescending(x => x.PlayerScore).ToList();
            WriteToFile.WriteToCsv(scores);
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