namespace BullsAndCows.Commands
{
    public interface ICommand
    {
        bool HelpCommand(string randomNumber, char[] cheatNumber, ref int countRevealingDigits, ref int usingHelpCount);

        void DisplayScoreboard();

        int RestartCommand(int attemptsCount, ref string randomNumber);
    }
}