namespace BullsAndCows.GameEngine
{
    public interface IEngine : IRandomMethods
    {
        ////This interface will use Facade pattern
        void StartGame();

        void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows, int usingHelp);
    }
}