namespace BullsAndCows.GameEngine
{
    public interface IEngine
    {
        ////This interface will use Facade pattern
        void DisplayStartGameIntroText();

        void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows, int usingHelp);

        char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber);

        string GenerateRandomSecretNumber();
    }
}