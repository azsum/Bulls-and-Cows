using System.Collections.Generic;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public interface IFileWriter
    {
        void Write(List<Score> scores);
    }
}