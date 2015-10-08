namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IPlayer
    {
        // IScore name and points is same as IPlayers
        string Nickname { get; }

        int Points { get; }

        void GameOver();

        void PlayerWin();

        void DeterminatePlayerFinalResult();
    }
}