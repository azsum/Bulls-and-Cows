using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace BullsAndCows.Functionalityes
{
    using BullsAndCows.Scoreboard;

    class WriteToFile
    {
      
        public static void WriteToCSV(List<Score> scores)
        {
            StreamWriter stream = new StreamWriter(@".\..\..\Scores.csv");
            stream.Flush();
            stream.Close();
            foreach (Score score in scores)
            {
                string line = $"{score.PlayerName,-20}:{score.PlayerScore}\n";
                File.AppendAllText(@".\..\..\Scores.csv", line);
            }
        }
    }
}
