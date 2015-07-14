using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    public interface IRandomGenerator
    {
        string GenerateRandomSecretNumber();

        char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber);
    }
}
