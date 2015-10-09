using BullsAndCows.GameEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class FileWriter : IFileWriter
    {
        // add different types of files
        public void Write(List<Score> scores)
        {
            // should be set so filewriter and this point to one object and if one is changed in both places
            // it will be reflected
            // or other file format
            var path = "../Save/Scoreboard.csv";
            var scoreRowFormat = "{0,-30}{1}";
            using (StreamWriter stream = new StreamWriter(path))
            {
                StringBuilder builder = new StringBuilder();
                foreach (var score in scores)
                {
                    builder.AppendFormat(scoreRowFormat, score.PlayerName, score.PlayerScore);
                    var result = builder.ToString();
                    stream.WriteLine(result);
                }
            }
        }
    }
}