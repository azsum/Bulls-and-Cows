namespace BullsAndCows.Validations
{
    public class Validator : IValidator
    {
        private const int NUMBER_LENGTH = 4;
        private static volatile Validator validationsInstance;
        private static readonly object SyncLock = new object();

        private Validator()
        {
        }

        ////singleton creation pattern
        public static Validator Instance
        {
            get
            {
                if (validationsInstance == null)
                {
                    lock (SyncLock)
                    {
                        if (validationsInstance == null)
                        {
                            validationsInstance = new Validator();
                        }
                    }
                }

                return validationsInstance;
            }
        }

        public bool ValidateDigits(string number)
        {
            var isValidNumber = true;
            var isNumberFourDigitsLong = number.Trim().Length <= NUMBER_LENGTH;
            if (isNumberFourDigitsLong)
            {
                for (var i = 0; i < NUMBER_LENGTH; i++)
                {
                    var isCharDigit = char.IsDigit(number[i]);
                    if (!isCharDigit)
                    {
                        isValidNumber = false;
                    }
                }
            }
            else
            {
                isValidNumber = false;
            }

            return isValidNumber;
        }
    }
}