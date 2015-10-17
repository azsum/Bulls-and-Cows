namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class Score : IScore
    {
        private string playerName;
        private int playerScore;

        public Score(string playerName, int playerScore)
        {
            this.PlayerName = playerName;
            this.PlayerScore = playerScore;
        }

        public string PlayerName
        {
            get { return this.playerName; }
            private set
            {
                this.playerName = value;
            }

        }

        public int PlayerScore
        {
            get { return this.playerScore; }
            private set
            {
                this.playerScore = value;
            }
        }
    }
}