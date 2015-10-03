namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IPlayer
    {
        // IScore name and points is same as IPlayers
        string Nickname { get; set; }

        int Points { get; set; }

        Player CreatePlayer();

        void GameOver();

        void PlayerWin();

        void DeterminatePlayerFinalResult();
    }
}