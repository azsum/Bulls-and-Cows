namespace BullsAndCows.Validations
{
    public class Validator : IValidator
    {
        private static volatile Validator validationsInstance;
        private static readonly object SyncLock = new object();

        private Validator()
        {
        }

        ////singleton creation pattern
        public static Validator InstanceValidations
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
            var count = 0;
            for (var i = 0; i < 4; i++)
            {
                if (char.IsDigit(number[i]))
                {
                    count++;
                }
            }

            if (count <= 4)
            {
                return true;
            }

            return false;
        }
    }
}