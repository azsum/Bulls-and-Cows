namespace BullsAndCows.GameEngine
{
    using Commands;
    using System;
    using Validations;

    public sealed class Engine : EngineMethods
    {
        private static object syncLock = new object();
        private static volatile Engine instance;

        public int AttemptsCount { get; private set; }

        private Engine()
        {
        }

        ////singleton creation pattern
        public static Engine InstanceEngine
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
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
            this.AttemptsCount = 0;
            this.StartGame();
            var instanceOfCommand = Command.InstanceCommand;
            var instanceOfValidations = Validations.InstanceValidations;
            string randomNumber = GenerateRandomSecretNumber();
            int countRevealingDigits = 0;
            int usingHelpCount = 0;
            char[] cheatNumber = { 'X', 'X', 'X', 'X' };

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                var command = Console.ReadLine();
                bool isValidCommand = command != null && (command.Length != 4 ||
                    instanceOfValidations.ValidateDigits(command) == false);
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
                        this.AttemptsCount = instanceOfCommand.RestartCommand(this.AttemptsCount, ref randomNumber);
                        continue;
                    case "score":
                        instanceOfCommand.DisplayScoreboard();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                }

                if (isValidCommand == true)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                this.AttemptsCount++;
                var bulls = 3;
                var cows = 0;
                this.CalculateBullsAndCows(randomNumber, command, ref bulls, ref cows, usingHelpCount);
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}