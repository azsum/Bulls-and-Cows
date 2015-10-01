using System.Collections.Generic;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public interface IFileWriter
    {
        void WriteToCsv(List<Score> scores);
    }
}