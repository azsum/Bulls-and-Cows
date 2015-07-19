namespace BullsAndCows.Functionalities.ScoreSystem
{
    internal interface IPlayer
    {
        Player CreatePlayer();

        void GameOver();

        void PlayerWin();

        void DeterminatePlayerFinalResult();
    }
}