namespace BullsAndCows.Functionalityes
{
    using System.IO;

    class ReadFromFile
    {
        public static string ReadFromCsv(string path)
        {
            return File.ReadAllText(@path);
        }
    }
}
