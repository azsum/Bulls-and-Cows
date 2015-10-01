using BullsAndCows.GameEngine;
using System.Collections.Generic;
using System.IO;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class FileWriter
    {
        public static void WriteToCsv(List<Score> scores)
        {
            var path = Engine.InstanceEngine.Path;
            var stream = new StreamWriter(path);
            stream.Flush();
            stream.Close();
            foreach (var score in scores)
            {
                var line = string.Format("{0,-30}{1}\n", score.PlayerName, score.PlayerScore);
                File.AppendAllText(path, line);
            }
        }
    }
}