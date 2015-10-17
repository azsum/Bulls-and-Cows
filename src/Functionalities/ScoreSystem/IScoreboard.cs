using System.Collections.Generic;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public interface IScoreboard
    {
        IList<Score> SortScoreboard(IList<Score> scores);

        List<Score> AddPlayerToScoreboard(Player player);

        string GetScoreboard();

        void PrintScoreboard();
    }
}