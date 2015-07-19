namespace BullsAndCows.Commands
{
    public interface ICommands
    {
        bool HelpCommand(string randomNumber, char[] cheatNumber, ref int countRevealingDigits, ref int usingHelpCount);

        void DisplayScoreboard();

        int RestartCommand(int attemptsCount, ref string randomNumber);
    }
}