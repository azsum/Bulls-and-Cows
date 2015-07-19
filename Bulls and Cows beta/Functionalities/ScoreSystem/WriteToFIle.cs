namespace BullsAndCows.Functionalities.ScoreSystem
{
    using System.Collections.Generic;
    using System.IO;

    public class WriteToFIle
    {
        public static void WriteToCsv(List<Score> scores)
        {
            var path = GameEngine.Engine.InstanceEngine.Path;
            StreamWriter stream = new StreamWriter(path);
            stream.Flush();
            stream.Close();
            foreach (Score score in scores)
            {
                string line = string.Format("{0,-20}:{1}\n", score.PlayerName, score.PlayerScore);
                File.AppendAllText(path, line);
            }
        }
    }
}