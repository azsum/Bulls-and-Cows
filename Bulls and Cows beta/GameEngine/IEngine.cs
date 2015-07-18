namespace BullsAndCows.GameEngine
{
    public interface IEngine
    {
        void StartGame();

        void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows);
    }
}