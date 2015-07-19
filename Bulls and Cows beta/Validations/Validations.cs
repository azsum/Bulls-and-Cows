namespace BullsAndCows.Validations
{
    public class Validations : IValidations
    {
        private static volatile Validations validationsInstance;

        private static object syncLock = new object();

        private Validations()
        {
        }

        ////singleton creation pattern
        public static Validations InstanceValidations
        {
            get
            {
                if (validationsInstance == null)
                {
                    lock (syncLock)
                    {
                        if (validationsInstance == null)
                        {
                            validationsInstance = new Validations();
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