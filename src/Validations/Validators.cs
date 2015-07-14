namespace BullsAndCows.Validations
{
    public class Validators
    {
        internal static bool ValidateDigits(string number)
        {
            var count = 0;
            for (var i = 0; i < 4; i++)
            {
                if (char.IsDigit(number[i]))
                {
                    count++;
                }
            }

            if (count == 4)
            {
                return true;
            }

            return false;
        }
    }
}
