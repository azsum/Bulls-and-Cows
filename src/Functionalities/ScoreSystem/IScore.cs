namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IScore
    {
        string PlayerName { get; }

        int PlayerScore { get; }
    }
}