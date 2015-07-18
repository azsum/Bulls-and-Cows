namespace BullsAndCows.GameEngine
{
    using Commands;
    using System;
    using Validations;

    public sealed class Engine : EngineMethods
    {
        private static volatile Engine instance;
        public static object SyncLock { get; } = new object();

        private Engine()
        {
        }

        //singelton creational pattern
        public static Engine InstanceEngine
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Engine();
                        }
                    }
                }
                return instance;
            }
        }
       
        public void GameOn()
        {
            StartGame();
            var instanceOfCommand = Command.InstanceCommand;
            string randomNumber = GenerateRandomSecretNumber();
            int countRevealingDigits = 0;
            int attemptsCount = 0;
            int usingHelpCount = 0;
            char[] cheatNumber = { 'X', 'X', 'X', 'X' };
            while (true)
            {
                Console.Write("Enter your guess or command: ");
                var command = Console.ReadLine();
                bool isValidCommand = command != null && (command.Length != 4 || Validators.ValidateDigits(command) == false);
                switch (command)
                {
                    case "help":
                        var helpCommand = instanceOfCommand.HelpCommand(randomNumber, cheatNumber, ref countRevealingDigits, ref usingHelpCount);

                        if (helpCommand)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    case "restart":
                        attemptsCount = instanceOfCommand.RestartCommand(attemptsCount, ref randomNumber);
                        continue;
                    case "scoreboard":
                        instanceOfCommand.TopCommand();
                        break;
                    case "exit":
                        break;
                }

                if (isValidCommand)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                attemptsCount++;
                var bulls = 0;
                var cows = 0;
                CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows);
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}