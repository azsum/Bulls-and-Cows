namespace BullsAndCows
{
    public class StartGame 
    {
        public static void Main()
        {
            var instance = GameEngine.Engine.InstanceEngine;
            instance.GameOn();
        }
    }
}