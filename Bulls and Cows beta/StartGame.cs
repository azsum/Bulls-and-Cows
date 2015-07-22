using BullsAndCows.GameEngine;

namespace BullsAndCows
{
    public class StartGame
    {
        public static void Main()
        {
            var instance = Engine.InstanceEngine;
            instance.GameOn();
        }
    }
}