using BullsAndCows.GameEngine;
using System;

namespace BullsAndCows.Functionalities.ScoreSystem
{
    public class Player : IPlayer
    {
        private const int Credits = 20;
        private static volatile Player instance;
        private static readonly object SyncLock = new object();
        private readonly int finalPoints = Credits - Engine.Instance.AttemptsCount;
        // add scoreboard?

        private Player()
        {
        }

        public Player(string nickname, int points)
        {
            Nickname = nickname;
            Points = points;
        }

        ////singleton creation pattern
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
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

        public string Nickname { get; set; }

        public int Points { get; set; }

        public void DeterminatePlayerFinalResult()
        {
            if (finalPoints > 0)
            {
                PlayerWin();
            }
            else
            {
                GameOver();
            }
        }

        // breaks because we don`t have Scoreboard to use
        // set messages as variables(const?), can we use the algorithm changing pattern or is it overkill 
        public void PlayerWin()
        {
            Console.Clear();
            Console.WriteLine("Congratulations!!! You win!");
            Console.WriteLine();
            var player = CreatePlayer();
            var scoreboard = AddPlayerToScoreboard(player);
            SortScoreboard(scoreboard);
            PrintScoreboard();
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Please try again");
            Console.WriteLine();
            PrintScoreboard();
        }

        public Player CreatePlayer()
        {
            Console.WriteLine("Enter a nickname in less than 25 symbols");
            var name = Console.ReadLine();
            while (name.Length > 25)
            {
                Console.WriteLine("Enter a nickname in less than 25 symbols");
                name = Console.ReadLine();
            }

            var player = new Player(name, finalPoints);
            return player;
        }
    }
}