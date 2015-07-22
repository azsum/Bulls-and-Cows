using System.Collections.Generic;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public interface IWriteToFile
    {
        void WriteToCsv(List<Score> scores);
    }
}