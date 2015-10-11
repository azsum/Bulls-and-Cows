
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
            DisplayStartGameIntroText();
            var instanceOfCommand = Command.Instance;
            var instanceOfValidations = Validations.Validator.Instance;
            var randomNumber = GenerateRandomSecretNumber();
            var countRevealingDigits = 0;
            var timesUsedHelp = 0;
            char[] cheatNumber = { 'X', 'X', 'X', 'X' };

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        var helpCommand = instanceOfCommand.HelpCommand(randomNumber, cheatNumber,
                            ref countRevealingDigits, ref timesUsedHelp);
                        
                        continue;
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

                var isValidAction = command != null && (command.Length != 4 ||
                                                         instanceOfValidations.ValidateDigits(command) == false);
                if (isValidAction)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                int guess;
                var bulls = 0;
                var cows = 0;
                var isValidGuess = int.TryParse(command, out guess);
                if (isValidGuess)
                {
                    AttemptsCount++;
                    CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows, timesUsedHelp);
                    Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                }
            }
        }
    }
}