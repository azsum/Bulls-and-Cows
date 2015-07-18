namespace BullsAndCows.Functionalityes
{
    using System.Collections.Generic;

    internal interface IScoreboard
    {
        void SortScoreBoard();
        void PrintScoreBoard();
        void AddPlayerToScoreBoard(int score);
        int SortedDictionary(KeyValuePair<string, int> left, KeyValuePair<string, int> right);
    }
}
