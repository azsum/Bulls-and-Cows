namespace BullsAndCows.Functionalities.ScoreSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public abstract class Scoreboard 
    {
        public  string Path
        {
            get
            {
                return @".\..\..\Functionalities\ScoreSystem\Scoreboard.csv";
            }
        }
        
        public string GetScoreboard()
        {
            return File.ReadAllText(Path);
        }

        public void PrintScoreboard()
        {
            string scoreboard = File.ReadAllText(Path);
            Console.WriteLine("---------Scoreboard----------");
            Console.WriteLine(scoreboard);
            Console.WriteLine("-----------------------------");
        }

        public void SortScoreboard(List<Score> scores)
        {
            scores = scores.OrderByDescending(x => x.PlayerScore).ToList();
            WriteToFIle.WriteToCsv(scores);
        }

        public List<Score> AddPlayerToScoreboard(Player player)
        {
            string[] highscores = this.GetScoreboard().Trim().Split('\n');
            List<Score> scores = new List<Score>();
            for (int i = 0; i < highscores.Length; i++)
            {
                string[] highscore = Regex.Split(highscores[i], @"[\W]+");
                scores.Add(new Score(highscore[0], int.Parse(highscore[1])));
            }

            scores.Add(new Score(player.Nickname, player.Points));
            return scores;
        }
    }
}