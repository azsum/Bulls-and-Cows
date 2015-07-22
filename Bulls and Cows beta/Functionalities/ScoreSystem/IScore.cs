namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IScore
    {
        int PlayerScore { get; }

        string PlayerName { get; }
    }
}