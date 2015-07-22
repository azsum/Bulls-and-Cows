using System.Collections.Generic;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public interface IScoreboard
    {
        void SortScoreboard(List<Score> scores);

        List<Score> AddPlayerToScoreboard(Player player);

        string GetScoreboard();

        void PrintScoreboard();
    }
}