namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IPlayer
    {
        string Nickname { get; set; }

        int Points { get; set; }

        Player CreatePlayer();

        void GameOver();

        void PlayerWin();

        void DeterminatePlayerFinalResult();
    }
}