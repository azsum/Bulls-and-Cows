namespace BullsAndCows.Functionalities.ScoreSystem
{
    using GameEngine;
    using System;

    public class Player : Scoreboard, IPlayer
    {
        private readonly static object syncLock = new object();
        private static volatile Player instance;
        private string nickname;
        private int points;
        private const int Credits = 20;
        private readonly int finalPoints = Credits - Engine.InstanceEngine.AttemptsCount;

        public int AttemptsCount { get; private set; }

        private Player()
        {
        }

        ////singleton creation pattern
        public static Player InstancePlayer
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Player();
                        }
                    }
                }

                return instance;
            }
        }

        public Player(string nickname, int points)
        {
            this.nickname = nickname;
            this.points = points;
        }

        public string Nickname
        {
            get { return this.nickname; }
            set { this.nickname = value.Length > 30 ? value.Remove(30, value.Length - 30) : value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public void DeterminatePlayerFinalResult()
        {
            if (this.finalPoints > 0)
            {
                PlayerWin();
            }
            else
            {
                GameOver();
            }
        }

        public void PlayerWin()
        {
            Console.Clear();
            Console.WriteLine("Congratulations!!! You win!");
            Console.WriteLine();
            Player player = this.CreatePlayer();
            var scoreboard = AddPlayerToScoreboard(player);
            this.SortScoreboard(scoreboard);
            this.PrintScoreboard();
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Please try again");
            Console.WriteLine();
            this.PrintScoreboard();
        }

        public Player CreatePlayer()
        {
            Console.WriteLine("Enter a nickname without any whitespace");
            this.nickname = Console.ReadLine();
            return new Player(nickname, this.finalPoints);
        }
    }
}