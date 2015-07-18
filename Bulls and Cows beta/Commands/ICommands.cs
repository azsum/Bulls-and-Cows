namespace BullsAndCows.Commands
{
    public interface ICommands
    {
        bool HelpCommand(string randomNumber, char[] cheatNumber, ref int countRevealingDigits, ref int usingHelpCount);

        int RandomNumberCommand(int usingHelpCount, ref int attemptsCount, ref string randomNumber);

        void TopCommand();

        int RestartCommand(int attemptsCount, ref string randomNumber);
    }
}