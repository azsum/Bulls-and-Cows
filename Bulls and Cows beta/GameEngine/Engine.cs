
namespace BullsAndCows.GameEngine
{
    using Commands;
    using System;

    public sealed class Engine : EngineMethods
    {
        private static readonly object SyncLock = new object();
        private static volatile Engine instance;

        private Engine()
        {
        }

        public int AttemptsCount { get; private set; }

        ////singleton creation pattern
        public static Engine Instance
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
            AttemptsCount = 0;
            StartGame();
            var instanceOfCommand = Command.InstanceCommand;
            var instanceOfValidations = Validations.Validator.Instance;
            var randomNumber = GenerateRandomSecretNumber();
            var countRevealingDigits = 0;
            var usingHelpCount = 0;
            char[] cheatNumber = { 'X', 'X', 'X', 'X' };

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                var command = Console.ReadLine();
                var isValidCommand = command != null && (command.Length != 4 ||
                                                         instanceOfValidations.ValidateDigits(command) == false);
                switch (command)
                {
                    case "help":
                        var helpCommand = instanceOfCommand.HelpCommand(randomNumber, cheatNumber,
                            ref countRevealingDigits, ref usingHelpCount);

                        if (helpCommand)
                        {
                            continue;
                        }
                        break;

                    case "restart":
                        AttemptsCount = instanceOfCommand.RestartCommand(AttemptsCount, ref randomNumber);
                        continue;
                    case "score":
                        instanceOfCommand.DisplayScoreboard();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                }

                if (isValidCommand)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                AttemptsCount++;
                var bulls = 3;
                var cows = 0;
                CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows, usingHelpCount);
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}