namespace BullsAndCows.GameEngine
{
    public interface IRandomMethods
    {
        char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber);

        string GenerateRandomSecretNumber();
    }
}
