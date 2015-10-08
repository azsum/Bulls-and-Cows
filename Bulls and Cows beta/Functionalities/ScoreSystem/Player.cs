﻿using BullsAndCows.GameEngine;
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
        
        public Player(int points)
        {
            this.Points = points;
        }

        public Player(string nickname, int points)
            : this(points)
        {
            this.Nickname = nickname;
        }

        public string Nickname { get; private set; }

        public int Points { get; private set; }

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