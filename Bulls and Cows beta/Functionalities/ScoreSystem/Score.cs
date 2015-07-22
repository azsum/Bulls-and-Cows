namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class Score : IScore
    {
        private readonly string playerName;
        private readonly int playerScore;

        public Score(string playerName, int playerScore)
        {
            this.playerName = playerName;
            this.playerScore = playerScore;
        }

        public int PlayerScore
        {
            get { return playerScore; }
        }

        public string PlayerName
        {
            get { return playerName; }
        }
    }
}