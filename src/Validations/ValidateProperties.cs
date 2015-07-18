using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BullsAndCows.Validations
{
    class ValidateProperties
    {
       public static void ValidateName(string name)
        {    // match only digits and numbers
            Regex regex = new Regex(@"\A[0-9][a-zA-Z]*\Z");
            Match match = regex.Match(name);

            if (match.Length != name.Length)
            {
                Console.WriteLine("Please enter only letters or digits, without whitepace");
            }
        }

        public static bool ValidateNumberDigits(string number)
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
