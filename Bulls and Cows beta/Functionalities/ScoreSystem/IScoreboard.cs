namespace BullsAndCows.Functionalities.ScoreSystem
{
    using System.Collections.Generic;

    public interface IScoreboard
    {
        void SortScoreboard(List<Score> scores);

        List<Score> AddPlayerToScoreboard(Player player);

        string GetScoreboard();

        void PrintScoreboard();
    }
}